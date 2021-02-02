// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Reflection;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using System.Threading.Tasks;
using System.Collections.Generic;

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

                ClientSecretCredential cred = provider.Credential as ClientSecretCredential;

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
            using (new TestEnvVar(new ()
            {
                { "AZURE_CLIENT_ID", "mockclientid" },
                { "AZURE_TENANT_ID", "mocktenantid" },
                { "AZURE_CLIENT_CERTIFICATE_PATH", "mockcertificatepath" }
            }))
            {
                var provider = new EnvironmentCredential();
                var cred = provider.Credential as ClientCertificateCredential;
                Assert.NotNull(cred);
                Assert.AreEqual("mockclientid", cred.ClientId);
                Assert.AreEqual("mocktenantid", cred.TenantId);

                var certProvider = cred.ClientCertificateProvider as ClientCertificateCredential.X509Certificate2FromFileProvider;

                Assert.NotNull(certProvider);
                Assert.AreEqual("mockcertificatepath", certProvider.CertificatePath);
            }
        }

        [Test]
        public void EnvironmentCredentialUnavailableException()
        {
            var credential = InstrumentClient(new EnvironmentCredential(CredentialPipeline.GetInstance(null), null));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
        }

        [Test]
        public async Task EnvironmentCredentialAuthenticationFailedException()
        {
            string expectedInnerExMessage = Guid.NewGuid().ToString();

            var mockMsalClient = new MockMsalConfidentialClient(new MockClientException(expectedInnerExMessage));

            ClientSecretCredential innerCred = new ClientSecretCredential(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), default, default, mockMsalClient);

            var credential = InstrumentClient(new EnvironmentCredential(CredentialPipeline.GetInstance(null), innerCred));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            Assert.AreEqual(expectedInnerExMessage, ex.InnerException.Message);

            await Task.CompletedTask;
        }

        public static IEnumerable<object[]> AssertCredentialUnavailableWhenEmptyStringEnvironmentSettings()
        {
            yield return new object[] { new Dictionary<string, string> { { "AZURE_CLIENT_ID", string.Empty }, { "AZURE_CLIENT_SECRET", "mockclientsecret" }, { "AZURE_TENANT_ID", "mocktenantid" } } };
            yield return new object[] { new Dictionary<string, string> { { "AZURE_CLIENT_ID", "mockclientid" }, { "AZURE_CLIENT_SECRET", string.Empty }, { "AZURE_TENANT_ID", "mocktenantid" } } };
            yield return new object[] { new Dictionary<string, string> { { "AZURE_CLIENT_ID", "mockclientid" }, { "AZURE_CLIENT_SECRET", "mockclientsecret" }, { "AZURE_TENANT_ID", string.Empty } } };
            yield return new object[] { new Dictionary<string, string> { { "AZURE_CLIENT_ID", string.Empty }, { "AZURE_CLIENT_CERTIFICATE_PATH", "mockcertpath" }, { "AZURE_TENANT_ID", "mocktenantid" } } };
            yield return new object[] { new Dictionary<string, string> { { "AZURE_CLIENT_ID", "mockclientid" }, { "AZURE_CLIENT_CERTIFICATE_PATH", string.Empty }, { "AZURE_TENANT_ID", "mocktenantid" } } };
            yield return new object[] { new Dictionary<string, string> { { "AZURE_CLIENT_ID", "mockclientid" }, { "AZURE_CLIENT_CERTIFICATE_PATH", "mockcertpath" }, { "AZURE_TENANT_ID", string.Empty } } };
            yield return new object[] { new Dictionary<string, string> { { "AZURE_USERNAME", string.Empty }, { "AZURE_PASSWORD", "mockpassword" }, { "AZURE_TENANT_ID", "mocktenantid" }, { "AZURE_CLIENT_ID", "mockclientid" } } };
            yield return new object[] { new Dictionary<string, string> { { "AZURE_USERNAME", "mockusername" }, { "AZURE_PASSWORD", string.Empty }, { "AZURE_TENANT_ID", "mocktenantid" }, { "AZURE_CLIENT_ID", "mockclientid" } } };
            yield return new object[] { new Dictionary<string, string> { { "AZURE_USERNAME", "mockusername" }, { "AZURE_PASSWORD", "mockpassword" }, { "AZURE_TENANT_ID", string.Empty }, { "AZURE_CLIENT_ID", "mockclientid" } } };
            yield return new object[] { new Dictionary<string, string> { { "AZURE_USERNAME", "mockusername" }, { "AZURE_PASSWORD", "mockpassword" }, { "AZURE_TENANT_ID", "mocktenantid" }, { "AZURE_CLIENT_ID", string.Empty } } };
        }

        [NonParallelizable]
        [Test]
        [TestCaseSource(nameof(AssertCredentialUnavailableWhenEmptyStringEnvironmentSettings))]
        public void AssertCredentialUnavailableWhenEmptyString(Dictionary<string, string> environmentVars)
        {
            using (new TestEnvVar(environmentVars))
            {
                var credential = InstrumentClient(new EnvironmentCredential());

                Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            }
        }
    }
}
