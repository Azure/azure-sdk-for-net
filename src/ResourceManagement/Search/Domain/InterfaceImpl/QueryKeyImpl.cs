// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Search.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Search.Fluent.Models;

    internal partial class QueryKeyImpl 
    {
        /// <summary>
        /// Gets the name of the query API key.
        /// </summary>
        string Microsoft.Azure.Management.Search.Fluent.IQueryKey.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the key value.
        /// </summary>
        string Microsoft.Azure.Management.Search.Fluent.IQueryKey.Key
        {
            get
            {
                return this.Key();
            }
        }
    }
}