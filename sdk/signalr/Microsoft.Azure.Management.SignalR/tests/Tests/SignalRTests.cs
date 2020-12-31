using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.SignalR;
using Microsoft.Azure.Management.SignalR.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace SignalR.Tests
{
    public class SignalRTests
    {
        [Fact]
        public void SignalRCheckNameTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(this.GetType()))
            {
                var resourceClient = SignalRTestUtilities.GetResourceManagementClient(context, handler);
                var signalrClient = SignalRTestUtilities.GetSignalRManagementClient(context, handler);

                // Create resource group
                var location = SignalRTestUtilities.GetDefaultSignalRLocation(resourceClient);
                var resourceGroup = SignalRTestUtilities.CreateResourceGroup(resourceClient, location);

                // Check valid name
                var signalrName = TestUtilities.GenerateName("signalr-service-test-0820");
                var checkNameRequest = signalrClient.SignalR.CheckNameAvailability(
                    location,
                    new NameAvailabilityParameters
                    {
                        Type = SignalRTestUtilities.SignalRResourceType,
                        Name = signalrName
                    });

                Assert.True(checkNameRequest.NameAvailable);
                Assert.Null(checkNameRequest.Reason);
                Assert.Null(checkNameRequest.Message);

                signalrName = SignalRTestUtilities.CreateSignalR(signalrClient, resourceGroup.Name, location).Name;
                checkNameRequest = signalrClient.SignalR.CheckNameAvailability(
                    location,
                    new NameAvailabilityParameters
                    {
                        Type = SignalRTestUtilities.SignalRResourceType,
                        Name = signalrName,
                    });
                Assert.False(checkNameRequest.NameAvailable);
                Assert.Equal("AlreadyExists", checkNameRequest.Reason);
                Assert.Equal("The name is already taken. Please try a different name.", checkNameRequest.Message);
            }
        }

        [Fact]
        public void SignalRFreeTierToStandardTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(this.GetType()))
            {
                var resourceClient = SignalRTestUtilities.GetResourceManagementClient(context, handler);
                var signalrClient = SignalRTestUtilities.GetSignalRManagementClient(context, handler);

                var location = SignalRTestUtilities.GetDefaultSignalRLocation(resourceClient);
                var resourceGroup = SignalRTestUtilities.CreateResourceGroup(resourceClient, location);

                var signalrName = TestUtilities.GenerateName("signalr-service-test-0820");

                var signalr = SignalRTestUtilities.CreateSignalR(signalrClient, resourceGroup.Name, location, isStandard: false);
                SignalRScenarioVerification(signalrClient, resourceGroup, signalr, false);
            }
        }

        [Fact]
        public void SignalRStandardTierToFreeTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(this.GetType()))
            {
                var resourceClient = SignalRTestUtilities.GetResourceManagementClient(context, handler);
                var signalrClient = SignalRTestUtilities.GetSignalRManagementClient(context, handler);

                var location = SignalRTestUtilities.GetDefaultSignalRLocation(resourceClient);
                var resourceGroup = SignalRTestUtilities.CreateResourceGroup(resourceClient, location);

                var signalrName = TestUtilities.GenerateName("signalr-service-test-0820");

                var capacity = 2;
                var signalr = SignalRTestUtilities.CreateSignalR(signalrClient, resourceGroup.Name, location, isStandard: true, capacity: capacity);
                SignalRScenarioVerification(signalrClient, resourceGroup, signalr, true, capacity);
            }
        }

        [Fact]
        public void SignalRUsageTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(this.GetType()))
            {
                var resourceClient = SignalRTestUtilities.GetResourceManagementClient(context, handler);
                var signalrClient = SignalRTestUtilities.GetSignalRManagementClient(context, handler);

                var location = SignalRTestUtilities.GetDefaultSignalRLocation(resourceClient);

                var usages = signalrClient.Usages.List(location);
                Assert.NotEmpty(usages);

                var usage = usages.First();
                Assert.NotNull(usage);
                Assert.NotEmpty(usage.Id);
                Assert.NotNull(usage.CurrentValue);
                Assert.NotNull(usage.Limit);
                Assert.NotNull(usage.Name);
                Assert.NotEmpty(usage.Name.Value);
                Assert.NotEmpty(usage.Name.LocalizedValue);
                Assert.NotEmpty(usage.Unit);
            }
        }



        private void SignalRScenarioVerification(SignalRManagementClient signalrClient, ResourceGroup resourceGroup, SignalRResource signalr, bool isStandard, int capacity = 1)
        {
            // Validate the newly created SignalR instance
            SignalRTestUtilities.ValidateResourceDefaultTags(signalr);
            Assert.NotNull(signalr.Sku);
            if (isStandard)
            {
                Assert.Equal(SignalRSkuTier.Standard, signalr.Sku.Tier);
                Assert.Equal("Standard_S1", signalr.Sku.Name);
                Assert.Equal("S1", signalr.Sku.Size);
                Assert.Equal(capacity, signalr.Sku.Capacity);
            }
            else
            {
                Assert.Equal(SignalRSkuTier.Free, signalr.Sku.Tier);
                Assert.Equal("Free_F1", signalr.Sku.Name);
                Assert.Equal("F1", signalr.Sku.Size);
                Assert.Equal(capacity, signalr.Sku.Capacity);
            }
            Assert.Equal(ProvisioningState.Succeeded, signalr.ProvisioningState);
            Assert.NotEmpty(signalr.HostName);
            Assert.NotEmpty(signalr.ExternalIP);
            Assert.NotNull(signalr.PublicPort);
            Assert.NotNull(signalr.ServerPort);
            Assert.NotEmpty(signalr.Version);
            Assert.Equal(3, signalr.Features.Count); // ServiceMode will be set as Default
            Assert.Equal("Default", signalr.Features.First().Value);
            Assert.Equal(1, signalr.Cors.AllowedOrigins.Count); // all origins(*) are allowed by default.
            Assert.Equal("*", signalr.Cors.AllowedOrigins.First());
            Assert.Equal("SignalR", signalr.Kind);
            Assert.Equal(1, signalr.Upstream.Templates.Count);

            // List the SignalR instances by resource group
            var signalrByResourceGroup = signalrClient.SignalR.ListByResourceGroup(resourceGroup.Name);
            Assert.Single(signalrByResourceGroup);
            signalr = signalrByResourceGroup.FirstOrDefault(r => StringComparer.OrdinalIgnoreCase.Equals(r.Name, signalr.Name));
            SignalRTestUtilities.ValidateResourceDefaultTags(signalr);

            // Get the SignalR instance by name
            signalr = signalrClient.SignalR.Get(resourceGroup.Name, signalr.Name);
            SignalRTestUtilities.ValidateResourceDefaultTags(signalr);

            // List keys
            var keys = signalrClient.SignalR.ListKeys(resourceGroup.Name, signalr.Name);
            Assert.NotNull(keys);
            Assert.NotEmpty(keys.PrimaryKey);
            Assert.NotEmpty(keys.PrimaryConnectionString);
            Assert.NotEmpty(keys.SecondaryKey);
            Assert.NotEmpty(keys.SecondaryConnectionString);

            // Update the SignalR instance
            capacity = isStandard ? 1 : 5;
            signalr = signalrClient.SignalR.Update(resourceGroup.Name, signalr.Name, new SignalRResource
            {
                Tags = SignalRTestUtilities.DefaultNewTags,
                Sku = new ResourceSku
                {
                    Name = isStandard ? "Free_F1" : "Standard_S1",
                    Tier = isStandard ? "Free" : "Standard",
                    Size = isStandard ? "F1" : "S1",
                    Capacity = capacity,
                },
                HostNamePrefix = TestUtilities.GenerateName("signalr-service-test"),
                Features = new List<SignalRFeature> {
                        new SignalRFeature { Value = "Serverless" }
                    },
                Cors = new SignalRCorsSettings
                {
                    AllowedOrigins = new List<string>
                        {
                            "http://example.com:12345",
                            "https://contoso.com",
                        }
                },
            });

            // Validate the updated SignalR instance
            SignalRTestUtilities.ValidateResourceDefaultNewTags(signalr);
            Assert.NotNull(signalr.Sku);
            if (isStandard)
            {
                Assert.Equal(SignalRSkuTier.Free, signalr.Sku.Tier);
                Assert.Equal("Free_F1", signalr.Sku.Name);
                Assert.Equal("F1", signalr.Sku.Size);
                Assert.Equal(capacity, signalr.Sku.Capacity);
            }
            else
            {
                Assert.Equal(SignalRSkuTier.Standard, signalr.Sku.Tier);
                Assert.Equal("Standard_S1", signalr.Sku.Name);
                Assert.Equal("S1", signalr.Sku.Size);
                Assert.Equal(capacity, signalr.Sku.Capacity);
            }
            Assert.Equal(ProvisioningState.Succeeded, signalr.ProvisioningState);
            Assert.NotEmpty(signalr.HostName);
            Assert.NotEmpty(signalr.ExternalIP);
            Assert.NotNull(signalr.PublicPort);
            Assert.NotNull(signalr.ServerPort);
            Assert.NotEmpty(signalr.Version);
            Assert.Equal(3, signalr.Features.Count);
            Assert.Equal("Serverless", signalr.Features.First().Value);
            Assert.Equal(2, signalr.Cors.AllowedOrigins.Count);
            Assert.Equal("http://example.com:12345", signalr.Cors.AllowedOrigins.First());
            Assert.Equal("https://contoso.com", signalr.Cors.AllowedOrigins.Last());

            // List keys of the updated SignalR instance
            keys = signalrClient.SignalR.ListKeys(resourceGroup.Name, signalr.Name);
            Assert.NotNull(keys);
            Assert.NotEmpty(keys.PrimaryKey);
            Assert.NotEmpty(keys.PrimaryConnectionString);
            Assert.NotEmpty(keys.SecondaryKey);
            Assert.NotEmpty(keys.SecondaryConnectionString);

            // Regenerate primary key
            var newKeys1 = signalrClient.SignalR.RegenerateKey(resourceGroup.Name, signalr.Name, new RegenerateKeyParameters
            {
                KeyType = "Primary",
            });
            // Due to a bug in SignalR RP, the result of RegenerateKey is null. UnComment following lines after we fixed it RP side
            //Assert.NotNull(newKeys1);
            //Assert.NotEqual(keys.PrimaryKey, newKeys1.PrimaryKey);
            //Assert.NotEqual(keys.PrimaryConnectionString, newKeys1.PrimaryConnectionString);
            //Assert.Null(newKeys1.SecondaryKey);
            //Assert.Null(newKeys1.SecondaryConnectionString);

            // Ensure only the primary key is regenerated
            newKeys1 = signalrClient.SignalR.ListKeys(resourceGroup.Name, signalr.Name);
            Assert.NotNull(newKeys1);
            Assert.NotEqual(keys.PrimaryKey, newKeys1.PrimaryKey);
            Assert.NotEqual(keys.PrimaryConnectionString, newKeys1.PrimaryConnectionString);
            Assert.Equal(keys.SecondaryKey, newKeys1.SecondaryKey);
            Assert.Equal(keys.SecondaryConnectionString, newKeys1.SecondaryConnectionString);

            // Regenerate secondary key
            var newKeys2 = signalrClient.SignalR.RegenerateKey(resourceGroup.Name, signalr.Name, new RegenerateKeyParameters
            {
                KeyType = "Secondary",
            });
            // Due to a bug in SignalR RP, the result of RegenerateKey is null. UnComment following lines after we fixed it RP side
            //Assert.NotNull(newKeys2);
            //Assert.Null(newKeys2.PrimaryKey);
            //Assert.Null(newKeys2.PrimaryConnectionString);
            //Assert.NotEqual(keys.SecondaryKey, newKeys2.SecondaryKey);
            //Assert.NotEqual(keys.SecondaryConnectionString, newKeys2.SecondaryConnectionString);

            // ensure only the secondary key is regenerated
            newKeys2 = signalrClient.SignalR.ListKeys(resourceGroup.Name, signalr.Name);
            Assert.NotNull(newKeys2);
            Assert.Equal(newKeys1.PrimaryKey, newKeys2.PrimaryKey);
            Assert.Equal(newKeys1.PrimaryConnectionString, newKeys2.PrimaryConnectionString);
            Assert.NotEqual(newKeys1.SecondaryKey, newKeys2.SecondaryKey);
            Assert.NotEqual(newKeys1.SecondaryConnectionString, newKeys2.SecondaryConnectionString);

            // Delete the SignalR instance
            signalrClient.SignalR.Delete(resourceGroup.Name, signalr.Name);

            // Delete again, should be no-op
            signalrClient.SignalR.Delete(resourceGroup.Name, signalr.Name);
        }
    }
}

