// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ContainerInstance;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ContainerInstance.Mocking
{
    public partial class MockableContainerInstanceResourceGroupResource : ArmResource
    {
        /// <summary> Gets a collection of ContainerGroupSandboxes in the <see cref="ResourceGroupResource"/>. </summary>
        /// <returns> An object representing collection of ContainerGroupSandboxes and their operations over a ContainerGroupSandboxResource. </returns>
        public virtual ContainerGroupSandboxCollection GetContainerGroupSandboxes()
        {
            return GetCachedClient(client => new ContainerGroupSandboxCollection(client, Id));
        }

        /// <summary>
        /// Get a SandboxGroup
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/sandboxGroups/{sandboxGroupName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> SandboxGroups_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-07-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="sandboxGroupName"> The name of the SandboxGroup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sandboxGroupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="sandboxGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<ContainerGroupSandboxResource>> GetContainerGroupSandboxAsync(string sandboxGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sandboxGroupName, nameof(sandboxGroupName));

            return await GetContainerGroupSandboxes().GetAsync(sandboxGroupName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a SandboxGroup
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/sandboxGroups/{sandboxGroupName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> SandboxGroups_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-07-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="sandboxGroupName"> The name of the SandboxGroup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sandboxGroupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="sandboxGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<ContainerGroupSandboxResource> GetContainerGroupSandbox(string sandboxGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sandboxGroupName, nameof(sandboxGroupName));

            return GetContainerGroupSandboxes().Get(sandboxGroupName, cancellationToken);
        }
    }
}
