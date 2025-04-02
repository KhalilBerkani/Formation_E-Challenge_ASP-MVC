using Formation_E_Challenge_ASP_MVC.Entity;
using Microsoft.EntityFrameworkCore;

// Construction manuelle des options pour EF Core
var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SchoolDb;Trusted_Connection=True;");

using var context = new SchoolContext(optionsBuilder.Options);

// Juste pour tester : afficher le nombre de personnes
var total = context.People.Count();
Console.WriteLine($"Nombre de personnes dans la base : {total}");
