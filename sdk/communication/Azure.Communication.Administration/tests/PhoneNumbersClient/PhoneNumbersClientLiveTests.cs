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
        public async Task CreateReservationErrorState(string? locale)
        {
            var client = CreateClient();
            const string countryCode = "wrong_code";

            PhoneNumberCapabilitiesRequest capabilitiesRequest = new PhoneNumberCapabilitiesRequest();
            capabilitiesRequest.Calling = PhoneNumberCapabilityValue.InboundOutbound;

            var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(countryCode, PhoneNumberType.Geographic, PhoneNumberAssignmentType.Person, capabilitiesRequest);

            try
            {
                if (TestEnvironment.Mode == RecordedTestMode.Playback)
                    await searchOperation.WaitForCompletionAsync(TimeSpan.Zero, default).ConfigureAwait(false);
                else
                    await searchOperation.WaitForCompletionAsync().ConfigureAwait(false);
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

            PhoneNumberCapabilitiesRequest capabilitiesRequest = new PhoneNumberCapabilitiesRequest();
            capabilitiesRequest.Calling = PhoneNumberCapabilityValue.InboundOutbound;

            var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(countryCode, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Person, capabilitiesRequest);

            if (TestEnvironment.Mode == RecordedTestMode.Playback)
                await searchOperation.WaitForCompletionAsync(TimeSpan.Zero, default).ConfigureAwait(false);
            else
                await searchOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.IsNotNull(searchOperation);
            Assert.IsTrue(searchOperation.HasCompleted);
            Assert.IsTrue(searchOperation.HasValue);

            var reservation = searchOperation.Value;
            Assert.IsNotNull(reservation);

            Assert.AreEqual(1, reservation.PhoneNumbers?.Count);
        }

        [Test]
        [TestCase(null)]
        [TestCase("en-US")]
        public async Task CreateGeographicalReservation(string? locale)
        {
            var client = CreateClient();
            const string countryCode = "US";

            PhoneNumberCapabilitiesRequest capabilitiesRequest = new PhoneNumberCapabilitiesRequest();
            capabilitiesRequest.Calling = PhoneNumberCapabilityValue.InboundOutbound;

            var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(countryCode, PhoneNumberType.Geographic, PhoneNumberAssignmentType.Person, capabilitiesRequest);

            if (TestEnvironment.Mode == RecordedTestMode.Playback)
                await searchOperation.WaitForCompletionAsync(TimeSpan.Zero, default).ConfigureAwait(false);
            else
                await searchOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.IsNotNull(searchOperation);
            Assert.IsTrue(searchOperation.HasCompleted);
            Assert.IsTrue(searchOperation.HasValue);

            var reservation = searchOperation.Value;
            Assert.IsNotNull(reservation);

            Assert.AreEqual(1, reservation.PhoneNumbers?.Count);
        }
    }
}
