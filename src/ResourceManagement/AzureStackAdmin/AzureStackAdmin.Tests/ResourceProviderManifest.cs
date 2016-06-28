using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.PeerToPeer.Collaboration;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.AzureStack.Management;
using Microsoft.AzureStack.Management.Models;
using Xunit;

namespace AzureStackAdmin.Tests
{
    public class ResourceProviderManifestTests
    {
        public AzureStackClient GetAzureStackAdminClient(RecordedDelegatingHandler handler)
        {
            var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "fake");
            handler.IsPassThrough = false;
            return new AzureStackClient(new Uri("https://armuri"), token, "2015-11-01").WithHandler(handler);
        }

        [Fact]
        public void GetResourceProviderManifest()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/b5c4cce5-bf48-4c87-a083-eb99fda1f60e/resourceGroups/System/providers/Microsoft.Subscriptions.Providers/manifests/Microsoft.Sql.Admin',
                    'name': 'Microsoft.Sql.Admin',
                    'type': 'Microsoft.Subscriptions.Providers/manifests',
                    'location': 'local',
                    'properties': {
                        'displayName': 'Microsoft.Sql.Admin',
                        'namespace': 'Microsoft.Sql.Admin',
                        'providerLocation': 'local',
                        'providerType': 'NotSpecified',
                        'extensions': [
                            {
                                'name': 'SqlAdminExtension',
                                'uri': 'https://azstack:13002/'
                            }
                        ],
                        'resourceTypes': [
                            {
                                'name': 'hostingservers',
                                'routingType': 'Default',
                                'resourceDeletionPolicy': 'NotSpecified',
                                'endpoints': [
                                    {
                                        'apiVersions': [
                                            '2014-04-01-preview'
                                        ],
                                        'enabled': true,
                                        'endpointUri': 'https://azstack:30010',
                                        'timeout': 'PT0S'
                                    }
                                ],
                                'marketplaceType': 'NotSpecified'
                            }
                        ],
                        'enabled': true,
                        'provisioningState': 'Succeeded'
                    }
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetAzureStackAdminClient(handler);

            var result = client.ProviderRegistrations.Get("TestRG", "Microsoft.Sql.Admin");
            
