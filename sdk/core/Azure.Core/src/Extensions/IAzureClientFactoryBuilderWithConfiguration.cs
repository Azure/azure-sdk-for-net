// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace Azure.Core.Extensions
{

    public interface IAzureClientFactoryBuilderWithConfiguration<in TConfiguration>: IAzureClientFactoryBuilder
    {
        IAzureClientBuilder<TClient, TOptions> RegisterClientFactory<TClient, TOptions>(TConfiguration configuration) where TOptions : ClientOptions;
    }
}
