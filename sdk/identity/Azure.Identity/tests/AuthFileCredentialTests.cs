// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Management;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AuthFileCredentialTests : ClientTestBase
    {
        public AuthFileCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task SdkAuthFileEnsureCredentialParsesCorrectly()
        {
            var credential = new AuthFileCredential(Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "authfile.json"));
            var innerCredential = await _credential(credential);

            ClientSecretCredential cred = innerCredential as ClientSecretCredential;
            Assert.NotNull(cred);
            Assert.AreEqual("mockclientid", cred.ClientId);
            Assert.AreEqual("mocktenantid", cred.TenantId);
            Assert.AreEqual("mockclientsecret", cred.ClientSecret);
        }

        [Test]
        public Task BadSdkAuthFilePathThrowsDuringGetToken()
        {
            var credential = new AuthFileCredential("Bougs*File*Path");

            if (IsAsync)
            {
                Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new string[] { "https://mock.scope/.default/" }, null), default(CancellationToken)).ConfigureAwait(false));
            }
            else
            {
                Assert.Throws<AuthenticationFailedException>(() => credential.GetToken(new TokenRequestContext(new string[] { "https://mock.scope/.default/" }, null), default(CancellationToken)));
            }

            return Task.CompletedTask;
        }

        public async Task<TokenCredential> _credential(AuthFileCredential provider)
        {
            await provider.EnsureCredential(IsAsync, default);
            return (TokenCredential)typeof(AuthFileCredential).GetField("_credential", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(provider);
        }
    }
}
