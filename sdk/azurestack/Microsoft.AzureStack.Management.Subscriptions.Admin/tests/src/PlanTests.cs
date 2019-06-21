// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Subscriptions.Admin;
using Microsoft.AzureStack.Management.Subscriptions.Admin.Models;
using Subscriptions.Tests.src.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Subscriptions.Tests
{
    public class PlanTests : SubscriptionsTestBase
    {

        private void ValidatePlan(Plan plan) {
            // Resource
            Assert.NotNull(plan);
            Assert.NotNull(plan.Id);
            Assert.NotNull(plan.Location);
            Assert.NotNull(plan.Name);
            Assert.NotNull(plan.Type);

            // Plan
            Assert.NotNull(plan.DisplayName);
            Assert.NotNull(plan.PlanName);
            Assert.NotEmpty(plan.QuotaIds);
        }

        private void AssertSame(Plan expected, Plan given) {
            // Resource
            Assert.Equal(expected.Id, given.Id);
            Assert.Equal(expected.Location, given.Location);
            Assert.Equal(expected.Name, given.Name);
            Assert.Equal(expected.Type, given.Type);

            // Plan

        }

        [Fact]
        public void TestListPlans() {
            RunTest((client) => {
                var allPlans = client.Plans.ListAll();

                var resourceGroups = new System.Collections.Generic.HashSet<string>();
                allPlans.ForEach(client.Plans.ListAllNext, (plan) => {
                    resourceGroups.Add(Common.GetResourceGroupFromId(plan.Id));
                });

                resourceGroups.ForEach((rg) => {
                    client.Plans.List(rg);
                });
            });
        }

        [Fact]
        public void TestCreateUpdateThenDeletePlan()
        {
            RunTest((client) => {
                var name = "testplans";
                var description = "description of the plan";

                var quota = client.Quotas.List(TestContext.LocationName).First();

                var result = client.Plans.CreateOrUpdate(
                    TestContext.ResourceGroupName,
                    name,
                    new Plan(
                        planName: name,
                        displayName: name,
                        location: TestContext.LocationName,
                        description: description,
                        quotaIds: new List<string> { quota.Id }
                    ));

                ValidatePlan(result);
                var plan = client.Plans.Get(TestContext.ResourceGroupName, name);
                ValidatePlan(plan);

                client.Plans.Delete(TestContext.ResourceGroupName, name);

                Assert.Throws<Microsoft.Rest.Azure.CloudException>(() => client.Plans.Get(TestContext.ResourceGroupName, name));
            });
        }

    }
}
