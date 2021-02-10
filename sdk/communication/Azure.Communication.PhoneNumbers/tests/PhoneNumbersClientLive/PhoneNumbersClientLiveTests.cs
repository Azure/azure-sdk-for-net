// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Communication.PhoneNumbers.Models;
using Azure.Communication.PhoneNumbers.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.PhoneNumbers.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="PhoneNumberAdministrationClient"/> class.
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

        [Test]
        public async Task ListPhoneNumbersAsync()
        {
            var client = CreateClient();

            var numbersPagable = client.ListPhoneNumbersAsync();
            var numbers = await numbersPagable.ToEnumerableAsync();

            Assert.IsNotNull(numbers);
        }

        [Test]
        [TestCase(null)]
        [TestCase("en-US")]
        public async Task CreateSearchErrorState(string? locale)
        {
            var client = CreateClient();
            const string countryCode = "US";

            // User and toll free is an invalid combination
            var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(countryCode, PhoneNumberType.TollFree, PhoneNumberAssignmentType.User,
                new PhoneNumberCapabilities(PhoneNumberCapabilityValue.Outbound, PhoneNumberCapabilityValue.None), new PhoneNumberSearchOptions("212", 1));

            try
            {
                if (TestEnvironment.Mode == RecordedTestMode.Playback)
                    await searchOperation.WaitForCompletionAsync(TimeSpan.Zero, default).ConfigureAwait(false);
                else
                    await searchOperation.WaitForCompletionAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Search has failed.", ex.Message);
                return;
            }

            Assert.Fail("WaitForCompletionAsync should have thrown an exception.");
        }

        [TestCase("geographic", "user", "inbound", "none")]
        [TestCase("geographic", "application", "outbound", "none")]
        [TestCase("geographic", "application", "inbound+outbound", "none")]
        [TestCase("geographic", "user", "inbound", "inbound")]
        [TestCase("geographic", "application", "outbound", "outbound")]
        [TestCase("geographic", "application", "inbound+outbound", "inbound+outbound")]
        [TestCase("geographic", "user", "none", "inbound")]
        [TestCase("geographic", "application", "none", "outbound")]
        [TestCase("geographic", "application", "none", "inbound+outbound")]
        public async Task CreateSearch(string phoneType, string assignmentType, string calling, string sms)
        {
            PhoneNumberType phoneNumberType = phoneType == "geographic" ? PhoneNumberType.Geographic : PhoneNumberType.TollFree;
            PhoneNumberAssignmentType phoneNumberAssignmentType = assignmentType == "user" ? PhoneNumberAssignmentType.User : PhoneNumberAssignmentType.Application;

            var client = CreateClient();
            const string countryCode = "US";

            var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(countryCode, phoneNumberType, phoneNumberAssignmentType,
                new PhoneNumberCapabilities(calling, sms));

            if (TestEnvironment.Mode == RecordedTestMode.Playback)
                await searchOperation.WaitForCompletionAsync(TimeSpan.Zero, default).ConfigureAwait(false);
            else
                await searchOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.IsNotNull(searchOperation);
            Assert.IsTrue(searchOperation.HasCompleted);
            Assert.IsTrue(searchOperation.HasValue);

            var rearchResult = searchOperation.Value;
            Assert.IsNotNull(rearchResult);

            Assert.AreEqual(1, rearchResult.PhoneNumbers.Count);
        }

        [TestCase("geographic", "user", "inbound", "none")]
        [TestCase("geographic", "application", "outbound", "none")]
        [TestCase("geographic", "application", "inbound+outbound", "none")]
        [TestCase("geographic", "user", "inbound", "inbound")]
        [TestCase("geographic", "application", "outbound", "outbound")]
        [TestCase("geographic", "application", "inbound+outbound", "inbound+outbound")]
        [TestCase("geographic", "user", "none", "inbound")]
        [TestCase("geographic", "application", "none", "outbound")]
        [TestCase("geographic", "application", "none", "inbound+outbound")]
        public async Task PurchaseSearch(string phoneType, string assignmentType, string calling, string sms)
        {
            PhoneNumberType phoneNumberType = phoneType == "geographic" ? PhoneNumberType.Geographic : PhoneNumberType.TollFree;
            PhoneNumberAssignmentType phoneNumberAssignmentType = assignmentType == "user" ? PhoneNumberAssignmentType.User : PhoneNumberAssignmentType.Application;

            var client = CreateClient();
            const string countryCode = "US";

            // Search
            var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(countryCode, phoneNumberType, phoneNumberAssignmentType, new PhoneNumberCapabilities(calling, sms));

            if (TestEnvironment.Mode == RecordedTestMode.Playback)
                await searchOperation.WaitForCompletionAsync(TimeSpan.Zero, default).ConfigureAwait(false);
            else
                await searchOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.IsNotNull(searchOperation);
            Assert.IsTrue(searchOperation.HasCompleted);
            Assert.IsTrue(searchOperation.HasValue);

            var searchResult = searchOperation.Value;
            Assert.IsNotNull(searchResult);

            Assert.AreEqual(1, searchResult.PhoneNumbers.Count);

            // Purchase

            var purchaseOperation = await client.StartPurchasePhoneNumbersAsync(searchOperation.Id);

            if (TestEnvironment.Mode == RecordedTestMode.Playback)
                await purchaseOperation.WaitForCompletionAsync(TimeSpan.Zero, default).ConfigureAwait(false);
            else
                await purchaseOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.IsNotNull(purchaseOperation);
            Assert.IsTrue(purchaseOperation.HasCompleted);
            Assert.IsTrue(purchaseOperation.HasValue);

            var purchaseResult = purchaseOperation.Value;
            Assert.IsNotNull(purchaseResult);

            // Get purchased number
            var searchedNumber = searchOperation.Value.PhoneNumbers.First();

            var phoneNumberResponse = await client.GetPhoneNumberAsync(searchedNumber);
            var phoneNumber = phoneNumberResponse.Value;

            Assert.AreEqual(searchedNumber, phoneNumber.PhoneNumber);

            Assert.AreEqual(phoneType, phoneNumber.PhoneNumberType.ToString());
            Assert.AreEqual(assignmentType, phoneNumber.AssignmentType.ToString());
            Assert.AreEqual(calling, phoneNumber.Capabilities.Calling.ToString());
            Assert.AreEqual(sms, phoneNumber.Capabilities.Sms.ToString());

            // TODO:
            // Assert.AreEqual(sms, phoneNumber.Cost);

            Assert.AreEqual(countryCode, phoneNumber.CountryCode);
            Assert.AreEqual(searchedNumber, phoneNumber.PhoneNumber);
        }
    }
}
