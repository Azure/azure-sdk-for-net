// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Search.Fluent
{
    /// <summary>
    /// Describes an API key for a given Azure Search service that has permissions
    /// for query operations only.
    /// </summary>
    public interface IQueryKey  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the name of the query API key.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the key value.
        /// </summary>
        string Key { get; }
    }
}