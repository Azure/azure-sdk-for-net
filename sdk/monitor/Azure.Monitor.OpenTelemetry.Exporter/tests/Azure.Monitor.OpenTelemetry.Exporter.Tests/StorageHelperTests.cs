// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class StorageHelperTests
    {
        // The directory separator is either '/' or '\' depending on the Platform, making unit testing tricky.
        private static readonly char ds = Path.DirectorySeparatorChar;

        [Fact]
        public void VerifyConfiguredDirectory()
        {
            var directoryPath = StorageHelper.GetStorageDirectory(
                platform: new MockPlatform(),
                configuredStorageDirectory: $"C:{ds}Temp");

            Assert.Equal(directoryPath, $"C:{ds}Temp");
        }

        [Theory]
        [InlineData("WINDOWS", "LOCALAPPDATA")]
        [InlineData("WINDOWS", "TEMP")]
        [InlineData("LINUX", "TMPDIR")]
        public void VerifyDefaultDirectory(string osName, string environmentVarName)
        {
            var platform = new MockPlatform();
            platform.IsOsPlatformFunc = (os) => os.ToString() == osName;
            platform.SetEnvironmentVariable(environmentVarName, $"C:{ds}Temp");

            var directoryPath = StorageHelper.GetStorageDirectory(
                platform: platform,
                configuredStorageDirectory: null);

            Assert.Equal(directoryPath, $"C:{ds}Temp{ds}Microsoft{ds}AzureMonitor");
        }
    }
}
