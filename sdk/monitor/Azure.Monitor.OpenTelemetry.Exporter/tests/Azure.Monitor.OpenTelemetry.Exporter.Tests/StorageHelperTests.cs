// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class StorageHelperTests
    {
        [Fact]
        public void VerifyDirectory()
        {
            var directoryPath = StorageHelper.GetStorageDirectory(
                configuredStorageDirectory: "C:\\Temp",
                instrumentationKey: "testikey");

            Assert.StartsWith("C:\\Temp\\testikey\\", directoryPath);
        }

        [Fact]
        public void VerifyDefaultDirectory()
        {
            var directoryPath = StorageHelper.GetStorageDirectory(
                configuredStorageDirectory: null,
                instrumentationKey: "testikey");

            // Note: Default root directory will be variable depending on OS and permissions.
            Assert.Contains("\\Microsoft\\AzureMonitor\\testikey\\", directoryPath);
        }
    }
}
