using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Album_MVC_EF.Models
{
    public class Album
    {    
            public int AlbumId { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
    }

    public class MusicStoreDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
    }
}