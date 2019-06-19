// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core
{
    public interface IAzureClientsBuilderWithConfiguration<in TConfiguration>: IAzureClientsBuilder
    {
        void RegisterClient<TClient, TOptions>(string name, TConfiguration configuration) where TOptions : class;
    }
}
