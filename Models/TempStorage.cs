using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameronKeetch_Assignment3.Models
{
    public class TempStorage
    {
        private static List<MovieResponse> movieList = new List<MovieResponse>();

        public static IEnumerable<MovieResponse> MovieList => movieList;

        public static void AddMovie(MovieResponse movie)
        {
            movieList.Add(movie);
        }
    }
}
