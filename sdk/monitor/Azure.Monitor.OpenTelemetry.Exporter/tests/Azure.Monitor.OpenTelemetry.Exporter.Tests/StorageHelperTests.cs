// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class StorageHelperTests
    {
        // The directory separator is either `/` or `\` depending on the Platform, making unit testing tricky.
        private static char ds = Path.DirectorySeparatorChar;

        [Fact]
        public void VerifyDirectory()
        {
            var directoryPath = StorageHelper.GetStorageDirectory(
                configuredStorageDirectory: $"C:{ds}Temp",
                instrumentationKey: "testikey");

            Assert.StartsWith($"C:{ds}Temp{ds}testikey", directoryPath);
        }

        [Fact]
        public void VerifyDefaultDirectory()
        {
            var directoryPath = StorageHelper.GetStorageDirectory(
                configuredStorageDirectory: null,
                instrumentationKey: "testikey");

            // Note: Default root directory will be variable depending on OS and permissions.
            Assert.Contains($"{ds}Microsoft{ds}AzureMonitor{ds}testikey", directoryPath);
        }
    }
}
