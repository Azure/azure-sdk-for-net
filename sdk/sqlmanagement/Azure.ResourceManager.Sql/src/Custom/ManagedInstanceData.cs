// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Sql
{
    public partial class ManagedInstanceData
    {
        /// <summary> The resource id of another managed instance whose DNS zone this managed instance will share after creation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DnsZonePartner { get; set; }
    }
}
