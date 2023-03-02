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
using NUnit.Framework;

namespace Azure.ResourceManager.PolicyInsights.Tests
{
    internal class PolicyRemediationTests : PolicyInsightsManagementTestBase
    {
        private PolicyRemediationCollection _policyRemediationCollection;
        private const string _remediationPrefixName = "remediation";

        public PolicyRemediationTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void Setup()
        {
            _policyRemediationCollection = Client.GetPolicyRemediations(DefaultSubscription.Id);
        }

        [RecordedTest]
        public async Task Remediations_SubscriptionCrud()
        {
            // CreateOrUpdate
            var policyRemediationName = Recording.GenerateAssetName(_remediationPrefixName);
            var data = new PolicyRemediationData()
            {
                PolicyAssignmentId = DefaultPolicyAssignmentId,
                Filter = new RemediationFilters() { Locations = { AzureLocation.EastUS } },
                ParallelDeployments = 1,
                ResourceCount = 1,
                FailureThreshold = new RemediationPropertiesFailureThreshold() { Percentage = (float?)0.42 }
            };
            var policyRemediation = await _policyRemediationCollection.CreateOrUpdateAsync(WaitUntil.Completed, policyRemediationName, data);
            ValidatepolicyRemediation(policyRemediation.Value.Data, policyRemediationName);

            // Exist
            var flag = await _policyRemediationCollection.ExistsAsync(policyRemediationName);
            Assert.IsTrue(flag);

            // Get
            var getPolicyRemediation = await _policyRemediationCollection.GetAsync(policyRemediationName);
            ValidatepolicyRemediation(getPolicyRemediation.Value.Data, policyRemediationName);

            // List
            var list = await _policyRemediationCollection.GetAllAsync().ToEnumerableAsync();

            // Delete
            await policyRemediation.Value.DeleteAsync(WaitUntil.Completed);
            flag = await _policyRemediationCollection.ExistsAsync(policyRemediationName);
            Assert.IsFalse(flag);
        }

        private void ValidatepolicyRemediation(PolicyRemediationData policyRemediation, string policyRemediationName)
        {
            Assert.IsNotNull(policyRemediation);
        }
    }
}
