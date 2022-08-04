// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Policy.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.ManagedServiceIdentity;
    using Microsoft.Azure.Management.ManagementGroups;
    using Microsoft.Azure.Management.ManagementGroups.Models;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Azure.OData;
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

                var putResult = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: policyName, parameters: policyDefinition);
                Assert.NotNull(putResult);
                this.AssertValid(policyName, policyDefinition, putResult, isBuiltin: false);
                this.AssertMinimal(putResult);

                // Validate result
                var getResult = client.PolicyDefinitions.Get(policyName);
                this.AssertEqual(putResult, getResult, isBuiltin: false);

                var listResult = client.PolicyDefinitions.List();
                this.AssertInList(client, policyName, policyDefinition, listResult);

                // Validate pagination with page size 100
                listResult = client.PolicyDefinitions.List(top: 100);
                this.AssertInList(client, policyName, policyDefinition, listResult);

                // Update with all properties
                this.UpdatePolicyDefinition(policyDefinition);

                putResult = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: policyName, parameters: policyDefinition);
                Assert.NotNull(putResult);
                this.AssertValid(policyName, policyDefinition, putResult, false);
                Assert.Equal("All", putResult.Mode);
                Assert.Null(putResult.Parameters);

                // Validate result
                getResult = client.PolicyDefinitions.Get(policyName);
                this.AssertEqual(putResult, getResult, isBuiltin: false);

                // Delete definition and validate
                this.DeleteDefinitionAndValidate(client, policyName);

                // Create definition with parameters
                policyDefinition = this.CreatePolicyDefinitionWithParameters(policyName);

                putResult = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: policyName, parameters: policyDefinition);
                Assert.NotNull(putResult);
                this.AssertValid(policyName, policyDefinition, putResult, false);

                // Validate result
                getResult = client.PolicyDefinitions.Get(policyName);
                this.AssertEqual(putResult, getResult, isBuiltin: false);

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
                this.AssertInList(client, policyName, policyDefinition, listResult);

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

                var putResult = client.PolicySetDefinitions.CreateOrUpdate(setName, policySet);
                Assert.NotNull(putResult);
                this.AssertValid(setName, policySet, putResult, false);
                Assert.Single(putResult.PolicyDefinitions);
                Assert.Null(putResult.Description);
                this.AssertMetadataValid(putResult.Metadata);
                Assert.Null(putResult.Parameters);
                Assert.Equal("Custom", putResult.PolicyType);

                // Validate result
                var getResult = client.PolicySetDefinitions.Get(setName);
                this.AssertEqual(putResult, getResult, isBuiltin: false);

                var listResult = client.PolicySetDefinitions.List();
                this.AssertInList(client, setName, policySet, listResult);
                Assert.Single(getResult.PolicyDefinitions);

                // Validate pagination with page size 50
                listResult = client.PolicySetDefinitions.List(top: 50);
                this.AssertInList(client, setName, policySet, listResult);

                // Update with extra properties
                policySet.Description = LivePolicyTests.BasicDescription;
                policySet.Metadata = LivePolicyTests.BasicMetadata;
                policySet.DisplayName = $"Updated {policySet.DisplayName}";

                // Add another definition that can be referenced (must be distinct from the first one to pass validation)
                const string RefId = "refId2";
                var definitionName2 = TestUtilities.GenerateName();
                var definitionResult2 = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: definitionName2, parameters: policyDefinition);
                policySet.PolicyDefinitions = new[]
                {
                    new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id),
                    new PolicyDefinitionReference(policyDefinitionId: definitionResult2.Id, policyDefinitionReferenceId: RefId)
                };

                putResult = client.PolicySetDefinitions.CreateOrUpdate(setName, policySet);
                Assert.NotNull(putResult);
                this.AssertValid(setName, policySet, putResult, false);
                Assert.Equal(2, putResult.PolicyDefinitions.Count);
                Assert.Null(putResult.Parameters);
                Assert.Equal("Custom", putResult.PolicyType);
                Assert.Equal(1, putResult.PolicyDefinitions.Count(definition => RefId.Equals(definition.PolicyDefinitionReferenceId, StringComparison.Ordinal)));

                // validate result
                getResult = client.PolicySetDefinitions.Get(setName);
                this.AssertEqual(putResult, getResult, isBuiltin: false);

                // Delete and validate
                this.DeleteSetDefinitionAndValidate(client, setName);

                // Create a policy set with groups
                const string GroupNameOne = "group1";
                const string GroupNameTwo = "group2";
                policySet.PolicyDefinitionGroups = new List<PolicyDefinitionGroup> { new PolicyDefinitionGroup(GroupNameOne), new PolicyDefinitionGroup(GroupNameTwo) };
                policySet.PolicyDefinitions[0].GroupNames = new[] { GroupNameOne, GroupNameTwo };
                policySet.PolicyDefinitions[1].GroupNames = new[] { GroupNameTwo };
                putResult = client.PolicySetDefinitions.CreateOrUpdate(setName, policySet);
                Assert.NotNull(putResult);
                this.AssertValid(setName, policySet, putResult, false);

                getResult = client.PolicySetDefinitions.Get(setName);
                this.AssertEqual(putResult, getResult, isBuiltin: false);

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

                putResult = client.PolicySetDefinitions.CreateOrUpdate(setName, policySet);
                Assert.NotNull(putResult);
                this.AssertValid(setName, policySet, putResult, false);
                Assert.Single(putResult.PolicyDefinitions);

                // validate result
                getResult = client.PolicySetDefinitions.Get(setName);
                this.AssertEqual(putResult, getResult, isBuiltin: false);

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
                };

                var putResult = client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment);
                Assert.NotNull(putResult);

                // Default enforcement should be set even if not provided as input in PUT request.
                policyAssignment.EnforcementMode = EnforcementMode.Default;
                this.AssertValid(assignmentName, policyAssignment, putResult);
                Assert.Null(putResult.NotScopes);
                Assert.Null(putResult.Description);
                this.AssertMetadataValid(putResult.Metadata);
                Assert.Null(putResult.Parameters);

                // validate results
                var getResult = client.PolicyAssignments.Get(assignmentScope, assignmentName);
                this.AssertEqual(putResult, getResult);

                var listResult = client.PolicyAssignments.List();
                this.AssertInList(client, assignmentName, policyAssignment, listResult);

                // Validate pagination with page size 10
                var assignmentQuery = new ODataQuery<PolicyAssignment> { Top = 10 };
                listResult = client.PolicyAssignments.List(assignmentQuery);
                this.AssertInList(client, assignmentName, policyAssignment, listResult);

                // Update with extra properties
                policyAssignment.Description = LivePolicyTests.BasicDescription;
                policyAssignment.Metadata = LivePolicyTests.BasicMetadata;
                policyAssignment.DisplayName = $"Updated {policyAssignment.DisplayName}";
                policyAssignment.Location = "eastus";
                policyAssignment.Identity = new Identity(type: ResourceIdentityType.SystemAssigned);
                policyAssignment.EnforcementMode = EnforcementMode.DoNotEnforce;

                putResult = client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment);
                Assert.NotNull(putResult);
                this.AssertValid(assignmentName, policyAssignment, putResult);

                // validate results
                getResult = client.PolicyAssignments.GetById(putResult.Id);
                this.AssertEqual(putResult, getResult);

                // Delete policy assignment and validate
                client.PolicyAssignments.Delete(assignmentScope, assignmentName);
                this.AssertThrowsCloudException(() => client.PolicyAssignments.Get(assignmentScope, assignmentName));
                listResult = client.PolicyAssignments.List();
                Assert.Empty(listResult.Where(p => p.Name.Equals(assignmentName)));

                // Create brand new assignment with identity
                assignmentName = TestUtilities.GenerateName();
                putResult = client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment);
                Assert.NotNull(putResult);
                this.AssertValid(assignmentName, policyAssignment, putResult);

                // validate results
                getResult = client.PolicyAssignments.GetById(putResult.Id);
                this.AssertEqual(putResult, getResult);

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
        public void CanPatchPolicyAssignment()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                const string Region = "westus2";

                var client = context.GetServiceClient<PolicyClient>();
                var resourceGroupClient = context.GetServiceClient<ResourceManagementClient>();
                var msiMgmtClient = context.GetServiceClient<ManagedServiceIdentityClient>();

                // make a test resource group
                var resourceGroupName = TestUtilities.GenerateName();
                var resourceGroup = resourceGroupClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup(location: Region));

                // make a test user-assigned identity
                var testUserAssignedIdentityName = TestUtilities.GenerateName();
                var identityParameters = new Microsoft.Azure.Management.ManagedServiceIdentity.Models.Identity(location: Region);
                var userAssignedIdentity = msiMgmtClient.UserAssignedIdentities.CreateOrUpdate(resourceGroupName: resourceGroupName, resourceName: testUserAssignedIdentityName, parameters: identityParameters);

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
                    Location = Region
                };

                var assignment = client.PolicyAssignments.Create(assignmentScope, policyAssignmentName, policyAssignment);

                // get the same item at scope and ensure it matches
                var getAssignment = client.PolicyAssignments.Get(assignmentScope, assignment.Name);
                this.AssertEqual(assignment, getAssignment);

                // patch the assignment by changing the identity to the test user-assigned identity
                var policyUserAssignedIdentity = new Identity(type: ResourceIdentityType.UserAssigned, userAssignedIdentities: new Dictionary<string, IdentityUserAssignedIdentitiesValue> { { userAssignedIdentity.Id, new IdentityUserAssignedIdentitiesValue() } });
                var policyAssignmentPatchRequest = new PolicyAssignmentUpdate { Location = Region, Identity = policyUserAssignedIdentity };
                var patchAssignment = client.PolicyAssignments.Update(assignmentScope, policyAssignmentName, policyAssignmentPatchRequest);
                Assert.NotNull(patchAssignment);
                Assert.Equal(Region, patchAssignment.Location);
                this.AssertValid(policyAssignmentPatchRequest.Identity, patchAssignment.Identity);

                getAssignment = client.PolicyAssignments.Get(assignmentScope, assignment.Name);
                this.AssertEqual(patchAssignment, getAssignment);

                // patch the assignment by changing the identity to a system-assigned identity
                policyAssignmentPatchRequest = new PolicyAssignmentUpdate { Location = Region, Identity = new Identity(type: ResourceIdentityType.SystemAssigned) };
                patchAssignment = client.PolicyAssignments.UpdateById(getAssignment.Id, policyAssignmentPatchRequest);
                Assert.NotNull(patchAssignment);
                Assert.Equal(Region, patchAssignment.Location);
                this.AssertValid(policyAssignmentPatchRequest.Identity, patchAssignment.Identity);

                getAssignment = client.PolicyAssignments.Get(assignmentScope, assignment.Name);
                this.AssertEqual(patchAssignment, getAssignment);

                // remove identity via patch
                policyAssignmentPatchRequest = new PolicyAssignmentUpdate { Identity = new Identity(type: ResourceIdentityType.None) };
                patchAssignment = client.PolicyAssignments.Update(assignmentScope, policyAssignmentName, policyAssignmentPatchRequest);
                Assert.NotNull(patchAssignment);
                Assert.Equal(Region, patchAssignment.Location);
                this.AssertValid(policyAssignmentPatchRequest.Identity, patchAssignment.Identity);

                getAssignment = client.PolicyAssignments.Get(assignmentScope, assignment.Name);
                this.AssertEqual(patchAssignment, getAssignment);

                // clean up everything
                client.PolicyAssignments.Delete(assignmentScope, assignment.Name);
                client.PolicyDefinitions.Delete(policyDefinition.Name);
                msiMgmtClient.UserAssignedIdentities.Delete(resourceGroupName: resourceGroupName, resourceName: testUserAssignedIdentityName);
                resourceGroupClient.ResourceGroups.Delete(resourceGroupName);
            }
        }

        [Fact]
        public void CanCrudPolicyAssignmentAtResourceGroup()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                const string Region = "westus2";

                var client = context.GetServiceClient<PolicyClient>();
                var resourceGroupClient = context.GetServiceClient<ResourceManagementClient>();
                var msiMgmtClient = context.GetServiceClient<ManagedServiceIdentityClient>();

                // make a test resource group
                var resourceGroupName = TestUtilities.GenerateName();
                var resourceGroup = resourceGroupClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup(location: Region));

                // make a test user-assigned identity
                var testUserAssignedIdentityName = TestUtilities.GenerateName();
                var identityParameters = new Microsoft.Azure.Management.ManagedServiceIdentity.Models.Identity(location: Region);
                var userAssignedIdentity = msiMgmtClient.UserAssignedIdentities.CreateOrUpdate(resourceGroupName: resourceGroupName, resourceName: testUserAssignedIdentityName, parameters: identityParameters);

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
                    EnforcementMode = EnforcementMode.Default
                };

                var putAssignment = client.PolicyAssignments.Create(assignmentScope, policyAssignmentName, policyAssignment);
                Assert.NotNull(putAssignment);
                this.AssertValid(policyAssignmentName, policyAssignment, putAssignment);

                // retrieve list of policies that apply to this resource group, validate exactly one matches the one we just created
                var assignments = client.PolicyAssignments.ListForResourceGroup(resourceGroupName);
                Assert.Single(assignments.Where(assign => assign.Name.Equals(policyAssignmentName)));

                // get the same item at scope and ensure it matches
                var getAssignment = client.PolicyAssignments.Get(assignmentScope, policyAssignmentName);
                this.AssertEqual(putAssignment, getAssignment);

                // update assignment with user assigned identity
                policyAssignment.Location = Region;
                policyAssignment.Identity = new Identity(type: ResourceIdentityType.UserAssigned, userAssignedIdentities: new Dictionary<string, IdentityUserAssignedIdentitiesValue> { { userAssignedIdentity.Id, new IdentityUserAssignedIdentitiesValue() } });
                putAssignment = client.PolicyAssignments.CreateById(getAssignment.Id, policyAssignment);
                this.AssertValid(policyAssignmentName, policyAssignment, putAssignment);

                // get the same item at scope and ensure it matches
                getAssignment = client.PolicyAssignments.GetById(putAssignment.Id);
                this.AssertEqual(putAssignment, getAssignment);

                // clean up everything
                client.PolicyAssignments.Delete(assignmentScope, policyAssignmentName);
                client.PolicyDefinitions.Delete(policyDefinition.Name);
                msiMgmtClient.UserAssignedIdentities.Delete(resourceGroupName: resourceGroupName, resourceName: testUserAssignedIdentityName);
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
                    PolicyDefinitionId = policyDefinition.Id
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
        public void CanCrudPolicyExemption()
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

                // create a policy set that can be assigned
                var definitionReference = new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id, policyDefinitionReferenceId: TestUtilities.GenerateName());
                var policySetName = TestUtilities.GenerateName();
                var policySet = new PolicySetDefinition
                {
                    DisplayName = $"{thisTestName} Policy Set Definition ${LivePolicyTests.NameTag}",
                    PolicyDefinitions = new[] { definitionReference }
                };

                var policySetResult = client.PolicySetDefinitions.CreateOrUpdate(policySetName, policySet);
                Assert.NotNull(policySetResult);

                // create an assignment that can be exempted
                var assignmentName = TestUtilities.GenerateName();
                var assignmentScope = this.SubscriptionScope(client);
                var policyAssignment = new PolicyAssignment
                {
                    DisplayName = $"{thisTestName} Policy Assignment ${LivePolicyTests.NameTag}",
                    PolicyDefinitionId = policySetResult.Id,
                };

                var assignmentResult = client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment);
                Assert.NotNull(assignmentResult);

                // First, create with minimal properties
                var exemptionName = TestUtilities.GenerateName();
                var exemptionScope = this.SubscriptionScope(client);
                var policyExemption = new PolicyExemption
                {
                    DisplayName = $"{thisTestName} Policy Exemption ${LivePolicyTests.NameTag}",
                    PolicyAssignmentId = assignmentResult.Id,
                    ExemptionCategory = ExemptionCategory.Waiver
                };

                var result = client.PolicyExemptions.CreateOrUpdate(scope: exemptionScope, policyExemptionName: exemptionName, parameters: policyExemption);

                // validate results
                var getResult = client.PolicyExemptions.Get(exemptionScope, exemptionName);
                this.AssertValid(exemptionName, policyExemption, getResult);
                this.AssertEqual(result, getResult);

                var listResult = client.PolicyExemptions.List();
                this.AssertInList(exemptionName, policyExemption, listResult);

                // Update with extra properties
                policyExemption.ExemptionCategory = ExemptionCategory.Mitigated;
                policyExemption.Description = LivePolicyTests.BasicDescription;
                policyExemption.Metadata = LivePolicyTests.BasicMetadata;
                policyExemption.DisplayName = $"Updated {policyExemption.DisplayName}";
                policyExemption.ExpiresOn = DateTime.UtcNow.AddDays(1);
                policyExemption.PolicyDefinitionReferenceIds = new[] { definitionReference.PolicyDefinitionReferenceId };

                result = client.PolicyExemptions.CreateOrUpdate(scope: exemptionScope, policyExemptionName: exemptionName, parameters: policyExemption);
                Assert.NotNull(result);

                // validate results
                getResult = client.PolicyExemptions.Get(scope: exemptionScope, policyExemptionName: exemptionName);
                this.AssertValid(exemptionName, policyExemption, getResult);
                Assert.NotNull(result.Metadata);

                // createBy info is in system data
                AssertMetadataEqual(LivePolicyTests.BasicMetadata, result.Metadata, true);


                listResult = client.PolicyExemptions.List();
                this.AssertInList(exemptionName, policyExemption, listResult);

                // delete policy assignment and validate (existing exemption will not block delete the associated assignment)
                client.PolicyAssignments.Delete(assignmentScope, assignmentName);
                this.AssertThrowsCloudException(() => client.PolicyAssignments.Get(assignmentScope, assignmentName));
                listResult = client.PolicyExemptions.List();
                Assert.Empty(listResult.Where(p => p.Name.Equals(assignmentName)));

                // delete policy set definition and validate
                this.DeleteSetDefinitionAndValidate(client, policySetName);

                // delete policy definition and validate
                this.DeleteDefinitionAndValidate(client, definitionName);

                // delete policy exemption and validate
                client.PolicyExemptions.Delete(exemptionScope, exemptionName);
                this.AssertThrowsCloudException(() => client.PolicyAssignments.Get(exemptionScope, exemptionName));
                listResult = client.PolicyExemptions.List();
                Assert.Empty(listResult.Where(p => p.Name.Equals(exemptionName)));
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
                //var managementGroupName = TestUtilities.GenerateName();
                var managementGroupName = "azsmnet2902";
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
                this.AssertInList(client, policyDefinitionName, policyDefinitionModel, listResult);

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
                //var managementGroupName = TestUtilities.GenerateName();
                var managementGroupName = "azsmnet2337";
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
                this.AssertInList(client, setName, policySet, listResult);

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
                //var managementGroupName = TestUtilities.GenerateName();
                var managementGroupName = "azsmnet9706";
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
                    PolicyDefinitionId = policyDefinition.Id
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
        public void CanCrudPolicyExemptionAtManagementGroup()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();
                var delegatingHandler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context, delegatingHandler);

                // make a management group
                //var managementGroupName = TestUtilities.GenerateName();
                var managementGroupName = "azsmnet5070";
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
                    PolicyDefinitionId = policyDefinition.Id
                };

                // create assignment at management group scope
                var assignment = client.PolicyAssignments.Create(assignmentScope, policyAssignmentName, policyAssignment);
                Assert.NotNull(assignment);

                // create exemption at management group scope
                var exemptionName = TestUtilities.GenerateName();
                var exemptionScope = this.ManagementGroupScope(managementGroup);
                var policyExemption = new PolicyExemption
                {
                    DisplayName = $"{thisTestName} Policy Exemption",
                    PolicyAssignmentId = assignment.Id,
                    ExemptionCategory = ExemptionCategory.Waiver
                };

                var result = client.PolicyExemptions.CreateOrUpdate(scope: exemptionScope, policyExemptionName: exemptionName, parameters: policyExemption);

                // get at management group scope, validate result matches
                var getResult = client.PolicyExemptions.Get(exemptionScope, exemptionName);
                this.AssertValid(exemptionName, policyExemption, getResult);
                this.AssertEqual(result, getResult);

                var listResult = client.PolicyExemptions.ListForManagementGroup(managementGroupName, @"atScope()");
                this.AssertInList(exemptionName, policyExemption, listResult);

                // delete policy exemption and validate
                client.PolicyExemptions.Delete(exemptionScope, exemptionName);
                this.AssertThrowsCloudException(() => client.PolicyAssignments.Get(exemptionScope, exemptionName));
                listResult = client.PolicyExemptions.List();
                Assert.Empty(listResult.Where(p => p.Name.Equals(exemptionName)));

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
                    DisplayName = $"{thisTestName} Bad Assignment - Missing Policy Definition Id {LivePolicyTests.NameTag}"
                };

                this.AssertThrowsCloudException(() => client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment), "InvalidRequestContent");

                // nonexistent policy definition id
                policyAssignment = new PolicyAssignment
                {
                    DisplayName = $"{thisTestName} Bad Assignment - Bad Policy Definition Id {LivePolicyTests.NameTag}",
                    PolicyDefinitionId = definitionResult.Id.Replace(definitionName, TestUtilities.GenerateName())
                };

                this.AssertThrowsCloudException(() => client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment), "PolicyDefinitionNotFound");

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
        public void ValidatePolicyExemptionErrorHandling()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<PolicyClient>();

                // create a definition that can be assigned
                var definitionName = TestUtilities.GenerateName();
                var thisTestName = TestUtilities.GetCurrentMethodName();
                var policyDefinition = this.CreatePolicyDefinition($"{thisTestName} Policy Definition ${LivePolicyTests.NameTag}");

                var definition = client.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: definitionName, parameters: policyDefinition);
                Assert.NotNull(definition);

                // create a policy set that can be assigned
                var definitionReference = new PolicyDefinitionReference(policyDefinitionId: definition.Id, policyDefinitionReferenceId: TestUtilities.GenerateName());
                var policySetName = TestUtilities.GenerateName();
                var policySet = new PolicySetDefinition
                {
                    DisplayName = $"{thisTestName} Policy Set Definition ${LivePolicyTests.NameTag}",
                    PolicyDefinitions = new[] { definitionReference }
                };

                var policySetResult = client.PolicySetDefinitions.CreateOrUpdate(policySetName, policySet);
                Assert.NotNull(policySetResult);

                // create an assignment that can be exempted
                var assignmentName = TestUtilities.GenerateName();
                var assignmentScope = this.SubscriptionScope(client);
                var policyAssignment = new PolicyAssignment
                {
                    DisplayName = $"{thisTestName} Policy Assignment ${LivePolicyTests.NameTag}",
                    PolicyDefinitionId = policySetResult.Id,
                };

                var assignment = client.PolicyAssignments.Create(assignmentScope, assignmentName, policyAssignment);
                Assert.NotNull(assignment);

                // invalid policy assignment id
                var exemptionName = TestUtilities.GenerateName();
                var exemptionScope = this.SubscriptionScope(client);
                var policyExemption = new PolicyExemption
                {
                    DisplayName = $"{thisTestName} Policy Exemption ${LivePolicyTests.NameTag}",
                    PolicyAssignmentId = assignment.Id + TestUtilities.GenerateName(),
                    ExemptionCategory = ExemptionCategory.Waiver
                };

                this.AssertThrowsCloudException(() => client.PolicyExemptions.CreateOrUpdate(exemptionScope, exemptionName, policyExemption), "InvalidCreatePolicyExemptionRequest");

                // missing exemption category
                policyExemption = new PolicyExemption
                {
                    DisplayName = $"{thisTestName} Policy Exemption ${LivePolicyTests.NameTag}",
                    PolicyAssignmentId = assignment.Id
                };

                this.AssertThrowsValidationException(() => client.PolicyExemptions.CreateOrUpdate(exemptionScope, exemptionName, policyExemption), @"'ExemptionCategory' cannot be null.");

                // invalid policy definition reference id
                policyExemption = new PolicyExemption
                {
                    DisplayName = $"{thisTestName} Policy Exemption ${LivePolicyTests.NameTag}",
                    PolicyAssignmentId = assignment.Id,
                    ExemptionCategory = ExemptionCategory.Waiver,
                    PolicyDefinitionReferenceIds = new [] { TestUtilities.GenerateName() }
                };

                this.AssertThrowsCloudException(() => client.PolicyExemptions.CreateOrUpdate(exemptionScope, exemptionName, policyExemption), "InvalidPolicyDefinitionReference");

                // create the exemption
                policyExemption = new PolicyExemption
                {
                    DisplayName = $"{thisTestName} Policy Exemption ${LivePolicyTests.NameTag}",
                    PolicyAssignmentId = assignment.Id,
                    ExemptionCategory = ExemptionCategory.Waiver
                };

                var result = client.PolicyExemptions.CreateOrUpdate(scope: exemptionScope, policyExemptionName: exemptionName, parameters: policyExemption);

                // change assignment Id of an existing exemption is not allowed
                policyExemption = new PolicyExemption
                {
                    PolicyAssignmentId = assignment.Id + TestUtilities.GenerateName(),
                    ExemptionCategory = ExemptionCategory.Waiver
                };

                this.AssertThrowsCloudException(() => client.PolicyExemptions.CreateOrUpdate(exemptionScope, exemptionName, policyExemption), "InvalidPolicyAssignmentIdUpdate");

                // clean up everything
                client.PolicyAssignments.Delete(assignmentScope, assignment.Name);
                this.DeleteSetDefinitionAndValidate(client, policySetName);
                this.DeleteDefinitionAndValidate(client, definitionName);
                client.PolicyExemptions.Delete(exemptionScope, exemptionName);
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
            var allManagementGroups = client.ManagementGroups.List().ToArray();
            //var parentManagementGroup = allManagementGroups.First(item => item.Name.Equals(ParentManagementGroup));
            var parentManagementGroup = allManagementGroups[1];

            // make a management group using the given parameters
            var managementGroupDetails = new CreateManagementGroupDetails(parent: new CreateParentGroupInfo(id: parentManagementGroup.Id), updatedBy: displayName);
            var managementGroupRequest = new CreateManagementGroupRequest(type: parentManagementGroup.Type, name: name, details: managementGroupDetails, displayName: displayName);

            var managementGroupResult = client.ManagementGroups.CreateOrUpdate(name, managementGroupRequest);
            Assert.NotNull(managementGroupResult);

            var managementGroup = (ManagementGroup) managementGroupResult;
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
            this.AssertMetadataEqual(expected.Metadata, result.Metadata, isBuiltin);
            this.AssertModeEqual(expected.Mode, result.Mode);
            Assert.Equal(expected.Name, result.Name);
            Assert.Equal(expected.Parameters?.ToString(), result.Parameters?.ToString());
            Assert.Equal(expected.PolicyRule.ToString(), result.PolicyRule.ToString());
            Assert.Equal(expected.PolicyType, result.PolicyType);
            Assert.Equal(expected.Type, result.Type);
            this.AssertEqual(expected.SystemData, result.SystemData);
        }

        // validate that the given list result contains exactly one policy definition that matches the given name and model
        private void AssertInList(PolicyClient client, string policyName, PolicyDefinition model, IPage<PolicyDefinition> listResult)
        {
            Assert.NotEmpty(listResult);
            var policyInList = listResult.Where(p => p.Name.Equals(policyName)).ToList();

            while (policyInList?.Count <= 0 && !string.IsNullOrEmpty(listResult.NextPageLink))
            {
                listResult = client.PolicyDefinitions.ListNext(listResult.NextPageLink);
                Assert.NotEmpty(listResult);
                policyInList = listResult.Where(p => p.Name.Equals(policyName)).ToList();
            }

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
            this.AssertValid(expected.Name, expected, result, isBuiltin);
            this.AssertEqual(expected.SystemData, result.SystemData);
        }

        // validate that the given list result contains exactly one policy set definition that matches the given name and model
        private void AssertInList(PolicyClient client, string policySetName, PolicySetDefinition model, IPage<PolicySetDefinition> listResult)
        {
            Assert.NotEmpty(listResult);
            var policySetInList = listResult.Where(p => p.Name.Equals(policySetName)).ToList();

            while (policySetInList?.Count <= 0 && !string.IsNullOrEmpty(listResult.NextPageLink))
            {
                listResult = client.PolicySetDefinitions.ListNext(listResult.NextPageLink);
                Assert.NotEmpty(listResult);
                policySetInList = listResult.Where(p => p.Name.Equals(policySetName)).ToList();
            }

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
            this.AssertMetadataValid(result.Metadata);
            Assert.Equal(model.Parameters?.ToString(), result.Parameters?.ToString());
            Assert.Equal(model.PolicyDefinitionId, result.PolicyDefinitionId);
            Assert.Equal(model.Location, result.Location);
            Assert.Equal(model.EnforcementMode, result.EnforcementMode);
            this.AssertValid(model.Identity, result.Identity);
        }

        // validate that the given result policy assignment is equal to the expected one
        private void AssertEqual(PolicyAssignment expected, PolicyAssignment result)
        {
            Assert.NotNull(result);
            Assert.NotNull(expected);
            Assert.Equal(expected.Description, result.Description);
            Assert.Equal(expected.DisplayName, result.DisplayName);
            Assert.Equal(expected.Id, result.Id);
            this.AssertMetadataEqual(expected.Metadata, result.Metadata, false);
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
            Assert.Equal(expected.Type, result.Type);
            Assert.Equal(expected.Location, result.Location);

            this.AssertEqual(expected.Identity, result.Identity);
            this.AssertEqual(expected.SystemData, result.SystemData);
        }

        // validate that the given result identity is equal to the expected one
        private void AssertEqual(Identity expected, Identity result)
        {
            if (expected != null)
            {
                Assert.NotNull(result);
                Assert.Equal(expected.Type, result.Type);
                Assert.Equal(expected.PrincipalId, result.PrincipalId);
                Assert.Equal(expected.TenantId, result.TenantId);

                if (expected.UserAssignedIdentities != null)
                {
                    Assert.NotNull(result.UserAssignedIdentities);
                    Assert.Equal(expected.UserAssignedIdentities.Count, result.UserAssignedIdentities.Count);

                    foreach (var expectedUserAssignedIdentity in expected.UserAssignedIdentities)
                    {
                        Assert.True(result.UserAssignedIdentities.TryGetValue(expectedUserAssignedIdentity.Key, out var resultUserAssignedIdentity));
                        Assert.Equal(expectedUserAssignedIdentity.Value.ClientId, resultUserAssignedIdentity.ClientId);
                        Assert.Equal(expectedUserAssignedIdentity.Value.PrincipalId, resultUserAssignedIdentity.PrincipalId);
                    }
                }
                else
                {
                    Assert.Null(result.UserAssignedIdentities);
                }
            }
            else
            {
                Assert.Null(result);
            }
        }

        // validate that the given result identity matches the given model
        private void AssertValid(Identity model, Identity result)
        {
            if (model != null)
            {
                Assert.Equal(model.Type, result.Type);

                switch (model.Type)
                {
                    case ResourceIdentityType.SystemAssigned:
                        Assert.NotNull(result.PrincipalId);
                        Assert.NotNull(result.TenantId);
                        Assert.Null(result.UserAssignedIdentities);
                        break;

                    case ResourceIdentityType.UserAssigned:
                        Assert.Null(result.PrincipalId);
                        Assert.Null(result.TenantId);
                        Assert.NotNull(result.UserAssignedIdentities);
                        Assert.NotNull(model.UserAssignedIdentities);
                        Assert.Equal(model.UserAssignedIdentities.Count, result.UserAssignedIdentities.Count);

                        foreach (var key in model.UserAssignedIdentities.Keys)
                        {
                            Assert.True(result.UserAssignedIdentities.TryGetValue(key, out var resultUserAssignedIdentity));
                            Assert.NotNull(resultUserAssignedIdentity.ClientId);
                            Assert.NotNull(resultUserAssignedIdentity.PrincipalId);
                        }

                        break;

                    case ResourceIdentityType.None:
                        Assert.Null(result.PrincipalId);
                        Assert.Null(result.TenantId);
                        Assert.Null(result.UserAssignedIdentities);
                        break;

                    default:
                        throw new InvalidOperationException($"Unsupported Resource Identity Type: {model.Type}");
                }
            }
            else
            {
                Assert.Null(result);
            }
        }

        // validate that the given result system data is equal to the expected one
        private void AssertEqual(SystemData expected, SystemData result)
        {
            if (expected != null)
            {
                Assert.NotNull(result);
                Assert.Equal(expected.CreatedAt, result.CreatedAt);
                Assert.Equal(expected.CreatedBy, result.CreatedBy);
                Assert.Equal(expected.CreatedByType, result.CreatedByType);
                Assert.Equal(expected.LastModifiedAt, result.LastModifiedAt);
                Assert.Equal(expected.LastModifiedBy, result.LastModifiedBy);
                Assert.Equal(expected.LastModifiedByType, result.LastModifiedByType);
            }
            else
            {
                Assert.Null(result);
            }
        }

        // validate that the given list result contains exactly one policy assignment matching the given name and model
        private void AssertInList(PolicyClient client, string assignmentName, PolicyAssignment model, IPage<PolicyAssignment> listResult)
        {
            Assert.NotEmpty(listResult);
            var assignmentInList = listResult.FirstOrDefault(p => p.Name.Equals(assignmentName));

            while (assignmentInList == null && !string.IsNullOrEmpty(listResult.NextPageLink))
            {
                listResult = client.PolicyAssignments.ListNext(listResult.NextPageLink);
                Assert.NotEmpty(listResult);
                assignmentInList = listResult.FirstOrDefault(p => p.Name.Equals(assignmentName));
            }

            Assert.NotNull(assignmentInList);
            this.AssertValid(assignmentName, model, assignmentInList);
        }

        // validate that the given result policy exemption matches the given name and model
        private void AssertValid(string exemptionName, PolicyExemption model, PolicyExemption result)
        {
            Assert.NotNull(result);
            Assert.Equal(exemptionName, result.Name);
            AssertSystemDataValid(result.SystemData);
        }

        // validate that the given list result contains exactly one policy exemption matching the given name and model
        private void AssertInList(string exemptionName, PolicyExemption model, IPage<PolicyExemption> listResult)
        {
            Assert.NotEmpty(listResult);
            var exemptionInList = listResult.FirstOrDefault(p => p.Name.Equals(exemptionName));
            Assert.NotNull(exemptionInList);
            this.AssertValid(exemptionName, model, exemptionInList);
        }

        // validate that the given result policy exemption is equal to the expected one
        private void AssertEqual(PolicyExemption expected, PolicyExemption result)
        {
            Assert.NotNull(result);
            Assert.NotNull(expected);
            Assert.Equal(expected.Name, result.Name);
            Assert.Equal(expected.Description, result.Description);
            Assert.Equal(expected.DisplayName, result.DisplayName);
            Assert.Equal(expected.Id, result.Id);
            Assert.Equal(expected.PolicyAssignmentId, result.PolicyAssignmentId);
            Assert.Equal(expected.ExemptionCategory, result.ExemptionCategory);
            Assert.True(expected.ExpiresOn == result.ExpiresOn);
            Assert.Equal(expected.PolicyAssignmentId, result.PolicyAssignmentId);
            Assert.Equal(expected.PolicyAssignmentId, result.PolicyAssignmentId);
            Assert.Equal(expected.PolicyAssignmentId, result.PolicyAssignmentId);
            Assert.Equal(expected.PolicyAssignmentId, result.PolicyAssignmentId);
            AssertMetadataEqual(expected.Metadata, result.Metadata, false);

            if (expected.PolicyDefinitionReferenceIds == null)
            {
                Assert.Null(result.PolicyDefinitionReferenceIds);
            }
            else
            {
                Assert.Equal(expected.PolicyDefinitionReferenceIds.Count, result.PolicyDefinitionReferenceIds.Count);
                foreach (var policyReferenceId in expected.PolicyDefinitionReferenceIds)
                {
                    Assert.Single(policyReferenceId, result.PolicyDefinitionReferenceIds.Where(item => item == policyReferenceId));
                }
            }
        }

        private void AssertSystemDataValid(SystemData systemData)
        {
            Assert.NotNull(systemData);
            Assert.NotNull(systemData.CreatedAt);
            Assert.NotNull(systemData.CreatedBy);
            Assert.NotNull(systemData.CreatedByType);
            Assert.NotNull(systemData.LastModifiedAt);
            Assert.NotNull(systemData.LastModifiedBy);
            Assert.NotNull(systemData.LastModifiedByType);
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

        private void AssertThrowsValidationException(Action testCode, string responseContains = null)
        {
            var result = this.CatchAndReturn<ValidationException>(testCode);
            if (!string.IsNullOrEmpty(responseContains))
            {
                Assert.Contains(responseContains, result.Message);
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
