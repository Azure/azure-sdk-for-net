// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Compute;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class ComputePrivateLinkResourceData
    {
        // Customization: restored as IReadOnlyList<string> to preserve the previously-shipped API surface.
        // The new spec emits this as a writable IList, which would be a binary-breaking change for
        // existing consumers.
        /// <summary> The private link resource required zone names. </summary>
        public IReadOnlyList<string> RequiredZoneNames
        {
            get
            {
                return Properties is null ? new ChangeTrackingList<string>() : (IReadOnlyList<string>)Properties.RequiredZoneNames;
            }
        }
    }
}
