// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Net;
using System.Net.Http;
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
                        'routingResourceManagerType': 'Default',
                        'extensionCollection':
                            {
                                'version' : '0.1.0.0',
                                'extensions': [
                                    {
                                        'name': 'SqlAdminExtension',
                                        'uri': 'https://azstack:13002/',
                                        'properties':
                                            {
                                                'quotaCreateBladeName': 'addSqlQuotaBlade',
                                                'resourceProviderDashboardBladeName': 'addSqlServerBlade'
                                            }
                                    }
                                ]
                            }
                        ,
                        'resourceTypes': [
                            {
                                'name': 'hostingservers',
                                'routingType': 'Default',
                                'resourceDeletionPolicy': 'NotSpecified',
                                'inGlobalLocation': true,
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
                        'provisioningState': 'Succeeded',
                        'signature': 'e39843e0490cf8a4c876ce0eb2e35b595cdea663'
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
            Assert.Equal("0.1.0.0", result.ProviderRegistration.Properties.ExtensionCollection.Version);
            Assert.Equal("SqlAdminExtension", result.ProviderRegistration.Properties.ExtensionCollection.Extensions[0].Name);
            Assert.Equal("https://azstack:13002/", result.ProviderRegistration.Properties.ExtensionCollection.Extensions[0].Uri);
            Assert.Equal("addSqlQuotaBlade", result.ProviderRegistration.Properties.ExtensionCollection.Extensions[0].Properties.QuotaCreateBladeName);
            Assert.Equal("addSqlServerBlade", result.ProviderRegistration.Properties.ExtensionCollection.Extensions[0].Properties.ResourceProviderDashboardBladeName);
            Assert.Equal("2014-04-01-preview", result.ProviderRegistration.Properties.ResourceTypes[0].Endpoints[0].ApiVersions[0]);
            Assert.Equal(ResourceManagerType.Default, result.ProviderRegistration.Properties.RoutingResourceManagerType);
            Assert.Equal("https://azstack:30010", result.ProviderRegistration.Properties.ResourceTypes[0].Endpoints[0].EndpointUri);
            Assert.Equal(new TimeSpan(0, 0, 0), result.ProviderRegistration.Properties.ResourceTypes[0].Endpoints[0].Timeout);
            Assert.Equal(true, result.ProviderRegistration.Properties.ResourceTypes[0].Endpoints[0].Enabled);
            Assert.Equal(RoutingType.Default, result.ProviderRegistration.Properties.ResourceTypes[0].RoutingType);
            Assert.Equal(true, result.ProviderRegistration.Properties.ResourceTypes[0].InGlobalLocation);
            Assert.Equal(ResourceDeletionPolicy.NotSpecified, result.ProviderRegistration.Properties.ResourceTypes[0].ResourceDeletionPolicy);
            Assert.Equal(MarketplaceType.NotSpecified, result.ProviderRegistration.Properties.ResourceTypes[0].MarketplaceType);
            Assert.Equal("Succeeded", result.ProviderRegistration.Properties.ProvisioningState);
            Assert.Equal("e39843e0490cf8a4c876ce0eb2e35b595cdea663", result.ProviderRegistration.Properties.Signature);
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
                        'routingResourceManagerType': 'Admin',
                        'extensionCollection':
                            {
                                'version' : '0.1.0.0',
                                'extensions': [
                                    {
                                        'name': 'SqlAdminExtension',
                                        'uri': 'https://azstack:13002/',
                                        'properties':
                                            {
                                                'quotaCreateBladeName': 'addSqlQuotaBlade',
                                                'resourceProviderDashboardBladeName': 'addSqlServerBlade'
                                            }
                                    }
                                ]
                            }
                        ,
                        'resourceTypes': [
                            {
                                'name': 'hostingservers',
                                'routingType': 'Default',
                                'resourceDeletionPolicy': 'NotSpecified',
                                'inGlobalLocation': true,
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
                        'provisioningState': 'Succeeded',
                        'signature': 'e39843e0490cf8a4c876ce0eb2e35b595cdea663'
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
                                         Enabled = true,
                                         RoutingResourceManagerType = ResourceManagerType.Admin,
                                         ResourceTypes = new ResourceType[]
                                                         {
                                                             new ResourceType()
                                                             {
                                                                 Name = "hostingservers",
                                                                 RoutingType = RoutingType.Default,
                                                                 InGlobalLocation = true,
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
                            ExtensionCollection = new ExtensionCollectionDefinition()
                            {
                                Version = "0.1.0.0",
                                Extensions = new ExtensionDefinition[]
                                                {
                                                    new ExtensionDefinition()
                                                    {
                                                        Name = "SqlAdminExtenstion",
                                                        Uri = "https://azstack:30011",
                                                        Properties = new ExtensionPropertiesDefinition()
                                                                        {
                                                                            QuotaCreateBladeName = "addSqlQuotaBlade",
                                                                            ResourceProviderDashboardBladeName = "addSqlServerBlade"
                                                                        }
                                                    }
                                                }
                            },
                            ProvisioningState = "Succeeded",
                            Signature = "e39843e0490cf8a4c876ce0eb2e35b595cdea663"
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
            Assert.Equal(ResourceManagerType.Admin, result.ProviderRegistration.Properties.RoutingResourceManagerType);
            Assert.Equal("hostingservers", result.ProviderRegistration.Properties.ResourceTypes[0].Name);
            Assert.Equal("0.1.0.0", result.ProviderRegistration.Properties.ExtensionCollection.Version);
            Assert.Equal("SqlAdminExtension", result.ProviderRegistration.Properties.ExtensionCollection.Extensions[0].Name);
            Assert.Equal("https://azstack:13002/", result.ProviderRegistration.Properties.ExtensionCollection.Extensions[0].Uri);
            Assert.Equal("addSqlQuotaBlade", result.ProviderRegistration.Properties.ExtensionCollection.Extensions[0].Properties.QuotaCreateBladeName);
            Assert.Equal("addSqlServerBlade", result.ProviderRegistration.Properties.ExtensionCollection.Extensions[0].Properties.ResourceProviderDashboardBladeName);
            Assert.Equal("2014-04-01-preview", result.ProviderRegistration.Properties.ResourceTypes[0].Endpoints[0].ApiVersions[0]);
            Assert.Equal("https://azstack:30010", result.ProviderRegistration.Properties.ResourceTypes[0].Endpoints[0].EndpointUri);
            Assert.Equal(new TimeSpan(0, 0, 0), result.ProviderRegistration.Properties.ResourceTypes[0].Endpoints[0].Timeout);
            Assert.Equal(true, result.ProviderRegistration.Properties.ResourceTypes[0].Endpoints[0].Enabled);
            Assert.Equal(RoutingType.Default, result.ProviderRegistration.Properties.ResourceTypes[0].RoutingType);
            Assert.Equal(true, result.ProviderRegistration.Properties.ResourceTypes[0].InGlobalLocation);
            Assert.Equal(ResourceDeletionPolicy.NotSpecified, result.ProviderRegistration.Properties.ResourceTypes[0].ResourceDeletionPolicy);
            Assert.Equal(MarketplaceType.NotSpecified, result.ProviderRegistration.Properties.ResourceTypes[0].MarketplaceType);
            Assert.Equal(result.ProviderRegistration.Properties.Signature, "e39843e0490cf8a4c876ce0eb2e35b595cdea663");
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
