// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.DataMigration
{
    // Backward-compat justification: the GA project resource used DataMigrationServiceTask-prefixed method names.
    public partial class DataMigrationProjectResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DataMigrationServiceTaskCollection GetDataMigrationServiceTasks() => GetTasks();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<DataMigrationServiceTaskResource>> GetDataMigrationServiceTaskAsync(string taskName, string expand = default, CancellationToken cancellationToken = default)
            => GetTaskAsync(taskName, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<DataMigrationServiceTaskResource> GetDataMigrationServiceTask(string taskName, string expand = default, CancellationToken cancellationToken = default)
            => GetTask(taskName, expand, cancellationToken);
    }
}
