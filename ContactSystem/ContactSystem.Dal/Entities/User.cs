using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSystem.Dal.Entities;

public class User
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Salt { get; set; }

    public int UserRoleId { get; set; }
    public UserRole UserRole { get; set; }

    public ICollection<RefreshToken> RefreshTokens { get; set; }
    public ICollection<Contact> Contacts { get; set; }

}
