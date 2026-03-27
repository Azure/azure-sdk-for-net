// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // Backward compat: The old Swagger/AutoRest API exposed IPAddressPools as a top-level
    // property. The new TypeSpec-generated code nests or renames this property. This file
    // preserves the old property to avoid breaking existing consumers.
    public partial class BgpAdvertisement
    {
        /// <summary> The names of the IP address pools associated with this announcement. </summary>
        public IList<string> IPAddressPools { get; }
    }
}
