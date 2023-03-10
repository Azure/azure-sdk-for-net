// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.PhoneNumbers.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="PhoneNumbersClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class PhoneNumbersClientLiveTests : PhoneNumbersClientLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumbersClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public PhoneNumbersClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "GetPurchasedPhoneNumbersUsingConnectionString")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GetPurchasedPhoneNumbersUsingTokenCredential")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GetPurchasedPhoneNumbersUsingKeyCredential")]
        public async Task GetPurchasedPhoneNumbers(AuthMethod authMethod)
        {
            var client = CreateClient(authMethod);

            var numbersPagable = client.GetPurchasedPhoneNumbersAsync();
            var numbers = await numbersPagable.ToEnumerableAsync();

            Assert.IsNotNull(numbers);
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "GetPhoneNumberUsingConnectionString")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GetPhoneNumberUsingTokenCredential")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GetPhoneNumberUsingKeyCredential")]
        public async Task GetPhoneNumber(AuthMethod authMethod)
        {
            var number = GetTestPhoneNumber();

            var client = CreateClient(authMethod);
            var phoneNumber = await client.GetPurchasedPhoneNumberAsync(number);

            Assert.IsNotNull(phoneNumber);
            Assert.IsNotNull(phoneNumber.Value);
            Assert.AreEqual(number, phoneNumber.Value.PhoneNumber);
        }

        [Test]
        public async Task GetPhoneNumberWithNullNumber()
        {
            var client = CreateClient();

            try
            {
                var phoneNumber = await client.GetPurchasedPhoneNumberAsync(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("phoneNumber", ex.ParamName);
                return;
            }

            Assert.Fail("GetPurchasedPhoneNumberAsync should have thrown an ArgumentNullException.");
        }

        [Test]
        public async Task StartUpdateCapabilitiesWithNullNumber()
        {
            var client = CreateClient();

            try
            {
                var phoneNumber = await client.StartUpdateCapabilitiesAsync(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("phoneNumber", ex.ParamName);
                return;
            }

            Assert.Fail("GetPurchasedPhoneNumberAsync should have thrown an ArgumentNullException.");
        }

        [Test]
        public async Task CreateSearchErrorState()
        {
            var client = CreateClient();
            const string countryCode = "US";
            try
            {
                // User and toll free is an invalid combination
                var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(countryCode, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Person,
                    new PhoneNumberCapabilities(PhoneNumberCapabilityType.Outbound, PhoneNumberCapabilityType.None), new PhoneNumberSearchOptions { AreaCode = "212", Quantity = 1 });
            }
            catch (Azure.RequestFailedException ex)
            {
                Assert.AreEqual(400, ex.Status);
                return;
            }

            Assert.Fail("StartSearchAvailablePhoneNumbersAsync should have thrown an exception.");
        }

        [Test]
        public async Task CreateSearchWithNullCountryCode()
        {
            var client = CreateClient();
            try
            {
                var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(null, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application,
                    new PhoneNumberCapabilities(PhoneNumberCapabilityType.Outbound, PhoneNumberCapabilityType.None));
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("twoLetterIsoCountryName", ex.ParamName);
                return;
            }

            Assert.Fail("StartSearchAvailablePhoneNumbersAsync should have thrown an exception.");
        }

        [Test]
        [AsyncOnly]
        public async Task CreateSearchAsync()
        {
            if (TestEnvironment.ShouldIgnorePhoneNumbersTests)
            {
                Assert.Ignore("Skip phone number live tests flag is on.");
            }
            var client = CreateClient();
            var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync("US", PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application,
                new PhoneNumberCapabilities(PhoneNumberCapabilityType.Outbound, PhoneNumberCapabilityType.None));

            await searchOperation.WaitForCompletionAsync();

            Assert.IsTrue(searchOperation.HasCompleted);
            Assert.AreEqual(1, searchOperation.Value.PhoneNumbers.Count);
            Assert.AreEqual(PhoneNumberAssignmentType.Application, searchOperation.Value.AssignmentType);
            Assert.AreEqual(PhoneNumberCapabilityType.Outbound, searchOperation.Value.Capabilities.Calling);
            Assert.AreEqual(PhoneNumberCapabilityType.None, searchOperation.Value.Capabilities.Sms);
            Assert.AreEqual(PhoneNumberType.TollFree, searchOperation.Value.PhoneNumberType);
        }

        [Test]
        [SyncOnly]
        public void CreateSearch()
        {
            if (TestEnvironment.ShouldIgnorePhoneNumbersTests)
            {
                Assert.Ignore("Skip phone number live tests flag is on.");
            }
            var client = CreateClient();
            var searchOperation = client.StartSearchAvailablePhoneNumbers("US", PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application,
                new PhoneNumberCapabilities(PhoneNumberCapabilityType.Outbound, PhoneNumberCapabilityType.None));

            while (!searchOperation.HasCompleted)
            {
                SleepIfNotInPlaybackMode();
                searchOperation.UpdateStatus();
            }

            Assert.IsTrue(searchOperation.HasCompleted);
            Assert.AreEqual(1, searchOperation.Value.PhoneNumbers.Count);
            Assert.AreEqual(PhoneNumberAssignmentType.Application, searchOperation.Value.AssignmentType);
            Assert.AreEqual(PhoneNumberCapabilityType.Outbound, searchOperation.Value.Capabilities.Calling);
            Assert.AreEqual(PhoneNumberCapabilityType.None, searchOperation.Value.Capabilities.Sms);
            Assert.AreEqual(PhoneNumberType.TollFree, searchOperation.Value.PhoneNumberType);
        }

        [Test]
        [AsyncOnly]
        public async Task UpdateCapabilitiesAsync()
        {
            if (TestEnvironment.ShouldIgnorePhoneNumbersTests || SkipUpdateCapabilitiesLiveTest)
            {
                Assert.Ignore("Skip phone number live tests flag is on.");
            }
            var number = GetTestPhoneNumber();

            var client = CreateClient();
            var phoneNumber = await client.GetPurchasedPhoneNumberAsync(number);
            PhoneNumberCapabilityType callingCapabilityType = phoneNumber.Value.Capabilities.Calling == PhoneNumberCapabilityType.Inbound ? PhoneNumberCapabilityType.Outbound : PhoneNumberCapabilityType.Inbound;
            PhoneNumberCapabilityType smsCapabilityType = phoneNumber.Value.Capabilities.Sms == PhoneNumberCapabilityType.InboundOutbound ? PhoneNumberCapabilityType.Outbound : PhoneNumberCapabilityType.InboundOutbound;

            var updateOperation = await client.StartUpdateCapabilitiesAsync(number, callingCapabilityType, smsCapabilityType);
            await updateOperation.WaitForCompletionAsync();

            Assert.IsTrue(updateOperation.HasCompleted);
            Assert.IsNotNull(updateOperation.Value);
            Assert.AreEqual(number, updateOperation.Value.PhoneNumber);
            Assert.AreEqual(200, updateOperation.GetRawResponse().Status);
        }

        [Test]
        public async Task ReleaseUnauthorizedNumber()
        {
            var client = CreateClient();
            try
            {
                var releaseOperation = await client.StartReleasePhoneNumberAsync(UnauthorizedNumber);
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
            }
        }

        [Test]
        public async Task UpdateCapabilitiesUnauthorizedNumber()
        {
            var capabilities = new PhoneNumberCapabilities(calling: PhoneNumberCapabilityType.None, sms: PhoneNumberCapabilityType.Outbound);
            var client = CreateClient();
            try
            {
                var UpdateCapabilitiesOperation = await client.StartUpdateCapabilitiesAsync(UnauthorizedNumber);
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
            }
        }

        [Test]
        public async Task GetPurchasedUnauthorizedNumber()
        {
            var client = CreateClient();
            try
            {
                var phoneNumbers = await client.GetPurchasedPhoneNumberAsync(UnauthorizedNumber);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex.Message);
            }
        }

        [Test]
        public async Task GetPurchasedPhoneNumbersNextPage()
        {
            if (SkipPhoneNumberLiveTests)
                Assert.Ignore("Skip phone number live tests flag is on.");

            var client = CreateClient();
            var purchasedPhoneNumbers = client.GetPurchasedPhoneNumbersAsync();

            await foreach (PurchasedPhoneNumber purchasedPhone in purchasedPhoneNumbers)
            {
                Console.WriteLine("phone " + purchasedPhone.PhoneNumber);
            }

            Assert.NotNull(purchasedPhoneNumbers);
        }

        [Test]
        [SyncOnly]
        public void UpdateCapabilities()
        {
            if (TestEnvironment.ShouldIgnorePhoneNumbersTests || SkipUpdateCapabilitiesLiveTest)
            {
                Assert.Ignore("Skip phone number live tests flag is on.");
            }
            var number = GetTestPhoneNumber();

            var client = CreateClient();
            var phoneNumber = client.GetPurchasedPhoneNumber(number);
            PhoneNumberCapabilityType callingCapabilityType = phoneNumber.Value.Capabilities.Calling == PhoneNumberCapabilityType.Inbound ? PhoneNumberCapabilityType.Outbound : PhoneNumberCapabilityType.Inbound;
            PhoneNumberCapabilityType smsCapabilityType = phoneNumber.Value.Capabilities.Sms == PhoneNumberCapabilityType.InboundOutbound ? PhoneNumberCapabilityType.Outbound : PhoneNumberCapabilityType.InboundOutbound;

            var updateOperation = client.StartUpdateCapabilities(number, callingCapabilityType, smsCapabilityType);

            while (!updateOperation.HasCompleted)
            {
                SleepIfNotInPlaybackMode();
                updateOperation.UpdateStatus();
            }

            Assert.IsTrue(updateOperation.HasCompleted);
            Assert.IsNotNull(updateOperation.Value);
            Assert.AreEqual(number, updateOperation.Value.PhoneNumber);
            Assert.AreEqual(200, updateOperation.GetRawResponse().Status);
        }

        [Test]
        public async Task GetTollFreeAreaCodes()
        {
            if (SkipPhoneNumberLiveTests)
                Assert.Ignore("Skip phone number live tests flag is on.");

            string[] expectedAreaCodes = { "888", "877", "866", "855", "844", "800", "833", "88" };
            var client = CreateClient();

            var areaCodes = client.GetAvailableAreaCodesTollFreeAsync("US");
            await foreach (PhoneNumberAreaCode areaCode in areaCodes)
            {
                Assert.Contains(areaCode.AreaCode, expectedAreaCodes);
            }
            Assert.IsNotNull(areaCodes);
        }

        [Test]
        public async Task GetGeographicAreaCodes()
        {
            if (SkipPhoneNumberLiveTests)
                Assert.Ignore("Skip phone number live tests flag is on.");

            var client = CreateClient();
            var availableLocalities = client.GetAvailableLocalitiesAsync("US");
            await foreach (PhoneNumberLocality firstLocality in availableLocalities)
            {
                var areaCodes = client.GetAvailableAreaCodesGeographicAsync("US", "person", firstLocality.LocalizedName, firstLocality.AdministrativeDivision.AbbreviatedName);
                await foreach (PhoneNumberAreaCode areaCode in areaCodes)
                {
                    Console.WriteLine("Area Code " + areaCode.AreaCode);
                }
                Assert.IsNotNull(areaCodes);
                break;
            }
        }

        [Test]
        public async Task GetCountries()
        {
            if (SkipPhoneNumberLiveTests)
                Assert.Ignore("Skip phone number live tests flag is on.");

            List<string> countriesResponse = new List<string>();
            string[] expectedCountries = { "US", "CA" };
            var client = CreateClient();

            var countries = client.GetAvailableCountriesAsync();
            await foreach (PhoneNumberCountry country in countries)
            {
                countriesResponse.Add(country.CountryCode);
            }

            foreach (string country in expectedCountries)
            {
                Assert.Contains(country, countriesResponse);
            }
            Assert.IsNotNull(countries);
        }

        [Test]
        public async Task GetLocalities()
        {
            if (SkipPhoneNumberLiveTests)
                Assert.Ignore("Skip phone number live tests flag is on.");

            var client = CreateClient();

            var localities = client.GetAvailableLocalitiesAsync("US");
            await foreach (PhoneNumberLocality locality in localities)
            {
                Console.WriteLine("Locality " + locality.LocalizedName);
            }
            Assert.IsNotNull(localities);
        }

        [Test]
        public async Task GetLocalitiesWithAdministrativeDivision()
        {
            if (SkipPhoneNumberLiveTests)
                Assert.Ignore("Skip phone number live tests flag is on.");

            var client = CreateClient();
            var availableLocalities = client.GetAvailableLocalitiesAsync("US");
            await foreach (PhoneNumberLocality firstLocality in availableLocalities)
            {
                var localities = client.GetAvailableLocalitiesAsync("US", firstLocality.AdministrativeDivision.AbbreviatedName);
                await foreach (PhoneNumberLocality locality in localities)
                {
                    Console.WriteLine("Locality " + locality.LocalizedName);
                    Assert.AreEqual(locality.AdministrativeDivision.AbbreviatedName, firstLocality.AdministrativeDivision.AbbreviatedName);
                }
                Assert.IsNotNull(localities);
                break;
            }
        }

        [Test]
        public async Task GetOfferings()
        {
            if (SkipPhoneNumberLiveTests)
                Assert.Ignore("Skip phone number live tests flag is on.");

            var client = CreateClient();

            var offerings = client.GetAvailableOfferingsAsync("US");
            await foreach (PhoneNumberOffering offering in offerings)
            {
                Console.WriteLine("Offering " + offering.ToString());
            }
            Assert.IsNotNull(offerings);
        }
    }
}
