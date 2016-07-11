using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.DAG
{
    internal interface ITaskItem<TaskResultT>
    {
        TaskResultT Result { get; }

        Task Execute();
    }
}
