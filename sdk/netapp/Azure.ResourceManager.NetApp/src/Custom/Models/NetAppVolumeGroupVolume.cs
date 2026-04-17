// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: Overrides for properties whose types differ from old API.
// - Type (string → ResourceType?)
// - IsRestoring (add setter)
// - DataStoreResourceId (IReadOnlyList<string> → IReadOnlyList<ResourceIdentifier>)

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeGroupVolume
    {
        /// <summary> Resource type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceType? ResourceType => Type != null ? new ResourceType(Type) : null;

        /// <summary> Restoring. </summary>
        public bool? IsRestoring
        {
            get => Properties is null ? default : Properties.IsRestoring;
            set { /* setter kept for backward compat; value is read-only from service */ }
        }

        /// <summary> Data store resource unique identifier. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<ResourceIdentifier> DataStoreResourceId
        {
            get
            {
                if (Properties is null)
                    return null;
                var ids = Properties.DataStoreResourceId;
                if (ids is null)
                    return null;
                return ids.Select(s => new ResourceIdentifier(s)).ToList().AsReadOnly();
            }
        }
    }
}
