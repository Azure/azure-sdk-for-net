// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json.Linq;
using System.Linq;
using Xunit;

namespace Policy.Tests
{
    using System;
    using System.Diagnostics;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;

    public class LivePolicyTests : TestBase
    {
        [Fact]
        public void CanCrudPolicyDefinition()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // First, create with minimal properties
                var policyName = TestUtilities.GenerateName();
                var policyDefinition = new PolicyDefinition
                {
                    DisplayName = "CanCrudPolicyDefinition Policy",
                    PolicyRule = JToken.Parse(
                        @"{
                            ""if"": {
                                ""source"": ""action"",
                                ""equals"": ""ResourceProviderTestHost/TestResourceType/TestResourceTypeNestedOne/write""
                            },
                            ""then"": {
                                ""effect"": ""deny""
                            }
                        }")
                };
                
                var result = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: policyName, parameters: policyDefinition);
                Assert.NotNull(result);

                var getResult = client.PolicyDefinitions.Get(policyName);
                Assert.Equal(policyName, getResult.Name);
                Assert.Equal(policyDefinition.DisplayName, getResult.DisplayName);
                Assert.Equal(policyDefinition.PolicyRule, getResult.PolicyRule);
                Assert.Equal("Custom", getResult.PolicyType);
                Assert.Null(getResult.Mode);
                Assert.Null(getResult.Description);
                Assert.Null(getResult.Metadata);
                Assert.Null(getResult.Parameters);

                var listResult = client.PolicyDefinitions.List();
                Assert.NotEmpty(listResult);
                var policyInList = listResult.FirstOrDefault(p => p.Name.Equals(policyName));
                Assert.NotNull(policyInList);
                Assert.Equal(policyDefinition.DisplayName, policyInList.DisplayName);
                Assert.Equal(policyDefinition.PolicyRule, policyInList.PolicyRule);

                // Update with all properties
                policyDefinition.Description = "Description text";
                policyDefinition.Metadata = JToken.Parse(@"{ 'category': 'sdk test' }");
                policyDefinition.Mode = "All";
                policyDefinition.DisplayName = "Updated CanCrudPolicyDefinition Policy";

