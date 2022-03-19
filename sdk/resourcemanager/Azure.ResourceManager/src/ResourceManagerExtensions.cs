// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager
{
    /// <summary>
    /// Extension class for resource manager.
    /// </summary>
    internal static class ResourceManagerExtensions
    {
        internal static ResourceIdentifier GetSubscriptionResourceIdentifier(this ResourceIdentifier id)
        {
            if (id.ResourceType == Subscription.ResourceType)
                return id;

            ResourceIdentifier parent = id.Parent;
            while (parent != null && parent.ResourceType != Subscription.ResourceType)
            {
                parent = parent.Parent;
            }

            return parent?.ResourceType == Subscription.ResourceType ? parent : null;
        }
    }
}
