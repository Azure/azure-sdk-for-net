using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.DAG
{
    public interface ITaskGroup<TaskResultT, TaskItemT> where TaskItemT : ITaskItem<TaskResultT>
    {
        DAGraph<TaskItemT, DAGNode<TaskItemT>> DAG { get; }

        void Merge(ITaskGroup<TaskResultT, TaskItemT> parentTaskGroup);

        bool IsPreparer { get; }

        void Prepare();

        Task ExecuteAsync(CancellationToken cancellationToken, bool multiThreaded);

        TaskResultT TaskResult(string taskId);
    }
}
