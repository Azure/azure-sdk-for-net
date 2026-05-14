// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.ResourceManager.ArtifactSigning.Models;

namespace Azure.ResourceManager.ArtifactSigning
{
    public partial class ArtifactSigningCertificateProfileData
    {
        /// <summary>
        /// Profile type of the certificate.
        /// </summary>
        // Backward-compatibility shim. Use CertificateProfileType instead.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Use CertificateProfileType instead.")]
        public CertificateProfileType ProfileType
        {
            get => CertificateProfileType.GetValueOrDefault();
            set => CertificateProfileType = value;
        }
    }
}
