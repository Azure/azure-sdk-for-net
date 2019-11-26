// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure requests made to the OAUTH identity service
    /// </summary>
    public class TokenCredentialOptions : ClientOptions
    {
        private static readonly Uri s_defaultAuthorityHost = new Uri("https://login.microsoftonline.com/");

        /// <summary>
        /// The host of the Azure Active Directory authority.   The default is https://login.microsoftonline.com/
        /// </summary>
        public Uri AuthorityHost { get; set; }

        /// <summary>
        /// Creates an instance of <see cref="TokenCredentialOptions"/> with default settings.
        /// </summary>
        public TokenCredentialOptions()
        {
            AuthorityHost = s_defaultAuthorityHost;
        }
    }
}
