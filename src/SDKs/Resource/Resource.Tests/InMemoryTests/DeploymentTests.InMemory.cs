// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Xunit;
using Microsoft.Rest;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure.OData;

namespace ResourceGroups.Tests
{
    public class InMemoryDeploymentTests
    {
        public ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            var subscriptionId = Guid.NewGuid().ToString();
            var token = new TokenCredentials(subscriptionId, "abc123");
            handler.IsPassThrough = false;
            var client = new ResourceManagementClient(token, handler);
            client.SubscriptionId = subscriptionId;
            return client;
        }

        [Fact]
        public void DeploymentTestsCreateValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(@"{
                    'id': 'foo',
                    'name':'myrealease-3.14',
                    'properties':{
                        'provisioningState':'Succeeded',    
                        'timestamp':'2014-01-05T12:30:43.00Z',
                        'mode':'Incremental',
                        'template': { 'api-version' : '123' },
		                'templateLink': {
                           'uri': 'http://wa/template.json',
                           'contentVersion': '1.0.0.0',
                           'contentHash': {
                              'algorithm': 'sha256',
                              'value': 'yyz7xhhshfasf',
                           }
                        },
                        'parametersLink': { /* use either one of parameters or parametersLink */
                           'uri': 'http://wa/parameters.json',
                           'contentVersion': '1.0.0.0',
                           'contentHash': {
                              'algorithm': 'sha256',
                              'value': 'yyz7xhhshfasf',
                           }
                        },
                        'parameters': {
                            'key' : {
                                'type':'string',           
                                'value':'user'
                            }
		                },
                        'outputs': {
                            'key' : {
                                'type':'string',           
                                'value':'user'
                            }
                        }        
                    }
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.Created };

            var client = GetResourceManagementClient(handler);
            var dictionary = new Dictionary<string, object> {
                    {"param1", "value1"},
                    {"param2", true},
                    {"param3", new Dictionary<string, object>() {
                        {"param3_1", 123},
                        {"param3_2", "value3_2"},
                    }}
                };
            var parameters = new Deployment
            {
                Properties = new DeploymentProperties()
                {
                    Template = JObject.Parse("{'api-version':'123'}"),
                    TemplateLink = new TemplateLink
                        {
                            Uri = "http://abc/def/template.json",
                            ContentVersion = "1.0.0.0"
                        },
                    Parameters = dictionary,
                    ParametersLink = new ParametersLink
                    {
                        Uri = "http://abc/def/template.json",
                        ContentVersion = "1.0.0.0"
                    },
                    Mode = DeploymentMode.Incremental
                }
            };

            var result = client.Deployments.CreateOrUpdate("foo", "myrealease-3.14", parameters); 

            JObject json = JObject.Parse(handler.Request);

            // Validate headers 
            Assert.Equal("application/json; charset=utf-8", handler.ContentHeaders.GetValues("Content-Type").First());
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate payload
            Assert.Equal("Incremental", json["properties"]["mode"].Value<string>());
            Assert.Equal("http://abc/def/template.json", json["properties"]["templateLink"]["uri"].Value<string>());
            Assert.Equal("1.0.0.0", json["properties"]["templateLink"]["contentVersion"].Value<string>());
            Assert.Equal("1.0.0.0", json["properties"]["parametersLink"]["contentVersion"].Value<string>());
            Assert.Equal("value1", json["properties"]["parameters"]["param1"].Value<string>());
            Assert.Equal(true, json["properties"]["parameters"]["param2"].Value<bool>());
            Assert.Equal(123, json["properties"]["parameters"]["param3"]["param3_1"].Value<int>());
            Assert.Equal("value3_2", json["properties"]["parameters"]["param3"]["param3_2"].Value<string>());
            Assert.Equal(123, json["properties"]["template"]["api-version"].Value<int>());

