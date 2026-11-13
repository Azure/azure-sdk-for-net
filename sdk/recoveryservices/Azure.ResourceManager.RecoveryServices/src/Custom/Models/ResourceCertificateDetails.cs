// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.RecoveryServices.Models
{
    // add the ctor back for backward compatibility.
    public abstract partial class ResourceCertificateDetails
    {
        /// <summary> Initializes a new instance of <see cref="ResourceCertificateDetails"/>. </summary>
        protected ResourceCertificateDetails()
        {
        }
        /// <summary> The base64 encoded certificate raw data string. </summary>
        public byte[] Certificate { get; }
    }
}
