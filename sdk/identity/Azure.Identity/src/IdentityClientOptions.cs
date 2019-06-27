// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure requests made to Azure Identity Services
    /// </summary>
    public class IdentityClientOptions : ClientOptions
    {
        private readonly static Uri DefaultAuthorityHost = new Uri("https://login.microsoftonline.com/");
        private readonly static TimeSpan DefaultRefreshBuffer = TimeSpan.FromMinutes(2);

        /// <summary>
        /// The host of the Azure Active Directory authority.   The default is https://login.microsoft.com
        /// </summary>
        public Uri AuthorityHost { get; set; }

        /// <summary>
        /// Creates an instance of IdentityClientOptions with default settings.
        /// </summary>
        public IdentityClientOptions()
        {
            AuthorityHost = DefaultAuthorityHost;
        }
    }
}
