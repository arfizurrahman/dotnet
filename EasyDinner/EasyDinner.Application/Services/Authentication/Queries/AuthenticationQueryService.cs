using EasyDinner.Application.Common.Interfaces.Authentication;
using EasyDinner.Application.Common.Interfaces.Persistence;
using EasyDinner.Application.Services.Authentication.Common;
using EasyDinner.Domain.Common.Errors;
using EasyDinner.Domain.Entities;
using ErrorOr;

namespace EasyDinner.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        // 1. Validate the user does exist
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        // 2. Validate the password is correct
        if (user.Passowrd != password)
        {
            return new[] { Errors.Authentication.InvalidCredentials };
        }
        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}