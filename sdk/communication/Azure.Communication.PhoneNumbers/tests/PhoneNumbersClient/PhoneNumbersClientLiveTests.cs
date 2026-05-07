// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
        [AsyncOnly]
        public async Task GetPurchasedPhoneNumbersAsync(AuthMethod authMethod)
        {
            var client = CreateClient(authMethod);

            var numbersPagable = client.GetPurchasedPhoneNumbersAsync();
            var numbers = await numbersPagable.ToEnumerableAsync();

            Assert.That(numbers, Is.Not.Null);
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "GetPurchasedPhoneNumbersUsingConnectionString")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GetPurchasedPhoneNumbersUsingTokenCredential")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GetPurchasedPhoneNumbersUsingKeyCredential")]
        [SyncOnly]
        public void GetPurchasedPhoneNumbers(AuthMethod authMethod)
        {
            var client = CreateClient(authMethod);

            var numbersPagable = client.GetPurchasedPhoneNumbers();
            var numbers = numbersPagable.AsPages().ToList();

            Assert.That(numbers, Is.Not.Null);
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "GetPhoneNumberUsingConnectionString")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GetPhoneNumberUsingTokenCredential")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GetPhoneNumberUsingKeyCredential")]
        [AsyncOnly]
        public async Task GetPhoneNumberAsync(AuthMethod authMethod)
        {
            var number = GetTestPhoneNumber();

            var client = CreateClient(authMethod);
            var phoneNumber = await client.GetPurchasedPhoneNumberAsync(number);

            Assert.That(phoneNumber, Is.Not.Null);
            Assert.That(phoneNumber.Value, Is.Not.Null);
            Assert.That(phoneNumber.Value.PhoneNumber, Is.EqualTo(number));
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "GetPhoneNumberUsingConnectionString")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GetPhoneNumberUsingTokenCredential")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GetPhoneNumberUsingKeyCredential")]
        [SyncOnly]
        public void GetPhoneNumber(AuthMethod authMethod)
        {
            var number = GetTestPhoneNumber();

            var client = CreateClient(authMethod);
            var phoneNumber = client.GetPurchasedPhoneNumber(number);

            Assert.That(phoneNumber, Is.Not.Null);
            Assert.That(phoneNumber.Value, Is.Not.Null);
            Assert.That(phoneNumber.Value.PhoneNumber, Is.EqualTo(number));
        }

        [Test]
        [AsyncOnly]
        public async Task GetPhoneNumberWithNullNumberAsync()
        {
            var client = CreateClient();

            try
            {
                var phoneNumber = await client.GetPurchasedPhoneNumberAsync(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.That(ex.ParamName, Is.EqualTo("phoneNumber"));
                return;
            }

            Assert.Fail("GetPurchasedPhoneNumberAsync should have thrown an ArgumentNullException.");
        }

        [Test]
        [SyncOnly]
        public void GetPhoneNumberWithNullNumber()
        {
            var client = CreateClient();

            try
            {
                var phoneNumber = client.GetPurchasedPhoneNumber(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.That(ex.ParamName, Is.EqualTo("phoneNumber"));
                return;
            }

            Assert.Fail("GetPurchasedPhoneNumberAsync should have thrown an ArgumentNullException.");
        }

        [Test]
        [AsyncOnly]
        public async Task StartUpdateCapabilitiesWithNullNumberAsync()
        {
            var client = CreateClient();

            try
            {
                var phoneNumber = await client.StartUpdateCapabilitiesAsync(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.That(ex.ParamName, Is.EqualTo("phoneNumber"));
                return;
            }

            Assert.Fail("GetPurchasedPhoneNumberAsync should have thrown an ArgumentNullException.");
        }

        [Test]
        [SyncOnly]
        public void StartUpdateCapabilitiesWithNullNumber()
        {
            var client = CreateClient();

            try
            {
                var phoneNumber = client.StartUpdateCapabilities(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.That(ex.ParamName, Is.EqualTo("phoneNumber"));
                return;
            }

            Assert.Fail("GetPurchasedPhoneNumberAsync should have thrown an ArgumentNullException.");
        }

        [Test]
        [AsyncOnly]
        public async Task CreateSearchErrorStateAsync()
        {
            var client = CreateClient();
            const string countryCode = "US";
            try
            {
                // User and toll free is an invalid combination
                var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(countryCode, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Person,
                    new PhoneNumberCapabilities(PhoneNumberCapabilityType.Outbound, PhoneNumberCapabilityType.None), new PhoneNumberSearchOptions { AreaCode = "212", Quantity = 1 });
            }
            catch (RequestFailedException ex)
            {
                Assert.That(IsClientError(ex.Status), Is.True, $"Status code {ex.Status} does not indicate a client error.");
                return;
            }

            Assert.Fail("StartSearchAvailablePhoneNumbersAsync should have thrown an exception.");
        }

        [Test]
        [SyncOnly]
        public void CreateSearchErrorState()
        {
            var client = CreateClient();
            const string countryCode = "US";
            try
            {
                // User and toll free is an invalid combination
                var searchOperation = client.StartSearchAvailablePhoneNumbers(countryCode, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Person,
                    new PhoneNumberCapabilities(PhoneNumberCapabilityType.Outbound, PhoneNumberCapabilityType.None), new PhoneNumberSearchOptions { AreaCode = "212", Quantity = 1 });
            }
            catch (RequestFailedException ex)
            {
                Assert.That(IsClientError(ex.Status), Is.True, $"Status code {ex.Status} does not indicate a client error.");
                return;
            }

            Assert.Fail("StartSearchAvailablePhoneNumbersAsync should have thrown an exception.");
        }

        [Test]
        [AsyncOnly]
        public async Task CreateSearchWithNullCountryCodeAsync()
        {
            var client = CreateClient();
            try
            {
                var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(null, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application,
                    new PhoneNumberCapabilities(PhoneNumberCapabilityType.Outbound, PhoneNumberCapabilityType.None));
            }
            catch (ArgumentNullException ex)
            {
                Assert.That(ex.ParamName, Is.EqualTo("twoLetterIsoCountryName"));
                return;
            }

            Assert.Fail("StartSearchAvailablePhoneNumbersAsync should have thrown an exception.");
        }

        [Test]
        [SyncOnly]
        public void CreateSearchWithNullCountryCode()
        {
            var client = CreateClient();
            try
            {
                var searchOperation = client.StartSearchAvailablePhoneNumbers(null, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application,
                    new PhoneNumberCapabilities(PhoneNumberCapabilityType.Outbound, PhoneNumberCapabilityType.None));
            }
            catch (ArgumentNullException ex)
            {
                Assert.That(ex.ParamName, Is.EqualTo("twoLetterIsoCountryName"));
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

            Assert.That(searchOperation.HasCompleted, Is.True);
            Assert.That(searchOperation.Value.PhoneNumbers.Count, Is.EqualTo(1));
            Assert.That(searchOperation.Value.AssignmentType, Is.EqualTo(PhoneNumberAssignmentType.Application));
            Assert.That(searchOperation.Value.Capabilities.Calling, Is.EqualTo(PhoneNumberCapabilityType.Outbound));
            Assert.That(searchOperation.Value.Capabilities.Sms, Is.EqualTo(PhoneNumberCapabilityType.None));
            Assert.That(searchOperation.Value.PhoneNumberType, Is.EqualTo(PhoneNumberType.TollFree));

            var searchId = searchOperation.Value.SearchId;

            var response = await client.GetPhoneNumberSearchResultAsync(searchId);

            Assert.That(response.Value.PhoneNumbers.Count, Is.EqualTo(1));
            Assert.That(response.Value.AssignmentType, Is.EqualTo(PhoneNumberAssignmentType.Application));
            Assert.That(response.Value.Capabilities.Calling, Is.EqualTo(PhoneNumberCapabilityType.Outbound));
            Assert.That(response.Value.Capabilities.Sms, Is.EqualTo(PhoneNumberCapabilityType.None));
            Assert.That(response.Value.PhoneNumberType, Is.EqualTo(PhoneNumberType.TollFree));
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

            Assert.That(searchOperation.HasCompleted, Is.True);
            Assert.That(searchOperation.Value.PhoneNumbers.Count, Is.EqualTo(1));
            Assert.That(searchOperation.Value.AssignmentType, Is.EqualTo(PhoneNumberAssignmentType.Application));
            Assert.That(searchOperation.Value.Capabilities.Calling, Is.EqualTo(PhoneNumberCapabilityType.Outbound));
            Assert.That(searchOperation.Value.Capabilities.Sms, Is.EqualTo(PhoneNumberCapabilityType.None));
            Assert.That(searchOperation.Value.PhoneNumberType, Is.EqualTo(PhoneNumberType.TollFree));

            var searchId = searchOperation.Value.SearchId;

            var response = client.GetPhoneNumberSearchResult(searchId);

            Assert.That(response.Value.PhoneNumbers.Count, Is.EqualTo(1));
            Assert.That(response.Value.AssignmentType, Is.EqualTo(PhoneNumberAssignmentType.Application));
            Assert.That(response.Value.Capabilities.Calling, Is.EqualTo(PhoneNumberCapabilityType.Outbound));
            Assert.That(response.Value.Capabilities.Sms, Is.EqualTo(PhoneNumberCapabilityType.None));
            Assert.That(response.Value.PhoneNumberType, Is.EqualTo(PhoneNumberType.TollFree));
        }

        [Test]
        [AsyncOnly]
        public async Task GetPhoneNumberSearchResultWithNullSearchIdAsync()
        {
            var client = CreateClient();
            try
            {
                var searchResult = await client.GetPhoneNumberSearchResultAsync(null);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.Not.Null);
            }
        }

        [Test]
        [SyncOnly]
        public void GetPhoneNumberSearchResultWithNullSearchId()
        {
            var client = CreateClient();
            try
            {
                var searchResult = client.GetPhoneNumberSearchResult(null);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.Not.Null);
            }
        }

        [Test]
        [AsyncOnly]
        public async Task GetPhoneNumberSearchResultWithUnknownSearchIdAsync()
        {
            var client = CreateClient();
            try
            {
                var searchResult = await client.GetPhoneNumberSearchResultAsync(UnknownPhoneNumberSearchResultId);
            }
            catch (RequestFailedException ex)
            {
                Assert.That(IsClientError(ex.Status), Is.True, $"Status code {ex.Status} does not indicate a client error.");
                Assert.That(ex.Message, Is.Not.Null);
            }
        }

        [Test]
        [SyncOnly]
        public void GetPhoneNumberSearchResultWithUnknownSearchId()
        {
            var client = CreateClient();
            try
            {
                var searchResult = client.GetPhoneNumberSearchResult(UnknownPhoneNumberSearchResultId);
            }
            catch (RequestFailedException ex)
            {
                Assert.That(IsClientError(ex.Status), Is.True, $"Status code {ex.Status} does not indicate a client error.");
                Assert.That(ex.Message, Is.Not.Null);
            }
        }

        [Test]
        [AsyncOnly]
        public async Task ReleaseUnauthorizedNumberAsync()
        {
            var client = CreateClient();
            try
            {
                var releaseOperation = await client.StartReleasePhoneNumberAsync(UnauthorizedNumber);
            }
            catch (RequestFailedException ex)
            {
                Assert.That(IsClientError(ex.Status), Is.True, $"Status code {ex.Status} does not indicate a client error.");
                Assert.That(ex.Message, Is.Not.Null);
            }
        }

        [Test]
        [SyncOnly]
        public void ReleaseUnauthorizedNumber()
        {
            var client = CreateClient();
            try
            {
                var releaseOperation = client.StartReleasePhoneNumber(UnauthorizedNumber);
            }
            catch (RequestFailedException ex)
            {
                Assert.That(IsClientError(ex.Status), Is.True, $"Status code {ex.Status} does not indicate a client error.");
                Assert.That(ex.Message, Is.Not.Null);
            }
        }

        [Test]
        [AsyncOnly]
        public async Task ReleaseNullNumberAsync()
        {
            var client = CreateClient();
            try
            {
                var releaseOperation = await client.StartReleasePhoneNumberAsync(null);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.Not.Null);
            }
        }

        [Test]
        [SyncOnly]
        public void ReleaseNullNumber()
        {
            var client = CreateClient();
            try
            {
                var releaseOperation = client.StartReleasePhoneNumber(null);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.Not.Null);
            }
        }

        [Test]
        [AsyncOnly]
        public async Task GetPurchasedUnauthorizedNumberAsync()
        {
            var client = CreateClient();
            try
            {
                var phoneNumbers = await client.GetPurchasedPhoneNumberAsync(UnauthorizedNumber);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.Not.Null);
            }
        }

        [Test]
        [SyncOnly]
        public void GetPurchasedUnauthorizedNumber()
        {
            var client = CreateClient();
            try
            {
                var phoneNumbers = client.GetPurchasedPhoneNumberAsync(UnauthorizedNumber);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.Not.Null);
            }
        }

        [Test]
        [AsyncOnly]
        public async Task StartPurchaseInvalidSearchIdAsync()
        {
            var client = CreateClient();
            try
            {
                var purchaseOperation = await client.StartPurchasePhoneNumbersAsync("some-invalid-id");
            }
            catch (RequestFailedException ex)
            {
                Assert.That(IsClientError(ex.Status), Is.True, $"Status code {ex.Status} does not indicate a client error.");
                Assert.That(ex.Message, Is.Not.Null);
            }
        }

        [Test]
        [SyncOnly]
        public void StartPurchaseInvalidSearchId()
        {
            var client = CreateClient();
            try
            {
                var purchaseOperation = client.StartPurchasePhoneNumbers("some-invalid-id");
            }
            catch (RequestFailedException ex)
            {
                Assert.That(IsClientError(ex.Status), Is.True, $"Status code {ex.Status} does not indicate a client error.");
                Assert.That(ex.Message, Is.Not.Null);
            }
        }

        [Test]
        [AsyncOnly]
        public async Task StartPurchaseWithoutAgreementToNotResellAsync()
        {
            if (TestEnvironment.ShouldIgnorePhoneNumbersTests)
            {
                Assert.Ignore("Skip phone number live tests flag is on.");
            }

            var client = CreateClient();

            // France doesn't allow reselling phone numbers.
            var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync("FR", PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application,
                new PhoneNumberCapabilities(PhoneNumberCapabilityType.Outbound, PhoneNumberCapabilityType.None));

            await searchOperation.WaitForCompletionAsync();

            Assert.That(searchOperation.HasCompleted, Is.True);
            Assert.That(searchOperation.Value.PhoneNumbers.Count, Is.EqualTo(1));
            Assert.That(searchOperation.Value.AssignmentType, Is.EqualTo(PhoneNumberAssignmentType.Application));
            Assert.That(searchOperation.Value.Capabilities.Calling, Is.EqualTo(PhoneNumberCapabilityType.Outbound));
            Assert.That(searchOperation.Value.Capabilities.Sms, Is.EqualTo(PhoneNumberCapabilityType.None));
            Assert.That(searchOperation.Value.PhoneNumberType, Is.EqualTo(PhoneNumberType.TollFree));

            var searchId = searchOperation.Value.SearchId;

            try
            {
                var purchaseOperation = await client.StartPurchasePhoneNumbersAsync(searchId, agreeToNotResell: false);
            }
            catch (RequestFailedException ex)
            {
                Assert.That(IsClientError(ex.Status), Is.True, $"Status code {ex.Status} does not indicate a client error.");
                Assert.That(ex.Message, Is.Not.Null);
            }
        }

        [Test]
        [SyncOnly]
        public void StartPurchaseWithoutAgreementToNotResell()
        {
            if (TestEnvironment.ShouldIgnorePhoneNumbersTests)
            {
                Assert.Ignore("Skip phone number live tests flag is on.");
            }

            var client = CreateClient();

            // France doesn't allow reselling phone numbers.
            var searchOperation = client.StartSearchAvailablePhoneNumbers("FR", PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application,
                new PhoneNumberCapabilities(PhoneNumberCapabilityType.Outbound, PhoneNumberCapabilityType.None));

            while (!searchOperation.HasCompleted)
            {
                SleepIfNotInPlaybackMode();
                searchOperation.UpdateStatus();
            }

            Assert.That(searchOperation.HasCompleted, Is.True);
            Assert.That(searchOperation.Value.PhoneNumbers.Count, Is.EqualTo(1));
            Assert.That(searchOperation.Value.AssignmentType, Is.EqualTo(PhoneNumberAssignmentType.Application));
            Assert.That(searchOperation.Value.Capabilities.Calling, Is.EqualTo(PhoneNumberCapabilityType.Outbound));
            Assert.That(searchOperation.Value.Capabilities.Sms, Is.EqualTo(PhoneNumberCapabilityType.None));
            Assert.That(searchOperation.Value.PhoneNumberType, Is.EqualTo(PhoneNumberType.TollFree));

            var searchId = searchOperation.Value.SearchId;

            try
            {
                var purchaseOperation = client.StartPurchasePhoneNumbers(searchId, agreeToNotResell: false);
            }
            catch (RequestFailedException ex)
            {
                Assert.That(IsClientError(ex.Status), Is.True, $"Status code {ex.Status} does not indicate a client error.");
                Assert.That(ex.Message, Is.Not.Null);
            }
        }

        [Test]
        [AsyncOnly]
        public async Task GetPurchasedPhoneNumbersNextPageAsync()
        {
            var client = CreateClient();
            var purchasedPhoneNumbers = client.GetPurchasedPhoneNumbersAsync();

            await foreach (PurchasedPhoneNumber purchasedPhone in purchasedPhoneNumbers)
            {
                Console.WriteLine("phone " + purchasedPhone.PhoneNumber);
            }

            Assert.That(purchasedPhoneNumbers, Is.Not.Null);
        }

        [Test]
        [SyncOnly]
        public void GetPurchasedPhoneNumbersNextPage()
        {
            var client = CreateClient();
            var purchasedPhoneNumbers = client.GetPurchasedPhoneNumbers();

            foreach (PurchasedPhoneNumber purchasedPhone in purchasedPhoneNumbers)
            {
                Console.WriteLine("phone " + purchasedPhone.PhoneNumber);
            }

            Assert.That(purchasedPhoneNumbers, Is.Not.Null);
        }

        [Test]
        [AsyncOnly]
        public async Task GetPurchasedPhoneNumbersAsPagesAsync()
        {
            var client = CreateClient();
            var phoneNumbers = await client.GetPurchasedPhoneNumbersAsync().ToEnumerableAsync();
            var phoneNumbersCount = phoneNumbers.Count;
            var expectedPageSize = phoneNumbersCount;

            if (phoneNumbersCount >= 2)
            {
                expectedPageSize = phoneNumbersCount / 2;
            }

            var pages = client.GetPurchasedPhoneNumbersAsync().AsPages(pageSizeHint: expectedPageSize);
            var actual = 0;
            await foreach (var page in pages)
            {
                if (expectedPageSize == 0)
                {
                    break;
                }
                // Validate only the size of the first page as it's the only one
                // guaranteed to be of expectedPageSize
                if (actual == 0)
                {
                    Assert.That(page.Values.Count, Is.EqualTo(expectedPageSize));
                }
                foreach (var phoneNumber in page.Values)
                {
                    actual++;
                }
            }

            Assert.That(actual, Is.EqualTo(phoneNumbersCount));
        }

        [Test]
        [SyncOnly]
        public void GetPurchasedPhoneNumbersAsPages()
        {
            var client = CreateClient();
            var phoneNumbers = client.GetPurchasedPhoneNumbers().ToList();
            var phoneNumbersCount = phoneNumbers.Count;
            var expectedPageSize = phoneNumbersCount;

            if (phoneNumbersCount >= 2)
            {
                expectedPageSize = phoneNumbersCount / 2;
            }

            var pages = client.GetPurchasedPhoneNumbers().AsPages(pageSizeHint: expectedPageSize);
            var actual = 0;
            foreach (var page in pages)
            {
                if (expectedPageSize == 0)
                {
                    break;
                }
                // Validate only the size of the first page as it's the only one
                // guaranteed to be of expectedPageSize
                if (actual == 0)
                {
                    Assert.That(page.Values.Count, Is.EqualTo(expectedPageSize));
                }
                foreach (var phoneNumber in page.Values)
                {
                    actual++;
                }
            }

            Assert.That(actual, Is.EqualTo(phoneNumbersCount));
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

            Assert.That(updateOperation.HasCompleted, Is.True);
            Assert.That(updateOperation.Value, Is.Not.Null);
            Assert.That(updateOperation.Value.PhoneNumber, Is.EqualTo(number));
            Assert.That(IsSuccess(updateOperation.GetRawResponse().Status), Is.True, $"Status code {updateOperation.GetRawResponse().Status} does not indicate success");
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

            var updateOperation = InstrumentOperation(client.StartUpdateCapabilities(number, callingCapabilityType, smsCapabilityType));

            while (!updateOperation.HasCompleted)
            {
                SleepIfNotInPlaybackMode();
                updateOperation.UpdateStatus();
            }

            Assert.That(updateOperation.HasCompleted, Is.True);
            Assert.That(updateOperation.Value, Is.Not.Null);
            Assert.That(updateOperation.Value.PhoneNumber, Is.EqualTo(number));
            Assert.That(IsSuccess(updateOperation.GetRawResponse().Status), Is.True, $"Status code {updateOperation.GetRawResponse().Status} does not indicate success");
        }

        [Test]
        [AsyncOnly]
        public async Task UpdateCapabilitiesUnauthorizedNumberAsync()
        {
            var client = CreateClient();
            try
            {
                var UpdateCapabilitiesOperation = await client.StartUpdateCapabilitiesAsync(UnauthorizedNumber);
            }
            catch (RequestFailedException ex)
            {
                Assert.That(IsClientError(ex.Status), Is.True, $"Status code {ex.Status} does not indicate a client error.");
                Assert.That(ex.Message, Is.Not.Null);
            }
        }

        [Test]
        [SyncOnly]
        public void UpdateCapabilitiesUnauthorizedNumber()
        {
            var client = CreateClient();
            try
            {
                var UpdateCapabilitiesOperation = client.StartUpdateCapabilities(UnauthorizedNumber);
            }
            catch (RequestFailedException ex)
            {
                Assert.That(IsClientError(ex.Status), Is.True, $"Status code {ex.Status} does not indicate a client error.");
                Assert.That(ex.Message, Is.Not.Null);
            }
        }

        [Test]
        [AsyncOnly]
        public async Task GetTollFreeAreaCodesAsync()
        {
            string[] expectedAreaCodes = { "888", "877", "866", "855", "844", "800", "833", "88" };
            var client = CreateClient();

            var areaCodes = client.GetAvailableAreaCodesTollFreeAsync("US");
            await foreach (PhoneNumberAreaCode areaCode in areaCodes)
            {
                Assert.That(expectedAreaCodes, Does.Contain(areaCode.AreaCode));
            }
            Assert.That(areaCodes, Is.Not.Null);
        }

        [Test]
        [SyncOnly]
        public void GetTollFreeAreaCodes()
        {
            string[] expectedAreaCodes = { "888", "877", "866", "855", "844", "800", "833", "88" };
            var client = CreateClient();

            var areaCodes = client.GetAvailableAreaCodesTollFree("US");
            foreach (PhoneNumberAreaCode areaCode in areaCodes)
            {
                Assert.That(expectedAreaCodes, Does.Contain(areaCode.AreaCode));
            }
            Assert.That(areaCodes, Is.Not.Null);
        }

        [Test]
        [AsyncOnly]
        public async Task GetTollFreeAreaCodesAsyncAsPages()
        {
            var client = CreateClient();
            var areaCodes = await client.GetAvailableAreaCodesTollFreeAsync("US").ToEnumerableAsync();
            var areaCodesCount = areaCodes.Count;
            var expectedPageSize = areaCodesCount;

            if (areaCodesCount >= 2)
            {
                expectedPageSize = areaCodesCount / 2;
            }
            var pages = client.GetAvailableAreaCodesTollFreeAsync("US").AsPages(pageSizeHint: expectedPageSize);
            var actual = 0;
            await foreach (var page in pages)
            {
                if (page == null || expectedPageSize == 0)
                {
                    break;
                }
                // Validate only the size of the first page as it's the only one
                // guaranteed to be of expectedPageSize
                if (actual == 0)
                {
                    Assert.That(page.Values.Count, Is.EqualTo(expectedPageSize));
                }
                foreach (var phoneNumber in page.Values)
                {
                    actual++;
                }
            }

            Assert.That(actual, Is.EqualTo(areaCodesCount));
        }

        [Test]
        [SyncOnly]
        public void GetTollFreeAreaCodesAsPages()
        {
            var client = CreateClient();
            var areaCodes = client.GetAvailableAreaCodesTollFree("US").ToList();
            var areaCodesCount = areaCodes.Count;

            var expectedPageSize = areaCodesCount;

            if (areaCodesCount >= 2)
            {
                expectedPageSize = areaCodesCount / 2;
            }
            var pages = client.GetAvailableAreaCodesTollFree("US").AsPages(pageSizeHint: expectedPageSize);
            var actual = 0;
            foreach (var page in pages)
            {
                if (page == null || expectedPageSize == 0)
                {
                    break;
                }
                // Validate only the size of the first page as it's the only one
                // guaranteed to be of expectedPageSize
                if (actual == 0)
                {
                    Assert.That(page.Values.Count, Is.EqualTo(expectedPageSize));
                }
                foreach (var phoneNumber in page.Values)
                {
                    actual++;
                }
            }

            Assert.That(actual, Is.EqualTo(areaCodesCount));
        }

        [Test]
        [AsyncOnly]
        public async Task GetGeographicAreaCodesAsync()
        {
            var client = CreateClient();
            var availableLocalities = client.GetAvailableLocalitiesAsync("US");
            await foreach (PhoneNumberLocality firstLocality in availableLocalities)
            {
                var areaCodes = client.GetAvailableAreaCodesGeographicAsync("US", "person", firstLocality.LocalizedName, firstLocality.AdministrativeDivision.AbbreviatedName);
                await foreach (PhoneNumberAreaCode areaCode in areaCodes)
                {
                    Console.WriteLine("Area Code " + areaCode.AreaCode);
                }
                Assert.That(areaCodes, Is.Not.Null);
                break;
            }
        }

        [Test]
        [SyncOnly]
        public void GetGeographicAreaCodes()
        {
            var client = CreateClient();
            var availableLocalities = client.GetAvailableLocalities("US");
            foreach (PhoneNumberLocality firstLocality in availableLocalities)
            {
                var areaCodes = client.GetAvailableAreaCodesGeographic("US", "person", firstLocality.LocalizedName, firstLocality.AdministrativeDivision.AbbreviatedName);
                foreach (PhoneNumberAreaCode areaCode in areaCodes)
                {
                    Console.WriteLine("Area Code " + areaCode.AreaCode);
                }
                Assert.That(areaCodes, Is.Not.Null);
                break;
            }
        }

        [Test]
        [AsyncOnly]
        public async Task GetGeographicAreaCodesAsyncAsPages()
        {
            var client = CreateClient();
            var availableLocalities = await client.GetAvailableLocalitiesAsync("US").ToEnumerableAsync();
            var areaCodes = await client.GetAvailableAreaCodesGeographicAsync("US", "person", availableLocalities.First().LocalizedName, availableLocalities.First().AdministrativeDivision.AbbreviatedName).ToEnumerableAsync();
            var areaCodesCount = areaCodes.Count;
            var expectedPageSize = areaCodesCount;

            if (areaCodesCount >= 2)
            {
                expectedPageSize = areaCodesCount / 2;
            }
            var pages = client.GetAvailableAreaCodesGeographicAsync("US", "person", availableLocalities.First().LocalizedName, availableLocalities.First().AdministrativeDivision.AbbreviatedName).AsPages(pageSizeHint: expectedPageSize);
            var actual = 0;
            await foreach (var page in pages)
            {
                if (page == null || expectedPageSize == 0)
                {
                    break;
                }
                // Validate only the size of the first page as it's the only one
                // guaranteed to be of expectedPageSize
                if (actual == 0)
                {
                    Assert.That(page.Values.Count, Is.EqualTo(expectedPageSize));
                }
                foreach (var phoneNumber in page.Values)
                {
                    actual++;
                }
            }

            Assert.That(actual, Is.EqualTo(areaCodesCount));
        }

        [Test]
        [SyncOnly]
        public void GetGeographicAreaCodesAsPages()
        {
            var client = CreateClient();
            var availableLocalities = client.GetAvailableLocalities("US");
            var areaCodes = client.GetAvailableAreaCodesGeographic("US", "person", availableLocalities.First().LocalizedName, availableLocalities.First().AdministrativeDivision.AbbreviatedName).ToList();
            var areaCodesCount = areaCodes.Count;

            var expectedPageSize = areaCodesCount;

            if (areaCodesCount >= 2)
            {
                expectedPageSize = areaCodesCount / 2;
            }
            var pages = client.GetAvailableAreaCodesGeographic("US", "person", availableLocalities.First().LocalizedName, availableLocalities.First().AdministrativeDivision.AbbreviatedName).AsPages(pageSizeHint: expectedPageSize);
            var actual = 0;
            foreach (var page in pages)
            {
                if (page == null || expectedPageSize == 0)
                {
                    break;
                }
                // Validate only the size of the first page as it's the only one
                // guaranteed to be of expectedPageSize
                if (actual == 0)
                {
                    Assert.That(page.Values.Count, Is.EqualTo(expectedPageSize));
                }
                foreach (var phoneNumber in page.Values)
                {
                    actual++;
                }
            }

            Assert.That(actual, Is.EqualTo(areaCodesCount));
        }

        [Test]
        [AsyncOnly]
        public async Task GetMobileAreaCodesAsync()
        {
            var client = CreateClient();
            var availableLocalities = client.GetAvailableLocalitiesAsync("IE", PhoneNumberType.Mobile);
            await foreach (PhoneNumberLocality firstLocality in availableLocalities)
            {
                var areaCodes = client.GetAvailableAreaCodesMobileAsync("IE", PhoneNumberAssignmentType.Application, firstLocality.LocalizedName);
                await foreach (PhoneNumberAreaCode areaCode in areaCodes)
                {
                    Console.WriteLine("Mobile Area Code " + areaCode.AreaCode);
                }
                Assert.That(areaCodes, Is.Not.Null);
                break;
            }
        }

        [Test]
        [SyncOnly]
        public void GetMobileAreaCodes()
        {
            var client = CreateClient();
            var availableLocalities = client.GetAvailableLocalities("IE", PhoneNumberType.Mobile);
            foreach (PhoneNumberLocality firstLocality in availableLocalities)
            {
                var areaCodes = client.GetAvailableAreaCodesMobile("IE", PhoneNumberAssignmentType.Application, firstLocality.LocalizedName);
                foreach (PhoneNumberAreaCode areaCode in areaCodes)
                {
                    Console.WriteLine("Mobile Area Code " + areaCode.AreaCode);
                }
                Assert.That(areaCodes, Is.Not.Null);
                break;
            }
        }

        [Test]
        [AsyncOnly]
        public async Task GetCountriesAsync()
        {
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
                Assert.That(countriesResponse, Does.Contain(country));
            }
            Assert.That(countries, Is.Not.Null);
        }

        [Test]
        [SyncOnly]
        public void GetCountries()
        {
            List<string> countriesResponse = new List<string>();
            string[] expectedCountries = { "US", "CA" };
            var client = CreateClient();

            var countries = client.GetAvailableCountries();
            foreach (PhoneNumberCountry country in countries)
            {
                countriesResponse.Add(country.CountryCode);
            }

            foreach (string country in expectedCountries)
            {
                Assert.That(countriesResponse, Does.Contain(country));
            }
            Assert.That(countries, Is.Not.Null);
        }

        [Test]
        [AsyncOnly]
        public async Task GetCountriesAsyncAsPages()
        {
            var client = CreateClient();
            var countries = await client.GetAvailableCountriesAsync().ToEnumerableAsync();
            var countriesCount = countries.Count;

            var expectedPageSize = countriesCount;

            if (countriesCount >= 2)
            {
                expectedPageSize = countriesCount / 2;
            }
            var pages = client.GetAvailableCountriesAsync().AsPages(pageSizeHint: expectedPageSize);
            var actual = 0;
            await foreach (var page in pages)
            {
                if (page == null || expectedPageSize == 0)
                {
                    break;
                }
                // Validate only the size of the first page as it's the only one
                // guaranteed to be of expectedPageSize
                if (actual == 0)
                {
                    Assert.That(page.Values.Count, Is.EqualTo(expectedPageSize));
                }
                foreach (var phoneNumber in page.Values)
                {
                    actual++;
                }
            }

            Assert.That(actual, Is.EqualTo(countriesCount));
        }

        [Test]
        [SyncOnly]
        public void GetCountriesAsPages()
        {
            var client = CreateClient();
            var countries = client.GetAvailableCountries().ToList();
            var countriesCount = countries.Count;

            var expectedPageSize = countriesCount;

            if (countriesCount >= 2)
            {
                expectedPageSize = countriesCount / 2;
            }
            var pages = client.GetAvailableCountries().AsPages(pageSizeHint: expectedPageSize);
            var actual = 0;
            foreach (var page in pages)
            {
                if (page == null || expectedPageSize == 0)
                {
                    break;
                }
                // Validate only the size of the first page as it's the only one
                // guaranteed to be of expectedPageSize
                if (actual == 0)
                {
                    Assert.That(page.Values.Count, Is.EqualTo(expectedPageSize));
                }
                foreach (var phoneNumber in page.Values)
                {
                    actual++;
                }
            }

            Assert.That(actual, Is.EqualTo(countriesCount));
        }

        [Test]
        [AsyncOnly]
        public async Task GetLocalitiesAsync()
        {
            var client = CreateClient();

            var localities = client.GetAvailableLocalitiesAsync("US");
            await foreach (PhoneNumberLocality locality in localities)
            {
                Console.WriteLine("Locality " + locality.LocalizedName);
            }
            Assert.That(localities, Is.Not.Null);
        }

        [Test]
        [SyncOnly]
        public void GetLocalities()
        {
            var client = CreateClient();

            var localities = client.GetAvailableLocalities("US");
            foreach (PhoneNumberLocality locality in localities)
            {
                Console.WriteLine("Locality " + locality.LocalizedName);
            }
            Assert.That(localities, Is.Not.Null);
        }

        [Test]
        [AsyncOnly]
        public async Task GetLocalitiesWithPhoneNumberTypeAsync()
        {
            var client = CreateClient();

            var localities = client.GetAvailableLocalitiesAsync("IE", PhoneNumberType.Mobile);
            await foreach (PhoneNumberLocality locality in localities)
            {
                Console.WriteLine("Locality " + locality.LocalizedName);
            }
            Assert.That(localities, Is.Not.Null);
        }

        [Test]
        [SyncOnly]
        public void GetLocalitiesWithPhoneNumberType()
        {
            var client = CreateClient();

            var localities = client.GetAvailableLocalities("IE", PhoneNumberType.Mobile);
            foreach (PhoneNumberLocality locality in localities)
            {
                Console.WriteLine("Locality " + locality.LocalizedName);
            }
            Assert.That(localities, Is.Not.Null);
        }

        [Test]
        [AsyncOnly]
        public async Task GetLocalitiesWithPhoneNumberTypeAsyncAsPages()
        {
            var client = CreateClient();
            var localities = await client.GetAvailableLocalitiesAsync("IE", PhoneNumberType.Mobile).ToEnumerableAsync();
            var localitiesCount = localities.Count;
            var expectedPageSize = localitiesCount;

            if (localitiesCount >= 2)
            {
                expectedPageSize = localitiesCount / 2;
            }
            var pages = client.GetAvailableLocalitiesAsync("IE", PhoneNumberType.Mobile).AsPages(pageSizeHint: expectedPageSize);
            var actual = 0;
            await foreach (var page in pages)
            {
                if (page == null || expectedPageSize == 0)
                {
                    break;
                }
                if (actual == 0)
                {
                    Assert.That(page.Values.Count, Is.EqualTo(expectedPageSize));
                }
                foreach (var phoneNumber in page.Values)
                {
                    actual++;
                }
            }

            Assert.That(actual, Is.EqualTo(localitiesCount));
        }

        [Test]
        [SyncOnly]
        public void GetLocalitiesWithPhoneNumberTypeAsPages()
        {
            var client = CreateClient();
            var localities = client.GetAvailableLocalities("IE", PhoneNumberType.Mobile).ToList();
            var localitiesCount = localities.Count;
            var expectedPageSize = localitiesCount;

            if (localitiesCount >= 2)
            {
                expectedPageSize = localitiesCount / 2;
            }
            var pages = client.GetAvailableLocalities("IE", PhoneNumberType.Mobile).AsPages(pageSizeHint: expectedPageSize);
            var actual = 0;
            foreach (var page in pages)
            {
                if (page == null || expectedPageSize == 0)
                {
                    break;
                }
                if (actual == 0)
                {
                    Assert.That(page.Values.Count, Is.EqualTo(expectedPageSize));
                }
                foreach (var phoneNumber in page.Values)
                {
                    actual++;
                }
            }

            Assert.That(actual, Is.EqualTo(localitiesCount));
        }

        [Test]
        [AsyncOnly]
        public async Task GetLocalitiesAsyncAsPages()
        {
            var client = CreateClient();
            var localities = await client.GetAvailableLocalitiesAsync("US").ToEnumerableAsync();
            var localitiesCount = localities.Count;
            var expectedPageSize = localitiesCount;

            if (localitiesCount >= 2)
            {
                expectedPageSize = localitiesCount / 2;
            }
            var pages = client.GetAvailableLocalitiesAsync("US").AsPages(pageSizeHint: expectedPageSize);
            var actual = 0;
            await foreach (var page in pages)
            {
                if (page == null || expectedPageSize == 0)
                {
                    break;
                }
                // Validate only the size of the first page as it's the only one
                // guaranteed to be of expectedPageSize
                if (actual == 0)
                {
                    Assert.That(page.Values.Count, Is.EqualTo(expectedPageSize));
                }
                foreach (var phoneNumber in page.Values)
                {
                    actual++;
                }
            }

            Assert.That(actual, Is.EqualTo(localitiesCount));
        }

        [Test]
        [SyncOnly]
        public void GetLocalitiesAsPages()
        {
            var client = CreateClient();
            var localities = client.GetAvailableLocalities("US").ToList();
            var localitiesCount = localities.Count;
            var expectedPageSize = localitiesCount;

            if (localitiesCount >= 2)
            {
                expectedPageSize = localitiesCount / 2;
            }
            var pages = client.GetAvailableLocalities("US").AsPages(pageSizeHint: expectedPageSize);
            var actual = 0;
            foreach (var page in pages)
            {
                if (page == null || expectedPageSize == 0)
                {
                    break;
                }
                // Validate only the size of the first page as it's the only one
                // guaranteed to be of expectedPageSize
                if (actual == 0)
                {
                    Assert.That(page.Values.Count, Is.EqualTo(expectedPageSize));
                }
                foreach (var phoneNumber in page.Values)
                {
                    actual++;
                }
            }

            Assert.That(actual, Is.EqualTo(localitiesCount));
        }

        [Test]
        [AsyncOnly]
        public async Task GetLocalitiesWithAdministrativeDivisionAsync()
        {
            var client = CreateClient();
            var availableLocalities = client.GetAvailableLocalitiesAsync("US");
            await foreach (PhoneNumberLocality firstLocality in availableLocalities)
            {
                var localities = client.GetAvailableLocalitiesAsync("US", firstLocality.AdministrativeDivision.AbbreviatedName);
                await foreach (PhoneNumberLocality locality in localities)
                {
                    Console.WriteLine("Locality " + locality.LocalizedName);
                    Assert.That(firstLocality.AdministrativeDivision.AbbreviatedName, Is.EqualTo(locality.AdministrativeDivision.AbbreviatedName));
                }
                Assert.That(localities, Is.Not.Null);
                break;
            }
        }

        [Test]
        [SyncOnly]
        public void GetLocalitiesWithAdministrativeDivision()
        {
            var client = CreateClient();
            var availableLocalities = client.GetAvailableLocalities("US");
            foreach (PhoneNumberLocality firstLocality in availableLocalities)
            {
                var localities = client.GetAvailableLocalities("US", firstLocality.AdministrativeDivision.AbbreviatedName);
                foreach (PhoneNumberLocality locality in localities)
                {
                    Console.WriteLine("Locality " + locality.LocalizedName);
                    Assert.That(firstLocality.AdministrativeDivision.AbbreviatedName, Is.EqualTo(locality.AdministrativeDivision.AbbreviatedName));
                }
                Assert.That(localities, Is.Not.Null);
                break;
            }
        }

        [Test]
        [AsyncOnly]
        public async Task GetOfferingsAsync()
        {
            var client = CreateClient();

            var offerings = client.GetAvailableOfferingsAsync("US");
            await foreach (PhoneNumberOffering offering in offerings)
            {
                Console.WriteLine("Offering " + offering.ToString());
            }
            Assert.That(offerings, Is.Not.Null);
        }

        [Test]
        [SyncOnly]
        public void GetOfferings()
        {
            var client = CreateClient();

            var offerings = client.GetAvailableOfferings("US");
            foreach (PhoneNumberOffering offering in offerings)
            {
                Console.WriteLine("Offering " + offering.ToString());
            }
            Assert.That(offerings, Is.Not.Null);
        }

        [Test]
        [AsyncOnly]
        public async Task GetOfferingsAsyncAsPages()
        {
            var client = CreateClient();
            var offerings = await client.GetAvailableOfferingsAsync("US").ToEnumerableAsync();
            var offeringsCount = offerings.Count;
            var expectedPageSize = offeringsCount;

            if (offeringsCount >= 2)
            {
                expectedPageSize = offeringsCount / 2;
            }
            var pages = client.GetAvailableOfferingsAsync("US").AsPages(pageSizeHint: expectedPageSize);
            var actual = 0;
            await foreach (var page in pages)
            {
                if (page == null || expectedPageSize == 0)
                {
                    break;
                }
                // Validate only the size of the first page as it's the only one
                // guaranteed to be of expectedPageSize
                if (actual == 0)
                {
                    Assert.That(page.Values.Count, Is.EqualTo(expectedPageSize));
                }
                foreach (var phoneNumber in page.Values)
                {
                    actual++;
                }
            }

            Assert.That(actual, Is.EqualTo(offeringsCount));
        }

        [Test]
        [SyncOnly]
        public void GetOfferingsAsPages()
        {
            var client = CreateClient();
            var offerings = client.GetAvailableOfferings("US").ToList();
            var offeringsCount = offerings.Count;
            var expectedPageSize = offeringsCount;

            if (offeringsCount >= 2)
            {
                expectedPageSize = offeringsCount / 2;
            }
            var pages = client.GetAvailableOfferings("US").AsPages(pageSizeHint: expectedPageSize);
            var actual = 0;
            foreach (var page in pages)
            {
                if (page == null || expectedPageSize == 0)
                {
                    break;
                }
                // Validate only the size of the first page as it's the only one
                // guaranteed to be of expectedPageSize
                if (actual == 0)
                {
                    Assert.That(page.Values.Count, Is.EqualTo(expectedPageSize));
                }
                foreach (var phoneNumber in page.Values)
                {
                    actual++;
                }
            }

            Assert.That(actual, Is.EqualTo(offeringsCount));
        }

        [Test]
        [AsyncOnly]
        public async Task GetOfferingsWithPhoneNumberAndAssignmentTypeAsync()
        {
            var client = CreateClient();

            var offerings = client.GetAvailableOfferingsAsync("US", PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application);
            await foreach (PhoneNumberOffering offering in offerings)
            {
                Console.WriteLine("Offering " + offering.ToString());
            }
            Assert.That(offerings, Is.Not.Null);
        }

        [Test]
        [SyncOnly]
        public void GetOfferingsWithPhoneNumberAndAssignmentType()
        {
            var client = CreateClient();

            var offerings = client.GetAvailableOfferings("US", PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application);
            foreach (PhoneNumberOffering offering in offerings)
            {
                Console.WriteLine("Offering " + offering.ToString());
            }
            Assert.That(offerings, Is.Not.Null);
        }

        [Test]
        [AsyncOnly]
        public async Task SearchOperatorInformationAsyncSucceeds()
        {
            var phoneNumber = GetTestPhoneNumber();
            List<string> phoneNumbers = new List<string>() { phoneNumber };

            var client = CreateClient();

            var results = await client.SearchOperatorInformationAsync(phoneNumbers);
            Assert.That(results.Value.Values[0].PhoneNumber, Is.EqualTo(phoneNumber));
        }

        [Test]
        [SyncOnly]
        public void SearchOperatorInformationSucceeds()
        {
            var phoneNumber = GetTestPhoneNumber();
            List<string> phoneNumbers = new List<string>() { phoneNumber };

            var client = CreateClient();

            var results = client.SearchOperatorInformation(phoneNumbers);
            Assert.That(results.Value.Values[0].PhoneNumber, Is.EqualTo(phoneNumber));
        }

        [Test]
        [AsyncOnly]
        public async Task SearchOperatorInformationAsyncOnlyAcceptsOnePhoneNumber()
        {
            var phoneNumber = GetTestPhoneNumber();
            List<string> phoneNumbers = new List<string>() { phoneNumber, phoneNumber };

            var client = CreateClient();

            try
            {
                var results = await client.SearchOperatorInformationAsync(phoneNumbers);
            }
            catch (RequestFailedException ex)
            {
                Assert.That(IsClientError(ex.Status), Is.True, $"Status code {ex.Status} does not indicate a client error.");
                return;
            }

            Assert.Fail("SearchOperatorInformationAsync should have thrown an exception.");
        }

        [Test]
        [SyncOnly]
        public void SearchOperatorInformationOnlyAcceptsOnePhoneNumber()
        {
            var phoneNumber = GetTestPhoneNumber();
            List<string> phoneNumbers = new List<string>() { phoneNumber, phoneNumber };

            var client = CreateClient();

            try
            {
                var results = client.SearchOperatorInformation(phoneNumbers);
            }
            catch (RequestFailedException ex)
            {
                Assert.That(IsClientError(ex.Status), Is.True, $"Status code {ex.Status} does not indicate a client error.");
                return;
            }

            Assert.Fail("SearchOperatorInformation should have thrown an exception.");
        }

        [Test]
        [AsyncOnly]
        public async Task SearchOperatorInformationAsyncRespectsOptions()
        {
            var phoneNumber = GetTestPhoneNumber();
            List<string> phoneNumbers = new List<string>() { phoneNumber };

            var client = CreateClient();

            var results = await client.SearchOperatorInformationAsync(phoneNumbers, new OperatorInformationOptions() { IncludeAdditionalOperatorDetails = false });
            var operatorInformation = results.Value.Values[0];
            Assert.That(operatorInformation.PhoneNumber, Is.EqualTo(phoneNumber));
            Assert.That(operatorInformation.InternationalFormat, Is.Not.Null);
            Assert.That(operatorInformation.NationalFormat, Is.Not.Null);
            Assert.That(operatorInformation.IsoCountryCode, Is.Null);
            Assert.That(operatorInformation.OperatorDetails, Is.Null);

            results = await client.SearchOperatorInformationAsync(phoneNumbers, new OperatorInformationOptions() { IncludeAdditionalOperatorDetails = true });
            operatorInformation = results.Value.Values[0];
            Assert.That(operatorInformation.PhoneNumber, Is.EqualTo(phoneNumber));
            Assert.That(operatorInformation.InternationalFormat, Is.Not.Null);
            Assert.That(operatorInformation.NationalFormat, Is.Not.Null);
            Assert.That(operatorInformation.IsoCountryCode, Is.Not.Null);
            Assert.That(operatorInformation.OperatorDetails, Is.Not.Null);
        }

        [Test]
        [SyncOnly]
        public void SearchOperatorInformationRespectsOptions()
        {
            var phoneNumber = GetTestPhoneNumber();
            List<string> phoneNumbers = new List<string>() { phoneNumber };

            var client = CreateClient();

            var results = client.SearchOperatorInformation(phoneNumbers, new OperatorInformationOptions() { IncludeAdditionalOperatorDetails = false });
            var operatorInformation = results.Value.Values[0];
            Assert.That(operatorInformation.PhoneNumber, Is.EqualTo(phoneNumber));
            Assert.That(operatorInformation.InternationalFormat, Is.Not.Null);
            Assert.That(operatorInformation.NationalFormat, Is.Not.Null);
            Assert.That(operatorInformation.IsoCountryCode, Is.Null);
            Assert.That(operatorInformation.OperatorDetails, Is.Null);

            results = client.SearchOperatorInformation(phoneNumbers, new OperatorInformationOptions() { IncludeAdditionalOperatorDetails = true });
            operatorInformation = results.Value.Values[0];
            Assert.That(operatorInformation.PhoneNumber, Is.EqualTo(phoneNumber));
            Assert.That(operatorInformation.InternationalFormat, Is.Not.Null);
            Assert.That(operatorInformation.NationalFormat, Is.Not.Null);
            Assert.That(operatorInformation.IsoCountryCode, Is.Not.Null);
            Assert.That(operatorInformation.OperatorDetails, Is.Not.Null);
        }

        private static bool IsSuccess(int statusCode)
        {
            return statusCode >= 200 && statusCode < 300;
        }

        private static bool IsClientError(int statusCode)
        {
            return statusCode >= 400 && statusCode < 500;
        }
    }
}
