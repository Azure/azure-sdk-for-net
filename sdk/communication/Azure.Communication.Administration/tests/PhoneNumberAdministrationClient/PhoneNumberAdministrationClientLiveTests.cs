// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Communication.Administration.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Administration.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="PhoneNumberAdministrationClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class PhoneNumberAdministrationClientLiveTests : PhoneNumberAdministrationClientLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberAdministrationClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public PhoneNumberAdministrationClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [TestCase(null, TestName = "GetAllSupportedCountries")]
        [TestCase("en-US", TestName = "GetAllSupportedCountriesEnUsLocale")]
        public async Task GetAllSupportedCountries(string? locale)
        {
            var client = CreateClient();

            var countries = client.GetAllSupportedCountriesAsync(locale);

            await foreach (var country in countries)
            {
                Assert.IsFalse(string.IsNullOrEmpty(country.CountryCode));
                Assert.IsFalse(string.IsNullOrEmpty(country.LocalizedName));
            }
        }

        [Test]
        public async Task GetAllPhoneNumbers()
        {
            var client = CreateClient();

            var numbersPagable = client.GetAllPhoneNumbersAsync();
            var numbers = await numbersPagable.ToEnumerableAsync();

            Assert.IsNotNull(numbers);
        }

        [Test]
        public async Task GetAllReservations()
        {
            // Arrange
            var client = CreateClient();

            const string locale = "en-US";
            const string countryCode = "US";

            var pageablePhonePlanGroups = client.GetPhonePlanGroupsAsync(countryCode, locale);
            var phonePlanGroups = await pageablePhonePlanGroups.ToEnumerableAsync().ConfigureAwait(false);

            string phonePlanGroupId = phonePlanGroups.First(group => group.PhoneNumberType == PhoneNumberType.TollFree).PhonePlanGroupId;
            var pageablePhonePlans = client.GetPhonePlansAsync(countryCode, phonePlanGroupId, locale);
            var phonePlan = (await pageablePhonePlans.ToEnumerableAsync()).First();
            var areaCode = phonePlan.AreaCodes.First();

            var reservationOptions = new CreateReservationOptions("My reservation", "my description", new[] { phonePlan.PhonePlanId }, areaCode);
            reservationOptions.Quantity = 1;
            var reservationOperation = await client.StartReservationAsync(reservationOptions);

            if (TestEnvironment.Mode == RecordedTestMode.Playback)
                await reservationOperation.WaitForCompletionAsync(TimeSpan.Zero, default).ConfigureAwait(false);
            else
                await reservationOperation.WaitForCompletionAsync().ConfigureAwait(false);

            // Act
            var reservationsPagable = client.GetAllReservationsAsync();
            var reservations = await reservationsPagable.ToEnumerableAsync();

            Assert.IsNotEmpty(reservations);

            await client.CancelReservationAsync(reservationOperation.Id);
        }

        [Test]
        [TestCase(null, null)]
        [TestCase("en-US", null)]
        [TestCase("en-US", false)]
        [TestCase("en-US", true)]
        public async Task GetPlanGroups(string? locale, bool? includeRateInformation)
        {
            var client = CreateClient();
            const string countryCode = "US";

            var pageablePhonePlanGroups = client.GetPhonePlanGroupsAsync(countryCode, locale, includeRateInformation);

            var phonePlanGroups = await pageablePhonePlanGroups.ToEnumerableAsync();

            Assert.IsNotNull(phonePlanGroups);
            Assert.IsNotEmpty(phonePlanGroups);

            var firstGroup = phonePlanGroups.First(group => group.PhoneNumberType == PhoneNumberType.Geographic);

            Assert.IsNotNull(firstGroup.LocalizedName);
            Assert.IsNotNull(firstGroup.LocalizedDescription);

            if (includeRateInformation == true)
            {
                Assert.IsNotNull(firstGroup.RateInformation);
            }
            else
            {
                Assert.IsNull(firstGroup.RateInformation);
            }
        }

        [Test]
        [TestCase(null)]
        [TestCase("en-US")]
        public async Task GetPhonePlans(string? locale)
        {
            var client = CreateClient();
            const string countryCode = "US";

            var pageablePhonePlanGroups = client.GetPhonePlanGroupsAsync(countryCode, locale);
            var phonePlanGroups = await pageablePhonePlanGroups.ToEnumerableAsync().ConfigureAwait(false);

            var pageablePhonePlans = client.GetPhonePlansAsync(countryCode, phonePlanGroups.First().PhonePlanGroupId, locale);
            var phonePlans = await pageablePhonePlans.ToEnumerableAsync();

            Assert.IsNotNull(phonePlans);
            Assert.IsNotEmpty(phonePlans);
        }

        [Test]
        [TestCase(null)]
        [TestCase("en-US")]
        public async Task GetAreaCodesForPlan(string? locale)
        {
            var client = CreateClient();
            const string countryCode = "US";

            var pageablePhonePlanGroups = client.GetPhonePlanGroupsAsync(countryCode, locale);
            var phonePlanGroups = await pageablePhonePlanGroups.ToEnumerableAsync().ConfigureAwait(false);

            string phonePlanGroupId = phonePlanGroups.First(group => group.PhoneNumberType == PhoneNumberType.Geographic).PhonePlanGroupId;
            var pageablePhonePlans = client.GetPhonePlansAsync(countryCode, phonePlanGroupId, locale);
            var phonePlans = await pageablePhonePlans.ToEnumerableAsync();
            var phonePlanId = phonePlans.First().PhonePlanId;

            var locationOptionsResponse = await client.GetPhonePlanLocationOptionsAsync(countryCode, phonePlanGroupId, phonePlanId).ConfigureAwait(false);

            var locationOptions = new List<LocationOptionsQuery>
            {
                new LocationOptionsQuery
                {
                    LabelId = "state",
                    OptionsValue = "NY"
                },
                new LocationOptionsQuery
                {
                    LabelId = "city",
                    OptionsValue = "NOAM-US-NY-NY"
                }
            };

            var areaCodes = await client.GetAllAreaCodesAsync("selection", countryCode, phonePlanId, locationOptions);

            Assert.IsNotNull(areaCodes.Value.PrimaryAreaCodes);
            Assert.IsNotEmpty(areaCodes.Value.PrimaryAreaCodes);
        }

        [Test]
        [TestCase(null)]
        [TestCase("en-US")]
        public async Task CreateReservationErrorState(string? locale)
        {
            var client = CreateClient();
            const string countryCode = "US";

            var pageablePhonePlanGroups = client.GetPhonePlanGroupsAsync(countryCode, locale);
            var phonePlanGroups = await pageablePhonePlanGroups.ToEnumerableAsync().ConfigureAwait(false);

            string phonePlanGroupId = phonePlanGroups.First(group => group.PhoneNumberType == PhoneNumberType.TollFree).PhonePlanGroupId;
            var pageablePhonePlans = client.GetPhonePlansAsync(countryCode, phonePlanGroupId, locale);
            var phonePlan = (await pageablePhonePlans.ToEnumerableAsync()).First();
            var tollFreeAreaCode = phonePlan.AreaCodes.First();

            string geographicPhonePlanGroupId = phonePlanGroups.First(group => group.PhoneNumberType == PhoneNumberType.Geographic).PhonePlanGroupId;
            var geographicPhonePlanId = (await client.GetPhonePlansAsync(countryCode, geographicPhonePlanGroupId, locale).ToEnumerableAsync()).First().PhonePlanId;

            var reservationOptions = new CreateReservationOptions("My reservation", "my description", new[] { geographicPhonePlanId }, tollFreeAreaCode);
            reservationOptions.Quantity = 1;
            var reservationOperation = await client.StartReservationAsync(reservationOptions);

            try
            {
                if (TestEnvironment.Mode == RecordedTestMode.Playback)
                    await reservationOperation.WaitForCompletionAsync(TimeSpan.Zero, default).ConfigureAwait(false);
                else
                    await reservationOperation.WaitForCompletionAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Reservation has failed.", ex.Message);
                return;
            }

            Assert.Fail("WaitForCompletionAsync should have thrown an exception.");
        }

        [Test]
        [TestCase(null)]
        [TestCase("en-US")]
        public async Task CreateReservation(string? locale)
        {
            var client = CreateClient();
            const string countryCode = "US";

            var pageablePhonePlanGroups = client.GetPhonePlanGroupsAsync(countryCode, locale);
            var phonePlanGroups = await pageablePhonePlanGroups.ToEnumerableAsync().ConfigureAwait(false);

            string phonePlanGroupId = phonePlanGroups.First(group => group.PhoneNumberType == PhoneNumberType.TollFree).PhonePlanGroupId;
            var pageablePhonePlans = client.GetPhonePlansAsync(countryCode, phonePlanGroupId, locale);
            var phonePlan = (await pageablePhonePlans.ToEnumerableAsync()).First();
            var areaCode = phonePlan.AreaCodes.First();

            var reservationOptions = new CreateReservationOptions("My reservation", "my description", new[] { phonePlan.PhonePlanId }, areaCode);
            reservationOptions.Quantity = 1;
            var reservationOperation = await client.StartReservationAsync(reservationOptions);

            if (TestEnvironment.Mode == RecordedTestMode.Playback)
                await reservationOperation.WaitForCompletionAsync(TimeSpan.Zero, default).ConfigureAwait(false);
            else
                await reservationOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.IsNotNull(reservationOperation);
            Assert.IsTrue(reservationOperation.HasCompleted);
            Assert.IsTrue(reservationOperation.HasValue);

            var reservation = reservationOperation.Value;
            Assert.IsNotNull(reservation);

            Assert.AreEqual(ReservationStatus.Reserved, reservation.Status);
            Assert.AreEqual(areaCode, reservation.AreaCode);
            Assert.IsNull(reservation.ErrorCode);
            Assert.AreEqual(1, reservation.PhoneNumbers?.Count);

            await client.CancelReservationAsync(reservationOperation.Id);
        }

        [Test]
        [TestCase(null)]
        [TestCase("en-US")]
        public async Task CreateGeographicalReservation(string? locale)
        {
            var client = CreateClient();
            const string countryCode = "US";

            var pageablePhonePlanGroups = client.GetPhonePlanGroupsAsync(countryCode, locale);
            var phonePlanGroups = await pageablePhonePlanGroups.ToEnumerableAsync().ConfigureAwait(false);

            var phonePlanGroup = phonePlanGroups.First(group => group.PhoneNumberType == PhoneNumberType.Geographic);
            var pageablePhonePlans = client.GetPhonePlansAsync(countryCode, phonePlanGroup.PhonePlanGroupId, locale);
            var phonePlan = (await pageablePhonePlans.ToEnumerableAsync()).First();

            var locationOptionsResponse = await client.GetPhonePlanLocationOptionsAsync(countryCode, phonePlanGroup.PhonePlanGroupId, phonePlan.PhonePlanId);
            var state = locationOptionsResponse.Value.LocationOptions.Options.First();

            var locationOptionsQueries = new List<LocationOptionsQuery>
            {
                new LocationOptionsQuery
                {
                    LabelId = "state",
                    OptionsValue = state.Value
                },
                new LocationOptionsQuery
                {
                    LabelId = "city",
                    OptionsValue = state.LocationOptions.First().Options.First().Value
                }
            };

            var areaCodes = await client.GetAllAreaCodesAsync(phonePlan.LocationType.ToString(), countryCode, phonePlan.PhonePlanId, locationOptionsQueries);
            var areaCode = areaCodes.Value.PrimaryAreaCodes.First();

            var reservationOptions = new CreateReservationOptions("My reservation", "my description", new[] { phonePlan.PhonePlanId }, areaCode);
            reservationOptions.Quantity = 1;
            var reservationOperation = await client.StartReservationAsync(reservationOptions);

            if (TestEnvironment.Mode == RecordedTestMode.Playback)
                await reservationOperation.WaitForCompletionAsync(TimeSpan.Zero, default).ConfigureAwait(false);
            else
                await reservationOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.IsNotNull(reservationOperation);
            Assert.IsTrue(reservationOperation.HasCompleted);
            Assert.IsTrue(reservationOperation.HasValue);

            var reservation = reservationOperation.Value;
            Assert.IsNotNull(reservation);

            Assert.AreEqual(ReservationStatus.Reserved, reservation.Status);
            Assert.AreEqual(areaCode, reservation.AreaCode);
            Assert.IsNull(reservation.ErrorCode);
            Assert.AreEqual(1, reservation.PhoneNumbers?.Count);

            await client.CancelReservationAsync(reservationOperation.Id);
        }
    }
}
