// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Communication.PhoneNumbers.Tests
{
    public class PhoneNumbersModelFactoryTests
    {
        [Test]
        public void PhoneNumberAreaCode_ShouldReturnInstanceOfPhoneNumberAreaCode()
        {
            var result = PhoneNumbersModelFactory.PhoneNumberAreaCode("123");
            Assert.IsNotNull(result);
            Assert.AreEqual("123", result.AreaCode);
        }

        [Test]
        public void PhoneNumberCountry_WhenLocalizedAndCountryCodeNotNull_ShouldReturnInstanceOfPhoneNumberCountry()
        {
            var result = PhoneNumbersModelFactory.PhoneNumberCountry("USA", "US");
            Assert.IsNotNull(result);
            Assert.AreEqual("USA", result.LocalizedName);
            Assert.AreEqual("US", result.CountryCode);
        }

        [Test]
        public void PhoneNumberLocality_ShouldReturnInstanceOfPhoneNumberLocality()
        {
            var administrativeDivision = PhoneNumbersModelFactory.PhoneNumberAdministrativeDivision("Washington", "WA");
            var result = PhoneNumbersModelFactory.PhoneNumberLocality("Seattle", administrativeDivision);
            Assert.IsNotNull(result);
            Assert.AreEqual("Seattle", result.LocalizedName);
            Assert.AreEqual(administrativeDivision, result.AdministrativeDivision);
        }

        [Test]
        public void PhoneNumberAdministrativeDivision_WhenLocalizedAndAbbreviatedNameNotNull_ShouldReturnInstanceOfPhoneNumberAdministrativeDivision()
        {
            var result = PhoneNumbersModelFactory.PhoneNumberAdministrativeDivision("Washington", "WA");
            Assert.IsNotNull(result);
            Assert.AreEqual("Washington", result.LocalizedName);
            Assert.AreEqual("WA", result.AbbreviatedName);
        }

        [Test]
        public void PhoneNumberOffering_ShouldReturnInstanceOfPhoneNumberOffering()
        {
            var capabilities = new PhoneNumberCapabilities(PhoneNumberCapabilityType.Inbound, PhoneNumberCapabilityType.Inbound);
            var cost = PhoneNumbersModelFactory.PhoneNumberCost(10, "USD", BillingFrequency.Monthly);
            var result = PhoneNumbersModelFactory.PhoneNumberOffering(PhoneNumberType.Geographic, PhoneNumberAssignmentType.Application, capabilities, cost);
            Assert.IsNotNull(result);
            Assert.AreEqual(PhoneNumberType.Geographic, result.PhoneNumberType);
            Assert.AreEqual(PhoneNumberAssignmentType.Application, result.AssignmentType);
            Assert.AreEqual(capabilities, result.AvailableCapabilities);
            Assert.AreEqual(cost, result.Cost);
        }

        [Test]
        public void PhoneNumberCost_WhenIsoCurrencySymbolNotNull_ShouldReturnInstanceOfPhoneNumberCost()
        {
            var result = PhoneNumbersModelFactory.PhoneNumberCost(10, "USD", BillingFrequency.Monthly);
            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Amount);
            Assert.AreEqual("USD", result.IsoCurrencySymbol);
            Assert.AreEqual(BillingFrequency.Monthly, result.BillingFrequency);
        }

        [Test]
        public void PhoneNumberSearchResult_ShouldReturnInstanceOfPhoneNumberSearchResult()
        {
            var phoneNumbers = new List<string> { "+12065551234", "+12065551235" };
            var capabilities = new PhoneNumberCapabilities(PhoneNumberCapabilityType.Inbound, PhoneNumberCapabilityType.Inbound);
            var cost = PhoneNumbersModelFactory.PhoneNumberCost(10, "USD", BillingFrequency.Monthly);
            var error = PhoneNumberSearchResultError.NoError;

            var result = PhoneNumbersModelFactory.PhoneNumberSearchResult("search1", phoneNumbers, PhoneNumberType.Geographic, PhoneNumberAssignmentType.Application, capabilities, cost, DateTimeOffset.Now, 0, error);
            Assert.IsNotNull(result);
            Assert.AreEqual("search1", result.SearchId);
            Assert.AreEqual(phoneNumbers, result.PhoneNumbers);
            Assert.AreEqual(PhoneNumberType.Geographic, result.PhoneNumberType);
            Assert.AreEqual(PhoneNumberAssignmentType.Application, result.AssignmentType);
            Assert.AreEqual(capabilities, result.Capabilities);
            Assert.AreEqual(cost, result.Cost);
            Assert.AreEqual(0, result.ErrorCode);
            Assert.AreEqual(error, result.Error);
        }
    }
}
