using ContactMate.Bll.Dtos;

namespace ContactMate.Bll.Services;

public interface IUserRoleService
{
    Task<ICollection<UserRoleDto>> GetAllRolesAsync();
    Task<ICollection<UserGetDto>> GetAllUsersByRoleNameAsync(string roleName);
}