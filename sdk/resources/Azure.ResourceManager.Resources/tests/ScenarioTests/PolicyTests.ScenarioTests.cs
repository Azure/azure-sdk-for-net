// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Resources.Tests;
using NUnit.Framework;

namespace Policy.Tests
{
    public class LivePolicyTests : ResourceOperationsTestsBase
    {
        public LivePolicyTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        /// <summary>
        /// The management group that will be used as a parent for any management groups created during the test
        /// </summary>
        private const string ParentManagementGroup = "AzGovPerfTest";

        [Test]
        public async Task CanCrudPolicyDefinition()
        {
            // First, create with minimal properties
            var policyName = Recording.GenerateAssetName("");
            var thisTestName = "CanCrudPolicyDefinition";
            var policyDefinition = this.CreatePolicyDefinition($"{thisTestName} Policy Definition ${LivePolicyTests.NameTag}");

            var result = (await PolicyDefinitionsOperations.CreateOrUpdateAsync(policyDefinitionName: policyName, parameters: policyDefinition)).Value;
            Assert.NotNull(result);

            // Validate result
            var getResult = (await PolicyDefinitionsOperations.GetAsync(policyName)).Value;
            this.AssertValid(policyName, policyDefinition, getResult, false);
            this.AssertMinimal(getResult);

            var listResult = await PolicyDefinitionsOperations.ListAsync().ToEnumerableAsync();
            this.AssertInList(policyName, policyDefinition, listResult);

            // Update with all properties
            this.UpdatePolicyDefinition(policyDefinition);

            result = (await PolicyDefinitionsOperations.CreateOrUpdateAsync(policyDefinitionName: policyName, parameters: policyDefinition)).Value;
            Assert.NotNull(result);

            // Validate result
            getResult = (await PolicyDefinitionsOperations.GetAsync(policyName)).Value;
            this.AssertValid(policyName, policyDefinition, getResult, false);

            Assert.AreEqual("All", getResult.Mode);
            Assert.IsEmpty(getResult.Parameters);

            // Delete definition and validate
            await this.DeleteDefinitionAndValidate(policyName);

            // Create definition with parameters
            policyDefinition = this.CreatePolicyDefinitionWithParameters(policyName);

            result = (await PolicyDefinitionsOperations.CreateOrUpdateAsync(policyDefinitionName: policyName, parameters: policyDefinition)).Value;
            Assert.NotNull(result);

            // Validate result
            getResult = (await PolicyDefinitionsOperations.GetAsync(policyName)).Value;
            this.AssertValid(policyName, policyDefinition, getResult, false);

            // Delete definition and validate
            await this.DeleteDefinitionAndValidate(policyName);
        }

        [Test]
        [Category("Will fail with async playback")]
        public async Task CanCrudDataPlanePolicyDefinition()
        {
            var policyName = Recording.GenerateAssetName("");
            var thisTestName = "CanCrudDataPlanePolicyDefinition";
            var policyDefinition = this.CreateDataPlanePolicyDefinition($"{thisTestName} Policy Definition ${LivePolicyTests.NameTag}");

            var result = (await PolicyDefinitionsOperations.CreateOrUpdateAsync(policyDefinitionName: policyName, parameters: policyDefinition)).Value;
            Assert.NotNull(result);

            // Validate result
            var getResult = (await PolicyDefinitionsOperations.GetAsync(policyName)).Value;
            Assert.NotNull(policyDefinition);
            Assert.NotNull(policyDefinition.Mode);
            Assert.Null(policyDefinition.Description);
            Assert.IsEmpty(policyDefinition.Parameters);
            this.AssertValid(policyName, policyDefinition, getResult, false);

            var listResult = await PolicyDefinitionsOperations.ListAsync().ToEnumerableAsync();
            this.AssertInList(policyName, policyDefinition, listResult);

            // Update definition
            policyDefinition.DisplayName = "Audit certificates that are not protected by RSA - v2";

            result = (await PolicyDefinitionsOperations.CreateOrUpdateAsync(policyDefinitionName: policyName, parameters: policyDefinition)).Value;
            Assert.NotNull(result);

            // Validate result
            getResult = (await PolicyDefinitionsOperations.GetAsync(policyName)).Value;
            this.AssertValid(policyName, policyDefinition, getResult, false);

            Assert.AreEqual("Microsoft.DataCatalog.Data", getResult.Mode);
            Assert.IsEmpty(getResult.Parameters);

            // Delete definition and validate
            await this.DeleteDefinitionAndValidate(policyName);
        }

        [Test]
        public async Task CanCrudPolicySetDefinition()
        {
            // Add a definition that can be referenced
            var definitionName = Recording.GenerateAssetName("");
            var thisTestName = "CanCrudPolicySetDefinition";
            var policyDefinition = this.CreatePolicyDefinition($"{thisTestName} Policy Definition ${LivePolicyTests.NameTag}");

            var definitionResult = (await PolicyDefinitionsOperations.CreateOrUpdateAsync(policyDefinitionName: definitionName, parameters: policyDefinition)).Value;
            Assert.NotNull(definitionResult);

            // First, create with minimal properties
            var setName = Recording.GenerateAssetName("");
            var policySet = new PolicySetDefinition
            {
                DisplayName = $"{thisTestName} Policy Set Definition ${LivePolicyTests.NameTag}",
                PolicyDefinitions = { new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id) }
            };

            var result = (await PolicySetDefinitionsOperations.CreateOrUpdateAsync(setName, policySet)).Value;
            Assert.NotNull(result);

            // Validate result
            var getResult = (await PolicySetDefinitionsOperations.GetAsync(setName)).Value;
            this.AssertValid(setName, policySet, getResult, false);
            Has.One.EqualTo(getResult.PolicyDefinitions);
            Assert.Null(getResult.Description);
            AssertMetadataValid(getResult.Metadata);
            Assert.IsEmpty(getResult.Parameters);
            Assert.AreEqual("Custom", getResult.PolicyType.ToString());

            var listResult = await PolicySetDefinitionsOperations.ListAsync().ToEnumerableAsync();
            this.AssertInList(setName, policySet, listResult);
            Has.One.EqualTo(getResult.PolicyDefinitions);

            // Update with extra properties
            policySet.Description = LivePolicyTests.BasicDescription;
            policySet.Metadata = LivePolicyTests.BasicMetadata;
            policySet.DisplayName = $"Updated {policySet.DisplayName}";

            // Add another definition that can be referenced (must be distinct from the first one to pass validation)
            const string refId = "refId2";
            var definitionName2 = Recording.GenerateAssetName("");
            var definitionResult2 = (await PolicyDefinitionsOperations.CreateOrUpdateAsync(policyDefinitionName: definitionName2, parameters: policyDefinition)).Value;

            policySet.PolicyDefinitions.Clear();
            policySet.PolicyDefinitions.Add(new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id));
            policySet.PolicyDefinitions.Add(new PolicyDefinitionReference(policyDefinitionId: definitionResult2.Id){ PolicyDefinitionReferenceId = refId });

            result = (await PolicySetDefinitionsOperations.CreateOrUpdateAsync(setName, policySet)).Value;
            Assert.NotNull(result);

            // validate result
            getResult = (await PolicySetDefinitionsOperations.GetAsync(setName)).Value;
            this.AssertValid(setName, policySet, getResult, false);
            Assert.AreEqual(2, getResult.PolicyDefinitions.Count);
            Assert.IsEmpty(getResult.Parameters);
            Assert.AreEqual("Custom", getResult.PolicyType.ToString());
            Assert.AreEqual(1, getResult.PolicyDefinitions.Count(definition => refId.Equals(definition.PolicyDefinitionReferenceId, StringComparison.Ordinal)));

