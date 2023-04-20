// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.InteropServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class StorageHelperTests
    {
        private readonly string _testStorageDirectory;

        public StorageHelperTests()
        {
            _testStorageDirectory = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? "C:\\UnitTest"
                : "/var/UnitTest";
        }

        [Fact]
        public void VerifyGetStorageDirectory_Configured()
        {
            var directoryPath = StorageHelper.GetStorageDirectory(
                platform: new MockPlatform
                {
                    UserName = "ApplicationPoolIdentity",
                    ProcessName ="w3wp",
                    ApplicationBaseDirectory = "C:\\inetpub\\wwwroot",
                },
                configuredStorageDirectory: _testStorageDirectory,
                instrumentationKey: "testIkey");

            var expected = Path.Combine(_testStorageDirectory, "f01a11b594e1f6d06cd96564b1f258b515bf98d956e8a1842c74479a1ecef4eb");
            Assert.Equal(expected, directoryPath);
        }

        [Theory]
        [InlineData("WINDOWS", "LOCALAPPDATA")]
        [InlineData("LINUX", "TMPDIR")]
        public void VerifyGetStorageDirectory_Default(string osName, string envVarName)
        {
            var platform = new MockPlatform
            {
                UserName = "ApplicationPoolIdentity",
                ProcessName = "w3wp",
                ApplicationBaseDirectory = "C:\\inetpub\\wwwroot",
            };
            platform.IsOsPlatformFunc = (os) => os.ToString() == osName;
            platform.SetEnvironmentVariable(envVarName, _testStorageDirectory);

            var directoryPath = StorageHelper.GetStorageDirectory(
                platform: platform,
                configuredStorageDirectory: null,
                instrumentationKey: "testIkey");

            var expected = Path.Combine(_testStorageDirectory, "Microsoft", "AzureMonitor", "f01a11b594e1f6d06cd96564b1f258b515bf98d956e8a1842c74479a1ecef4eb");
            Assert.Equal(expected, directoryPath);
        }

        [Theory]
        [InlineData("LOCALAPPDATA")]
        [InlineData("TEMP")]
        public void VerifyDefaultDirectory_Windows(string envVarName)
        {
            var platform = new MockPlatform();
            platform.IsOsPlatformFunc = (os) => os.ToString() == "WINDOWS";
            platform.SetEnvironmentVariable(envVarName, _testStorageDirectory);

            var directoryPath = StorageHelper.GetDefaultStorageDirectory(platform: platform);

            // when using a default directory, we will append /Microsoft/AzureMonitor
            var expected = Path.Combine(_testStorageDirectory, "Microsoft", "AzureMonitor");
            Assert.Equal(expected, directoryPath);
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
            var expected = Path.Combine(expectedDirectory, "Microsoft", "AzureMonitor");
            Assert.Equal(expected, directoryPath);
        }

        [Theory]
        [InlineData("WINDOWS")]
        [InlineData("LINUX")]
        public void VerifyDefaultDirectory_Failure(string osName)
        {
            var platform = new MockPlatform();
            platform.IsOsPlatformFunc = (os) => os.ToString() == osName;
            platform.CreateDirectoryFunc = (path) => false;

            Assert.Throws<InvalidOperationException>(() => StorageHelper.GetDefaultStorageDirectory(platform: platform));
        }
    }
}
