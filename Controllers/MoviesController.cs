using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAnalysis.Data;
using MoviesAnalysis.Models;
using MoviesAnalysis.Services;

namespace MoviesAnalysis.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly TmdbService _tmdb;

        public MoviesController(AppDbContext context, TmdbService tmdb)
        {
            _context = context;
            _tmdb = tmdb;
        }

        // GET: /Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: /Movies/GetFromTMDB
        public async Task<IActionResult> GetFromTMDB()
        {
            var results = await _tmdb.SearchMoviesAsync("Batman");
            foreach (var item in results)
            {
                if (!_context.Movies.Any(m => m.TmdbId == item.id))
                {
                    _context.Movies.Add(new Movie
                    {
                        TmdbId = item.id,
                        Title = item.title,
                        ReleaseDate = item.release_date,
                        Overview = item.overview,
                        PosterPath = item.poster_path
                    });
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: /Movies/DeleteAll
        public async Task<IActionResult> DeleteAll()
        {
            _context.Movies.RemoveRange(_context.Movies);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: /Movies/DeleteById?id=5
        public async Task<IActionResult> DeleteById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
