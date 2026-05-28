// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A class representing a collection of <see cref="HostingEnvironmentPrivateEndpointConnectionResource"/> and their operations.
    /// Each <see cref="HostingEnvironmentPrivateEndpointConnectionResource"/> in the collection will belong to the same instance of <see cref="AppServiceEnvironmentResource"/>.
    /// To get a <see cref="HostingEnvironmentPrivateEndpointConnectionCollection"/> instance call the GetHostingEnvironmentPrivateEndpointConnections method from an instance of <see cref="AppServiceEnvironmentResource"/>.
    /// </summary>
    public partial class HostingEnvironmentPrivateEndpointConnectionCollection
    {
        /// <summary>
        /// Description for Approves or rejects a private endpoint connection
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/privateEndpointConnections/{privateEndpointConnectionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceEnvironments_ApproveOrRejectPrivateEndpointConnection</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="HostingEnvironmentPrivateEndpointConnectionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="privateEndpointConnectionName"> The <see cref="string"/> to use. </param>
        /// <param name="info"> The <see cref="PrivateLinkConnectionApprovalRequestInfo"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointConnectionName"/> or <paramref name="info"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<HostingEnvironmentPrivateEndpointConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfo info, CancellationToken cancellationToken)
            => await CreateOrUpdateAsync(waitUntil, privateEndpointConnectionName, new RemotePrivateEndpointConnectionARMResourceData(info.Id, info.Name, info.ResourceType, info.SystemData, null, null, info.PrivateLinkServiceConnectionState, new List<IPAddress>(), info.Kind, null), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Description for Approves or rejects a private endpoint connection
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/privateEndpointConnections/{privateEndpointConnectionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceEnvironments_ApproveOrRejectPrivateEndpointConnection</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="HostingEnvironmentPrivateEndpointConnectionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="privateEndpointConnectionName"> The <see cref="string"/> to use. </param>
        /// <param name="info"> The <see cref="PrivateLinkConnectionApprovalRequestInfo"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointConnectionName"/> or <paramref name="info"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<HostingEnvironmentPrivateEndpointConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfo info, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, privateEndpointConnectionName, new RemotePrivateEndpointConnectionARMResourceData(info.Id, info.Name, info.ResourceType, info.SystemData, null, null, info.PrivateLinkServiceConnectionState, new List<IPAddress>(), info.Kind, null), cancellationToken);
    }
}
