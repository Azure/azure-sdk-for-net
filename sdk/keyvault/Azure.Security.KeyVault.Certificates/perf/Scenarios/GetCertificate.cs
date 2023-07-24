// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Certificates.Perf.Infrastructure;
using Azure.Test.Perf;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Perf.Scenarios
{
    public sealed class GetCertificate : CertificatesScenarioBase<PerfOptions>
    {
        private string _certificateName;

        public GetCertificate(PerfOptions options) : base(options)
        {
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            _certificateName = GetRandomName("c-");
            CertificateOperation operation = await Client.StartCreateCertificateAsync(_certificateName, new(WellKnownIssuerNames.Self, "CN=Azure SDK")
            {
                KeyType = CertificateKeyType.Rsa,
                ContentType = CertificateContentType.Pem,
            });

            await operation.WaitForCompletionAsync();
        }

        public override async Task GlobalCleanupAsync()
        {
            await DeleteCertificatesAsync(_certificateName);

            await base.GlobalCleanupAsync();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            KeyVaultCertificate certificate = Client.GetCertificate(_certificateName);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            KeyVaultCertificate certificate = await Client.GetCertificateAsync(_certificateName);
        }
    }
}
