// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // The generated property is IList<T> because the value now comes from nested commit-batch details.
    // Expose the shipped IReadOnlyList<T> signature for API compatibility.
    public partial class CommitBatchStatusResponseProperties
    {
        /// <summary> List of devices for which the commit operation failed. </summary>
        public IReadOnlyList<string> CommitBatchDetailsFailedDevices
            => (IReadOnlyList<string>)CommitBatchDetails?.FailedDevices;
    }
}
