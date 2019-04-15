using Conferendum.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;

namespace Conferendum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InsertData();
            PrintData();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        private static void InsertData()
        {
            using (var context = new ConferenceContext())
            {
                context.Database.EnsureCreated();

                var section1 = new SectionEntry
                {
                    Section = "GIS",
                    City = "Tomsk",
                    Name = "Geoinformation Systems",
                    Location = "Lenina 2, 404"
                };

                var section2 = new SectionEntry
                {
                    Section = "CS",
                    City = "Tomsk",
                    Name = "Computer Science",
                    Location = "Lenina 30, 206"
                };

                if (!context.SectionEntry.Any(s => s.Section == section1.Section))
                {
                    context.SectionEntry.Add(section1);
                }
                if (!context.SectionEntry.Any(s => s.Section == section2.Section))
                {
                    context.SectionEntry.Add(section2);
                }

                context.SaveChanges();
            }
        }

        private static void PrintData()
        {
            using (var context = new ConferenceContext())
            {
                var entries = context.SectionEntry;
                foreach (var entry in entries)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"Section: {entry.Section}");
                    data.AppendLine($"City: {entry.City}");
                    data.AppendLine($"Location: {entry.Location}");
                    data.AppendLine($"Name: {entry.Name}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
    }
}
