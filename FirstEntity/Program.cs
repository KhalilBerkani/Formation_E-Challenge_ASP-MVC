using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using FirstEntity.Data;
using FirstEntity.Repository;
using FirstEntity.Entity;
using FirstEntity.Entity.Views;

internal class Program
{
    static async Task Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();

        var context = host.Services.GetRequiredService<SchoolContext>();

        // 📌 Ajout d’un sujet
        var subjectRepository = host.Services.GetRequiredService<IRepository<Subject>>();
        var newSubject = new Subject
        {
            Name = "Math",
            Description = "Introduction"
        };
        await subjectRepository.AddAsync(newSubject);
        await subjectRepository.SaveChangesAsync();
        Console.WriteLine("✔️ Sujet ajouté !");

        // 📚 Liste des sujets
        var allSubjects = await subjectRepository.ListAllAsync();
        Console.WriteLine("\nListe des sujets :");
        foreach (var s in allSubjects)
        {
            Console.WriteLine($"- {s.Id}: {s.Name} ({s.Description})");
        }

        Console.WriteLine("\nEnseignants :");
        var teacherSubjects = await context.TeacherSubjects.ToListAsync();
        if (teacherSubjects.Any())
        {
            foreach (var t in teacherSubjects)
            {
                Console.WriteLine($"- {t.FullName} enseigne {t.SubjectName} ({t.Description})");
            }
        }
        else
        {
            Console.WriteLine("Aucun enseignant ");
        }

        Console.WriteLine("\n🎓 Rechercher un étudiant par numéro :");
        var studentInfos = await context.GetStudentByStudentNumberAsync(1);
        foreach (var s in studentInfos)
        {
            Console.WriteLine($"- {s.StudentNumber}: {s.FirstName} {s.LastName}");
        }
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<SchoolContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            });
}
