using Azure.Core;
using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity.Tests
{
    public class DeviceCodeCredentialLiveTests : RecordedTestBase
    {
        private const string MultiTenantClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        private const string SingleTenantClientId = "9985250a-c1c3-4caf-a039-9d98f2a0707a";
        private const string TenantId = "a7fc734e-9961-43ce-b4de-21b8b38403ba";

        public DeviceCodeCredentialLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        public Task PrintDeviceCode(DeviceCodeInfo code, CancellationToken cancellationToken)
        {
            Debug.WriteLine(code.Message);

            return Task.CompletedTask;
        }

        [Test]
        public async Task AuthenticateWithDeviceCodeMockAsync()
        {
            var cred = CreateDeviceCodeCredential((code, cancelToken) => PrintDeviceCode(code, cancelToken), MultiTenantClientId);

            AccessToken token = await cred.GetTokenAsync(new string[] { "https://vault.azure.net/.default" });

            Assert.NotNull(token.Token);
        }


        private DeviceCodeCredential CreateDeviceCodeCredential(Func<DeviceCodeInfo, CancellationToken, Task> deviceCodeCallback, string clientId, string tenantId = default, IdentityClientOptions options = default, TestRecording recording = null)
        {
            recording ??= Recording;
            options ??= new IdentityClientOptions();
            return InstrumentClient
                (new DeviceCodeCredential(
                    deviceCodeCallback,
                    clientId, 
                    tenantId,
                    recording.InstrumentClientOptions(options)));
        }
    }
}
