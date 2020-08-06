// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ResourceGroups.Tests
{
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Rest;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Xunit;

    public class InMemoryDeploymentWhatIfTests
    {
        [Fact]
        public void WhatIf_SendingRequest_SetsHeaders()
        {
            // Arrange.
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var deploymentWhatIf = new DeploymentWhatIf(new DeploymentWhatIfProperties());

            using (ResourceManagementClient client = CreateResourceManagementClient(handler))
            {
                // Act.
                client.Deployments.WhatIf("test-rg", "test-deploy", deploymentWhatIf);
            }

            // Assert.
            Assert.Equal("application/json; charset=utf-8", handler.ContentHeaders.GetValues("Content-Type").First());
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
        }

        [Fact]
        public void WhatIf_SendingRequest_SerializesPayload()
        {
            // Arrange.
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var deploymentWhatIf = new DeploymentWhatIf
            {
                Location = "westus",
                Properties = new DeploymentWhatIfProperties
                {
                    Mode = DeploymentMode.Complete,
                    TemplateLink = new TemplateLink
                    {
                        Uri = "https://example.com",
                        ContentVersion = "1.0.0.0"
                    },
                    ParametersLink = new ParametersLink
                    {
                        Uri = "https://example.com/parameters",
                        ContentVersion = "1.0.0.0"
                    },
                    Template = JObject.Parse("{ '$schema': 'fake' }"),
                    Parameters = new Dictionary<string, object>
                    {
                        ["param1"] = "foo",
                        ["param2"] = new Dictionary<string, object>
                        {
                            ["param2_1"] = 123,
                            ["param2_2"] = "bar"
                        }
                    }
                }
            };

            using (ResourceManagementClient client = CreateResourceManagementClient(handler))
            {
                // Act.
                client.Deployments.WhatIf("test-rg", "test-deploy", deploymentWhatIf);
            }

            // Assert.
            JObject resultJson = JObject.Parse(handler.Request);
            Assert.Equal("westus", resultJson["location"]);
            Assert.Equal("Complete", resultJson["properties"]["mode"]);
            Assert.Equal("https://example.com", resultJson["properties"]["templateLink"]["uri"]);
            Assert.Equal("1.0.0.0", resultJson["properties"]["templateLink"]["contentVersion"]);
            Assert.Equal("https://example.com/parameters", resultJson["properties"]["parametersLink"]["uri"]);
            Assert.Equal("1.0.0.0", resultJson["properties"]["parametersLink"]["contentVersion"]);
            Assert.Equal(JObject.Parse("{ '$schema': 'fake' }"), resultJson["properties"]["template"]);
            Assert.Equal("foo", resultJson["properties"]["parameters"]["param1"]);
            Assert.Equal(123, resultJson["properties"]["parameters"]["param2"]["param2_1"]);
            Assert.Equal("bar", resultJson["properties"]["parameters"]["param2"]["param2_2"]);
        }

        [Theory]
        [InlineData(@"{
            '$schema': 'http://schema.management.azure.com/schemas/2015-01-01/deploymentParameters.json#',
            'contentVersion': '1.0.0.0',
            'parameters': {
                'storageAccountName': {
                    'value': 'lsfjlasf9urw'
                }
            }
        }")]
        [InlineData(@"{
            'storageAccountName': {
                'value': 'lsfjlasf9urw'
            }
        }")]
        public void WhatIf_SendingRequestWithStrings_SerializesPayload(string parameterContent)
        {
            // Arrange.
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            const string templateContent = @"{
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
            }";

        var deploymentWhatIf = new DeploymentWhatIf
            {
                Location = "westus",
                Properties = new DeploymentWhatIfProperties
                {
                    Mode = DeploymentMode.Incremental,
                    Template = templateContent,
                    Parameters = parameterContent
                }
            };

            using (ResourceManagementClient client = CreateResourceManagementClient(handler))
            {
                // Act.
                client.Deployments.WhatIf("test-rg", "test-deploy", deploymentWhatIf);
            }

            // Assert.
            JObject resultJson = JObject.Parse(handler.Request);
            Assert.Equal("Incremental", resultJson["properties"]["mode"]);
            Assert.Equal("1.0.0.0", resultJson["properties"]["template"]["contentVersion"]);
            Assert.Equal("lsfjlasf9urw", resultJson["properties"]["parameters"]["storageAccountName"]["value"]);
        }

        [Fact]
        public void WhatIf_ReceivingResponse_DeserializesResult()
        {
            // Arrange.
            var deploymentWhatIf = new DeploymentWhatIf(new DeploymentWhatIfProperties());
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
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
                }")
            };
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            using (ResourceManagementClient client = CreateResourceManagementClient(handler))
            {
                // Act.
                WhatIfOperationResult result = client.Deployments.WhatIf("test-rg", "test-deploy", deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.Equal(1, result.Changes.Count);

                WhatIfChange change = result.Changes[0];
                Assert.Equal(ChangeType.Modify, change.ChangeType);

                Assert.NotNull(change.Before);
                Assert.Equal("myExistingIdentity", JToken.FromObject(change.Before)["name"]);

                Assert.NotNull(change.After);
                Assert.Equal("myExistingIdentity", JToken.FromObject(change.After)["name"]);

                Assert.NotNull(change.Delta);
                Assert.Equal(1, change.Delta.Count);
                Assert.Equal("tags.myNewTag", change.Delta[0].Path);
                Assert.Equal(PropertyChangeType.Create, change.Delta[0].PropertyChangeType);
                Assert.Equal("my tag value", change.Delta[0].After);
            }
        }

        [Fact]
        public void WhatIfAtSubscriptionScope_SendingRequest_SetsHeaders()
        {
            // Arrange.
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var deploymentWhatIf = new DeploymentWhatIf(new DeploymentWhatIfProperties());

            using (ResourceManagementClient client = CreateResourceManagementClient(handler))
            {
                // Act.
                client.Deployments.WhatIfAtSubscriptionScope("test-subscription-deploy", deploymentWhatIf);
            }

            // Assert.
            Assert.Equal("application/json; charset=utf-8", handler.ContentHeaders.GetValues("Content-Type").First());
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
        }

        [Fact]
        public void WhatIfAtSubscriptionScope_SendingRequest_SerializesPayload()
        {
            // Arrange.
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var deploymentWhatIf = new DeploymentWhatIf
            {
                Location = "westus",
                Properties = new DeploymentWhatIfProperties
                {
                    Mode = DeploymentMode.Complete,
                    TemplateLink = new TemplateLink
                    {
                        Uri = "https://example.com",
                        ContentVersion = "1.0.0.0"
                    },
                    ParametersLink = new ParametersLink
                    {
                        Uri = "https://example.com/parameters",
                        ContentVersion = "1.0.0.0"
                    },
                    Template = JObject.Parse("{ '$schema': 'fake' }"),
                    Parameters = new Dictionary<string, object>
                    {
                        ["param1"] = "foo",
                        ["param2"] = new Dictionary<string, object>
                        {
                            ["param2_1"] = 123,
                            ["param2_2"] = "bar"
                        }
                    }
                }
            };

            using (ResourceManagementClient client = CreateResourceManagementClient(handler))
            {
                // Act.
                client.Deployments.WhatIfAtSubscriptionScope("test-subscription-deploy", deploymentWhatIf);
            }

            // Assert.
            JObject resultJson = JObject.Parse(handler.Request);
            Assert.Equal("westus", resultJson["location"]);
            Assert.Equal("Complete", resultJson["properties"]["mode"]);
            Assert.Equal("https://example.com", resultJson["properties"]["templateLink"]["uri"]);
            Assert.Equal("1.0.0.0", resultJson["properties"]["templateLink"]["contentVersion"]);
            Assert.Equal("https://example.com/parameters", resultJson["properties"]["parametersLink"]["uri"]);
            Assert.Equal("1.0.0.0", resultJson["properties"]["parametersLink"]["contentVersion"]);
            Assert.Equal(JObject.Parse("{ '$schema': 'fake' }"), resultJson["properties"]["template"]);
            Assert.Equal("foo", resultJson["properties"]["parameters"]["param1"]);
            Assert.Equal(123, resultJson["properties"]["parameters"]["param2"]["param2_1"]);
            Assert.Equal("bar", resultJson["properties"]["parameters"]["param2"]["param2_2"]);
        }

        [Theory]
        [InlineData(@"{
            '$schema': 'http://schema.management.azure.com/schemas/2015-01-01/deploymentParameters.json#',
            'contentVersion': '1.0.0.0',
            'parameters': {
                'roleDefName': {
                   'value': 'myCustomRole'
                }
            }
        }")]
        [InlineData(@"{
            'roleDefName': {
                'value': 'myCustomRole'
            }
        }")]
        public void WhatIfAtSubscriptionScope_SendingRequestWithStrings_SerializesPayload(string parameterContent)
        {
            // Arrange.
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
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
            }";

        var deploymentWhatIf = new DeploymentWhatIf
            {
                Location = "westus",
                Properties = new DeploymentWhatIfProperties
                {
                    Mode = DeploymentMode.Incremental,
                    Template = templateContent,
                    Parameters = parameterContent
                }
            };

            using (ResourceManagementClient client = CreateResourceManagementClient(handler))
            {
                // Act.
                client.Deployments.WhatIfAtSubscriptionScope("test-subscription-deploy", deploymentWhatIf);
            }

            // Assert.
            JObject resultJson = JObject.Parse(handler.Request);
            Assert.Equal("Incremental", resultJson["properties"]["mode"]);
            Assert.Equal("1.0.0.0", resultJson["properties"]["template"]["contentVersion"]);
            Assert.Equal("myCustomRole", resultJson["properties"]["parameters"]["roleDefName"]["value"]);
        }

        [Fact]
        public void WhatIfAtSubscriptionScope_ReceivingResponse_DeserializesResult()
        {
            // Arrange.
            var deploymentWhatIf = new DeploymentWhatIf(new DeploymentWhatIfProperties());
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
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
                                    'location': 'eastus',
                                }
                            }
                        ]
                    }
                }")
            };
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            using (ResourceManagementClient client = CreateResourceManagementClient(handler))
            {
                // Act.
                WhatIfOperationResult result =
                    client.Deployments.WhatIfAtSubscriptionScope("test-subscription-deploy", deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.Equal(1, result.Changes.Count);

                WhatIfChange change = result.Changes[0];
                Assert.Equal(ChangeType.Create, change.ChangeType);

                Assert.Null(change.Before);
                Assert.Null(change.Delta);

                Assert.NotNull(change.After);
                Assert.Equal("myResourceGroup", JToken.FromObject(change.After)["name"]);
            }
        }

        [Fact]
        public void WhatIfAtManagementGroupScope_SendingRequest_SetsHeaders()
        {
            // Arrange.
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var deploymentWhatIf = new ScopedDeploymentWhatIf("westus", new DeploymentWhatIfProperties());

            using (ResourceManagementClient client = CreateResourceManagementClient(handler))
            {
                // Act.
                client.Deployments.WhatIfAtManagementGroupScope("test-mg", "test-mg-deploy", deploymentWhatIf);
            }

            // Assert.
            Assert.Equal("application/json; charset=utf-8", handler.ContentHeaders.GetValues("Content-Type").First());
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
        }

        [Fact]
        public void WhatIfAtManagementGroupScope_SendingRequest_SerializesPayload()
        {
            // Arrange.
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var deploymentWhatIf = new ScopedDeploymentWhatIf
            {
                Location = "westus",
                Properties = new DeploymentWhatIfProperties
                {
                    Mode = DeploymentMode.Complete,
                    TemplateLink = new TemplateLink
                    {
                        Uri = "https://example.com",
                        ContentVersion = "1.0.0.0"
                    },
                    ParametersLink = new ParametersLink
                    {
                        Uri = "https://example.com/parameters",
                        ContentVersion = "1.0.0.0"
                    },
                    Template = JObject.Parse("{ '$schema': 'fake' }"),
                    Parameters = new Dictionary<string, object>
                    {
                        ["param1"] = "foo",
                        ["param2"] = new Dictionary<string, object>
                        {
                            ["param2_1"] = 123,
                            ["param2_2"] = "bar"
                        }
                    }
                }
            };

            using (ResourceManagementClient client = CreateResourceManagementClient(handler))
            {
                // Act.
                client.Deployments.WhatIfAtManagementGroupScope("test-mg", "test-mg-deploy", deploymentWhatIf);
            }

            // Assert.
            JObject resultJson = JObject.Parse(handler.Request);
            Assert.Equal("westus", resultJson["location"]);
            Assert.Equal("Complete", resultJson["properties"]["mode"]);
            Assert.Equal("https://example.com", resultJson["properties"]["templateLink"]["uri"]);
            Assert.Equal("1.0.0.0", resultJson["properties"]["templateLink"]["contentVersion"]);
            Assert.Equal("https://example.com/parameters", resultJson["properties"]["parametersLink"]["uri"]);
            Assert.Equal("1.0.0.0", resultJson["properties"]["parametersLink"]["contentVersion"]);
            Assert.Equal(JObject.Parse("{ '$schema': 'fake' }"), resultJson["properties"]["template"]);
            Assert.Equal("foo", resultJson["properties"]["parameters"]["param1"]);
            Assert.Equal(123, resultJson["properties"]["parameters"]["param2"]["param2_1"]);
            Assert.Equal("bar", resultJson["properties"]["parameters"]["param2"]["param2_2"]);
        }

        [Theory]
        [InlineData(@"{
            '$schema': 'http://schema.management.azure.com/schemas/2015-01-01/deploymentParameters.json#',
            'contentVersion': '1.0.0.0',
            'parameters': {
                'roleDefName': {
                   'value': 'myCustomRole'
                }
            }
        }")]
        [InlineData(@"{
            'roleDefName': {
                'value': 'myCustomRole'
            }
        }")]
        public void WhatIfAtManagementGroupScope_SendingRequestWithStrings_SerializesPayload(string parameterContent)
        {
            // Arrange.
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
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
            }";

        var deploymentWhatIf = new ScopedDeploymentWhatIf
            {
                Location = "westus",
                Properties = new DeploymentWhatIfProperties
                {
                    Mode = DeploymentMode.Incremental,
                    Template = templateContent,
                    Parameters = parameterContent
                }
            };

            using (ResourceManagementClient client = CreateResourceManagementClient(handler))
            {
                // Act.
                client.Deployments.WhatIfAtManagementGroupScope("test-mg", "test-mg-deploy", deploymentWhatIf);
            }

            // Assert.
            JObject resultJson = JObject.Parse(handler.Request);
            Assert.Equal("Incremental", resultJson["properties"]["mode"]);
            Assert.Equal("1.0.0.0", resultJson["properties"]["template"]["contentVersion"]);
            Assert.Equal("myCustomRole", resultJson["properties"]["parameters"]["roleDefName"]["value"]);
        }

        [Fact]
        public void WhatIfAtManagementGroupScope_ReceivingResponse_DeserializesResult()
        {
            // Arrange.
            var deploymentWhatIf = new ScopedDeploymentWhatIf("westus", new DeploymentWhatIfProperties());
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'status': 'Succeeded',
                    'properties': {
                        'changes': [
                            {
                                'resourceId': '/providers/Microsoft.Management/managementGroups/myManagementGroup/providers/Microsoft.Authorization/policyDefinitions/testDef',
                                'changeType': 'Create',
                                'after': {
                                    'apiVersion': '2018-03-01',
                                    'id': '/providers/Microsoft.Management/managementGroups/myManagementGroup/providers/Microsoft.Authorization/policyDefinitions/testDef',
                                    'type': 'Microsoft.Authorization/policyDefinitions',
                                    'name': 'testDef'
                                }
                            }
                        ]
                    }
                }")
            };
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            using (ResourceManagementClient client = CreateResourceManagementClient(handler))
            {
                // Act.
                WhatIfOperationResult result =
                    client.Deployments.WhatIfAtManagementGroupScope("test-mg", "test-mg-deploy", deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.Equal(1, result.Changes.Count);

                WhatIfChange change = result.Changes[0];
                Assert.Equal(ChangeType.Create, change.ChangeType);

                Assert.Null(change.Before);
                Assert.Null(change.Delta);

                Assert.NotNull(change.After);
                Assert.Equal("testDef", JToken.FromObject(change.After)["name"]);
            }
        }

        [Fact]
        public void WhatIfAtTenantScope_SendingRequest_SetsHeaders()
        {
            // Arrange.
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var deploymentWhatIf = new ScopedDeploymentWhatIf("westus", new DeploymentWhatIfProperties());

            using (ResourceManagementClient client = CreateResourceManagementClient(handler))
            {
                // Act.
                client.Deployments.WhatIfAtTenantScope("test-tenant-deploy", deploymentWhatIf);
            }

            // Assert.
            Assert.Equal("application/json; charset=utf-8", handler.ContentHeaders.GetValues("Content-Type").First());
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
        }

        [Fact]
        public void WhatIfAtTenantScope_SendingRequest_SerializesPayload()
        {
            // Arrange.
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var deploymentWhatIf = new ScopedDeploymentWhatIf
            {
                Location = "westus",
                Properties = new DeploymentWhatIfProperties
                {
                    Mode = DeploymentMode.Complete,
                    TemplateLink = new TemplateLink
                    {
                        Uri = "https://example.com",
                        ContentVersion = "1.0.0.0"
                    },
                    ParametersLink = new ParametersLink
                    {
                        Uri = "https://example.com/parameters",
                        ContentVersion = "1.0.0.0"
                    },
                    Template = JObject.Parse("{ '$schema': 'fake' }"),
                    Parameters = new Dictionary<string, object>
                    {
                        ["param1"] = "foo",
                        ["param2"] = new Dictionary<string, object>
                        {
                            ["param2_1"] = 123,
                            ["param2_2"] = "bar"
                        }
                    }
                }
            };

            using (ResourceManagementClient client = CreateResourceManagementClient(handler))
            {
                // Act.
                client.Deployments.WhatIfAtTenantScope("test-tenant-deploy", deploymentWhatIf);
            }

            // Assert.
            JObject resultJson = JObject.Parse(handler.Request);
            Assert.Equal("westus", resultJson["location"]);
            Assert.Equal("Complete", resultJson["properties"]["mode"]);
            Assert.Equal("https://example.com", resultJson["properties"]["templateLink"]["uri"]);
            Assert.Equal("1.0.0.0", resultJson["properties"]["templateLink"]["contentVersion"]);
            Assert.Equal("https://example.com/parameters", resultJson["properties"]["parametersLink"]["uri"]);
            Assert.Equal("1.0.0.0", resultJson["properties"]["parametersLink"]["contentVersion"]);
            Assert.Equal(JObject.Parse("{ '$schema': 'fake' }"), resultJson["properties"]["template"]);
            Assert.Equal("foo", resultJson["properties"]["parameters"]["param1"]);
            Assert.Equal(123, resultJson["properties"]["parameters"]["param2"]["param2_1"]);
            Assert.Equal("bar", resultJson["properties"]["parameters"]["param2"]["param2_2"]);
        }

        [Theory]
        [InlineData(@"{
            '$schema': 'http://schema.management.azure.com/schemas/2015-01-01/deploymentParameters.json#',
            'contentVersion': '1.0.0.0',
            'parameters': {
                'roleDefName': {
                   'value': 'myCustomRole'
                }
            }
        }")]
        [InlineData(@"{
            'roleDefName': {
                'value': 'myCustomRole'
            }
        }")]
        public void WhatIfAtTenantScope_SendingRequestWithStrings_SerializesPayload(string parameterContent)
        {
            // Arrange.
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
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
            }";

            var deploymentWhatIf = new ScopedDeploymentWhatIf
            {
                Location = "westus",
                Properties = new DeploymentWhatIfProperties
                {
                    Mode = DeploymentMode.Incremental,
                    Template = templateContent,
                    Parameters = parameterContent
                }
            };

            using (ResourceManagementClient client = CreateResourceManagementClient(handler))
            {
                // Act.
                client.Deployments.WhatIfAtTenantScope("test-tenant-deploy", deploymentWhatIf);
            }

            // Assert.
            JObject resultJson = JObject.Parse(handler.Request);
            Assert.Equal("Incremental", resultJson["properties"]["mode"]);
            Assert.Equal("1.0.0.0", resultJson["properties"]["template"]["contentVersion"]);
            Assert.Equal("myCustomRole", resultJson["properties"]["parameters"]["roleDefName"]["value"]);
        }

        [Fact]
        public void WhatIfAtTenantScope_ReceivingResponse_DeserializesResult()
        {
            // Arrange.
            var deploymentWhatIf = new ScopedDeploymentWhatIf("westus", new DeploymentWhatIfProperties());
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'status': 'Succeeded',
                    'properties': {
                        'changes': [
                            {
                                'resourceId': '/providers/Microsoft.Management/managementGroups/myManagementGroup',
                                'changeType': 'Create',
                                'after': {
                                    'apiVersion': '2018-03-01',
                                    'id': '/providers/Microsoft.Management/managementGroups/myManagementGroup',
                                    'type': 'Microsoft.Management/managementGroup',
                                    'name': 'myManagementGroup'
                                }
                            }
                        ]
                    }
                }")
            };
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            using (ResourceManagementClient client = CreateResourceManagementClient(handler))
            {
                // Act.
                WhatIfOperationResult result =
                    client.Deployments.WhatIfAtTenantScope("test-tenent-deploy", deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.Equal(1, result.Changes.Count);

                WhatIfChange change = result.Changes[0];
                Assert.Equal(ChangeType.Create, change.ChangeType);

                Assert.Null(change.Before);
                Assert.Null(change.Delta);

                Assert.NotNull(change.After);
                Assert.Equal("myManagementGroup", JToken.FromObject(change.After)["name"]);
            }
        }

        private static ResourceManagementClient CreateResourceManagementClient(DelegatingHandler handler)
        {
            string subscriptionId = Guid.NewGuid().ToString();
            var token = new TokenCredentials(subscriptionId, "foo");

            return new ResourceManagementClient(token, handler) { SubscriptionId = subscriptionId };
        }
    }
}