            // Validate result
            Assert.Equal("foo", result.Id);
            Assert.Equal("myrealease-3.14", result.Name);
            Assert.Equal("Succeeded", result.Properties.ProvisioningState);
            Assert.Equal(new DateTime(2014, 1, 5, 12, 30, 43), result.Properties.Timestamp);
            Assert.Equal(DeploymentMode.Incremental, result.Properties.Mode);
            Assert.Equal("http://wa/template.json", result.Properties.TemplateLink.Uri);
            Assert.Equal("1.0.0.0", result.Properties.TemplateLink.ContentVersion);
            Assert.True(result.Properties.Parameters.ToString().Contains("\"type\": \"string\""));
            Assert.True(result.Properties.Outputs.ToString().Contains("\"type\": \"string\""));
        }

        [Fact]
        public void DeploymentTestsTemplateAsJsonString()
        {
            var responseBody = @"{
                'id': 'foo',
                'name': 'test-release-3',
                'properties': {
                    'parameters': {
                        'storageAccountName': {
				            'type': 'String',
				            'value': 'tianotest04'
			            }
		            },
		            'mode': 'Incremental',
		            'provisioningState': 'Succeeded',
		            'timestamp': '2016-07-12T17:36:39.2398177Z',
		            'duration': 'PT0.5966357S',
		            'correlationId': 'c0d728d5-5b97-41b9-b79a-abcd9eb5fe4a'
	            }
            }";

            var templateString = @"{
                '$schema': 'http://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#',
                'contentVersion': '1.0.0.0',
                'parameters': {
                    'storageAccountName': {
		                'type': 'string'
	                }
                },
                'resources': [
                ],
                'outputs': {  }
            }";

            var parametersStringFull = @"{
                '$schema': 'http://schema.management.azure.com/schemas/2015-01-01/deploymentParameters.json#',
                'contentVersion': '1.0.0.0',
                'parameters': {
                    'storageAccountName': {
		                'value': 'tianotest04'
	                }
                }
            }";

            var parametersStringsShort = @"{
                'storageAccountName': {
		            'value': 'tianotest04'
	            }
            }";

            for (int i = 0; i < 2; i++)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(responseBody)
                };

                var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.Created };

                var client = GetResourceManagementClient(handler);

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        Template = templateString,
                        Parameters = i == 0 ? parametersStringFull : parametersStringsShort,
                        Mode = DeploymentMode.Incremental
                    }
                };

                var result = client.Deployments.CreateOrUpdate("foo", "myrealease-3.14", parameters);

                JObject json = JObject.Parse(handler.Request);

                // Validate headers 
                Assert.Equal("application/json; charset=utf-8", handler.ContentHeaders.GetValues("Content-Type").First());
                Assert.Equal(HttpMethod.Put, handler.Method);
                Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

                // Validate payload
                Assert.Equal("Incremental", json["properties"]["mode"].Value<string>());
                Assert.Equal("tianotest04", json["properties"]["parameters"]["storageAccountName"]["value"].Value<string>());
                Assert.Equal("1.0.0.0", json["properties"]["template"]["contentVersion"].Value<string>());

                // Validate result
                Assert.Equal("foo", result.Id);
                Assert.Equal("test-release-3", result.Name);
                Assert.Equal("Succeeded", result.Properties.ProvisioningState);
                Assert.Equal(DeploymentMode.Incremental, result.Properties.Mode);
                Assert.True(result.Properties.Parameters.ToString().Contains("\"value\": \"tianotest04\""));
            }
        }

        [Fact]
        public void ListDeploymentOperationsReturnsMultipleObjects()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'value': [
                          {
                        'subscriptionId':'mysubid',
                        'resourceGroup': 'foo',
                        'deploymentName':'test-release-3',
                        'operationId': 'AEF2398',
                        'properties':{
                            'targetResource':{
                                'id': '/subscriptions/123abc/resourcegroups/foo/providers/ResourceProviderTestHost/TestResourceType/resource1',
                                'resourceName':'mySite1',
                                'resourceType': 'Microsoft.Web',
                            },
                            'provisioningState':'Succeeded',                 
                            'timestamp': '2014-02-25T23:08:21.8183932Z',
                            'correlationId': 'afb170c6-fe57-4b38-a43b-900fe09be4ca',
                            'statusCode': 'InternalServerError',
                            'statusMessage': 'InternalServerError',           
                          }
                       }
                    ],
                    'nextLink': 'https://wa.com/subscriptions/mysubid/resourcegroups/TestRG/deployments/test-release-3/operations?$skiptoken=983fknw'
                    }
