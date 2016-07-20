using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.DAG
{
    public abstract class TaskGroupBase<TaskResultT> : ITaskGroup<TaskResultT, ITaskItem<TaskResultT>>
    {
        public TaskGroupBase(string rootTaskItemId, ITaskItem<TaskResultT> rootTaskItem)
        {
            DAG = new DAGraph<ITaskItem<TaskResultT>, DAGNode<ITaskItem<TaskResultT>>>(CreateRootDAGNode(rootTaskItemId, rootTaskItem));
        }

        private DAGNode<ITaskItem<TaskResultT>> CreateRootDAGNode(string rootTaskItemId, ITaskItem<TaskResultT> rootTaskItem)
        {
            return new DAGNode<ITaskItem<TaskResultT>>(rootTaskItemId, rootTaskItem);
        }

        public DAGraph<ITaskItem<TaskResultT>, DAGNode<ITaskItem<TaskResultT>>> DAG
        {
            get;
            private set;
        }

        public void Merge(ITaskGroup<TaskResultT, ITaskItem<TaskResultT>> parentTaskGroup)
        {
            DAG.Merge(parentTaskGroup.DAG);
        }

        public bool IsPreparer
        {
            get
            {
                return DAG.IsPreparer;
            }
        }

        public void Prepare()
        {
            if (IsPreparer)
            {
                DAG.Prepare();
            }
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken, bool multiThreaded)
        {
            if (multiThreaded)
            {
                List<Task> tasks = new List<Task>();
                var nextNode = DAG.GetNext();
                while (nextNode != null)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                    Task task = ExecuteNodeTaskAsync(nextNode, cancellationToken, true);
                    tasks.Add(task);
                }

                if (!tasks.Any())
                {
                    await Task.Yield();
                    return;
                }

                await Task.WhenAll(tasks.ToArray());
                return;
            }
            else
            {
                var nextNode = DAG.GetNext();
                if (nextNode == null)
                {
                    await Task.Yield();
                    return;
                }
                await ExecuteNodeTaskAsync(nextNode, cancellationToken, false);
            }
        }

        private async Task ExecuteNodeTaskAsync(DAGNode<ITaskItem<TaskResultT>> node, CancellationToken cancellationToken, bool multiThreaded)
        {
            await node.Data.ExecuteAsync(cancellationToken);
            DAG.ReportCompleted(node);
            await ExecuteAsync(cancellationToken, multiThreaded);
        }

        public TaskResultT TaskResult(string taskId)
        {
            return DAG.GetNodeData(taskId).Result;
        }
    }
}
