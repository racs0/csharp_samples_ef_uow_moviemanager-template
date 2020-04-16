using MovieManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieManager.Core
{
    public class ImportController
    {
        const string Filename = "movies.csv";

        /// <summary>
        /// Liefert die Movies mit den dazugehörigen Kategorien
        /// </summary>
        public static IEnumerable<Movie> ReadFromCsv()
        {
            string filepath = Utils.MyFile.GetFullNameInApplicationTree(Filename);
            var lines = File.ReadAllLines(filepath);
            lines = lines.Skip(1).ToArray();
            Dictionary<string, Category> categories = new Dictionary<string, Category>();
            List<Movie> movies = new List<Movie>();

            foreach (var item in lines)
            {
                string[] items = item.Split(';');
                string title = items[0];
                int year = Convert.ToInt32(items[1]);
                string categoryname = items[2];
                int duration = Convert.ToInt32(items[3]);
                Movie movie;
                Category category;

                if (!categories.ContainsKey(categoryname))
                {
                    category = new Category(categoryname);
                    categories.Add(categoryname, category);
                    movie = new Movie(title,categories[categoryname],duration,year);
                    movies.Add(movie);
                }
                else if(categories.ContainsKey(categoryname))
                {
                    movie = new Movie(title, categories[categoryname], duration, year);
                    movies.Add(movie);
                }
            }

            return movies;
        }

    }
}
