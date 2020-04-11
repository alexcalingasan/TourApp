using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataContext: DbContext, IDataContext
    {
        public DataContext(DbContextOptions options): base(options)
        {            
        }
        public DbSet<Travel> Travels { get; set; }
    }
}