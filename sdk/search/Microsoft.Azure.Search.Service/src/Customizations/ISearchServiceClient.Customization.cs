// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;

    public partial interface ISearchServiceClient
    {
        /// <summary>
        /// Gets the credentials used to authenticate to an Azure Search service. This can be either a query API key or an admin API key.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys"/> for more information about API keys in Azure Search.
        /// </remarks>
        SearchCredentials SearchCredentials { get; }
    }
}
