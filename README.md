--DDD App 

EF CORE 
	CODE FIRST 
		Add packages references
		 - ClubManagementApp => EF Core / Ef Core Tools
		 - Infrastructure => EF Core / EF Core SQLServer

		 Add-Migration <name> to script the initial schema
		 (Script-Migration) to generate <name> migration script

		 Update-Database -Verbose

	DB FIRST
		scaffold-dbcontext -provider Microsoft.EntityFrameworkCore.SqlServer -connection "<connectionString>"