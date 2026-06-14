// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class DataLakeClientOptionsTests
    {
        [Test]
        public void TryGetServiceVersion_ParsesAllServiceVersions()
        {
            var serviceVersions = Enum.GetValues(typeof(DataLakeClientOptions.ServiceVersion))
                .Cast<DataLakeClientOptions.ServiceVersion>();

            foreach (DataLakeClientOptions.ServiceVersion expected in serviceVersions)
            {
                string versionString = expected.ToVersionString();

                bool parsed = DataLakeClientOptions.TryGetServiceVersion(versionString, out DataLakeClientOptions.ServiceVersion actual);

                Assert.IsTrue(parsed, $"TryGetServiceVersion failed to parse \"{versionString}\" for {expected}.");
                Assert.AreEqual(expected, actual, $"TryGetServiceVersion returned {actual} instead of {expected} for \"{versionString}\".");
            }
        }
    }
}
