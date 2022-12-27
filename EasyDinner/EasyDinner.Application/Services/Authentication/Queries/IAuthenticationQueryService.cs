using EasyDinner.Application.Common.Errors;
using EasyDinner.Application.Services.Authentication.Common;
using ErrorOr;
using FluentResults;

namespace EasyDinner.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}