            // Validate Headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("Microsoft.Sql.Admin", result.ProviderRegistration.Name);
            Assert.Equal("local", result.ProviderRegistration.Location);
            Assert.Equal("Microsoft.Sql.Admin", result.ProviderRegistration.Properties.Namespace);
            Assert.Equal("local", result.ProviderRegistration.Properties.ProviderLocation);
            Assert.Equal("hostingservers", result.ProviderRegistration.Properties.ResourceTypes[0].Name);
            Assert.Equal("hostingservers", result.ProviderRegistration.Properties.Extensions[0].Name);
            Assert.Equal("2014-04-01-preview", result.ProviderRegistration.Properties.ResourceTypes[0].Endpoints[0].ApiVersions[0]);
            Assert.Equal("https://azstack:30010", result.ProviderRegistration.Properties.ResourceTypes[0].Endpoints[0].EndpointUri);
            Assert.Equal(new TimeSpan(0, 0, 0), result.ProviderRegistration.Properties.ResourceTypes[0].Endpoints[0].Timeout);
            Assert.Equal(true, result.ProviderRegistration.Properties.ResourceTypes[0].Endpoints[0].Enabled);
            Assert.Equal(RoutingType.Default, result.ProviderRegistration.Properties.ResourceTypes[0].RoutingType);
            Assert.Equal(ResourceDeletionPolicy.NotSpecified, result.ProviderRegistration.Properties.ResourceTypes[0].ResourceDeletionPolicy);
            Assert.Equal(MarketplaceType.NotSpecified, result.ProviderRegistration.Properties.ResourceTypes[0].MarketplaceType);
            // Assert.Equal(ProvisioningState.Succeeded, result.ProviderRegistration.Properties.ProvisioningState);
        }

        [Fact]
        public void CreateOrUpdateResourceProviderManifest()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/b5c4cce5-bf48-4c87-a083-eb99fda1f60e/resourceGroups/System/providers/Microsoft.Subscriptions.Providers/manifests/Microsoft.Sql.Admin',
                    'name': 'Microsoft.Sql.Admin',
                    'type': 'Microsoft.Subscriptions.Providers/manifests',
                    'location': 'local',
                    'properties': {
                        'displayName': 'Microsoft.Sql.Admin',
                        'namespace': 'Microsoft.Sql.Admin',
                        'providerLocation': 'local',
                        'providerType': 'NotSpecified',
                        'extensions': [
                            {
                                'name': 'SqlAdminExtension',
                                'uri': 'https://azstack:13002/'
                            }
                        ],
                        'resourceTypes': [
                            {
                                'name': 'hostingservers',
                                'routingType': 'Default',
                                'resourceDeletionPolicy': 'NotSpecified',
                                'endpoints': [
                                    {
                                        'apiVersions': [
                                            '2014-04-01-preview'
                                        ],
                                        'enabled': true,
                                        'endpointUri': 'https://azstack:30010',
                                        'timeout': 'PT0S'
                                    }
                                ],
                                'marketplaceType': 'NotSpecified'
                            }
                        ],
                        'enabled': true,
                        'provisioningState': 'Succeeded'
                    }
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetAzureStackAdminClient(handler);

            var result = client.ProviderRegistrations.CreateOrUpdate(
                "system",
                new ProviderRegistrationCreateOrUpdateParameters(
                    new ProviderRegistrationModel()
                    {
                        Location = "local",
                        Name = "Microsoft.Sql.Admin",
                        Properties = new ManifestPropertiesDefinition()
                                     {
                                         DisplayName = "Microsoft.Sql.Admin",
                                         ExtensionName = "Microsoft.Sql.Admin",
                                         Enabled = true,
                                         Extensions = new Extension[]
                                                      {
                                                          new Extension() {Name = "SqlAdminExtension", Uri = "https://azstack:13002/"}
                                                      },
                                         ResourceTypes = new ResourceType[]
                                                         {
                                                             new ResourceType()
                                                             {
                                                                 Name = "hostingservers",
                                                                 RoutingType = RoutingType.Default,
                                                                 Endpoints = new ResourceProviderEndpoint[]
                                                                             {
                                                                                 new ResourceProviderEndpoint()
                                                                                 {
                                                                                     ApiVersions = new[] {"2014-04-01-preview"},
                                                                                     Enabled = true,
                                                                                     EndpointUri = "https://azstack:30010",
                                                                                 }
                                                                             }

                                                             }
                                                         },
                                         ProvisioningState = ProvisioningState.Succeeded
                                     }
                    }
                    ));

            // Validate Headers
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("Microsoft.Sql.Admin", result.ProviderRegistration.Name);
            Assert.Equal("local", result.ProviderRegistration.Location);
            Assert.Equal("Microsoft.Sql.Admin", result.ProviderRegistration.Properties.Namespace);
            Assert.Equal("local", result.ProviderRegistration.Properties.ProviderLocation);
            Assert.Equal("hostingservers", result.ProviderRegistration.Properties.ResourceTypes[0].Name);
            Assert.Equal("hostingservers", result.ProviderRegistration.Properties.Extensions[0].Name);
            Assert.Equal("2014-04-01-preview", result.ProviderRegistration.Properties.ResourceTypes[0].Endpoints[0].ApiVersions[0]);
            Assert.Equal("https://azstack:30010", result.ProviderRegistration.Properties.ResourceTypes[0].Endpoints[0].EndpointUri);
            Assert.Equal(new TimeSpan(0, 0, 0), result.ProviderRegistration.Properties.ResourceTypes[0].Endpoints[0].Timeout);
            Assert.Equal(true, result.ProviderRegistration.Properties.ResourceTypes[0].Endpoints[0].Enabled);
            Assert.Equal(RoutingType.Default, result.ProviderRegistration.Properties.ResourceTypes[0].RoutingType);
            Assert.Equal(ResourceDeletionPolicy.NotSpecified, result.ProviderRegistration.Properties.ResourceTypes[0].ResourceDeletionPolicy);
            Assert.Equal(MarketplaceType.NotSpecified, result.ProviderRegistration.Properties.ResourceTypes[0].MarketplaceType);
        }

        [Fact]
        public void DeleteResourceProviderManifest()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetAzureStackAdminClient(handler);

            var result = client.ProviderRegistrations.Delete("system", "Microsoft.Sql.Admin");

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }
    }
}
