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
    /// These are the settings that will be used by the end-to-end tests tests.
    /// The json files configured in the config will load the settings specific to a user.
    /// </summary>
    public class TestSettings
    {
        public static TestSettings Instance { get; private set; }

        public RecordedTestMode TestMode { get; set; }

        /// <summary>
        /// The working directory of the tests.
        /// </summary>
        public string WorkingDirectory { get; private set; }

        /// <summary>
        /// The IoT Hub instance connection string.
        /// </summary>
        public string IotHubConnectionString { get; set; }

        /// <summary>
        /// The IoT Hub instance hostName.
        /// </summary>
        public string IotHubHostName { get; set; }

        static TestSettings()
        {
            if (Instance != null)
            {
                return;
            }

            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string workingDirectory = Path.GetDirectoryName(path);

            string userName = Environment.UserName;

            // Initialize the settings related to IoT Hub instance and auth
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
            Instance.WorkingDirectory = workingDirectory;

            // We will override settings if they can be found in the environment variables.
            OverrideFromEnvVariables();
        }

        // These environment variables are required to be set to run tests against the CI pipeline.
        private static void OverrideFromEnvVariables()
        {
            string iotHubConnectionString = Environment.GetEnvironmentVariable(TestsConstants.IOT_HUB_CONNECTION_STRING);
            if (!string.IsNullOrWhiteSpace(iotHubConnectionString))
            {
                Instance.IotHubConnectionString = iotHubConnectionString;
            }
            else
            {
                Environment.SetEnvironmentVariable(TestsConstants.IOT_HUB_CONNECTION_STRING, Instance.IotHubConnectionString);
            }

            string testMode = Environment.GetEnvironmentVariable(TestsConstants.IOT_HUB_TESTMODE);
            if (!string.IsNullOrWhiteSpace(testMode))
            {
                // Enum.Parse<type>(value) cannot be used in net461 so using the type casting syntax.
                Instance.TestMode = (RecordedTestMode)Enum.Parse(typeof(RecordedTestMode), testMode);
            }
            else
            {
                Environment.SetEnvironmentVariable(TestsConstants.IOT_HUB_TESTMODE, Instance.TestMode.ToString());
            }
        }
    }
}
