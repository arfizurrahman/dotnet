using EasyDinner.Application.Common.Errors;
using ErrorOr;
using FluentResults;

namespace EasyDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}