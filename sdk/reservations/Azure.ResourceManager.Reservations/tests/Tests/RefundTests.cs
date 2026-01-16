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
            Assert.That(reservations.Count, Is.GreaterThan(1));
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

            Assert.That(refundResponse1.Value, Is.Not.Null);
            Assert.That(refundResponse1.GetRawResponse().Status, Is.EqualTo(202));
            Assert.That(refundResponse1.Value.Properties, Is.Not.Null);
            Assert.That(refundResponse1.Value.Properties.SessionId.ToString(), Is.Not.Empty);
            Assert.That(refundResponse1.Value.Properties.Quantity, Is.GreaterThanOrEqualTo(1));
            Assert.That(refundResponse1.Value.Properties.BillingRefundAmount, Is.Not.Null);
            Assert.That(refundResponse1.Value.Properties.PricingRefundAmount, Is.Not.Null);
            Assert.That(refundResponse1.Value.Properties.BillingRefundAmount.Amount, Is.GreaterThan(0));
            Assert.That(refundResponse1.Value.Properties.BillingRefundAmount.CurrencyCode, Is.EqualTo("GBP"));
            Assert.That(refundResponse1.Value.Properties.PricingRefundAmount.Amount, Is.GreaterThan(0));
            Assert.That(refundResponse1.Value.Properties.PricingRefundAmount.CurrencyCode, Is.EqualTo("USD"));

            // BillingInformation
            Assert.That(refundResponse1.Value.Properties.BillingInformation, Is.Not.Null);
            Assert.That(refundResponse1.Value.Properties.BillingInformation.CompletedTransactions, Is.EqualTo(1));
            Assert.That(refundResponse1.Value.Properties.BillingInformation.TotalTransactions, Is.EqualTo(12));
            Assert.That(refundResponse1.Value.Properties.BillingInformation.BillingPlan, Is.Not.Null);
            Assert.That(refundResponse1.Value.Properties.BillingInformation.BillingCurrencyProratedAmount, Is.Not.Null);
            Assert.That(refundResponse1.Value.Properties.BillingInformation.BillingCurrencyRemainingCommitmentAmount, Is.Not.Null);
            Assert.That(refundResponse1.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount, Is.Not.Null);
            Assert.That(refundResponse1.Value.Properties.BillingInformation.BillingCurrencyProratedAmount.Amount, Is.GreaterThan(0));
            Assert.That(refundResponse1.Value.Properties.BillingInformation.BillingCurrencyProratedAmount.CurrencyCode, Is.EqualTo("GBP"));
            Assert.That(refundResponse1.Value.Properties.BillingInformation.BillingCurrencyRemainingCommitmentAmount.CurrencyCode, Is.EqualTo("GBP"));
            Assert.That(refundResponse1.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount.Amount, Is.GreaterThan(0));
            Assert.That(refundResponse1.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount.CurrencyCode, Is.EqualTo("GBP"));

            //PolicyResult
            Assert.That(refundResponse1.Value.Properties.PolicyResultProperties, Is.Not.Null);
            Assert.That(refundResponse1.Value.Properties.PolicyResultProperties.PolicyErrors.Count, Is.EqualTo(0));
            Assert.That(refundResponse1.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal, Is.Not.Null);
            Assert.That(refundResponse1.Value.Properties.PolicyResultProperties.MaxRefundLimit, Is.Not.Null);
            Assert.That(refundResponse1.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal.Amount > 0, Is.True);
            Assert.That(refundResponse1.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal.CurrencyCode, Is.EqualTo("USD"));
            Assert.That(refundResponse1.Value.Properties.PolicyResultProperties.MaxRefundLimit.Amount, Is.EqualTo(50000));
            Assert.That(refundResponse1.Value.Properties.PolicyResultProperties.MaxRefundLimit.CurrencyCode, Is.EqualTo("USD"));

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
            Assert.That(refundResponse2.Value, Is.Not.Null);
            Assert.That(refundResponse2.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(refundResponse2.Value, Is.Not.Null);
            Assert.That(refundResponse2.Value.Data, Is.Not.Null);
            Assert.That(refundResponse2.Value.Data.Id.ToString(), Is.Not.Null);
            Assert.That(refundResponse2.Value.Data.ResourceType.ToString(), Is.EqualTo("microsoft.capacity/reservationOrders"));
            Assert.That(refundResponse2.Value.Data.Name, Is.Not.Null);
            Assert.That(refundResponse2.Value.Data.Version, Is.GreaterThanOrEqualTo(1));
            Assert.That(refundResponse2.Value.Data.DisplayName, Is.Not.Null);
            Assert.That(refundResponse2.Value.Data.Term, Is.Not.Null);
            Assert.That(refundResponse2.Value.Data.ProvisioningState, Is.Not.Null);
            Assert.That(refundResponse2.Value.Data.Reservations, Is.Not.Null);
            Assert.That(refundResponse2.Value.Data.Reservations.Count, Is.GreaterThanOrEqualTo(1));
            Assert.That(refundResponse2.Value.Data.Reservations[0].Id.ToString(), Is.Not.Null);
            Assert.That(refundResponse2.Value.Data.OriginalQuantity, Is.GreaterThanOrEqualTo(1));
            Assert.That(refundResponse2.Value.Data.BillingPlan, Is.Not.Null);
        }
        private void TestCalculateRefundResult(Response<ReservationCalculateRefundResult> calculateRefundResponse)
        {
            Assert.That(calculateRefundResponse.Value, Is.Not.Null);
            Assert.That(calculateRefundResponse.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(calculateRefundResponse.Value.Properties, Is.Not.Null);
            Assert.That(calculateRefundResponse.Value.Properties.SessionId.ToString(), Is.Not.Empty);
            Assert.That(calculateRefundResponse.Value.Properties.Quantity, Is.GreaterThanOrEqualTo(1));
            Assert.That(calculateRefundResponse.Value.Properties.BillingRefundAmount, Is.Not.Null);
            Assert.That(calculateRefundResponse.Value.Properties.PricingRefundAmount, Is.Not.Null);
            Assert.That(calculateRefundResponse.Value.Properties.BillingRefundAmount.Amount, Is.GreaterThanOrEqualTo(0));
            Assert.That(calculateRefundResponse.Value.Properties.BillingRefundAmount.CurrencyCode, Is.Not.Null);
            Assert.That(calculateRefundResponse.Value.Properties.PricingRefundAmount.Amount, Is.GreaterThanOrEqualTo(0));
            Assert.That(calculateRefundResponse.Value.Properties.PricingRefundAmount.CurrencyCode, Is.Not.Null);

            // BillingInformation
            Assert.That(calculateRefundResponse.Value.Properties.BillingInformation, Is.Not.Null);
            Assert.That(1, Is.GreaterThanOrEqualTo(calculateRefundResponse.Value.Properties.BillingInformation.CompletedTransactions));
            Assert.That(calculateRefundResponse.Value.Properties.BillingInformation.TotalTransactions, Is.GreaterThanOrEqualTo(1));
            Assert.That(calculateRefundResponse.Value.Properties.BillingInformation.BillingPlan, Is.Not.Null);
            Assert.That(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyProratedAmount, Is.Not.Null);
            Assert.That(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyRemainingCommitmentAmount, Is.Not.Null);
            Assert.That(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount, Is.Not.Null);
            Assert.That(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyProratedAmount.Amount, Is.GreaterThanOrEqualTo(0));
            Assert.That(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyProratedAmount.CurrencyCode, Is.Not.Null);
            Assert.That(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyRemainingCommitmentAmount.CurrencyCode, Is.Not.Null);
            Assert.That(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount.Amount, Is.GreaterThanOrEqualTo(0));
            Assert.That(calculateRefundResponse.Value.Properties.BillingInformation.BillingCurrencyTotalPaidAmount.CurrencyCode, Is.Not.Null);

            //PolicyResult
            Assert.That(calculateRefundResponse.Value.Properties.PolicyResultProperties, Is.Not.Null);
            Assert.That(calculateRefundResponse.Value.Properties.PolicyResultProperties.PolicyErrors.Count, Is.EqualTo(0));
            Assert.That(calculateRefundResponse.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal, Is.Not.Null);
            Assert.That(calculateRefundResponse.Value.Properties.PolicyResultProperties.MaxRefundLimit, Is.Not.Null);
            Assert.That(calculateRefundResponse.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal.Amount, Is.GreaterThanOrEqualTo(0));
            Assert.That(calculateRefundResponse.Value.Properties.PolicyResultProperties.ConsumedRefundsTotal.CurrencyCode, Is.Not.Null);
            Assert.That(calculateRefundResponse.Value.Properties.PolicyResultProperties.MaxRefundLimit.Amount, Is.EqualTo(50000));
            Assert.That(calculateRefundResponse.Value.Properties.PolicyResultProperties.MaxRefundLimit.CurrencyCode, Is.Not.Null);
        }
    }
}
