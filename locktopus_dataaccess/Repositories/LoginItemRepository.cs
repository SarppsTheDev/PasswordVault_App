using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using locktopus_domain.Entities;
using locktopus_domain.Exceptions;
using locktopus_domain.Repositories;

namespace locktopus_dataaccess.Repositories;

public class LoginItemRepository(AppDbContext dbContext, ILogger<LoginItemRepository> logger) : ILoginItemRepository
{
    private DbSet<LoginItem> LoginItems => dbContext.Set<LoginItem>();

    public async Task<long> Create(LoginItem loginItem)
    {
        LoginItems.Add(loginItem);
        await dbContext.SaveChangesAsync();
        return loginItem.LoginItemId;
    }

    public async Task<LoginItem> Update(LoginItem loginItem)
    {
        try
        {
            var existingItem = await GetExistingLoginItem(loginItem.LoginItemId);

            existingItem.Title = loginItem.Title;
            existingItem.Username = loginItem.Username;
            existingItem.Password = loginItem.Password;
            existingItem.EncryptedPassword = loginItem.EncryptedPassword;
            existingItem.WebsiteUrl = loginItem.WebsiteUrl;
            existingItem.Notes = loginItem.Notes;
            existingItem.LastUpdatedAt = DateTime.UtcNow;

            await dbContext.SaveChangesAsync();

            return existingItem;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating login item with ID {LoginItemId}", loginItem.LoginItemId);
            throw;
        }
    }

    public async Task<long> Delete(long loginItemId)
    {
        try
        {
            var existingItem = await GetExistingLoginItem(loginItemId);

            LoginItems.Remove(existingItem);
            return await dbContext.SaveChangesAsync(); // Return the number of rows affected (1 if successful).
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error deleting login item with ID {LoginItemId}", loginItemId);
            throw;
        }
    }

    private async Task<LoginItem> GetExistingLoginItem(long loginItemId)
    {
        var existingItem = await LoginItems.FindAsync(loginItemId);

        if (existingItem != null) return existingItem;

        logger.LogError("Could not find login item with id {ItemId}", loginItemId);
        throw new LoginItemNotFoundException($"Login Item with ID {loginItemId} was not found");
    }
}