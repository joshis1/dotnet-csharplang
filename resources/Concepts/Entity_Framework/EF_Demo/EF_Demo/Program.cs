﻿using System;
using System.Linq;
using System.Data.Entity;

namespace EF_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MusicStoreDbContext())
            {
                var albums = context.Albums;
                var count = albums.CountAsync();
                Console.WriteLine(count);
                context.Albums.Add(new Album() { Price = 9.9m, Title = "Wish" });
                context.SaveChanges();
                count = context.Albums.CountAsync();
                Console.WriteLine(count);
                //LinQ adds the Where capability
                var albumlist = context.Albums.Where(o => o.Title.Contains("Wish")).ToList();
                Console.WriteLine(albumlist.Count());
                Console.ReadLine();

            }
        }

        public class MusicStoreDbContext: DbContext
        {
            public DbSet<Album> Albums { get; set;}
        }

        public class Album
        {
            public int AlbumId { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
        }

    }
}
