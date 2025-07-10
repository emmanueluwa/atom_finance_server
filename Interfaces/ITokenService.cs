using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using atom_finance_server.Models;

namespace atom_finance_server.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
