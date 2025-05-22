using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSystem.Dal.Entities;

public class UserRole
{
    public int UserRoleId { get; set; }
    public string Role { get; set; }
    public string RoleDefinition { get; set; }

    public List<User> Users { get; set; }
}
