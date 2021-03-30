// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    }
}
