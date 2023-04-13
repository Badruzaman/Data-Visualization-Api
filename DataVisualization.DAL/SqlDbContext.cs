using DataVisualization.Domain.DTOs;
using DataVisualization.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualization.DAL
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }
        public DbSet<SecondaryOrderCollections> SecondaryOrderCollections { get; set; }
    }
}
