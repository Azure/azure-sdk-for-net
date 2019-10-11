// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class CertificatesTestBase : RecordedTestBase
    {
        public const string AzureKeyVaultUrlEnvironmentVariable = "AZURE_KEYVAULT_URL";
        private readonly HashSet<string> _toCleanup = new HashSet<string>();

        public CertificateClient Client { get; set; }

        public Uri VaultUri { get; set; }

        public CertificatesTestBase(bool isAsync) : base(isAsync)
        {
        }

        internal CertificateClient GetClient(TestRecording recording = null)
        {
            recording ??= Recording;

            return InstrumentClient
                (new CertificateClient(
                    new Uri(recording.GetVariableFromEnvironment(AzureKeyVaultUrlEnvironmentVariable)),
                    recording.GetCredential(new DefaultAzureCredential()),
                    recording.InstrumentClientOptions(new CertificateClientOptions())));
        }

        public override void StartTestRecording()
        {
            base.StartTestRecording();

            Client = GetClient();
            VaultUri = new Uri(Recording.GetVariableFromEnvironment(AzureKeyVaultUrlEnvironmentVariable));
        }

        [OneTimeTearDown]
        public async Task CleanupCertificates()
        {
            List<Task> cleanupTasks = new List<Task>();

            foreach (string certName in _toCleanup)
            {
                cleanupTasks.Add(WaitForDeletedCertificate(certName).ContinueWith(t => Client.PurgeDeletedCertificateAsync(certName)));
            }

            await Task.WhenAll(cleanupTasks);
        }

        protected async Task CleanupCertificate(string name)
        {
            await Client.DeleteCertificateAsync(name);

            await WaitForDeletedCertificate(name);

            await Client.PurgeDeletedCertificateAsync(name);
        }

        protected async Task<CertificateWithPolicy> WaitForCompletion(CertificateOperation operation)
        {
            TimeSpan pollingInterval = TimeSpan.FromSeconds((Mode == RecordedTestMode.Playback) ? 0 : 1);

            if (IsAsync)
            {
                await operation.WaitForCompletionAsync();
            }
            else
            {
                while (!operation.HasValue)
                {
                    operation.UpdateStatus();

                    await Task.Delay(pollingInterval);
                }
            }

            return operation.Value;
        }

        protected Task WaitForDeletedCertificate(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return Task.CompletedTask;
            }

            using (Recording.DisableRecording())
            {
                return TestRetryHelper.RetryAsync(async () => await Client.GetDeletedCertificateAsync(name));
            }
        }

        protected Task WaitForPurgedCertificate(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return Task.CompletedTask;
            }

            using (Recording.DisableRecording())
            {
                return TestRetryHelper.RetryAsync(async () =>
                {
                    try
                    {
                        await Client.GetDeletedCertificateAsync(name);
                        throw new InvalidOperationException("Key still exists");
                    }
                    catch
                    {
                        return (Response)null;
                    }
                });
            }
        }

        protected Task PollForCertificate(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return Task.CompletedTask;
            }

            using (Recording.DisableRecording())
            {
                return TestRetryHelper.RetryAsync(async () => await Client.GetCertificateAsync(name));
            }
        }

        protected void RegisterForCleanup(string certificateName)
        {
            lock (_toCleanup)
            {
                _toCleanup.Add(certificateName);
            }
        }
    }
}
