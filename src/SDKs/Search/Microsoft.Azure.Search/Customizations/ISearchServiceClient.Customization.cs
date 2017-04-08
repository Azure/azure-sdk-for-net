// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;

    public partial interface ISearchServiceClient
    {
        /// <summary>
        /// Gets the credentials used to authenticate to an Azure Search service.
        /// </summary>
        SearchCredentials SearchCredentials { get; }
    }
}
