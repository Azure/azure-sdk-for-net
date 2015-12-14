// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;

    public partial interface ISearchIndexClient
    {
        /// <summary>
        /// Gets the credentials used to authenticate to an Azure Search service.
        /// </summary>
        SearchCredentials SearchCredentials { get; }

        /// <summary>
        /// Indicates whether the index client should use HTTP GET for making Search and Suggest requests to the
        /// Azure Search REST API. The default is <c>false</c>, which indicates that HTTP POST will be used.
        /// </summary>
        bool UseHttpGetForQueries { get; set; }
    }
}
