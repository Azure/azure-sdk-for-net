// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;

namespace Azure.Identity
{
    public class IdentityClientOptions : ClientOptions
    {
        private readonly static Uri DefaultAuthorityHost = new Uri("https://login.microsoftonline.com/");
        private readonly static TimeSpan DefaultRefreshBuffer = TimeSpan.FromMinutes(2);

        public Uri AuthorityHost { get; set; }

        public IdentityClientOptions()
        {
            AuthorityHost = DefaultAuthorityHost;
        }
    }
}
