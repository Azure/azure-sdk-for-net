// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;

namespace Azure.DigitalTwins.Core.Tests
{
    /// <summary>
    /// These are the settings that will be used by the end-to-end tests tests.
    /// The json files configured in the config will load the settings specific to a user.
    /// </summary>
    public class TestSettings
    {
        public const string AdtEnvironmentVariablesPrefix = "DIGITALTWINS";

        // If these environment variables exist in the environment, their values will replace (supersede) config.json values.

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

            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string workingDirectory = Path.GetDirectoryName(path);

            string userName = Environment.UserName;

            // Initialize the settings related to DT instance and auth
            var testSettingsConfigBuilder = new ConfigurationBuilder();

            string testSettingsCommonPath = Path.Combine(workingDirectory, "config", "common.config.json");
            testSettingsConfigBuilder.AddJsonFile(testSettingsCommonPath);

            string testSettingsUserPath = Path.Combine(workingDirectory, "config", $"{userName}.config.json");
            if (File.Exists(testSettingsUserPath))
            {
                testSettingsConfigBuilder.AddJsonFile(testSettingsUserPath);
            }

            IConfiguration config = testSettingsConfigBuilder.Build();

            Instance = config.Get<TestSettings>();
            Instance.WorkingDirectory = workingDirectory;
        }
    }
}
