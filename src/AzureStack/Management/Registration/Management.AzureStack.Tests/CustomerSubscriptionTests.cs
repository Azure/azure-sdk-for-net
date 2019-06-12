// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Microsoft.Azure.Management.AzureStack.Tests
{
    using Microsoft.Azure.Management.AzureStack;
    using Microsoft.Azure.Management.AzureStack.Models;
    using Xunit;

    public class CustomerSubscriptionTests : AzureStackTestBase
    {
        private const string TestResourceGroupName = "AzsGroup";
        private const string TestRegistrationName = "TestRegistration";
        private const string TestUserSubscriptionName = "TestSubscription";
        private const string TestSubscriptionID = "16A043D5-8B84-4240-8ACF-54966D03DAE0";
        private const string TestTenantID = "BF792B6C-F171-4BFC-9EED-FFD19ACBC951";

        private void ValidateCustomerSubscription(CustomerSubscription subscription)
        {
            Assert.NotNull(subscription);
            Assert.NotEmpty(subscription.Id);
            Assert.NotEmpty(subscription.TenantId);
        }

        private void AssertSame(CustomerSubscription expected, CustomerSubscription given)
        {
            Assert.Equal(expected.Id, given.Id);
            Assert.Equal(expected.TenantId, given.TenantId);
        }

        [Fact]
        public void TestListCustomerSubscriptions()
        {
            RunTest((client) =>
            {
                var subscriptions = client.CustomerSubscriptions.List(TestResourceGroupName, TestRegistrationName);

                foreach (var subscription in subscriptions)
                {
                    ValidateCustomerSubscription(subscription);
                }
            });
        }

        [Fact]
        public void TestGetCustomerSubscription()
        {
            RunTest((client) =>
            {
                var subscriptions = client.CustomerSubscriptions.List(TestResourceGroupName, TestRegistrationName);

                foreach (var subscription in subscriptions)
                {
                    var subscriptionResult = client.CustomerSubscriptions.Get(TestResourceGroupName, TestRegistrationName, subscription.Name);
                    AssertSame(subscription, subscriptionResult);
                }
            });
        }

        [Fact]
        public void TestCreateAndDeleteCustomerSubscription()
        {
            RunTest((client) =>
            {
                CustomerSubscription parameter = new CustomerSubscription(
                    id: $"subscriptions/{TestSubscriptionID}/resourceGroups/{TestResourceGroupName}/providers/Microsoft.AzureStack/registrations/{TestRegistrationName}/customersubscriptions/{TestUserSubscriptionName}",
                    name: TestUserSubscriptionName,
                    type: "Microsoft.AzureStack/registrations/customersubscriptions",
                    tenantId: TestTenantID
                    );

                var subscription = client.CustomerSubscriptions.Create(TestResourceGroupName, TestRegistrationName, TestUserSubscriptionName, parameter);

                client.CustomerSubscriptions.Delete(TestResourceGroupName, TestRegistrationName, TestUserSubscriptionName);
            });
        }
    }
}