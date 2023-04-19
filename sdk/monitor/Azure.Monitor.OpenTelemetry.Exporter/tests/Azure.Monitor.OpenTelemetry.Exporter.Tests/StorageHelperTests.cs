// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
                configuredStorageDirectory: $"C:{ds}Temp",
                instrumentationKey: "testIkey",
                processName: "w3wp",
                applicationDirectory: "C:\\inetpub\\wwwroot");

            Assert.Equal($"C:{ds}Temp{ds}da7bc2b3fc208d871eda206b7dec121a7944a3bce25e17143ba0f8b1a6c41bdd", directoryPath);
        }

        [Theory]
        [InlineData("LOCALAPPDATA")]
        [InlineData("TEMP")]
        public void VerifyDefaultDirectory_Windows(string envVarName)
        {
            var platform = new MockPlatform();
            platform.IsOsPlatformFunc = (os) => os.ToString() == "WINDOWS";
            platform.SetEnvironmentVariable(envVarName, $"C:{ds}Temp");

            var directoryPath = StorageHelper.GetDefaultStorageDirectory(platform: platform);

            // when using a default directory, we will append /Microsoft/AzureMonitor
            Assert.Equal($"C:{ds}Temp{ds}Microsoft{ds}AzureMonitor", directoryPath);
        }

        [Theory]
        [InlineData(0, "/unitTest/tmp/", "/unitTest/tmp/")]
        [InlineData(1, "null", "/var/tmp/")]
        [InlineData(2, "null", "/tmp/")]
        public void VerifyDefaultDirectory_Linux(int attempt, string envVarValue, string expectedDirectory)
        {
            // In NON-Windows environments, First attempt is an EnvironmentVariable.
            // If that's not available, we'll attempt hardcoded defaults.
            int attemptCount = 0;

            var platform = new MockPlatform();
            platform.IsOsPlatformFunc = (os) => os.ToString() == "LINUX";
            platform.SetEnvironmentVariable("TMPDIR", envVarValue);
            platform.CreateDirectoryFunc = (path) => attemptCount++ == attempt;

            var directoryPath = StorageHelper.GetDefaultStorageDirectory(platform: platform);

            // when using a default directory, we will append /Microsoft/AzureMonitor
            Assert.Equal($"{expectedDirectory}Microsoft{ds}AzureMonitor", directoryPath);
        }
    }
}
