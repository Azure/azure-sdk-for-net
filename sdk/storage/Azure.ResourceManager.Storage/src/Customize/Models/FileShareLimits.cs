// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden aliases for MaxProvisionedIops and MinProvisionedIops.
// Could use @@clientName in spec but would lose improved names.

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class FileShareLimits
    {
        /// <summary> Backward-compatible alias for MaxProvisionedIOPS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("maxProvisionedIOPS")]
        public int? MaxProvisionedIops => MaxProvisionedIOPS;

        /// <summary> Backward-compatible alias for MinProvisionedIOPS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("minProvisionedIOPS")]
        public int? MinProvisionedIops => MinProvisionedIOPS;
    }
}
