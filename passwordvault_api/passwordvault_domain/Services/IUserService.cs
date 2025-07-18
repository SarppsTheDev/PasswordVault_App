using passwordvault_domain.Entities;

namespace passwordvault_domain.Services;

public interface IUserService
{
    Task<User> UpdateProfile(string userId, string firstName, string lastName);
    Task DeleteUser(User user);
}