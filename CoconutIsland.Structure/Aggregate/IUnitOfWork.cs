using System;
using System.Threading;
using System.Threading.Tasks;

namespace CoconutIsland.Structure.Aggregate
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CompleteAsync(CancellationToken cancellationToken = default);
    }
}