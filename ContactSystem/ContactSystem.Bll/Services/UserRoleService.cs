using ContactMate.Bll.Dtos;
using ContactMate.Dal.Entities;
using ContactMate.Repository.Services;

namespace ContactMate.Bll.Services;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository UserRoleRepository;

    public UserRoleService(IUserRoleRepository userRoleRepository)
    {
        UserRoleRepository = userRoleRepository;
    }

    public async Task<ICollection<UserRoleDto>> GetAllRolesAsync()
    {
        var userRoels = await UserRoleRepository.SelectAllRolesAsync();

        var userRoleDto = userRoels.Select(userRole => ConverUserRoleToUserRoleDto(userRole)).ToList();
        return userRoleDto;
    }

    public async Task<ICollection<UserGetDto>> GetAllUsersByRoleNameAsync(string roleName)    
    {
        var users = await UserRoleRepository.SelectAllUsersByRoleNameAsync(roleName);

        var userRolesDto = users.Select(user => ConvertUserToUserGetDto(user)).ToList();
        return userRolesDto;
    }

    private UserRoleDto ConverUserRoleToUserRoleDto(UserRole userRole)
    {
        return new UserRoleDto()
        {
            UserRoleId = userRole.UserRoleId,
            UserRoleName = userRole.UserRoleName,
            Description = userRole.Description,
        };
    }

    private UserGetDto ConvertUserToUserGetDto(User user)
    {
        return new UserGetDto()
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Role = user.UserRole.UserRoleName,
        };
    }
}
