// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using static Azure.Search.Documents.SearchClientOptions.ServiceVersion;

namespace Azure.Search.Documents.Tests
{
    public class SearchClientOptionsTests
    {
        [Test]
        public void DefaultsToLatestGaVersion()
        {
            Assert.AreEqual(V2026_10_01, new SearchClientOptions().Version);
            Assert.AreEqual(V2026_10_01, SearchClientOptions.LatestVersion);
        }

        [TestCase(V2020_06_30, "2020-06-30")]
        [TestCase(V2023_11_01, "2023-11-01")]
        [TestCase(V2024_07_01, "2024-07-01")]
        [TestCase(V2025_09_01, "2025-09-01")]
        [TestCase(V2026_04_01, "2026-04-01")]
        [TestCase(V2026_10_01, "2026-10-01")]
        public void SupportedVersionsRoundtrip(SearchClientOptions.ServiceVersion version, string versionString)
        {
            Assert.AreEqual(version, new SearchClientOptions(version).Version);
            Assert.AreEqual(versionString, version.ToVersionString());
            Assert.AreEqual(version, versionString.ToServiceVersion());
            Assert.IsTrue(SearchClientOptions.TryGetServiceVersion(versionString, out var parsedVersion));
            Assert.AreEqual(version, parsedVersion);
        }

        [Test]
        public void ConfigurationSelectsGaVersion()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Search:Version"] = "2026-10-01",
                })
                .Build();

#pragma warning disable SCME0002
            SearchClientOptions options = new(configuration.GetSection("Search"));
#pragma warning restore SCME0002

            Assert.AreEqual(V2026_10_01, options.Version);
        }

        [Test]
        public void RejectsUnsupportedPreviewVersion()
        {
            Assert.IsFalse(SearchClientOptions.TryGetServiceVersion("2026-08-01-preview", out _));
            Assert.Throws<ArgumentOutOfRangeException>(() => "2026-08-01-preview".ToServiceVersion());
            Assert.Throws<ArgumentOutOfRangeException>(() => new SearchClientOptions((SearchClientOptions.ServiceVersion)7));
        }
    }
}
