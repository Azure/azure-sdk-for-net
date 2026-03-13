// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden ProvisionedIops alias for renamed ProvisionedIOPS.
// Could use @@clientName in spec but would lose the improved name.

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class FileServiceAccountUsageElements
    {
        /// <summary> Backward-compatible alias for ProvisionedIOPS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("provisionedIOPS")]
        public int? ProvisionedIops => ProvisionedIOPS;
    }
}
