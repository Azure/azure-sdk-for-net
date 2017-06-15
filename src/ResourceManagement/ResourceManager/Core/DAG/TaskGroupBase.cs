// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.DAG
{
    public abstract class TaskGroupBase<TaskResultT> : ITaskGroup<TaskResultT, ITaskItem<TaskResultT>>
    {
        private TaskCompletionSource<object> taskCompletionSource;
        private bool multiThreaded;

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

        /// <summary>
        /// Executes the group of tasks that creates a set of dependency resources and eventually
        /// the root resource.
        /// </summary>
        /// <param name="cancellationToken">Enable cancellation</param>
        /// <param name="multiThreaded"></param>
        /// <returns></returns>
        public Task ExecuteAsync(CancellationToken cancellationToken, bool multiThreaded)
        {
            taskCompletionSource = new TaskCompletionSource<object>();
            this.multiThreaded = multiThreaded; // Right now we run multithreaded TODO: enable non-multithreaded scenario
            ExecuteReadyTasksAsync(cancellationToken);
            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Executes all the tasks in the ready queue in parallel.
        /// </summary>
        /// <param name="cancellationToken">Enable cancellation</param>
        private void ExecuteReadyTasksAsync(CancellationToken cancellationToken)
        {
            var nextNode = DAG.GetNext();
            while (nextNode != null)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    taskCompletionSource.TrySetCanceled();
                    return;
                }
                else if (taskCompletionSource.Task.IsCanceled || taskCompletionSource.Task.IsFaulted)
                {
                    return;
                }
                else
                {
                    // Here we are not waiting or checking the result of 'task', any failler in this
                    // 'ExecuteNodeTaskAsync' will be signaled via this.taskCompletionSource.
                    Task task = ExecuteNodeTaskAsync(nextNode, cancellationToken);
                }
                nextNode = DAG.GetNext();
            }
        }

        /// <summary>
        /// Executes one task and await for it and as a part of continuation run the next
        /// set of tasks in the ready queue.
        /// </summary>
        /// <param name="node">The node containing task</param>
        /// <param name="cancellationToken">Enable cancellation</param>
        /// <returns></returns>
        private async Task ExecuteNodeTaskAsync(DAGNode<ITaskItem<TaskResultT>> node,
            CancellationToken cancellationToken)
        {
            try
            {
                TaskResultT cachedResult = node.Data.CreatedResource;
                if (cachedResult != null && !DAG.IsRootNode(node))
                {
                    DAG.ReportCompleted(node);
                }
                else
                {
                    await node.Data.ExecuteAsync(cancellationToken);
                    DAG.ReportCompleted(node);
                    if (DAG.IsRootNode(node))
                    {
                        taskCompletionSource.SetResult(null);
                        return;
                    }
                }
                ExecuteReadyTasksAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                taskCompletionSource.TrySetException(exception);
            }
        }

        public TaskResultT TaskResult(string taskId)
        {
            return DAG.GetNodeData(taskId).CreatedResource;
        }
    }
}