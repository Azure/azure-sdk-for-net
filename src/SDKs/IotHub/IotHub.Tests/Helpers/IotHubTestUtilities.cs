// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 


namespace IotHub.Tests.Helpers
{
    using System.Net;
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class IotHubTestUtilities
    {
        public static string DefaultLocation = "WestUS";
        public static string DefaultIotHubName = "DotNetHub";
        public static string DefaultUpdateIotHubName = "UpdateDotNetHub";
        public static string DefaultResourceGroupName = "DotNetHubRG";
        public static string DefaultUpdateResourceGroupName = "UpdateDotNetHubRG";
        public static string EventsEndpointName = "events";
        public static IotHubClient GetIotHubClient(MockContext context, RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            return context.GetServiceClient<IotHubClient>(handlers: handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
        }

        public static EventHubManagementClient GetEhClient(MockContext context, RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            return context.GetServiceClient<EventHubManagementClient>(handlers: handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
        }

        public static ServiceBusManagementClient GetSbClient(MockContext context, RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            return context.GetServiceClient<ServiceBusManagementClient>(handlers: handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
        }

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }
    }
}
