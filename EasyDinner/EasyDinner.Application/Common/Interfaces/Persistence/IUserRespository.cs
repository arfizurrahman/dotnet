
using EasyDinner.Domain.Entities;

namespace EasyDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
};