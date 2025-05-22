using ContactMate.Bll.Dtos;

namespace ContactMate.Bll.Services;

public interface IUserService
{
    Task DeleteUserByIdAsync(long userId, string userRoleName);
    Task UpdateUserRoleAsync(long userId, string userRoleName);
}