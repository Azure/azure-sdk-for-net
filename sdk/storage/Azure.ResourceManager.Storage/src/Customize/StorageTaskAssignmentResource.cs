// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class StorageTaskAssignmentResource
    {
        // Constructor overload to fix generator bug: StorageTaskAssignmentData extends
        // a local Resource type with string Id, but the base constructor expects ResourceIdentifier.
        internal StorageTaskAssignmentResource(ArmClient client, string id) : this(client, new ResourceIdentifier(id))
        {
        }

        /// <summary> GetStorageTaskAssignmentInstancesReports renamed to GetAll. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<StorageTaskReportInstance> GetStorageTaskAssignmentInstancesReports(int? maxpagesize, string filter, CancellationToken cancellationToken)
            => GetAll(maxpagesize, filter, cancellationToken);

        /// <summary> GetStorageTaskAssignmentInstancesReportsAsync renamed to GetAllAsync. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<StorageTaskReportInstance> GetStorageTaskAssignmentInstancesReportsAsync(int? maxpagesize, string filter, CancellationToken cancellationToken)
            => GetAllAsync(maxpagesize, filter, cancellationToken);
    }
}
