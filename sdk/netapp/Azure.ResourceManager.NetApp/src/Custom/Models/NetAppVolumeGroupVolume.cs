// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeGroupVolume
    {
        /// <summary> The resource type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceType? ResourceType => string.IsNullOrEmpty(Type) ? (ResourceType?)null : new ResourceType(Type);

        /// <summary> Resource identifier used to identify the Snapshot. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SnapshotId
        {
            get => SnapshotResourceId?.ToString();
            set => SnapshotResourceId = value is string s ? new ResourceIdentifier(s) : null;
        }

        /// <summary> Resource identifier used to identify the Backup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BackupId
        {
            get => BackupResourceId?.ToString();
            set => BackupResourceId = value is string s ? new ResourceIdentifier(s) : null;
        }

        /// <summary> Pool Resource Id used in case of creating a volume through volume group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier CapacityPoolResourceId
        {
            get => CapacityPoolResourceIdString is string s ? new ResourceIdentifier(s) : null;
            set => CapacityPoolResourceIdString = value?.ToString();
        }

        /// <summary> Data store resource unique identifier. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<ResourceIdentifier> DataStoreResourceId
        {
            get
            {
                var strs = DataStoreResourceIdStrings;
                if (strs is null) return null;
                var result = new System.Collections.Generic.List<ResourceIdentifier>();
                foreach (var s in strs)
                {
                    result.Add(new ResourceIdentifier(s));
                }
                return result;
            }
        }
    }
}
