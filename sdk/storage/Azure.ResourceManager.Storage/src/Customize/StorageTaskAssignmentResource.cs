// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Structural fix: Adds string-id constructor bridge needed by generated code and restores
// old report-listing method names (GetStorageTaskAssignmentsInstancesReports -> GetAll).
// TODO: Generator bug - should generate appropriate constructor for resource types.

using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class StorageTaskAssignmentResource
    {
        // StorageTaskAssignmentData extends a local Resource model with string Id.
        // The generated constructor `(ArmClient, StorageTaskAssignmentData data) : this(client, data.Id)`
        // needs this string-accepting overload to bridge to the ResourceIdentifier constructor.
        internal StorageTaskAssignmentResource(ArmClient client, string id) : base(client, new ResourceIdentifier(id))
        {
        }
        // Backward-compatible overload: GetStorageTaskAssignmentInstancesReports renamed to GetAll.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<StorageTaskReportInstance> GetStorageTaskAssignmentInstancesReports(int? maxpagesize, string filter, CancellationToken cancellationToken)
            => GetAll(maxpagesize, filter, cancellationToken);

        // Backward-compatible overload: GetStorageTaskAssignmentInstancesReportsAsync renamed to GetAllAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<StorageTaskReportInstance> GetStorageTaskAssignmentInstancesReportsAsync(int? maxpagesize, string filter, CancellationToken cancellationToken)
            => GetAllAsync(maxpagesize, filter, cancellationToken);
    }
}
