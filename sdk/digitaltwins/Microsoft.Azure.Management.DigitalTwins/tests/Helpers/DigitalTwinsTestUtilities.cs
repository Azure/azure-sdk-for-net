namespace DigitalTwins.Tests.Helpers
{

    using Microsoft.Azure.Management.DigitalTwins;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.Net;
    class DigitalTwinsTestUtilities
    {
        public static string DefaultLocation = "westus2";
        public static string DefaultInstanceName = "DigitalTwinsSDK";
        public static string DefaultEndpointName = "DigitalTwinsSDKEndpoint";
        public static string DefaultResourceGroupName = "DigitalTwinsSDKResourceGroup";

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
