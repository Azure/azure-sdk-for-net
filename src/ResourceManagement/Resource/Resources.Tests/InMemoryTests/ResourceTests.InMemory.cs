//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Xunit;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;
using Microsoft.Azure.Management.Resources.Models;

namespace ResourceGroups.Tests
{
    public class InMemoryResourceTests
    {
        public ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "abc123");
            handler.IsPassThrough = false;
            return new ResourceManagementClient(token).WithHandler(handler);
        }
        
        [Fact]
        public void ResourceGetValidateMessage()
        { 
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                  'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1',
                  'name': 'site1',
                  'location': 'South Central US',
                   'properties': {
                        'name':'site1',
	                    'siteMode': 'Standard',
                        'computeMode':'Dedicated',
                        'provisioningState':'Running'
                    }
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.Get("foo", new ResourceIdentity
                {
                    ResourceName = "site1",
                    ResourceProviderNamespace = "Microsoft.Web",
                    ResourceProviderApiVersion = "2014-01-04",
                    ResourceType = "Sites"
                });

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("South Central US", result.Resource.Location);
            Assert.Equal("site1", result.Resource.Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.Resource.Id);
            Assert.True(result.Resource.Properties.Contains("Dedicated"));
            Assert.Equal("Running", result.Resource.ProvisioningState);
        }

        [Fact]
        public void ResourceGetWorksWithoutProvisioningState()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                  'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1',
                  'name': 'site1',
                  'location': 'South Central US',
                   'properties': {
                        'name':'site1',
	                    'siteMode': 'Standard',
                        'computeMode':'Dedicated'
                    }
                }")
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.Get("foo", new ResourceIdentity
            {
                ResourceName = "site1",
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceProviderApiVersion = "2014-01-04",
                ResourceType = "Sites"
            });

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("South Central US", result.Resource.Location);
            Assert.Equal("site1", result.Resource.Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.Resource.Id);
            Assert.True(result.Resource.Properties.Contains("Dedicated"));
            Assert.Null(result.Resource.ProvisioningState);
        }

        [Fact]
        public void ResourceListValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{ 'value' : [
                    {
                      'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1',
                      'name': 'site1',
                      'resourceGroup': 'foo',
                      'location': 'South Central US',
                      'properties': 
                       { 
                          'name':'site1',
	                      'siteMode': 'Standard',
                          'computeMode':'Dedicated',
                          'provisioningState':'Running'
                       }
                    },
                    {
                      'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1',
                      'name': 'site1',
                      'resourceGroup': 'foo',
                      'location': 'South Central US',
                      'properties': 
                       { 
                          'name':'site1',
	                      'siteMode': 'Standard',
                          'computeMode':'Dedicated'
                       }
                    }], 
                    'nextLink': 'https://wa.com/subscriptions/subId/resources?$skiptoken=983fknw'}")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.List(new ResourceListParameters
            {              
                ResourceType = "Sites"
            });

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(2, result.Resources.Count());
            Assert.Equal("South Central US", result.Resources[0].Location);
            Assert.Equal("site1", result.Resources[0].Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.Resources[0].Id);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.Resources[0].Id);
            Assert.True(result.Resources[0].Properties.Contains("Dedicated"));
            Assert.Equal("Running", result.Resources[0].ProvisioningState);
        }

        [Fact]
        public void ResourceListForResourceGroupValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{ 'value' : [
                    {
                      'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1',
                      'name': 'site1',
                      'resourceGroup': 'foo',
                      'location': 'South Central US'
                    },
                    {
                      'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1',
                      'name': 'site1',
                      'resourceGroup': 'foo',
                      'location': 'South Central US'
                    }], 
                    'nextLink': 'https://wa.com/subscriptions/subId/resources?$skiptoken=983fknw'}")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.List(new ResourceListParameters
            {
                ResourceGroupName = "foo",
                ResourceType = "Sites"
            });

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(2, result.Resources.Count());
            Assert.Equal("South Central US", result.Resources[0].Location);
            Assert.Equal("site1", result.Resources[0].Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.Resources[0].Id);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.Resources[0].Id);
            Assert.Null(result.Resources[0].Properties);
        }

        [Fact]
        public void ResourceGetThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);


            Assert.Throws<ArgumentNullException>(() => client.Resources.Get(null, null));
            Assert.Throws<ArgumentNullException>(() => client.Resources.Get("foo", new ResourceIdentity()));
            Assert.Throws<ArgumentNullException>(() => client.Resources.Get("foo", new ResourceIdentity
            {
                ResourceName = null,
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceType = "Sites"
            }));
            Assert.Throws<ArgumentNullException>(() => client.Resources.Get("foo", new ResourceIdentity
            {
                ResourceName = "site1",
                ResourceProviderNamespace = null,
                ResourceType = "Sites"
            }));
            Assert.Throws<ArgumentNullException>(() => client.Resources.Get("foo", new ResourceIdentity
            {
                ResourceName = "site1",
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceType = null
            }));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Resources.Get("~`123", new ResourceIdentity()));
        }

        [Fact]
        public void ResourceCreateOrUpdateValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'location': 'South Central US',
                    'tags' : {
                        'department':'finance',
                        'tagname':'tagvalue'
                    },
                    'properties': {
                        'name':'site3',
	                    'siteMode': 'Standard',
                        'computeMode':'Dedicated',
                        'provisioningState':'Running'
                    }
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.CreateOrUpdate("foo", new ResourceIdentity
                {
                    ResourceName = "site3",
                    ResourceProviderNamespace = "Microsoft.Web",
                    ResourceProviderApiVersion = "2014-01-04",
                    ResourceType = "sites",
                }, 
                new GenericResource
                {
                    Location = "South Central US",
                    Tags = new Dictionary<string, string>() { { "department", "finance" }, { "tagname", "tagvalue" } },
                    Properties = @"{
                        'name':'site3',
	                    'siteMode': 'Standard',
                        'computeMode':'Dedicated'
                    }"
                }
            );

            JObject json = JObject.Parse(handler.Request);

            // Validate headers
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate payload
            Assert.Equal("South Central US", json["location"].Value<string>());
            Assert.Equal("finance", json["tags"]["department"].Value<string>());
            Assert.Equal("tagvalue", json["tags"]["tagname"].Value<string>());

            // Validate result
            Assert.Equal("South Central US", result.Resource.Location);
            Assert.Equal("Running", result.Resource.ProvisioningState);
            Assert.Equal("finance", result.Resource.Tags["department"]);
            Assert.Equal("tagvalue", result.Resource.Tags["tagname"]);
            Assert.True(result.Resource.Properties.Contains("Dedicated"));
        }

        [Fact]
        public void ResourceCreateForWebsiteValidatePayload()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{'location':'South Central US','tags':null,'properties':{'name':'csmr14v5efk0','state':'Running','hostNames':['csmr14v5efk0.antares-int.windows-int.net'],'webSpace':'csmrgqinwpwky-SouthCentralUSwebspace','selfLink':'https://antpreview1.api.admin-antares-int.windows-int.net:454/20130801/websystems/websites/web/subscriptions/abc123/webspaces/csmrgqinwpwky-SouthCentralUSwebspace/sites/csmr14v5efk0','repositorySiteName':'csmr14v5efk0','owner':null,'usageState':0,'enabled':true,'adminEnabled':true,'enabledHostNames':['csmr14v5efk0.antares-int.windows-int.net','csmr14v5efk0.scm.antares-int.windows-int.net'],'siteProperties':{'metadata':null,'properties':[],'appSettings':null},'availabilityState':0,'sslCertificates':[],'csrs':[],'cers':null,'siteMode':'Standard','hostNameSslStates':[{'name':'csmr14v5efk0.antares-int.windows-int.net','sslState':0,'ipBasedSslResult':null,'virtualIP':null,'thumbprint':null,'toUpdate':null,'toUpdateIpBasedSsl':null,'ipBasedSslState':0},{'name':'csmr14v5efk0.scm.antares-int.windows-int.net','sslState':0,'ipBasedSslResult':null,'virtualIP':null,'thumbprint':null,'toUpdate':null,'toUpdateIpBasedSsl':null,'ipBasedSslState':0}],'computeMode':1,'serverFarm':'DefaultServerFarm1','lastModifiedTimeUtc':'2014-02-21T00:49:30.477','storageRecoveryDefaultState':'Running','contentAvailabilityState':0,'runtimeAvailabilityState':0,'siteConfig':null,'deploymentId':'csmr14v5efk0','trafficManagerHostNames':[]}}")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.CreateOrUpdate("foo", new ResourceIdentity
                {
                    ResourceName = "csmr14v5efk0",
                    ResourceProviderNamespace = "Microsoft.Web",
                    ResourceProviderApiVersion = "2014-01-04",
                    ResourceType = "sites",
                }, 
                new GenericResource
                    {
                        Location = "South Central US",
                        Properties = @"{
                            'name':'csmr14v5efk0',
	                        'siteMode': 'Standard',
                            'computeMode':'Dedicated'
                        }"
                    }
                );

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("South Central US", result.Resource.Location);
        }

        [Fact]
        public void ResourceGetCreateOrUpdateDeleteAndExistsThrowExceptionWithoutApiVersion()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var identity = new ResourceIdentity
                {
                    ResourceName = "site3",
                    ResourceProviderNamespace = "Microsoft.Web",
                    ResourceProviderApiVersion = null,
                    ResourceType = "sites",
                };

            var resource = new GenericResource
                {
                    Location = "South Central US",
                    Properties = @"{
                                'name':'site3',
	                            'siteMode': 'Standard',
                                'computeMode':'Dedicated'
                            }"
                };


            Assert.Throws<ArgumentNullException>(() => client.Resources.Get("foo",
                identity));
            Assert.Throws<ArgumentNullException>(() => client.Resources.CheckExistence("foo",
                identity));
            Assert.Throws<ArgumentNullException>(() => client.Resources.CreateOrUpdate("foo",
                identity, resource ));
            Assert.Throws<ArgumentNullException>(() => client.Resources.Delete("foo",
                identity));
        }

        [Fact]
        public void ResourceCreateOrUpdateThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);


            Assert.Throws<ArgumentNullException>(() => client.Resources.CreateOrUpdate(null, null, null));
            Assert.Throws<ArgumentNullException>(() => client.Resources.CreateOrUpdate("foo", new ResourceIdentity(), new GenericResource()));
            Assert.Throws<ArgumentNullException>(() => client.Resources.CreateOrUpdate("foo", new ResourceIdentity
            {
                ResourceName = null,
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceType = "sites",
            }, new GenericResource
                {
                    Location = "",
                }
            ));
            Assert.Throws<ArgumentNullException>(() => client.Resources.CreateOrUpdate("foo", new ResourceIdentity
            {
                ResourceName = "site1",
                ResourceProviderNamespace = null,
                ResourceType = "sites",
            }, new GenericResource
                {
                    Location = "",
                }
            ));
            Assert.Throws<ArgumentNullException>(() => client.Resources.CreateOrUpdate("foo", new ResourceIdentity
            {
                ResourceName = "site1",
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceType = null,
            }, new GenericResource
                    {
                        Location = "",
                    }
            ));
            Assert.Throws<ArgumentNullException>(() => client.Resources.CreateOrUpdate("foo", new ResourceIdentity
            {
                ResourceName = "site1",
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceType = "sites",
            }, null));
            Assert.Throws<ArgumentNullException>(() => client.Resources.CreateOrUpdate("foo", new ResourceIdentity
            {
                ResourceName = "site1",
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceType = "sites",
            }, new GenericResource
                {
                    Location = null,
                }
            ));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Resources.CreateOrUpdate("~123", new ResourceIdentity
            {
                ResourceName = "site1",
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceType = "sites",
            }, new GenericResource
                {
                    Location = "",
                    Properties = "",
                }
            ));
        }

        [Fact]
        public void ResourceExistsValidateOkMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.CheckExistence("foo", new ResourceIdentity
            {
                ResourceName = "site3",
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceProviderApiVersion = "2014-01-04",
                ResourceType = "sites"
            });

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(true, result.Exists);
        }

        [Fact]
        public void ResourceExistsValidateMissingMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound);
            response.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.NotFound };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.CheckExistence("foo", new ResourceIdentity
            {
                ResourceName = Guid.NewGuid().ToString(),
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceProviderApiVersion = "2014-01-04",
                ResourceType = "sites"
            });

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(false, result.Exists);
        }

        [Fact]
        public void UriSupportsBaseUriWithPathTest()
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound);
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.NotFound };
            handler.IsPassThrough = false;
            var randomValue = Guid.NewGuid().ToString();
            var token = new TokenCloudCredentials(randomValue, "abc123");
            var client = new ResourceManagementClient(token, new Uri("https://localhost:123/test/")).WithHandler(handler);
            client.Resources.CheckExistence("foo", new ResourceIdentity
            {
                ResourceName = randomValue,
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceProviderApiVersion = "2014-01-04",
                ResourceType = "sites"
            });
            // Validate headers
            Assert.Equal("https://localhost:123/test/subscriptions/" + randomValue + "/resourcegroups/foo/providers/Microsoft.Web//sites/" + randomValue + "?api-version=2014-01-04", handler.Uri.AbsoluteUri);
        }

        [Fact]
        public void ResourceDeleteValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.Delete("foo", new ResourceIdentity
            {
                ResourceName = "site3",
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceProviderApiVersion = "2014-01-04",
                ResourceType = "sites",
            });

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void ResourceDeleteSupportNoContentReturnCode()
        {
            var response = new HttpResponseMessage(HttpStatusCode.NoContent);

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.NoContent };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.Delete("foo", new ResourceIdentity
            {
                ResourceName = "site3",
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceProviderApiVersion = "2014-01-04",
                ResourceType = "sites",
            });
        }

        [Fact]
        public void ResourceDeleteThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);


            Assert.Throws<ArgumentNullException>(() => client.Resources.Delete("foo", null));
            Assert.Throws<ArgumentNullException>(() => client.Resources.Delete(null, new ResourceIdentity()));
            Assert.Throws<ArgumentNullException>(() => client.Resources.Delete("foo", new ResourceIdentity()));
            Assert.Throws<ArgumentNullException>(() => client.Resources.Delete("foo", new ResourceIdentity
            {
                ResourceName = null,
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceType = "Sites",
            }));
            Assert.Throws<ArgumentNullException>(() => client.Resources.Delete("foo", new ResourceIdentity
            {
                ResourceName = "site1",
                ResourceProviderNamespace = null,
                ResourceType = "Sites",
            }));
            Assert.Throws<ArgumentNullException>(() => client.Resources.Delete("foo", new ResourceIdentity
            {
                ResourceName = "site1",
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceType = null,
            }));
        }

        [Fact]
        public void ResourcesMoveTest()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
            };
            response.Headers.Add("x-ms-request-id", "1");
            response.Headers.Add("Location", "http://foo");

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.Accepted,
                SubsequentStatusCodeToReturn = HttpStatusCode.NoContent
            };
           
            var client = GetResourceManagementClient(handler);

            var resourceToMove = new ResourcesMoveInfo();
            resourceToMove.TargetResourceGroup = "/subscriptions/" + Uri.EscapeDataString(client.Credentials.SubscriptionId) + "/resourceGroups/resourceGroup1";

            var resource1 = "/subscriptions/" + Uri.EscapeDataString(client.Credentials.SubscriptionId) + "/resourceGroups/resourceGroup0/providers/Microsoft.Web/website/website1";
            resourceToMove.Resources.Add(resource1);

            var resource2 = "/subscriptions/" + Uri.EscapeDataString(client.Credentials.SubscriptionId) + "/resourceGroups/resourceGroup0/providers/Microsoft.Compute/hostservice/vm1";
            resourceToMove.Resources.Add(resource2);

            var moveResult = client.Resources.MoveResources("resourceGroup0", resourceToMove);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Valid response
            Assert.Equal(moveResult.StatusCode, HttpStatusCode.NoContent);
           
           
        }
    }
}
