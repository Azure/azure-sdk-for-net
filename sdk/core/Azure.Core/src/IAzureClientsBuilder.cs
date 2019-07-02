// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    public interface IAzureClientsBuilder
    {
        void RegisterClient<TClient, TOptions>(string name, Func<TOptions, TClient> clientFactory, Action<TOptions> configureOptions) where TOptions : ClientOptions;
    }
}
