using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Movie_records_Semakou
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            using (var context = new FilmDbContext())
            {
                try
                {
                    // Clear existing entries from the tables
                    context.Filmy.RemoveRange(context.Filmy);
                    context.Reziseri.RemoveRange(context.Reziseri);
                    context.Zanry.RemoveRange(context.Zanry);
                    context.Uzivatele.RemoveRange(context.Uzivatele);
                    context.SaveChanges();

                    // Přidání režiséra a žánru před přidáním filmu
                    var novyReziser = new Reziser { Jmeno = "Reziser Jmeno" };
                    context.Reziseri.Add(novyReziser);
                    var novyZanr = new Zanr { Nazev = "Akční" };
                    context.Zanry.Add(novyZanr);
                    context.SaveChanges(); // Save changes to the referenced tables

                    // Přidání filmu
                    var novyFilm = new Film
                    {
                        Nazev = "Matrix",
                        ReziserID = novyReziser.ID, // Use the ID from the newly added režiser
                        Zanry = new List<Zanr> { novyZanr } // Use the newly added žánr
                    };


                    // Show a message box with the number of entities being tracked before saving changes
                    MessageBox.Show("Number of entities before SaveChanges: " + context.ChangeTracker.Entries().Count());

                    context.Filmy.Add(novyFilm);

                    var updatedEntitiesCount = context.SaveChanges();

                    // Show a message box with the number of entities after saving changes
                    MessageBox.Show($"Number of entities after SaveChanges: " + context.ChangeTracker.Entries().Count());

                    // Check if any entities were updated
                    if (updatedEntitiesCount > 0)
                    {
                        MessageBox.Show("Database updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("No changes made to the database.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");

                    // Check and display inner exceptions
                    Exception innerException = ex.InnerException;
                    int innerExceptionCount = 1;

                    while (innerException != null)
                    {
                        MessageBox.Show($"Inner Exception {innerExceptionCount}: {innerException.Message}");
                        innerException = innerException.InnerException;
                        innerExceptionCount++;
                    }
                }

            }
        }
    }
}
