// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Fluent.Resource.Core.DAG
{
    public interface ITaskItem<TaskResultT>
    {
        TaskResultT Result { get; }

        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
