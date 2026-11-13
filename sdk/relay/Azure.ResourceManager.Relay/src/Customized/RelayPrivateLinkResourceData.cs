// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#nullable disable
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.Relay
{
    /// <summary> A resource that supports private link capabilities. </summary>
    // This customization is for API backward compatibility.
    // In the baseline API version, the types of RequiredMembers and RequiredZoneNames are IReadOnlyList<string>,
    // but in the current generated code they are IList<string> (on RelayPrivateLinkResourceProperties).
    // We wrap them here to preserve the original IReadOnlyList<string> return type.
    public partial class RelayPrivateLinkResourceData
    {
        /// <summary> The private link resource required member names. </summary>
        public IReadOnlyList<string> RequiredMembers
        {
            get
            {
                return Properties.RequiredMembers.ToList().AsReadOnly();
            }
        }

        /// <summary> The private link resource Private link DNS zone name. </summary>
        public IReadOnlyList<string> RequiredZoneNames
        {
            get
            {
                return Properties.RequiredZoneNames.ToList().AsReadOnly();
            }
        }
    }
}
