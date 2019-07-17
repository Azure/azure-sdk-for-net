// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace Azure.Core.Extensions
{

    public interface IAzureClientsBuilderWithConfiguration<in TConfiguration>: IAzureClientsBuilder
    {
        IAzureClientBuilder<TClient, TOptions> RegisterClientFactory<TClient, TOptions>(TConfiguration configuration) where TOptions : ClientOptions;
    }
}
