using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberFlow.Domain.Account;

public interface ISeedRoleInitial
{
    void SeedUsers();
    void SeedRoles();
}