")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(handler);

            var result = client.DeploymentOperations.List("foo", "bar", null);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate response 
            Assert.Equal(1, result.Count());
            Assert.Equal("AEF2398", result.First().OperationId);
            Assert.Equal("/subscriptions/123abc/resourcegroups/foo/providers/ResourceProviderTestHost/TestResourceType/resource1", result.First().Properties.TargetResource.Id);
            Assert.Equal("mySite1", result.First().Properties.TargetResource.ResourceName);
            Assert.Equal("Microsoft.Web", result.First().Properties.TargetResource.ResourceType);
            Assert.Equal("Succeeded", result.First().Properties.ProvisioningState);
            Assert.Equal("InternalServerError", result.First().Properties.StatusCode);
            Assert.Equal("InternalServerError", result.First().Properties.StatusMessage);
            Assert.Equal("https://wa.com/subscriptions/mysubid/resourcegroups/TestRG/deployments/test-release-3/operations?$skiptoken=983fknw", result.NextPageLink);
        }

        [Fact]
        public void ListDeploymentOperationsReturnsEmptyArray()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"{
                    'value': [],
                    'nextLink': 'https://wa.com/subscriptions/mysubid/resourcegroups/TestRG/deployments/test-release-3/operations?$skiptoken=983fknw'
                    }")
                };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(handler);

            var result = client.DeploymentOperations.List("foo", "bar", null);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate response 
            Assert.Equal(0, result.Count());
        }

        [Fact]
        public void ListDeploymentOperationsWithRealPayloadReadsJsonInStatusMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                  'value': [
                    {
                      'id': '/subscriptions/abcd1234/resourcegroups/foo/deployments/testdeploy/operations/334558C2218CAEB0',
                      'subscriptionId': 'abcd1234',
                      'resourceGroup': 'foo',
                      'deploymentName': 'testdeploy',
                      'operationId': '334558C2218CAEB0',
                      'properties': {
                        'provisioningState': 'Failed',
                        'timestamp': '2014-03-14T23:43:31.8688746Z',
                        'trackingId': '4f258f91-edd5-4d71-87c2-fac9a4b5cbbd',
                        'statusCode': 'Conflict',
                        'statusMessage': {
                          'Code': 'Conflict',
                          'Message': 'Website with given name ilygreTest4 already exists.',
                          'Target': null,
                          'Details': [
                            {
                              'Message': 'Website with given name ilygreTest4 already exists.'
                            },
                            {
                              'Code': 'Conflict'
                            },
                            {
                              'ErrorEntity': {
                                'Code': 'Conflict',
                                'Message': 'Website with given name ilygreTest4 already exists.',
                                'ExtendedCode': '54001',
                                'MessageTemplate': 'Website with given name {0} already exists.',
                                'Parameters': [
                                  'ilygreTest4'
                                ],
                                'InnerErrors': null
                              }
                            }
                          ],
                          'Innererror': null
                        },
                        'targetResource': {
                          'id':
                '/subscriptions/abcd1234/resourcegroups/foo/providers/Microsoft.Web/Sites/ilygreTest4',
                          'subscriptionId': 'abcd1234',
                          'resourceGroup': 'foo',
                          'resourceType': 'Microsoft.Web/Sites',
                          'resourceName': 'ilygreTest4'
                        }
                      }
                    },
                    {
                      'id':
                '/subscriptions/abcd1234/resourcegroups/foo/deployments/testdeploy/operations/6B9A5A38C94E6
                F14',
                      'subscriptionId': 'abcd1234',
                      'resourceGroup': 'foo',
                      'deploymentName': 'testdeploy',
                      'operationId': '6B9A5A38C94E6F14',
                      'properties': {
                        'provisioningState': 'Succeeded',
                        'timestamp': '2014-03-14T23:43:25.2101422Z',
                        'trackingId': '2ff7a8ad-abf3-47f6-8ce0-e4aae8c26065',
                        'statusCode': 'OK',
                        'statusMessage': null,
                        'targetResource': {
                          'id':
                '/subscriptions/abcd1234/resourcegroups/foo/providers/Microsoft.Web/serverFarms/ilygreTest4
                Host',
                          'subscriptionId': 'abcd1234',
                          'resourceGroup': 'foo',
                          'resourceType': 'Microsoft.Web/serverFarms',
                          'resourceName': 'ilygreTest4Host'
                        }
                      }
                    }
                  ]
                }")
            };
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(handler);

            var result = client.DeploymentOperations.List("foo", "bar", null);

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            Assert.True(JObject.Parse(result.First().Properties.StatusMessage.ToString()).HasValues);
        }

        [Fact]
        public void ListDeploymentOperationsWorksWithNextLink()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'value': [
                          {
                        'subscriptionId':'mysubid',
                        'resourceGroup': 'foo',
                        'deploymentName':'test-release-3',
                        'operationId': 'AEF2398',
                        'properties':{
                            'targetResource':{
                                'subscriptionId':'mysubid',
                                'resourceGroup': 'TestRG',
                                'resourceName':'mySite1',
                                'resourceType': 'Microsoft.Web',
                            },
                            'provisioningState':'Succeeded',
                            'timestamp': '2014-02-25T23:08:21.8183932Z',
                            'correlationId': 'afb170c6-fe57-4b38-a43b-900fe09be4ca',
                            'statusCode': 'InternalServerError',
                            'statusMessage': 'InternalServerError',    
                          }
                       }
                    ],
                    'nextLink': 'https://wa.com/subscriptions/mysubid/resourcegroups/TestRG/deployments/test-release-3/operations?$skiptoken=983fknw'
                    }
