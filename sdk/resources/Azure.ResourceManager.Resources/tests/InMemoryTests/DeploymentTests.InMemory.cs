// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Resources.Tests;
using NUnit.Framework;

namespace ResourceGroups.Tests
{
    public class InMemoryDeploymentTests : ResourceOperationsTestsBase
    {
        public InMemoryDeploymentTests(bool isAsync) : base(isAsync)
        {
        }

        public ResourcesManagementClient GetResourceManagementClient(HttpPipelineTransport transport)
        {
            ResourcesManagementClientOptions options = new ResourcesManagementClientOptions();
            options.Transport = transport;

            return CreateClient<ResourcesManagementClient>(
                TestEnvironment.SubscriptionId,
                new TestCredential(), options);
        }

        [Test]
        public async Task DeploymentTestsCreateValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.Created);
            var content = @"{
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
                              'value': 'yyz7xhhshfasf'
                           }
                        },
                        'parametersLink': {
                           'uri': 'http://wa/parameters.json',
                           'contentVersion': '1.0.0.0',
                           'contentHash': {
                              'algorithm': 'sha256',
                              'value': 'yyz7xhhshfasf'
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
                }".Replace("'", "\"");
            mockResponse.SetContent(content);

            var dictionary = new Dictionary<string, object> {
                    {"param1", "value1"},
                    {"param2", true},
                    {"param3", new Dictionary<string, object>() {
                        {"param3_1", 123},
                        {"param3_2", "value3_2"},
                    }}
                };
            var parameters = new Deployment
            (
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    Template = "{\"api-version\": \"123\"}",
                    TemplateLink = new TemplateLink("http://abc/def/template.json")
                    {
                        ContentVersion = "1.0.0.0"
                    },
                    Parameters = JsonSerializer.Serialize(dictionary),
                    ParametersLink = new ParametersLink("http://abc/def/template.json")
                    {
                        ContentVersion = "1.0.0.0"
                    }
                }
                );

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            DeploymentsCreateOrUpdateOperation raw = await client.Deployments.StartCreateOrUpdateAsync("foo", "myrealease-3.14", parameters);

            DeploymentExtended result = (await WaitForCompletionAsync(raw)).Value;

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.IsTrue(request.Headers.Contains(new HttpHeader("Content-Type", "application/json")));
            Assert.AreEqual(HttpMethod.Put.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate payload
            Stream stream = new MemoryStream();
            await request.Content.WriteToAsync(stream, default);
            stream.Position = 0;
            var resquestContent = new StreamReader(stream).ReadToEnd();
            var json = JsonDocument.Parse(resquestContent).RootElement;

            Assert.AreEqual("Incremental", json.GetProperty("properties").GetProperty("mode").GetString());
            Assert.AreEqual("http://abc/def/template.json", json.GetProperty("properties").GetProperty("templateLink").GetProperty("uri").GetString());
            Assert.AreEqual("1.0.0.0", json.GetProperty("properties").GetProperty("templateLink").GetProperty("contentVersion").GetString());
            Assert.AreEqual("1.0.0.0", json.GetProperty("properties").GetProperty("parametersLink").GetProperty("contentVersion").GetString());
            Assert.AreEqual("value1", json.GetProperty("properties").GetProperty("parameters").GetProperty("param1").GetString());
            Assert.True(json.GetProperty("properties").GetProperty("parameters").GetProperty("param2").GetBoolean());
            Assert.AreEqual(123, json.GetProperty("properties").GetProperty("parameters").GetProperty("param3").GetProperty("param3_1").GetInt32());
            Assert.AreEqual("value3_2", json.GetProperty("properties").GetProperty("parameters").GetProperty("param3").GetProperty("param3_2").GetString());
            Assert.AreEqual("123", json.GetProperty("properties").GetProperty("template").GetProperty("api-version").GetString());

            // Validate result
            Assert.AreEqual("foo", result.Id);
            Assert.AreEqual("myrealease-3.14", result.Name);
            Assert.AreEqual("Succeeded", result.Properties.ProvisioningState);
            Assert.AreEqual(new DateTimeOffset(2014, 1, 5, 12, 30, 43, new TimeSpan()), result.Properties.Timestamp);
            Assert.AreEqual(DeploymentMode.Incremental, result.Properties.Mode);
            Assert.AreEqual("http://wa/template.json", result.Properties.TemplateLink.Uri);
            Assert.AreEqual("1.0.0.0", result.Properties.TemplateLink.ContentVersion);
            Assert.IsTrue(JsonSerializer.Serialize(result.Properties.Parameters).Contains("\"type\":\"string\""));
            Assert.IsTrue(JsonSerializer.Serialize(result.Properties.Outputs).Contains("\"type\":\"string\""));
        }

        [Test]
        public async Task DeploymentTestsTemplateAsJsonString()
        {
            List<string> dividedCases = new List<string> {
            (@"{
                '$schema': 'http://schema.management.azure.com/schemas/2015-01-01/deploymentParameters.json#',
                'contentVersion': '1.0.0.0',
                'parameters': {
                    'storageAccountName': {
		                'value': 'tianotest04'
	                }
                }
            }").Replace("'", "\""),
            (@"{
                'storageAccountName': {
		            'value': 'tianotest04'
	            }
            }").Replace("'", "\"")
            };
            foreach (var parameterString in dividedCases)
            {
                var mockResponse = new MockResponse((int)HttpStatusCode.Created);
                var responseBody = (@"{
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
                }").Replace("'", "\"");
                mockResponse.SetContent(responseBody);

                var templateString = (@"{
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
                }").Replace("'", "\"");

                JsonElement jsonParameter = JsonSerializer.Deserialize<JsonElement>(parameterString);
                if (!jsonParameter.TryGetProperty("parameters", out JsonElement parameter))
                {
                    parameter = jsonParameter;
                }
                var mockTransport = new MockTransport(mockResponse);
                var client = GetResourceManagementClient(mockTransport);

                var parameters = new Deployment
                (
                    new DeploymentProperties(DeploymentMode.Incremental)
                    {
                        Template = templateString,
                        ParametersJson = parameter
                    }
                 );

                var raw = await client.Deployments.StartCreateOrUpdateAsync("foo", "myrealease-3.14", parameters);
                var result = (await WaitForCompletionAsync(raw)).Value;

                // Validate headers
                var request = mockTransport.Requests[0];
                Assert.IsTrue(request.Headers.Contains(new HttpHeader("Content-Type", "application/json")));
                Assert.AreEqual(HttpMethod.Put.Method, request.Method.Method);
                Assert.IsTrue(request.Headers.Contains("Authorization"));

                // Validate payload
                Stream stream = new MemoryStream();
                await request.Content.WriteToAsync(stream, default);
                stream.Position = 0;
                var resquestContent = new StreamReader(stream).ReadToEnd();
                var json = JsonDocument.Parse(resquestContent).RootElement;
                Assert.AreEqual("Incremental", json.GetProperty("properties").GetProperty("mode").GetString());
                Assert.AreEqual("tianotest04", json.GetProperty("properties").GetProperty("parameters").GetProperty("storageAccountName").GetProperty("value").GetString());
                Assert.AreEqual("1.0.0.0", json.GetProperty("properties").GetProperty("template").GetProperty("contentVersion").GetString());

                // Validate result
                Assert.AreEqual("foo", result.Id);
                Assert.AreEqual("test-release-3", result.Name);
                Assert.AreEqual("Succeeded", result.Properties.ProvisioningState);
                Assert.AreEqual(DeploymentMode.Incremental, result.Properties.Mode);
                Assert.IsTrue(JsonSerializer.Serialize(result.Properties.Parameters).Contains("\"value\":\"tianotest04\""));
            }
        }

        [Test]
        public async Task ListDeploymentOperationsReturnsMultipleObjects()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = (@"{
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
                                'resourceType': 'Microsoft.Web'
                            },
                            'provisioningState':'Succeeded',                 
                            'timestamp': '2014-02-25T23:08:21.8183932Z',
                            'correlationId': 'afb170c6-fe57-4b38-a43b-900fe09be4ca',
                            'statusCode': 'InternalServerError',
                            'statusMessage': 'InternalServerError'       
                          }
                       }
                    ]}
            ").Replace("'","\"");
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);
            var result = await client.Deployment.ListAsync("foo", "bar", null).ToEnumerableAsync();

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate response
            Has.One.EqualTo(result);
            Assert.AreEqual("AEF2398", result.First().OperationId);
            Assert.AreEqual("/subscriptions/123abc/resourcegroups/foo/providers/ResourceProviderTestHost/TestResourceType/resource1", result.First().Properties.TargetResource.Id);
            Assert.AreEqual("mySite1", result.First().Properties.TargetResource.ResourceName);
            Assert.AreEqual("Microsoft.Web", result.First().Properties.TargetResource.ResourceType);
            Assert.AreEqual("Succeeded", result.First().Properties.ProvisioningState);
            Assert.AreEqual("InternalServerError", result.First().Properties.StatusCode);
            Assert.AreEqual("InternalServerError", result.First().Properties.StatusMessage);
        }

        [Test]
        public async Task ListDeploymentOperationsReturnsEmptyArray()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = JsonDocument.Parse("{\"value\": []}").RootElement.ToString();
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = await client.Deployment.ListAsync("foo", "bar", null).ToEnumerableAsync();

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate response
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task ListDeploymentOperationsWithRealPayloadReadsJsonInStatusMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
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
                '/subscriptions/abcd1234/resourcegroups/foo/deployments/testdeploy/operations/6B9A5A38C94E6F14',
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
                '/subscriptions/abcd1234/resourcegroups/foo/providers/Microsoft.Web/serverFarms/ilygreTest4Host',
                          'subscriptionId': 'abcd1234',
                          'resourceGroup': 'foo',
                          'resourceType': 'Microsoft.Web/serverFarms',
                          'resourceName': 'ilygreTest4Host'
                        }
                      }
                    }
                  ]
                }".Replace("'", "\"");
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = await client.Deployment.ListAsync("foo", "bar", null).ToEnumerableAsync();

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            Assert.True(((Dictionary<string, object>)result.First().Properties.StatusMessage).Count != 0);
        }

        [Test]
        public async Task GetDeploymentOperationsReturnsValue()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
                        'subscriptionId':'mysubid',
                        'resourceGroup': 'foo',
                        'deploymentName':'test-release-3',
                        'operationId': 'AEF2398',
                        'properties':{
                            'targetResource':{
                                'id':'/subscriptions/123abc/resourcegroups/foo/providers/ResourceProviderTestHost/TestResourceType/resource1',
                                'resourceName':'mySite1',
                                'resourceType': 'Microsoft.Web'
                            },
                            'provisioningState':'Succeeded',
                            'timestamp': '2014-02-25T23:08:21.8183932Z',
                            'correlationId': 'afb170c6-fe57-4b38-a43b-900fe09be4ca',
                            'statusCode': 'OK',
                            'statusMessage': 'OK'
                          }
                       }".Replace("'", "\"");
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = (await client.Deployment.GetAsync("foo", "bar", "123")).Value;

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate response
            Assert.AreEqual("AEF2398", result.OperationId);
            Assert.AreEqual("mySite1", result.Properties.TargetResource.ResourceName);
            Assert.AreEqual("/subscriptions/123abc/resourcegroups/foo/providers/ResourceProviderTestHost/TestResourceType/resource1", result.Properties.TargetResource.Id);
            Assert.AreEqual("Microsoft.Web", result.Properties.TargetResource.ResourceType);
            Assert.AreEqual("Succeeded", result.Properties.ProvisioningState);
            Assert.AreEqual("OK", result.Properties.StatusCode);
            Assert.AreEqual("OK", result.Properties.StatusMessage);
        }

        [Test]
        public async Task DeploymentTestsValidateCheckPayload()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.BadRequest);
            var content = @"{
                      'error': {
                        'code': 'InvalidTemplate',
                        'message': 'Deployment template validation failed.'
                      }
                    }".Replace("'", "\"");
            mockResponse.SetContent(content);

            var dictionary = new Dictionary<string, object> {
                    {"param1", "value1"},
                    {"param2", true},
                    {"param3", new Dictionary<string, object>() {
                        {"param3_1", 123},
                        {"param3_2", "value3_2"},
                    }}
                };
            var parameters = new Deployment
            (
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    TemplateLink = new TemplateLink("http://abc/def/template.json")
                    {
                        ContentVersion = "1.0.0.0",
                    },
                    Parameters = JsonSerializer.Serialize(dictionary)
                }
                );

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            try
            {
                var raw = await client.Deployments.StartValidateAsync("foo", "bar", parameters);
                var result = (await WaitForCompletionAsync(raw)).Value;
            }
            catch (RequestFailedException)
            {
                var requestEX = mockTransport.Requests[0];
                Stream stream = new MemoryStream();
                await requestEX.Content.WriteToAsync(stream, default);
                stream.Position = 0;
                var resquestContent = new StreamReader(stream).ReadToEnd();
                var json = JsonDocument.Parse(resquestContent).RootElement;
                // Validate payload
                Assert.AreEqual("Incremental", json.GetProperty("properties").GetProperty("mode").GetString());
                Assert.AreEqual("http://abc/def/template.json", json.GetProperty("properties").GetProperty("templateLink").GetProperty("uri").GetString());
                Assert.AreEqual("1.0.0.0", json.GetProperty("properties").GetProperty("templateLink").GetProperty("contentVersion").GetString());
                Assert.AreEqual("value1", json.GetProperty("properties").GetProperty("parameters").GetProperty("param1").GetString());
                Assert.IsTrue(json.GetProperty("properties").GetProperty("parameters").GetProperty("param2").GetBoolean());
                Assert.AreEqual(123, json.GetProperty("properties").GetProperty("parameters").GetProperty("param3").GetProperty("param3_1").GetInt32());
                Assert.AreEqual("value3_2", json.GetProperty("properties").GetProperty("parameters").GetProperty("param3").GetProperty("param3_2").GetString());
            }

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.IsTrue(request.Headers.Contains(new HttpHeader("Content-Type", "application/json")));
            Assert.AreEqual(HttpMethod.Post.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));
        }

        [Test]
        public async Task DeploymentTestsValidateSimpleFailure()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.BadRequest);
            var content = @"{
                      'error': {
                        'code': 'InvalidTemplate',
                        'message': 'Deployment template validation failed: The template parameters hostingPlanName, siteMode, computeMode are not valid; they are not present.'
                      }
                    }".Replace("'", "\"");
            var header = new HttpHeader("Content-Type", "application/json");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var parameters = new Deployment(
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    TemplateLink = new TemplateLink("http://abc/def/template.json")
                    {
                        ContentVersion = "1.0.0.0",
                    },
                    });

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            try
            {
                var raw = await client.Deployments.StartValidateAsync("foo", "bar", parameters);
                var result = (await WaitForCompletionAsync(raw)).Value;
            }
            catch (RequestFailedException ex)
            {
                // Validate result
                Assert.IsTrue(ex.Message.ToString().Contains("InvalidTemplate"));
                Assert.IsTrue(ex.Message.ToString().Contains("Deployment template validation failed: The template parameters hostingPlanName, siteMode, computeMode are not valid; they are not present."));
            }
        }

        [Test]
        public async Task DeploymentTestsValidateComplexFailure()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.BadRequest);
            var content = @"{
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
                    }".Replace("'","\"");
            var header = new HttpHeader("Content-Type", "application/json");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var parameters = new Deployment(
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    TemplateLink = new TemplateLink("http://abc/def/template.json")
                    {
                        ContentVersion = "1.0.0.0"
                    }
                });

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            try
            {
                var raw = await client.Deployments.StartValidateAsync("foo", "bar", parameters);
                var result = (await WaitForCompletionAsync(raw)).Value;
            }
            catch (RequestFailedException ex)
            {
                // Validate result
                Assert.IsTrue(ex.Message.ToString().Contains("InvalidTemplate"));
                Assert.IsTrue(ex.Message.ToString().Contains("Deployment template validation failed: The template parameters hostingPlanName, siteMode, computeMode are not valid; they are not present."));
                Assert.IsTrue(ex.Message.ToString().Contains("Error1"));
                Assert.IsTrue(ex.Message.ToString().Contains("Error2"));
            }
        }

        [Test]
        public async Task DeploymentTestsValidateSuccess()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = JsonDocument.Parse(@"{}").RootElement.ToString();
            mockResponse.SetContent(content);

            var parameters = new Deployment(new DeploymentProperties(DeploymentMode.Incremental)
            {
                TemplateLink = new TemplateLink("http://abc/def/template.json")
                {
                    ContentVersion = "1.0.0.0",
                }
            });

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var raw = await client.Deployments.StartValidateAsync("foo", "bar", parameters);
            var result = (await WaitForCompletionAsync(raw)).Value;

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.IsTrue(request.Headers.Contains(new HttpHeader("Content-Type", "application/json")));
            Assert.AreEqual(HttpMethod.Post.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.Null(result.Error);
        }

        [Test]
        public async Task DeploymentTestsCancelValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.NoContent);
            var content = JsonDocument.Parse(@"{}").RootElement.ToString();
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            await client.Deployments.CancelAsync("foo", "bar");
        }

        [Test]
        public async Task DeploymentTestsCancelThrowsExceptions()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            try
            {
                await client.Deployments.CancelAsync(null, "bar");
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
            try
            {
                await client.Deployments.CancelAsync("foo", null);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }

        [Test]
        public async Task DeploymentTestsGetValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
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
                              'value': 'yyz7xhhshfasf'
                           }
                        },
                        'parametersLink': {
                           'uri': 'http://wa/parameters.json',
                           'contentVersion': '1.0.0.0',
                           'contentHash': {
                              'algorithm': 'sha256',
                              'value': 'yyz7xhhshfasf'
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
                    },
                    'tags': {
                        'tagsTestKey': 'tagsTestValue'
                    }
                }".Replace("'", "\"");
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = (await client.Deployments.GetAsync("foo", "bar")).Value;

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.AreEqual("myrealease-3.14", result.Name);
            Assert.AreEqual("Succeeded", result.Properties.ProvisioningState);
            Assert.AreEqual("12345", result.Properties.CorrelationId);
            Assert.AreEqual(new DateTimeOffset(2014, 1, 5, 12, 30, 43, new TimeSpan()), result.Properties.Timestamp);
            Assert.AreEqual(DeploymentMode.Incremental, result.Properties.Mode);
            Assert.AreEqual("http://wa/template.json", result.Properties.TemplateLink.Uri.ToString());
            Assert.AreEqual("1.0.0.0", result.Properties.TemplateLink.ContentVersion);
            Assert.IsTrue(JsonSerializer.Serialize(result.Properties.Parameters).Contains("\"type\":\"string\""));
            Assert.IsTrue(JsonSerializer.Serialize(result.Properties.Outputs).Contains("\"type\":\"string\""));
            Assert.NotNull(result.Tags);
            Assert.True(result.Tags.ContainsKey("tagsTestKey"));
            Assert.AreEqual("tagsTestValue", result.Tags["tagsTestKey"]);
        }

        [Test]
        public async Task DeploymentTestsListAllValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{ 
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
                                  'value': 'yyz7xhhshfasf'
                               }
                            },
                            'parametersLink': {
                               'uri': 'http://wa/parameters.json',
                               'contentVersion': '1.0.0.0',
                               'contentHash': {
                                  'algorithm': 'sha256',
                                  'value': 'yyz7xhhshfasf'
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
                                  'value': 'yyz7xhhshfasf'
                               }
                            },
                            'parametersLink': {
                               'uri': 'http://wa/parameters.json',
                               'contentVersion': '1.0.0.0',
                               'contentHash': {
                                  'algorithm': 'sha256',
                                  'value': 'yyz7xhhshfasf'
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
                    ]
                }".Replace("'", "\"");
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = await client.Deployments.ListByResourceGroupAsync("foo").ToEnumerableAsync();

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.AreEqual("myrealease-3.14", result.First().Name);
            Assert.AreEqual("Succeeded", result.First().Properties.ProvisioningState);
            Assert.AreEqual(new DateTimeOffset(2014, 1, 5, 12, 30, 43, new TimeSpan()), result.First().Properties.Timestamp);
            Assert.AreEqual(DeploymentMode.Incremental, result.First().Properties.Mode);
            Assert.AreEqual("http://wa/template.json", result.First().Properties.TemplateLink.Uri.ToString());
            Assert.AreEqual("1.0.0.0", result.First().Properties.TemplateLink.ContentVersion);
            Assert.IsTrue(JsonSerializer.Serialize(result.First().Properties.Parameters).Contains("\"type\":\"string\""));
            Assert.IsTrue(JsonSerializer.Serialize(result.First().Properties.Outputs).Contains("\"type\":\"string\""));
        }

        [Test]
        public async Task DeploymentTestsListValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{ 
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
                                  'value': 'yyz7xhhshfasf'
                               }
                            },
                            'parametersLink': {
                               'uri': 'http://wa/parameters.json',
                               'contentVersion': '1.0.0.0',
                               'contentHash': {
                                  'algorithm': 'sha256',
                                  'value': 'yyz7xhhshfasf'
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
                                  'value': 'yyz7xhhshfasf'
                               }
                            },
                            'parametersLink': {
                               'uri': 'http://wa/parameters.json',
                               'contentVersion': '1.0.0.0',
                               'contentHash': {
                                  'algorithm': 'sha256',
                                  'value': 'yyz7xhhshfasf'
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
                    ]
                }".Replace("'", "\"");
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = await client.Deployments.ListByResourceGroupAsync("foo", "provisioningState eq 'Succeeded'", 10).ToEnumerableAsync();

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));
            Assert.IsTrue(request.Uri.ToString().Contains("$top=10"));
            Assert.IsTrue(request.Uri.ToString().Contains("$filter=provisioningState%20eq%20%27Succeeded%27"));

            // Validate result
            Assert.AreEqual("myrealease-3.14", result.First().Name);
            Assert.AreEqual("Succeeded", result.First().Properties.ProvisioningState);
            Assert.AreEqual(new DateTimeOffset(2014, 1, 5, 12, 30, 43, new TimeSpan()), result.First().Properties.Timestamp);
            Assert.AreEqual(DeploymentMode.Incremental, result.First().Properties.Mode);
            Assert.AreEqual("http://wa/template.json", result.First().Properties.TemplateLink.Uri.ToString());
            Assert.AreEqual("1.0.0.0", result.First().Properties.TemplateLink.ContentVersion);
            Assert.IsTrue(JsonSerializer.Serialize(result.First().Properties.Parameters).Contains("\"type\":\"string\""));
            Assert.IsTrue(JsonSerializer.Serialize(result.First().Properties.Outputs).Contains("\"type\":\"string\""));
        }

        [Test]
        public async Task DeploymentTestListDoesNotThrowExceptions()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = JsonDocument.Parse("{\"value\" : []}").RootElement.ToString();
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = await client.Deployments.ListByResourceGroupAsync("foo").ToEnumerableAsync();
            Assert.IsEmpty(result);
        }
    }
}
