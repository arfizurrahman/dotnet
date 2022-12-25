using EasyDinner.Domain.Entities;

namespace EasyDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}