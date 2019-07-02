// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Extensions
{
    internal class AzureClientOptions<TClient>
    {
        public Func<IServiceProvider, TokenCredential> CredentialFactory { get; set; }
    }
}