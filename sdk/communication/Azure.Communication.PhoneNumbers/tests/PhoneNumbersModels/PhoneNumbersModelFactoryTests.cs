// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Azure.Communication.PhoneNumbers.Tests
{
    public class PhoneNumbersModelFactoryTests
    {
        [Test]
        public void PhoneNumberAreaCode_ShouldReturnInstanceOfPhoneNumberAreaCode()
        {
            var result = PhoneNumbersModelFactory.PhoneNumberAreaCode("123");
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("123", result.AreaCode);
        }

        [Test]
        public void PhoneNumberCountry_WhenLocalizedAndCountryCodeNotNull_ShouldReturnInstanceOfPhoneNumberCountry()
        {
            var result = PhoneNumbersModelFactory.PhoneNumberCountry("USA", "US");
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("USA", result.LocalizedName);
            ClassicAssert.AreEqual("US", result.CountryCode);
        }

        [Test]
        public void PhoneNumberLocality_ShouldReturnInstanceOfPhoneNumberLocality()
        {
            var administrativeDivision = PhoneNumbersModelFactory.PhoneNumberAdministrativeDivision("Washington", "WA");
            var result = PhoneNumbersModelFactory.PhoneNumberLocality("Seattle", administrativeDivision);
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("Seattle", result.LocalizedName);
            ClassicAssert.AreEqual(administrativeDivision, result.AdministrativeDivision);
        }

        [Test]
        public void PhoneNumberAdministrativeDivision_WhenLocalizedAndAbbreviatedNameNotNull_ShouldReturnInstanceOfPhoneNumberAdministrativeDivision()
        {
            var result = PhoneNumbersModelFactory.PhoneNumberAdministrativeDivision("Washington", "WA");
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("Washington", result.LocalizedName);
            ClassicAssert.AreEqual("WA", result.AbbreviatedName);
        }

        [Test]
        public void PhoneNumberOffering_ShouldReturnInstanceOfPhoneNumberOffering()
        {
            var capabilities = new PhoneNumberCapabilities(PhoneNumberCapabilityType.Inbound, PhoneNumberCapabilityType.Inbound);
            var cost = PhoneNumbersModelFactory.PhoneNumberCost(10, "USD", BillingFrequency.Monthly);
            var result = PhoneNumbersModelFactory.PhoneNumberOffering(PhoneNumberType.Geographic, PhoneNumberAssignmentType.Application, capabilities, cost);
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(PhoneNumberType.Geographic, result.PhoneNumberType);
            ClassicAssert.AreEqual(PhoneNumberAssignmentType.Application, result.AssignmentType);
            ClassicAssert.AreEqual(capabilities, result.AvailableCapabilities);
            ClassicAssert.AreEqual(cost, result.Cost);
        }

        [Test]
        public void PhoneNumberCost_WhenIsoCurrencySymbolNotNull_ShouldReturnInstanceOfPhoneNumberCost()
        {
            var result = PhoneNumbersModelFactory.PhoneNumberCost(10, "USD", BillingFrequency.Monthly);
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(10, result.Amount);
            ClassicAssert.AreEqual("USD", result.IsoCurrencySymbol);
            ClassicAssert.AreEqual(BillingFrequency.Monthly, result.BillingFrequency);
        }

        [Test]
        public void PhoneNumberSearchResult_ShouldReturnInstanceOfPhoneNumberSearchResult()
        {
            var phoneNumbers = new List<string> { "+12065551234", "+12065551235" };
            var capabilities = new PhoneNumberCapabilities(PhoneNumberCapabilityType.Inbound, PhoneNumberCapabilityType.Inbound);
            var cost = PhoneNumbersModelFactory.PhoneNumberCost(10, "USD", BillingFrequency.Monthly);
            var error = PhoneNumberSearchResultError.NoError;

            var result = PhoneNumbersModelFactory.PhoneNumberSearchResult("search1", phoneNumbers, PhoneNumberType.Geographic, PhoneNumberAssignmentType.Application, capabilities, cost, DateTimeOffset.Now, 0, error);
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("search1", result.SearchId);
            ClassicAssert.AreEqual(phoneNumbers, result.PhoneNumbers);
            ClassicAssert.AreEqual(PhoneNumberType.Geographic, result.PhoneNumberType);
            ClassicAssert.AreEqual(PhoneNumberAssignmentType.Application, result.AssignmentType);
            ClassicAssert.AreEqual(capabilities, result.Capabilities);
            ClassicAssert.AreEqual(cost, result.Cost);
            ClassicAssert.AreEqual(0, result.ErrorCode);
            ClassicAssert.AreEqual(error, result.Error);
        }
    }
}