            // Delete and validate
            await this.DeleteSetDefinitionAndValidate(setName);

            // Create a policy set with groups
            const string groupNameOne = "group1";
            const string groupNameTwo = "group2";
            policySet.PolicyDefinitionGroups.Clear();
            policySet.PolicyDefinitionGroups.Add(new PolicyDefinitionGroup(groupNameOne));
            policySet.PolicyDefinitionGroups.Add(new PolicyDefinitionGroup(groupNameTwo));

            policySet.PolicyDefinitions[0].GroupNames.Clear();
            policySet.PolicyDefinitions[0].GroupNames.Add(groupNameOne);
            policySet.PolicyDefinitions[0].GroupNames.Add(groupNameTwo);

            policySet.PolicyDefinitions[1].GroupNames.Clear();
            policySet.PolicyDefinitions[1].GroupNames.Add(groupNameTwo);

            result = (await PolicySetDefinitionsOperations.CreateOrUpdateAsync(setName, policySet)).Value;
            Assert.NotNull(result);
            this.AssertValid(setName, policySet, result, false);

            getResult = (await PolicySetDefinitionsOperations.GetAsync(setName)).Value;
            this.AssertValid(setName, policySet, getResult, false);

            // Delete and validate everything
            await this.DeleteSetDefinitionAndValidate(setName);
            await this.DeleteDefinitionAndValidate(definitionName);
            await this.DeleteDefinitionAndValidate(definitionName2);

            // create set definition with parameters
            policyDefinition = this.CreatePolicyDefinitionWithParameters(definitionName);
            definitionResult = (await PolicyDefinitionsOperations.CreateOrUpdateAsync(policyDefinitionName: definitionName, parameters: policyDefinition)).Value;
            Assert.NotNull(definitionResult);

