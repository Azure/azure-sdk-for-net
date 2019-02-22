using Microsoft.Azure.Management.DeploymentManager;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TrackedResource = Microsoft.Azure.Management.DeploymentManager.Models.TrackedResource;

namespace Management.DeploymentManager.Tests
{
    public static class DeploymentManagerTestUtilities
    {
        public const string ProviderName = "Microsoft.DeploymentManager";

        public const string Location = "Central US";

        public static readonly Dictionary<string, string> DefaultTags = new Dictionary<string, string>
        {
            { "key1", "value1" },
            { "key2", "value2" },
        };
        public static readonly Dictionary<string, string> DefaultNewTags = new Dictionary<string, string>
        {
            { "key2","value2"},
            { "key3","value3"},
            { "key4","value4"}
        };

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }

        public static AzureDeploymentManagerClient GetDeploymentManagerClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<AzureDeploymentManagerClient>(handlers: handler);
            return client;
        }

        public static ResourceGroup CreateResourceGroup(ResourceManagementClient client, string location)
        {
            return client.ResourceGroups.CreateOrUpdate(
                TestUtilities.GenerateName("deploymentmanager-sdk-net-test-rg"),
                new ResourceGroup
                {
                    Location = location 
                });
        }

        public static void ValidateResourceDefaultTags(TrackedResource resource)
        {
            ValidateResource(resource);
            Assert.NotNull(resource.Tags);
            Assert.Equal(2, resource.Tags.Count);
            Assert.Equal("value1", resource.Tags["key1"]);
            Assert.Equal("value2", resource.Tags["key2"]);
        }

        public static void ValidateResourceDefaultNewTags(TrackedResource resource)
        {
            ValidateResource(resource);
            Assert.NotNull(resource.Tags);
            Assert.Equal(3, resource.Tags.Count);
            Assert.Equal("value2", resource.Tags["key2"]);
            Assert.Equal("value3", resource.Tags["key3"]);
            Assert.Equal("value4", resource.Tags["key4"]);
        }

        private static void ValidateResource(TrackedResource resource)
        {
            Assert.NotNull(resource);
            Assert.NotNull(resource.Id);
            Assert.NotNull(resource.Name);
            Assert.NotNull(resource.Type);
            Assert.NotNull(resource.Location);
        }
    }
}
