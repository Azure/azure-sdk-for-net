// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// A factory abstraction for a component that can create Azure client instances with custom configuration for a given logical name.
    /// </summary>
    /// <typeparam name="TClient">The type of the client.</typeparam>
    public interface IAzureClientFactory<TClient>
    {
        /// <summary>
        /// Creates and configures an <typeparamref name="TClient"/> instance using the configuration that corresponds to the logical name specified by <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The logical name of the client to create.</param>
        /// <returns>An instance of <typeparamref name="TClient"/>.</returns>
        TClient CreateClient(string name);
    }
}