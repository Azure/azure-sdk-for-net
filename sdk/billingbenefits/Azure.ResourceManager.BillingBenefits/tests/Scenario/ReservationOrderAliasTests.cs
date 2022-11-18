// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.BillingBenefits;
using Azure.ResourceManager.BillingBenefits.Tests;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.BillingBenefits.Models;
using Azure.Core;

namespace Azure.ResourceManager.Reservations.Tests
{
    public class ReservationOrderAliasTests : BillingBenefitsManagementTestBase
    {
        private ReservationOrderAliasModelResource ModelResource { get; set; }
        private TenantResource tenantResource { get; set; }

        public ReservationOrderAliasTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();

                AsyncPageable<TenantResource> tenantResourcesResponse = Client.GetTenants().GetAllAsync();
                List<TenantResource> tenantResources = await tenantResourcesResponse.ToEnumerableAsync();
                tenantResource = tenantResources.ToArray()[0];
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateAndGetSharedScopeReservationOrderAlias()
        {
            var resource = ReservationOrderAliasModelResource.CreateResourceIdentifier("testReservationOrderAliasMock");
            ModelResource = Client.GetReservationOrderAliasModelResource(resource);
            var request = CreatePurchaseRequestContent(AppliedScopeType.Shared);
            var createResponse = await ModelResource.CreateOrUpdateAsync(WaitUntil.Completed, request);

            Assert.NotNull(createResponse);
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.NotNull(createResponse.Value);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, AppliedScopeType.Shared);

            var getAliasResponse = await ModelResource.GetAsync();

            Assert.AreEqual(200, getAliasResponse.GetRawResponse().Status);
            ValidateResponseProperties(getAliasResponse.Value.Data, AppliedScopeType.Shared);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateAndGetSingleScopeSavingsPlansOrderAlias()
        {
            var resource = ReservationOrderAliasModelResource.CreateResourceIdentifier("testReservationOrderAliasMockSingle");
            ModelResource = Client.GetReservationOrderAliasModelResource(resource);
            var request = CreatePurchaseRequestContent(AppliedScopeType.Single);
            var createResponse = await ModelResource.CreateOrUpdateAsync(WaitUntil.Completed, request);

            Assert.NotNull(createResponse);
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.NotNull(createResponse.Value);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, AppliedScopeType.Single);

            var getAliasResponse = await ModelResource.GetAsync();

            Assert.AreEqual(200, getAliasResponse.GetRawResponse().Status);
            ValidateResponseProperties(getAliasResponse.Value.Data, AppliedScopeType.Single);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateAndGetSingleResourceGroupScopeSavingsPlansOrderAlias()
        {
            var resource = ReservationOrderAliasModelResource.CreateResourceIdentifier("testReservationOrderAliasMockSingleRG");
            ModelResource = Client.GetReservationOrderAliasModelResource(resource);
            var request = CreatePurchaseRequestContent(AppliedScopeType.Single);
            request.AppliedScopeProperties = new AppliedScopeProperties
            {
                ResourceGroupId = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47/resourceGroups/TestRG"
            };
            var createResponse = await ModelResource.CreateOrUpdateAsync(WaitUntil.Completed, request);

            Assert.NotNull(createResponse);
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.NotNull(createResponse.Value);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, AppliedScopeType.Single, true);

            var getAliasResponse = await ModelResource.GetAsync();

            Assert.AreEqual(200, getAliasResponse.GetRawResponse().Status);
            ValidateResponseProperties(getAliasResponse.Value.Data, AppliedScopeType.Single, true);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateAndGetManagementGroupScopeSavingsPlansOrderAlias()
        {
            var resource = ReservationOrderAliasModelResource.CreateResourceIdentifier("testReservationOrderAliasMockManagementGroup");
            ModelResource = Client.GetReservationOrderAliasModelResource(resource);
            var request = CreatePurchaseRequestContent(AppliedScopeType.ManagementGroup);
            var createResponse = await ModelResource.CreateOrUpdateAsync(WaitUntil.Completed, request);

            Assert.NotNull(createResponse);
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.NotNull(createResponse.Value);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, AppliedScopeType.ManagementGroup);

