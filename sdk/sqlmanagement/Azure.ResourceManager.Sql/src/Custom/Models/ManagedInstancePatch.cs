// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Sql.Models
{
    public partial class ManagedInstancePatch
    {
        /// <summary> The resource id of another managed instance whose DNS zone this managed instance will share after creation. </summary>
        public string DnsZonePartner { get; set; }
    }
}
