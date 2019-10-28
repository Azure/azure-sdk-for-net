// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Extensions
{
#pragma warning disable CA1040 // Avoid empty interfaces
    /// <summary>
    /// Marks the type exposing client registration options for clients registered with <see cref="IAzureClientFactoryBuilder"/>.
    /// </summary>
    /// <typeparam name="TClient">The type of the client.</typeparam>
    /// <typeparam name="TOptions">The options type used by the client.</typeparam>
    public interface IAzureClientBuilder<TClient, TOptions> where TOptions : class
#pragma warning restore CA1040 // Avoid empty interfaces
    {
    }
}
