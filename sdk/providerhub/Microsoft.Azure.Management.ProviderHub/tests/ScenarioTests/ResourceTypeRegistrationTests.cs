
using Microsoft.Azure.Management.ProviderHub.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Management.ProviderHub.Tests
{
    public class ResourceTypeRegistrationTests
    {
        [Fact]
        public void ResourceTypeRegistrationsCRUDTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                string providerNamespace = "Microsoft.Contoso";
                string resourceType = "employees";
                var employeesResourceTypeProperties = new ResourceTypeRegistrationProperties
                {
                    RoutingType = "Default",
                    Regionality = "Regional",
                    Endpoints = new ResourceTypeEndpoint[]
                    {
                        new ResourceTypeEndpoint
                        {
                            ApiVersions = new List<string>
                            {
                                "2018-11-01-preview",
                                "2020-01-01-preview",
                                "2019-01-01"
                            },
                            Locations = new string[]
                            {
                                "West US",
                                "West Central US",
                                "West Europe",
                                "Southeast Asia",
                                "West US 2",
                                "East US 2 EUAP",
                                "North Europe",
                                "East US",
                                "East Asia"
                            },
                            RequiredFeatures = new string[] { "Microsoft.Contoso/RPaaSSampleApp" }
                        }
                    },
                    SwaggerSpecifications = new SwaggerSpecification[]
                    {
                        new SwaggerSpecification
                        {
                            ApiVersions = new List<string>
                            {
                                "2018-11-01-preview",
                                "2020-01-01-preview",
                                "2019-01-01"
                            },
                            SwaggerSpecFolderUri = "https://github.com/Azure/azure-rest-api-specs-pr/blob/RPSaaSMaster/specification/rpsaas/resource-manager/Microsoft.Contoso/"
                        }
                    },
                    EnableAsyncOperation = true,
                    EnableThirdPartyS2S = false,
                    ResourceMovePolicy = new ResourceTypeRegistrationPropertiesResourceMovePolicy
                    {
                        ValidationRequired = false,
                        CrossResourceGroupMoveEnabled = true,
                        CrossSubscriptionMoveEnabled = true
                    }
                };

                var resourceTypeRegistration = CreateResourceTypeRegistration(context, providerNamespace, resourceType, employeesResourceTypeProperties);
                Assert.NotNull(resourceTypeRegistration);

                resourceTypeRegistration = GetResourceTypeRegistration(context, providerNamespace, resourceType);
                Assert.NotNull(resourceTypeRegistration);

                var resourceTypeRegistrationsList = ListResourceTypeRegistration(context, providerNamespace);
                Assert.NotNull(resourceTypeRegistrationsList);

                DeleteResourceTypeRegistration(context, providerNamespace, resourceType);
                var exception = Assert.Throws<ErrorResponseException>(() => GetResourceTypeRegistration(context, providerNamespace, resourceType));
                Assert.True(exception.Response.StatusCode == System.Net.HttpStatusCode.NotFound);

                resourceTypeRegistration = CreateResourceTypeRegistration(context, providerNamespace, resourceType, employeesResourceTypeProperties);
                Assert.NotNull(resourceTypeRegistration);
            }
        }

        private ResourceTypeRegistration CreateResourceTypeRegistration(MockContext context, string providerNamespace, string resourceType, ResourceTypeRegistrationProperties properties)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.ResourceTypeRegistrations.CreateOrUpdate(providerNamespace, resourceType, properties);
        }

        private ResourceTypeRegistration GetResourceTypeRegistration(MockContext context, string providerNamespace, string resourceType)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.ResourceTypeRegistrations.Get(providerNamespace, resourceType);
        }

        private IPage<ResourceTypeRegistration> ListResourceTypeRegistration(MockContext context, string providerNamespace)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.ResourceTypeRegistrations.ListByProviderRegistration(providerNamespace);
        }

        private void DeleteResourceTypeRegistration(MockContext context, string providerNamespace, string resourceType)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            client.ResourceTypeRegistrations.Delete(providerNamespace, resourceType);
        }

        private ProviderHubClient GetProviderHubManagementClient(MockContext context)
        {
            return context.GetServiceClient<ProviderHubClient>();
        }
    }
}
