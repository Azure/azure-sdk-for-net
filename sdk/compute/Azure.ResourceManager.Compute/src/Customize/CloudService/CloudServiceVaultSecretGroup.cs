// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceVaultSecretGroup
    {
        /// <summary> Initializes a new instance of CloudServiceVaultSecretGroup. </summary>
        public CloudServiceVaultSecretGroup()
        {
        }

        /// <summary> The source vault ID. </summary>
        public ResourceIdentifier SourceVaultId { get; set; }

        /// <summary> The vault certificates. </summary>
        public IList<CloudServiceVaultCertificate> VaultCertificates { get; set; }
    }
}
