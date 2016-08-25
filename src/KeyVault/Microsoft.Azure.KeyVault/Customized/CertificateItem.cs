// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault.Models
{
    /// <summary>
    /// The certificate item containing certificate metadata
    /// </summary>
    public partial class CertificateItem
    {
        /// <summary>
        /// The certificate identifier
        /// </summary>
        public CertificateIdentifier Identifier
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Id))
                    return new CertificateIdentifier(Id);
                else
                    return null;
            }
        }
    }
}
