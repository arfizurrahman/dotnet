using EasyDinner.Domain.Entities;

namespace EasyDinner.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);