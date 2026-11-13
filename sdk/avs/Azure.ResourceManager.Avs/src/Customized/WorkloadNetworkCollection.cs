// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Avs.Models;

namespace Azure.ResourceManager.Avs
{
    /// <summary>
    /// A class representing a collection of <see cref="WorkloadNetworkResource"/> and their operations.
    /// Each <see cref="WorkloadNetworkResource"/> in the collection will belong to the same instance of <see cref="AvsPrivateCloudResource"/>.
    /// To get a <see cref="WorkloadNetworkCollection"/> instance call the GetWorkloadNetworks method from an instance of <see cref="AvsPrivateCloudResource"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This class is obsolete and will be removed in a future release.", false)]
    public partial class WorkloadNetworkCollection : ArmCollection, IEnumerable<WorkloadNetworkResource>, IAsyncEnumerable<WorkloadNetworkResource>
    {
        /// <summary> Initializes a new instance of the <see cref="WorkloadNetworkCollection"/> class for mocking. </summary>
        protected WorkloadNetworkCollection()
        {
        }

        /// <summary>
        /// Get a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/{workloadNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workloadNetworkName"> Name for the workload network in the private cloud. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<Response<WorkloadNetworkResource>> GetAsync(WorkloadNetworkName workloadNetworkName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("The method is deprecated as of API version 2023-09-01 and will be removed in a future release.");
        }

        /// <summary>
        /// Get a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/{workloadNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workloadNetworkName"> Name for the workload network in the private cloud. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<WorkloadNetworkResource> Get(WorkloadNetworkName workloadNetworkName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("The method is deprecated as of API version 2023-09-01 and will be removed in a future release.");
        }

        /// <summary>
        /// List of workload networks in a private cloud.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_List</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="WorkloadNetworkResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<WorkloadNetworkResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("The method is deprecated as of API version 2023-09-01 and will be removed in a future release.");
        }

        /// <summary>
        /// List of workload networks in a private cloud.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_List</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="WorkloadNetworkResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<WorkloadNetworkResource> GetAll(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("The method is deprecated as of API version 2023-09-01 and will be removed in a future release.");
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/{workloadNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workloadNetworkName"> Name for the workload network in the private cloud. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<Response<bool>> ExistsAsync(WorkloadNetworkName workloadNetworkName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("The method is deprecated as of API version 2023-09-01 and will be removed in a future release.");
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/{workloadNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workloadNetworkName"> Name for the workload network in the private cloud. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(WorkloadNetworkName workloadNetworkName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("The method is deprecated as of API version 2023-09-01 and will be removed in a future release.");
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/{workloadNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workloadNetworkName"> Name for the workload network in the private cloud. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<NullableResponse<WorkloadNetworkResource>> GetIfExistsAsync(WorkloadNetworkName workloadNetworkName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("The method is deprecated as of API version 2023-09-01 and will be removed in a future release.");
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/{workloadNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workloadNetworkName"> Name for the workload network in the private cloud. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<WorkloadNetworkResource> GetIfExists(WorkloadNetworkName workloadNetworkName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("The method is deprecated as of API version 2023-09-01 and will be removed in a future release.");
        }

        IEnumerator<WorkloadNetworkResource> IEnumerable<WorkloadNetworkResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<WorkloadNetworkResource> IAsyncEnumerable<WorkloadNetworkResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
