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
            get { return _authorityHost ?? KnownAuthorityHosts.GetDefault(); }
            set { _authorityHost = value; }
        }
    }
}
