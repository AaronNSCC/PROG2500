using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ChinookMusicApp.Data
{
    public partial class ChinookContext
    {
        public ChinookContext() {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = ConfigurationManager
                .ConnectionStrings["Chinook"].ConnectionString;
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
