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

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A class representing a collection of <see cref="FileShareResource"/> and their operations.
    /// Each <see cref="FileShareResource"/> in the collection will belong to the same instance of <see cref="FileServiceResource"/>.
    /// To get a <see cref="FileShareCollection"/> instance call the GetFileShares method from an instance of <see cref="FileServiceResource"/>.
    /// </summary>
    public partial class FileShareCollection : ArmCollection, IEnumerable<FileShareResource>, IAsyncEnumerable<FileShareResource>
    {
        /// <summary>
        /// Lists all shares.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FileShares_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FileShareResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of shares that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only share names starting with the filter will be listed. </param>
        /// <param name="expand"> Optional, used to expand the properties within share's properties. Valid values are: deleted, snapshots. Should be passed as a string with delimiter ','. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FileShareResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FileShareResource> GetAllAsync(string maxpagesize, string filter, string expand, CancellationToken cancellationToken)
            => GetAllAsync(string.IsNullOrEmpty(maxpagesize) ? null : int.Parse(maxpagesize), filter, expand, cancellationToken);

        /// <summary>
        /// Lists all shares.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FileShares_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FileShareResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of shares that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only share names starting with the filter will be listed. </param>
        /// <param name="expand"> Optional, used to expand the properties within share's properties. Valid values are: deleted, snapshots. Should be passed as a string with delimiter ','. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FileShareResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FileShareResource> GetAll(string maxpagesize, string filter, string expand, CancellationToken cancellationToken)
            => GetAll(string.IsNullOrEmpty(maxpagesize) ? null : int.Parse(maxpagesize), filter, expand, cancellationToken);
    }
}
