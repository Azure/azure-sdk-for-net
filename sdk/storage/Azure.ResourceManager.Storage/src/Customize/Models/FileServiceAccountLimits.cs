// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden MaxProvisionedIops alias for renamed MaxProvisionedIOPS.
// Could use @@clientName in spec but would lose the improved name.

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class FileServiceAccountLimits
    {
        /// <summary> Backward-compatible alias for MaxProvisionedIOPS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("maxProvisionedIOPS")]
        public int? MaxProvisionedIops => MaxProvisionedIOPS;
    }
}
