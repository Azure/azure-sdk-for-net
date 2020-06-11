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

        private static readonly string s_adtInstanceEndpointUrlEnv = $"{AdtEnvironmentVariablesPrefix}_ADT_INSTANCE_ENDPOINT_URL";
        private static readonly string s_applicationTenantIdEnv = $"{AdtEnvironmentVariablesPrefix}_TENANT_ID";
        private static readonly string s_applicationClientIdEnv = $"{AdtEnvironmentVariablesPrefix}_CLIENT_ID";
        private static readonly string s_applicationClientSecretEnv = $"{AdtEnvironmentVariablesPrefix}_CLIENT_SECRET";
        private static readonly string s_digitalTwinHostnameEnv = $"{AdtEnvironmentVariablesPrefix}_URL";
        private static readonly string s_digitalTwinTestMode = $"AZURE_IOT_TEST_MODE";

        public static TestSettings Instance { get; private set; }

        public RecordedTestMode TestMode { get; set; }

        /// <summary>
        /// The working directory of the tests.
        /// </summary>
        public string WorkingDirectory { get; private set; }

        /// <summary>
        /// Host name of the digital twin instance to connect to.
        /// </summary>
        public string DigitalTwinsInstanceHostName { get; set; }

        /// <summary>
        /// Application ID created to authenticate to the digital twin instance.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Application registration client secret.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Microsoft tenent ID.
        /// </summary>
        public string MicrosoftTenantId { get; set; }

        /// <summary>
        /// The audience of digital twin for which we need to get an access token.
        /// </summary>
        public string DigitalTwinsAudience { get; set; }

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

            // We will override settings if they can be found in the environment variables.
            OverrideFromEnvVariables();
        }

        private static void OverrideFromEnvVariables()
        {
            string envAdtEndpoint = Environment.GetEnvironmentVariable(s_adtInstanceEndpointUrlEnv);
            if (!string.IsNullOrWhiteSpace(envAdtEndpoint))
            {
                Instance.DigitalTwinsInstanceHostName = envAdtEndpoint;
            }

            // Add the following three values to Environment Variables(if not present) as the test framework expects these to be present.

            string envTenantId = Environment.GetEnvironmentVariable(s_applicationTenantIdEnv);
            if (!string.IsNullOrWhiteSpace(envTenantId))
            {
                Instance.MicrosoftTenantId = envTenantId;
            }
            else
            {
                Environment.SetEnvironmentVariable(s_applicationTenantIdEnv, Instance.MicrosoftTenantId);
            }

            string envApplicationId = Environment.GetEnvironmentVariable(s_applicationClientIdEnv);
            if (!string.IsNullOrWhiteSpace(envApplicationId))
            {
                Instance.ApplicationId = envApplicationId;
            }
            else
            {
                Environment.SetEnvironmentVariable(s_applicationClientIdEnv, Instance.ApplicationId);
            }

            string envClientSecret = Environment.GetEnvironmentVariable(s_applicationClientSecretEnv);
            if (!string.IsNullOrWhiteSpace(envClientSecret))
            {
                Instance.ClientSecret = envClientSecret;
            }
            else
            {
                Environment.SetEnvironmentVariable(s_applicationClientSecretEnv, Instance.ClientSecret);
            }

            string digitalTwinHostname = Environment.GetEnvironmentVariable(s_digitalTwinHostnameEnv);
            if (!string.IsNullOrWhiteSpace(digitalTwinHostname))
            {
                Instance.DigitalTwinsInstanceHostName = digitalTwinHostname;
            }
            else
            {
                Environment.SetEnvironmentVariable(s_digitalTwinHostnameEnv, Instance.DigitalTwinsInstanceHostName);
            }

            string testMode = Environment.GetEnvironmentVariable(s_digitalTwinTestMode);
            if (!string.IsNullOrWhiteSpace(testMode))
            {
                // Enum.Parse<type>(value) cannot be used in net461 so using the type casting syntax.
                Instance.TestMode = (RecordedTestMode)Enum.Parse(typeof(RecordedTestMode), testMode);
            }
            else
            {
                Environment.SetEnvironmentVariable(s_digitalTwinTestMode, Instance.TestMode.ToString());
            }
        }
    }
}