            var getAliasResponse = await ModelResource.GetAsync();

            Assert.AreEqual(200, getAliasResponse.GetRawResponse().Status);
            ValidateResponseProperties(getAliasResponse.Value.Data, AppliedScopeType.ManagementGroup);
        }

        private void ValidateResponseProperties(ReservationOrderAliasModelData Data, AppliedScopeType scope, bool isRG = false)
        {
            if (scope == AppliedScopeType.Single)
            {
                Assert.NotNull(Data.AppliedScopeProperties);
                if (isRG)
                {
                    Assert.IsEmpty(Data.AppliedScopeProperties.SubscriptionId);
                    Assert.IsNotEmpty(Data.AppliedScopeProperties.ResourceGroupId);
                }
                else
                {
                    Assert.IsNotEmpty(Data.AppliedScopeProperties.SubscriptionId);
                }
            }
            else if (scope == AppliedScopeType.ManagementGroup)
            {
                Assert.NotNull(Data.AppliedScopeProperties);
                Assert.IsNotEmpty(Data.AppliedScopeProperties.ManagementGroupId);
            }
            else
            {
                Assert.Null(Data.AppliedScopeProperties);
            }

            Assert.AreEqual(scope, Data.AppliedScopeType);
            Assert.AreEqual(BillingPlan.P1M, Data.BillingPlan);
            Assert.AreEqual("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47", Data.BillingScopeId);
            Assert.IsNotEmpty(Data.Id);
            Assert.IsNotEmpty(Data.Name);
            Assert.IsNotEmpty(Data.DisplayName);
            Assert.NotNull(Data.ResourceType);
            Assert.AreEqual("Microsoft.BillingBenefits", Data.ResourceType.Namespace);
            Assert.AreEqual("reservationOrderAliases", Data.ResourceType.Type);
            Assert.AreEqual(ProvisioningState.Created, Data.ProvisioningState);
            Assert.IsNotEmpty(Data.ReservationOrderId);
            Assert.NotNull(Data.Sku);
            Assert.AreEqual("Standard_B1s", Data.Sku.Name);
            Assert.AreEqual("Standard_B1s", Data.SkuName);
            Assert.AreEqual(Term.P3Y, Data.Term);
            Assert.AreEqual(1, Data.Quantity);
            Assert.AreEqual(AzureLocation.EastUS, Data.Location);
            Assert.AreEqual(ReservedResourceType.VirtualMachines, Data.ReservedResourceType);
            Assert.AreEqual(InstanceFlexibility.On, Data.ReservedResourceInstanceFlexibility);
            Assert.False(Data.Renew);
        }

        private static ReservationOrderAliasModelCreateOrUpdateContent CreatePurchaseRequestContent(AppliedScopeType scope)
        {
            var request = new ReservationOrderAliasModelCreateOrUpdateContent(new BillingBenefitsSku("Standard_B1s"));
            request.BillingScopeId = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47";
            request.Term = new Term("P3Y");
            request.AppliedScopeType = scope;
            request.DisplayName = "TestROName" + scope.ToString();
            request.BillingPlan = new BillingPlan("P1M");
            request.ReservedResourceType = "VirtualMachines";
            request.Renew = false;
            request.Quantity = 1;
            request.Location = AzureLocation.EastUS;
            request.ReservedResourceProperties = new ReservationOrderAliasRequestReservedResourceProperties
            {
                InstanceFlexibility = InstanceFlexibility.On
            };

            if (scope == AppliedScopeType.Single)
            {
                request.AppliedScopeProperties = new AppliedScopeProperties
                {
                    SubscriptionId = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
                };
            }
            else if (scope == AppliedScopeType.ManagementGroup)
            {
                request.AppliedScopeProperties = new AppliedScopeProperties
                {
                    ManagementGroupId = "/providers/Microsoft.Management/managementGroups/ba5ed788-ddc6-429c-a6a2-0277f01dbee7",
                    TenantId = new Guid("ba5ed788-ddc6-429c-a6a2-0277f01dbee7")
                };
            }

            return request;
        }
    }
}
