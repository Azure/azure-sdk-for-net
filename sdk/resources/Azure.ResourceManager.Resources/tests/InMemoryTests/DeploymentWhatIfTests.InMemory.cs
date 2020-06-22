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
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Resources.Tests;
using NUnit.Framework;

namespace ResourceGroups.Tests
{
    public class InMemoryDeploymentWhatIfTests : ResourceOperationsTestsBase
    {
        public InMemoryDeploymentWhatIfTests(bool isAsync) : base(isAsync)
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
        public async Task WhatIf_SendingRequest_SetsHeaders()
        {
            // Arrange.
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var deploymentWhatIf = new DeploymentWhatIf(new DeploymentWhatIfProperties(DeploymentMode.Incremental));

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            // Act.
            await client.Deployments.StartWhatIfAsync("test-rg", "test-deploy", deploymentWhatIf);

            // Assert.
            var request = mockTransport.Requests[0];
            Assert.IsTrue(request.Headers.Contains(new HttpHeader("Content-Type", "application/json")));
            Assert.AreEqual(HttpMethod.Post.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));
        }

        [Test]
        public async Task WhatIf_SendingRequest_SerializesPayload()
        {
            // Arrange.
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var deploymentWhatIf = new DeploymentWhatIf(new DeploymentWhatIfProperties(DeploymentMode.Complete)
            {
                TemplateLink = new TemplateLink("https://example.com")
                {
                    ContentVersion = "1.0.0.0"
                },
                ParametersLink = new ParametersLink("https://example.com/parameters")
                {
                    ContentVersion = "1.0.0.0"
                },
                Template = "{ \"$schema\": \"fake\" }",
                Parameters = JsonSerializer.Serialize(new Dictionary<string, object>
                {
                    ["param1"] = "foo",
                    ["param2"] = new Dictionary<string, object>
                    {
                        ["param2_1"] = 123,
                        ["param2_2"] = "bar"
                    }
                })
            })
            {
                Location = "westus"
            };

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            // Act.
            await client.Deployments.StartWhatIfAsync("test-rg", "test-deploy", deploymentWhatIf);

            // Assert.
            var request = mockTransport.Requests[0];
            Stream stream = new MemoryStream();
            await request.Content.WriteToAsync(stream, default);
            stream.Position = 0;
            var resquestContent = new StreamReader(stream).ReadToEnd();
            var resultJson = JsonDocument.Parse(resquestContent).RootElement;
            Assert.AreEqual("westus", resultJson.GetProperty("location").GetString());
            Assert.AreEqual("Complete", resultJson.GetProperty("properties").GetProperty("mode").GetString());
            Assert.AreEqual("https://example.com", resultJson.GetProperty("properties").GetProperty("templateLink").GetProperty("uri").GetString());
            Assert.AreEqual("1.0.0.0", resultJson.GetProperty("properties").GetProperty("templateLink").GetProperty("contentVersion").GetString());
            Assert.AreEqual("https://example.com/parameters", resultJson.GetProperty("properties").GetProperty("parametersLink").GetProperty("uri").GetString());
            Assert.AreEqual("1.0.0.0", resultJson.GetProperty("properties").GetProperty("parametersLink").GetProperty("contentVersion").GetString());
            Assert.AreEqual(JsonDocument.Parse("{\"$schema\":\"fake\"}").RootElement.ToString(), resultJson.GetProperty("properties").GetProperty("template").ToString());
            Assert.AreEqual("foo", resultJson.GetProperty("properties").GetProperty("parameters").GetProperty("param1").GetString());
            Assert.AreEqual(123, resultJson.GetProperty("properties").GetProperty("parameters").GetProperty("param2").GetProperty("param2_1").GetInt32());
            Assert.AreEqual("bar", resultJson.GetProperty("properties").GetProperty("parameters").GetProperty("param2").GetProperty("param2_2").GetString());
        }

        [Test]
        public async Task WhatIf_SendingRequestWithStrings_SerializesPayload()
        {
            // Arrange.
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);

