// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Policy.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using Microsoft.Azure.Management.ManagementGroups;
    using Microsoft.Azure.Management.ManagementGroups.Models;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Newtonsoft.Json.Linq;
    using Resource.Tests.Helpers;
    using ResourceGroups.Tests;
    using Xunit;

    /// <summary>
    /// Policy entity test cases
    /// </summary>
    /// <remarks>
    /// Recorded with the following (secret masked):
    /// TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId=f67cc918-f64f-4c3f-aa24-a855465f9d41;ServicePrincipal=20f84e2b-2ca6-4035-a118-6105027fce93;ServicePrincipalSecret=***hidden***;AADTenant=72f988bf-86f1-41af-91ab-2d7cd011db47;Environment=Prod;
    /// The above service principal maps to the "cheggSDKTests" application in the Microsoft AAD tenant.
    /// </remarks>
    public class LivePolicyTests : TestBase
    {
        /// <summary>
        /// The management group that will be used as a parent for any management groups created during the test
        /// </summary>
        private const string ParentManagementGroup = "AzGovPerfTest";

        [Fact]
        public void CanCrudPolicyDefinition()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // First, create with minimal properties
                var policyName = TestUtilities.GenerateName();
                var thisTestName = TestUtilities.GetCurrentMethodName();
                var policyDefinition = this.CreatePolicyDefinition($"{thisTestName} Policy Definition ${LivePolicyTests.NameTag}");

                var result = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: policyName, parameters: policyDefinition);
                Assert.NotNull(result);

                // Validate result
                var getResult = client.PolicyDefinitions.Get(policyName);
                this.AssertValid(policyName, policyDefinition, getResult, false);
                this.AssertMinimal(getResult);

                var listResult = client.PolicyDefinitions.List();
                this.AssertInList(policyName, policyDefinition, listResult);

                // Update with all properties
                this.UpdatePolicyDefinition(policyDefinition);

                result = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: policyName, parameters: policyDefinition);
                Assert.NotNull(result);

                // Validate result
                getResult = client.PolicyDefinitions.Get(policyName);
                this.AssertValid(policyName, policyDefinition, getResult, false);

                Assert.Equal("All", getResult.Mode);
                Assert.Null(getResult.Parameters);

                // Delete definition and validate
                this.DeleteDefinitionAndValidate(client, policyName);

                // Create definition with parameters
                policyDefinition = this.CreatePolicyDefinitionWithParameters(policyName);

                result = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: policyName, parameters: policyDefinition);
                Assert.NotNull(result);

                // Validate result
                getResult = client.PolicyDefinitions.Get(policyName);
                this.AssertValid(policyName, policyDefinition, getResult, false);

                // Delete definition and validate
                this.DeleteDefinitionAndValidate(client, policyName);
            }
        }

        [Fact]
        public void CanCrudDataPlanePolicyDefinition()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // First, create with minimal properties
                var policyName = TestUtilities.GenerateName();
                var thisTestName = TestUtilities.GetCurrentMethodName();
                var policyDefinition = this.CreateDataPlanePolicyDefinition($"{thisTestName} Policy Definition ${LivePolicyTests.NameTag}");

                var result = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: policyName, parameters: policyDefinition);
                Assert.NotNull(result);

                // Validate result
                var getResult = client.PolicyDefinitions.Get(policyName);
                Assert.NotNull(policyDefinition);
                Assert.NotNull(policyDefinition.Mode);
                Assert.Null(policyDefinition.Description);
                Assert.Null(policyDefinition.Parameters);                
                this.AssertValid(policyName, policyDefinition, getResult, false);                

                var listResult = client.PolicyDefinitions.List();
                this.AssertInList(policyName, policyDefinition, listResult);

                // Update definition
                policyDefinition.DisplayName = "Audit certificates that are not protected by RSA - v2";

                result = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: policyName, parameters: policyDefinition);
                Assert.NotNull(result);

                // Validate result
                getResult = client.PolicyDefinitions.Get(policyName);
                this.AssertValid(policyName, policyDefinition, getResult, false);

                Assert.Equal("Microsoft.DataCatalog.Data", getResult.Mode);
                Assert.Null(getResult.Parameters);

                // Delete definition and validate
                this.DeleteDefinitionAndValidate(client, policyName);                               
            }
        }

        [Fact]
        public void CanCrudPolicySetDefinition()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // Add a definition that can be referenced
                var definitionName = TestUtilities.GenerateName();
                var thisTestName = TestUtilities.GetCurrentMethodName();
                var policyDefinition = this.CreatePolicyDefinition($"{thisTestName} Policy Definition ${LivePolicyTests.NameTag}");

                var definitionResult = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: definitionName, parameters: policyDefinition);
                Assert.NotNull(definitionResult);

                // First, create with minimal properties
                var setName = TestUtilities.GenerateName();
                var policySet = new PolicySetDefinition
                {
                    DisplayName = $"{thisTestName} Policy Set Definition ${LivePolicyTests.NameTag}",
                    PolicyDefinitions = new[] { new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id) }
                };

                var result = client.PolicySetDefinitions.CreateOrUpdate(setName, policySet);
                Assert.NotNull(result);

                // Validate result
                var getResult = client.PolicySetDefinitions.Get(setName);
                this.AssertValid(setName, policySet, getResult, false);
                Assert.Single(getResult.PolicyDefinitions);
                Assert.Null(getResult.Description);
                AssertMetadataValid(getResult.Metadata);
                Assert.Null(getResult.Parameters);
                Assert.Equal("Custom", getResult.PolicyType);

                var listResult = client.PolicySetDefinitions.List();
                this.AssertInList(setName, policySet, listResult);
                Assert.Single(getResult.PolicyDefinitions);

                // Update with extra properties
                policySet.Description = LivePolicyTests.BasicDescription;
                policySet.Metadata = LivePolicyTests.BasicMetadata;
                policySet.DisplayName = $"Updated {policySet.DisplayName}";

                // Add another definition that can be referenced (must be distinct from the first one to pass validation)
                const string refId = "refId2";
                var definitionName2 = TestUtilities.GenerateName();
                var definitionResult2 = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: definitionName2, parameters: policyDefinition);
                policySet.PolicyDefinitions = new[]
                {
                    new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id),
                    new PolicyDefinitionReference(policyDefinitionId: definitionResult2.Id, policyDefinitionReferenceId: refId)
                };

                result = client.PolicySetDefinitions.CreateOrUpdate(setName, policySet);
                Assert.NotNull(result);

                // validate result
                getResult = client.PolicySetDefinitions.Get(setName);
                this.AssertValid(setName, policySet, getResult, false);
                Assert.Equal(2, getResult.PolicyDefinitions.Count);
                Assert.Null(getResult.Parameters);
                Assert.Equal("Custom", getResult.PolicyType);
                Assert.Equal(1, getResult.PolicyDefinitions.Count(definition => refId.Equals(definition.PolicyDefinitionReferenceId, StringComparison.Ordinal)));

                // Delete and validate
                this.DeleteSetDefinitionAndValidate(client, setName);

                // Create a policy set with groups
                const string groupNameOne = "group1";
                const string groupNameTwo = "group2";
                policySet.PolicyDefinitionGroups = new List<PolicyDefinitionGroup> { new PolicyDefinitionGroup(groupNameOne), new PolicyDefinitionGroup(groupNameTwo) };
                policySet.PolicyDefinitions[0].GroupNames = new[] { groupNameOne, groupNameTwo };
                policySet.PolicyDefinitions[1].GroupNames = new[] { groupNameTwo };
                result = client.PolicySetDefinitions.CreateOrUpdate(setName, policySet);
                Assert.NotNull(result);
                this.AssertValid(setName, policySet, result, false);

                getResult = client.PolicySetDefinitions.Get(setName);
                this.AssertValid(setName, policySet, getResult, false);

                // Delete and validate everything
                this.DeleteSetDefinitionAndValidate(client, setName);
                this.DeleteDefinitionAndValidate(client, definitionName);
                this.DeleteDefinitionAndValidate(client, definitionName2);

                // create set definition with parameters
                policyDefinition = this.CreatePolicyDefinitionWithParameters(definitionName);
                definitionResult = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: definitionName, parameters: policyDefinition);
                Assert.NotNull(definitionResult);

                var referenceParameters = new Dictionary<string, ParameterValuesValue> { { "foo", new ParameterValuesValue("[parameters('fooSet')]") } };
                var policySetParameters = new Dictionary<string, ParameterDefinitionsValue> { { "fooSet", new ParameterDefinitionsValue(ParameterType.String) } };

                policySet = new PolicySetDefinition
                {
                    DisplayName = $"{thisTestName} Policy Set Definition ${LivePolicyTests.NameTag}",
                    PolicyDefinitions = new[]
                    {
                        new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id, parameters: referenceParameters)
                    },
                    Parameters = policySetParameters
                };

                result = client.PolicySetDefinitions.CreateOrUpdate(setName, policySet);
                Assert.NotNull(result);

                // validate result
                getResult = client.PolicySetDefinitions.Get(setName);
                this.AssertValid(setName, policySet, getResult, false);
                Assert.Single(getResult.PolicyDefinitions);

                // Delete everything and validate
                this.DeleteSetDefinitionAndValidate(client, setName);
                this.DeleteDefinitionAndValidate(client, definitionName);
            }
        }

        [Fact]
        public void CanCrudPolicyAssignment()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // create a definition that can be assigned
                var definitionName = TestUtilities.GenerateName();
                var thisTestName = TestUtilities.GetCurrentMethodName();
                var policyDefinition = this.CreatePolicyDefinition($"{thisTestName} Policy Definition ${LivePolicyTests.NameTag}");

                var definitionResult = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: definitionName, parameters: policyDefinition);
                Assert.NotNull(definitionResult);

                // First, create with minimal properties
                var assignmentName = TestUtilities.GenerateName();
                var assignmentScope = this.SubscriptionScope(client);
                var policyAssignment = new PolicyAssignment
                {
                    DisplayName = $"{thisTestName} Policy Assignment ${LivePolicyTests.NameTag}",
                    PolicyDefinitionId = definitionResult.Id,
                    Sku = LivePolicyTests.A0Free
                };

                var result = client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment);
                Assert.NotNull(result);

                // validate results
                var getResult = client.PolicyAssignments.Get(assignmentScope, assignmentName);

                // Default enforcement should be set even if not provided as input in PUT request.
                policyAssignment.EnforcementMode = EnforcementMode.Default;
                this.AssertValid(assignmentName, policyAssignment, getResult);
                Assert.Null(getResult.NotScopes);
                Assert.Null(getResult.Description);
                AssertMetadataValid(getResult.Metadata);
                Assert.Null(getResult.Parameters);
                Assert.Equal(EnforcementMode.Default, getResult.EnforcementMode);

                var listResult = client.PolicyAssignments.List();
                this.AssertInList(assignmentName, policyAssignment, listResult);

                // Update with extra properties
                policyAssignment.Description = LivePolicyTests.BasicDescription;
                policyAssignment.Metadata = LivePolicyTests.BasicMetadata;
                policyAssignment.DisplayName = $"Updated {policyAssignment.DisplayName}";
                policyAssignment.Sku = LivePolicyTests.A1Standard;
                policyAssignment.Location = "eastus";
                policyAssignment.Identity = new Identity(type: ResourceIdentityType.SystemAssigned);
                policyAssignment.EnforcementMode = EnforcementMode.DoNotEnforce;

                result = client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment);
                Assert.NotNull(result);

                // validate results
                getResult = client.PolicyAssignments.GetById(result.Id);
                this.AssertValid(assignmentName, policyAssignment, getResult);

                // Delete policy assignment and validate
                client.PolicyAssignments.Delete(assignmentScope, assignmentName);
                this.AssertThrowsCloudException(() => client.PolicyAssignments.Get(assignmentScope, assignmentName));
                listResult = client.PolicyAssignments.List();
                Assert.Empty(listResult.Where(p => p.Name.Equals(assignmentName)));

                // Create brand new assignment with identity
                assignmentName = TestUtilities.GenerateName();
                result = client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment);
                Assert.NotNull(result);

                // validate results
                getResult = client.PolicyAssignments.GetById(result.Id);
                this.AssertValid(assignmentName, policyAssignment, getResult);

                // Delete policy assignment and validate
                client.PolicyAssignments.Delete(assignmentScope, assignmentName);
                this.AssertThrowsCloudException(() => client.PolicyAssignments.Get(assignmentScope, assignmentName));
                listResult = client.PolicyAssignments.List();
                Assert.Empty(listResult.Where(p => p.Name.Equals(assignmentName)));

                // Delete policy definition and validate
                this.DeleteDefinitionAndValidate(client, definitionName);
            }
        }

        [Fact]
        public void CanCrudPolicyAssignmentAtResourceGroup()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();
                var resourceGroupClient = context.GetServiceClient<ResourceManagementClient>();
 
                // make a test resource group
                var resourceGroupName = TestUtilities.GenerateName();
                var resourceGroup = resourceGroupClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup("westus2"));

                // make a test policy definition
                var policyDefinitionName = TestUtilities.GenerateName();
                var thisTestName = TestUtilities.GetCurrentMethodName();
                var policyDefinitionModel = this.CreatePolicyDefinition($"{thisTestName} Policy Definition");
                var policyDefinition = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName, policyDefinitionModel);

                // assign the test policy definition to the test resource group
                var policyAssignmentName = TestUtilities.GenerateName();
                var assignmentScope = this.ResourceGroupScope(resourceGroup);
                var policyAssignment = new PolicyAssignment
                {
                    DisplayName = $"{thisTestName} Policy Assignment",
                    PolicyDefinitionId = policyDefinition.Id,
                    Scope = assignmentScope,
                    Sku = LivePolicyTests.A0Free
                };

                var assignment = client.PolicyAssignments.Create(assignmentScope, policyAssignmentName, policyAssignment);

                // retrieve list of policies that apply to this resource group, validate exactly one matches the one we just created
                var assignments = client.PolicyAssignments.ListForResourceGroup(resourceGroupName);
                Assert.Single(assignments.Where(assign => assign.Name.Equals(assignment.Name)));

                // get the same item at scope and ensure it matches
                var getAssignment = client.PolicyAssignments.Get(assignmentScope, assignment.Name);
                this.AssertEqual(assignment, getAssignment);

                // clean up everything
                client.PolicyAssignments.Delete(assignmentScope, assignment.Name);
                client.PolicyDefinitions.Delete(policyDefinition.Name);
                resourceGroupClient.ResourceGroups.Delete(resourceGroupName);
            }
        }

        [Fact]
        public void CanCrudPolicyAssignmentAtResource()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();
                var resourceManagementClient = context.GetServiceClient<ResourceManagementClient>();

                // make a test resource group
                var resourceGroupName = TestUtilities.GenerateName();
                var resourceGroup = resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup("eastus2"));

                // make a resource in the resource group
                var resourceName = TestUtilities.GenerateName();
                var resource = this.CreateResource(resourceManagementClient, resourceGroup, resourceName);

                // make a test policy definition
                var policyDefinitionName = TestUtilities.GenerateName();
                var thisTestName = TestUtilities.GetCurrentMethodName();
                var policyDefinitionModel = this.CreatePolicyDefinition($"{thisTestName} Policy Definition");
                var policyDefinition = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName, policyDefinitionModel);

                // assign the test policy definition to the test resource
                var policyAssignmentName = TestUtilities.GenerateName();
                var assignmentScope = this.ResourceScope(resource);
                var policyAssignment = new PolicyAssignment
                {
                    DisplayName = $"{thisTestName} Policy Assignment",
                    PolicyDefinitionId = policyDefinition.Id,
                    Scope = assignmentScope,
                    Sku = LivePolicyTests.A0Free
                };

                var assignment = client.PolicyAssignments.Create(assignmentScope, policyAssignmentName, policyAssignment);

                // retrieve list of policies that apply to this resource, validate exactly one matches the one we just created
                var assignments = client.PolicyAssignments.ListForResource(resourceGroup.Name, "", "", resource.Type, resource.Name);
                Assert.Single(assignments.Where(assign => assign.Name.Equals(assignment.Name)));

                // get the same item at scope and ensure it matches
                var getAssignment = client.PolicyAssignments.Get(assignmentScope, assignment.Name);
                this.AssertEqual(assignment, getAssignment);

                // clean up everything
                client.PolicyAssignments.Delete(assignmentScope, assignment.Name);
                client.PolicyDefinitions.Delete(policyDefinition.Name);
                resourceManagementClient.ResourceGroups.Delete(resourceGroupName);
            }
        }

        [Fact]
        public void CanCrudPolicyDefinitionAtManagementGroup()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();
                var delegatingHandler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context, delegatingHandler);

                // make a management group
                var managementGroupName = TestUtilities.GenerateName();
                var thisTestName = TestUtilities.GetCurrentMethodName();
                var managementGroup = this.CreateManagementGroup(managementGroupsClient, managementGroupName, thisTestName);

                // make a test policy definition at management group
                var policyDefinitionName = TestUtilities.GenerateName();
                var policyDefinitionModel = this.CreatePolicyDefinition($"{thisTestName} Policy Definition");
                var policyDefinition = client.PolicyDefinitions.CreateOrUpdateAtManagementGroup(policyDefinitionName, policyDefinitionModel, managementGroupName);
                Assert.NotNull(policyDefinition);

                // Validate result
                var getResult = client.PolicyDefinitions.GetAtManagementGroup(policyDefinitionName, managementGroupName);
                this.AssertValid(policyDefinitionName, policyDefinitionModel, getResult, false);
                this.AssertMinimal(getResult);

                var listResult = client.PolicyDefinitions.ListByManagementGroup(managementGroup.Name);
                this.AssertInList(policyDefinitionName, policyDefinitionModel, listResult);

                // Update with all properties
                this.UpdatePolicyDefinition(policyDefinitionModel);

                policyDefinition = client.PolicyDefinitions.CreateOrUpdateAtManagementGroup(policyDefinition.Name, policyDefinitionModel, managementGroup.Name);
                Assert.NotNull(policyDefinition);

                // Validate result
                getResult = client.PolicyDefinitions.GetAtManagementGroup(policyDefinition.Name, managementGroup.Name);
                this.AssertValid(policyDefinitionName, policyDefinitionModel, getResult, false);

                Assert.Equal("All", getResult.Mode);
                Assert.Null(getResult.Parameters);

                // clean up
                this.DeleteDefinitionAndValidate(client, policyDefinition.Name, managementGroup.Name);
                managementGroupsClient.ManagementGroups.Delete(managementGroup.Name);
            }
        }

        [Fact]
        public void CanCrudPolicySetDefinitionAtManagementGroup()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();
                var delegatingHandler = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context, delegatingHandler);

                // make a management group
                var managementGroupName = TestUtilities.GenerateName();
                var thisTestName = TestUtilities.GetCurrentMethodName();
                var managementGroup = this.CreateManagementGroup(managementGroupsClient, managementGroupName, thisTestName);

                // Add a definition that can be referenced
                var definitionName = TestUtilities.GenerateName();
                var policyDefinition = this.CreatePolicyDefinition($"{thisTestName} Policy Definition ${LivePolicyTests.NameTag}");

                var definitionResult = client.PolicyDefinitions.CreateOrUpdateAtManagementGroup(definitionName, policyDefinition, managementGroup.Name);
                Assert.NotNull(definitionResult);

                // First, create with minimal properties
                var setName = TestUtilities.GenerateName();
                var policySet = new PolicySetDefinition
                {
                    DisplayName = $"{thisTestName} Policy Set Definition ${LivePolicyTests.NameTag}",
                    PolicyDefinitions = new[] { new PolicyDefinitionReference(definitionResult.Id) }
                };

                var result = client.PolicySetDefinitions.CreateOrUpdateAtManagementGroup(setName, policySet, managementGroup.Name);
                Assert.NotNull(result);

                // Validate result
                var getResult = client.PolicySetDefinitions.GetAtManagementGroup(setName, managementGroup.Name);
                this.AssertValid(setName, policySet, getResult, false);
                Assert.Single(getResult.PolicyDefinitions);
                Assert.Null(getResult.Description);
                AssertMetadataValid(getResult.Metadata);
                Assert.Null(getResult.Parameters);
                Assert.Equal("Custom", getResult.PolicyType);

                var listResult = client.PolicySetDefinitions.ListByManagementGroup(managementGroup.Name);
                this.AssertInList(setName, policySet, listResult);

                // Update with extra properties
                policySet.Description = LivePolicyTests.BasicDescription;
                policySet.Metadata = LivePolicyTests.BasicMetadata;
                policySet.DisplayName = $"Updated {policySet.DisplayName}";

                // Add another definition that can be referenced (must be distinct from the first one to pass validation)
                var definitionName2 = TestUtilities.GenerateName();
                var definitionResult2 = client.PolicyDefinitions.CreateOrUpdateAtManagementGroup(definitionName2, policyDefinition, managementGroup.Name);
                policySet.PolicyDefinitions = new[]
                {
                    new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id),
                    new PolicyDefinitionReference(policyDefinitionId: definitionResult2.Id)
                };

                result = client.PolicySetDefinitions.CreateOrUpdateAtManagementGroup(setName, policySet, managementGroup.Name);
                Assert.NotNull(result);

                // validate result
                getResult = client.PolicySetDefinitions.GetAtManagementGroup(setName, managementGroup.Name);
                this.AssertValid(setName, policySet, getResult, false);
                Assert.Equal(2, getResult.PolicyDefinitions.Count);
                Assert.Null(getResult.Parameters);
                Assert.Equal("Custom", getResult.PolicyType);

                // Delete and validate everything
                this.DeleteSetDefinitionAndValidate(client, setName, managementGroup.Name);
                this.DeleteDefinitionAndValidate(client, definitionName, managementGroup.Name);
                this.DeleteDefinitionAndValidate(client, definitionName2, managementGroup.Name);

                // create definition with parameters
                policyDefinition = this.CreatePolicyDefinitionWithParameters(definitionName);
                definitionResult = client.PolicyDefinitions.CreateOrUpdateAtManagementGroup(definitionName, policyDefinition, managementGroup.Name);
                Assert.NotNull(definitionResult);

                var referenceParameters = new Dictionary<string, ParameterValuesValue> { { "foo", new ParameterValuesValue("[parameters('fooSet')]") } };
                var policySetParameters = new Dictionary<string, ParameterDefinitionsValue> { { "fooSet", new ParameterDefinitionsValue(ParameterType.String) } };

                policySet = new PolicySetDefinition
                {
                    DisplayName = $"{thisTestName} Policy Set Definition ${LivePolicyTests.NameTag}",
                    PolicyDefinitions = new[]
                    {
                        new PolicyDefinitionReference(definitionResult.Id, referenceParameters)
                    },
                    Parameters = policySetParameters
                };

                result = client.PolicySetDefinitions.CreateOrUpdateAtManagementGroup(setName, policySet, managementGroup.Name);
                Assert.NotNull(result);

                // validate result
                getResult = client.PolicySetDefinitions.GetAtManagementGroup(setName, managementGroup.Name);
                this.AssertValid(setName, policySet, getResult, false);
                Assert.Single(getResult.PolicyDefinitions);

                // Delete everything and validate
                this.DeleteSetDefinitionAndValidate(client, setName, managementGroup.Name);
                this.DeleteDefinitionAndValidate(client, definitionName, managementGroup.Name);
                managementGroupsClient.ManagementGroups.Delete(managementGroupName);
            }
        }

        [Fact]
        public void CanCrudPolicyAssignmentAtManagementGroup()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();
                var delegatingHandler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context, delegatingHandler);

                // make a management group
                var managementGroupName = TestUtilities.GenerateName();
                var thisTestName = TestUtilities.GetCurrentMethodName();
                var managementGroup = this.CreateManagementGroup(managementGroupsClient, managementGroupName, thisTestName);

                // get a builtin policy definition
                var policyDefinition = client.PolicyDefinitions.ListBuiltIn().First(item => item.Parameters == null);

                // assign the test policy definition to the test management group
                var policyAssignmentName = TestUtilities.GenerateName();
                var assignmentScope = this.ManagementGroupScope(managementGroup);
                var policyAssignment = new PolicyAssignment
                {
                    DisplayName = $"{thisTestName} Policy Assignment",
                    PolicyDefinitionId = policyDefinition.Id,
                    Scope = assignmentScope,
                    Sku = LivePolicyTests.A0Free
                };

                // assign at management group scope
                var assignment = client.PolicyAssignments.Create(assignmentScope, policyAssignmentName, policyAssignment);

                // get at management group scope, validate result matches
                var getAssignment = client.PolicyAssignments.Get(assignmentScope, assignment.Name);
                this.AssertEqual(assignment, getAssignment);

                // clean up everything
                client.PolicyAssignments.Delete(assignmentScope, assignment.Name);
                managementGroupsClient.ManagementGroups.Delete(managementGroupName);
            }
        }

        [Fact]
        public void ValidatePolicyAssignmentErrorHandling()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // Add a definition that can be assigned
                var definitionName = TestUtilities.GenerateName();
                var thisTestName = TestUtilities.GetCurrentMethodName();
                var policyDefinition = this.CreatePolicyDefinition($"{thisTestName} Policy Definition ${LivePolicyTests.NameTag}");
                var definitionResult = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: definitionName, parameters: policyDefinition);
                Assert.NotNull(definitionResult);

                // Missing policy definition id
                var assignmentName = TestUtilities.GenerateName();
                var assignmentScope = this.SubscriptionScope(client);
                var policyAssignment = new PolicyAssignment
                {
                    DisplayName = $"{thisTestName} Bad Assignment - Missing Policy Definition Id {LivePolicyTests.NameTag}",
                    Sku = LivePolicyTests.A0Free
                };

                this.AssertThrowsCloudException(() => client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment), "InvalidRequestContent");

                // nonexistent policy definition id
                policyAssignment = new PolicyAssignment
                {
                    DisplayName = $"{thisTestName} Bad Assignment - Bad Policy Definition Id {LivePolicyTests.NameTag}",
                    Sku = LivePolicyTests.A0Free,
                    PolicyDefinitionId = definitionResult.Id.Replace(definitionName, TestUtilities.GenerateName())
                };

                this.AssertThrowsCloudException(() => client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment), "PolicyDefinitionNotFound");

                // Invalid SKU
                policyAssignment = new PolicyAssignment
                {
                    DisplayName = $"{thisTestName} Bad Assignment - Bad Policy Sku {LivePolicyTests.NameTag}",
                    Sku = LivePolicyTests.A2FreeInvalid,
                    PolicyDefinitionId = definitionResult.Id
                };

                this.AssertThrowsCloudException(() => client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment), "InvalidPolicySku");

                // Delete policy definition and validate
                this.DeleteDefinitionAndValidate(client, definitionName);
            }
        }

        [Fact]
        public void ValidatePolicyDefinitionErrorHandling()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // Missing rule
                var definitionName = TestUtilities.GenerateName();
                var thisTestName = TestUtilities.GetCurrentMethodName();
                var policyDefinition = new PolicyDefinition
                {
                    DisplayName = $"{thisTestName} - Missing Rule {LivePolicyTests.NameTag}"
                };

                this.AssertThrowsCloudException(() => client.PolicyDefinitions.CreateOrUpdate(definitionName, policyDefinition), "InvalidRequestContent");

                // Invalid Mode
                policyDefinition = this.CreatePolicyDefinition($"{thisTestName} - Bad Mode ${LivePolicyTests.NameTag}");
                policyDefinition.Mode = "Foo";

                this.AssertThrowsCloudException(() => client.PolicyDefinitions.CreateOrUpdate(definitionName, policyDefinition), "InvalidPolicyDefinitionMode");

                // Unused parameter
                policyDefinition = this.CreatePolicyDefinition($"{thisTestName} - Unused Parameter ${LivePolicyTests.NameTag}");
                policyDefinition.Parameters = LivePolicyTests.BasicParameters;

                this.AssertThrowsCloudException(() => client.PolicyDefinitions.CreateOrUpdate(definitionName, policyDefinition), "UnusedPolicyParameters");

                // Missing parameter
                policyDefinition = this.CreatePolicyDefinitionWithParameters($"{thisTestName} - Missing Parameter ${LivePolicyTests.NameTag}");
                policyDefinition.Parameters = null;

                this.AssertThrowsCloudException(() => client.PolicyDefinitions.CreateOrUpdate(definitionName, policyDefinition), "InvalidPolicyParameters");
            }
        }

        [Fact]
        public void ValidatePolicySetDefinitionErrorHandling()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // Create a definition that can be assigned
                var definitionName = TestUtilities.GenerateName();
                var thisTestName = TestUtilities.GetCurrentMethodName();
                var policyDefinition = this.CreatePolicyDefinition($"{thisTestName} Policy Definition ${LivePolicyTests.NameTag}");

                var definitionResult = client.PolicyDefinitions.CreateOrUpdate(definitionName, policyDefinition);
                Assert.NotNull(definitionResult);

                // Missing policy definition references
                var setName = TestUtilities.GenerateName();
                var policySetDefinition = new PolicySetDefinition
                {
                    DisplayName = $"{thisTestName} Bad Set Definition - Missing Policies {LivePolicyTests.NameTag}"
                };

                var validationException = this.CatchAndReturn<ValidationException>(() => client.PolicySetDefinitions.CreateOrUpdate(setName, policySetDefinition));
                Assert.Contains("PolicyDefinitions", validationException.Target);

                // Invalid definition reference
                policySetDefinition = new PolicySetDefinition
                {
                    DisplayName = $"{thisTestName} Bad Set Definition - Bad Policy Id {LivePolicyTests.NameTag}",
                    PolicyDefinitions = new[]
                    {
                        new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id.Replace(definitionName, TestUtilities.GenerateName()))
                    }
                };

                this.AssertThrowsCloudException(() => client.PolicySetDefinitions.CreateOrUpdate(setName, policySetDefinition), "PolicyDefinitionNotFound");

                // Unused parameter
                policySetDefinition = new PolicySetDefinition
                {
                    DisplayName = $"{thisTestName} Bad Set Definition - Unused Parameter {LivePolicyTests.NameTag}",
                    Parameters = LivePolicyTests.BasicParameters,
                    PolicyDefinitions = new[]
                    {
                        new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id)
                    }
                };

                this.AssertThrowsCloudException(() => client.PolicySetDefinitions.CreateOrUpdate(setName, policySetDefinition), "UnusedPolicyParameters");

                var referenceParameters = new Dictionary<string, ParameterValuesValue> { { "foo", new ParameterValuesValue("abc") } };

                // Invalid reference parameters
                policySetDefinition = new PolicySetDefinition
                {
                    DisplayName = $"{thisTestName} Bad Set Definition - Bad Reference Parameter {LivePolicyTests.NameTag}",
                    PolicyDefinitions = new[]
                    {
                        new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id, parameters: referenceParameters)
                    }
                };

                this.AssertThrowsCloudException(() => client.PolicySetDefinitions.CreateOrUpdate(setName, policySetDefinition), "UndefinedPolicyParameter");

                // delete and validate
                this.DeleteDefinitionAndValidate(client, definitionName);
            }
        }

        [Fact]
        public void CanListAndGetBuiltinPolicyDefinitions()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // list all builtin policy definitions
                var allBuiltIn = client.PolicyDefinitions.ListBuiltIn();

                // validate list results
                foreach (var builtIn in allBuiltIn)
                {
                    // validate that list items are all valid
                    this.AssertValid(builtIn, true);

                    // validate that individual get matches list results
                    var getBuiltIn = client.PolicyDefinitions.GetBuiltIn(builtIn.Name);
                    this.AssertEqual(builtIn, getBuiltIn, true);
                }
            }
        }

        [Fact]
        public void CannotDeleteBuiltInPolicyDefinitions()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // list all builtin policy definitions
                var allBuiltIns = client.PolicyDefinitions.ListBuiltIn();

                // try to delete the first 50
                foreach (var builtIn in allBuiltIns.Take(50))
                {
                    client.PolicyDefinitions.Delete(builtIn.Name);
                }

                // get the list again, verify it hasn't changed
                var allBuiltIn2 = client.PolicyDefinitions.ListBuiltIn();

                Assert.Equal(allBuiltIns.Count(), allBuiltIn2.Count());
                foreach (var builtIn in allBuiltIns)
                {
                    Assert.Single(allBuiltIn2.Where(policy => policy.Name.Equals(builtIn.Name)));
                }
            }
        }

        [Fact]
        public void CanListAndGetBuiltinPolicySetDefinitions()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // list all builtin policy definitions
                var allBuiltIn = client.PolicySetDefinitions.ListBuiltIn();

                // validate list results
                foreach (var builtIn in allBuiltIn)
                {
                    // validate that list items are all valid
                    this.AssertValid(builtIn, true);

                    // validate that individual get is valid and matches list results
                    var getBuiltIn = client.PolicySetDefinitions.GetBuiltIn(builtIn.Name);
                    this.AssertValid(getBuiltIn, true);
                    this.AssertEqual(builtIn, getBuiltIn, true);

                    // validate that each policy reference points to a policy definition that exists and is builtin
                    foreach (var policyReference in builtIn.PolicyDefinitions)
                    {
                        var parts = policyReference.PolicyDefinitionId.Split('/');
                        var name = parts.Last();
                        var policyDefinition = client.PolicyDefinitions.GetBuiltIn(name);
                        this.AssertValid(policyDefinition, true);
                    }
                }
            }
        }

        [Fact]
        public void CannotDeleteBuiltInPolicySetDefinitions()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // list all builtin policy definitions
                var allBuiltIn = client.PolicySetDefinitions.ListBuiltIn();

                // try to delete them all
                foreach (var builtIn in allBuiltIn)
                {
                    client.PolicySetDefinitions.Delete(builtIn.Name);
                }

                // get the list again, verify it hasn't changed
                var allBuiltIn2 = client.PolicySetDefinitions.ListBuiltIn();

                Assert.Equal(allBuiltIn.Count(), allBuiltIn2.Count());
                foreach (var builtIn in allBuiltIn)
                {
                    Assert.Single(allBuiltIn2.Where(policy => policy.Name.Equals(builtIn.Name)));
                }
            }
        }

        // test values
        private const string NameTag = "[Auto Test]";
        private const string BasicDescription = "Description text";
        private static readonly JToken BasicMetadata = JToken.Parse(@"{ 'category': 'sdk test' }");
        private static readonly IDictionary<string, ParameterDefinitionsValue> BasicParameters = new Dictionary<string, ParameterDefinitionsValue> { { "foo", new ParameterDefinitionsValue(ParameterType.String) } };
        private static readonly PolicySku A0Free = new PolicySku("A0", "Free");
        private static readonly PolicySku A1Standard = new PolicySku("A1", "Standard");
        private static readonly PolicySku A2FreeInvalid = new PolicySku("A2", "Free");

        // create a minimal policy definition model
        private PolicyDefinition CreatePolicyDefinition(string displayName) => new PolicyDefinition
        {
            DisplayName = displayName,
            PolicyRule = JToken.Parse(
                @"{
                    ""if"": {
                        ""source"": ""action"",
                        ""equals"": ""ResourceProviderTestHost/TestResourceType/TestResourceTypeNestedOne/write""
                    },
                    ""then"": {
                        ""effect"": ""deny""
                    }
                }"
            )
        };

        // create a minimal dataplane policy definition model
        private PolicyDefinition CreateDataPlanePolicyDefinition(string displayName) => new PolicyDefinition
        {
            DisplayName = displayName,
            Mode = "Microsoft.DataCatalog.Data",
            PolicyRule = JToken.Parse(
                @"{
                    ""if"": {
                        ""field"": ""Microsoft.DataCatalog.Data/catalog/entity/type"",
                        ""notEquals"": ""foo""
                    },
                    ""then"": {
                        ""effect"": ""ModifyClassifications"",
                        ""details"": {
                            ""classificationsToAdd"": [ ""foo"" ],
                            ""classificationsToRemove"": [ ""bar"" ],
                        }
                    }
                }"
            )
        };

        // create a minimal policy definition model with parameter
        private PolicyDefinition CreatePolicyDefinitionWithParameters(string displayName) => new PolicyDefinition
        {
            DisplayName = displayName,
            Parameters = LivePolicyTests.BasicParameters,
            PolicyRule = JToken.Parse(
                @"{
                    ""if"": {
                        ""source"": ""action"",
                        ""equals"": ""[parameters('foo')]""
                    },
                    ""then"": {
                        ""effect"": ""deny""
                    }
                }"
            )
        };

        // create a resource in the given resource group
        private Resource CreateResource(ResourceManagementClient client, ResourceGroup resourceGroup, string resourceName)
        {
            return client.Resources.CreateOrUpdate(
                resourceGroup.Name,
                "Microsoft.Web",
                string.Empty,
                "serverFarms",
                resourceName,
                "2018-02-01",
                new GenericResource
                {
                    Location = resourceGroup.Location,
                    Sku = new Sku
                    {
                        Name = "S1"
                    },
                    Properties = JObject.Parse("{}")
                });
        }

        private ManagementGroup CreateManagementGroup(ManagementGroupsAPIClient client, string name, string displayName)
        {
            // get an existing test management group to be parent
            var allManagementGroups = client.ManagementGroups.List();
            var parentManagementGroup = allManagementGroups.First(item => item.Name.Equals(ParentManagementGroup));

            // make a management group using the given parameters
            var managementGroupDetails = new CreateManagementGroupDetails(parent: new CreateParentGroupInfo(id: parentManagementGroup.Id), updatedBy: displayName);
            var managementGroupRequest = new CreateManagementGroupRequest(type: parentManagementGroup.Type, name: name, details: managementGroupDetails, displayName: displayName);

            var managementGroupResult = client.ManagementGroups.CreateOrUpdate(name, managementGroupRequest);
            Assert.NotNull(managementGroupResult);

            var managementGroup = ((JObject)managementGroupResult).ToObject<ManagementGroup>();
            Assert.NotNull(managementGroup);
            return managementGroup;
        }

        // validate that the given policy definition does not have extra fields
        private void AssertMinimal(PolicyDefinition definition)
        {
            Assert.NotNull(definition);
            Assert.Equal("Indexed", definition.Mode);
            Assert.Null(definition.Description);
            AssertMetadataValid(definition.Metadata);
            Assert.Null(definition.Parameters);
        }

        // update the given policy definition with extra fields
        private void UpdatePolicyDefinition(PolicyDefinition policyDefinition)
        {
            policyDefinition.Description = LivePolicyTests.BasicDescription;
            policyDefinition.Metadata = LivePolicyTests.BasicMetadata;
            policyDefinition.Mode = "All";
            policyDefinition.DisplayName = $"Update {policyDefinition.DisplayName}";
        }

        // validate that the given result is a valid policy definition
        private void AssertValid(PolicyDefinition result, bool isBuiltin)
        {
            Assert.NotNull(result);
            Assert.NotNull(result.Name);
            Assert.NotEmpty(result.Name);
            Assert.NotNull(result.DisplayName);
            Assert.NotEmpty(result.DisplayName);
            Assert.NotNull(result.PolicyType);
            if (isBuiltin)
            {
                Assert.True(result.PolicyType.Equals("BuiltIn", StringComparison.Ordinal) || result.PolicyType.Equals("Static", StringComparison.Ordinal));
            }
            else
            {
                Assert.Equal("Custom", result.PolicyType);
            }
            
            Assert.NotNull(result.PolicyRule);
            Assert.NotEmpty(result.PolicyRule.ToString());
            Assert.NotNull(result.Type);
            Assert.Equal("Microsoft.Authorization/policyDefinitions", result.Type);
            Assert.NotNull(result.Id);
            Assert.EndsWith($"/providers/{result.Type}/{result.Name}", result.Id);
            if (isBuiltin)
            {
                Assert.NotNull(result.Description);
                Assert.NotEmpty(result.Description);
            }
            if (result.Mode != null)
            {
                if (!result.Mode.StartsWith("Microsoft.", StringComparison.OrdinalIgnoreCase))
                {
                    Assert.True(result.Mode.Equals("NotSpecified") || result.Mode.Equals("All") || result.Mode.Equals("Indexed"));
                }
                else
                {
                    Assert.Matches(@"Microsoft\.\w+\.Data", result.Mode);
                }
            }
        }

        // validate that the given result policy definition matches the given name and model
        private void AssertValid(string policyName, PolicyDefinition model, PolicyDefinition result, bool isBuiltin)
        {
            this.AssertValid(result, isBuiltin);
            Assert.Equal(policyName, result.Name);
            Assert.Equal(model.DisplayName, result.DisplayName);
            Assert.Equal(model.PolicyRule.ToString(), result.PolicyRule.ToString());
            AssertModeEqual(model.Mode, result.Mode);
            Assert.Equal(model.Description, result.Description);
            AssertMetadataEqual(model.Metadata, result.Metadata, isBuiltin);
            Assert.Equal(model.Parameters?.ToString(), result.Parameters?.ToString());
        }

        // validate that the given result policy definition is equal to the expected one
        private void AssertEqual(PolicyDefinition expected, PolicyDefinition result, bool isBuiltin)
        {
            Assert.NotNull(result);
            Assert.NotNull(expected);
            Assert.Equal(expected.Description, result.Description);
            Assert.Equal(expected.DisplayName, result.DisplayName);
            Assert.Equal(expected.Id, result.Id);
            AssertMetadataEqual(expected.Metadata, result.Metadata, isBuiltin);
            AssertModeEqual(expected.Mode, result.Mode);
            Assert.Equal(expected.Name, result.Name);
            Assert.Equal(expected.Parameters?.ToString(), result.Parameters?.ToString());
            Assert.Equal(expected.PolicyRule.ToString(), result.PolicyRule.ToString());
            Assert.Equal(expected.PolicyType, result.PolicyType);
            Assert.Equal(expected.Type, result.Type);
        }

        // validate that the given list result contains exactly one policy definition that matches the given name and model
        private void AssertInList(string policyName, PolicyDefinition model, IPage<PolicyDefinition> listResult)
        {
            Assert.NotEmpty(listResult);
            var policyInList = listResult.Where(p => p.Name.Equals(policyName)).ToList();
            Assert.NotNull(policyInList);
            Assert.Single(policyInList);
            this.AssertValid(policyName, model, policyInList.Single(), false);
        }

        // delete the policy definition matching the given name and validate it is gone
        private void DeleteDefinitionAndValidate(PolicyClient client, string policyName, string managementGroupName = null)
        {
            if (managementGroupName == null)
            {
                client.PolicyDefinitions.Delete(policyName);
                Assert.Throws<CloudException>(() => client.PolicyDefinitions.Get(policyName));
                var listResult = client.PolicyDefinitions.List();
                Assert.Empty(listResult.Where(p => p.Name.Equals(policyName)));
            }
            else
            {
                client.PolicyDefinitions.DeleteAtManagementGroup(policyName, managementGroupName);
                Assert.Throws<CloudException>(() => client.PolicyDefinitions.GetAtManagementGroup(policyName, managementGroupName));
                var listResult = client.PolicyDefinitions.ListByManagementGroup(managementGroupName);
                Assert.Empty(listResult.Where(p => p.Name.Equals(policyName)));
            }
        }

        // validate that the given result is a valid policy set definition
        private void AssertValid(PolicySetDefinition result, bool isBuiltin)
        {
            Assert.NotNull(result);
            Assert.NotNull(result.Name);
            Assert.NotEmpty(result.Name);
            Assert.NotNull(result.DisplayName);
            Assert.NotEmpty(result.DisplayName);
            Assert.NotNull(result.PolicyType);
            Assert.Equal(isBuiltin ? "BuiltIn" : "Custom", result.PolicyType);
            Assert.NotNull(result.Type);
            Assert.Equal("Microsoft.Authorization/policySetDefinitions", result.Type);
            Assert.NotNull(result.Id);
            Assert.EndsWith($"/providers/{result.Type}/{result.Name}", result.Id);
            if (isBuiltin)
            {
                Assert.NotNull(result.Description);
                Assert.NotEmpty(result.Description);
            }
            Assert.NotEmpty(result.PolicyDefinitions);
            foreach (var policyDefinition in result.PolicyDefinitions)
            {
                Assert.NotNull(policyDefinition);
                Assert.NotNull(policyDefinition.PolicyDefinitionId);
                Assert.NotNull(policyDefinition.PolicyDefinitionReferenceId);
                Assert.Contains("/providers/Microsoft.Authorization/policyDefinitions/", policyDefinition.PolicyDefinitionId);
            }
        }

        // validate that the given result policy set matches the given name and model
        private void AssertValid(string policySetName, PolicySetDefinition model, PolicySetDefinition result, bool isBuiltin)
        {
            this.AssertValid(result, isBuiltin);
            Assert.Equal(policySetName, result.Name);

            Assert.Equal(model.DisplayName, result.DisplayName);
            Assert.Equal(model.Description, result.Description);
            AssertMetadataEqual(model.Metadata, result.Metadata, isBuiltin);
            Assert.Equal(model.Parameters?.ToString(), result.Parameters?.ToString());
            Assert.Equal(model.PolicyDefinitions.Count, result.PolicyDefinitions.Count);
            foreach (var expectedDefinition in model.PolicyDefinitions)
            {
                var resultDefinitions = result.PolicyDefinitions.Where(def => def.PolicyDefinitionId.Equals(expectedDefinition.PolicyDefinitionId));
                Assert.True(resultDefinitions.Count() > 0);
                var resultDefinition = resultDefinitions.Single(def => expectedDefinition.PolicyDefinitionReferenceId == null || expectedDefinition.PolicyDefinitionReferenceId.Equals(def.PolicyDefinitionReferenceId, StringComparison.Ordinal));
                if (expectedDefinition.GroupNames != null)
                {
                    Assert.Equal(expectedDefinition.GroupNames.Count(), resultDefinition.GroupNames.Count());
                    Assert.Equal(expectedDefinition.GroupNames.Count(), expectedDefinition.GroupNames.Intersect(resultDefinition.GroupNames).Count());
                }
                else
                {
                    Assert.Null(resultDefinition.GroupNames);
                }
            }

            if (model.PolicyDefinitionGroups != null)
            {
                Assert.All(model.PolicyDefinitionGroups, group => Assert.Equal(1, result.PolicyDefinitionGroups.Count(resultGroup => resultGroup.Name.Equals(group.Name, StringComparison.Ordinal))));
            }
            else
            {
                Assert.Null(result.PolicyDefinitionGroups);
            }
        }

        // validate that the given result policy definition is equal to the expected one
        private void AssertEqual(PolicySetDefinition expected, PolicySetDefinition result, bool isBuiltin)
        {
            Assert.NotNull(result);
            Assert.NotNull(expected);
            Assert.Equal(expected.Id, result.Id);
            Assert.Equal(expected.Name, result.Name);
            Assert.Equal(expected.PolicyType, result.PolicyType);
            Assert.Equal(expected.Type, result.Type);
            AssertValid(expected.Name, expected, result, isBuiltin);
        }

        // validate that the given list result contains exactly one policy set definition that matches the given name and model
        private void AssertInList(string policySetName, PolicySetDefinition model, IPage<PolicySetDefinition> listResult)
        {
            Assert.NotEmpty(listResult);
            var policySetInList = listResult.Where(p => p.Name.Equals(policySetName)).ToList();
            Assert.NotNull(policySetInList);
            Assert.Single(policySetInList);
            this.AssertValid(policySetName, model, policySetInList.Single(), false);
        }

        // delete the policy set definition matching the given name and validate it is gone
        private void DeleteSetDefinitionAndValidate(PolicyClient client, string policySetName, string managementGroupName = null)
        {
            if (managementGroupName == null)
            {
                client.PolicySetDefinitions.Delete(policySetName);
                this.AssertThrowsCloudException(() => client.PolicySetDefinitions.Get(policySetName));
                var listResult = client.PolicySetDefinitions.List();
                Assert.Empty(listResult.Where(p => p.Name.Equals(policySetName)));
            }
            else
            {
                client.PolicySetDefinitions.DeleteAtManagementGroup(policySetName, managementGroupName);
                this.AssertThrowsCloudException(() => client.PolicySetDefinitions.GetAtManagementGroup(policySetName, managementGroupName));
                var listResult = client.PolicySetDefinitions.ListByManagementGroup(managementGroupName);
                Assert.Empty(listResult.Where(p => p.Name.Equals(policySetName)));
            }
        }

        // validate that the given result policy assignment matches the given name and model
        private void AssertValid(string assignmentName, PolicyAssignment model, PolicyAssignment result)
        {
            Assert.NotNull(result);
            Assert.Equal(assignmentName, result.Name);

            Assert.Equal(model.DisplayName, result.DisplayName);
            Assert.Equal(model.Description, result.Description);
            AssertMetadataValid(result.Metadata);
            Assert.Equal(model.Parameters?.ToString(), result.Parameters?.ToString());
            Assert.Equal(model.PolicyDefinitionId, result.PolicyDefinitionId);
            Assert.Equal(model.Sku.Name, result.Sku.Name);
            Assert.Equal(model.Sku.Tier, result.Sku.Tier);
            Assert.Equal(model.Location, result.Location);
            Assert.Equal(model.EnforcementMode, result.EnforcementMode);
            if (model.Identity != null)
            {
                Assert.Equal(model.Identity.Type, result.Identity.Type);
                Assert.NotNull(result.Identity.PrincipalId);
                Assert.NotNull(result.Identity.TenantId);
            }
            else
            {
                Assert.Null(result.Identity);
            }
        }

        // validate that the given result policy assignment is equal to the expected one
        private void AssertEqual(PolicyAssignment expected, PolicyAssignment result)
        {
            Assert.NotNull(result);
            Assert.NotNull(expected);
            Assert.Equal(expected.Description, result.Description);
            Assert.Equal(expected.DisplayName, result.DisplayName);
            Assert.Equal(expected.Id, result.Id);
            AssertMetadataEqual(expected.Metadata, result.Metadata, false);
            Assert.Equal(expected.Name, result.Name);
            if (expected.NotScopes == null)
            {
                Assert.Null(result.NotScopes);
            }
            else
            {
                Assert.Equal(expected.NotScopes.Count, result.NotScopes.Count);
                foreach (var notscope in expected.NotScopes)
                {
                    Assert.Single(notscope, result.NotScopes.Where(item => item == notscope));
                }
            }

            Assert.Equal(expected.Parameters?.ToString(), result.Parameters?.ToString());
            Assert.Equal(expected.PolicyDefinitionId, result.PolicyDefinitionId);
            Assert.Equal(expected.Scope, result.Scope);
            Assert.Equal(expected.Sku.ToString(), result.Sku.ToString());
            Assert.Equal(expected.Type, result.Type);
            Assert.Equal(expected.Location, result.Location);
            Assert.Equal(expected.Identity?.Type, result.Identity?.Type);
            Assert.Equal(expected.Identity?.PrincipalId, result.Identity?.PrincipalId);
            Assert.Equal(expected.Identity?.TenantId, result.Identity?.TenantId);
        }

        // validate that the given list result contains exactly one policy assignment matching the given name and model model
        private void AssertInList(string assignmentName, PolicyAssignment model, IPage<PolicyAssignment> listResult)
        {
            Assert.NotEmpty(listResult);
            var assignmentInList = listResult.FirstOrDefault(p => p.Name.Equals(assignmentName));
            Assert.NotNull(assignmentInList);
            this.AssertValid(assignmentName, model, assignmentInList);
        }

        private void AssertModeEqual(string expected, string actual)
        {
            if (expected == null)
            {
                Assert.Equal("Indexed", actual);
            }
            else
            {
                Assert.Equal(expected, actual);
            }
        }

        private void AssertMetadataValid(object metaDataObject)
        {
            if (metaDataObject != null)
            {
                var metaData = (JObject)metaDataObject;
                var createdBy = metaData["createdBy"];
                Assert.NotNull(createdBy);
                var createdOn = metaData["createdOn"];
                Assert.NotNull(createdOn);
                var updatedBy = metaData["updatedBy"];
                Assert.NotNull(updatedBy);
            }
        }

        private void AssertMetadataEqual(object expectedObject, object actualObject, bool isBuiltin)
        {
            if (!isBuiltin)
            {
                AssertMetadataValid(actualObject);
            }

            var expected = (JObject)expectedObject;
            if (expected != null)
            {
                var actual = (JObject)actualObject;
                foreach (JProperty property in expected.Properties())
                {
                    Assert.Contains(property.Value, actual.PropertyValues());
                }
            }
        }

        private void AssertThrowsCloudException(Action testCode, string responseContains = null)
        {
            var result = this.CatchAndReturn<CloudException>(testCode);
            if (!string.IsNullOrEmpty(responseContains))
            {
                Assert.Contains(responseContains, result.Response.Content);
            }
        }

        // validate the given action throws the given exception then return the exception
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
            catch (Exception ex)
            {
                Assert.IsType<T>(ex);
            }

            Assert.True(false, "Exception should have been thrown");
            return null;
        }

        // get subscription scope of the given client
        private string SubscriptionScope(PolicyClient client) => $"/subscriptions/{client.SubscriptionId}";

        // get resource group scope of the given client and resource group
        private string ResourceGroupScope(ResourceGroup resourceGroup) => $"{resourceGroup.Id}";

        // get resource scope of the given client and resource
        private string ResourceScope(Resource resource) => $"{resource.Id}";

        // get management group scope of the given client and management group
        private string ManagementGroupScope(ManagementGroup managementGroup) => $"{managementGroup.Id}";
    }
}
