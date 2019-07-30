// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;

namespace Microsoft.Extensions.Azure.Internal
{
    internal class AzureClientCredentialOptions<TClient>
    {
        public Func<IServiceProvider, TokenCredential> CredentialFactory { get; set; }
    }
}