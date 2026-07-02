// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class BlobClientOptionsTests
    {
        [Test]
        public void TryGetServiceVersion_ParsesAllServiceVersions()
        {
            var serviceVersions = Enum.GetValues(typeof(BlobClientOptions.ServiceVersion))
                .Cast<BlobClientOptions.ServiceVersion>();

            foreach (BlobClientOptions.ServiceVersion expected in serviceVersions)
            {
                string versionString = expected.ToVersionString();

                bool parsed = BlobClientOptions.TryGetServiceVersion(versionString, out BlobClientOptions.ServiceVersion actual);

                Assert.IsTrue(parsed, $"TryGetServiceVersion failed to parse \"{versionString}\" for {expected}.");
                Assert.AreEqual(expected, actual, $"TryGetServiceVersion returned {actual} instead of {expected} for \"{versionString}\".");
            }
        }
    }
}
