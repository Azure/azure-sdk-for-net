using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.DAG
{
    public interface ITaskItem<TaskResultT>
    {
        TaskResultT Result { get; }

        Task Execute();
    }
}
