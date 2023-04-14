// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Reservations.Models;
using Azure.ResourceManager.Reservations.Tests.Helper;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Reservations.Tests
{
    public class ExchangeTests : ReservationsManagementClientBase
    {
        private TenantResource Tenant { get; set; }

        public ExchangeTests(bool isAsync) : base(isAsync)
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
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCalculateExchangeAndExchange()
        {
            AsyncPageable<ReservationDetailResource> reservationResponse = Tenant.GetReservationDetailsAsync();
            List<ReservationDetailResource> reservationResources = await reservationResponse.ToEnumerableAsync();
            var reservation = reservationResources.Find(item => item.Data.Properties.ProvisioningState.Equals(ReservationProvisioningState.Succeeded) &&
                item.Data.Properties.Quantity > 1);

            var calculateExchangeRequestProperties = new CalculateExchangeContentProperties();
            calculateExchangeRequestProperties.ReservationsToExchange.Add(new ReservationToReturn
            {
                ReservationId = new ResourceIdentifier(reservation.Id),
                Quantity = 2
            });
            calculateExchangeRequestProperties.ReservationsToPurchase.Add(TestHelpers.CreatePurchaseRequestContent("Shared", "Upfront"));

            var calculateExchangeRequest = new CalculateExchangeContent
            {
                Properties = calculateExchangeRequestProperties
            };

            var calculateExchangeResponse = await Tenant.CalculateReservationExchangeAsync(WaitUntil.Completed, calculateExchangeRequest);

            Assert.IsNotNull(calculateExchangeResponse.Value);
            Assert.AreEqual(CalculateExchangeOperationResultStatus.Succeeded, calculateExchangeResponse.Value.Status);
            Assert.IsNotEmpty(calculateExchangeResponse.Value.Id);
            Assert.IsNotEmpty(calculateExchangeResponse.Value.Name);
            Assert.IsNotNull(calculateExchangeResponse.Value.Properties);
            Assert.IsNotNull(calculateExchangeResponse.Value.Properties.NetPayable);
            Assert.IsNotNull(calculateExchangeResponse.Value.Properties.PurchasesTotal);
            Assert.IsNotNull(calculateExchangeResponse.Value.Properties.RefundsTotal);
            Assert.Greater(calculateExchangeResponse.Value.Properties.NetPayable.Amount, 0);
            Assert.AreEqual("GBP", calculateExchangeResponse.Value.Properties.NetPayable.CurrencyCode);
            Assert.Greater(calculateExchangeResponse.Value.Properties.PurchasesTotal.Amount, 0);
            Assert.AreEqual("GBP", calculateExchangeResponse.Value.Properties.PurchasesTotal.CurrencyCode);
            Assert.Greater(calculateExchangeResponse.Value.Properties.RefundsTotal.Amount, 0);
            Assert.AreEqual("GBP", calculateExchangeResponse.Value.Properties.RefundsTotal.CurrencyCode);
            Assert.IsNotEmpty(calculateExchangeResponse.Value.Properties.SessionId.ToString());
            Assert.IsNotNull(calculateExchangeResponse.Value.Properties.ReservationsToExchange);
            Assert.GreaterOrEqual(calculateExchangeResponse.Value.Properties.ReservationsToExchange.Count, 1);
            Assert.IsNotNull(calculateExchangeResponse.Value.Properties.ReservationsToExchange[0].ReservationId);
            Assert.GreaterOrEqual(calculateExchangeResponse.Value.Properties.ReservationsToExchange[0].Quantity, 1);
            Assert.IsNotNull(calculateExchangeResponse.Value.Properties.ReservationsToPurchase);
            Assert.GreaterOrEqual(calculateExchangeResponse.Value.Properties.ReservationsToPurchase.Count, 1);

            var exchangeRequest = new ExchangeContent
            {
                ExchangeRequestSessionId = calculateExchangeResponse.Value.Properties.SessionId
            };

            var exchangeResponse = await Tenant.ExchangeAsync(WaitUntil.Completed, exchangeRequest);

            Assert.IsNotNull(exchangeResponse.Value);
            Assert.AreEqual(ExchangeOperationResultStatus.Succeeded, exchangeResponse.Value.Status);
            Assert.IsNotEmpty(exchangeResponse.Value.Id);
            Assert.IsNotEmpty(exchangeResponse.Value.Name);
            Assert.IsNotNull(exchangeResponse.Value.Properties);
            Assert.IsNotNull(exchangeResponse.Value.Properties.NetPayable);
            Assert.IsNotNull(exchangeResponse.Value.Properties.PurchasesTotal);
            Assert.IsNotNull(exchangeResponse.Value.Properties.RefundsTotal);
            Assert.Greater(exchangeResponse.Value.Properties.NetPayable.Amount, 0);
            Assert.AreEqual("GBP", exchangeResponse.Value.Properties.NetPayable.CurrencyCode);
            Assert.Greater(exchangeResponse.Value.Properties.PurchasesTotal.Amount, 0);
            Assert.AreEqual("GBP", exchangeResponse.Value.Properties.PurchasesTotal.CurrencyCode);
            Assert.Greater(exchangeResponse.Value.Properties.RefundsTotal.Amount, 0);
            Assert.AreEqual("GBP", exchangeResponse.Value.Properties.RefundsTotal.CurrencyCode);
            Assert.IsNotEmpty(exchangeResponse.Value.Properties.SessionId.ToString());
            Assert.IsNotNull(exchangeResponse.Value.Properties.ReservationsToExchange);
            Assert.GreaterOrEqual(exchangeResponse.Value.Properties.ReservationsToExchange.Count, 1);
            Assert.IsNotNull(exchangeResponse.Value.Properties.ReservationsToExchange[0].ReservationId.ToString());
            Assert.GreaterOrEqual(exchangeResponse.Value.Properties.ReservationsToExchange[0].Quantity, 1);
            Assert.IsNotNull(exchangeResponse.Value.Properties.ReservationsToPurchase);
            Assert.GreaterOrEqual(exchangeResponse.Value.Properties.ReservationsToPurchase.Count, 1);
        }
    }
}
