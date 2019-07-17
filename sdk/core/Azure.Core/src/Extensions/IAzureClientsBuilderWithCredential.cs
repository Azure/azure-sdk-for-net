// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Core.Extensions
{
    public interface IAzureClientsBuilderWithCredential
    {
        IAzureClientBuilder<TClient, TOptions> RegisterClientFactory<TClient, TOptions>(Func<TOptions, TokenCredential, TClient> clientFactory) where TOptions : ClientOptions;
    }
}
