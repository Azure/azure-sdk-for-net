// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.DAG
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
