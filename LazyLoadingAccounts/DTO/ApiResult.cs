using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LazyLoadingAccounts.DTO
{
    public class ApiResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public int TotalRecords => GetTotalRecords();

        private int GetTotalRecords()
        {
            if (Data == null)
            {
                return 0;
            }

            if (Data is IList listItems && Data.GetType().IsGenericType)
            {
                if (listItems.Count == 0)
                {
                    return 0;
                }

                var first = listItems[0];
                if (first is ITotalRecordsProvider totalRecordsProvider)
                {
                    return totalRecordsProvider.TotalRecords;
                }
            }

            return 0;
        }
    }
}
