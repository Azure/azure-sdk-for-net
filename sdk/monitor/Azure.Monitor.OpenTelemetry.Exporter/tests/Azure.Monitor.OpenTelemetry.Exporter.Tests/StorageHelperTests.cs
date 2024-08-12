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
        private readonly MockPlatform _testPlatform;
        private readonly string _testIkey = "testIkey";
        private readonly string _testHash;

        public StorageHelperTests()
        {
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            _testStorageDirectory = isWindows
                ? @"C:\UnitTest"
                : "/var/UnitTest";

            _testPlatform = isWindows
                ? new MockPlatform { UserName = "ApplicationPoolIdentity", ProcessName = "w3wp", ApplicationBaseDirectory = @"C:\inetpub\wwwroot" }
                : new MockPlatform { UserName = "TestUser", ProcessName = "TestApplication", ApplicationBaseDirectory = "/unitTest/" };

            // This hash value is a combination of the ikey + values from the platform (UserName, ProcessName, ApplicationBaseDirectory).
            _testHash = isWindows
                ? "f01a11b594e1f6d06cd96564b1f258b515bf98d956e8a1842c74479a1ecef4eb"
                : "683940b83fdb5f4de3bead583ecb8dce9ec04cbc22319eaa1238e6e83bdc9112";
        }

        [Fact]
        public void VerifyGetStorageDirectory_Configured()
        {
            var directoryPath = StorageHelper.GetStorageDirectory(
                platform: _testPlatform,
                configuredStorageDirectory: _testStorageDirectory,
                instrumentationKey: _testIkey);

            var expected = Path.Combine(_testStorageDirectory, _testHash);
            Assert.Equal(expected, directoryPath);
        }

        [Theory]
        [InlineData("WINDOWS", "LOCALAPPDATA")]
        [InlineData("WINDOWS", "TEMP")]
        [InlineData("LINUX", "TMPDIR")]
        public void VerifyGetStorageDirectory_Default(string osName, string envVarName)
        {
            _testPlatform.IsOsPlatformFunc = (os) => os.ToString() == osName;
            _testPlatform.SetEnvironmentVariable(envVarName, _testStorageDirectory);

            var directoryPath = StorageHelper.GetStorageDirectory(
                platform: _testPlatform,
                configuredStorageDirectory: null,
                instrumentationKey: _testIkey);

            var expected = Path.Combine(_testStorageDirectory, "Microsoft", "AzureMonitor", _testHash);
            Assert.Equal(expected, directoryPath);
        }

        [Theory]
        [InlineData("WINDOWS")]
        [InlineData("LINUX")]
        public void VerifyGetStorageDirectory_Failure(string osName)
        {
            var platform = new MockPlatform();
            platform.IsOsPlatformFunc = (os) => os.ToString() == osName;
            platform.CreateDirectoryFunc = (path) => throw new Exception("unit test: failed to create directory");

            Assert.Throws<InvalidOperationException>(() => StorageHelper.GetStorageDirectory(platform: platform, configuredStorageDirectory: null, instrumentationKey: "00000000-0000-0000-0000-000000000000"));
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
            // This test simulates repeated failures to verify that the StorageHelper is selecting the expected directories.
            int attemptCount = 0;

            var platform = new MockPlatform();
            platform.IsOsPlatformFunc = (os) => os.ToString() == "LINUX";
            platform.SetEnvironmentVariable("TMPDIR", envVarValue);
            platform.CreateDirectoryFunc = (path) =>
            {
                if (attemptCount++ != attempt)
                {
                    throw new Exception("unit test: failed to create directory");
                }
            };

            var directoryPath = StorageHelper.GetDefaultStorageDirectory(platform: platform);

            // when using a default directory, we will append /Microsoft/AzureMonitor
            var expected = Path.Combine(expectedDirectory, "Microsoft", "AzureMonitor");
            Assert.Equal(expected, directoryPath);
        }
    }
}
