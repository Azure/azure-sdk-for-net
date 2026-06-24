// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth
{
    public partial class ResourceHealthEventImpactedResourceData
    {
        /// <summary> Additional information. </summary>
        // This is required because the generated property is IList<T>, while GA exposed IReadOnlyList<T>,
        // and @@alternateType cannot change the collection interface type.
        public IReadOnlyList<ResourceHealthKeyValueItem> Info => Properties?.Info as IReadOnlyList<ResourceHealthKeyValueItem>;

        /// <summary> Resource name of the impacted resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ResourceName { get; }

        /// <summary> Resource group name of the impacted resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ResourceGroup { get; }

        /// <summary> Status of the impacted resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Status { get; }

        /// <summary> Start time of maintenance for the impacted resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MaintenanceStartTime { get; }

        /// <summary> End time of maintenance for the impacted resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MaintenanceEndTime { get; }
    }
}
