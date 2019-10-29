// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    public partial class CertificateReference
    {
        /// <summary>
        /// Instantiates an instance of CertificateReference with default property values.  
        /// Values for the Thumbprint and ThumbprintAlgorithm properties are taken from the provided base certificate.
        /// </summary>
        /// <param name="baseCertificate">Provides initial values for the CertificateReference properties Thumbprint and ThumbprintAlgorithm.</param>
        public CertificateReference(Certificate baseCertificate) : this()
        {
            this.Thumbprint = baseCertificate.Thumbprint;
            this.ThumbprintAlgorithm = baseCertificate.ThumbprintAlgorithm;
        }
    }
}
