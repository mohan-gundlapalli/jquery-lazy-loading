-- =======================================================
-- Create Stored Procedure Template for Azure SQL Database
-- =======================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Mohan Gundlapalli
-- Create Date: Nov 16, 2020
-- Description: Fetches the records needed for lazy loading
-- =============================================
alter PROCEDURE proc_GetAccountByPage
(
    -- Add the parameters for the stored procedure here
    @PageNo int = 1,
    @PageSize int = 10
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

	;with AccountRecord as
	(
		select acc.AccountId,
		isnull(FirstName, '-') as FirstName
		,isnull(LastName, '-') as LastName
		,isnull(Mobile, '-') as Mobile
		,isnull(Email, '-') as Email
		,isnull(Address1, '-') Address1
		,isnull(Address2, '-') Address2
		,isnull(City, '-') as City
		,isnull(PostalCode, '-') as PostalCode
		,isnull(Country, '-') as Country
		,StartDate -- TODO: format the date to the format Jul 1/2020
		,
		isnull(stuff((
				select ', ' + isnull(r.Name, '-')
				from AccountRole ar
				left join Role r on ar.RoleId = r.RoleId
				where ar.AccountId = acc.AccountId
				order by r.Name
				for xml path('')
			),1,1,''), '-') as AccountRoles,
		ROW_NUMBER() over (order by acc.FirstName, acc.LastName) as RowNo,
		COUNT(*) over (order by AccountId) as TotalRecords
		from Account acc
		where acc.StatusKey = 'Active'
	)

	select * from AccountRecord
	where RowNo between (@PageNo - 1) * @PageSize and @PageNo * @PageSize
    
END
GO
