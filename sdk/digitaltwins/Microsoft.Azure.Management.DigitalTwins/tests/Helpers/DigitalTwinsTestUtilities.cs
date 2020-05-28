
using Microsoft.Azure.Management.DigitalTwins;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DigitalTwins.Tests.Helpers
{
    class DigitalTwinsTestUtilities
    {
        public static string DefaultLocation = "WestUS";
        public static string DefaultInstanceName = "DigitalTwins";
        public static string DefaultEndpointName = "DigitalTwinsEndpoint";
        public static string DefaultResourceGroupName = "DigitalTwinsResourceGroup";

        public static AzureDigitalTwinsManagementClient GetDigitalTwinsClient(MockContext context, RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            return context.GetServiceClient<AzureDigitalTwinsManagementClient>(handlers: handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
        }

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }
    }
}
