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

            Assert.That(calculateExchangeResponse.Value, Is.Not.Null);
            Assert.That(calculateExchangeResponse.Value.Status, Is.EqualTo(CalculateExchangeOperationResultStatus.Succeeded));
            Assert.That((string)calculateExchangeResponse.Value.Id, Is.Not.Empty);
            Assert.That(calculateExchangeResponse.Value.Name, Is.Not.Empty);
            Assert.That(calculateExchangeResponse.Value.Properties, Is.Not.Null);
            Assert.That(calculateExchangeResponse.Value.Properties.NetPayable, Is.Not.Null);
            Assert.That(calculateExchangeResponse.Value.Properties.PurchasesTotal, Is.Not.Null);
            Assert.That(calculateExchangeResponse.Value.Properties.RefundsTotal, Is.Not.Null);
            Assert.That(calculateExchangeResponse.Value.Properties.NetPayable.Amount, Is.GreaterThan(0));
            Assert.That(calculateExchangeResponse.Value.Properties.NetPayable.CurrencyCode, Is.EqualTo("GBP"));
            Assert.That(calculateExchangeResponse.Value.Properties.PurchasesTotal.Amount, Is.GreaterThan(0));
            Assert.That(calculateExchangeResponse.Value.Properties.PurchasesTotal.CurrencyCode, Is.EqualTo("GBP"));
            Assert.That(calculateExchangeResponse.Value.Properties.RefundsTotal.Amount, Is.GreaterThan(0));
            Assert.That(calculateExchangeResponse.Value.Properties.RefundsTotal.CurrencyCode, Is.EqualTo("GBP"));
            Assert.That(calculateExchangeResponse.Value.Properties.SessionId.ToString(), Is.Not.Empty);
            Assert.That(calculateExchangeResponse.Value.Properties.ReservationsToExchange, Is.Not.Null);
            Assert.That(calculateExchangeResponse.Value.Properties.ReservationsToExchange.Count, Is.GreaterThanOrEqualTo(1));
            Assert.That(calculateExchangeResponse.Value.Properties.ReservationsToExchange[0].ReservationId, Is.Not.Null);
            Assert.That(calculateExchangeResponse.Value.Properties.ReservationsToExchange[0].Quantity, Is.GreaterThanOrEqualTo(1));
            Assert.That(calculateExchangeResponse.Value.Properties.ReservationsToPurchase, Is.Not.Null);
            Assert.That(calculateExchangeResponse.Value.Properties.ReservationsToPurchase.Count, Is.GreaterThanOrEqualTo(1));

            var exchangeRequest = new ExchangeContent
            {
                ExchangeRequestSessionId = calculateExchangeResponse.Value.Properties.SessionId
            };

            var exchangeResponse = await Tenant.ExchangeAsync(WaitUntil.Completed, exchangeRequest);

            Assert.That(exchangeResponse.Value, Is.Not.Null);
            Assert.That(exchangeResponse.Value.Status, Is.EqualTo(ExchangeOperationResultStatus.Succeeded));
            Assert.That((string)exchangeResponse.Value.Id, Is.Not.Empty);
            Assert.That(exchangeResponse.Value.Name, Is.Not.Empty);
            Assert.That(exchangeResponse.Value.Properties, Is.Not.Null);
            Assert.That(exchangeResponse.Value.Properties.NetPayable, Is.Not.Null);
            Assert.That(exchangeResponse.Value.Properties.PurchasesTotal, Is.Not.Null);
            Assert.That(exchangeResponse.Value.Properties.RefundsTotal, Is.Not.Null);
            Assert.That(exchangeResponse.Value.Properties.NetPayable.Amount, Is.GreaterThan(0));
            Assert.That(exchangeResponse.Value.Properties.NetPayable.CurrencyCode, Is.EqualTo("GBP"));
            Assert.That(exchangeResponse.Value.Properties.PurchasesTotal.Amount, Is.GreaterThan(0));
            Assert.That(exchangeResponse.Value.Properties.PurchasesTotal.CurrencyCode, Is.EqualTo("GBP"));
            Assert.That(exchangeResponse.Value.Properties.RefundsTotal.Amount, Is.GreaterThan(0));
            Assert.That(exchangeResponse.Value.Properties.RefundsTotal.CurrencyCode, Is.EqualTo("GBP"));
            Assert.That(exchangeResponse.Value.Properties.SessionId.ToString(), Is.Not.Empty);
            Assert.That(exchangeResponse.Value.Properties.ReservationsToExchange, Is.Not.Null);
            Assert.That(exchangeResponse.Value.Properties.ReservationsToExchange.Count, Is.GreaterThanOrEqualTo(1));
            Assert.That(exchangeResponse.Value.Properties.ReservationsToExchange[0].ReservationId.ToString(), Is.Not.Null);
            Assert.That(exchangeResponse.Value.Properties.ReservationsToExchange[0].Quantity, Is.GreaterThanOrEqualTo(1));
            Assert.That(exchangeResponse.Value.Properties.ReservationsToPurchase, Is.Not.Null);
            Assert.That(exchangeResponse.Value.Properties.ReservationsToPurchase.Count, Is.GreaterThanOrEqualTo(1));
        }
    }
}
