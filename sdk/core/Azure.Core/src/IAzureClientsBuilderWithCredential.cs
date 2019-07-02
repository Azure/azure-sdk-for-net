// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    public interface IAzureClientsBuilderWithCredential
    {
        void RegisterClient<TClient, TOptions>(string name, Func<TOptions, TokenCredential, TClient> clientFactory, Action<TOptions> configureOptions, TokenCredential providedCredential) where TOptions : ClientOptions;
    }
}
