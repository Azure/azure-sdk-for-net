// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Extensions.Azure
{
    public interface IAzureClientFactory<TClient>
    {
        TClient CreateClient(string name);
    }
}