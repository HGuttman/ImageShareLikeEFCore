using Microsoft.EntityFrameworkCore;
using System;

namespace ImageShareLikes.Data
{
    public class ImageDBContext: DbContext
    {
        private readonly string _connectionString;
        public ImageDBContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        public DbSet<Image> Images { get; set; }
    }
}
