// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core
{
    public interface IAzureClientFactory<TClient>
    {
        TClient CreateClient(string name);
    }
}