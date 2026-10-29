// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    [Category("Compatibility")]
    public class CompatibilityTestHelpersTests
    {
        [TestCase("?api-version=2026-01-01", "?api-version=2099-01-01")]
        [TestCase("?api-version=2026-01-01&$skiptoken=next", "?api-version=2099-01-01&$skiptoken=next")]
        [TestCase("?migrate=true&api-version=2026-01-01", "?migrate=true&api-version=2099-01-01")]
        public void UriComparisonIgnoresOnlyApiVersionValue(string actualQuery, string expectedQuery)
        {
            CompatibilityTestHelpers.AssertUriIgnoringApiVersion(
                new Uri("https://management.azure.com/resources" + actualQuery),
                new Uri("https://management.azure.com/resources" + expectedQuery));
        }

        [TestCase("https://management.azure.com/other?api-version=new&$skiptoken=next")]
        [TestCase("https://other.example/resources?api-version=new&$skiptoken=next")]
        [TestCase("http://management.azure.com/resources?api-version=new&$skiptoken=next")]
        [TestCase("https://management.azure.com/resources?api-version=new&$skiptoken=other")]
        [TestCase("https://management.azure.com/resources?api-version=new")]
        [TestCase("https://management.azure.com/resources?api-version=new&$skiptoken=next&migrate=true")]
        [TestCase("https://management.azure.com/resources?$skiptoken=next")]
        [TestCase("https://management.azure.com/resources?api-version=&$skiptoken=next")]
        [TestCase("https://management.azure.com/resources?api-version=new&api-version=other&$skiptoken=next")]
        [TestCase("https://management.azure.com/resources?api-version=new&$skiptoken=next#other")]
        public void UriComparisonRejectsOtherDifferences(string actual)
        {
            Assert.Throws<AssertionException>(() => CompatibilityTestHelpers.AssertUriIgnoringApiVersion(
                new Uri(actual),
                new Uri("https://management.azure.com/resources?api-version=old&$skiptoken=next")));
        }

        [Test]
        public void UriComparisonRejectsChangedMigrateValue()
        {
            Assert.Throws<AssertionException>(() => CompatibilityTestHelpers.AssertUriIgnoringApiVersion(
                new Uri("https://management.azure.com/resources?api-version=new&migrate=false"),
                new Uri("https://management.azure.com/resources?api-version=old&migrate=true")));
        }
    }
}
