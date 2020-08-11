// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using MachineLearning.Tests.Helpers;
using Microsoft.Azure.Management.MachineLearning.CommitmentPlans;
using Microsoft.Azure.Management.MachineLearning.CommitmentPlans.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json.Linq;
using Xunit;

namespace MachineLearning.Tests.ScenarioTests
{
    public class CommitmentPlanTests : BaseScenarioTests
    {
        private const string DefaultLocation = "South Central US";
        private const string TestPlanNamePrefix = "amlcp";
        private const string TestResourceGroupNamePrefix = "amlrg";
        private const string MLResourceProviderNamespace = "Microsoft.MachineLearning";
        private const string TestSkuName = "S1";
        private const string TestSkuTier = "Standard";

        private const string ResourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.MachineLearning/commitmentPlans/{2}";
        
        private delegate void AMLCommitmentPlanTestDelegate(
            string commitmentPlanName,
            string resourceGroupName,
            ResourceManagementClient resourcesClient,
            AzureMLCommitmentPlansManagementClient amlPlansClient);

        [Fact]
        public void CreateGetRemoveCommitmentPlan()
        {
            this.RunAMLCommitmentPlanTestScenario((commitmentPlanName, resourceGroupName, resourcesClient, amlPlansClient) =>
            {
                bool planWasRemoved = false;
                try
                {
                    //Validate expected NO-OP behavior on deleting a nonexistent plan
                    amlPlansClient.CommitmentPlans.RemoveWithHttpMessagesAsync(resourceGroupName, commitmentPlanName);

                    // Create and validate the AML commitment plan resource
                    CommitmentPlan inputCommitmentPlan = new CommitmentPlan(CommitmentPlanTests.DefaultLocation, sku: new ResourceSku(1, CommitmentPlanTests.TestSkuName, CommitmentPlanTests.TestSkuTier));
                    CommitmentPlan outputCommitmentPlan = amlPlansClient.CommitmentPlans.CreateOrUpdateWithHttpMessagesAsync(inputCommitmentPlan, resourceGroupName, commitmentPlanName).Result.Body;
                    CommitmentPlanTests.ValidateCommitmentPlanResource(amlPlansClient.SubscriptionId, resourceGroupName, commitmentPlanName, outputCommitmentPlan);

                    // Retrieve the AML commitment plan after creation
                    var retrievedPlan = amlPlansClient.CommitmentPlans.Get(resourceGroupName, commitmentPlanName);
                    CommitmentPlanTests.ValidateCommitmentPlanResource(amlPlansClient.SubscriptionId, resourceGroupName, commitmentPlanName, retrievedPlan);

                    // Remove the commitment plan
                    amlPlansClient.CommitmentPlans.RemoveWithHttpMessagesAsync(resourceGroupName, commitmentPlanName).Wait();
                    planWasRemoved = true;

                    //Validate that the expected not found exception is thrown after deletion when trying to access the commitment plan
                    var expectedCloudException = Assert.Throws<CloudException>(() => amlPlansClient.CommitmentPlans.Get(resourceGroupName, commitmentPlanName));
                    Assert.NotNull(expectedCloudException.Body);
                    Assert.Equal("ResourceNotFound", expectedCloudException.Body.Code);
                }
                finally
                {
                    // Remove the commitment plan
                    if (!planWasRemoved)
                    {
                        BaseScenarioTests.DisposeOfTestResource(() => amlPlansClient.CommitmentPlans.RemoveWithHttpMessagesAsync(resourceGroupName, commitmentPlanName));
                    }
                }
            });
        }

        [Fact]
        public void CreateAndUpdateCommitmentPlan()
        {
            const string TagKey = "tag1";
            const string TagValue = "value1";

            this.RunAMLCommitmentPlanTestScenario((commitmentPlanName, resourceGroupName, resourcesClient, amlPlansClient) =>
            {
                try
                {
                    // Create and validate the AML commitment plan resource
                    CommitmentPlan inputCommitmentPlan = new CommitmentPlan(CommitmentPlanTests.DefaultLocation, sku: new ResourceSku(1, CommitmentPlanTests.TestSkuName, CommitmentPlanTests.TestSkuTier));
                    CommitmentPlan outputCommitmentPlan = amlPlansClient.CommitmentPlans.CreateOrUpdateWithHttpMessagesAsync(inputCommitmentPlan, resourceGroupName, commitmentPlanName).Result.Body;
                    CommitmentPlanTests.ValidateCommitmentPlanResource(amlPlansClient.SubscriptionId, resourceGroupName, commitmentPlanName, outputCommitmentPlan);

                    // Update the commitment plan
                    outputCommitmentPlan.Tags[TagKey] = TagValue;
                    outputCommitmentPlan = amlPlansClient.CommitmentPlans.CreateOrUpdateWithHttpMessagesAsync(outputCommitmentPlan, resourceGroupName, commitmentPlanName).Result.Body;

                    // Validate the change
                    Assert.Equal(1, outputCommitmentPlan.Tags.Count);
                    Assert.Equal(TagValue, outputCommitmentPlan.Tags[TagKey]);
                }
                finally
                {
                    // Remove the commitment plan
                    BaseScenarioTests.DisposeOfTestResource(() => amlPlansClient.CommitmentPlans.RemoveWithHttpMessagesAsync(resourceGroupName, commitmentPlanName));
                }
            });
        }

