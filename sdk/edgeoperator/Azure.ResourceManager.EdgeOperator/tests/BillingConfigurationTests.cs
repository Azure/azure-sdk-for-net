// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EdgeOperator.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeOperator.Tests
{
    /// <summary>
    /// SDK-level tests for the Microsoft.EdgeOperator billingConfigurations resource. These mirror
    /// the positive scenarios in
    /// <c>src/OperatorResourceProviders/tests/TestsViaARM/BillingConfigurationTests.ps1</c>, exercised
    /// through the strongly typed management SDK instead of raw ARM requests.
    ///
    /// EdgeOperator is an Azure Local Disconnected Operations (ALDO) provider whose ARM endpoint is
    /// only reachable from a disconnected stamp, so these tests are recorded once (Record mode) on an
    /// ALDO/irvm01 environment and replayed by CI (Playback mode). See
    /// <see cref="EdgeOperatorManagementTestEnvironment"/> for the endpoint/audience wiring.
    ///
    /// Negative HTTP-shape scenarios (non-'default' name, PATCH/DELETE rejection, external snapshot
    /// write/delete rejection) are not expressible through the typed singleton/read-only SDK surface
    /// and remain covered by the via-ARM PowerShell suite. <see cref="InvalidBillingModel_IsRejected"/>
    /// covers the one negative case the SDK can express (extensible enum with an unsupported value).
    /// </summary>
    public class BillingConfigurationTests : EdgeOperatorManagementTestBase
    {
        public BillingConfigurationTests(bool isAsync) : base(isAsync)
        {
        }

        private BillingConfigurationData BuildBillingConfigurationData(BillingModel billingModel = default)
        {
            if (billingModel == default)
            {
                billingModel = BillingModel.Capacity;
            }

            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            var resourceId = new ResourceIdentifier(
                $"/subscriptions/{subscriptionId}/resourceGroups/rgBillingTest/providers/Microsoft.AzureStackHCI/clusters/billing-test-cluster");

            var current = new BillingPeriodDetails(cores: 12, pricingModel: "Trial", startOn: DateTimeOffset.Parse("2025-11-01"))
            {
                EndOn = DateTimeOffset.Parse("2025-12-31"),
            };

            var upcoming = new BillingPeriodDetails(cores: 24, pricingModel: "Annual", startOn: DateTimeOffset.Parse("2026-01-01"));

            var billingConfiguration = new BillingConfigurationDetails(AutoRenew.Enabled, "Enabled", current)
            {
                Upcoming = upcoming,
            };

            var properties = new BillingConfigurationProperties(
                resourceId,
                resourceName: "billing-test-cluster",
                stampId: "401ECB09-83EC-4777-A56C-6FFF26BCC815",
                location: "eastus",
                billingModel,
                connectionIntent: "Connected",
                billingConfiguration)
            {
                Cloud = "Public",
                BenefitPlans = new BenefitPlans
                {
                    AzureHybridWindowsServerBenefit = BenefitPlanStatus.Enabled,
                    WindowsServerVmCount = 5,
                },
            };

            return new BillingConfigurationData { Properties = properties };
        }

        private static void AssertResponseShape(BillingConfigurationResource resource)
        {
            Assert.That(resource, Is.Not.Null);
            Assert.That(resource.HasData, Is.True);
            Assert.That(resource.Data.Name, Is.EqualTo("default"));
            Assert.That(resource.Id.ToString().ToLowerInvariant(), Does.EndWith("/billingconfigurations/default"));
            Assert.That(resource.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.EdgeOperator/billingConfigurations").IgnoreCase);
            Assert.That(resource.Data.Properties, Is.Not.Null);
            Assert.That(resource.Data.Properties.BillingModel, Is.EqualTo(BillingModel.Capacity));
        }

        [RecordedTest]
        public async Task CreateBillingConfiguration_Default_Succeeds()
        {
            BillingConfigurationResource billingConfiguration = DefaultSubscription.GetBillingConfiguration();

            ArmOperation<BillingConfigurationResource> operation =
                await billingConfiguration.CreateOrUpdateAsync(WaitUntil.Completed, BuildBillingConfigurationData());

            AssertResponseShape(operation.Value);
        }

        [RecordedTest]
        public async Task GetBillingConfiguration_Default_RoundTrips()
        {
            BillingConfigurationResource billingConfiguration = DefaultSubscription.GetBillingConfiguration();
            await billingConfiguration.CreateOrUpdateAsync(WaitUntil.Completed, BuildBillingConfigurationData());

            Response<BillingConfigurationResource> response = await billingConfiguration.GetAsync();

            AssertResponseShape(response.Value);
            Assert.That(response.Value.Data.Properties.ResourceName, Is.EqualTo("billing-test-cluster"));
            Assert.That(
                response.Value.Data.Properties.StampId,
                Is.EqualTo("401ECB09-83EC-4777-A56C-6FFF26BCC815").Or.EqualTo(SanitizeValue));
        }

        [RecordedTest]
        public async Task ReadBillingConfigurationSnapshots_ReturnsHistory()
        {
            BillingConfigurationResource billingConfiguration = DefaultSubscription.GetBillingConfiguration();
            await billingConfiguration.CreateOrUpdateAsync(WaitUntil.Completed, BuildBillingConfigurationData());

            // The snapshot is written asynchronously by the ResourceCreationCompleted callback, so
            // poll the list for a bounded window. Delays are real in Record mode and skipped in Playback.
            BillingConfigurationSnapshotResource snapshot = null;
            for (int attempt = 0; attempt < 24 && snapshot is null; attempt++)
            {
                await foreach (BillingConfigurationSnapshotResource item in billingConfiguration.GetBillingConfigurationSnapshots().GetAllAsync())
                {
                    snapshot = item;
                    break;
                }

                if (snapshot is null)
                {
                    await Delay(5000);
                }
            }

            Assert.That(snapshot, Is.Not.Null, "Expected at least one billing configuration snapshot after create.");
            Assert.That(snapshot.HasData, Is.True);
            Assert.That(snapshot.Data.Properties, Is.Not.Null);
        }

        [RecordedTest]
        public void InvalidBillingModel_IsRejected()
        {
            BillingConfigurationResource billingConfiguration = DefaultSubscription.GetBillingConfiguration();
            BillingConfigurationData data = BuildBillingConfigurationData(billingModel: "InvalidModel");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await billingConfiguration.CreateOrUpdateAsync(WaitUntil.Completed, data));

            Assert.That(ex.Status, Is.EqualTo(400));
        }
    }
}
