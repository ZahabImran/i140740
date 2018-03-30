sp_configure 'show advanced options', 1
RECONFIGURE
GO
sp_configure 'clr enabled', 1
RECONFIGURE
GO
sp_configure 'show advanced options', 0
RECONFIGURE
GO
DROP ASSEMBLY [ IF EXISTS ] assembly_name [CLRFunctions]  
[ WITH NO DEPENDENTS ]  
[ ; ]  

select Name from  Sales.SalesTerritory
drop assembly CLRFunctions
go
Create Assembly CLRFunctions from 'C:\Users\zahab.imran\Desktop\CLRFunctions.dll' with Permission_set = SAFE
GO

  Create Function ActualScrambling(@StringToScramble nvarchar(max))
       
RETURNS [nvarchar](255) WITH EXECUTE AS CALLER
       
       AS
   External name [CLRFunctions].[CLRFunctions.SQLfunctions].[Scrambling]
	GO

	Create Function ActualMasking(@StringToScramble nvarchar(max),@total int)
       
RETURNS [nvarchar](255) WITH EXECUTE AS CALLER
       
       AS
              External name [CLRFunctions].[CLRFunctions.SQLfunctions].[Masking]
	GO


	UPDATE [Production].[ProductDescription] SET Description = dbo.ActualScrambling('XXXXXr os. Celyle             ')  WHERE Description= 'XXXXXr os. Celyle             '
	GO
		Select Description from  [Production].[ProductDescription] where Description = 'XXXXXr os. Celyle             '


	select * from sys.assembly_modules

UPDATE [Sales].[SalesTerritory] SET Name = dbo.ActualScrambling('t eCnlra    )'  WHERE Name= 't eCnlra    '

select Name from Person.ContactType

	UPDATE [Production].[ProductDescription] SET Description = dbo.ActualScrambling('XXXXXr os. Celyle             ')  WHERE Description= 'XXXXXr os. Celyle             '

	UPDATE [Person].[Address] SET AddressLine1= dbo.ActualMasking(  '1005 Valley Oak Plaza ',5) WHERE AddressLine1= '1005 Valley Oak Plaza '

	select AddressLine1 from [Person].[Address] 

	SELECT ROW_NUMBER() OVER(ORDER BY AddressLine1) AS [Rank],TopListId
FROM TopList where AddressLine1= '1008 Lydia Lane'

;WITH CTE AS
(
SELECT ROW_NUMBER() over (order by AddressLine1)as RowId,  AddressId
FROM Person.Address
)

select * from Person.Address

set AddressLine1 = dbo.ActualMasking(AddressLine1,5)

 update a
 set a.AddressLine1 = dbo.ActualMasking(a.AddressLine1, 5)
 from Person.Address a
 inner join CTE c on a.AddressId = c.AddressId
 where c.RowId > 0 and c.RowId < 10

FROM Person.Address
where AddressLine1= '1008 Lydia Lane'

Select Name from HumanResources.Shift