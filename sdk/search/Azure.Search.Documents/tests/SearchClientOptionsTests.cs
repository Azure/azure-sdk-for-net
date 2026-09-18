// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    [Category("TypeCompleteness")]
    public class SearchClientOptionsTests
    {
        [Test]
        public void ServiceVersionMappingsRoundTrip([Values] SearchClientOptions.ServiceVersion version)
        {
            string wireVersion = version.ToVersionString();

            Assert.AreEqual(version, new SearchClientOptions(version).Version);
            Assert.AreEqual(version, wireVersion.ToServiceVersion());
            Assert.IsTrue(SearchClientOptions.TryGetServiceVersion(wireVersion, out SearchClientOptions.ServiceVersion parsed));
            Assert.AreEqual(version, parsed);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("not-an-api-version")]
        public void UnknownVersionStringsAreRejected(string version)
        {
            Assert.IsFalse(SearchClientOptions.TryGetServiceVersion(version, out _));
            Assert.Throws<ArgumentOutOfRangeException>(() => version.ToServiceVersion());
        }

        [TestCase(0)]
        [TestCase(int.MaxValue)]
        public void UndefinedServiceVersionsAreRejected(int value)
        {
            SearchClientOptions.ServiceVersion version = (SearchClientOptions.ServiceVersion)value;

            Assert.Throws<ArgumentOutOfRangeException>(() => new SearchClientOptions(version));
            Assert.Throws<ArgumentOutOfRangeException>(() => version.ToVersionString());
        }
    }
}
