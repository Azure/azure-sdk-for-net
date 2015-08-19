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
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Xunit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;
using Microsoft.Azure.Management.Resources.Models;
using System.Runtime.Serialization.Formatters;

namespace ResourceGroups.Tests
{
    public class InMemoryDeploymentTests
    {
        public ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "abc123");
            handler.IsPassThrough = false;
            return new ResourceManagementClient(token).WithHandler(handler);
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
            var serializedDictionary = JsonConvert.SerializeObject(dictionary, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None,
                Formatting = Formatting.Indented
            });
            var parameters = new Deployment
            {
                Properties = new DeploymentProperties()
                {
                    Template = "{'api-version':'123'}",
                    TemplateLink = new TemplateLink
                        {
                            Uri = new Uri("http://abc/def/template.json"),
                            ContentVersion = "1.0.0.0"
                        },
                    Parameters = serializedDictionary,
                    ParametersLink = new ParametersLink
                    {
                        Uri = new Uri("http://abc/def/template.json"),
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
            Assert.Equal("foo", result.Deployment.Id);
            Assert.Equal("myrealease-3.14", result.Deployment.Name);
            Assert.Equal("Succeeded", result.Deployment.Properties.ProvisioningState);
            Assert.Equal(new DateTime(2014, 1, 5, 12, 30, 43), result.Deployment.Properties.Timestamp);
            Assert.Equal(DeploymentMode.Incremental, result.Deployment.Properties.Mode);
            Assert.Equal("http://wa/template.json", result.Deployment.Properties.TemplateLink.Uri.ToString());
            Assert.Equal("1.0.0.0", result.Deployment.Properties.TemplateLink.ContentVersion);
            Assert.True(result.Deployment.Properties.Parameters.Contains("\"type\": \"string\""));
            Assert.True(result.Deployment.Properties.Outputs.Contains("\"type\": \"string\""));
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
            Assert.Equal(1, result.Operations.Count);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("AEF2398", result.Operations[0].OperationId);
            Assert.Equal("/subscriptions/123abc/resourcegroups/foo/providers/ResourceProviderTestHost/TestResourceType/resource1", result.Operations[0].Properties.TargetResource.Id);
            Assert.Equal("mySite1", result.Operations[0].Properties.TargetResource.ResourceName);
            Assert.Equal("Microsoft.Web", result.Operations[0].Properties.TargetResource.ResourceType);
            Assert.Equal("Succeeded", result.Operations[0].Properties.ProvisioningState);
            Assert.Equal("InternalServerError", result.Operations[0].Properties.StatusCode);
            Assert.Equal("\"InternalServerError\"", result.Operations[0].Properties.StatusMessage);
            Assert.Equal("https://wa.com/subscriptions/mysubid/resourcegroups/TestRG/deployments/test-release-3/operations?$skiptoken=983fknw", result.NextLink.ToString());
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
            Assert.Equal(0, result.Operations.Count);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
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

            Assert.True(JObject.Parse(result.Operations[0].Properties.StatusMessage).HasValues);
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

            result = client.DeploymentOperations.ListNext(result.NextLink);

            // Validate body 
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
            Assert.Equal("https://wa.com/subscriptions/mysubid/resourcegroups/TestRG/deployments/test-release-3/operations?$skiptoken=983fknw", handler.Uri.ToString());

            // Validate response 
            Assert.Equal(0, result.Operations.Count);
            Assert.Equal(null, result.NextLink);
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
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("AEF2398", result.Operation.OperationId);
            Assert.Equal("mySite1", result.Operation.Properties.TargetResource.ResourceName);
            Assert.Equal("/subscriptions/123abc/resourcegroups/foo/providers/ResourceProviderTestHost/TestResourceType/resource1", result.Operation.Properties.TargetResource.Id);
            Assert.Equal("Microsoft.Web", result.Operation.Properties.TargetResource.ResourceType);
            Assert.Equal("Succeeded", result.Operation.Properties.ProvisioningState);
            Assert.Equal("OK", result.Operation.Properties.StatusCode);
            Assert.Equal("\"OK\"", result.Operation.Properties.StatusMessage);
        }

        [Fact]
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
            var serializedDictionary = JsonConvert.SerializeObject(dictionary, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });
            var parameters = new Deployment
            {
                Properties = new DeploymentProperties()
                {
                    TemplateLink = new TemplateLink
                    {
                        Uri = new Uri("http://abc/def/template.json"),
                        ContentVersion = "1.0.0.0",
                    },
                    Parameters = serializedDictionary,
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
                        Uri = new Uri("http://abc/def/template.json"),
                        ContentVersion = "1.0.0.0",
                    },
                    Mode = DeploymentMode.Incremental
                }
            };

            var result = client.Deployments.Validate("foo", "bar", parameters);

            // Validate result
            Assert.False(result.IsValid);
            Assert.Equal("InvalidTemplate", result.Error.Code);
            Assert.Equal("Deployment template validation failed: The template parameters hostingPlanName, siteMode, computeMode are not valid; they are not present.", result.Error.Message);
            Assert.Null(result.Error.Target);
            Assert.Equal(0, result.Error.Details.Count);
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
                        Uri = new Uri("http://abc/def/template.json"),
                        ContentVersion = "1.0.0.0",
                    },
                    Mode = DeploymentMode.Incremental
                }
            };

            var result = client.Deployments.Validate("foo", "bar", parameters);

            JObject json = JObject.Parse(handler.Request);

            // Validate result
            Assert.False(result.IsValid);
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
                        Uri = new Uri("http://abc/def/template.json"),
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
            Assert.True(result.IsValid);
            Assert.Null(result.Error);
        }

        [Fact]
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
            var response = new HttpResponseMessage(HttpStatusCode.NoContent);

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.NoContent,
            };

            var client = GetResourceManagementClient(handler);

            var result = client.Deployments.Cancel("foo", "bar");

            // Validate headers
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        [Fact]
        public void DeploymentTestsCancelThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);


            Assert.Throws<ArgumentNullException>(() => client.Deployments.Cancel(null, "bar"));
            Assert.Throws<ArgumentNullException>(() => client.Deployments.Cancel("foo", null));
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
            Assert.Equal("myrealease-3.14", result.Deployment.Name);
            Assert.Equal("Succeeded", result.Deployment.Properties.ProvisioningState);
            Assert.Equal("12345", result.Deployment.Properties.CorrelationId);
            Assert.Equal(new DateTime(2014, 1, 5, 12, 30, 43), result.Deployment.Properties.Timestamp);
            Assert.Equal(DeploymentMode.Incremental, result.Deployment.Properties.Mode);
            Assert.Equal("http://wa/template.json", result.Deployment.Properties.TemplateLink.Uri.ToString());
            Assert.Equal("1.0.0.0", result.Deployment.Properties.TemplateLink.ContentVersion);
            Assert.True(result.Deployment.Properties.Parameters.Contains("\"type\": \"string\""));
            Assert.True(result.Deployment.Properties.Outputs.Contains("\"type\": \"string\""));
        }

        [Fact]
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

            var result = client.Deployments.List("foo", new DeploymentListParameters());

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("myrealease-3.14", result.Deployments[0].Name);
            Assert.Equal("Succeeded", result.Deployments[0].Properties.ProvisioningState);
            Assert.Equal(new DateTime(2014, 1, 5, 12, 30, 43), result.Deployments[0].Properties.Timestamp);
            Assert.Equal(DeploymentMode.Incremental, result.Deployments[0].Properties.Mode);
            Assert.Equal("http://wa/template.json", result.Deployments[0].Properties.TemplateLink.Uri.ToString());
            Assert.Equal("1.0.0.0", result.Deployments[0].Properties.TemplateLink.ContentVersion);
            Assert.True(result.Deployments[0].Properties.Parameters.Contains("\"type\": \"string\""));
            Assert.True(result.Deployments[0].Properties.Outputs.Contains("\"type\": \"string\""));
            Assert.Equal("https://wa/subscriptions/subId/templateDeployments?$skiptoken=983fknw", result.NextLink.ToString());
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

            var result = client.Deployments.List("foo", new DeploymentListParameters
                {
                    ProvisioningState = "Succeeded",
                    Top = 10,
                });

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
            Assert.True(handler.Uri.ToString().Contains("$top=10"));
            Assert.True(handler.Uri.ToString().Contains("$filter=provisioningState eq 'Succeeded'"));

            // Validate result
            Assert.Equal("myrealease-3.14", result.Deployments[0].Name);
            Assert.Equal("Succeeded", result.Deployments[0].Properties.ProvisioningState);
            Assert.Equal(new DateTime(2014, 1, 5, 12, 30, 43), result.Deployments[0].Properties.Timestamp);
            Assert.Equal(DeploymentMode.Incremental, result.Deployments[0].Properties.Mode);
            Assert.Equal("http://wa/template.json", result.Deployments[0].Properties.TemplateLink.Uri.ToString());
            Assert.Equal("1.0.0.0", result.Deployments[0].Properties.TemplateLink.ContentVersion);
            Assert.True(result.Deployments[0].Properties.Parameters.Contains("\"type\": \"string\""));
            Assert.True(result.Deployments[0].Properties.Outputs.Contains("\"type\": \"string\""));
            Assert.Equal("https://wa/subscriptions/subId/templateDeployments?$skiptoken=983fknw", result.NextLink.ToString());
        }

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

            var result = client.Deployments.List("foo", new DeploymentListParameters
            {
                ProvisioningState = "Succeeded",
                Top = 10,
            });

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
            Assert.True(handler.Uri.ToString().Contains("$top=10"));
            Assert.True(handler.Uri.ToString().Contains("$filter=provisioningState eq 'Succeeded'"));
            Assert.True(handler.Uri.ToString().Contains("resourcegroups/foo/deployments"));

            // Validate result
            Assert.Equal("myrealease-3.14", result.Deployments[0].Name);
            Assert.Equal("Succeeded", result.Deployments[0].Properties.ProvisioningState);
            Assert.Equal(new DateTime(2014, 1, 5, 12, 30, 43), result.Deployments[0].Properties.Timestamp);
            Assert.Equal(DeploymentMode.Incremental, result.Deployments[0].Properties.Mode);
            Assert.Equal("http://wa/template.json", result.Deployments[0].Properties.TemplateLink.Uri.ToString());
            Assert.Equal("1.0.0.0", result.Deployments[0].Properties.TemplateLink.ContentVersion);
            Assert.True(result.Deployments[0].Properties.Parameters.Contains("\"type\": \"string\""));
            Assert.True(result.Deployments[0].Properties.Outputs.Contains("\"type\": \"string\""));
            Assert.Equal("https://wa/subscriptions/subId/templateDeployments?$skiptoken=983fknw", result.NextLink.ToString());
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

            var result = client.Deployments.List("foo", new DeploymentListParameters());
            Assert.Empty(result.Deployments);
        }
    }
}
