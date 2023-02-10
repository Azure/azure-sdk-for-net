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
            var calculateExchangeRequestProperties = new CalculateExchangeContentProperties();
            calculateExchangeRequestProperties.ReservationsToExchange.Add(new ReservationToReturn
            {
                ReservationId = new ResourceIdentifier("/providers/microsoft.capacity/reservationOrders/be56711c-7ba2-4b62-bcb8-cb93ba191ea1/reservations/dc84da8a-9650-455c-9968-b83ac2ae4adb"),
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
            Assert.IsTrue(calculateExchangeResponse.Value.Properties.NetPayable.Amount > 0);
            Assert.AreEqual("USD", calculateExchangeResponse.Value.Properties.NetPayable.CurrencyCode);
            Assert.IsTrue(calculateExchangeResponse.Value.Properties.PurchasesTotal.Amount > 0);
            Assert.AreEqual("USD", calculateExchangeResponse.Value.Properties.PurchasesTotal.CurrencyCode);
            Assert.IsTrue(calculateExchangeResponse.Value.Properties.RefundsTotal.Amount > 0);
            Assert.AreEqual("USD", calculateExchangeResponse.Value.Properties.RefundsTotal.CurrencyCode);
            Assert.IsNotEmpty(calculateExchangeResponse.Value.Properties.SessionId.ToString());
            Assert.IsNotNull(calculateExchangeResponse.Value.Properties.ReservationsToExchange);
            Assert.AreEqual(1, calculateExchangeResponse.Value.Properties.ReservationsToExchange.Count);
            Assert.AreEqual("/providers/microsoft.capacity/reservationOrders/be56711c-7ba2-4b62-bcb8-cb93ba191ea1/reservations/dc84da8a-9650-455c-9968-b83ac2ae4adb",
                        calculateExchangeResponse.Value.Properties.ReservationsToExchange[0].ReservationId.ToString());
            Assert.AreEqual(2, calculateExchangeResponse.Value.Properties.ReservationsToExchange[0].Quantity);
            Assert.IsNotNull(calculateExchangeResponse.Value.Properties.ReservationsToPurchase);
            Assert.AreEqual(1, calculateExchangeResponse.Value.Properties.ReservationsToPurchase.Count);

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
            Assert.IsTrue(exchangeResponse.Value.Properties.NetPayable.Amount > 0);
            Assert.AreEqual("USD", exchangeResponse.Value.Properties.NetPayable.CurrencyCode);
            Assert.IsTrue(exchangeResponse.Value.Properties.PurchasesTotal.Amount > 0);
            Assert.AreEqual("USD", exchangeResponse.Value.Properties.PurchasesTotal.CurrencyCode);
            Assert.IsTrue(exchangeResponse.Value.Properties.RefundsTotal.Amount > 0);
            Assert.AreEqual("USD", exchangeResponse.Value.Properties.RefundsTotal.CurrencyCode);
            Assert.IsNotEmpty(exchangeResponse.Value.Properties.SessionId.ToString());
            Assert.IsNotNull(exchangeResponse.Value.Properties.ReservationsToExchange);
            Assert.AreEqual(1, exchangeResponse.Value.Properties.ReservationsToExchange.Count);
            Assert.AreEqual("/providers/microsoft.capacity/reservationOrders/be56711c-7ba2-4b62-bcb8-cb93ba191ea1/reservations/dc84da8a-9650-455c-9968-b83ac2ae4adb",
                        exchangeResponse.Value.Properties.ReservationsToExchange[0].ReservationId.ToString());
            Assert.AreEqual(2, exchangeResponse.Value.Properties.ReservationsToExchange[0].Quantity);
            Assert.IsNotNull(exchangeResponse.Value.Properties.ReservationsToPurchase);
            Assert.AreEqual(1, exchangeResponse.Value.Properties.ReservationsToPurchase.Count);
        }
    }
}
