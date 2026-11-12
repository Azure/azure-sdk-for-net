// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.ContainerInstance;
using Azure.ResourceManager.ContainerInstance.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ContainerInstance.Mocking
{
    public partial class MockableContainerInstanceSubscriptionResource : ArmResource
    {
        private ClientDiagnostics _sandboxGroupsClientDiagnostics;

        private SandboxGroups _sandboxGroupsRestClient;

        private ClientDiagnostics SandboxGroupsClientDiagnostics => _sandboxGroupsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.ContainerInstance.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);

        private SandboxGroups SandboxGroupsRestClient => _sandboxGroupsRestClient ??= new SandboxGroups(SandboxGroupsClientDiagnostics, Pipeline, Diagnostics.ApplicationId, Endpoint, "2026-07-01");

        /// <summary>
        /// List SandboxGroup resources by subscription ID
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/sandboxGroups. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> SandboxGroups_ListBySubscription. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-07-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ContainerGroupSandboxResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ContainerGroupSandboxResource> GetContainerGroupSandboxesAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<ContainerGroupSandboxData, ContainerGroupSandboxResource>(new SandboxGroupsGetBySubscriptionAsyncCollectionResultOfT(SandboxGroupsRestClient, Guid.Parse(Id.SubscriptionId), context, "MockableContainerInstanceSubscriptionResource.GetContainerGroupSandboxes"), data => new ContainerGroupSandboxResource(Client, data));
        }

        /// <summary>
        /// List SandboxGroup resources by subscription ID
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/sandboxGroups. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> SandboxGroups_ListBySubscription. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-07-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ContainerGroupSandboxResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ContainerGroupSandboxResource> GetContainerGroupSandboxes(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<ContainerGroupSandboxData, ContainerGroupSandboxResource>(new SandboxGroupsGetBySubscriptionCollectionResultOfT(SandboxGroupsRestClient, Guid.Parse(Id.SubscriptionId), context, "MockableContainerInstanceSubscriptionResource.GetContainerGroupSandboxes"), data => new ContainerGroupSandboxResource(Client, data));
        }
    }
}
