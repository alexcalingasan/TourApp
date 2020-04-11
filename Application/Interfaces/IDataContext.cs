using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IDataContext
    {
        DbSet<Travel> Travels { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}