// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class ShareClientOptionsTests
    {
        [Test]
        public void TryGetServiceVersion_ParsesAllServiceVersions()
        {
            var serviceVersions = Enum.GetValues(typeof(ShareClientOptions.ServiceVersion))
                .Cast<ShareClientOptions.ServiceVersion>();

            foreach (ShareClientOptions.ServiceVersion expected in serviceVersions)
            {
                string versionString = expected.ToVersionString();

                bool parsed = ShareClientOptions.TryGetServiceVersion(versionString, out ShareClientOptions.ServiceVersion actual);

                Assert.IsTrue(parsed, $"TryGetServiceVersion failed to parse \"{versionString}\" for {expected}.");
                Assert.AreEqual(expected, actual, $"TryGetServiceVersion returned {actual} instead of {expected} for \"{versionString}\".");
            }
        }
    }
}
