using LazyLoadingAccounts.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LazyLoadingAccounts.Repositories
{
    public interface IAccountRepository
    {
        Task<IList<AccountRoleDTO>> GetAccounts(int pageNo, int pageSize);
    }
}