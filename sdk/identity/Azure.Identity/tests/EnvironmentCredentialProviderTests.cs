// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Reflection;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using System.Threading.Tasks;

namespace Azure.Identity.Tests
{
    public class EnvironmentCredentialProviderTests : ClientTestBase
    {
        public EnvironmentCredentialProviderTests(bool isAsync) : base(isAsync)
        {
        }

        [NonParallelizable]
        [Test]
        public void CredentialConstructionClientSecret()
        {
            string clientIdBackup = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
            string tenantIdBackup = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
            string clientSecretBackup = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");

            try
            {
                Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", "mockclientid");

                Environment.SetEnvironmentVariable("AZURE_TENANT_ID", "mocktenantid");

                Environment.SetEnvironmentVariable("AZURE_CLIENT_SECRET", "mockclientsecret");

                var provider = new EnvironmentCredential();

                ClientSecretCredential cred =_credential(provider) as ClientSecretCredential;

                Assert.NotNull(cred);

                Assert.AreEqual("mockclientid", cred.ClientId);

                Assert.AreEqual("mocktenantid", cred.TenantId);

                Assert.AreEqual("mockclientsecret", cred.ClientSecret);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", clientIdBackup);
                Environment.SetEnvironmentVariable("AZURE_TENANT_ID", tenantIdBackup);
                Environment.SetEnvironmentVariable("AZURE_CLIENT_SECRET", clientSecretBackup);
            }
        }

        [NonParallelizable]
        [Test]
        public void CredentialConstructionClientCertificate()
        {
            string clientIdBackup = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
            string tenantIdBackup = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
            string clientCertificateLocationBackup = Environment.GetEnvironmentVariable("AZURE_CLIENT_CERTIFICATE_PATH");

            try
            {
                Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", "mockclientid");
                Environment.SetEnvironmentVariable("AZURE_TENANT_ID", "mocktenantid");
                Environment.SetEnvironmentVariable("AZURE_CLIENT_CERTIFICATE_PATH", "mockcertificatepath");

                var provider = new EnvironmentCredential();
                var cred = _credential(provider) as ClientCertificateCredential;
                var certProvider = cred.ClientCertificateProvider as ClientCertificateCredential.X509Certificate2FromFileProvider;

                Assert.NotNull(cred);
                Assert.NotNull(certProvider);
                Assert.AreEqual("mockclientid", cred.ClientId);
                Assert.AreEqual("mocktenantid", cred.TenantId);
                Assert.AreEqual("mockcertificatepath", certProvider.CertificatePath);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", clientIdBackup);
                Environment.SetEnvironmentVariable("AZURE_TENANT_ID", tenantIdBackup);
                Environment.SetEnvironmentVariable("AZURE_CLIENT_CERTIFICATE_PATH", clientCertificateLocationBackup);
            }
        }

        [Test]
        public async Task EnvironmentCredentialUnavailableException()
        {
            var credential = InstrumentClient(new EnvironmentCredential(CredentialPipeline.GetInstance(null), null));

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            await Task.CompletedTask;
        }

        [Test]
        public async Task EnvironmentCredentialAuthenticationFailedException()
        {
            string expectedInnerExMessage = Guid.NewGuid().ToString();

            var mockMsalClient = new MockMsalConfidentialClient(new MockClientException(expectedInnerExMessage));

            ClientSecretCredential innerCred = new ClientSecretCredential(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), CredentialPipeline.GetInstance(null), mockMsalClient);

            var credential = InstrumentClient(new EnvironmentCredential(CredentialPipeline.GetInstance(null), innerCred));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            Assert.AreEqual(expectedInnerExMessage, ex.InnerException.Message);

            await Task.CompletedTask;
        }

        public static TokenCredential _credential(EnvironmentCredential provider)
        {
            return (TokenCredential)typeof(EnvironmentCredential).GetField("_credential", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(provider);
        }
    }
}
