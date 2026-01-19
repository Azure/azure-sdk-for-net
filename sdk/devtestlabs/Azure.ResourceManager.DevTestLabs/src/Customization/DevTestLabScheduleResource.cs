// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.DevTestLabs.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DevTestLabs
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetApplicableAsync", typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetApplicable", typeof(CancellationToken))]
    public partial class DevTestLabScheduleResource : ArmResource
    {
        /// <summary>
        /// Lists all applicable schedules
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/schedules/{name}/listApplicable. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Schedules_ListApplicable. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2018-09-15. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DevTestLabScheduleResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabScheduleResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabScheduleResource> GetApplicableAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<DevTestLabScheduleData, DevTestLabScheduleResource>(new DevTestLabSchedulesGetApplicableAsyncCollectionResultOfT(
                _devTestLabSchedulesRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                context), data => new DevTestLabScheduleResource(Client, data));
        }

        /// <summary>
        /// Lists all applicable schedules
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/schedules/{name}/listApplicable. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Schedules_ListApplicable. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2018-09-15. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DevTestLabScheduleResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabScheduleResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabScheduleResource> GetApplicable(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<DevTestLabScheduleData, DevTestLabScheduleResource>(new DevTestLabSchedulesGetApplicableCollectionResultOfT(
                _devTestLabSchedulesRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                context), data => new DevTestLabScheduleResource(Client, data));
        }
    }
}
