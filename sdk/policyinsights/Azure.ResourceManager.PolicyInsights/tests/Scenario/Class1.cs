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

namespace Azure.ResourceManager.PolicyInsights.Tests
{
    internal class Class1 : PolicyInsightsManagementTestBase
    {
        public Class1(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task CreateOrUpdateExistGetGetAllDelete()
        {
            var sub = await Client.GetDefaultSubscriptionAsync();
            var subid = sub.Data.Id;
            string assignmentid = subid + "/providers/microsoft.authorization/policyassignments/3bbee6571e0340dba6df72bf";
            var collection = Client.GetPolicyAttestations(subid);

            var defination =  Client.GetSubscriptionPolicyDefinitionResource(new ResourceIdentifier("/providers/Microsoft.Authorization/policyDefinitions/0004bbf0-5099-4179-869e-e9ffe5fb0945"));
            // create
            //var rg = await CreateResourceGroup();
            string attestationName = Recording.GenerateAssetName("attestation");
            attestationName = "attestationSdkTestSub";
            PolicyAttestationData data = new PolicyAttestationData(new ResourceIdentifier(assignmentid))
            {
                Comments = ".NET SDK Test",
                ComplianceState = "Compliant",
                ExpireOn = new DateTime(2030, 12, 10),
                Owner = "Test Owner",
                PolicyAssignmentId = new ResourceIdentifier(assignmentid),
                Evidence =
                {
                    new AttestationEvidence(){ Description = "Evidence 1", SourceUri = new Uri("http://www.contoso.com/evidence1") },
                    new AttestationEvidence(){ Description = "Evidence 2", SourceUri = new Uri("http://www.contoso.com/evidence2") },
                },
                AssessOn = new DateTime(2022, 12, 5),
                //Metadata = BinaryData.FromString("{\"DEPT_ID\", \"NYC4-MARKETING\"}")
            };
            var attestation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, attestationName, data);
            var list = await collection.GetAllAsync().ToEnumerableAsync();
        }

        [RecordedTest]
        public async Task RemediationE2E()
        {
            var sub = await Client.GetDefaultSubscriptionAsync();
            var subid = sub.Data.Id;
            string assignmentid = subid + "/providers/microsoft.authorization/policyassignments/3bbee6571e0340dba6df72bf";
            var collection = Client.GetPolicyRemediations(subid);

            var list = await collection.GetAllAsync().ToEnumerableAsync();

            var remediationName = "b49b6437-706d-4208-8508-65d87a9b2e37";
            remediationName = "remediation0000";
            var data = new PolicyRemediationData()
            {
                PolicyAssignmentId = new ResourceIdentifier(assignmentid),
                Filter = new RemediationFilters() { Locations = { AzureLocation.EastUS } },
                ParallelDeployments = 1,
                ResourceCount = 1,
                FailureThreshold = new RemediationPropertiesFailureThreshold() { Percentage = (float?)0.42 }
            };
            var remediation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, remediationName, data);

            list = await collection.GetAllAsync().ToEnumerableAsync();
        }

        [RecordedTest]
        public async Task RemediationE2EByResourceGroup()
        {
            var sub = await Client.GetDefaultSubscriptionAsync();
            var subid = sub.Data.Id;
            string rgid = subid + "/resourcegroups/policyrg0000";
            string assignmentid = rgid + "/providers/microsoft.authorization/policyassignments/944926686acd4d49b7550766";
            var collection = Client.GetPolicyRemediations(new ResourceIdentifier(rgid));

            var list = await collection.GetAllAsync().ToEnumerableAsync();

            var remediationName = "b49b6437-706d-4208-8508-65d87a9b2e37";
            remediationName = "remediation0000";
            var data = new PolicyRemediationData()
            {
                PolicyAssignmentId = new ResourceIdentifier(assignmentid),
                Filter = new RemediationFilters() { Locations = { AzureLocation.EastUS } },
                ParallelDeployments = 1,
                ResourceCount = 1,
                FailureThreshold = new RemediationPropertiesFailureThreshold() { Percentage = (float?)0.42 }
            };
            var remediation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, remediationName, data);

            list = await collection.GetAllAsync().ToEnumerableAsync();
        }
    }
}
