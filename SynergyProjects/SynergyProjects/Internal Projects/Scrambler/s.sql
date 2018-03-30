UPDATE [Person].[Address] SET AddressLine2 = 'X'  WHERE AddressLine2= ' '
select * from Person.Address where AddressLine1= 'XXXXXe de Varenne '
select AddressLine1 from Person.Address order by  AddressLine1 ASC
UPDATE [Person].[Address] SET AddressLine1 = 'XXXXXe de Maubeuge '  WHERE AddressLine1= '1, rue de Maubeuge '