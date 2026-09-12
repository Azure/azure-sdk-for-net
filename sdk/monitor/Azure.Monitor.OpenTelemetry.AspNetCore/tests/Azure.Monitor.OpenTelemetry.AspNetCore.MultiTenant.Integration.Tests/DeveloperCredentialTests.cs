// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    [NonParallelizable]
    public class DeveloperCredentialTests
    {
        [TestCase("true", RecordedTestMode.Live, false, false, typeof(AzurePowerShellCredential))]
        [TestCase("TRUE", RecordedTestMode.Live, false, false, typeof(AzurePowerShellCredential))]
        [TestCase("false", RecordedTestMode.Live, false, false, null)]
        [TestCase("", RecordedTestMode.Live, false, false, null)]
        [TestCase("true", RecordedTestMode.Playback, false, false, typeof(MockCredential))]
        [TestCase("true", RecordedTestMode.Live, true, false, typeof(ClientSecretCredential))]
        [TestCase("true", RecordedTestMode.Live, false, true, typeof(AzurePipelinesCredential))]
        [TestCase("true", RecordedTestMode.Live, true, true, typeof(ClientSecretCredential))]
        public void PreservesCredentialPrecedence(string optIn, RecordedTestMode mode, bool clientSecret, bool pipelineToken, Type? expectedType)
        {
            var variables = new Dictionary<string, string>
            {
                ["MONITOR_USE_AZURE_POWERSHELL_CREDENTIAL"] = optIn,
                ["MONITOR_CLIENT_SECRET"] = clientSecret ? "test-only-not-used" : string.Empty,
                ["MONITOR_SYSTEM_ACCESSTOKEN"] = pipelineToken ? "test-only-not-used" : string.Empty,
                ["MONITOR_TENANT_ID"] = "00000000-0000-0000-0000-000000000001",
                ["MONITOR_CLIENT_ID"] = "00000000-0000-0000-0000-000000000002",
                ["MONITOR_AZURE_AUTHORITY_HOST"] = "https://login.microsoftonline.com/",
                ["MONITOR_AZURESUBSCRIPTION_TENANT_ID"] = "00000000-0000-0000-0000-000000000001",
                ["MONITOR_AZURESUBSCRIPTION_CLIENT_ID"] = "00000000-0000-0000-0000-000000000002",
                ["MONITOR_AZURESUBSCRIPTION_SERVICE_CONNECTION_ID"] = "00000000-0000-0000-0000-000000000003"
            };
            var previous = variables.Keys.ToDictionary(name => name, Environment.GetEnvironmentVariable);
            try
            {
                foreach (var variable in variables)
                {
                    Environment.SetEnvironmentVariable(variable.Key, variable.Value);
                }

                var environment = new AzureMonitorTestEnvironment { Mode = mode };
                if (expectedType == null)
                {
                    Assert.That(environment.Credential, Is.Not.TypeOf<AzurePowerShellCredential>());
                }
                else
                {
                    Assert.That(environment.Credential, Is.TypeOf(expectedType));
                }
            }
            finally
            {
                foreach (var variable in previous)
                {
                    Environment.SetEnvironmentVariable(variable.Key, variable.Value);
                }
            }
        }
    }
}
#endif