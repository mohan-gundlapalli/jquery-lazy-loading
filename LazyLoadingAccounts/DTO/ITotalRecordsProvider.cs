using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LazyLoadingAccounts.DTO
{
    public interface ITotalRecordsProvider
    {
        int TotalRecords { get; set; }
    }
    
}
