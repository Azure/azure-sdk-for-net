// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class FileServiceAccountUsageElements
    {
        /// <summary> Backward-compatible alias for ProvisionedIOPS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? ProvisionedIops => ProvisionedIOPS;
    }
}
