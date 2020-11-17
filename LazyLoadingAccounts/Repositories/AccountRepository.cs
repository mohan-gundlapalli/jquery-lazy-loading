using LazyLoadingAccounts.DTO;
using LazyLoadingAccounts.Infrastructure;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace LazyLoadingAccounts.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public ConfigHelper _configHelper;

        public AccountRepository(IOptions<ConfigHelper> ch) => _configHelper = ch.Value;

        public async Task<IList<AccountRoleDTO>> GetAccounts(int pageNo, int pageSize)
        {
            using var conn = GetConnection();

            var items = await conn.QueryAsync<AccountRoleDTO>(
            sql: "dbo.proc_GetAccountByPage",
            param: new { PageNo = pageNo, PageSize = pageSize },
            commandType: CommandType.StoredProcedure,
            commandTimeout: 60);

            return items.ToList();
        }

        public SqlConnection GetConnection()
        {
            var conn = new SqlConnection(_configHelper.DefaultConnection);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
