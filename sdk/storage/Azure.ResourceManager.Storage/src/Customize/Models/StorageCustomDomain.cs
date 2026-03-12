// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageCustomDomain
    {
        /// <summary> Backward-compatible alias for UseSubDomainName. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("useSubDomainName")]
        public bool? IsUseSubDomainNameEnabled
        {
            get => UseSubDomainName;
            set => UseSubDomainName = value;
        }
    }
}
