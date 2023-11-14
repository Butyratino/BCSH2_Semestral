using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Movie_records_Semakou
{
    public class Film
    {
        public int ID { get; set; }
        public string Nazev { get; set; }
        public int ReziserID { get; set; }
        
        public Reziser Reziser { get; set; }
        public List<Zanr> Zanry { get; set; }
    }

    public class Reziser
    {
        public int ID { get; set; }
        public string Jmeno { get; set; }
        
        public List<Film> Filmy { get; set; }
    }

    public class Zanr
    {
        public int ID { get; set; }
        public string Nazev { get; set; }
        
        public List<Film> Filmy { get; set; }
    }

    public class Uzivatel
    {
        public int ID { get; set; }
        public string Jmeno { get; set; }
        
        public List<Film> SledovaneFilmy { get; set; }
        public List<Film> OblibeneFilmy { get; set; }

        public void OznacitJakoVidene(Film film)
        {
            SledovaneFilmy.Add(film);
        }

        public void OznacitJakoOblibene(Film film)
        {
            OblibeneFilmy.Add(film);
        }
    }

    public class FilmDbContext : DbContext
    {
        public DbSet<Film> Filmy { get; set; }
        public DbSet<Reziser> Reziseri { get; set; }
        public DbSet<Zanr> Zanry { get; set; }
        public DbSet<Uzivatel> Uzivatele { get; set; }

        public FilmDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=FilmyDatabase.db");
        }

        public List<Film> NajdiFilmyPodleZanru(string nazevZanru)
        {
            return Filmy.Where(f => f.Zanry.Any(z => z.Nazev == nazevZanru)).ToList();
        }

        public List<Film> NajdiFilmyPodleRezisera(string jmenoRezisera)
        {
            return Filmy.Where(f => f.Reziser.Jmeno == jmenoRezisera).ToList();
        }

        public List<Film> NajdiFilmyPodleNazvu(string nazevFilmu)
        {
            return Filmy.Where(f => f.Nazev.Contains(nazevFilmu)).ToList();
        }

        public void AktualizovatInformaceOFilmu(int filmId, string novyNazev, int novyReziserId)
        {
            var film = Filmy.Find(filmId);

            if (film != null)
            {
                film.Nazev = novyNazev;
                film.ReziserID = novyReziserId;

                SaveChanges();
            }
        }

        public void SmazatFilm(int filmId)
        {
            var film = Filmy.Find(filmId);

            if (film != null)
            {
                Filmy.Remove(film);
                SaveChanges();
            }
        }

        public void PridatNovyFilm(string nazev, int reziserId)
        {
            if (nazev.Length > 50)
            {
                // Pokud je název příliš dlouhý, nepridáváme film
                Console.WriteLine("Název filmu je příliš dlouhý.");
                return;
            }

            var novyFilm = new Film { Nazev = nazev, ReziserID = reziserId };
            Filmy.Add(novyFilm);
            SaveChanges();
        }

    }


}
