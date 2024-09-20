using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Business.Interfaces
{
    public interface ITokenValidationService
    {
        bool ValidateToken(string encryptToken);
        Task<bool> IsAuthorize(string email, string url);
    }
}
