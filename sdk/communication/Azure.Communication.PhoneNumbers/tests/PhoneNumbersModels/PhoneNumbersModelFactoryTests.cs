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
            Assert.That(result, Is.Not.Null);
            Assert.That(result.AreaCode, Is.EqualTo("123"));
        }

        [Test]
        public void PhoneNumberCountry_WhenLocalizedAndCountryCodeNotNull_ShouldReturnInstanceOfPhoneNumberCountry()
        {
            var result = PhoneNumbersModelFactory.PhoneNumberCountry("USA", "US");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.LocalizedName, Is.EqualTo("USA"));
            Assert.That(result.CountryCode, Is.EqualTo("US"));
        }

        [Test]
        public void PhoneNumberLocality_ShouldReturnInstanceOfPhoneNumberLocality()
        {
            var administrativeDivision = PhoneNumbersModelFactory.PhoneNumberAdministrativeDivision("Washington", "WA");
            var result = PhoneNumbersModelFactory.PhoneNumberLocality("Seattle", administrativeDivision);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.LocalizedName, Is.EqualTo("Seattle"));
            Assert.That(result.AdministrativeDivision, Is.EqualTo(administrativeDivision));
        }

        [Test]
        public void PhoneNumberAdministrativeDivision_WhenLocalizedAndAbbreviatedNameNotNull_ShouldReturnInstanceOfPhoneNumberAdministrativeDivision()
        {
            var result = PhoneNumbersModelFactory.PhoneNumberAdministrativeDivision("Washington", "WA");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.LocalizedName, Is.EqualTo("Washington"));
            Assert.That(result.AbbreviatedName, Is.EqualTo("WA"));
        }

        [Test]
        public void PhoneNumberOffering_ShouldReturnInstanceOfPhoneNumberOffering()
        {
            var capabilities = new PhoneNumberCapabilities(PhoneNumberCapabilityType.Inbound, PhoneNumberCapabilityType.Inbound);
            var cost = PhoneNumbersModelFactory.PhoneNumberCost(10, "USD", BillingFrequency.Monthly);
            var result = PhoneNumbersModelFactory.PhoneNumberOffering(PhoneNumberType.Geographic, PhoneNumberAssignmentType.Application, capabilities, cost);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.PhoneNumberType, Is.EqualTo(PhoneNumberType.Geographic));
            Assert.That(result.AssignmentType, Is.EqualTo(PhoneNumberAssignmentType.Application));
            Assert.That(result.AvailableCapabilities, Is.EqualTo(capabilities));
            Assert.That(result.Cost, Is.EqualTo(cost));
        }

        [Test]
        public void PhoneNumberCost_WhenIsoCurrencySymbolNotNull_ShouldReturnInstanceOfPhoneNumberCost()
        {
            var result = PhoneNumbersModelFactory.PhoneNumberCost(10, "USD", BillingFrequency.Monthly);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Amount, Is.EqualTo(10));
            Assert.That(result.IsoCurrencySymbol, Is.EqualTo("USD"));
            Assert.That(result.BillingFrequency, Is.EqualTo(BillingFrequency.Monthly));
        }

        [Test]
        public void PhoneNumberSearchResult_ShouldReturnInstanceOfPhoneNumberSearchResult()
        {
            var phoneNumbers = new List<string> { "+12065551234", "+12065551235" };
            var capabilities = new PhoneNumberCapabilities(PhoneNumberCapabilityType.Inbound, PhoneNumberCapabilityType.Inbound);
            var cost = PhoneNumbersModelFactory.PhoneNumberCost(10, "USD", BillingFrequency.Monthly);
            var error = PhoneNumberSearchResultError.NoError;

            var result = PhoneNumbersModelFactory.PhoneNumberSearchResult("search1", phoneNumbers, PhoneNumberType.Geographic, PhoneNumberAssignmentType.Application, capabilities, cost, DateTimeOffset.Now, 0, error);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.SearchId, Is.EqualTo("search1"));
            Assert.That(result.PhoneNumbers, Is.EqualTo(phoneNumbers));
            Assert.That(result.PhoneNumberType, Is.EqualTo(PhoneNumberType.Geographic));
            Assert.That(result.AssignmentType, Is.EqualTo(PhoneNumberAssignmentType.Application));
            Assert.That(result.Capabilities, Is.EqualTo(capabilities));
            Assert.That(result.Cost, Is.EqualTo(cost));
            Assert.That(result.ErrorCode, Is.EqualTo(0));
            Assert.That(result.Error, Is.EqualTo(error));
        }
    }
}
