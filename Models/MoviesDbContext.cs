using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameronKeetch_Assignment3.Models
{
    public class MoviesDbContext : DbContext
    {
        //constructor
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {

        }

        //create a set of the SignUp information so it can be displayed
        public DbSet<MovieResponse> Movies { get; set; }
    }
}
