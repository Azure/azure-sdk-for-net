// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    public partial class MachineLearningDatastoreCollection
    {
        /// <summary>
        /// List datastores.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/datastores</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Datastores_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="count"> Maximum number of results to return. </param>
        /// <param name="isDefault"> Filter down to the workspace default datastore. </param>
        /// <param name="names"> Names of datastores to return. </param>
        /// <param name="searchText"> Text to search for in the datastore names. </param>
        /// <param name="orderBy"> Order by property (createdtime | modifiedtime | name). </param>
        /// <param name="orderByAsc"> Order by property in ascending order. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MachineLearningDatastoreResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MachineLearningDatastoreResource> GetAllAsync(string skip = null, int? count = null, bool? isDefault = null, IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = null, CancellationToken cancellationToken = default)
        {
            MachineLearningDatastoreCollectionGetAllOptions options = new MachineLearningDatastoreCollectionGetAllOptions();
            options.Skip = skip;
            options.Count = count;
            options.IsDefault = isDefault;
            options.SearchText= searchText;
            options.OrderBy= orderBy;
            options.OrderByAsc= orderByAsc;

            if (names is not null)
            {
                foreach (var item in names)
                {
                    options.Names.Add(item);
                }
            }

            return GetAllAsync(options, cancellationToken);
        }

        /// <summary>
        /// List datastores.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/datastores</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Datastores_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="count"> Maximum number of results to return. </param>
        /// <param name="isDefault"> Filter down to the workspace default datastore. </param>
        /// <param name="names"> Names of datastores to return. </param>
        /// <param name="searchText"> Text to search for in the datastore names. </param>
        /// <param name="orderBy"> Order by property (createdtime | modifiedtime | name). </param>
        /// <param name="orderByAsc"> Order by property in ascending order. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MachineLearningDatastoreResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MachineLearningDatastoreResource> GetAll(string skip = null, int? count = null, bool? isDefault = null, IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = null, CancellationToken cancellationToken = default)
        {
            MachineLearningDatastoreCollectionGetAllOptions options = new MachineLearningDatastoreCollectionGetAllOptions();
            options.Skip = skip;
            options.Count = count;
            options.IsDefault = isDefault;
            options.SearchText = searchText;
            options.OrderBy = orderBy;
            options.OrderByAsc = orderByAsc;

            if (names is not null)
            {
                foreach (var item in names)
                {
                    options.Names.Add(item);
                }
            }

            return GetAll(options, cancellationToken);
        }
    }
}
