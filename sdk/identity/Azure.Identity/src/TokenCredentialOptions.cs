// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure requests made to the OAUTH identity service.
    /// </summary>
    public class TokenCredentialOptions : ClientOptions
    {
        private Uri _authorityHost;

        /// <summary>
        /// The host of the Azure Active Directory authority. The default is https://login.microsoftonline.com/. For well known authority hosts for Azure cloud instances see <see cref="AzureAuthorityHosts"/>.
        /// </summary>
        public Uri AuthorityHost
        {
            get { return _authorityHost ?? AzureAuthorityHosts.GetDefault(); }
            set { _authorityHost = Validations.ValidateAuthorityHost(value); }
        }

        /// <summary>
        /// If <c>true</c>, enables the credential to fetch tokens for any tenants the user or multi-tenant application registration is a member of.
        /// Otherwise the credential will only acquire tokens from the tenant configured when the credential was constructed.
        /// </summary>
        public bool AllowMultiTenantAuthentication { get; set; }

        /// <summary>
        /// Gets or sets value indicating if logging that contains PII content should be logged.
        /// </summary>
        public bool IsLoggingPIIEnabled { get; set; }
    }
}
