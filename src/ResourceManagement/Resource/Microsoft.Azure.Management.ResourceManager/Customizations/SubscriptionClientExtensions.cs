// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Rest.Azure
{
    public static class SubscriptionClientExtensions
    {
        public static ISubscriptionClient GetSubscriptionClient(this IAzureContext context)
        {
           return SubscriptionClient.CreateClient(context);
        }

        public static ISubscriptionsOperations GetSubscriptionOperations(IAzureContext context)
        {
            return context.GetSubscriptionClient().Subscriptions;
        }

        public static ITenantsOperations GetTenantOperations(IAzureContext context)
        {
            return context.GetSubscriptionClient().Tenants;
        }
    }
}
