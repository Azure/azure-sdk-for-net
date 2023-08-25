// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Base object for representing capability. </summary>
    public partial class PostgreSqlBaseCapability
    {
        /// <summary> Readonly status of the capability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Status
        {
            get => CapabilityStatus?.ToString();
        }
    }
}
