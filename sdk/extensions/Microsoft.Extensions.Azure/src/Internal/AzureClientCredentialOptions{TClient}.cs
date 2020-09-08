// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Microsoft.Extensions.Azure
{
    internal class AzureClientCredentialOptions<TClient>
    {
        public Func<IServiceProvider, TokenCredential> CredentialFactory { get; set; }
    }
}