// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Extensions
{
#pragma warning disable CA1040 // Avoid empty interfaces
    public interface IAzureClientBuilder<TClient, TOptions> where TOptions : class
#pragma warning restore CA1040 // Avoid empty interfaces
    {
    }
}
