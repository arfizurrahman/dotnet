using EasyDinner.Application.Common.Errors;
using EasyDinner.Application.Common.Interfaces.Authentication;
using EasyDinner.Application.Common.Interfaces.Persistence;
using EasyDinner.Domain.Entities;
using OneOf;

namespace EasyDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public AuthenticationResult Login(string email, string password)
    {
        // 1. Validate the user does exist
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email doest not exist.");
        }
        // 2. Validate the password is correct
        if (user.Passowrd != password)
        {
            throw new Exception("Invalid password.");
        }
        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public OneOf<AuthenticationResult, IError> Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return new DuplicateEmailError();
        }
        // 2. Create user (generate unique ID) & Persist to DB
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Passowrd = password
        };

        _userRepository.Add(user);

        // 3. Create JWT token
        Guid userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}