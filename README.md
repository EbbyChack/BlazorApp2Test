//INSTALL ENTITYFRAMEWORKCORE.SQLSERVER AND .TOOLS
//to scaffold
Scaffold-DbContext "Server=EBBY\SQLEXPRESS;Database=CD_STORE;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

 //add this in app settings
 "ConnectionStrings": {
  "DefaultConnection": "Server=EBBY\\SQLEXPRESS;Database=CD_STORE;Trusted_Connection=True;"
},

//add this in program.cs
 
    
//add this in every controller
 private readonly CdStoreContext _context; // Replace YourDbContext with the name of your DbContext

 public CdController(CdStoreContext context) // Replace YourDbContext with the name of your DbContext
 {
     _context = context;
 }
 

Scaffold-DbContext "Server=EBBY\SQLEXPRESS;Database=CD_STORE;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities
