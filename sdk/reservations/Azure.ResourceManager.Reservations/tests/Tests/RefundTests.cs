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
            var reservation = reservationResources.Find(item => item.Data.Properties.ProvisioningState.Equals(ReservationProvisioningState.Succeeded) &&
                item.Data.Properties.Quantity > 1);
            var fullyQualifiedId = reservation.Id;
            var fullyQualifiedOrderId = reservation.Id.Parent;
            var orderDetail = await Collection.GetAsync(Guid.Parse(reservation.Id.Parent.Name));

            var riToReturn = new ReservationToReturn
            {
                ReservationId = fullyQualifiedId,
                Quantity = 1
            };

            var calculateRefundRequest = new ReservationCalculateRefundContent
            {
                Id = fullyQualifiedOrderId,
                Properties = new ReservationCalculateRefundRequestProperties
                {
                    Scope = "Reservation",
                    ReservationToReturn = riToReturn
                }
            };

            var calculateRefundResponse = await orderDetail.Value.CalculateRefundAsync(calculateRefundRequest);

            Assert.IsNotNull(calculateRefundResponse.Value);
            Assert.AreEqual(200, calculateRefundResponse.GetRawResponse().Status);
            Assert.AreEqual(fullyQualifiedId, calculateRefundResponse.Value.Id);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties);
            Assert.IsNotEmpty(calculateRefundResponse.Value.Properties.SessionId.ToString());
            Assert.AreEqual(1, calculateRefundResponse.Value.Properties.Quantity);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.BillingRefundAmount);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.PricingRefundAmount);
            Assert.IsTrue(calculateRefundResponse.Value.Properties.BillingRefundAmount.Amount > 0);
            Assert.AreEqual("USD", calculateRefundResponse.Value.Properties.BillingRefundAmount.CurrencyCode);
            Assert.IsTrue(calculateRefundResponse.Value.Properties.PricingRefundAmount.Amount > 0);
            Assert.AreEqual("USD", calculateRefundResponse.Value.Properties.PricingRefundAmount.CurrencyCode);

            // BillingInformation
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.BillingInformation);
            Assert.AreEqual(1, calculateRefundResponse.Value.Properties.BillingInformation.CompletedTransactions);
            Assert.AreEqual(1, calculateRefundResponse.Value.Properties.BillingInformation.TotalTransactions);
            Assert.AreEqual(ReservationBillingPlan.Upfront, calculateRefundResponse.Value.Properties.BillingInformation.BillingPlan);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyProratedAmount);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyRemainingCommitmentAmount);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount);
            Assert.IsTrue(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyProratedAmount.Amount > 0);
            Assert.AreEqual("USD", calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyProratedAmount.CurrencyCode);
            Assert.AreEqual(0, calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyRemainingCommitmentAmount.Amount); // Test RI is `Upfront` so this should be 0
            Assert.AreEqual("USD", calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyRemainingCommitmentAmount.CurrencyCode);
            Assert.IsTrue(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount.Amount > 0);
            Assert.AreEqual("USD", calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount.CurrencyCode);

            //PolicyResult
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.PolicyResultProperties);
            Assert.AreEqual(0, calculateRefundResponse.Value.Properties.PolicyResultProperties.PolicyErrors.Count);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal);
            Assert.IsNotNull(calculateRefundResponse.Value.Properties.PolicyResultProperties.MaxRefundLimit);
            Assert.IsTrue(calculateRefundResponse.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal.Amount > 0);
            Assert.AreEqual("USD", calculateRefundResponse.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal.CurrencyCode);
            Assert.AreEqual(50000, calculateRefundResponse.Value.Properties.PolicyResultProperties.MaxRefundLimit.Amount);
            Assert.AreEqual("USD", calculateRefundResponse.Value.Properties.PolicyResultProperties.MaxRefundLimit.CurrencyCode);

            var refundRequest = new ReservationRefundContent
            {
                Properties = new ReservationRefundRequestProperties
                {
                    SessionId = calculateRefundResponse.Value.Properties.SessionId,
                    Scope = "Reservation",
                    ReservationToReturn = riToReturn,
                    ReturnReason = "Test"
                }
            };

            var refundResponse = await orderDetail.Value.ReturnAsync(refundRequest);

            Assert.IsNotNull(refundResponse.Value);
            Assert.AreEqual(202, refundResponse.GetRawResponse().Status);
            Assert.AreEqual(fullyQualifiedId, refundResponse.Value.Id);
            Assert.IsNotNull(refundResponse.Value.Properties);
            Assert.IsNotEmpty(refundResponse.Value.Properties.SessionId.ToString());
            Assert.AreEqual(1, refundResponse.Value.Properties.Quantity);
            Assert.IsNotNull(refundResponse.Value.Properties.BillingRefundAmount);
            Assert.IsNotNull(refundResponse.Value.Properties.PricingRefundAmount);
            Assert.IsTrue(refundResponse.Value.Properties.BillingRefundAmount.Amount > 0);
            Assert.AreEqual("USD", refundResponse.Value.Properties.BillingRefundAmount.CurrencyCode);
            Assert.IsTrue(refundResponse.Value.Properties.PricingRefundAmount.Amount > 0);
            Assert.AreEqual("USD", refundResponse.Value.Properties.PricingRefundAmount.CurrencyCode);

            // BillingInformation
            Assert.IsNotNull(refundResponse.Value.Properties.BillingInformation);
            Assert.AreEqual(1, refundResponse.Value.Properties.BillingInformation.CompletedTransactions);
            Assert.AreEqual(1, refundResponse.Value.Properties.BillingInformation.TotalTransactions);
            Assert.AreEqual(ReservationBillingPlan.Upfront, refundResponse.Value.Properties.BillingInformation.BillingPlan);
            Assert.IsNotNull(refundResponse.Value.Properties.BillingInformation.BillingCurrencyProratedAmount);
            Assert.IsNotNull(refundResponse.Value.Properties.BillingInformation.BillingCurrencyRemainingCommitmentAmount);
            Assert.IsNotNull(refundResponse.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount);
            Assert.IsTrue(refundResponse.Value.Properties.BillingInformation.BillingCurrencyProratedAmount.Amount > 0);
            Assert.AreEqual("USD", refundResponse.Value.Properties.BillingInformation.BillingCurrencyProratedAmount.CurrencyCode);
            Assert.AreEqual(0, refundResponse.Value.Properties.BillingInformation.BillingCurrencyRemainingCommitmentAmount.Amount); // Test RI is `Upfront` so this should be 0
            Assert.AreEqual("USD", refundResponse.Value.Properties.BillingInformation.BillingCurrencyRemainingCommitmentAmount.CurrencyCode);
            Assert.IsTrue(refundResponse.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount.Amount > 0);
            Assert.AreEqual("USD", refundResponse.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount.CurrencyCode);

            //PolicyResult
            Assert.IsNotNull(refundResponse.Value.Properties.PolicyResultProperties);
            Assert.AreEqual(0, refundResponse.Value.Properties.PolicyResultProperties.PolicyErrors.Count);
            Assert.IsNotNull(refundResponse.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal);
            Assert.IsNotNull(refundResponse.Value.Properties.PolicyResultProperties.MaxRefundLimit);
            Assert.IsTrue(refundResponse.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal.Amount > 0);
            Assert.AreEqual("USD", refundResponse.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal.CurrencyCode);
            Assert.AreEqual(50000, refundResponse.Value.Properties.PolicyResultProperties.MaxRefundLimit.Amount);
            Assert.AreEqual("USD", refundResponse.Value.Properties.PolicyResultProperties.MaxRefundLimit.CurrencyCode);
        }
    }
}
