// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.PolicyInsights.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.PolicyInsights.Tests
{
    internal class PolicyRemediationTests : PolicyInsightsManagementTestBase
    {
        private const string _remediationPrefixName = "remediation";
        private PolicyAssignmentResource _policyAssignment;

        public PolicyRemediationTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TearDown]
        public async Task TearDown()
        {
            await _policyAssignment.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task Remediations_SubscriptionCrud()
        {
            // Assign a policy for test
            string policyAssignmentName = Recording.GenerateAssetName("policy");
            _policyAssignment = await CreatePolicyAssignment(DefaultSubscription, policyAssignmentName);

            // CreateOrUpdate
            var policyRemediationCollection = Client.GetPolicyRemediations(DefaultSubscription.Id);
            var policyRemediationName = Recording.GenerateAssetName(_remediationPrefixName);
            var data = new PolicyRemediationData()
            {
                PolicyAssignmentId = _policyAssignment.Data.Id,
                Filter = new RemediationFilters() { Locations = { AzureLocation.EastUS } },
                ParallelDeployments = 1,
                ResourceCount = 1,
                FailureThreshold = new RemediationPropertiesFailureThreshold() { Percentage = (float?)0.42 }
            };
            var policyRemediation = await policyRemediationCollection.CreateOrUpdateAsync(WaitUntil.Completed, policyRemediationName, data);
            ValidatepolicyRemediation(policyRemediation.Value.Data, policyRemediationName);

            // Exist
            var flag = await policyRemediationCollection.ExistsAsync(policyRemediationName);
            Assert.IsTrue(flag);

            // Get
            var getPolicyRemediation = await policyRemediationCollection.GetAsync(policyRemediationName);
            ValidatepolicyRemediation(getPolicyRemediation.Value.Data, policyRemediationName);

            // List
            var list = await policyRemediationCollection.GetAllAsync().ToEnumerableAsync();

            // Delete
            await policyRemediation.Value.DeleteAsync(WaitUntil.Completed);
            flag = await policyRemediationCollection.ExistsAsync(policyRemediationName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task Remediations_ResourceGroupCrud()
        {
            // Create a resource group
            var resourceGroup = await CreateResourceGroup();

            // Assign a policy for test
            string policyAssignmentName = Recording.GenerateAssetName("policy");
            _policyAssignment = await CreatePolicyAssignment(resourceGroup, policyAssignmentName);

            // CreateOrUpdate
            var policyRemediationCollection = Client.GetPolicyRemediations(resourceGroup.Id);
            var policyRemediationName = Recording.GenerateAssetName(_remediationPrefixName);
            var data = new PolicyRemediationData()
            {
                PolicyAssignmentId = _policyAssignment.Data.Id,
                Filter = new RemediationFilters() { Locations = { AzureLocation.EastUS } },
                ParallelDeployments = 1,
                ResourceCount = 1,
                FailureThreshold = new RemediationPropertiesFailureThreshold() { Percentage = (float?)0.42 }
            };
            var policyRemediation = await policyRemediationCollection.CreateOrUpdateAsync(WaitUntil.Completed, policyRemediationName, data);
            ValidatepolicyRemediation(policyRemediation.Value.Data, policyRemediationName);

            // Exist
            var flag = await policyRemediationCollection.ExistsAsync(policyRemediationName);
            Assert.IsTrue(flag);

            // Get
            var getPolicyRemediation = await policyRemediationCollection.GetAsync(policyRemediationName);
            ValidatepolicyRemediation(getPolicyRemediation.Value.Data, policyRemediationName);

            // List
            var list = await policyRemediationCollection.GetAllAsync().ToEnumerableAsync();

            // Delete
            await policyRemediation.Value.DeleteAsync(WaitUntil.Completed);
            flag = await policyRemediationCollection.ExistsAsync(policyRemediationName);
            Assert.IsFalse(flag);
        }

        private void ValidatepolicyRemediation(PolicyRemediationData policyRemediation, string policyRemediationName)
        {
            Assert.IsNotNull(policyRemediation);
            Assert.IsNotNull(policyRemediation.Id);
            Assert.AreEqual(policyRemediationName, policyRemediation.Name);
            Assert.AreEqual(1, policyRemediation.ParallelDeployments);
            Assert.AreEqual(1, policyRemediation.ResourceCount);
            Assert.AreEqual((float)0.42, policyRemediation.FailureThreshold.Percentage);
        }
    }
}
