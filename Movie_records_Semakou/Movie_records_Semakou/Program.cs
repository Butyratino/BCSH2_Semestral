namespace Movie_records_Semakou
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
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
                    
                    // Přidání filmu
                    var novyFilm = new Film { Nazev = "Matrix", ReziserID = 1 /* ID režiséra */, Zanry = new List<Zanr> { new Zanr { Nazev = "Akční" } } };
                    context.Filmy.Add(novyFilm);
                    context.SaveChanges();

                    // Získání filmů podle žánru
                    var akcniFilmy = context.Filmy.Where(f => f.Zanry.Any(z => z.Nazev == "Akční")).ToList();

                    // Prohlížení a označování filmů uživatelem
                    var uzivatel = new Uzivatel { Jmeno = "John" };
                    uzivatel.OznacitJakoVidene(novyFilm);
                    uzivatel.OznacitJakoOblibene(novyFilm);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Chyba: {ex.Message}");
                }
                
            }
        }
    }
}