")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(handler);

            var result = client.DeploymentOperations.List("foo", "bar", null);

            response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'value': []
                    }")
            };

            handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            client = GetResourceManagementClient(handler);

            result = client.DeploymentOperations.ListNext(result.NextPageLink);

            // Validate body 
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
            Assert.Equal("https://wa.com/subscriptions/mysubid/resourcegroups/TestRG/deployments/test-release-3/operations?$skiptoken=983fknw", handler.Uri.ToString());

            // Validate response 
            Assert.Equal(0, result.Count());
            Assert.Equal(null, result.NextPageLink);
        }

        [Fact]
        public void GetDeploymentOperationsReturnsValue()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                        'subscriptionId':'mysubid',
                        'resourceGroup': 'foo',
                        'deploymentName':'test-release-3',
                        'operationId': 'AEF2398',
                        'properties':{
                            'targetResource':{
                                'id':'/subscriptions/123abc/resourcegroups/foo/providers/ResourceProviderTestHost/TestResourceType/resource1',
                                'resourceName':'mySite1',
                                'resourceType': 'Microsoft.Web',
                            },
                            'provisioningState':'Succeeded',
                            'timestamp': '2014-02-25T23:08:21.8183932Z',
                            'correlationId': 'afb170c6-fe57-4b38-a43b-900fe09be4ca',
                            'statusCode': 'OK',
                            'statusMessage': 'OK',    
                          }
                       }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(handler);

            var result = client.DeploymentOperations.Get("foo", "bar", "123");

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate response 
            Assert.Equal("AEF2398", result.OperationId);
            Assert.Equal("mySite1", result.Properties.TargetResource.ResourceName);
            Assert.Equal("/subscriptions/123abc/resourcegroups/foo/providers/ResourceProviderTestHost/TestResourceType/resource1", result.Properties.TargetResource.Id);
            Assert.Equal("Microsoft.Web", result.Properties.TargetResource.ResourceType);
            Assert.Equal("Succeeded", result.Properties.ProvisioningState);
            Assert.Equal("OK", result.Properties.StatusCode);
            Assert.Equal("OK", result.Properties.StatusMessage);
        }

        [Fact(Skip = "Parameter validation using pattern match is not supported yet at code-gen, the work is on-going.")]
        public void DeploymentTestsCreateThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);


            Assert.Throws<ArgumentNullException>(() => client.Deployments.CreateOrUpdate(null, "bar", new Deployment()));
            Assert.Throws<ArgumentNullException>(() => client.Deployments.CreateOrUpdate("foo", null, new Deployment()));
            Assert.Throws<ArgumentNullException>(() => client.Deployments.CreateOrUpdate("foo", "bar", null));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Deployments.CreateOrUpdate("~`123", "bar", new Deployment()));
        }

        [Fact]
        public void DeploymentTestsValidateCheckPayload()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(@"{
                      'error': {
                        'code': 'InvalidTemplate',
                        'message': 'Deployment template validation failed.'
                      }
                    }")
            };
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.BadRequest };

            var client = GetResourceManagementClient(handler);
            var dictionary = new Dictionary<string, object> {
                    {"param1", "value1"},
                    {"param2", true},
                    {"param3", new Dictionary<string, object>() {
                        {"param3_1", 123},
                        {"param3_2", "value3_2"},
                    }}
                };
            var parameters = new Deployment
            {
                Properties = new DeploymentProperties()
                {
                    TemplateLink = new TemplateLink
                    {
                        Uri = "http://abc/def/template.json",
                        ContentVersion = "1.0.0.0",
                    },
                    Parameters = dictionary,
                    Mode = DeploymentMode.Incremental
                }
            };

            var result = client.Deployments.Validate("foo", "bar", parameters);

            JObject json = JObject.Parse(handler.Request);

            // Validate headers
            Assert.Equal("application/json; charset=utf-8", handler.ContentHeaders.GetValues("Content-Type").First());
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate payload
            Assert.Equal("Incremental", json["properties"]["mode"].Value<string>());
            Assert.Equal("http://abc/def/template.json", json["properties"]["templateLink"]["uri"].Value<string>());
            Assert.Equal("1.0.0.0", json["properties"]["templateLink"]["contentVersion"].Value<string>());
            Assert.Equal("value1", json["properties"]["parameters"]["param1"].Value<string>());
            Assert.Equal(true, json["properties"]["parameters"]["param2"].Value<bool>());
            Assert.Equal(123, json["properties"]["parameters"]["param3"]["param3_1"].Value<int>());
            Assert.Equal("value3_2", json["properties"]["parameters"]["param3"]["param3_2"].Value<string>());
        }

        [Fact]
        public void DeploymentTestsValidateSimpleFailure()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(@"{
                      'error': {
                        'code': 'InvalidTemplate',
                        'message': 'Deployment template validation failed: The template parameters hostingPlanName, siteMode, computeMode are not valid; they are not present.'
                      }
                    }")
            };
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.BadRequest };

            var client = GetResourceManagementClient(handler);
            
            var parameters = new Deployment
            {
                Properties = new DeploymentProperties()
                {
                    TemplateLink = new TemplateLink
                    {
                        Uri = "http://abc/def/template.json",
                        ContentVersion = "1.0.0.0",
                    },
                    Mode = DeploymentMode.Incremental
                }
            };

            var result = client.Deployments.Validate("foo", "bar", parameters);

            // Validate result
            Assert.Equal("InvalidTemplate", result.Error.Code);
            Assert.Equal("Deployment template validation failed: The template parameters hostingPlanName, siteMode, computeMode are not valid; they are not present.", result.Error.Message);
            Assert.Null(result.Error.Target);
            Assert.Null(result.Error.Details);
        }

        [Fact]
        public void DeploymentTestsValidateComplexFailure()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(@"{
                      'error': {
                        'code': 'InvalidTemplate',
                        'target': '',
                        'message': 'Deployment template validation failed: The template parameters hostingPlanName, siteMode, computeMode are not valid; they are not present.',
                        'details': [
                          {
                            'code': 'Error1',
                            'message': 'Deployment template validation failed.'
                          },
                          {
                            'code': 'Error2',
                            'message': 'Deployment template validation failed.'
                          } 
                        ]
                      }
                    }")
            };
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.BadRequest };

            var client = GetResourceManagementClient(handler);
            var parameters = new Deployment
            {
                Properties = new DeploymentProperties()
                {
                    TemplateLink = new TemplateLink
                    {
                        Uri = "http://abc/def/template.json",
                        ContentVersion = "1.0.0.0",
                    },
                    Mode = DeploymentMode.Incremental
                }
            };

            var result = client.Deployments.Validate("foo", "bar", parameters);

            JObject json = JObject.Parse(handler.Request);

            // Validate result
            Assert.Equal("InvalidTemplate", result.Error.Code);
            Assert.Equal("Deployment template validation failed: The template parameters hostingPlanName, siteMode, computeMode are not valid; they are not present.", result.Error.Message);
            Assert.Equal("", result.Error.Target);
            Assert.Equal(2, result.Error.Details.Count);
            Assert.Equal("Error1", result.Error.Details[0].Code);
            Assert.Equal("Error2", result.Error.Details[1].Code);
        }

        [Fact]
        public void DeploymentTestsValidateSuccess()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(handler);

            var parameters = new Deployment
            {
                Properties = new DeploymentProperties()
                {
                    TemplateLink = new TemplateLink
                    {
                        Uri = "http://abc/def/template.json",
                        ContentVersion = "1.0.0.0",
                    },
                    Mode = DeploymentMode.Incremental
                }
            };

            var result = client.Deployments.Validate("foo", "bar", parameters);

            JObject json = JObject.Parse(handler.Request);

            // Validate headers
            Assert.Equal("application/json; charset=utf-8", handler.ContentHeaders.GetValues("Content-Type").First());
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Null(result);
        }

        [Fact(Skip = "Parameter validation using pattern match is not supported yet at code-gen, the work is on-going.")]
        public void DeploymentTestsValidateThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Deployments.Validate(null, "bar", new Deployment()));
            Assert.Throws<ArgumentNullException>(() => client.Deployments.Validate("foo", "bar", null));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Deployments.Validate("~`123", "bar", new Deployment()));
        }

        [Fact]
        public void DeploymentTestsCancelValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.NoContent) { Content = new StringContent("") };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.NoContent,
            };

            var client = GetResourceManagementClient(handler);

            client.Deployments.Cancel("foo", "bar");
        }

        [Fact]
        public void DeploymentTestsCancelThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);


            Assert.Throws<Microsoft.Rest.ValidationException>(() => client.Deployments.Cancel(null, "bar"));
            Assert.Throws<Microsoft.Rest.ValidationException>(() => client.Deployments.Cancel("foo", null));
        }

        [Fact]
        public void DeploymentTestsGetValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'resourceGroup': 'foo',
                    'name':'myrealease-3.14',
                    'properties':{
                        'provisioningState':'Succeeded',    
                        'timestamp':'2014-01-05T12:30:43.00Z',
                        'mode':'Incremental',
                        'correlationId':'12345',
		                'templateLink': {
                           'uri': 'http://wa/template.json',
                           'contentVersion': '1.0.0.0',
                           'contentHash': {
                              'algorithm': 'sha256',
                              'value': 'yyz7xhhshfasf',
                           }
                        },
                        'parametersLink': { /* use either one of parameters or parametersLink */
                           'uri': 'http://wa/parameters.json',
                           'contentVersion': '1.0.0.0',
                           'contentHash': {
                              'algorithm': 'sha256',
                              'value': 'yyz7xhhshfasf',
                           }
                        },
                        'parameters': {
                            'key' : {
                                'type':'string',           
                                'value':'user'
                            }
		                },
                        'outputs': {
                            'key' : {
                                'type':'string',           
                                'value':'user'
                            }
                        }        
                    }
                }")
            };
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(handler);

            var result = client.Deployments.Get("foo", "bar");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("myrealease-3.14", result.Name);
            Assert.Equal("Succeeded", result.Properties.ProvisioningState);
            Assert.Equal("12345", result.Properties.CorrelationId);
            Assert.Equal(new DateTime(2014, 1, 5, 12, 30, 43), result.Properties.Timestamp);
            Assert.Equal(DeploymentMode.Incremental, result.Properties.Mode);
            Assert.Equal("http://wa/template.json", result.Properties.TemplateLink.Uri.ToString());
            Assert.Equal("1.0.0.0", result.Properties.TemplateLink.ContentVersion);
            Assert.True(result.Properties.Parameters.ToString().Contains("\"type\": \"string\""));
            Assert.True(result.Properties.Outputs.ToString().Contains("\"type\": \"string\""));
        }

        [Fact(Skip = "Parameter validation using pattern match is not supported yet at code-gen, the work is on-going.")]
        public void DeploymentGetValidateThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Deployments.Get(null, "bar"));
            Assert.Throws<ArgumentNullException>(() => client.Deployments.Get("foo", null));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Deployments.Get("~`123", "bar"));
        }

        [Fact]
        public void DeploymentTestsListAllValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{ 
                    'value' : [
                        {
                        'resourceGroup': 'foo',
                        'name':'myrealease-3.14',
                        'properties':{
                            'provisioningState':'Succeeded',    
                            'timestamp':'2014-01-05T12:30:43.00Z',
                            'mode':'Incremental',
		                    'templateLink': {
                               'uri': 'http://wa/template.json',
                               'contentVersion': '1.0.0.0',
                               'contentHash': {
                                  'algorithm': 'sha256',
                                  'value': 'yyz7xhhshfasf',
                               }
                            },
                            'parametersLink': { /* use either one of parameters or parametersLink */
                               'uri': 'http://wa/parameters.json',
                               'contentVersion': '1.0.0.0',
                               'contentHash': {
                                  'algorithm': 'sha256',
                                  'value': 'yyz7xhhshfasf',
                               }
                            },
                            'parameters': {
                                'key' : {
                                    'type':'string',           
                                    'value':'user'
                                }
		                    },
                            'outputs': {
                                'key' : {
                                    'type':'string',           
                                    'value':'user'
                                }
                            }     
                          }   
                        },
                        {
                        'resourceGroup': 'bar',
                        'name':'myrealease-3.14',
                        'properties':{
                            'provisioningState':'Succeeded',    
                            'timestamp':'2014-01-05T12:30:43.00Z',
                            'mode':'Incremental',
		                    'templateLink': {
                               'uri': 'http://wa/template.json',
                               'contentVersion': '1.0.0.0',
                               'contentHash': {
                                  'algorithm': 'sha256',
                                  'value': 'yyz7xhhshfasf',
                               }
                            },
                            'parametersLink': { /* use either one of parameters or parametersLink */
                               'uri': 'http://wa/parameters.json',
                               'contentVersion': '1.0.0.0',
                               'contentHash': {
                                  'algorithm': 'sha256',
                                  'value': 'yyz7xhhshfasf',
                               }
                            },
                            'parameters': {
                                'key' : {
                                    'type':'string',           
                                    'value':'user'
                                }
		                    },
                            'outputs': {
                                'key' : {
                                    'type':'string',           
                                    'value':'user'
                                }
                            }        
                        }
                      }
                    ],
                    'nextLink': 'https://wa/subscriptions/subId/templateDeployments?$skiptoken=983fknw' 
                }")
            };
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(handler);

            var result = client.Deployments.ListByResourceGroup("foo");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("myrealease-3.14", result.First().Name);
            Assert.Equal("Succeeded", result.First().Properties.ProvisioningState);
            Assert.Equal(new DateTime(2014, 1, 5, 12, 30, 43), result.First().Properties.Timestamp);
            Assert.Equal(DeploymentMode.Incremental, result.First().Properties.Mode);
            Assert.Equal("http://wa/template.json", result.First().Properties.TemplateLink.Uri.ToString());
            Assert.Equal("1.0.0.0", result.First().Properties.TemplateLink.ContentVersion);
            Assert.True(result.First().Properties.Parameters.ToString().Contains("\"type\": \"string\""));
            Assert.True(result.First().Properties.Outputs.ToString().Contains("\"type\": \"string\""));
            Assert.Equal("https://wa/subscriptions/subId/templateDeployments?$skiptoken=983fknw", result.NextPageLink);
        }

        [Fact]
        public void DeploymentTestsListValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{ 
                    'value' : [
                        {
                        'resourceGroup': 'foo',
                        'name':'myrealease-3.14',
                        'properties':{
                            'provisioningState':'Succeeded',    
                            'timestamp':'2014-01-05T12:30:43.00Z',
                            'mode':'Incremental',
		                    'templateLink': {
                               'uri': 'http://wa/template.json',
                               'contentVersion': '1.0.0.0',
                               'contentHash': {
                                  'algorithm': 'sha256',
                                  'value': 'yyz7xhhshfasf',
                               }
                            },
                            'parametersLink': { /* use either one of parameters or parametersLink */
                               'uri': 'http://wa/parameters.json',
                               'contentVersion': '1.0.0.0',
                               'contentHash': {
                                  'algorithm': 'sha256',
                                  'value': 'yyz7xhhshfasf',
                               }
                            },
                            'parameters': {
                                'key' : {
                                    'type':'string',           
                                    'value':'user'
                                }
		                    },
                            'outputs': {
                                'key' : {
                                    'type':'string',           
                                    'value':'user'
                                }
                            }     
                          }   
                        },
                        {
                        'resourceGroup': 'bar',
                        'name':'myrealease-3.14',
                        'properties':{
                            'provisioningState':'Succeeded',    
                            'timestamp':'2014-01-05T12:30:43.00Z',
                            'mode':'Incremental',
		                    'templateLink': {
                               'uri': 'http://wa/template.json',
                               'contentVersion': '1.0.0.0',
                               'contentHash': {
                                  'algorithm': 'sha256',
                                  'value': 'yyz7xhhshfasf',
                               }
                            },
                            'parametersLink': { /* use either one of parameters or parametersLink */
                               'uri': 'http://wa/parameters.json',
                               'contentVersion': '1.0.0.0',
                               'contentHash': {
                                  'algorithm': 'sha256',
                                  'value': 'yyz7xhhshfasf',
                               }
                            },
                            'parameters': {
                                'key' : {
                                    'type':'string',           
                                    'value':'user'
                                }
		                    },
                            'outputs': {
                                'key' : {
                                    'type':'string',           
                                    'value':'user'
                                }
                            }        
                        }
                      }
                    ],
                    'nextLink': 'https://wa/subscriptions/subId/templateDeployments?$skiptoken=983fknw' 
                }")
            };
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(handler);

            var result = client.Deployments.ListByResourceGroup("foo", new ODataQuery<DeploymentExtendedFilter>(d => d.ProvisioningState == "Succeeded") { Top = 10 });

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
            Assert.True(handler.Uri.ToString().Contains("$top=10"));
            Assert.True(handler.Uri.ToString().Contains("$filter=provisioningState eq 'Succeeded'"));

            // Validate result
            Assert.Equal("myrealease-3.14", result.First().Name);
            Assert.Equal("Succeeded", result.First().Properties.ProvisioningState);
            Assert.Equal(new DateTime(2014, 1, 5, 12, 30, 43), result.First().Properties.Timestamp);
            Assert.Equal(DeploymentMode.Incremental, result.First().Properties.Mode);
            Assert.Equal("http://wa/template.json", result.First().Properties.TemplateLink.Uri.ToString());
            Assert.Equal("1.0.0.0", result.First().Properties.TemplateLink.ContentVersion);
            Assert.True(result.First().Properties.Parameters.ToString().Contains("\"type\": \"string\""));
            Assert.True(result.First().Properties.Outputs.ToString().Contains("\"type\": \"string\""));
            Assert.Equal("https://wa/subscriptions/subId/templateDeployments?$skiptoken=983fknw", result.NextPageLink);
        }

        // TODO: Fix
        [Fact]
        public void DeploymentTestsListForGroupValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{ 
                    'value' : [
                        {
                        'resourceGroup': 'foo',
                        'name':'myrealease-3.14',
                        'properties':{
                            'provisioningState':'Succeeded',    
                            'timestamp':'2014-01-05T12:30:43.00Z',
                            'mode':'Incremental',
		                    'templateLink': {
                               'uri': 'http://wa/template.json',
                               'contentVersion': '1.0.0.0',
                               'contentHash': {
                                  'algorithm': 'sha256',
                                  'value': 'yyz7xhhshfasf',
                               }
                            },
                            'parametersLink': { /* use either one of parameters or parametersLink */
                               'uri': 'http://wa/parameters.json',
                               'contentVersion': '1.0.0.0',
                               'contentHash': {
                                  'algorithm': 'sha256',
                                  'value': 'yyz7xhhshfasf',
                               }
                            },
                            'parameters': {
                                'key' : {
                                    'type':'string',           
                                    'value':'user'
                                }
		                    },
                            'outputs': {
                                'key' : {
                                    'type':'string',           
                                    'value':'user'
                                }
                            }     
                          }   
                        },
                        {
                        'resourceGroup': 'bar',
                        'name':'myrealease-3.14',
                        'properties':{
                            'provisioningState':'Succeeded',    
                            'timestamp':'2014-01-05T12:30:43.00Z',
                            'mode':'Incremental',
		                    'templateLink': {
                               'uri': 'http://wa/template.json',
                               'contentVersion': '1.0.0.0',
                               'contentHash': {
                                  'algorithm': 'sha256',
                                  'value': 'yyz7xhhshfasf',
                               }
                            },
                            'parametersLink': { /* use either one of parameters or parametersLink */
                               'uri': 'http://wa/parameters.json',
                               'contentVersion': '1.0.0.0',
                               'contentHash': {
                                  'algorithm': 'sha256',
                                  'value': 'yyz7xhhshfasf',
                               }
                            },
                            'parameters': {
                                'key' : {
                                    'type':'string',           
                                    'value':'user'
                                }
		                    },
                            'outputs': {
                                'key' : {
                                    'type':'string',           
                                    'value':'user'
                                }
                            }        
                        }
                      }
                    ],
                    'nextLink': 'https://wa/subscriptions/subId/templateDeployments?$skiptoken=983fknw' 
                }")
            };
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(handler);

            var result = client.Deployments.ListByResourceGroup("foo", new ODataQuery<DeploymentExtendedFilter>(d => d.ProvisioningState == "Succeeded") { Top = 10 });

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
            Assert.True(handler.Uri.ToString().Contains("$top=10"));
            Assert.True(handler.Uri.ToString().Contains("$filter=provisioningState eq 'Succeeded'"));
            Assert.True(handler.Uri.ToString().Contains("resourcegroups/foo/providers/Microsoft.Resources/deployments"));

            // Validate result
            Assert.Equal("myrealease-3.14", result.First().Name);
            Assert.Equal("Succeeded", result.First().Properties.ProvisioningState);
            Assert.Equal(new DateTime(2014, 1, 5, 12, 30, 43), result.First().Properties.Timestamp);
            Assert.Equal(DeploymentMode.Incremental, result.First().Properties.Mode);
            Assert.Equal("http://wa/template.json", result.First().Properties.TemplateLink.Uri.ToString());
            Assert.Equal("1.0.0.0", result.First().Properties.TemplateLink.ContentVersion);
            Assert.True(result.First().Properties.Parameters.ToString().Contains("\"type\": \"string\""));
            Assert.True(result.First().Properties.Outputs.ToString().Contains("\"type\": \"string\""));
            Assert.Equal("https://wa/subscriptions/subId/templateDeployments?$skiptoken=983fknw", result.NextPageLink);
        }

        [Fact]
        public void DeploymentTestListDoesNotThrowExceptions()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{'value' : []}")
                };
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Deployments.ListByResourceGroup("foo");
            Assert.Empty(result);
        }
    }
}
