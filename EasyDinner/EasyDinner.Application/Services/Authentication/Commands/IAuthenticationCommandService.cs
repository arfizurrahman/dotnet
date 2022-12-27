using EasyDinner.Application.Common.Errors;
using EasyDinner.Application.Services.Authentication.Common;
using ErrorOr;
using FluentResults;

namespace EasyDinner.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}