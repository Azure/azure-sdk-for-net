// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A class representing a collection of <see cref="BlobContainerResource"/> and their operations.
    /// Each <see cref="BlobContainerResource"/> in the collection will belong to the same instance of <see cref="BlobServiceResource"/>.
    /// To get a <see cref="BlobContainerCollection"/> instance call the GetBlobContainers method from an instance of <see cref="BlobServiceResource"/>.
    /// </summary>
    public partial class BlobContainerCollection : ArmCollection, IEnumerable<BlobContainerResource>, IAsyncEnumerable<BlobContainerResource>
    {
        /// <summary>
        /// Lists all containers and does not support a prefix like data plane. Also SRP today does not return continuation token.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BlobContainerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only container names starting with the filter will be listed. </param>
        /// <param name="include"> Optional, used to include the properties for soft deleted blob containers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BlobContainerResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<BlobContainerResource> GetAllAsync(string maxpagesize, string filter, BlobContainerState? include, CancellationToken cancellationToken)
            => GetAllAsync(string.IsNullOrEmpty(maxpagesize) ? null : int.Parse(maxpagesize), filter, include, cancellationToken);

        /// <summary>
        /// Lists all containers and does not support a prefix like data plane. Also SRP today does not return continuation token.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BlobContainerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only container names starting with the filter will be listed. </param>
        /// <param name="include"> Optional, used to include the properties for soft deleted blob containers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BlobContainerResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<BlobContainerResource> GetAll(string maxpagesize, string filter, BlobContainerState? include, CancellationToken cancellationToken)
            => GetAll(string.IsNullOrEmpty(maxpagesize) ? null : int.Parse(maxpagesize), filter, include, cancellationToken);
    }
}
