// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using System.Linq;

using Microsoft.AzureStack.Management.Subscriptions.Admin;
using Microsoft.AzureStack.Management.Subscriptions.Admin.Models;
using System;
using Xunit;
using Subscriptions.Tests.src.Helpers;

namespace Subscriptions.Tests
{
    public class AcquiredPlanTests : SubscriptionsTestBase
    {

        private void ValidatePlanAcquisition(PlanAcquisition planAcquisition) {
            // Resource
            Assert.NotNull(planAcquisition);
            Assert.NotNull(planAcquisition.Id);

            // PlanAcquisition
            Assert.NotNull(planAcquisition.AcquisitionId);
            Assert.NotNull(planAcquisition.AcquisitionTime);
            Assert.NotNull(planAcquisition.ExternalReferenceId);
            Assert.NotNull(planAcquisition.PlanId);
            Assert.NotNull(planAcquisition.ProvisioningState);
        }

        private void AssertSame(PlanAcquisition expected, PlanAcquisition given) {
            // Resource
            Assert.Equal(expected.Id, given.Id);
            //Assert.Equal(expected.Location, given.Location);
            //Assert.Equal(expected.Name, given.Name);
            //Assert.Equal(expected.Type, given.Type);

            // PlanAcquisition
            Assert.Equal(expected.AcquisitionId, given.AcquisitionId);
            Assert.Equal(expected.AcquisitionTime, given.AcquisitionTime);
            Assert.Equal(expected.ExternalReferenceId, given.ExternalReferenceId);
            Assert.Equal(expected.PlanId, given.PlanId);
            Assert.Equal(expected.ProvisioningState, given.ProvisioningState);
        }

        [Fact]
        public void TestListAcquiredPlans() {
            RunTest((client) => {
                var subscriptions = client.Subscriptions.List();
                subscriptions.ForEach((subscription) => {
                    var acquiredPlans = client.AcquiredPlans.List(subscription.DelegatedProviderSubscriptionId);
                });
            });
        }

        [Fact]
        public void TestGetAcquiredPlan() {
            RunTest((client) => {
                var subscription = client.Subscriptions.Get(TestContext.TenantSubscriptionId);
                var acquiredPlan = client.AcquiredPlans.List(subscription.SubscriptionId).First();
                var result = client.AcquiredPlans.Get(subscription.SubscriptionId, acquiredPlan.AcquisitionId);
                AssertSame(acquiredPlan, result);
            });
        }

        [Fact]
        public void TestCreateThenDeleteAcquiredPlan() {
            RunTest((client) => {
                var subscription = client.Subscriptions.List().FirstOrDefault();
                var plan = client.Plans.ListAll().First();

                var newPlan = new PlanAcquisition()
                {
                    AcquisitionId = "df462f5d-5345-4ff6-9af9-2ff71984025f",
                    PlanId = plan.Id
                };

                var result = client.AcquiredPlans.Create(subscription.DelegatedProviderSubscriptionId, newPlan.AcquisitionId, newPlan);
                client.AcquiredPlans.Delete(subscription.DelegatedProviderSubscriptionId, newPlan.AcquisitionId);

                Assert.Throws<Microsoft.Rest.Azure.CloudException>(() => client.AcquiredPlans.Get(subscription.DelegatedProviderSubscriptionId, newPlan.AcquisitionId));

                
            });
        }
    }
}
