// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.NeonPostgres.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NeonPostgres
{
    /// <summary>
    /// A Class representing a NeonOrganization along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="NeonOrganizationResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetNeonOrganizationResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetNeonOrganization method.
    /// </summary>
    public partial class NeonOrganizationResource : ArmResource
    {
        /// <summary>
        /// Update a OrganizationResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Neon.Postgres/organizations/{organizationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OrganizationResource_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NeonOrganizationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The resource properties to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<NeonOrganizationResource>> UpdateAsync(WaitUntil waitUntil, NeonOrganizationData data, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, new NeonOrganizationPatch(data), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Update a OrganizationResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Neon.Postgres/organizations/{organizationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OrganizationResource_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NeonOrganizationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The resource properties to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<NeonOrganizationResource> Update(WaitUntil waitUntil, NeonOrganizationData data, CancellationToken cancellationToken = default)
            => Update(waitUntil, new NeonOrganizationPatch(data), cancellationToken);
    }
}
