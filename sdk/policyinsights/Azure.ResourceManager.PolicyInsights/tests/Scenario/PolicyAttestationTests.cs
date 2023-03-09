// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.PolicyInsights.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.PolicyInsights.Tests
{
    internal class PolicyAttestationTests : PolicyInsightsManagementTestBase
    {
        private PolicyAssignmentResource _policyAssignment;
        private SubscriptionPolicyDefinitionResource _policyDefinition;
        public PolicyAttestationTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TearDown]
        public async Task TearDown()
        {
            await _policyAssignment?.DeleteAsync(WaitUntil.Completed);
            await _policyDefinition?.DeleteAsync(WaitUntil.Completed);
        }

        private async Task<PolicyAttestationResource> CreateAttestaion(PolicyAttestationCollection policyAttestationCollection, string attestationName)
        {
            PolicyAttestationData data = new PolicyAttestationData(new ResourceIdentifier(_policyAssignment.Id))
            {
                Comments = ".NET SDK Test",
                ComplianceState = "Compliant",
                Owner = "Test Owner",
                PolicyAssignmentId = new ResourceIdentifier(_policyAssignment.Id),
                Evidence =
                {
                    new AttestationEvidence(){ Description = "Evidence 1", SourceUri = new Uri("http://www.contoso.com/evidence1") },
                    new AttestationEvidence(){ Description = "Evidence 2", SourceUri = new Uri("http://www.contoso.com/evidence2") },
                },
                Metadata = BinaryData.FromString("{\"DEPT_ID\": \"NYC4-MARKETING\"}")
            };
            var attestationLro = await policyAttestationCollection.CreateOrUpdateAsync(WaitUntil.Completed, attestationName, data);
            return attestationLro.Value;
        }

        [RecordedTest]
        public async Task Attestation_SubscriptionCrud()
        {
            // Create a custom definition
            string policyDefinitionName = Recording.GenerateAssetName("PolicyInsightsDefinitionTest");
            _policyDefinition = await CreatePolicyDefinition(policyDefinitionName, "Microsoft.Resources/subscriptions");

            // Assign a policy for test
            string policyAssignmentName = Recording.GenerateAssetName("PolicyInsightsAssignmentTest");
            _policyAssignment = await CreatePolicyAssignment(DefaultSubscription, policyAssignmentName, _policyDefinition.Id);

            // Trigger an evaluation on the resource group to ensure the policy states results are updated
            await DefaultSubscription.TriggerPolicyStateEvaluationAsync(WaitUntil.Completed);

            // CreateOrUpdate
            var policyAttestationCollection = Client.GetPolicyAttestations(DefaultSubscription.Id);
            string attestationName = Recording.GenerateAssetName("attestationtest");
            var attestation = await CreateAttestaion(policyAttestationCollection, attestationName);
            ValidateAttestation(attestation.Data, attestationName);

            // Exist
            var flag = await policyAttestationCollection.ExistsAsync(attestationName);
            Assert.IsTrue(flag);

            // Get
            var getattestation = await policyAttestationCollection.GetAsync(attestationName);
            ValidateAttestation(getattestation.Value.Data, attestationName);

            // GetAll
            var list = await policyAttestationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAttestation(list.FirstOrDefault(item => attestationName == item.Data.Name).Data, attestationName);

            // Delete
            await attestation.DeleteAsync(WaitUntil.Completed);
            flag = await policyAttestationCollection.ExistsAsync(attestationName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task Attestation_ResourceGroupCrud()
        {
            // Create a custom definition
            string policyDefinitionName = Recording.GenerateAssetName("PolicyInsightsDefinitionTest");
            _policyDefinition = await CreatePolicyDefinition(policyDefinitionName, "Microsoft.Resources/subscriptions/resourceGroups");

            // Assign a policy for test
            var resourceGroup = await CreateResourceGroup();
            string policyAssignmentName = Recording.GenerateAssetName("PolicyInsightsAssignmentTest");
            _policyAssignment = await CreatePolicyAssignment(resourceGroup, policyAssignmentName, _policyDefinition.Id);

            // Trigger an evaluation on the resource group to ensure the policy states results are updated
            await resourceGroup.TriggerPolicyStateEvaluationAsync(WaitUntil.Completed);

            // CreateOrUpdate
            var policyAttestationCollection = Client.GetPolicyAttestations(resourceGroup.Id);
            string attestationName = Recording.GenerateAssetName("attestationtest");
            var attestation = await CreateAttestaion(policyAttestationCollection, attestationName);
            ValidateAttestation(attestation.Data, attestationName);

            // Exist
            var flag = await policyAttestationCollection.ExistsAsync(attestationName);
            Assert.IsTrue(flag);

            // Get
            var getattestation = await policyAttestationCollection.GetAsync(attestationName);
            ValidateAttestation(getattestation.Value.Data, attestationName);

            // GetAll
            var list = await policyAttestationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAttestation(list.FirstOrDefault().Data, attestationName);

            // Delete
            await attestation.DeleteAsync(WaitUntil.Completed);
            flag = await policyAttestationCollection.ExistsAsync(attestationName);
            Assert.IsFalse(flag);
        }

        private void ValidateAttestation(PolicyAttestationData attestation, string attestationName)
        {
            Assert.IsNotNull(attestation);
            Assert.AreEqual(attestationName, attestation.Name);
            Assert.AreEqual(".NET SDK Test", attestation.Comments);
            Assert.AreEqual("Compliant", attestation.ComplianceState.ToString());
            Assert.AreEqual("Test Owner", attestation.Owner);
            Assert.AreEqual(2, attestation.Evidence.Count);
        }
    }
}
