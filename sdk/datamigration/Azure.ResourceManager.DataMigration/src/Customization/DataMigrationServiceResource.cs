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
    // Backward-compat justification: the GA service resource used ServiceServiceTask-prefixed method names.
    public partial class DataMigrationServiceResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ServiceServiceTaskCollection GetServiceServiceTasks() => GetDataMigrationServiceTasks();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<ServiceServiceTaskResource>> GetServiceServiceTaskAsync(string taskName, string expand = default, CancellationToken cancellationToken = default)
            => GetDataMigrationServiceTaskAsync(taskName, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ServiceServiceTaskResource> GetServiceServiceTask(string taskName, string expand = default, CancellationToken cancellationToken = default)
            => GetDataMigrationServiceTask(taskName, expand, cancellationToken);
    }
}
