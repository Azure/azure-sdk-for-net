// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    public partial class ManualInteractiveBrowserCredentialBrokerTests
    {
        private static TokenRequestContext context = new TokenRequestContext(new string[] { "https://vault.azure.net/.default" });

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task AuthenticateWithBrokerAsync()
        {
            IntPtr parentWindowHandle = GetForegroundWindow();

            // to fully manually verify the InteractiveBrowserCredential this test should be run both authenticating with a
            // school / organization account as well as a personal live account, i.e. a @outlook.com, @live.com, or @hotmail.com
            var cred = new InteractiveBrowserCredential(new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle));

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" })).ConfigureAwait(false);

            Assert.NotNull(token.Token);
        }

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task AuthenticateWithBrokerWithUseOperatingSystemAccount_DoesNotPrompt()
        {
            IntPtr parentWindowHandle = GetForegroundWindow();

            var cred = new InteractiveBrowserCredential(new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle) { UseDefaultBrokerAccount = true });

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" })).ConfigureAwait(false);

            Assert.NotNull(token.Token);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task GetPopToken(bool isAsync)
        {
            using var logger = AzureEventSourceListener.CreateConsoleLogger();
            IntPtr parentWindowHandle = GetForegroundWindow();

            var client = new PopTestClient(new InteractiveBrowserCredential(
                new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle)),
                new PopClientOptions() { Diagnostics = { IsLoggingContentEnabled = true, LoggedHeaderNames = { "Authorization" } } });
            var response = isAsync ?
                await client.GetAsync(new Uri("https://graph.microsoft.com/v1.0/me"), CancellationToken.None) :
                client.Get(new Uri("https://graph.microsoft.com/v1.0/me"), CancellationToken.None);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Status);

            response = isAsync ?
                await client.GetAsync(new Uri("https://graph.microsoft.com/v1.0/me"), CancellationToken.None) :
                client.Get(new Uri("https://graph.microsoft.com/v1.0/me"), CancellationToken.None);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Status);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task GetPopTokenWithAuthenticate(bool isAsync)
        {
            using var logger = AzureEventSourceListener.CreateConsoleLogger();
            IntPtr parentWindowHandle = GetForegroundWindow();

            // Issue the unauthorized request to get the PoP challenge
            var scopes = new[] { "https://graph.microsoft.com/.default" };
            string nonce = null;
            Uri resourceUri = new Uri("https://graph.microsoft.com/v1.0/me");
            string nonceToken = "nonce=\"";
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (_, _, _, _) => true
            };
            HttpClient httpClient = new(handler);
            var resp = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, resourceUri));
            // parse the nonce
            var popChallenge = resp.Headers.WwwAuthenticate.First(wa => wa.Scheme == "PoP");
            var nonceStart = popChallenge.Parameter.IndexOf(nonceToken) + nonceToken.Length;
            var nonceEnd = popChallenge.Parameter.IndexOf('"', nonceStart);
            nonce = popChallenge.Parameter.Substring(nonceStart, nonceEnd - nonceStart);

            InteractiveBrowserCredential credential = new InteractiveBrowserCredential(
                            new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle));

            var client = new PopTestClient(
                credential,
                new PopClientOptions() { Diagnostics = { IsLoggingContentEnabled = true, LoggedHeaderNames = { "Authorization" } } });

            using Request request = new MockRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(resourceUri);

            var popContext = new TokenRequestContext(scopes, proofOfPossessionNonce: nonce, requestUri: request.Uri.ToUri(), requestMethod: request.Method.ToString());
            // this should pop browser amd validate the AuthenticateAsync path.
            var record = await credential.AuthenticateAsync(popContext).ConfigureAwait(false);
            credential.Record = record;

            var response = isAsync ?
                await client.GetAsync(resourceUri, CancellationToken.None) :
                client.Get(resourceUri, CancellationToken.None);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Status);
        }

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public void AuthenticateWithBrokerAsyncWithSTA([Values(true, false)] bool isAsync)
        {
            var assemblies = System.Reflection.Assembly.GetExecutingAssembly().GetReferencedAssemblies().FirstOrDefault(a => a.Name == "System.Windows.Forms");
            if (assemblies != null)
            {
                throw new Exception("has winforms");
            }
            ManualResetEventSlim evt = new();
            Thread thread = new Thread(async () =>
            {
                // do something with retVal

                Console.WriteLine($"Thread {Thread.CurrentThread.GetApartmentState()}");
                IntPtr parentWindowHandle = GetForegroundWindow();
                var options = new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle)
                {
                    TokenCachePersistenceOptions = new()
                };

                var cred = new InteractiveBrowserCredential(options);
                var authRecord = isAsync ? await cred.AuthenticateAsync(context) : cred.Authenticate(context);
                options.AuthenticationRecord = authRecord;
                AccessToken token = isAsync ? await cred.GetTokenAsync(context).ConfigureAwait(false) : cred.GetToken(context);
                Console.WriteLine("got token");
                evt.Set();
            });

            Thread thread2 = new Thread(async () =>
            {
                // do something with retVal

                Console.WriteLine($"Thread {Thread.CurrentThread.GetApartmentState()}");
                IntPtr parentWindowHandle = GetForegroundWindow();
                var options = new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle)
                {
                    TokenCachePersistenceOptions = new()
                };

                var cred = new InteractiveBrowserCredential(options);
                var authRecord = isAsync ? await cred.AuthenticateAsync(context) : cred.Authenticate(context);
                options.AuthenticationRecord = authRecord;
                AccessToken token = isAsync ? await cred.GetTokenAsync(context).ConfigureAwait(false) : cred.GetToken(context);
                Console.WriteLine("got token");
                thread.Start();
            });
#pragma warning disable CA1416 // Validate platform compatibility
            thread.SetApartmentState(ApartmentState.STA);
            thread2.SetApartmentState(ApartmentState.STA);
#pragma warning restore CA1416 // Validate platform compatibility
            thread2.Start();
            evt.Wait(10000);
        }
    }
}