            policySet = new PolicySetDefinition
            {
                DisplayName = $"{thisTestName} Policy Set Definition ${LivePolicyTests.NameTag}",
                PolicyDefinitions =
                {
                        new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id)
                        {
                            Parameters = { { "foo", new ParameterValuesValue() { Value = "[parameters('fooSet')]" } } }
                        }
                    },
                Parameters = { { "fooSet", new ParameterDefinitionsValue() { Type = ParameterType.String } } }
            };

            result = (await PolicySetDefinitionsOperations.CreateOrUpdateAsync(setName, policySet)).Value;
            Assert.NotNull(result);

            // validate result
            getResult = (await PolicySetDefinitionsOperations.GetAsync(setName)).Value;
            this.AssertValid(setName, policySet, getResult, false);
            Has.One.EqualTo(getResult.PolicyDefinitions);

            // Delete everything and validate
            await this.DeleteSetDefinitionAndValidate(setName);
            await this.DeleteDefinitionAndValidate(definitionName);
        }

        [Test]
        public async Task CanCrudPolicyAssignment()
        {
            // create a definition that can be assigned
            var definitionName = Recording.GenerateAssetName("");
            var thisTestName = "CanCrudPolicyAssignment";
            var policyDefinition = this.CreatePolicyDefinition($"{thisTestName} Policy Definition ${LivePolicyTests.NameTag}");

            var definitionResult = (await PolicyDefinitionsOperations.CreateOrUpdateAsync(policyDefinitionName: definitionName, parameters: policyDefinition)).Value;
            Assert.NotNull(definitionResult);

            // First, create with minimal properties
            var assignmentName = Recording.GenerateAssetName("");
            var assignmentScope = this.SubscriptionScope();
            var policyAssignment = new PolicyAssignment
            {
                DisplayName = $"{thisTestName} Policy Assignment ${LivePolicyTests.NameTag}",
                PolicyDefinitionId = definitionResult.Id,
                Sku = LivePolicyTests.A0Free
            };

            var result = (await PolicyAssignmentsOperations.CreateAsync(assignmentScope, assignmentName, policyAssignment)).Value;
            Assert.NotNull(result);

            // validate results
            var getResult = (await PolicyAssignmentsOperations.GetAsync(assignmentScope, assignmentName)).Value;

            // Default enforcement should be set even if not provided as input in PUT request.
            policyAssignment.EnforcementMode = EnforcementMode.Default;
            this.AssertValid(assignmentName, policyAssignment, getResult);
            Assert.IsEmpty(getResult.NotScopes);
            Assert.Null(getResult.Description);
            AssertMetadataValid(getResult.Metadata);
            Assert.IsEmpty(getResult.Parameters);
            Assert.AreEqual(EnforcementMode.Default, getResult.EnforcementMode);

            var listResult = await PolicyAssignmentsOperations.ListAsync().ToEnumerableAsync();
            this.AssertInList(assignmentName, policyAssignment, listResult);

            // Update with extra properties
            policyAssignment.Description = LivePolicyTests.BasicDescription;
            policyAssignment.Metadata = LivePolicyTests.BasicMetadata;
            policyAssignment.DisplayName = $"Updated {policyAssignment.DisplayName}";
            policyAssignment.Sku = LivePolicyTests.A1Standard;
            policyAssignment.Location = "eastus";
            policyAssignment.Identity = new IdentityAutoGenerated() { Type = ResourceIdentityType.SystemAssigned };
            policyAssignment.EnforcementMode = EnforcementMode.DoNotEnforce;

            result = (await PolicyAssignmentsOperations.CreateAsync(assignmentScope, assignmentName, policyAssignment)).Value;
            Assert.NotNull(result);

            // validate results
            getResult = (await PolicyAssignmentsOperations.GetByIdAsync("/" + result.Id)).Value;
            this.AssertValid(assignmentName, policyAssignment, getResult);

            // Delete policy assignment and validate
            await PolicyAssignmentsOperations.DeleteAsync(assignmentScope, assignmentName);
            try
            {
                await PolicyAssignmentsOperations.GetAsync(assignmentScope, assignmentName);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
            listResult = await PolicyAssignmentsOperations.ListAsync().ToEnumerableAsync();
            Assert.IsEmpty(listResult.Where(p => p.Name.Equals(assignmentName)));

            // Create brand new assignment with identity
            assignmentName = Recording.GenerateAssetName("");
            result = (await PolicyAssignmentsOperations.CreateAsync(assignmentScope, assignmentName, policyAssignment)).Value;
            Assert.NotNull(result);

            // validate results
            getResult = (await PolicyAssignmentsOperations.GetByIdAsync("/" + result.Id)).Value;
            this.AssertValid(assignmentName, policyAssignment, getResult);

            // Delete policy assignment and validate
            await PolicyAssignmentsOperations.DeleteAsync(assignmentScope, assignmentName);
            try
            {
                await PolicyAssignmentsOperations.GetAsync(assignmentScope, assignmentName);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
            listResult = await PolicyAssignmentsOperations.ListAsync().ToEnumerableAsync();
            Assert.IsEmpty(listResult.Where(p => p.Name.Equals(assignmentName)));

            // Delete policy definition and validate
            await this.DeleteDefinitionAndValidate(definitionName);
        }

        [Test]
        public async Task CanCrudPolicyAssignmentAtResourceGroup()
        {
            // make a test resource group
            var resourceGroupName = Recording.GenerateAssetName("");
            var resourceGroup = (await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup("westus2"))).Value;

            // make a test policy definition
            var policyDefinitionName = Recording.GenerateAssetName("");
            var thisTestName = GetCurrentMethodName();
            var policyDefinitionModel = this.CreatePolicyDefinition($"{thisTestName} Policy Definition");
            var policyDefinition = (await PolicyDefinitionsOperations.CreateOrUpdateAsync(policyDefinitionName, policyDefinitionModel)).Value;

            // assign the test policy definition to the test resource group
            var policyAssignmentName = Recording.GenerateAssetName("");
            var assignmentScope = this.ResourceGroupScope(resourceGroup);
            var policyAssignment = new PolicyAssignment
            {
                DisplayName = $"{thisTestName} Policy Assignment",
                PolicyDefinitionId = policyDefinition.Id,
                Scope = assignmentScope,
                Sku = LivePolicyTests.A0Free
            };

            var assignment = (await PolicyAssignmentsOperations.CreateAsync("/" + assignmentScope, policyAssignmentName, policyAssignment)).Value;

            // retrieve list of policies that apply to this resource group, validate exactly one matches the one we just created
            var assignments = await PolicyAssignmentsOperations.ListForResourceGroupAsync(resourceGroupName).ToEnumerableAsync();
            Has.One.EqualTo(assignments.Where(assign => assign.Name.Equals(assignment.Name)));

            // get the same item at scope and ensure it matches
            var getAssignment = (await PolicyAssignmentsOperations.GetAsync("/" + assignmentScope, assignment.Name)).Value;
            this.AssertEqual(assignment, getAssignment);

            // clean up everything
            await PolicyAssignmentsOperations.DeleteAsync("/" + assignmentScope, assignment.Name);
            await PolicyDefinitionsOperations.DeleteAsync(policyDefinition.Name);
            // No need to manual delete
            //await WaitForCompletionAsync(await ResourceGroupsOperations.StartDeleteAsync(resourceGroupName));
        }

        [Test]
        public async Task CanCrudPolicyAssignmentAtResource()
        {
            // make a test resource group
            var resourceGroupName = Recording.GenerateAssetName("");
            var resourceGroup = (await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup("eastus2"))).Value;

            // make a resource in the resource group
            var resourceName = Recording.GenerateAssetName("");
            var resource = await this.CreateResource(resourceGroup, resourceName);

            // make a test policy definition
            var policyDefinitionName = Recording.GenerateAssetName("");
            var thisTestName = GetCurrentMethodName();
            var policyDefinitionModel = this.CreatePolicyDefinition($"{thisTestName} Policy Definition");
            var policyDefinition = (await PolicyDefinitionsOperations.CreateOrUpdateAsync(policyDefinitionName, policyDefinitionModel)).Value;

            // assign the test policy definition to the test resource
            var policyAssignmentName = Recording.GenerateAssetName("");
            var assignmentScope = this.ResourceScope(resource);
            var policyAssignment = new PolicyAssignment
            {
                DisplayName = $"{thisTestName} Policy Assignment",
                PolicyDefinitionId = policyDefinition.Id,
                Scope = assignmentScope,
                Sku = LivePolicyTests.A0Free
            };

            var assignment = (await PolicyAssignmentsOperations.CreateAsync(assignmentScope, policyAssignmentName, policyAssignment)).Value;

            // retrieve list of policies that apply to this resource, validate exactly one matches the one we just created
            var assignments = await PolicyAssignmentsOperations.ListForResourceAsync(resourceGroup.Name, "", "", resource.Type, resource.Name).ToEnumerableAsync();
            Has.One.EqualTo(assignments.Where(assign => assign.Name.Equals(assignment.Name)));

            // get the same item at scope and ensure it matches
            var getAssignment = (await PolicyAssignmentsOperations.GetAsync(assignmentScope, assignment.Name)).Value;
            this.AssertEqual(assignment, getAssignment);

            // clean up everything
            await PolicyAssignmentsOperations.DeleteAsync(assignmentScope, assignment.Name);
            await PolicyDefinitionsOperations.DeleteAsync(policyDefinition.Name);
            // No need to manual delete
            //await WaitForCompletionAsync(await ResourceGroupsOperations.StartDeleteAsync(resourceGroupName));
        }

        //No Track2 ManagementGroup
        //[Test]
        //public void CanCrudPolicyDefinitionAtManagementGroup()
        //{
        //    // make a management group
        //    var managementGroupName = TestUtilities.GenerateName();
        //    var thisTestName = TestUtilities.GetCurrentMethodName();
        //    var managementGroup = this.CreateManagementGroup(managementGroupsClient, managementGroupName, thisTestName);

        //    // make a test policy definition at management group
        //    var policyDefinitionName = TestUtilities.GenerateName();
        //    var policyDefinitionModel = this.CreatePolicyDefinition($"{thisTestName} Policy Definition");
        //    var policyDefinition = client.PolicyDefinitions.CreateOrUpdateAtManagementGroup(policyDefinitionName, policyDefinitionModel, managementGroupName);
        //    Assert.NotNull(policyDefinition);

        //    // Validate result
        //    var getResult = client.PolicyDefinitions.GetAtManagementGroup(policyDefinitionName, managementGroupName);
        //    this.AssertValid(policyDefinitionName, policyDefinitionModel, getResult, false);
        //    this.AssertMinimal(getResult);

        //    var listResult = client.PolicyDefinitions.ListByManagementGroup(managementGroup.Name);
        //    this.AssertInList(policyDefinitionName, policyDefinitionModel, listResult);

        //    // Update with all properties
        //    this.UpdatePolicyDefinition(policyDefinitionModel);

        //    policyDefinition = client.PolicyDefinitions.CreateOrUpdateAtManagementGroup(policyDefinition.Name, policyDefinitionModel, managementGroup.Name);
        //    Assert.NotNull(policyDefinition);

        //    // Validate result
        //    getResult = client.PolicyDefinitions.GetAtManagementGroup(policyDefinition.Name, managementGroup.Name);
        //    this.AssertValid(policyDefinitionName, policyDefinitionModel, getResult, false);

        //    Assert.Equal("All", getResult.Mode);
        //    Assert.Null(getResult.Parameters);

        //    // clean up
        //    this.DeleteDefinitionAndValidate(client, policyDefinition.Name, managementGroup.Name);
        //    managementGroupsClient.ManagementGroups.Delete(managementGroup.Name);
        //}

        //No Track2 ManagementGroup
        //[Test]
        //public void CanCrudPolicySetDefinitionAtManagementGroup()
        //{
        //    using (var context = MockContext.Start(this.GetType()))
        //    {
        //        var client = context.GetServiceClient<PolicyClient>();
        //        var delegatingHandler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
        //        var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context, delegatingHandler);

        //        // make a management group
        //        var managementGroupName = TestUtilities.GenerateName();
        //        var thisTestName = TestUtilities.GetCurrentMethodName();
        //        var managementGroup = this.CreateManagementGroup(managementGroupsClient, managementGroupName, thisTestName);

        //        // Add a definition that can be referenced
        //        var definitionName = TestUtilities.GenerateName();
        //        var policyDefinition = this.CreatePolicyDefinition($"{thisTestName} Policy Definition ${LivePolicyTests.NameTag}");

        //        var definitionResult = client.PolicyDefinitions.CreateOrUpdateAtManagementGroup(definitionName, policyDefinition, managementGroup.Name);
        //        Assert.NotNull(definitionResult);

        //        // First, create with minimal properties
        //        var setName = TestUtilities.GenerateName();
        //        var policySet = new PolicySetDefinition
        //        {
        //            DisplayName = $"{thisTestName} Policy Set Definition ${LivePolicyTests.NameTag}",
        //            PolicyDefinitions = new[] { new PolicyDefinitionReference(definitionResult.Id) }
        //        };

        //        var result = client.PolicySetDefinitions.CreateOrUpdateAtManagementGroup(setName, policySet, managementGroup.Name);
        //        Assert.NotNull(result);

        //        // Validate result
        //        var getResult = client.PolicySetDefinitions.GetAtManagementGroup(setName, managementGroup.Name);
        //        this.AssertValid(setName, policySet, getResult, false);
        //        Assert.Single(getResult.PolicyDefinitions);
        //        Assert.Null(getResult.Description);
        //        AssertMetadataValid(getResult.Metadata);
        //        Assert.Null(getResult.Parameters);
        //        Assert.Equal("Custom", getResult.PolicyType);

        //        var listResult = client.PolicySetDefinitions.ListByManagementGroup(managementGroup.Name);
        //        this.AssertInList(setName, policySet, listResult);

        //        // Update with extra properties
        //        policySet.Description = LivePolicyTests.BasicDescription;
        //        policySet.Metadata = LivePolicyTests.BasicMetadata;
        //        policySet.DisplayName = $"Updated {policySet.DisplayName}";

        //        // Add another definition that can be referenced (must be distinct from the first one to pass validation)
        //        var definitionName2 = TestUtilities.GenerateName();
        //        var definitionResult2 = client.PolicyDefinitions.CreateOrUpdateAtManagementGroup(definitionName2, policyDefinition, managementGroup.Name);
        //        policySet.PolicyDefinitions = new[]
        //        {
        //            new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id),
        //            new PolicyDefinitionReference(policyDefinitionId: definitionResult2.Id)
        //        };

        //        result = client.PolicySetDefinitions.CreateOrUpdateAtManagementGroup(setName, policySet, managementGroup.Name);
        //        Assert.NotNull(result);

        //        // validate result
        //        getResult = client.PolicySetDefinitions.GetAtManagementGroup(setName, managementGroup.Name);
        //        this.AssertValid(setName, policySet, getResult, false);
        //        Assert.Equal(2, getResult.PolicyDefinitions.Count);
        //        Assert.Null(getResult.Parameters);
        //        Assert.Equal("Custom", getResult.PolicyType);

        //        // Delete and validate everything
        //        this.DeleteSetDefinitionAndValidate(client, setName, managementGroup.Name);
        //        this.DeleteDefinitionAndValidate(client, definitionName, managementGroup.Name);
        //        this.DeleteDefinitionAndValidate(client, definitionName2, managementGroup.Name);

        //        // create definition with parameters
        //        policyDefinition = this.CreatePolicyDefinitionWithParameters(definitionName);
        //        definitionResult = client.PolicyDefinitions.CreateOrUpdateAtManagementGroup(definitionName, policyDefinition, managementGroup.Name);
        //        Assert.NotNull(definitionResult);

        //        var referenceParameters = new Dictionary<string, ParameterValuesValue> { { "foo", new ParameterValuesValue("[parameters('fooSet')]") } };
        //        var policySetParameters = new Dictionary<string, ParameterDefinitionsValue> { { "fooSet", new ParameterDefinitionsValue(ParameterType.String) } };

        //        policySet = new PolicySetDefinition
        //        {
        //            DisplayName = $"{thisTestName} Policy Set Definition ${LivePolicyTests.NameTag}",
        //            PolicyDefinitions = new[]
        //            {
        //                new PolicyDefinitionReference(definitionResult.Id, referenceParameters)
        //            },
        //            Parameters = policySetParameters
        //        };

        //        result = client.PolicySetDefinitions.CreateOrUpdateAtManagementGroup(setName, policySet, managementGroup.Name);
        //        Assert.NotNull(result);

        //        // validate result
        //        getResult = client.PolicySetDefinitions.GetAtManagementGroup(setName, managementGroup.Name);
        //        this.AssertValid(setName, policySet, getResult, false);
        //        Assert.Single(getResult.PolicyDefinitions);

        //        // Delete everything and validate
        //        this.DeleteSetDefinitionAndValidate(client, setName, managementGroup.Name);
        //        this.DeleteDefinitionAndValidate(client, definitionName, managementGroup.Name);
        //        managementGroupsClient.ManagementGroups.Delete(managementGroupName);
        //    }
        //}

        //No Track2 ManagementGroup
        //[Test]
        //public void CanCrudPolicyAssignmentAtManagementGroup()
        //{
        //    using (var context = MockContext.Start(this.GetType()))
        //    {
        //        var client = context.GetServiceClient<PolicyClient>();
        //        var delegatingHandler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
        //        var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context, delegatingHandler);

        //        // make a management group
        //        var managementGroupName = TestUtilities.GenerateName();
        //        var thisTestName = TestUtilities.GetCurrentMethodName();
        //        var managementGroup = this.CreateManagementGroup(managementGroupsClient, managementGroupName, thisTestName);

        //        // get a builtin policy definition
        //        var policyDefinition = client.PolicyDefinitions.ListBuiltIn().First(item => item.Parameters == null);

        //        // assign the test policy definition to the test management group
        //        var policyAssignmentName = TestUtilities.GenerateName();
        //        var assignmentScope = this.ManagementGroupScope(managementGroup);
        //        var policyAssignment = new PolicyAssignment
        //        {
        //            DisplayName = $"{thisTestName} Policy Assignment",
        //            PolicyDefinitionId = policyDefinition.Id,
        //            Scope = assignmentScope,
        //            Sku = LivePolicyTests.A0Free
        //        };

        //        // assign at management group scope
        //        var assignment = client.PolicyAssignments.Create(assignmentScope, policyAssignmentName, policyAssignment);

        //        // get at management group scope, validate result matches
        //        var getAssignment = client.PolicyAssignments.Get(assignmentScope, assignment.Name);
        //        this.AssertEqual(assignment, getAssignment);

        //        // clean up everything
        //        client.PolicyAssignments.Delete(assignmentScope, assignment.Name);
        //        managementGroupsClient.ManagementGroups.Delete(managementGroupName);
        //    }
        //}

        [Test]
        public async Task ValidatePolicyAssignmentErrorHandling()
        {
            // Add a definition that can be assigned
            var definitionName = Recording.GenerateAssetName("");
            var thisTestName = "ValidatePolicyAssignmentErrorHandling";
            var policyDefinition = this.CreatePolicyDefinition($"{thisTestName} Policy Definition ${LivePolicyTests.NameTag}");
            var definitionResult = (await PolicyDefinitionsOperations.CreateOrUpdateAsync(policyDefinitionName: definitionName, parameters: policyDefinition)).Value;
            Assert.NotNull(definitionResult);

            // Missing policy definition id
            var assignmentName = Recording.GenerateAssetName("");
            var assignmentScope = this.SubscriptionScope();
            var policyAssignment = new PolicyAssignment
            {
                DisplayName = $"{thisTestName} Bad Assignment - Missing Policy Definition Id {LivePolicyTests.NameTag}",
                Sku = LivePolicyTests.A0Free
            };

            try
            {
                await PolicyAssignmentsOperations.CreateAsync(assignmentScope, assignmentName, policyAssignment);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsTrue(ex.Message.ToString().Contains("InvalidRequestContent"));
            }

            // nonexistent policy definition id
            policyAssignment = new PolicyAssignment
            {
                DisplayName = $"{thisTestName} Bad Assignment - Bad Policy Definition Id {LivePolicyTests.NameTag}",
                Sku = LivePolicyTests.A0Free,
                PolicyDefinitionId = definitionResult.Id.Replace(definitionName, Recording.GenerateAssetName(""))
            };

            try
            {
                await PolicyAssignmentsOperations.CreateAsync(assignmentScope, assignmentName, policyAssignment);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsTrue(ex.Message.ToString().Contains("PolicyDefinitionNotFound"));
            }

            // Invalid SKU
            policyAssignment = new PolicyAssignment
            {
                DisplayName = $"{thisTestName} Bad Assignment - Bad Policy Sku {LivePolicyTests.NameTag}",
                Sku = LivePolicyTests.A2FreeInvalid,
                PolicyDefinitionId = definitionResult.Id
            };

            try
            {
                await PolicyAssignmentsOperations.CreateAsync(assignmentScope, assignmentName, policyAssignment);
            }

            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsTrue(ex.Message.ToString().Contains("InvalidPolicySku"));
            }

            // Delete policy definition and validate
            await this.DeleteDefinitionAndValidate(definitionName);
        }

        [Test]
        public async Task ValidatePolicyDefinitionErrorHandling()
        {
            // Missing rule
            var definitionName = Recording.GenerateAssetName("");
            var thisTestName = "ValidatePolicyDefinitionErrorHandling";
            var policyDefinition = new PolicyDefinition
            {
                DisplayName = $"{thisTestName} - Missing Rule {LivePolicyTests.NameTag}"
            };

            try
            {
                await PolicyDefinitionsOperations.CreateOrUpdateAsync(definitionName, policyDefinition);
            }

            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsTrue(ex.Message.ToString().Contains("InvalidRequestContent"));
            }

            // Invalid Mode
            policyDefinition = this.CreatePolicyDefinition($"{thisTestName} - Bad Mode ${LivePolicyTests.NameTag}");
            policyDefinition.Mode = "Foo";

            try
            {
                await PolicyDefinitionsOperations.CreateOrUpdateAsync(definitionName, policyDefinition);
            }

            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsTrue(ex.Message.ToString().Contains("InvalidPolicyDefinitionMode"));
            }

            // Unused parameter
            policyDefinition = this.CreatePolicyDefinition($"{thisTestName} - Unused Parameter ${LivePolicyTests.NameTag}");
            policyDefinition.Parameters.InitializeFrom(LivePolicyTests.BasicParameters);

            try
            {
                await PolicyDefinitionsOperations.CreateOrUpdateAsync(definitionName, policyDefinition);
            }

            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsTrue(ex.Message.ToString().Contains("UnusedPolicyParameters"));
            }

            // Missing parameter
            policyDefinition = this.CreatePolicyDefinitionWithoutParameter($"{thisTestName} - Missing Parameter ${LivePolicyTests.NameTag}");

            try
            {
                await PolicyDefinitionsOperations.CreateOrUpdateAsync(definitionName, policyDefinition);
            }

            catch (Exception ex)
            {
                Assert.NotNull(ex);
                StringAssert.Contains("InvalidPolicyParameters", ex.Message);
            }
        }

        [Test]
        public async Task ValidatePolicySetDefinitionErrorHandling()
        {
            // Create a definition that can be assigned
            var definitionName = Recording.GenerateAssetName("");
            var thisTestName = "ValidatePolicySetDefinitionErrorHandling";
            var policyDefinition = this.CreatePolicyDefinition($"{thisTestName} Policy Definition ${LivePolicyTests.NameTag}");

            var definitionResult = (await PolicyDefinitionsOperations.CreateOrUpdateAsync(definitionName, policyDefinition)).Value;
            Assert.NotNull(definitionResult);

            // Missing policy definition references
            var setName = Recording.GenerateAssetName("");
            var policySetDefinition = new PolicySetDefinition
            {
                DisplayName = $"{thisTestName} Bad Set Definition - Missing Policies {LivePolicyTests.NameTag}"
            };

            try
            {
                await PolicySetDefinitionsOperations.CreateOrUpdateAsync(setName, policySetDefinition);
            }

            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsTrue(ex.Message.ToString().Contains("policyDefinitions"));
            }

            // Invalid definition reference
            policySetDefinition = new PolicySetDefinition
            {
                DisplayName = $"{thisTestName} Bad Set Definition - Bad Policy Id {LivePolicyTests.NameTag}",
                PolicyDefinitions =
                {
                        new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id.Replace(definitionName, Recording.GenerateAssetName("")))
                    }
            };

            try
            {
                await PolicySetDefinitionsOperations.CreateOrUpdateAsync(setName, policySetDefinition);
            }

            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsTrue(ex.Message.ToString().Contains("PolicyDefinitionNotFound"));
            }

            // Unused parameter
            policySetDefinition = new PolicySetDefinition
            {
                DisplayName = $"{thisTestName} Bad Set Definition - Unused Parameter {LivePolicyTests.NameTag}",
                PolicyDefinitions =
                {
                        new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id)
                }
            };

            policySetDefinition.Parameters.InitializeFrom(LivePolicyTests.BasicParameters);

            try
            {
                await PolicySetDefinitionsOperations.CreateOrUpdateAsync(setName, policySetDefinition);
            }

            catch (Exception ex)
            {
                Assert.NotNull(ex);
                StringAssert.Contains("UnusedPolicyParameters", ex.Message);
                Assert.IsTrue(ex.Message.ToString().Contains(""));
            }

            // Invalid reference parameters
            policySetDefinition = new PolicySetDefinition
            {
                DisplayName = $"{thisTestName} Bad Set Definition - Bad Reference Parameter {LivePolicyTests.NameTag}",
                PolicyDefinitions =
                {
                    new PolicyDefinitionReference(policyDefinitionId: definitionResult.Id)
                    {
                        Parameters =
                        {
                            { "foo", new ParameterValuesValue() { Value = "abc" } }
                        }
                    }
                }
            };

            try
            {
                await PolicySetDefinitionsOperations.CreateOrUpdateAsync(setName, policySetDefinition);
            }

            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsTrue(ex.Message.ToString().Contains("UndefinedPolicyParameter"));
            }

            // delete and validate
            await this.DeleteDefinitionAndValidate(definitionName);
        }

        [Test]
        public async Task CanListAndGetBuiltinPolicyDefinitions()
        {
            // list all builtin policy definitions
            var allBuiltIn = await PolicyDefinitionsOperations.ListBuiltInAsync().ToEnumerableAsync();

            // validate list results
            foreach (var builtIn in allBuiltIn)
            {
                // validate that list items are all valid
                this.AssertValid(builtIn, true);

                // validate that individual get matches list results
                var getBuiltIn = (await PolicyDefinitionsOperations.GetBuiltInAsync(builtIn.Name)).Value;
                this.AssertEqual(builtIn, getBuiltIn, true);
            }
        }

        [Test]
        public async Task CannotDeleteBuiltInPolicyDefinitions()
        {
            // list all builtin policy definitions
            var allBuiltIns = await PolicyDefinitionsOperations.ListBuiltInAsync().ToEnumerableAsync();

            // try to delete the first 50
            foreach (var builtIn in allBuiltIns.Take(50))
            {
                await PolicyDefinitionsOperations.DeleteAsync(builtIn.Name);
            }

            // get the list again, verify it hasn't changed
            var allBuiltIn2 = await PolicyDefinitionsOperations.ListBuiltInAsync().ToEnumerableAsync();

            Assert.AreEqual(allBuiltIns.Count(), allBuiltIn2.Count());
            foreach (var builtIn in allBuiltIns)
            {
                Has.One.EqualTo(allBuiltIn2.Where(policy => policy.Name.Equals(builtIn.Name)));
            }
        }

        [Test]
        public async Task CanListAndGetBuiltinPolicySetDefinitions()
        {
            // list all builtin policy definitions
            var allBuiltIn = await PolicySetDefinitionsOperations.ListBuiltInAsync().ToEnumerableAsync();

            // validate list results
            foreach (var builtIn in allBuiltIn)
            {
                // validate that list items are all valid
                this.AssertValid(builtIn, true);

                // validate that individual get is valid and matches list results
                var getBuiltIn = (await PolicySetDefinitionsOperations.GetBuiltInAsync(builtIn.Name)).Value;
                this.AssertValid(getBuiltIn, true);
                this.AssertEqual(builtIn, getBuiltIn, true);

                // validate that each policy reference points to a policy definition that exists and is builtin
                foreach (var policyReference in builtIn.PolicyDefinitions)
                {
                    var parts = policyReference.PolicyDefinitionId.Split('/');
                    var name = parts.Last();
                    var policyDefinition = (await PolicyDefinitionsOperations.GetBuiltInAsync(name)).Value;
                    this.AssertValid(policyDefinition, true);
                }
            }
        }

        [Test]
        public async Task CannotDeleteBuiltInPolicySetDefinitions()
        {
            // list all builtin policy definitions
            var allBuiltIn = await PolicySetDefinitionsOperations.ListBuiltInAsync().ToEnumerableAsync();

            // try to delete them all
            foreach (var builtIn in allBuiltIn)
            {
                await PolicySetDefinitionsOperations.DeleteAsync(builtIn.Name);
            }

            // get the list again, verify it hasn't changed
            var allBuiltIn2 = await PolicySetDefinitionsOperations.ListBuiltInAsync().ToEnumerableAsync();

            Assert.AreEqual(allBuiltIn.Count(), allBuiltIn2.Count());
            foreach (var builtIn in allBuiltIn)
            {
                Has.One.EqualTo(allBuiltIn2.Where(policy => policy.Name.Equals(builtIn.Name)));
            }
        }

        // test values
        private const string NameTag = "[Auto Test]";
        private const string BasicDescription = "Description text";
        private static readonly Dictionary<string, object> BasicMetadata = new Dictionary<string, object>{ {"category", "sdk test"} };
        private static readonly IDictionary<string, ParameterDefinitionsValue> BasicParameters = new Dictionary<string, ParameterDefinitionsValue> { { "foo", new ParameterDefinitionsValue() { Type = ParameterType.String } } };
        private static readonly PolicySku A0Free = new PolicySku("A0") { Tier = "Free" };
        private static readonly PolicySku A1Standard = new PolicySku("A1") { Tier = "Standard" };
        private static readonly PolicySku A2FreeInvalid = new PolicySku("A2") { Tier = "Free" };

        // create a minimal policy definition model
        private PolicyDefinition CreatePolicyDefinition(string displayName) => new PolicyDefinition
        {
            DisplayName = displayName,
            PolicyRule = new Dictionary<string, object>
            {
                {
                    "if", new Dictionary<string, object>
                    {
                        { "source", "action" },
                        { "equals", "ResourceProviderTestHost/TestResourceType/TestResourceTypeNestedOne/write"}
                    }
                },
                {
                    "then", new Dictionary<string, object>
                    {
                        { "effect", "deny" }
                    }
                }
            }
        };

        // create a minimal dataplane policy definition model
        private PolicyDefinition CreateDataPlanePolicyDefinition(string displayName) => new PolicyDefinition
        {
            DisplayName = displayName,
            Mode = "Microsoft.DataCatalog.Data",
            PolicyRule = new Dictionary<string, object>
            {
                {
                    "if", new Dictionary<string, object>
                    {
                        { "field", "Microsoft.DataCatalog.Data/catalog/entity/type"},
                        { "notEquals", "foo"}
                    }
                },
                {
                    "then", new Dictionary<string, object>
                    {
                        { "effect", "ModifyClassifications" },
                        { "details", new Dictionary<string, object>
                            {
                                { "classificationsToAdd", new List<string>{"foo"} },
                                { "classificationsToRemove", new List<string>{"bar"} }
                            }
                        }
                    }
                }
            }
        };

        // create a minimal policy definition model with parameter
        private PolicyDefinition CreatePolicyDefinitionWithParameters(string displayName)
        {
            var definition = new PolicyDefinition
            {
                DisplayName = displayName,
                PolicyRule = new Dictionary<string, object>
                {
                    {
                        "if", new Dictionary<string, object>
                        {
                            {"source", "action"},
                            {"equals", "[parameters('foo')]"}
                        }
                    },
                    {
                        "then", new Dictionary<string, object>
                        {
                            {"effect", "deny"}
                        }
                    }
                }
            };
            definition.Parameters.InitializeFrom(LivePolicyTests.BasicParameters);
            return definition;
        }

        // create a minimal policy definition model without any parameters
        private PolicyDefinition CreatePolicyDefinitionWithoutParameter(string displayName) => new PolicyDefinition
        {
            DisplayName = displayName,
            PolicyRule = new Dictionary<string, object>
            {
                {
                    "if", new Dictionary<string, object>
                    {
                        {"source", "action"},
                        {"equals", "[parameters('foo')]"}
                    }
                },
                {
                    "then", new Dictionary<string, object>
                    {
                        {"effect", "deny"}
                    }
                }
            }
        };

        // create a resource in the given resource group
        private async Task<Resource> CreateResource(ResourceGroup resourceGroup, string resourceName)
        {
            var result = await ResourcesOperations.StartCreateOrUpdateAsync(
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
                    Properties = JsonSerializer.Deserialize<Dictionary<string, object>>("{}")
                });
            return (await WaitForCompletionAsync(result)).Value;
        }

        //No Track2 ManagementGroup
        //private ManagementGroup CreateManagementGroup(ManagementGroupsAPIClient client, string name, string displayName)
        //{
        //    // get an existing test management group to be parent
        //    var allManagementGroups = client.ManagementGroups.List();
        //    var parentManagementGroup = allManagementGroups.First(item => item.Name.Equals(ParentManagementGroup));

        //    // make a management group using the given parameters
        //    var managementGroupDetails = new CreateManagementGroupDetails(parent: new CreateParentGroupInfo(id: parentManagementGroup.Id), updatedBy: displayName);
        //    var managementGroupRequest = new CreateManagementGroupRequest(type: parentManagementGroup.Type, name: name, details: managementGroupDetails, displayName: displayName);

        //    var managementGroupResult = client.ManagementGroups.CreateOrUpdate(name, managementGroupRequest);
        //    Assert.NotNull(managementGroupResult);

        //    var managementGroup = ((JObject)managementGroupResult).ToObject<ManagementGroup>();
        //    Assert.NotNull(managementGroup);
        //    return managementGroup;
        //}

        // validate that the given policy definition does not have extra fields
        private void AssertMinimal(PolicyDefinition definition)
        {
            Assert.NotNull(definition);
            Assert.AreEqual("Indexed", definition.Mode);
            Assert.Null(definition.Description);
            AssertMetadataValid(definition.Metadata);
            Assert.IsEmpty(definition.Parameters);
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
            Assert.IsNotEmpty(result.Name);
            Assert.NotNull(result.DisplayName);
            Assert.IsNotEmpty(result.DisplayName);
            Assert.NotNull(result.PolicyType);
            if (isBuiltin)
            {
                Assert.True(result.PolicyType.ToString().Equals("BuiltIn", StringComparison.Ordinal) || result.PolicyType.ToString().Equals("Static", StringComparison.Ordinal));
            }
            else
            {
                Assert.AreEqual("Custom", result.PolicyType.ToString());
            }

            Assert.NotNull(result.PolicyRule);
            Assert.IsNotEmpty(result.PolicyRule.ToString());
            Assert.NotNull(result.Type);
            Assert.AreEqual("Microsoft.Authorization/policyDefinitions", result.Type);
            Assert.NotNull(result.Id);
            StringAssert.EndsWith($"/providers/{result.Type}/{result.Name}", result.Id);
            if (isBuiltin)
            {
                Assert.NotNull(result.Description);
                Assert.IsNotEmpty(result.Description);
            }
            if (result.Mode != null)
            {
                if (!result.Mode.StartsWith("Microsoft.", StringComparison.OrdinalIgnoreCase))
                {
                    Assert.True(result.Mode.Equals("NotSpecified") || result.Mode.Equals("All") || result.Mode.Equals("Indexed"));
                }
                else
                {
                    Assert.That(result.Mode, Does.Match(@"Microsoft\.\w+\.Data"));
                }
            }
        }

        // validate that the given result policy definition matches the given name and model
        private void AssertValid(string policyName, PolicyDefinition model, PolicyDefinition result, bool isBuiltin)
        {
            this.AssertValid(result, isBuiltin);
            Assert.AreEqual(policyName, result.Name);
            Assert.AreEqual(model.DisplayName, result.DisplayName);
            Assert.AreEqual(JsonSerializer.Serialize(model.PolicyRule).ToString(), JsonSerializer.Serialize(result.PolicyRule).ToString());
            AssertModeEqual(model.Mode, result.Mode);
            Assert.AreEqual(model.Description, result.Description);
            if (model.Metadata != null)
                AssertMetadataEqual(model.Metadata, result.Metadata, isBuiltin);
            Assert.AreEqual(model.Parameters.Count, result.Parameters.Count);
        }

        // validate that the given result policy definition is equal to the expected one
        private void AssertEqual(PolicyDefinition expected, PolicyDefinition result, bool isBuiltin)
        {
            Assert.NotNull(result);
            Assert.NotNull(expected);
            Assert.AreEqual(expected.Description, result.Description);
            Assert.AreEqual(expected.DisplayName, result.DisplayName);
            Assert.AreEqual(expected.Id, result.Id);
            AssertMetadataEqual(expected.Metadata, result.Metadata, isBuiltin);
            AssertModeEqual(expected.Mode, result.Mode);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Parameters?.ToString(), result.Parameters?.ToString());
            Assert.AreEqual(expected.PolicyRule.ToString(), result.PolicyRule.ToString());
            Assert.AreEqual(expected.PolicyType, result.PolicyType);
            Assert.AreEqual(expected.Type, result.Type);
        }

        // validate that the given list result contains exactly one policy definition that matches the given name and model
        private void AssertInList(string policyName, PolicyDefinition model, List<PolicyDefinition> listResult)
        {
            Assert.IsNotEmpty(listResult);
            var policyInList = listResult.Where(p => p.Name.Equals(policyName)).ToList();
            Assert.NotNull(policyInList);
            Has.One.EqualTo(policyInList);
            this.AssertValid(policyName, model, policyInList.Single(), false);
        }

        // delete the policy definition matching the given name and validate it is gone
        private async Task DeleteDefinitionAndValidate(string policyName, string managementGroupName = null)
        {
            if (managementGroupName == null)
            {
                await PolicyDefinitionsOperations.DeleteAsync(policyName);
                try
                {
                    await PolicyDefinitionsOperations.GetAsync(policyName);
                }
                catch (Exception ex)
                {
                    Assert.NotNull(ex);
                }
                var listResult = await PolicyDefinitionsOperations.ListAsync().ToEnumerableAsync();
                Assert.IsEmpty(listResult.Where(p => p.Name.Equals(policyName)));
            }
            else
            {
                await PolicyDefinitionsOperations.DeleteAtManagementGroupAsync(policyName, managementGroupName);
                try
                {
                    await PolicyDefinitionsOperations.GetAtManagementGroupAsync(policyName, managementGroupName);
                }
                catch (Exception ex)
                {
                    Assert.NotNull(ex);
                }
                var listResult = await PolicyDefinitionsOperations.ListByManagementGroupAsync(managementGroupName).ToEnumerableAsync();
                Assert.IsEmpty(listResult.Where(p => p.Name.Equals(policyName)));
            }
        }

        // validate that the given result is a valid policy set definition
        private void AssertValid(PolicySetDefinition result, bool isBuiltin)
        {
            Assert.NotNull(result);
            Assert.NotNull(result.Name);
            Assert.IsNotEmpty(result.Name);
            Assert.NotNull(result.DisplayName);
            Assert.IsNotEmpty(result.DisplayName);
            Assert.NotNull(result.PolicyType);
            Assert.AreEqual(isBuiltin ? "BuiltIn" : "Custom", result.PolicyType.ToString());
            Assert.NotNull(result.Type);
            Assert.AreEqual("Microsoft.Authorization/policySetDefinitions", result.Type);
            Assert.NotNull(result.Id);
            StringAssert.EndsWith($"/providers/{result.Type}/{result.Name}", result.Id);
            if (isBuiltin)
            {
                Assert.NotNull(result.Description);
                Assert.IsNotEmpty(result.Description);
            }
            Assert.IsNotEmpty(result.PolicyDefinitions);
            foreach (var policyDefinition in result.PolicyDefinitions)
            {
                Assert.NotNull(policyDefinition);
                Assert.NotNull(policyDefinition.PolicyDefinitionId);
                Assert.NotNull(policyDefinition.PolicyDefinitionReferenceId);
                Assert.IsTrue(policyDefinition.PolicyDefinitionId.Contains("/providers/Microsoft.Authorization/policyDefinitions/"));
            }
        }

        // validate that the given result policy set matches the given name and model
        private void AssertValid(string policySetName, PolicySetDefinition model, PolicySetDefinition result, bool isBuiltin)
        {
            this.AssertValid(result, isBuiltin);
            Assert.AreEqual(policySetName, result.Name);

            Assert.AreEqual(model.DisplayName, result.DisplayName);
            Assert.AreEqual(model.Description, result.Description);
            if (model.Metadata != null)
                AssertMetadataEqual(model.Metadata, result.Metadata, isBuiltin);
            Assert.AreEqual(model.Parameters?.Count, result.Parameters?.Count);
            Assert.AreEqual(model.PolicyDefinitions.Count, result.PolicyDefinitions.Count);
            foreach (var expectedDefinition in model.PolicyDefinitions)
            {
                var resultDefinitions = result.PolicyDefinitions.Where(def => def.PolicyDefinitionId.Equals(expectedDefinition.PolicyDefinitionId));
                Assert.True(resultDefinitions.Count() > 0);
                var resultDefinition = resultDefinitions.Single(def => expectedDefinition.PolicyDefinitionReferenceId == null || expectedDefinition.PolicyDefinitionReferenceId.Equals(def.PolicyDefinitionReferenceId, StringComparison.Ordinal));
                if (expectedDefinition.GroupNames != null)
                {
                    Assert.AreEqual(expectedDefinition.GroupNames.Count(), resultDefinition.GroupNames.Count());
                    Assert.AreEqual(expectedDefinition.GroupNames.Count(), expectedDefinition.GroupNames.Intersect(resultDefinition.GroupNames).Count());
                }
                else
                {
                    Assert.Null(resultDefinition.GroupNames);
                }
            }

            if (model.PolicyDefinitionGroups != null)
            {
                foreach (var group in model.PolicyDefinitionGroups)
                {
                    Assert.AreEqual(1, result.PolicyDefinitionGroups.Count(resultGroup => resultGroup.Name.Equals(group.Name, StringComparison.Ordinal)));
                }
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
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.PolicyType, result.PolicyType);
            Assert.AreEqual(expected.Type, result.Type);
            AssertValid(expected.Name, expected, result, isBuiltin);
        }

        // validate that the given list result contains exactly one policy set definition that matches the given name and model
        private void AssertInList(string policySetName, PolicySetDefinition model, List<PolicySetDefinition> listResult)
        {
            Assert.IsNotEmpty(listResult);
            var policySetInList = listResult.Where(p => p.Name.Equals(policySetName)).ToList();
            Assert.NotNull(policySetInList);
            Has.One.EqualTo(policySetInList);
            this.AssertValid(policySetName, model, policySetInList.Single(), false);
        }

        // delete the policy set definition matching the given name and validate it is gone
        private async Task DeleteSetDefinitionAndValidate(string policySetName, string managementGroupName = null)
        {
            if (managementGroupName == null)
            {
                await PolicySetDefinitionsOperations.DeleteAsync(policySetName);
                try
                {
                    await PolicySetDefinitionsOperations.GetAsync(policySetName);
                }
                catch (Exception ex)
                {
                    Assert.NotNull(ex);
                }
                var listResult = await PolicySetDefinitionsOperations.ListAsync().ToEnumerableAsync();
                Assert.IsEmpty(listResult.Where(p => p.Name.Equals(policySetName)));
            }
            else
            {
                await PolicySetDefinitionsOperations.DeleteAtManagementGroupAsync(policySetName, managementGroupName);
                try
                {
                    await PolicySetDefinitionsOperations.GetAtManagementGroupAsync(policySetName, managementGroupName);
                }
                catch (Exception ex)
                {
                    Assert.NotNull(ex);
                }
                var listResult = await PolicySetDefinitionsOperations.ListByManagementGroupAsync(managementGroupName).ToEnumerableAsync();
                Assert.IsEmpty(listResult.Where(p => p.Name.Equals(policySetName)));
            }
        }

        // validate that the given result policy assignment matches the given name and model
        private void AssertValid(string assignmentName, PolicyAssignment model, PolicyAssignment result)
        {
            Assert.NotNull(result);
            Assert.AreEqual(assignmentName, result.Name);

            Assert.AreEqual(model.DisplayName, result.DisplayName);
            Assert.AreEqual(model.Description, result.Description);
            AssertMetadataValid(result.Metadata);
            Assert.AreEqual(model.Parameters?.ToString(), result.Parameters?.ToString());
            Assert.AreEqual(model.PolicyDefinitionId, result.PolicyDefinitionId);
            Assert.AreEqual(model.Sku.Name, result.Sku.Name);
            Assert.AreEqual(model.Sku.Tier, result.Sku.Tier);
            Assert.AreEqual(model.Location, result.Location);
            Assert.AreEqual(model.EnforcementMode, result.EnforcementMode);
            if (model.Identity != null)
            {
                Assert.AreEqual(model.Identity.Type, result.Identity.Type);
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
            Assert.AreEqual(expected.Description, result.Description);
            Assert.AreEqual(expected.DisplayName, result.DisplayName);
            Assert.AreEqual(expected.Id, result.Id);
            AssertMetadataEqual(expected.Metadata, result.Metadata, false);
            Assert.AreEqual(expected.Name, result.Name);
            if (expected.NotScopes == null)
            {
                Assert.Null(result.NotScopes);
            }
            else
            {
                Assert.AreEqual(expected.NotScopes.Count, result.NotScopes.Count);
                foreach (var notscope in expected.NotScopes)
                {
                    //Assert.Single(notscope, result.NotScopes.Where(item => item == notscope));
                    Assert.That(notscope, Is.EqualTo(result.NotScopes.Where(item => item == notscope)));
                }
            }

            Assert.AreEqual(expected.Parameters?.ToString(), result.Parameters?.ToString());
            Assert.AreEqual(expected.PolicyDefinitionId, result.PolicyDefinitionId);
            Assert.AreEqual(expected.Scope, result.Scope);
            Assert.AreEqual(expected.Sku.ToString(), result.Sku.ToString());
            Assert.AreEqual(expected.Type, result.Type);
            Assert.AreEqual(expected.Location, result.Location);
            Assert.AreEqual(expected.Identity?.Type, result.Identity?.Type);
            Assert.AreEqual(expected.Identity?.PrincipalId, result.Identity?.PrincipalId);
            Assert.AreEqual(expected.Identity?.TenantId, result.Identity?.TenantId);
        }

        // validate that the given list result contains exactly one policy assignment matching the given name and model model
        private void AssertInList(string assignmentName, PolicyAssignment model, List<PolicyAssignment> listResult)
        {
            Assert.IsNotEmpty(listResult);
            var assignmentInList = listResult.FirstOrDefault(p => p.Name.Equals(assignmentName));
            Assert.NotNull(assignmentInList);
            this.AssertValid(assignmentName, model, assignmentInList);
        }

        private void AssertModeEqual(string expected, string actual)
        {
            if (expected == null)
            {
                Assert.AreEqual("Indexed", actual);
            }
            else
            {
                Assert.AreEqual(expected, actual);
            }
        }

        private void AssertMetadataValid(object metaDataObject)
        {
            if (metaDataObject != null)
            {
                var metaData = JsonDocument.Parse(JsonSerializer.Serialize(metaDataObject)).RootElement;
                var createdBy = metaData.GetProperty("createdBy");
                Assert.NotNull(createdBy);
                var createdOn = metaData.GetProperty("createdOn");
                Assert.NotNull(createdOn);
                var updatedBy = metaData.GetProperty("updatedBy");
                Assert.NotNull(updatedBy);
            }
        }

        private void AssertMetadataEqual(object expectedObject, object actualObject, bool isBuiltin)
        {
            if (!isBuiltin)
            {
                AssertMetadataValid(actualObject);
            }

            var expected = JsonDocument.Parse(JsonSerializer.Serialize(expectedObject)).RootElement;
            if (!expected.Equals(null))
            {
                var actual = JsonDocument.Parse(JsonSerializer.Serialize(actualObject)).RootElement;
                foreach (var property in expected.EnumerateObject())
                {
                    JsonElement value = new JsonElement();
                    Assert.NotNull(actual.TryGetProperty(property.Name, out value));
                    Assert.NotNull(value);
                }
            }
        }

        // get subscription scope of the given client
        private string SubscriptionScope() => $"//subscriptions/{TestEnvironment.SubscriptionId}";

        // get resource group scope of the given client and resource group
        private string ResourceGroupScope(ResourceGroup resourceGroup) => $"{resourceGroup.Id}";

        // get resource scope of the given client and resource
        private string ResourceScope(Resource resource) => $"{resource.Id}";

        // get management group scope of the given client and management group
        //private string ManagementGroupScope(ManagementGroup managementGroup) => $"{managementGroup.Id}";

        public static string GetCurrentMethodName()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }
    }
}
