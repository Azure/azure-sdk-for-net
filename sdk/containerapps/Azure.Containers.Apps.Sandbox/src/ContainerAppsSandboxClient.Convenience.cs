// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.Core;

namespace Azure.Containers.Apps.Sandbox
{
    public partial class ContainerAppsSandboxClient
    {
        private static readonly ResourceType s_sandboxGroupResourceType = new ResourceType("Microsoft.App/sandboxGroups");

        /// <summary>
        /// Initializes a new instance of <see cref="SandboxGroup"/> from its Azure Resource Manager identifier.
        /// </summary>
        /// <param name="sandboxGroupId">The Azure Resource Manager identifier of the sandbox group.</param>
        /// <returns>A client for operations scoped to the specified sandbox group.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="sandboxGroupId"/> is null.</exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="sandboxGroupId"/> is not a resource-group-scoped
        /// <c>Microsoft.App/sandboxGroups</c> resource identifier.
        /// </exception>
        public virtual SandboxGroup GetSandboxGroupClient(ResourceIdentifier sandboxGroupId)
        {
            Argument.AssertNotNull(sandboxGroupId, nameof(sandboxGroupId));

            if (sandboxGroupId.ResourceType != s_sandboxGroupResourceType)
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        "Invalid resource type {0}, expected {1}.",
                        sandboxGroupId.ResourceType,
                        s_sandboxGroupResourceType),
                    nameof(sandboxGroupId));
            }

            if (string.IsNullOrEmpty(sandboxGroupId.SubscriptionId) ||
                string.IsNullOrEmpty(sandboxGroupId.ResourceGroupName))
            {
                throw new ArgumentException(
                    "The sandbox group identifier must contain a subscription and resource group.",
                    nameof(sandboxGroupId));
            }

            return GetSandboxGroupClient(
                sandboxGroupId.SubscriptionId,
                sandboxGroupId.ResourceGroupName,
                sandboxGroupId.Name);
        }
    }
}
