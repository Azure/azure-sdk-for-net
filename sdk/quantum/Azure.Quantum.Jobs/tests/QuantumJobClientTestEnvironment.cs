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
        private bool _initialized = false;
        private readonly Lazy<AzLoginAccessTokenInfo> _azLoginAccessTokenInfo = new Lazy<AzLoginAccessTokenInfo>(QuantumJobClientTestEnvironment.GetAzLoginAccessTokenInfo);

        public string WorkspaceName => GetRecordedVariable("WORKSPACE_NAME");

        public string GetRandomId(string idName)
        {
            var randomId = Guid.NewGuid().ToString("N");
            var randomIdVariableName = $"RANDOM_ID_{idName}";
            if (Mode == RecordedTestMode.Record)
            {
                Environment.SetEnvironmentVariable(randomIdVariableName, randomId);
            }
            return GetRecordedVariable(randomIdVariableName);
        }

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
        }

        public void Initialize()
        {
            if (!_initialized
                && Mode == RecordedTestMode.Record
                && (GetOrSetVariable("LOCAL_RECORDING") != null))
            {
                GetOrSetVariable("SUBSCRIPTION_ID", _azLoginAccessTokenInfo.Value.SubscriptionId);
                GetOrSetVariable("TENANT_ID", _azLoginAccessTokenInfo.Value.TenantId);
                GetOrSetVariable("LOCATION", "westus");
                GetOrSetVariable("ENVIRONMENT", "Prod");
                _initialized = true;
            }
        }

        private string GetOrSetVariable(string variableName, string defaultValue = null)
        {
            var value = Environment.GetEnvironmentVariable(variableName);
            if (value == null)
            {
                value = defaultValue;
                Environment.SetEnvironmentVariable(variableName, value);
            }
            return value;
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
                    UseShellExecute = false,
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
