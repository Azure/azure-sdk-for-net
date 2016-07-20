using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    public interface IApplicable<IFluentResourceT> : IIndexable
    {
        Task<IFluentResourceT> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true);
    }
}
