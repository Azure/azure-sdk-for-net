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

        [Test]
        public async Task ListPhoneNumbersAsync()
        {
            var client = CreateClient();

            var numbersPagable = client.GetPurchasedPhoneNumbersAsync();
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

            Assert.Fail("WaitForCompletionAsync should have thrown an exception.");
        }
    }
}
