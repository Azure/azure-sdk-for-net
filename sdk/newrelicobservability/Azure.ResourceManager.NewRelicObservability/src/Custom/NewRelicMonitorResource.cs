// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.NewRelicObservability.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NewRelicObservability
{
    /// <summary>
    /// A Class representing a NewRelicMonitorResource along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="NewRelicMonitorResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetNewRelicMonitorResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetNewRelicMonitorResource method.
    /// </summary>
    public partial class NewRelicMonitorResource : ArmResource
    {
        /// <summary>
        /// Update a NewRelicMonitorResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/NewRelic.Observability/monitors/{monitorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Monitors_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-07-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NewRelicMonitorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The resource properties to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<Response<NewRelicMonitorResource>> UpdateAsync(NewRelicMonitorResourcePatch patch, CancellationToken cancellationToken)
        {
            ArmOperation<NewRelicMonitorResource> result = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new NewRelicMonitorResource(Client, result.Value.Data), result.GetRawResponse());
        }

        /// <summary>
        /// Update a NewRelicMonitorResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/NewRelic.Observability/monitors/{monitorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Monitors_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-07-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NewRelicMonitorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The resource properties to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual Response<NewRelicMonitorResource> Update(NewRelicMonitorResourcePatch patch, CancellationToken cancellationToken)
        {
            ArmOperation<NewRelicMonitorResource> result = Update(WaitUntil.Completed, patch, cancellationToken);
            return Response.FromValue(new NewRelicMonitorResource(Client, result.Value.Data), result.GetRawResponse());
        }
    }
}
