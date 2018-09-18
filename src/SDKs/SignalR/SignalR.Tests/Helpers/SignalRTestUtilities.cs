using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.SignalR;
using Microsoft.Azure.Management.SignalR.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TrackedResource = Microsoft.Azure.Management.SignalR.Models.TrackedResource;

namespace SignalR.Tests
{
    public static class SignalRTestUtilities
    {
        public const string SignalRNamespace = "Microsoft.SignalRService";
        public const string SignalRResourceTypeName = "SignalR";
        public const string SignalRResourceType = SignalRNamespace + "/" + SignalRResourceTypeName;

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

        public static string GetDefaultSignalRLocation(ResourceManagementClient client)
        {
            Provider provider = client.Providers.Get(SignalRNamespace);
            ProviderResourceType resourceType = provider.ResourceTypes.First(
                t => StringComparer.OrdinalIgnoreCase.Equals(t.ResourceType, SignalRResourceTypeName));
            return resourceType.Locations.First();
        }

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }

        public static SignalRManagementClient GetSignalRManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<SignalRManagementClient>(handlers: handler);
            return client;
        }

        public static ResourceGroup CreateResourceGroup(ResourceManagementClient client, string location = null)
        {
            return client.ResourceGroups.CreateOrUpdate(
                TestUtilities.GenerateName("signalr-test-rg"),
                new ResourceGroup
                {
                    Location = location ?? GetDefaultSignalRLocation(client)
                });
        }

        public static SignalRResource CreateSignalR(SignalRManagementClient client, string resourceGroupName, string location, bool isStandard = false, int capacity = 1)
        {
            ResourceSku sku;
            if (isStandard)
            {
                sku = new ResourceSku
                {
                    Name = "Standard_S1",
                    Tier = "Standard",
                    Size = "S1",
                    Capacity = capacity,
                };
            }
            else
            {
                sku = new ResourceSku
                {
                    Name = "Free_F1",
                    Tier = "Free",
                    Size = "F1",
                };
            }

            return client.SignalR.CreateOrUpdate(
                resourceGroupName,
                TestUtilities.GenerateName("signalr-test"),
                new SignalRCreateParameters
                {
                    Location = location,
                    Sku = sku,
                    Tags = DefaultTags,
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
