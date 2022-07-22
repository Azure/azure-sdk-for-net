using Microsoft.Orbital.Tests.Helpers;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Orbital.Tests
{
    public class TestBase
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static AzureOrbitalClient GetAzureOrbitalClientWithHandler(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return context.GetServiceClient<AzureOrbitalClient>(handlers: handler);
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static ResourceManagementClient GetResourceManagementClientWithHandler(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }
    }
}