//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

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
        /// This is the Id of the key backing the certificate.
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

        public static readonly string[] AllTypes = { Pfx };
    }

    /// <summary>
    /// Well known issuers
    /// </summary>
    public static class WellKnownIssuers
    {
        public const string Self = "Self";

        public const string SslAdmin = "SslAdmin";

        public const string Unknown = "Unknown";

        public static readonly string[] AllIssuers = { Self, SslAdmin, Unknown };
    }
}