                result = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: policyName, parameters: policyDefinition);
                Assert.NotNull(result);

                getResult = client.PolicyDefinitions.Get(policyName);
                Assert.Equal(policyName, getResult.Name);
                Assert.Equal(policyDefinition.DisplayName, getResult.DisplayName);
                Assert.Equal(policyDefinition.PolicyRule, getResult.PolicyRule);
                Assert.Equal("Custom", getResult.PolicyType);
                Assert.Equal("All", getResult.Mode);
                Assert.Equal(policyDefinition.Description, getResult.Description);
                Assert.Equal(policyDefinition.Metadata, getResult.Metadata);
                Assert.Null(getResult.Parameters);

                // Delete
                client.PolicyDefinitions.Delete(policyName);
                Assert.Throws<CloudException>(() => client.PolicyDefinitions.Get(policyName));
                listResult = client.PolicyDefinitions.List();
                Assert.Equal(0, listResult.Count(p => p.Name.Equals(policyName)));

                // Add one with parameters
                policyDefinition.Parameters = JToken.Parse(@"{ 'foo': { 'type': 'String' } }");
                policyDefinition.PolicyRule = JToken.Parse(
                    @"{
                            ""if"": {
                                ""source"": ""action"",
                                ""equals"": ""[parameters('foo')]""
                            },
                            ""then"": {
                                ""effect"": ""deny""
                            }
                    }");

                result = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: policyName, parameters: policyDefinition);
                Assert.NotNull(result);

                getResult = client.PolicyDefinitions.Get(policyName);
                Assert.Equal(policyName, getResult.Name);
                Assert.Equal(policyDefinition.Parameters.ToString(), getResult.Parameters.ToString());

                // Delete
                client.PolicyDefinitions.Delete(policyName);
                Assert.Throws<CloudException>(() => client.PolicyDefinitions.Get(policyName));
                listResult = client.PolicyDefinitions.List();
                Assert.Equal(0, listResult.Count(p => p.Name.Equals(policyName)));
            }
        }

        [Fact]
        public void CanCrudPolicySetDefinition()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // Add a definition that can be referenced
                var definitionName = TestUtilities.GenerateName();
                var policyDefinition = new PolicyDefinition
                {
                    DisplayName = "CanCrudPolicySetDefinition Policy Definition",
                    PolicyRule = JToken.Parse(
                        @"{
                            ""if"": {
                                ""source"": ""action"",
                                ""equals"": ""ResourceProviderTestHost/TestResourceType/TestResourceTypeNestedOne/write""
                            },
                            ""then"": {
                                ""effect"": ""deny""
                            }
                        }")
                };

                var definitionResult = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: definitionName, parameters: policyDefinition);
                Assert.NotNull(definitionResult);

                // First, create with minimal properties
                var setName = TestUtilities.GenerateName();
                var policySet = new PolicySetDefinition
                {
                    DisplayName = "CanCrudPolicySetDefinition Policy Set Definition",
                    PolicyDefinitions = new [] { new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id) }
                };

                var result = client.PolicySetDefinitions.CreateOrUpdate(setName, policySet);
                Assert.NotNull(result);

                var getResult = client.PolicySetDefinitions.Get(setName);
                Assert.Equal(setName, getResult.Name);
                Assert.Equal(policySet.DisplayName, getResult.DisplayName);
                Assert.Equal(1, getResult.PolicyDefinitions.Count);
                Assert.Single(getResult.PolicyDefinitions, policyRef => policyRef.PolicyDefinitionId.Equals(definitionResult.Id));
                Assert.Null(getResult.Description);
                Assert.Null(getResult.Metadata);
                Assert.Null(getResult.Parameters);
                Assert.Equal("Custom", getResult.PolicyType);

                var listResult = client.PolicySetDefinitions.List();
                Assert.NotEmpty(listResult);
                var policyInList = listResult.FirstOrDefault(p => p.Name.Equals(setName));
                Assert.NotNull(policyInList);
                Assert.Equal(policySet.DisplayName, policyInList.DisplayName);
                Assert.Equal(1, getResult.PolicyDefinitions.Count);
                Assert.Single(policyInList.PolicyDefinitions, policyRef => policyRef.PolicyDefinitionId.Equals(definitionResult.Id));

                // Update with all properties
                policySet.Description = "Description text";
                policySet.Metadata = JToken.Parse(@"{ 'category': 'sdk test' }");
                policySet.DisplayName = "Updated CanCrudPolicySetDefinition Policy Set Definition";
                policySet.PolicyDefinitions = new[]
                {
                    new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id),
                    new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id)
                };

                result = client.PolicySetDefinitions.CreateOrUpdate(setName, policySet);
                Assert.NotNull(result);

                getResult = client.PolicySetDefinitions.Get(setName);
                Assert.Equal(setName, getResult.Name);
                Assert.Equal(policySet.DisplayName, getResult.DisplayName);
                Assert.Equal(2, getResult.PolicyDefinitions.Count);
                Assert.True(getResult.PolicyDefinitions.All(policyRef => policyRef.PolicyDefinitionId.Equals(definitionResult.Id)));
                Assert.Equal(policySet.Description, getResult.Description);
                Assert.Equal(policySet.Metadata, getResult.Metadata);
                Assert.Null(getResult.Parameters);
                Assert.Equal("Custom", getResult.PolicyType);

                // Delete
                client.PolicySetDefinitions.Delete(setName);
                Assert.Throws<ErrorResponseException>(() => client.PolicySetDefinitions.Get(setName));
                listResult = client.PolicySetDefinitions.List();
                Assert.Equal(0, listResult.Count(p => p.Name.Equals(setName)));

                // Add one with parameters
                policyDefinition.Parameters = JToken.Parse(@"{ 'foo': { 'type': 'String' } }");
                policyDefinition.PolicyRule = JToken.Parse(
                    @"{
                            ""if"": {
                                ""source"": ""action"",
                                ""equals"": ""[parameters('foo')]""
                            },
                            ""then"": {
                                ""effect"": ""deny""
                            }
                    }");

                client.PolicyDefinitions.Delete(definitionName);
                definitionResult = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: definitionName, parameters: policyDefinition);
                Assert.NotNull(definitionResult);

                policySet = new PolicySetDefinition
                {
                    DisplayName = "CanCrudPolicySetDefinition Policy Set Definition",
                    PolicyDefinitions = new[]
                    {
                        new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id, parameters: JToken.Parse(@"{ 'foo': { 'value': ""[parameters('fooSet')]"" }}"))
                    },
                    Parameters = JToken.Parse(@"{ 'fooSet': { 'type': 'String' } }")
                };

                result = client.PolicySetDefinitions.CreateOrUpdate(setName, policySet);
                Assert.NotNull(result);

                getResult = client.PolicySetDefinitions.Get(setName);
                Assert.Equal(policySet.Parameters.ToString(), getResult.Parameters.ToString());
                Assert.Equal(1, getResult.PolicyDefinitions.Count);
                Assert.Single(policyInList.PolicyDefinitions, policyRef => policyRef.PolicyDefinitionId.Equals(definitionResult.Id));
                Assert.Equal(policySet.PolicyDefinitions[0].Parameters.ToString(), getResult.PolicyDefinitions[0].Parameters.ToString());

                // Delete
                client.PolicySetDefinitions.Delete(setName);
                Assert.Throws<ErrorResponseException>(() => client.PolicySetDefinitions.Get(setName));
                listResult = client.PolicySetDefinitions.List();
                Assert.Equal(0, listResult.Count(p => p.Name.Equals(setName)));
                client.PolicyDefinitions.Delete(definitionName);
            }
        }

        [Fact]
        public void CanCrudPolicyAssignment()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // Add a definition that can be assigned
                var definitionName = TestUtilities.GenerateName();
                var policyDefinition = new PolicyDefinition
                {
                    DisplayName = "CanCrudPolicyDefinition Policy Definition",
                    PolicyRule = JToken.Parse(
                        @"{
                            ""if"": {
                                ""source"": ""action"",
                                ""equals"": ""ResourceProviderTestHost/TestResourceType/TestResourceTypeNestedOne/write""
                            },
                            ""then"": {
                                ""effect"": ""deny""
                            }
                        }")
                };

                var definitionResult = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: definitionName, parameters: policyDefinition);
                Assert.NotNull(definitionResult);

                // First, create with minimal properties
                var assignmentName = TestUtilities.GenerateName();
                var assignmentScope = "/subscriptions/" + client.SubscriptionId;
                var policyAssignment = new PolicyAssignment
                {
                    DisplayName = "CanCrudPolicyDefinition Policy Assignment",
                    PolicyDefinitionId = definitionResult.Id,
                    Sku = new PolicySku("A0", "Free")
                };

                var result = client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment);
                Assert.NotNull(result);

                var getResult = client.PolicyAssignments.Get(assignmentScope, assignmentName);
                Assert.Equal(assignmentName, getResult.Name);
                Assert.Equal(policyAssignment.DisplayName, getResult.DisplayName);
                Assert.Equal(policyAssignment.PolicyDefinitionId, getResult.PolicyDefinitionId);
                Assert.Equal(assignmentScope, getResult.Scope);
                Assert.Equal(policyAssignment.Sku.Name, getResult.Sku.Name);
                Assert.Equal(policyAssignment.Sku.Tier, getResult.Sku.Tier);
                Assert.Null(getResult.NotScopes);
                Assert.Null(getResult.Description);
                Assert.Null(getResult.Metadata);
                Assert.Null(getResult.Parameters);

                var listResult = client.PolicyAssignments.List();
                Assert.NotEmpty(listResult);
                var policyInList = listResult.FirstOrDefault(p => p.Name.Equals(assignmentName));
                Assert.NotNull(policyInList);
                Assert.Equal(policyAssignment.DisplayName, policyInList.DisplayName);
                Assert.Equal(policyAssignment.PolicyDefinitionId, policyInList.PolicyDefinitionId);

                // Update with all properties
                policyAssignment.Description = "Description text";
                policyAssignment.Metadata = JToken.Parse(@"{ 'category': 'sdk test' }");
                policyAssignment.DisplayName = "Updated CanCrudPolicyDefinition Policy Assignment";
                policyAssignment.Sku = new PolicySku("A1", "Standard");

                result = client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment);
                Assert.NotNull(result);

                getResult = client.PolicyAssignments.GetById(result.Id);
                Assert.Equal(assignmentName, getResult.Name);
                Assert.Equal(policyAssignment.DisplayName, getResult.DisplayName);
                Assert.Equal(policyAssignment.PolicyDefinitionId, getResult.PolicyDefinitionId);
                Assert.Equal(assignmentScope, getResult.Scope);
                Assert.Equal(policyAssignment.Sku.Name, getResult.Sku.Name);
                Assert.Equal(policyAssignment.Sku.Tier, getResult.Sku.Tier);
                Assert.Equal(policyAssignment.Description, getResult.Description);
                Assert.Equal(policyAssignment.Metadata, getResult.Metadata);

                // Delete
                client.PolicyAssignments.Delete(assignmentScope, assignmentName);
                Assert.Throws<ErrorResponseException>(() => client.PolicyAssignments.Get(assignmentScope, assignmentName));
                listResult = client.PolicyAssignments.List();
                Assert.Equal(0, listResult.Count(p => p.Name.Equals(assignmentName)));
                client.PolicyDefinitions.Delete(definitionName);
            }
        }

        [Fact]
        public void ValidatePolicyAssignmentErrorHandling()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // Add a definition that can be assigned
                var definitionName = TestUtilities.GenerateName();
                var policyDefinition = new PolicyDefinition
                {
                    DisplayName = "CanCrudPolicyDefinition Policy Definition",
                    PolicyRule = JToken.Parse(
                        @"{
                            ""if"": {
                                ""source"": ""action"",
                                ""equals"": ""ResourceProviderTestHost/TestResourceType/TestResourceTypeNestedOne/write""
                            },
                            ""then"": {
                                ""effect"": ""deny""
                            }
                        }")
                };

                var definitionResult = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: definitionName, parameters: policyDefinition);
                Assert.NotNull(definitionResult);

                // Missing policy definition id
                var assignmentName = TestUtilities.GenerateName();
                var assignmentScope = "/subscriptions/" + client.SubscriptionId;
                var policyAssignment = new PolicyAssignment
                {
                    DisplayName = "Invalid Assignment",
                    Sku = new PolicySku("A0", "Free")
                };

                
                var exception = this.CatchAndReturn<ErrorResponseException>(() => client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment));
                Assert.Contains("InvalidRequestContent", exception.Response.Content);

                // Invalid policy definition id
                policyAssignment = new PolicyAssignment
                {
                    DisplayName = "Invalid Assignment",
                    Sku = new PolicySku("A0", "Free"),
                    PolicyDefinitionId = definitionResult.Id.Replace(definitionName, TestUtilities.GenerateName())
                };


                exception = this.CatchAndReturn<ErrorResponseException>(() => client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment));
                Assert.Contains("PolicyDefinitionNotFound", exception.Response.Content);

                // Invalid SKU
                policyAssignment = new PolicyAssignment
                {
                    DisplayName = "Invalid Assignment",
                    Sku = new PolicySku("A2", "Free"),
                    PolicyDefinitionId = definitionResult.Id
                };


                exception = this.CatchAndReturn<ErrorResponseException>(() => client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment));
                Assert.Contains("InvalidPolicySku", exception.Response.Content);

                // Delete
                client.PolicyDefinitions.Delete(definitionName);
            }
        }

        [Fact]
        public void ValidatePolicyDefinitionErrorHandling()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // Missing rule
                var definitionName = TestUtilities.GenerateName();
                var policyDefinition = new PolicyDefinition
                {
                    DisplayName = "Invalid Definition"
                };


                var exception = this.CatchAndReturn<CloudException>(() => client.PolicyDefinitions.CreateOrUpdate(definitionName, policyDefinition));
                Assert.Contains("InvalidRequestContent", exception.Response.Content);

                // Invalid Mode
                policyDefinition = new PolicyDefinition
                {
                    DisplayName = "Invalid Definition",
                    Mode = "Foo",
                    PolicyRule = JToken.Parse(
                        @"{
                            ""if"": {
                                ""source"": ""action"",
                                ""equals"": ""ResourceProviderTestHost/TestResourceType/TestResourceTypeNestedOne/write""
                            },
                            ""then"": {
                                ""effect"": ""deny""
                            }
                        }")
                };


                exception = this.CatchAndReturn<CloudException>(() => client.PolicyDefinitions.CreateOrUpdate(definitionName, policyDefinition));
                Assert.Contains("InvalidRequestContent", exception.Response.Content);

                // Unused parameter
                policyDefinition = new PolicyDefinition
                {
                    DisplayName = "Invalid Definition",
                    Parameters = JToken.Parse(@"{ 'foo': { 'type': 'String' } }"),
                    PolicyRule = JToken.Parse(
                        @"{
                            ""if"": {
                                ""source"": ""action"",
                                ""equals"": ""ResourceProviderTestHost/TestResourceType/TestResourceTypeNestedOne/write""
                            },
                            ""then"": {
                                ""effect"": ""deny""
                            }
                        }")
                };


                exception = this.CatchAndReturn<CloudException>(() => client.PolicyDefinitions.CreateOrUpdate(definitionName, policyDefinition));
                Assert.Contains("UnusedPolicyParameters", exception.Response.Content);

                // Missing parameter
                policyDefinition = new PolicyDefinition
                {
                    DisplayName = "Invalid Definition",
                    PolicyRule = JToken.Parse(
                        @"{
                            ""if"": {
                                ""source"": ""action"",
                                ""equals"": ""[parameters('foo')]""
                            },
                            ""then"": {
                                ""effect"": ""deny""
                            }
                        }")
                };


                exception = this.CatchAndReturn<CloudException>(() => client.PolicyDefinitions.CreateOrUpdate(definitionName, policyDefinition));
                Assert.Contains("InvalidPolicyParameters", exception.Response.Content);
            }
        }

        [Fact]
        public void ValidatePolicySetDefinitionErrorHandling()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // Add a definition that can be assigned
                var definitionName = TestUtilities.GenerateName();
                var policyDefinition = new PolicyDefinition
                {
                    DisplayName = "Test Policy Definition",
                    PolicyRule = JToken.Parse(
                        @"{
                            ""if"": {
                                ""source"": ""action"",
                                ""equals"": ""ResourceProviderTestHost/TestResourceType/TestResourceTypeNestedOne/write""
                            },
                            ""then"": {
                                ""effect"": ""deny""
                            }
                        }")
                };

                var definitionResult = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: definitionName, parameters: policyDefinition);
                Assert.NotNull(definitionResult);

                // Missing definition references
                var setName = TestUtilities.GenerateName();
                var policySetDefinition = new PolicySetDefinition
                {
                    DisplayName = "Invalid Set Definition"
                };


                var validationException = this.CatchAndReturn<ValidationException>(() => client.PolicySetDefinitions.CreateOrUpdate(setName, policySetDefinition));
                Assert.Contains("PolicyDefinitions", validationException.Target);

                // Invalid definition reference
                policySetDefinition = new PolicySetDefinition
                {
                    DisplayName = "Invalid Set Definition",
                    PolicyDefinitions = new[]
                    {
                        new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id.Replace(definitionName, TestUtilities.GenerateName()))
                    }
                };


                var exception = this.CatchAndReturn<ErrorResponseException>(() => client.PolicySetDefinitions.CreateOrUpdate(setName, policySetDefinition));
                Assert.Contains("PolicyDefinitionNotFound", exception.Response.Content);

                // Unused parameter
                policySetDefinition = new PolicySetDefinition
                {
                    DisplayName = "Invalid Set Definition",
                    Parameters = JToken.Parse(@"{ 'foo': { 'type': 'String' } }"),
                    PolicyDefinitions = new[]
                    {
                        new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id)
                    }
                };


                exception = this.CatchAndReturn<ErrorResponseException>(() => client.PolicySetDefinitions.CreateOrUpdate(setName, policySetDefinition));
                Assert.Contains("UnusedPolicyParameters", exception.Response.Content);

                // Invalid reference parameters
                policySetDefinition = new PolicySetDefinition
                {
                    DisplayName = "Invalid Set Definition",
                    PolicyDefinitions = new[]
                    {
                        new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id, parameters: JToken.Parse(@"{ 'foo': { 'value': 'abc' } }"))
                    }
                };


                exception = this.CatchAndReturn<ErrorResponseException>(() => client.PolicySetDefinitions.CreateOrUpdate(setName, policySetDefinition));
                Assert.Contains("UndefinedPolicyParameter", exception.Response.Content);

                client.PolicyDefinitions.Delete(definitionName);
            }
        }

        private T CatchAndReturn<T>(Action testCode) where T : Exception
        {
            try
            {
                testCode();
            }
            catch (T ex)
            {
                return ex;
            }

            Assert.True(false, "Exception should have been thrown");
            return null;
        }
    }
}
