// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;

namespace Azure.Iot.Hub.Service.Tests
{
    /// <summary>
    /// These are the settings that will be used by the end-to-end tests.
    /// The json files configured in the configuration will load the settings specific to a user.
    /// </summary>
    public class TestSettings
    {
        public const string IotHubEnvironmentVariablesPrefix = "IOT";
        public const string IotHubConnectionString = "IOT_HUB_CONNECTION_STRING";
        public const string StorageSasToken = "STORAGE_SAS_TOKEN";
        public const string TestModeEnvVariable = "AZURE_TEST_MODE";

        public static TestSettings Instance { get; private set; }

        public RecordedTestMode TestMode { get; set; }

        /// <summary>
        /// The working directory of the tests.
        /// </summary>
        public string WorkingDirectory { get; private set; }

        static TestSettings()
        {
            if (Instance != null)
            {
                return;
            }

            string codeBase = Assembly.GetExecutingAssembly().Location;
            string workingDirectory = Path.GetDirectoryName(codeBase);

            string userName = Environment.UserName;

            // Initialize the settings related to IoT Hub instance and authentication
            var testSettingsConfigBuilder = new ConfigurationBuilder();

            string testSettingsCommonPath = Path.Combine(workingDirectory, "config", "common.config.json");
            testSettingsConfigBuilder.AddJsonFile(testSettingsCommonPath);

            string testSettingsUserPath = Path.Combine(workingDirectory, "config", $"{userName}.config.json");
            if (File.Exists(testSettingsUserPath))
            {
                testSettingsConfigBuilder.AddJsonFile(testSettingsUserPath);
            }

            IConfiguration config = testSettingsConfigBuilder.Build();

            // This will set the values from the above config files into the TestSettings Instance.
            Instance = config.Get<TestSettings>();

            // Override the test mode if the test mode environment variable was specified.
            string testModeEnvVariable = Environment.GetEnvironmentVariable(TestModeEnvVariable);
            if (!string.IsNullOrEmpty(testModeEnvVariable))
            {
                Instance.TestMode = (RecordedTestMode)Enum.Parse(
                    typeof(RecordedTestMode),
                    testModeEnvVariable);
            }

            Instance.WorkingDirectory = workingDirectory;
        }
    }
}
