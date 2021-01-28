// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Newtonsoft.Json;

namespace Azure.Quantum.Jobs.Tests
{
    public class QuantumJobClientTestEnvironment : TestEnvironment
    {
        private readonly Lazy<AzLoginAccessTokenInfo> _azLoginAccessTokenInfo = new Lazy<AzLoginAccessTokenInfo>(QuantumJobClientTestEnvironment.GetAzLoginAccessTokenInfo);

        public string WorkspaceName => GetRecordedVariable("WORKSPACE_NAME");

        public new TokenCredential Credential
        {
            get
            {
                if (Mode == RecordedTestMode.Record)
                {
                    return new AzureCliCredential();
                }
                return base.Credential;
            }
        }

        public QuantumJobClientTestEnvironment()
        {
            if (Mode == RecordedTestMode.Record)
            {
                if (Environment.GetEnvironmentVariable("SUBSCRIPTION_ID") == null)
                {
                    Environment.SetEnvironmentVariable("SUBSCRIPTION_ID", _azLoginAccessTokenInfo.Value.SubscriptionId);
                }
                if (Environment.GetEnvironmentVariable("TENANT_ID") == null)
                {
                    Environment.SetEnvironmentVariable("TENANT_ID", _azLoginAccessTokenInfo.Value.TenantId);
                }
                if (Environment.GetEnvironmentVariable("LOCATION") == null)
                {
                    Environment.SetEnvironmentVariable("LOCATION", "westus");
                }
                if (Environment.GetEnvironmentVariable("ENVIRONMENT") == null)
                {
                    Environment.SetEnvironmentVariable("ENVIRONMENT", "Prod");
                }
            }
        }

        private class AzLoginAccessTokenInfo : TokenCredential
        {
            [JsonProperty("subscription")]
            public string SubscriptionId { get; set; }

            [JsonProperty("tenant")]
            public string TenantId { get; set; }

            [JsonProperty("accessToken")]
            public string AccessToken { get; set; }

            [JsonProperty("expiresOn")]
            public DateTimeOffset ExpiresOn { get; set; }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new AccessToken(AccessToken, ExpiresOn);
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(new AccessToken(AccessToken, ExpiresOn));
            }
        }

        private static AzLoginAccessTokenInfo GetAzLoginAccessTokenInfo()
        {
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            if (!isWindows)
            {
                return null;
            }

            var azProcess = new Process()
            {
                StartInfo = new ProcessStartInfo("cmd.exe", "/c az account get-access-token")
                {
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                }
            };
            azProcess.Start();
            azProcess.WaitForExit();
            var azProcessOutput = azProcess.StandardOutput.ReadToEnd();
            var accessTokenInfo = JsonConvert.DeserializeObject<AzLoginAccessTokenInfo>(azProcessOutput);
            return accessTokenInfo;
        }
    }
}
