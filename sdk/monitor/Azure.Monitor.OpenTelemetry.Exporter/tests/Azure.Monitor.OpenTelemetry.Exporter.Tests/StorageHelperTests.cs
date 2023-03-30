// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class StorageHelperTests
    {
        // The directory separator is either '/' or '\' depending on the Platform, making unit testing tricky.
        private static readonly char ds = Path.DirectorySeparatorChar;

        [Fact]
        public void VerifyDirectory()
        {
            var directoryPath = StorageHelper.GetStorageDirectory(
                configuredStorageDirectory: $"C:{ds}Temp",
                instrumentationKey: "testIkey",
                processName: "w3wp",
                applicationDirectory: "C:\\inetpub\\wwwroot");

            Assert.Equal(directoryPath, $"C:{ds}Temp{ds}da7bc2b3fc208d871eda206b7dec121a7944a3bce25e17143ba0f8b1a6c41bdd");
        }

        [Fact]
        public void VerifyDefaultDirectory()
        {
            var directoryPath = StorageHelper.GetStorageDirectory(
                configuredStorageDirectory: null,
                instrumentationKey: "testIkey",
                processName: "w3wp",
                applicationDirectory: "C:\\inetpub\\wwwroot");

            // Note: Cannot assert full string because default root directory will be variable depending on OS and environment variables.
            Assert.EndsWith($"{ds}Microsoft{ds}AzureMonitor{ds}da7bc2b3fc208d871eda206b7dec121a7944a3bce25e17143ba0f8b1a6c41bdd", directoryPath);
        }
    }
}
