// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Containers.Apps.Sandbox
{
    public partial class SandboxGroup
    {
        /// <summary>
        /// Gets the subscription identifier associated with this client.
        /// </summary>
        public virtual string SubscriptionId => _subscriptionId;

        /// <summary>
        /// Gets the resource group name associated with this client.
        /// </summary>
        public virtual string ResourceGroupName => _resourceGroupName;

        /// <summary>
        /// Gets the sandbox group name associated with this client.
        /// </summary>
        public virtual string Name => _sandboxGroupName;

        /// <summary>
        /// Gets the Azure Resource Manager identifier of the sandbox group associated with this client.
        /// </summary>
        public virtual ResourceIdentifier Id => new ResourceIdentifier(
            $"/subscriptions/{_subscriptionId}/resourceGroups/{_resourceGroupName}/providers/Microsoft.App/sandboxGroups/{_sandboxGroupName}");
    }
}
