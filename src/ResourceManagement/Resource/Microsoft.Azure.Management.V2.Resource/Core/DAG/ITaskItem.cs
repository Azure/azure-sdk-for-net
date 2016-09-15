using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.DAG
{
    public interface ITaskItem<TaskResultT>
    {
        TaskResultT Result { get; }

        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
