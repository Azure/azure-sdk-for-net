// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure requests made to Azure Identity Services
    /// </summary>
    public class IdentityClientOptions : ClientOptions
    {
        private static readonly Uri s_defaultAuthorityHost = new Uri("https://login.microsoftonline.com/");

        /// <summary>
        /// The host of the Azure Active Directory authority.   The default is https://login.microsoft.com
        /// </summary>
        public Uri AuthorityHost { get; set; }

        /// <summary>
        /// Creates an instance of IdentityClientOptions with default settings.
        /// </summary>
        public IdentityClientOptions()
        {
            AuthorityHost = s_defaultAuthorityHost;
        }
    }
}