            string templateContent = @"{
                '$schema': 'http://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#',
                'contentVersion': '1.0.0.0',
                'parameters': {
                    'storageAccountName': {
		                'type': 'string'
	                }
                },
                'resources': [
                ],
                'outputs': {}
            }".Replace("'", "\"");
            string[] divideCases = {
                @"{
                '$schema': 'http://schema.management.azure.com/schemas/2015-01-01/deploymentParameters.json#',
                'contentVersion': '1.0.0.0',
                'parameters': {
                    'storageAccountName': {
                        'value': 'lsfjlasf9urw'
                    }
                }
                }".Replace("'", "\""),
                @"{
                'storageAccountName': {
                    'value': 'lsfjlasf9urw'
                }
                }".Replace("'", "\"")};

            foreach (var parameterContent in divideCases)
            {
                JsonElement jsonParameter = JsonSerializer.Deserialize<JsonElement>(parameterContent);
                if (!jsonParameter.TryGetProperty("parameters", out JsonElement parameter))
                {
                    parameter = jsonParameter;
                }
                var deploymentWhatIf = new DeploymentWhatIf(
                new DeploymentWhatIfProperties(DeploymentMode.Incremental)
                {
                    Template = templateContent,
                    ParametersJson = parameter
                })
                {
                    Location = "westus"
                };

                var mockTransport = new MockTransport(mockResponse);
                var client = GetResourceManagementClient(mockTransport);

                // Act.
                await client.Deployments.StartWhatIfAsync("test-rg", "test-deploy", deploymentWhatIf);

                // Assert.
                var request = mockTransport.Requests[0];
                Stream stream = new MemoryStream();
                await request.Content.WriteToAsync(stream, default);
                stream.Position = 0;
                var resquestContent = new StreamReader(stream).ReadToEnd();
                var resultJson = JsonDocument.Parse(resquestContent).RootElement;
                Assert.AreEqual("Incremental", resultJson.GetProperty("properties").GetProperty("mode").GetString());
                Assert.AreEqual("1.0.0.0", resultJson.GetProperty("properties").GetProperty("template").GetProperty("contentVersion").GetString());
                Assert.AreEqual("lsfjlasf9urw", resultJson.GetProperty("properties").GetProperty("parameters").GetProperty("storageAccountName").GetProperty("value").GetString());
            }
        }

        [Test]
        public async Task WhatIf_ReceivingResponse_DeserializesResult()
        {
            // Arrange.
            var deploymentWhatIf = new DeploymentWhatIf(new DeploymentWhatIfProperties(DeploymentMode.Incremental));
            var content = @"{
                    'status': 'Succeeded',
                    'properties': {
                        'changes': [
                            {
                                'resourceId': '/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myExistingIdentity',
                                'changeType': 'Modify',
                                'before': {
                                    'apiVersion': '2018-11-30',
                                    'id': '/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myExistingIdentity',
                                    'type': 'Microsoft.ManagedIdentity/userAssignedIdentities',
                                    'name': 'myExistingIdentity',
                                    'location': 'westus2'
                                },
                                'after': {
                                    'apiVersion': '2018-11-30',
                                    'id': '/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myExistingIdentity',
                                    'type': 'Microsoft.ManagedIdentity/userAssignedIdentities',
                                    'name': 'myExistingIdentity',
                                    'location': 'westus2',
                                    'tags': {
                                        'myNewTag': 'my tag value'
                                    }
                                },
                                'delta': [
                                    {
                                        'path': 'tags.myNewTag',
                                        'propertyChangeType': 'Create',
                                        'after': 'my tag value'
                                    }
                                ]
                            }
                        ]
                    }
                }".Replace("'", "\"");

            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            // Act.
            var raw = await client.Deployments.StartWhatIfAsync("test-rg", "test-deploy", deploymentWhatIf);
            var result = (await WaitForCompletionAsync(raw)).Value;

            // Assert.
            Assert.AreEqual("Succeeded", result.Status);
            Assert.NotNull(result.Changes);
            Assert.AreEqual(1, result.Changes.Count);

            WhatIfChange change = result.Changes[0];
            Assert.AreEqual(ChangeType.Modify, change.ChangeType);

            Assert.NotNull(change.Before);
            Assert.AreEqual("myExistingIdentity", JsonDocument.Parse(JsonSerializer.Serialize(change.Before)).RootElement.GetProperty("name").GetString());

            Assert.NotNull(change.After);
            Assert.AreEqual("myExistingIdentity", JsonDocument.Parse(JsonSerializer.Serialize(change.After)).RootElement.GetProperty("name").GetString());

            Assert.NotNull(change.Delta);
            Assert.AreEqual(1, change.Delta.Count);
            Assert.AreEqual("tags.myNewTag", change.Delta[0].Path);
            Assert.AreEqual(PropertyChangeType.Create, change.Delta[0].PropertyChangeType);
            Assert.AreEqual("my tag value", change.Delta[0].After);
        }

        [Test]
        public async Task WhatIfAtSubscriptionScope_SendingRequest_SetsHeaders()
        {
            // Arrange.
            var deploymentWhatIf = new DeploymentWhatIf(new DeploymentWhatIfProperties(DeploymentMode.Incremental));

            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            // Act.
            await client.Deployments.StartWhatIfAtSubscriptionScopeAsync("test-subscription-deploy", deploymentWhatIf);

            // Assert.
            var request = mockTransport.Requests[0];
            Assert.IsTrue(request.Headers.Contains(new HttpHeader("Content-Type", "application/json")));
            Assert.AreEqual(HttpMethod.Post.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));
        }

        [Test]
        public async Task WhatIfAtSubscriptionScope_SendingRequest_SerializesPayload()
        {
            // Arrange.
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var deploymentWhatIf = new DeploymentWhatIf(
                new DeploymentWhatIfProperties(DeploymentMode.Complete)
                {
                    TemplateLink = new TemplateLink("https://example.com")
                    {
                        ContentVersion = "1.0.0.0"
                    },
                    ParametersLink = new ParametersLink("https://example.com/parameters")
                    {
                        ContentVersion = "1.0.0.0"
                    },
                    Template = "{\"$schema\":\"fake\"}",
                    Parameters = JsonSerializer.Serialize(new Dictionary<string, object>
                    {
                        ["param1"] = "foo",
                        ["param2"] = new Dictionary<string, object>
                        {
                            ["param2_1"] = 123,
                            ["param2_2"] = "bar"
                        }
                    })
                })
            {
                Location = "westus"
            };

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            // Act.
            await client.Deployments.StartWhatIfAtSubscriptionScopeAsync("test-subscription-deploy", deploymentWhatIf);

            // Assert.
            var request = mockTransport.Requests[0];
            Stream stream = new MemoryStream();
            await request.Content.WriteToAsync(stream, default);
            stream.Position = 0;
            var resquestContent = new StreamReader(stream).ReadToEnd();
            var resultJson = JsonDocument.Parse(resquestContent).RootElement;
            Assert.AreEqual("westus", resultJson.GetProperty("location").GetString());
            Assert.AreEqual("Complete", resultJson.GetProperty("properties").GetProperty("mode").GetString());
            Assert.AreEqual("https://example.com", resultJson.GetProperty("properties").GetProperty("templateLink").GetProperty("uri").GetString());
            Assert.AreEqual("1.0.0.0", resultJson.GetProperty("properties").GetProperty("templateLink").GetProperty("contentVersion").GetString());
            Assert.AreEqual("https://example.com/parameters", resultJson.GetProperty("properties").GetProperty("parametersLink").GetProperty("uri").GetString());
            Assert.AreEqual("1.0.0.0", resultJson.GetProperty("properties").GetProperty("parametersLink").GetProperty("contentVersion").GetString());
            Assert.AreEqual(JsonDocument.Parse("{\"$schema\":\"fake\"}").RootElement.ToString(), resultJson.GetProperty("properties").GetProperty("template").ToString());
            Assert.AreEqual("foo", resultJson.GetProperty("properties").GetProperty("parameters").GetProperty("param1").GetString());
            Assert.AreEqual(123, resultJson.GetProperty("properties").GetProperty("parameters").GetProperty("param2").GetProperty("param2_1").GetInt32());
            Assert.AreEqual("bar", resultJson.GetProperty("properties").GetProperty("parameters").GetProperty("param2").GetProperty("param2_2").GetString());
        }

        [Test]
        public async Task WhatIfAtSubscriptionScope_SendingRequestWithStrings_SerializesPayload()
        {
            // Arrange.
            string[] divideCases = {
                @"{
                    '$schema': 'http://schema.management.azure.com/schemas/2015-01-01/deploymentParameters.json#',
                    'contentVersion': '1.0.0.0',
                    'parameters': {
                        'roleDefName': {
                            'value': 'myCustomRole'
                        }
                    }
                }".Replace("'","\""),
                        @"{
                    'roleDefName': {
                        'value': 'myCustomRole'
                    }
                }".Replace("'","\"")
            };
            foreach (string item in divideCases)
            {
                string templateContent = @"{
                    '$schema': 'http://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#',
                    'contentVersion': '1.0.0.0',
                    'parameters': {
                        'roleDefName': {
		                    'type': 'string'
	                    }
                    },
                    'resources': [
                    ],
                    'outputs': {}
                }".Replace("'", "\"");
                var mockResponse = new MockResponse((int)HttpStatusCode.OK);

                JsonElement jsonParameter = JsonSerializer.Deserialize<JsonElement>(item);
                if (!jsonParameter.TryGetProperty("parameters", out JsonElement parameter))
                {
                    parameter = jsonParameter;
                }

                var deploymentWhatIf = new DeploymentWhatIf(
                    new DeploymentWhatIfProperties(DeploymentMode.Incremental)
                    {
                        Template = templateContent,
                        ParametersJson = parameter
                    })
                {
                    Location = "westus"
                };

                var mockTransport = new MockTransport(mockResponse);
                var client = GetResourceManagementClient(mockTransport);

                // Act.
                await client.Deployments.StartWhatIfAtSubscriptionScopeAsync("test-subscription-deploy", deploymentWhatIf);

                // Assert.
                var request = mockTransport.Requests[0];
                Stream stream = new MemoryStream();
                await request.Content.WriteToAsync(stream, default);
                stream.Position = 0;
                var resquestContent = new StreamReader(stream).ReadToEnd();
                var resultJson = JsonDocument.Parse(resquestContent).RootElement;
                Assert.AreEqual("Incremental", resultJson.GetProperty("properties").GetProperty("mode").GetString());
                Assert.AreEqual("1.0.0.0", resultJson.GetProperty("properties").GetProperty("template").GetProperty("contentVersion").GetString());
                Assert.AreEqual("myCustomRole", resultJson.GetProperty("properties").GetProperty("parameters").GetProperty("roleDefName").GetProperty("value").GetString());
            }
        }

        [Test]
        public async Task WhatIfAtSubscriptionScope_ReceivingResponse_DeserializesResult()
        {
            // Arrange.
            var deploymentWhatIf = new DeploymentWhatIf(new DeploymentWhatIfProperties(DeploymentMode.Incremental));
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
                    'status': 'Succeeded',
                    'properties': {
                        'changes': [
                            {
                                'resourceId': '/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myResourceGroup',
                                'changeType': 'Create',
                                'after': {
                                    'apiVersion': '2019-05-01',
                                    'id': '/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myResourceGroup',
                                    'type': 'Microsoft.Resources/resourceGroups',
                                    'name': 'myResourceGroup',
                                    'location': 'eastus'
                                }
                            }
                        ]
                    }
                }".Replace("'", "\"");
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            // Act.
            var raw = await client.Deployments.StartWhatIfAtSubscriptionScopeAsync("test-subscription-deploy", deploymentWhatIf);
            var result = (await WaitForCompletionAsync(raw)).Value;

            // Assert.
            Assert.AreEqual("Succeeded", result.Status);
            Assert.NotNull(result.Changes);
            Assert.AreEqual(1, result.Changes.Count);

            WhatIfChange change = result.Changes[0];
            Assert.AreEqual(ChangeType.Create, change.ChangeType);

            Assert.Null(change.Before);
            Assert.Null(change.Delta);

            Assert.NotNull(change.After);
            Assert.AreEqual("myResourceGroup", JsonDocument.Parse(JsonSerializer.Serialize(change.After)).RootElement.GetProperty("name").GetString());
        }
    }
}
