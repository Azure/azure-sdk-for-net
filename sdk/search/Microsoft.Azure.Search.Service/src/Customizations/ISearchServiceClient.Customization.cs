// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;

    public partial interface ISearchServiceClient
    {
        /// <summary>
        /// Gets the credentials used to authenticate to a search service. This can be either a query API key or an admin API key.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys">Create and manage api-keys for an Azure Cognitive Search service</see> for more information about API keys in Azure Cognitive Search.
        /// </remarks>
        SearchCredentials SearchCredentials { get; }
    }
}
