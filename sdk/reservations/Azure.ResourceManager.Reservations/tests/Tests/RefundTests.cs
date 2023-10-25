// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Reservations.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Reservations.Tests
{
    public class RefundTests : ReservationsManagementClientBase
    {
        private TenantResource Tenant { get; set; }
        private ReservationOrderCollection Collection { get; set; }

        public RefundTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();

                AsyncPageable<TenantResource> tenantResourcesResponse = ArmClient.GetTenants().GetAllAsync();
                List<TenantResource> tenantResources = await tenantResourcesResponse.ToEnumerableAsync();
                Tenant = tenantResources.ToArray()[0];
                Collection = Tenant.GetReservationOrders();
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCalculateRefundAndReturn()
        {
            AsyncPageable<ReservationDetailResource> reservationResponse = Tenant.GetReservationDetailsAsync();
            List<ReservationDetailResource> reservationResources = await reservationResponse.ToEnumerableAsync();

            // Find a random `Succeeded` reservation to return
            var reservations = reservationResources.FindAll(item => item.Data.Properties.ProvisioningState.Equals(ReservationProvisioningState.Succeeded) &&
                item.Data.Properties.Quantity > 1);
            Assert.Greater(reservations.Count, 1);
            var orderDetail1 = await Collection.GetAsync(Guid.Parse(reservations[0].Id.Parent.Name));
            var orderDetail2 = await Collection.GetAsync(Guid.Parse(reservations[1].Id.Parent.Name));

            var riToReturn1 = new ReservationToReturn
            {
                ReservationId = reservations[0].Id,
                Quantity = 1
            };

            var riToReturn2 = new ReservationToReturn
            {
                ReservationId = reservations[1].Id,
                Quantity = 1
            };

            var calculateRefundRequest1 = new ReservationCalculateRefundContent
            {
                Id = reservations[0].Id.Parent,
                Properties = new ReservationCalculateRefundRequestProperties
                {
                    Scope = "Reservation",
                    ReservationToReturn = riToReturn1
                }
            };

            var calculateRefundRequest2 = new ReservationCalculateRefundContent
            {
                Id = reservations[1].Id.Parent,
                Properties = new ReservationCalculateRefundRequestProperties
                {
                    Scope = "Reservation",
                    ReservationToReturn = riToReturn2
                }
            };

            var calculateRefundResponse1 = await orderDetail1.Value.CalculateRefundAsync(calculateRefundRequest1);
            var calculateRefundResponse2 = await orderDetail2.Value.CalculateRefundAsync(calculateRefundRequest2);

            TestCalculateRefundResult(calculateRefundResponse1);
            TestCalculateRefundResult(calculateRefundResponse2);

            var refundRequest1 = new ReservationRefundContent
            {
                Properties = new ReservationRefundRequestProperties
                {
                    SessionId = calculateRefundResponse1.Value.Properties.SessionId,
                    Scope = "Reservation",
                    ReservationToReturn = riToReturn1,
                    ReturnReason = "Test"
                }
            };

            // Refun test using non LRO return
            var refundResponse1 = await orderDetail1.Value.ReturnAsync(refundRequest1);

            Assert.IsNotNull(refundResponse1.Value);
            Assert.AreEqual(202, refundResponse1.GetRawResponse().Status);
            Assert.IsNotNull(refundResponse1.Value.Properties);
            Assert.IsNotEmpty(refundResponse1.Value.Properties.SessionId.ToString());
            Assert.GreaterOrEqual(refundResponse1.Value.Properties.Quantity, 1);
            Assert.IsNotNull(refundResponse1.Value.Properties.BillingRefundAmount);
            Assert.IsNotNull(refundResponse1.Value.Properties.PricingRefundAmount);
            Assert.Greater(refundResponse1.Value.Properties.BillingRefundAmount.Amount, 0);
            Assert.AreEqual("GBP", refundResponse1.Value.Properties.BillingRefundAmount.CurrencyCode);
            Assert.Greater(refundResponse1.Value.Properties.PricingRefundAmount.Amount, 0);
            Assert.AreEqual("USD", refundResponse1.Value.Properties.PricingRefundAmount.CurrencyCode);

            // BillingInformation
            Assert.IsNotNull(refundResponse1.Value.Properties.BillingInformation);
            Assert.AreEqual(1, refundResponse1.Value.Properties.BillingInformation.CompletedTransactions);
            Assert.AreEqual(12, refundResponse1.Value.Properties.BillingInformation.TotalTransactions);
            Assert.IsNotNull(refundResponse1.Value.Properties.BillingInformation.BillingPlan);
            Assert.IsNotNull(refundResponse1.Value.Properties.BillingInformation.BillingCurrencyProratedAmount);
            Assert.IsNotNull(refundResponse1.Value.Properties.BillingInformation.BillingCurrencyRemainingCommitmentAmount);
            Assert.IsNotNull(refundResponse1.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount);
            Assert.Greater(refundResponse1.Value.Properties.BillingInformation.BillingCurrencyProratedAmount.Amount, 0);
            Assert.AreEqual("GBP", refundResponse1.Value.Properties.BillingInformation.BillingCurrencyProratedAmount.CurrencyCode);
            Assert.AreEqual("GBP", refundResponse1.Value.Properties.BillingInformation.BillingCurrencyRemainingCommitmentAmount.CurrencyCode);
            Assert.Greater(refundResponse1.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount.Amount, 0);
            Assert.AreEqual("GBP", refundResponse1.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount.CurrencyCode);

            //PolicyResult
            Assert.IsNotNull(refundResponse1.Value.Properties.PolicyResultProperties);
            Assert.AreEqual(0, refundResponse1.Value.Properties.PolicyResultProperties.PolicyErrors.Count);
            Assert.IsNotNull(refundResponse1.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal);
            Assert.IsNotNull(refundResponse1.Value.Properties.PolicyResultProperties.MaxRefundLimit);
            Assert.IsTrue(refundResponse1.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal.Amount > 0);
            Assert.AreEqual("USD", refundResponse1.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal.CurrencyCode);
            Assert.AreEqual(50000, refundResponse1.Value.Properties.PolicyResultProperties.MaxRefundLimit.Amount);
            Assert.AreEqual("USD", refundResponse1.Value.Properties.PolicyResultProperties.MaxRefundLimit.CurrencyCode);

            var refundRequest2 = new ReservationRefundContent
            {
                Properties = new ReservationRefundRequestProperties
                {
                    SessionId = calculateRefundResponse2.Value.Properties.SessionId,
                    Scope = "Reservation",
                    ReservationToReturn = riToReturn2,
                    ReturnReason = "Test"
                }
            };

            // Refun test using  LRO return
            var refundResponse2 = await orderDetail2.Value.ReturnAsync(WaitUntil.Completed, refundRequest2);
            Assert.IsNotNull(refundResponse2.Value);
            Assert.AreEqual(200, refundResponse2.GetRawResponse().Status);
            Assert.IsNotNull(refundResponse2.Value);
            Assert.IsNotNull(refundResponse2.Value.Data);
            Assert.IsNotNull(refundResponse2.Value.Data.Id.ToString());
            Assert.AreEqual("microsoft.capacity/reservationOrders", refundResponse2.Value.Data.ResourceType.ToString());
            Assert.IsNotNull(refundResponse2.Value.Data.Name);
            Assert.GreaterOrEqual(refundResponse2.Value.Data.Version, 1);
            Assert.IsNotNull(refundResponse2.Value.Data.DisplayName);
            Assert.IsNotNull(refundResponse2.Value.Data.Term);
            Assert.IsNotNull(refundResponse2.Value.Data.ProvisioningState);
            Assert.IsNotNull(refundResponse2.Value.Data.Reservations);
            Assert.GreaterOrEqual(refundResponse2.Value.Data.Reservations.Count, 1);
            Assert.IsNotNull(refundResponse2.Value.Data.Reservations[0].Id.ToString());
            Assert.GreaterOrEqual(refundResponse2.Value.Data.OriginalQuantity, 1);
            Assert.IsNotNull(refundResponse2.Value.Data.BillingPlan);
        }
        private void TestCalculateRefundResult(Response<ReservationCalculateRefundResult> calculateRefundResponse)
        {
            Assert.IsNotNull(calculateRefundResponse.Value);
            Assert.AreEqual(200, calculateRefundResponse.GetRawResponse().Status);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties);
            Assert.IsNotEmpty(calculateRefundResponse.Value.Properties.SessionId.ToString());
            Assert.GreaterOrEqual(calculateRefundResponse.Value.Properties.Quantity, 1);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.BillingRefundAmount);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.PricingRefundAmount);
            Assert.GreaterOrEqual(calculateRefundResponse.Value.Properties.BillingRefundAmount.Amount, 0);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.BillingRefundAmount.CurrencyCode);
            Assert.GreaterOrEqual(calculateRefundResponse.Value.Properties.PricingRefundAmount.Amount, 0);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.PricingRefundAmount.CurrencyCode);

            // BillingInformation
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.BillingInformation);
            Assert.GreaterOrEqual(1, calculateRefundResponse.Value.Properties.BillingInformation.CompletedTransactions);
            Assert.GreaterOrEqual(calculateRefundResponse.Value.Properties.BillingInformation.TotalTransactions, 1);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.BillingInformation.BillingPlan);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyProratedAmount);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyRemainingCommitmentAmount);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount);
            Assert.GreaterOrEqual(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyProratedAmount.Amount, 0);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyProratedAmount.CurrencyCode);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyRemainingCommitmentAmount.CurrencyCode);
            Assert.GreaterOrEqual(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount.Amount, 0);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount.CurrencyCode);

            //PolicyResult
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.PolicyResultProperties);
            Assert.AreEqual(0, calculateRefundResponse.Value.Properties.PolicyResultProperties.PolicyErrors.Count);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.PolicyResultProperties.MaxRefundLimit);
            Assert.GreaterOrEqual(calculateRefundResponse.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal.Amount, 0);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal.CurrencyCode);
            Assert.AreEqual(50000, calculateRefundResponse.Value.Properties.PolicyResultProperties.MaxRefundLimit.Amount);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.PolicyResultProperties.MaxRefundLimit.CurrencyCode);
        }
    }
}
