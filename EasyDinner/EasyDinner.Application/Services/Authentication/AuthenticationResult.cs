using EasyDinner.Domain.Entities;

namespace EasyDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);