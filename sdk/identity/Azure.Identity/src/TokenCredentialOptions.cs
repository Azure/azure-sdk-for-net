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
        /// The host of the Azure Active Directory authority. The default is https://login.microsoftonline.com/. For well known authority hosts for Azure cloud instances see <see cref="KnownAuthorityHosts"/>.
        /// </summary>
        public Uri AuthorityHost
        {
            get { return _authorityHost ?? (EnvironmentVariables.AuthorityHost != null ? new Uri(EnvironmentVariables.AuthorityHost) : KnownAuthorityHosts.AzureCloud); }
            set { _authorityHost = value; }
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> value representing the amount of time to subtract from the token expiry time, whereupon
        /// attempts will be made to refresh the token. By default this will occur two minutes prior to the expiry of the token.
        /// The default value is 2 seconds.
        /// </summary>
        public TimeSpan TokenRefreshOffset { get; set; }
    }
}
