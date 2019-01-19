// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault.Models
{
    public partial class CertificateOperation
    {
        /// <summary>
        /// The certificate operation identifier
        /// </summary>
        public CertificateOperationIdentifier CertificateOperationIdentifier
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Id))
                    return new CertificateOperationIdentifier(Id);
                else
                    return null;
            }
        }
    }
}
