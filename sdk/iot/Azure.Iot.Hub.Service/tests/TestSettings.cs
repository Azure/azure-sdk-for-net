// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Azure.Iot.Hub.Service.Tests
{
    public class TestSettings
    {
        public const string IotHubEnvironmentVariablesPrefix = "IOTHUB";

        public static TestSettings Instance { get; private set; }

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


            // TODO: Find out why the Microsoft.Extensions.Configuration.Binder package does not have a version specified in the Packages.Data.props
            // IConfiguration config = testSettingsConfigBuilder.Build();
            // Instance = config.Get<TestSettings>();
            Instance = new TestSettings();
            Instance.WorkingDirectory = workingDirectory;

            // We will override settings if they can be found in the environment variables.
            OverrideFromEnvVariables();
        }

        private static void OverrideFromEnvVariables()
        {
            // TODO: Will add necessary overrides based on what the tests need.
        }
    }
}
