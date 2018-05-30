// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace EventGrid.Tests.TestHelper
{
    public static class EventGridManagementHelper
    {
        internal const string TopicPrefix = "sdk-Topic-";
        internal const string EventSubscriptionPrefix = "sdk-EventSubscription-";
        internal const string EventGridPrefix = "sdk-EventGrid-";
        internal const string ResourceGroupPrefix = "sdk-EventGrid-RG-";

        public static EventGridManagementClient GetEventGridManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
                EventGridManagementClient eventGridManagementClient = context.GetServiceClient<EventGridManagementClient>(handlers: handler);
                return eventGridManagementClient;
            }

            return null;
        }

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
                ResourceManagementClient resourceManagementClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
                return resourceManagementClient;
            }

            return null;
        }

        public static string TryGetResourceGroup(this ResourceManagementClient resourceManagementClient, string location)
        {
            const string DefaultResourceGroupName = "SDKTests";

            var resourceGroup = resourceManagementClient.ResourceGroups
                    .List().Where(group => string.IsNullOrWhiteSpace(location) || group.Location.Equals(location.Replace(" ", string.Empty), StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault(group => group.Name.Contains(DefaultResourceGroupName));

            return resourceGroup != null
                ? resourceGroup.Name
                : string.Empty;
        }

        public static void TryRegisterResourceGroup(this ResourceManagementClient resourceManagementClient, string location, string resourceGroupName)
        {
            resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup(location));
        }

        public static string GetLocationFromProvider(this ResourceManagementClient resourceManagementClient)
        {
            // West Central US is one of our early deployment regions
            // so we typically record tests targeting this region.
            return "westcentralus";
        }
    }
}