// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Text;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Information about the principal used to get the token.
    /// </summary>
    public class Principal
    {
        /// <summary>
        /// Will be false if token has not been acquired
        /// </summary>
        public bool IsAuthenticated;

        /// <summary>
        /// Either User or App
        /// </summary>
        public string Type;

        /// <summary>
        /// If Type is User, the user's UserPrincipalName
        /// </summary>
        public string UserPrincipalName;

        /// <summary>
        /// If Type is App, the App Id used
        /// </summary>
        public string AppId;

        /// <summary>
        /// Tenant the token was acquired from
        /// </summary>
        public string TenantId;

        /// <summary>
        /// If Type is App, and a certificate was used, the certificate's thumbprint
        /// </summary>
        public string CertificateThumbprint;

        /// <summary>
        /// Returns a representation of the principal with non-null fields
        /// </summary>
        /// <returns>The representation of this <see cref="Principal"/> that includes all non-null fields</returns>
        public override string ToString()
        {
            StringBuilder principal = new StringBuilder($"IsAuthenticated:{IsAuthenticated}");
            
            if (Type != null)
            {
                principal.Append($" Type:{Type}");
            }

            if (AppId != null)
            {
                principal.Append($" AppId:{AppId}");
            }

            if (TenantId != null)
            {
                principal.Append($" TenantId:{TenantId}");
            }

            if (UserPrincipalName != null)
            {
                principal.Append($" UserPrincipalName:{UserPrincipalName}");
            }

            if (CertificateThumbprint != null)
            {
                principal.Append($" CertificateThumbprint:{CertificateThumbprint}");
            }

            return principal.ToString();
        }
    }
}
