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

        public async Task Execute()
        {
            var nextNode = DAG.GetNext();
            if (nextNode == null)
            {
                await Task.Yield();
                return;
            }

            if (DAG.IsRootNode(nextNode))
            {
                await ExecuteRootTask(nextNode.Data);
                return;
            }

            await nextNode.Data.Execute();
            DAG.ReportCompleted(nextNode);
            await Execute();
        }

        public TaskResultT TaskResult(string taskId)
        {
            return DAG.GetNodeData(taskId).Result;
        }

        public abstract Task ExecuteRootTask(ITaskItem<TaskResultT> taskItem);
    }
}
