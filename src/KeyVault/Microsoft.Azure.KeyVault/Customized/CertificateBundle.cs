// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault.Models
{
    public partial class CertificateBundle
    {
        /// <summary>
        /// This is the Id of the secret backing the certificate.
        /// </summary>
        public SecretIdentifier SecretIdentifier
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Sid))
                    return new SecretIdentifier(Sid);
                else
                    return null;
            }
        }

        /// <summary>
        /// This is the Id of the key backing the certificate.
        /// </summary>
        public KeyIdentifier KeyIdentifier
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Kid))
                    return new KeyIdentifier(Kid);
                else
                    return null;
            }
        }

        /// <summary>
        /// This is the Id of the certificate.
        /// </summary>
        public CertificateIdentifier CertificateIdentifier
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

    /// <summary>
    /// Media types relevant to certificates.
    /// </summary>
    public static class CertificateContentType
    {
        public const string Pfx = "application/x-pkcs12";
        public const string Pem = "application/x-pem-file";

        public static readonly string[] AllTypes = { Pfx, Pem };
    }
}
