using ContactMate.Core.Errors;
using ContactMate.Repository.Services;

namespace ContactMate.Bll.Services;

public class UserService : IUserService
{
    private readonly IUserRepositroy UserRepositroy;
    private readonly IUserRoleRepository UserRoleRepository;

    public UserService(IUserRepositroy userRepositroy, IUserRoleRepository userRoleRepository)
    {
        UserRepositroy = userRepositroy;
        UserRoleRepository = userRoleRepository;
    }

    public async Task DeleteUserByIdAsync(long userId, string userRoleName)
    {
        //var admin = await UserRoleRepository.SelectUserRoleByRoleName("Admin");
        //var superAdmin = await UserRoleRepository.SelectUserRoleByRoleName("SuperAdmin");

        if (userRoleName == "SuperAdmin")
        {
            await UserRepositroy.DeleteUserById(userId);
        }
        else if (userRoleName == "Admin")
        {
            var user = await UserRepositroy.SelectUserByIdAsync(userId);

            if (user.UserRole.UserRoleName == "User" && user.UserId == userId)
            {
                await UserRepositroy.DeleteUserById(userId);
            }
            else
            {
                throw new NotAllowedException("Admin can not delete admin");
            }
        }
    }

    public async Task UpdateUserRoleAsync(long userId, string userRoleName)
    {
        await (userRoleName == "SuperAdmin"
            ? UserRepositroy.UpdateUserRoleAsync(userId, userRoleName)
            : throw new NotAllowedException("Updating is not allowed for Users or Admin"));
    }
}
