// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault.Models
{
    public partial class IssuerBundle
    {
        /// <summary>
        /// Identifier for the issuer object.
        /// </summary>
        public CertificateIssuerIdentifier IssuerIdentifier
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Id))
                    return new CertificateIssuerIdentifier(Id);
                else
                    return null;
            }
        }
    }
}
