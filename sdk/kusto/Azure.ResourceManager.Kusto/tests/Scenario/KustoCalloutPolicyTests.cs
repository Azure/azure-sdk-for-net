// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Kusto.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoCalloutPolicyTests : KustoManagementTestBase
    {
        public KustoCalloutPolicyTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUp();
        }

        [TestCase]
        [RecordedTest]
        public async Task CalloutPolicyAddRemoveTests()
        {
            await TestInitialCalloutPolicies();

            var calloutPolicy = new KustoCalloutPolicy { CalloutUriRegex = "*", CalloutType = KustoCalloutPolicyCalloutType.Kusto, OutboundAccess = KustoCalloutPolicyOutboundAccess.Allow};

            await TestAddCalloutPolicy(calloutPolicy);

            await TestRemoveCalloutPolicy(calloutPolicy);
        }

        private async Task TestInitialCalloutPolicies()
        {
            var calloutPoliciesBase = Cluster.Data.CalloutPolicies;
            var calloutPolicies = await Cluster.GetCalloutPoliciesAsync().ToEnumerableAsync();
            AssertCalloutPolicyListsEqual(calloutPoliciesBase, calloutPolicies);
        }

        private async Task TestAddCalloutPolicy(KustoCalloutPolicy calloutPolicy)
        {
            var calloutPoliciesList = new CalloutPoliciesList { Value = { calloutPolicy } };

            await Cluster.AddCalloutPoliciesAsync(WaitUntil.Completed, calloutPoliciesList);
            await AssertCalloutPolicyInList(calloutPolicy, true);
        }

        private async Task TestRemoveCalloutPolicy(KustoCalloutPolicy calloutPolicy)
        {
            var calloutPolicyFromCluster = await GetCalloutPolicyFromClusterAsync(calloutPolicy);
            var calloutPolicyToRemove = new CalloutPolicyToRemove { CalloutId = calloutPolicyFromCluster.CalloutId };

            await Cluster.RemoveCalloutPolicyAsync(WaitUntil.Completed, calloutPolicyToRemove);
            await AssertCalloutPolicyInList(calloutPolicy, false);
        }

        private async Task<KustoCalloutPolicy> GetCalloutPolicyFromClusterAsync(KustoCalloutPolicy policy)
        {
            var calloutPoliciesList = await Cluster.GetCalloutPoliciesAsync().ToListAsync();

            var matchingPolicy = calloutPoliciesList.FirstOrDefault(p =>
                p.CalloutUriRegex == policy.CalloutUriRegex &&
                p.CalloutType == policy.CalloutType &&
                p.OutboundAccess == policy.OutboundAccess &&
                !string.IsNullOrEmpty(p.CalloutId));

            if (matchingPolicy != null)
            {
                return matchingPolicy;
            }

            throw new Exception("CalloutPolicy not found in the cluster.");
        }

        private async Task AssertCalloutPolicyInList(KustoCalloutPolicy policy, bool shouldBeInList)
        {
            var updatedCalloutPoliciesList = await Cluster.GetCalloutPoliciesAsync().ToListAsync();

            var policyExists = updatedCalloutPoliciesList.Any(p =>
                p.CalloutUriRegex == policy.CalloutUriRegex &&
                p.CalloutType == policy.CalloutType &&
                p.OutboundAccess == policy.OutboundAccess &&
                !string.IsNullOrEmpty(p.CalloutId));

            if (shouldBeInList)
            {
                Assert.IsTrue(policyExists, "Policy not found in the list when it should be.");
            }
            else
            {
                Assert.IsFalse(policyExists, "Policy found in the list when it should not be.");
            }
        }

        private void AssertCalloutPolicyListsEqual(IList<KustoCalloutPolicy> expected, IList<KustoCalloutPolicy> actual)
        {
            if (expected is null)
            {
                Assert.IsNull(actual);
            }
            else
            {
                Assert.IsNotNull(actual);
                Assert.AreEqual(expected.Count, actual.Count, "Lists do not have the same number of elements.");

                foreach (var expectedPolicy in expected)
                {
                    var matchingPolicy = actual.FirstOrDefault(
                        actualPolicy =>
                            expectedPolicy.CalloutUriRegex == actualPolicy.CalloutUriRegex &&
                            expectedPolicy.CalloutType == actualPolicy.CalloutType &&
                            expectedPolicy.OutboundAccess == actualPolicy.OutboundAccess
                    );

                    Assert.IsNotNull(matchingPolicy, "Matching policy not found.");
                }
            }
        }
    }
}
