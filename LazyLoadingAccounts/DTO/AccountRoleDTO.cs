﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LazyLoadingAccounts.DTO
{
    public class AccountRoleDTO: ITotalRecordsProvider
	{
		public string AccountId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Mobile { get; set; }
		public string Email { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
		public DateTime? StartDate { get; set; }
		public string AccountRoles { get; set; }
		public int RowNo { get; set; }
		public int TotalRecords { get; set; }
	}
}
