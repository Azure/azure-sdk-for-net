// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    public partial class ManagedInstanceEditionCapability
    {
        /// <summary> Whether or not zone redundancy is supported for the edition. </summary>
        [WirePath("zoneRedundant")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsZoneRedundant { get; }
    }
}
