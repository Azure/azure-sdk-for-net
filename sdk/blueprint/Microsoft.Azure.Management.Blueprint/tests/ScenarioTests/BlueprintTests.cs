// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Management.Blueprint.Tests.ScenarioTests
{
    using Microsoft.Azure.Management.Blueprint;
    using Microsoft.Azure.Management.Blueprint.Customizations.Extensions;
    using Microsoft.Azure.Management.Blueprint.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json.Linq;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class BlueprintTests
    {
        /// <summary>
        /// Cover blueprint operations on raw scope
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DynamicBlueprintCRUD()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new BlueprintTestBase(context))
                {
                    await DynamicBlueprintCRUDInternal(testFixture, "/subscriptions/7e2bacd2-6c4b-444c-9331-2e76799cbfc9");
                    await DynamicBlueprintCRUDInternal(testFixture, "/providers/Microsoft.Management/managementGroups/emptyMG");
                }
            }
        }

        /// <summary>
        /// XUnit [Theory] with [InlineData] works, 
        /// but recording/playback doen't work, it generate single recording file, with recording from latest permutation.
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        private async Task DynamicBlueprintCRUDInternal(BlueprintTestBase testFixture, string scope)
        {
            string blueprintName = "dynamicBPFromDotnetSDK",
                blueprintName2 = "dynamicBPFromDotnetSDK2";

            // create
            var blueprint = CreateSimpleBlueprint();
            await testFixture.BlueprintClient.Blueprints.CreateOrUpdateAsync(scope, blueprintName, blueprint);

            // get
            var blueprintGet = await testFixture.BlueprintClient.Blueprints.GetAsync(scope, blueprintName);
            Assert.Equal(blueprintName, blueprintGet.Name);
            Assert.Equal("Microsoft.Blueprint/blueprints", blueprintGet.Type);
            Assert.Equal(Constants.BlueprintTargetScopes.Subscription, blueprintGet.TargetScope);
            Assert.Equal(3, blueprintGet.Parameters.Count);

            // update
            blueprint.Parameters.Add("defaultKeyVaultStore", new ParameterDefinition { Type = Constants.ParameterDefinitionTypes.String, DisplayName = "resource id for keyVault." });
            blueprintGet = await testFixture.BlueprintClient.Blueprints.CreateOrUpdateAsync(scope, blueprintName, blueprint);
            Assert.Contains("defaultKeyVaultStore", blueprintGet.Parameters.Keys);

            // list
            await testFixture.BlueprintClient.Blueprints.CreateOrUpdateAsync(scope, blueprintName2, blueprint);
            var blueprints = await testFixture.BlueprintClient.Blueprints.ListAsync(scope);
            Assert.Equal(2, blueprints.Count());
            Assert.Single(blueprints.Where(bp => bp.Name.Equals(blueprintName)));
            Assert.Single(blueprints.Where(bp => bp.Name.Equals(blueprintName2)));

            // delete
            await testFixture.BlueprintClient.Blueprints.DeleteAsync(scope, blueprintName);
            await testFixture.BlueprintClient.Blueprints.DeleteAsync(scope, blueprintName2);
        }

        /// <summary>
        /// cover blueprint operations on MG 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ManagementGroupBlueprintCRUD()
        {
            string managementGroupName = "emptyMG",
                blueprintName = "MGBPfromDotnetSDK",
                blueprintName2 = "MGBPfromDotnetSDK2";

            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new BlueprintTestBase(context))
                {
                    // create
                    var blueprint = CreateSimpleBlueprint();
                    await testFixture.BlueprintClient.Blueprints.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, blueprint);

                    // get
                    var blueprintGet = await testFixture.BlueprintClient.Blueprints.GetInManagementGroupAsync(managementGroupName, blueprintName);
                    Assert.Equal(blueprintName, blueprintGet.Name);
                    Assert.Equal("Microsoft.Blueprint/blueprints", blueprintGet.Type);
                    Assert.Equal(Constants.BlueprintTargetScopes.Subscription, blueprintGet.TargetScope);
                    Assert.Equal(3, blueprintGet.Parameters.Count);

                    // update
                    blueprint.Parameters.Add("defaultKeyVaultStore", new ParameterDefinition { Type = Constants.ParameterDefinitionTypes.String, DisplayName = "resource id for keyVault." });
                    blueprintGet = await testFixture.BlueprintClient.Blueprints.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, blueprint);
                    Assert.Contains("defaultKeyVaultStore", blueprintGet.Parameters.Keys);

                    // list
                    await testFixture.BlueprintClient.Blueprints.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName2, blueprint);
                    var blueprints = await testFixture.BlueprintClient.Blueprints.ListInManagementGroupAsync(managementGroupName);
                    Assert.Equal(2, blueprints.Count());
                    Assert.Single(blueprints.Where(bp => bp.Name.Equals(blueprintName)));
                    Assert.Single(blueprints.Where(bp => bp.Name.Equals(blueprintName2)));

                    // delete
                    await testFixture.BlueprintClient.Blueprints.DeleteInManagementGroupAsync(managementGroupName, blueprintName);
                    await testFixture.BlueprintClient.Blueprints.DeleteInManagementGroupAsync(managementGroupName, blueprintName2);
                }
            }
        }

        /// <summary>
        /// cover blueprint operations on Subscription 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task SubscriptionBlueprintCRUD()
        {
            string subscriptionId = "7e2bacd2-6c4b-444c-9331-2e76799cbfc9",
                blueprintName = "subBPfromDotnetSDK",
                blueprintName2 = "subBPfromDotnetSDK2";

            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new BlueprintTestBase(context))
                {
                    // create
                    var blueprint = CreateSimpleBlueprint();
                    await testFixture.BlueprintClient.Blueprints.CreateOrUpdateInSubscriptionAsync(subscriptionId, blueprintName, blueprint);

                    // get
                    var blueprintGet = await testFixture.BlueprintClient.Blueprints.GetInSubscriptionAsync(subscriptionId, blueprintName);
                    Assert.Equal(blueprintName, blueprintGet.Name);
                    Assert.Equal("Microsoft.Blueprint/blueprints", blueprintGet.Type);
                    Assert.Equal(Constants.BlueprintTargetScopes.Subscription, blueprintGet.TargetScope);
                    Assert.Equal(3, blueprintGet.Parameters.Count);

                    // update
                    blueprint.Parameters.Add("defaultKeyVaultStore", new ParameterDefinition { Type = Constants.ParameterDefinitionTypes.String, DisplayName = "resource id for keyVault." });
                    blueprintGet = await testFixture.BlueprintClient.Blueprints.CreateOrUpdateInSubscriptionAsync(subscriptionId, blueprintName, blueprint);
                    Assert.Contains("defaultKeyVaultStore", blueprintGet.Parameters.Keys);

                    // list
                    await testFixture.BlueprintClient.Blueprints.CreateOrUpdateInSubscriptionAsync(subscriptionId, blueprintName2, blueprint);
                    var blueprints = await testFixture.BlueprintClient.Blueprints.ListInSubscriptionAsync(subscriptionId);
                    Assert.Equal(2, blueprints.Count());
                    Assert.Single(blueprints.Where(bp => bp.Name.Equals(blueprintName)));
                    Assert.Single(blueprints.Where(bp => bp.Name.Equals(blueprintName2)));

                    // delete
                    await testFixture.BlueprintClient.Blueprints.DeleteInSubscriptionAsync(subscriptionId, blueprintName);
                    await testFixture.BlueprintClient.Blueprints.DeleteInSubscriptionAsync(subscriptionId, blueprintName2);
                }
            }
        }

        [Fact]
        public async Task ArtifactCRUD()
        {
            string managementGroupName = "AzBlueprint",
                blueprintName = "fromDotnetSDK",
                templateArtifactName = "vNicTemplate",
                policyArtifactName = "costCenterPolicy",
                rbacArtifactName = "ownerRBAC";
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new BlueprintTestBase(context))
                {
                    // create blueprint
                    var blueprint = CreateSimpleBlueprint();
                    await testFixture.BlueprintClient.Blueprints.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, blueprint);

                    #region template artifact
                    // create template artifact
                    var templateArtifact = CreateTemplateArtifact();
                    await testFixture.BlueprintClient.Artifacts.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, templateArtifactName, templateArtifact);
                    // get templateArtifact
                    var templateArtifactGet = await testFixture.BlueprintClient.Artifacts.GetInManagementGroupAsync(managementGroupName, blueprintName, templateArtifactName) as TemplateArtifact;
                    Assert.Equal(templateArtifactName, templateArtifactGet.Name);
                    Assert.Equal("Microsoft.Blueprint/blueprints/artifacts", templateArtifactGet.Type);
                    Assert.Equal("vNicResourceGroup", templateArtifactGet.ResourceGroup);
                    Assert.Equal(2, templateArtifactGet.Parameters.Count);
                    Assert.Single(templateArtifactGet.Parameters.Where(kvp => kvp.Key.Equals("vNetName")));
                    Assert.Single(templateArtifactGet.Parameters.Where(kvp => kvp.Key.Equals("Location")));

                    // update template artifact
                    templateArtifact.Parameters["Location"] = new ParameterValue { Value = "West US" };
                    await testFixture.BlueprintClient.Artifacts.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, templateArtifactName, templateArtifact);
                    #endregion

                    #region policy artifact
                    // create policy artifact
                    var policyArtifact = CreatePolicyArtifact();
                    await testFixture.BlueprintClient.Artifacts.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, policyArtifactName, policyArtifact);
                    // get policy artifact
                    var policyArtifactGet = await testFixture.BlueprintClient.Artifacts.GetInManagementGroupAsync(managementGroupName, blueprintName, policyArtifactName) as PolicyAssignmentArtifact;
                    Assert.Equal(policyArtifactName, policyArtifactGet.Name);
                    Assert.Equal("Microsoft.Blueprint/blueprints/artifacts", policyArtifactGet.Type);
                    Assert.Equal("/providers/Microsoft.Authorization/policyDefinitions/2a0e14a6-b0a6-4fab-991a-187a4f81c498", policyArtifactGet.PolicyDefinitionId);
                    Assert.Equal(2, policyArtifactGet.Parameters.Count);
                    Assert.Single(policyArtifactGet.Parameters.Where(kvp => kvp.Key.Equals("tagName")));
                    Assert.Single(policyArtifactGet.Parameters.Where(kvp => kvp.Key.Equals("tagValue")));
                    // update policy artifact
                    policyArtifact.Parameters["tagValue"] = new ParameterValue { Value = "[parameters('defaultCostCenter')]" };
                    await testFixture.BlueprintClient.Artifacts.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, policyArtifactName, policyArtifact);
                    #endregion

                    #region roleAssignment artifact
                    // create roleAssignment artifact
                    var rbacArtifact = CreateRBACArtifact();
                    await testFixture.BlueprintClient.Artifacts.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, rbacArtifactName, rbacArtifact);
                    // get roleAssignment artifact
                    var rbacArtifactGet = await testFixture.BlueprintClient.Artifacts.GetInManagementGroupAsync(managementGroupName, blueprintName, rbacArtifactName) as RoleAssignmentArtifact;
                    Assert.Equal(rbacArtifactName, rbacArtifactGet.Name);
                    Assert.Equal("Microsoft.Blueprint/blueprints/artifacts", rbacArtifactGet.Type);
                    Assert.Equal("/providers/Microsoft.Authorization/roleDefinitions/b24988ac-6180-42a0-ab88-20f7382dd24c", rbacArtifactGet.RoleDefinitionId);
                    // update roleAssignment artifact
                    rbacArtifact.DisplayName = "Assign Owner to Central IT Admin and ServiceOwner";
                    await testFixture.BlueprintClient.Artifacts.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, rbacArtifactName, rbacArtifact);
                    #endregion

                    // list artifacts
                    var artifactList = await testFixture.BlueprintClient.Artifacts.ListInManagementGroupAsync(managementGroupName, blueprintName);
                    Assert.Single(artifactList.OfType<TemplateArtifact>());
                    Assert.Single(artifactList.OfType<PolicyAssignmentArtifact>());
                    Assert.Single(artifactList.OfType<RoleAssignmentArtifact>());

                    // delete template artifact
                    await testFixture.BlueprintClient.Artifacts.DeleteInManagementGroupAsync(managementGroupName, blueprintName, templateArtifactName);
                    await testFixture.BlueprintClient.Artifacts.DeleteInManagementGroupAsync(managementGroupName, blueprintName, policyArtifactName);
                    await testFixture.BlueprintClient.Artifacts.DeleteInManagementGroupAsync(managementGroupName, blueprintName, rbacArtifactName);

                    await testFixture.BlueprintClient.Blueprints.DeleteInManagementGroupAsync("AzBlueprint", "fromDotnetSDK");
                }
            }
        }

        [Fact]
        public async Task ManagementGroupAssignmentCRUD()
        {
            string managementGroupName = "AzBlueprintWebScout",
                blueprintName = "AssignBlueprintAtMg",
                templateArtifactName = "vNicTemplate",
                policyArtifactName = "costCenterPolicy",
                rbacArtifactName = "ownerRBAC",
                assignmentName = "testAssignmentAtMg",
                subscriptionId = "7e2bacd2-6c4b-444c-9331-2e76799cbfc9";

            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new BlueprintTestBase(context))
                {
                    // cleanup
                    await testFixture.BlueprintClient.Assignments.DeleteInManagementGroupAsync(managementGroupName, assignmentName);
                    await testFixture.BlueprintClient.Blueprints.DeleteInManagementGroupAsync(managementGroupName, blueprintName);
                    // create blueprint
                    var blueprint = CreateSimpleBlueprint();
                    await testFixture.BlueprintClient.Blueprints.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, blueprint);

                    // create template artifact
                    var templateArtifact = CreateTemplateArtifact();
                    await testFixture.BlueprintClient.Artifacts.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, templateArtifactName, templateArtifact);

                    // create policyAssignment artifact
                    var policyArtifact = CreatePolicyArtifact();
                    await testFixture.BlueprintClient.Artifacts.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, policyArtifactName, policyArtifact);

                    // create roleAssignment artifact
                    var rbacArtifact = CreateRBACArtifact();
                    await testFixture.BlueprintClient.Artifacts.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, rbacArtifactName, rbacArtifact);

                    // publish
                    await testFixture.BlueprintClient.PublishedBlueprints.CreateInManagementGroupAsync(managementGroupName, blueprintName, "v1.0");

                    // fix costCenter and publish new version
                    templateArtifact.Parameters["tagValue"] = new ParameterValue { Value = "[parameters('defaultCostCenter')]" };
                    await testFixture.BlueprintClient.PublishedBlueprints.CreateInManagementGroupAsync(managementGroupName, blueprintName, "v1.1");
                    var latestSealed = await testFixture.BlueprintClient.PublishedBlueprints.GetInManagementGroupAsync(managementGroupName, blueprintName, "v1.1");

                    // list versions
                    var sealedBlueprints = await testFixture.BlueprintClient.PublishedBlueprints.ListInManagementGroupAsync(managementGroupName, blueprintName);
                    Assert.Equal(2, sealedBlueprints.Count());

                    // create assignment
                    var assignment = CreateBlueprintAssignment(latestSealed, subscriptionId);
                    await testFixture.BlueprintClient.Assignments.CreateOrUpdateInManagementGroupAsync(managementGroupName, assignmentName, assignment);
                    var assignmentGet = await testFixture.BlueprintClient.Assignments.GetInManagementGroupAsync(managementGroupName, assignmentName);
                    Assert.Equal(assignmentName, assignmentGet.Name);
                    Assert.Equal("Microsoft.Blueprint/blueprintAssignments", assignmentGet.Type);
                    Assert.Equal(string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId), assignmentGet.Scope);
                    Assert.Equal(1, assignment.ResourceGroups.Count);
                    Assert.Single(assignment.ResourceGroups.Keys.Where(k => k.Equals("vNicResourceGroup")));
                    Assert.Equal(3, assignment.Parameters.Count);
                    Assert.Single(assignment.Parameters.Keys.Where(k => k.Equals("vNetName")));
                    Assert.Single(assignment.Parameters.Keys.Where(k => k.Equals("defaultLocation")));
                    Assert.Single(assignment.Parameters.Keys.Where(k => k.Equals("defaultCostCenter")));

                    // list assignment
                    var assignmentsList = await testFixture.BlueprintClient.Assignments.ListInManagementGroupAsync(managementGroupName);
                    Assert.Single(assignmentsList.Where(a => String.Equals(a.Name, assignmentName, StringComparison.InvariantCultureIgnoreCase)));

                    // wait for assignment to finish
                    CancellationTokenSource waitTillFinish = new CancellationTokenSource(TimeSpan.FromMinutes(10));
                    assignmentGet = await WaitForCondition(
                        () => testFixture.BlueprintClient.Assignments.GetInManagementGroupAsync(managementGroupName, assignmentName),
                        (Assignment assign) => assign.IsTerminalState(),
                        waitTillFinish.Token);

                    // validate we have assignmentOperation for detail deployment steps.
                    var assignmentOperationList = await testFixture.BlueprintClient.AssignmentOperations.ListInManagementGroupAsync(managementGroupName, assignmentGet.Name);
                    var assignmentOperation = Assert.Single(assignmentOperationList);
                    var assignmentOperationGet = await testFixture.BlueprintClient.AssignmentOperations.GetInManagementGroupAsync(managementGroupName, assignmentGet.Name, assignmentOperation.Name);
                    Assert.Equal(assignmentGet.ProvisioningState, assignmentOperationGet.AssignmentState);

                    // cleanup
                    await testFixture.BlueprintClient.Assignments.DeleteInManagementGroupAsync(managementGroupName, assignmentName);
                    // assignment delete is async operation
                    CancellationTokenSource waitTillDeleted = new CancellationTokenSource(TimeSpan.FromMinutes(10));
                    await WaitForCondition(
                        () => testFixture.BlueprintClient.Assignments.GetInManagementGroupAsync(managementGroupName, assignmentName),
                        (Assignment assign) => assign.IsTerminalState(),
                        waitTillFinish.Token,
                        (Exception ex) =>
                        {
                            if (ex is CloudException && (ex as CloudException).Response.StatusCode == HttpStatusCode.NotFound)
                            {
                                return true;
                            }
                            throw ex;
                        });

                    await testFixture.BlueprintClient.PublishedBlueprints.DeleteInManagementGroupAsync(managementGroupName, blueprintName, "v1.0");
                    await testFixture.BlueprintClient.PublishedBlueprints.DeleteInManagementGroupAsync(managementGroupName, blueprintName, "v1.1");
                    await testFixture.BlueprintClient.Blueprints.DeleteInManagementGroupAsync(managementGroupName, blueprintName);
                }
            }
        }

        [Fact]
        public async Task SubscriptionAssignmentCRUD()
        {
            string managementGroupName = "AzBlueprint",
                blueprintName = "AssignBlueprint",
                templateArtifactName = "vNicTemplate",
                policyArtifactName = "costCenterPolicy",
                rbacArtifactName = "ownerRBAC",
                assignmentName = "testAssignment",
                subscriptionId = "7e2bacd2-6c4b-444c-9331-2e76799cbfc9";

            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new BlueprintTestBase(context))
                {
                    // cleanup
                    await testFixture.BlueprintClient.Assignments.DeleteInSubscriptionAsync(subscriptionId, assignmentName);
                    await testFixture.BlueprintClient.Blueprints.DeleteInManagementGroupAsync(managementGroupName, blueprintName);
                    // create blueprint
                    var blueprint = CreateSimpleBlueprint();
                    await testFixture.BlueprintClient.Blueprints.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, blueprint);

                    // create template artifact
                    var templateArtifact = CreateTemplateArtifact();
                    await testFixture.BlueprintClient.Artifacts.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, templateArtifactName, templateArtifact);

                    // create policyAssignment artifact
                    var policyArtifact = CreatePolicyArtifact();
                    await testFixture.BlueprintClient.Artifacts.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, policyArtifactName, policyArtifact);

                    // create roleAssignment artifact
                    var rbacArtifact = CreateRBACArtifact();
                    await testFixture.BlueprintClient.Artifacts.CreateOrUpdateInManagementGroupAsync(managementGroupName, blueprintName, rbacArtifactName, rbacArtifact);

                    // publish
                    await testFixture.BlueprintClient.PublishedBlueprints.CreateInManagementGroupAsync(managementGroupName, blueprintName, "v1.0");

                    // fix costCenter and publish new version
                    templateArtifact.Parameters["tagValue"] = new ParameterValue { Value = "[parameters('defaultCostCenter')]" };
                    await testFixture.BlueprintClient.PublishedBlueprints.CreateInManagementGroupAsync(managementGroupName, blueprintName, "v1.1");
                    var latestSealed = await testFixture.BlueprintClient.PublishedBlueprints.GetInManagementGroupAsync(managementGroupName, blueprintName, "v1.1");

                    // list versions
                    var sealedBlueprints = await testFixture.BlueprintClient.PublishedBlueprints.ListInManagementGroupAsync(managementGroupName, blueprintName);
                    Assert.Equal(2, sealedBlueprints.Count());

                    // create assignment
                    var assignment = CreateBlueprintAssignment(latestSealed);
                    await testFixture.BlueprintClient.Assignments.CreateOrUpdateInSubscriptionAsync(subscriptionId, assignmentName, assignment);
                    var assignmentGet = await testFixture.BlueprintClient.Assignments.GetInSubscriptionAsync(subscriptionId, assignmentName);
                    Assert.Equal(assignmentName, assignmentGet.Name);
                    Assert.Equal("Microsoft.Blueprint/blueprintAssignments", assignmentGet.Type);
                    Assert.Equal(1, assignment.ResourceGroups.Count);
                    Assert.Single(assignment.ResourceGroups.Keys.Where(k => k.Equals("vNicResourceGroup")));
                    Assert.Equal(3, assignment.Parameters.Count);
                    Assert.Single(assignment.Parameters.Keys.Where(k => k.Equals("vNetName")));
                    Assert.Single(assignment.Parameters.Keys.Where(k => k.Equals("defaultLocation")));
                    Assert.Single(assignment.Parameters.Keys.Where(k => k.Equals("defaultCostCenter")));

                    // list assignment
                    var assignmentsList = await testFixture.BlueprintClient.Assignments.ListInSubscriptionAsync(subscriptionId);
                    Assert.Single(assignmentsList.Where(a => String.Equals(a.Name, assignmentName, StringComparison.InvariantCultureIgnoreCase)));

                    // wait for assignment to finish
                    CancellationTokenSource waitTillFinish = new CancellationTokenSource(TimeSpan.FromMinutes(5));
                    assignmentGet = await WaitForCondition(
                        () => testFixture.BlueprintClient.Assignments.GetInSubscriptionAsync(subscriptionId, assignmentName),
                        (Assignment assign) => assign.IsTerminalState(),
                        waitTillFinish.Token);

                    // validate we have assignmentOperation for detail deployment steps.
                    var assignmentOperationList = await testFixture.BlueprintClient.AssignmentOperations.ListInSubscriptionAsync(subscriptionId, assignmentGet.Name);
                    var assignmentOperation = Assert.Single(assignmentOperationList);
                    var assignmentOperationGet = await testFixture.BlueprintClient.AssignmentOperations.GetInSubscriptionAsync(subscriptionId, assignmentGet.Name, assignmentOperation.Name);
                    Assert.Equal(assignmentGet.ProvisioningState, assignmentOperationGet.AssignmentState);

                    // cleanup
                    await testFixture.BlueprintClient.Assignments.DeleteInSubscriptionAsync(subscriptionId, assignmentName);
                    // assignment delete is async operation
                    CancellationTokenSource waitTillDeleted = new CancellationTokenSource(TimeSpan.FromMinutes(5));
                    await WaitForCondition(
                        () => testFixture.BlueprintClient.Assignments.GetInSubscriptionAsync(subscriptionId, assignmentName),
                        (Assignment assign) => assign.IsTerminalState(),
                        waitTillFinish.Token,
                        (Exception ex) =>
                        {
                            if (ex is CloudException && (ex as CloudException).Response.StatusCode == HttpStatusCode.NotFound)
                            {
                                return true;
                            }
                            throw ex;
                        });

                    await testFixture.BlueprintClient.PublishedBlueprints.DeleteInManagementGroupAsync(managementGroupName, blueprintName, "v1.0");
                    await testFixture.BlueprintClient.PublishedBlueprints.DeleteInManagementGroupAsync(managementGroupName, blueprintName, "v1.1");
                    await testFixture.BlueprintClient.Blueprints.DeleteInManagementGroupAsync(managementGroupName, blueprintName);
                }
            }
        }

        private async Task<T> WaitForCondition<T>(Func<Task<T>> resolve, Func<T, bool> condition, CancellationToken cancellationToken, Func<Exception, bool> exceptionFilter = null, TimeSpan pullingInterval = default(TimeSpan))
        {
            if (pullingInterval == default(TimeSpan))
            {
                pullingInterval = TimeSpan.FromSeconds(15);
            }

            while (!cancellationToken.IsCancellationRequested)
            {
                T result = default(T);
                try
                {
                    result = await resolve();
                }
                catch (Exception ex)
                {
                    if (exceptionFilter != null)
                    {
                        if (exceptionFilter(ex))
                        {
                            return result;
                        }
                    }
                    throw ex;
                }

                if (condition(result))
                {
                    return result;
                }

                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    await Task.Delay(pullingInterval);
                }
            }

            throw new TimeoutException();
        }

        private Assignment CreateBlueprintAssignment(PublishedBlueprint sealedBlueprint, string subscriptionId = null)
        {
            string scope = !string.IsNullOrEmpty(subscriptionId)
                ? string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId)
                : null;

            return new Assignment
            {
                BlueprintId = sealedBlueprint.Id,
                Identity = new ManagedServiceIdentity { Type = Constants.ManagedServiceIdentityType.SystemAssigned },
                Location = "EastUS",
                Scope = scope,
                ResourceGroups = new OrdinalStringDictionary<ResourceGroupValue>
                {
                    { "vNicResourceGroup", new ResourceGroupValue { Name="default-virtual-networks", Location = "EastUS" } },
                },
                Parameters = new OrdinalStringDictionary<ParameterValue>
                {
                    { "vNetName", new ParameterValue { Value = "DefaultPublicFacingNetwork" } },
                    { "defaultLocation", new ParameterValue { Value = "East US" } },
                    { "defaultCostCenter", new ParameterValue { Value = "Contoso/RnD/Dev/986754" } }
                }
            };
        }

        private BlueprintModel CreateSimpleBlueprint()
        {
            var blueprint = new BlueprintModel
            {
                DisplayName = "Sample Blueprint from Unittest",
                TargetScope = Constants.BlueprintTargetScopes.Subscription,
                ResourceGroups = new OrdinalStringDictionary<ResourceGroupDefinition>
                {
                    { "vNicResourceGroup", new ResourceGroupDefinition{ DisplayName="virtual-network-rg", Description = "All virutal network should save under this resource group." } }
                },
                Parameters = new OrdinalStringDictionary<ParameterDefinition>
                {
                    { "vNetName", new ParameterDefinition { Type = Constants.ParameterDefinitionTypes.String, DisplayName="default vNet for this subscription.", Description = "default vNet created by this blueprint.", DefaultValue = "defaultPublicVNet" } },
                    { "defaultLocation", new ParameterDefinition { Type = Constants.ParameterDefinitionTypes.String, DisplayName="default Location", Description = "default location of resource created by this blueprint.", DefaultValue = "East US" } },
                    { "defaultCostCenter", new ParameterDefinition { Type = Constants.ParameterDefinitionTypes.String, DisplayName="default CostCenter", Description = "default CostCenter for this subscription.", DefaultValue = "Contoso/IT/PROD/123456" } }
                }
            };
            return blueprint;
        }

        private TemplateArtifact CreateTemplateArtifact()
        {
            return new TemplateArtifact
            {
                DisplayName = "vNic template",
                ResourceGroup = "vNicResourceGroup",
                Template = JObject.Parse(File.ReadAllText(Path.Combine("Data", "vNicTemplate.json"))),
                Parameters = new OrdinalStringDictionary<ParameterValue>
                {
                    { "vNetName", new ParameterValue { Value= "[parameters('vNetName')]" } },
                    { "Location", new ParameterValue { Value= "[parameters('defaultLocation')]" } },
                }
            };
        }

        private PolicyAssignmentArtifact CreatePolicyArtifact()
        {
            return new PolicyAssignmentArtifact
            {
                DisplayName = "Apply costCenter tag and default value",
                PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/2a0e14a6-b0a6-4fab-991a-187a4f81c498",
                Parameters = new OrdinalStringDictionary<ParameterValue>
                {
                    { "tagName", new ParameterValue { Value= "costCenter" } },
                    { "tagValue", new ParameterValue { Value= "Contoso/IT/PROD/123456" } },
                }
            };
        }

        private RoleAssignmentArtifact CreateRBACArtifact()
        {
            return new RoleAssignmentArtifact
            {
                DisplayName = "Assign IT Admin SecurityGroup",
                RoleDefinitionId = "/providers/Microsoft.Authorization/roleDefinitions/b24988ac-6180-42a0-ab88-20f7382dd24c",
                PrincipalIds = new string[] {
                    "327c26bf-bf3e-4128-9b75-fbbd99e98739",
                    "f65e608c-c59e-45b8-b308-956f6ff1757f"
                }
            };
        }
    }
}