        [Fact]
        public void CreateAndListCommitmentPlans()
        {
            this.RunAMLCommitmentPlanTestScenario((commitmentPlanName, resourceGroupName, resourcesClient, amlPlansClient) =>
            {
                string plan1Name = TestUtilities.GenerateName(CommitmentPlanTests.TestPlanNamePrefix);
                string plan2Name = TestUtilities.GenerateName(CommitmentPlanTests.TestPlanNamePrefix);
                string plan3Name = TestUtilities.GenerateName(CommitmentPlanTests.TestPlanNamePrefix);

                string resourceGroup1Name = TestUtilities.GenerateName(CommitmentPlanTests.TestResourceGroupNamePrefix);
                string resourceGroup2Name = TestUtilities.GenerateName(CommitmentPlanTests.TestResourceGroupNamePrefix);

                try
                {
                    ResourceSku sku = new ResourceSku(1, CommitmentPlanTests.TestSkuName, CommitmentPlanTests.TestSkuTier);
                    CommitmentPlan inputCommitmentPlan = new CommitmentPlan(CommitmentPlanTests.DefaultLocation, sku: sku);

                    // Create two commitment plans in the first resource group
                    resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroup1Name, new ResourceGroup { Location = CommitmentPlanTests.DefaultLocation });

                    CommitmentPlan outputCommitmentPlan1 = amlPlansClient.CommitmentPlans.CreateOrUpdateWithHttpMessagesAsync(inputCommitmentPlan, resourceGroup1Name, plan1Name).Result.Body;
                    CommitmentPlanTests.ValidateCommitmentPlanResource(amlPlansClient.SubscriptionId, resourceGroup1Name, plan1Name, outputCommitmentPlan1);

                    CommitmentPlan outputCommitmentPlan2 = amlPlansClient.CommitmentPlans.CreateOrUpdateWithHttpMessagesAsync(inputCommitmentPlan, resourceGroup1Name, plan2Name).Result.Body;
                    CommitmentPlanTests.ValidateCommitmentPlanResource(amlPlansClient.SubscriptionId, resourceGroup1Name, plan2Name, outputCommitmentPlan2);

                    // Create one commitment plan in the second resource group
                    resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroup2Name, new ResourceGroup { Location = CommitmentPlanTests.DefaultLocation });

                    CommitmentPlan outputCommitmentPlan3 = amlPlansClient.CommitmentPlans.CreateOrUpdateWithHttpMessagesAsync(inputCommitmentPlan, resourceGroup2Name, plan3Name).Result.Body;
                    CommitmentPlanTests.ValidateCommitmentPlanResource(amlPlansClient.SubscriptionId, resourceGroup2Name, plan3Name, outputCommitmentPlan3);

                    // Get plans from first resource group and validate
                    var plansInGroup1 = amlPlansClient.CommitmentPlans.ListInResourceGroup(resourceGroup1Name);

                    Assert.NotNull(plansInGroup1);
                    Assert.Equal(2, plansInGroup1.Count());

                    string expectedResourceId1 = string.Format(CultureInfo.InvariantCulture, CommitmentPlanTests.ResourceIdFormat, amlPlansClient.SubscriptionId, resourceGroup1Name, plan1Name);
                    Assert.Contains(plansInGroup1, plan => string.Equals(plan.Id, expectedResourceId1, StringComparison.OrdinalIgnoreCase));

                    string expectedResourceId2 = string.Format(CultureInfo.InvariantCulture, CommitmentPlanTests.ResourceIdFormat, amlPlansClient.SubscriptionId, resourceGroup1Name, plan2Name);
                    Assert.Contains(plansInGroup1, plan => string.Equals(plan.Id, expectedResourceId2, StringComparison.OrdinalIgnoreCase));

                    // Get plans from second resource group and validate
                    var plansInGroup2 = amlPlansClient.CommitmentPlans.ListInResourceGroup(resourceGroup2Name);

                    Assert.NotNull(plansInGroup2);
                    Assert.Single(plansInGroup2);

                    string expectedResourceId3 = string.Format(CultureInfo.InvariantCulture, CommitmentPlanTests.ResourceIdFormat, amlPlansClient.SubscriptionId, resourceGroup2Name, plan3Name);
                    Assert.Contains(plansInGroup2, plan => string.Equals(plan.Id, expectedResourceId3, StringComparison.OrdinalIgnoreCase));
                }
                finally
                {
                    // Delete plans and resource groups
                    BaseScenarioTests.DisposeOfTestResource(() => amlPlansClient.CommitmentPlans.RemoveWithHttpMessagesAsync(resourceGroup1Name, plan1Name));
                    BaseScenarioTests.DisposeOfTestResource(() => amlPlansClient.CommitmentPlans.RemoveWithHttpMessagesAsync(resourceGroup1Name, plan2Name));
                    BaseScenarioTests.DisposeOfTestResource(() => resourcesClient.ResourceGroups.Delete(resourceGroup1Name));

                    BaseScenarioTests.DisposeOfTestResource(() => amlPlansClient.CommitmentPlans.RemoveWithHttpMessagesAsync(resourceGroup2Name, plan3Name));                                      
                    BaseScenarioTests.DisposeOfTestResource(() => resourcesClient.ResourceGroups.Delete(resourceGroup2Name));
                }
            });
        }

        private void RunAMLCommitmentPlanTestScenario(AMLCommitmentPlanTestDelegate actualTest,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName = "testframework_failed")
        {
            using (var context = MockContext.Start(this.GetType(), methodName))
            {
                bool testIsSuccessfull = true;
                string cpRpApiVersion = string.Empty;
                ResourceManagementClient resourcesClient = null;

                var commitmentPlanName = TestUtilities.GenerateName(CommitmentPlanTests.TestPlanNamePrefix);
                var resourceGroupName = TestUtilities.GenerateName(CommitmentPlanTests.TestResourceGroupNamePrefix);

                try
                {
                    // Create a resource group for the AML commitment plan
                    resourcesClient = context.GetServiceClient<ResourceManagementClient>();
                    var resourceGroupDefinition = new ResourceGroup
                    {
                        Location = CommitmentPlanTests.DefaultLocation
                    };
                    resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName, resourceGroupDefinition);

                    // Create a client for the AML RP and run the actual test
                    var commitmentPlansClient = context.GetServiceClient<AzureMLCommitmentPlansManagementClient>();

                    // Run the actual test
                    actualTest(commitmentPlanName, resourceGroupName, resourcesClient, commitmentPlansClient);
                }
                catch (CloudException cloudEx)
                {
                    Trace.TraceError("Caught unexpected exception: ");
                    Trace.TraceError(BaseScenarioTests.GenerateCloudExceptionReport(cloudEx));
                    testIsSuccessfull = false;
                }
                finally
                {
                    if (resourcesClient != null)
                    {
                        // Delete the created resource group
                        BaseScenarioTests.DisposeOfTestResource(() => resourcesClient.ResourceGroups.Delete(resourceGroupName));
                    }
                }
                Assert.True(testIsSuccessfull);
            }
        }

        private static void ValidateCommitmentPlanResource(string subscriptionId, string resourceGroupName, string commitmentPlanName, CommitmentPlan commitmentPlan)
        {
            // Validate basic ARM resource fields
            Assert.NotNull(commitmentPlan);

            string expectedResourceId = string.Format(CultureInfo.InvariantCulture, CommitmentPlanTests.ResourceIdFormat, subscriptionId, resourceGroupName, commitmentPlanName);
            Assert.Equal(expectedResourceId, commitmentPlan.Id);

            Assert.Equal(CommitmentPlanTests.DefaultLocation, commitmentPlan.Location);

            Assert.Equal("Microsoft.MachineLearning/commitmentPlans", commitmentPlan.Type);

            Assert.NotNull(commitmentPlan.Sku);
            Assert.Equal(CommitmentPlanTests.TestSkuName, commitmentPlan.Sku.Name);
            Assert.Equal(CommitmentPlanTests.TestSkuTier, commitmentPlan.Sku.Tier);

            // Validate specific AML commitment plan properties
            Assert.NotNull(commitmentPlan.Properties);

            Assert.NotEmpty(commitmentPlan.Properties.IncludedQuantities);

            Assert.NotNull(commitmentPlan.Properties.MaxAssociationLimit);
            Assert.True(commitmentPlan.Properties.MaxAssociationLimit.Value.CompareTo(1) > 0);

            Assert.NotNull(commitmentPlan.Properties.MaxCapacityLimit);
            Assert.True(commitmentPlan.Properties.MaxCapacityLimit.Value.CompareTo(1) > 0);

            Assert.NotNull(commitmentPlan.Properties.MinCapacityLimit);
            Assert.True(commitmentPlan.Properties.MinCapacityLimit.Value.CompareTo(1) == 0);
        }
    }
}

