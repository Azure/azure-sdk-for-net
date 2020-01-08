// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using Azure.Core.Testing;
using Azure.Identity.Tests.Mock;
using System.Threading.Tasks;
using System.IO;

namespace Azure.Identity.Tests
{
    public class EnvironmentCredentialProviderTests : ClientTestBase
    {
        public EnvironmentCredentialProviderTests(bool isAsync) : base(isAsync)
        {
        }

        [NonParallelizable]
        [Test]
        public void CredentialConstructionClientId()
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
        public void CredentialConstructionAuthLocation()
        {
            string authLocationBackup = Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION");
            string pathToFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "authfile.json");

            try
            {
                Environment.SetEnvironmentVariable("AZURE_AUTH_LOCATION", pathToFile);

                var provider = new EnvironmentCredential();
                AuthFileCredential cred = _credential(provider) as AuthFileCredential;

                Assert.NotNull(cred);
                Assert.AreEqual(pathToFile, cred.FilePath);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_AUTH_LOCATION", authLocationBackup);
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

            var mockAadClient = new MockAadIdentityClient(() => { throw new MockClientException(expectedInnerExMessage); });

            ClientSecretCredential innerCred = new ClientSecretCredential(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), CredentialPipeline.GetInstance(null), mockAadClient);

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
