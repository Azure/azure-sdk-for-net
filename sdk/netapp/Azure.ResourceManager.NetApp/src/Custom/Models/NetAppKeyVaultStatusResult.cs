// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: KeyVaultPrivateEndpoints was IReadOnlyList in old API, now IList.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppKeyVaultStatusResult
    {
        /// <summary> Properties of the key vault private endpoints. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<NetAppKeyVaultPrivateEndpoint> KeyVaultPrivateEndpoints
        {
            get
            {
                var list = Properties?.KeyVaultPrivateEndpoints;
                return list is null ? null : list.ToList().AsReadOnly();
            }
        }
    }
}
