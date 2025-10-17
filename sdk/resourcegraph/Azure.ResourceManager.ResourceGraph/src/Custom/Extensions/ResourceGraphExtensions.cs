// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.ResourceGraph.Mocking;
using Azure.ResourceManager.ResourceGraph.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ResourceGraph
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.ResourceGraph. </summary>
    public static partial class ResourceGraphExtensions
    {
        /// <summary>
        /// List all snapshots of a resource for a given time interval.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.ResourceGraph/resourcesHistory</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourcesHistory</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourceGraphTenantResource.GetResourceHistory(ResourcesHistoryContent,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="content"> Request specifying the query and its options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="content"/> is null. </exception>
        public static async Task<Response<BinaryData>> GetResourceHistoryAsync(this TenantResource tenantResource, ResourcesHistoryContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return await GetMockableResourceGraphTenantResource(tenantResource).GetResourceHistoryAsync(content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// List all snapshots of a resource for a given time interval.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.ResourceGraph/resourcesHistory</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourcesHistory</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourceGraphTenantResource.GetResourceHistory(ResourcesHistoryContent,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="content"> Request specifying the query and its options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="content"/> is null. </exception>
        public static Response<BinaryData> GetResourceHistory(this TenantResource tenantResource, ResourcesHistoryContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableResourceGraphTenantResource(tenantResource).GetResourceHistory(content, cancellationToken);
        }
    }
}
