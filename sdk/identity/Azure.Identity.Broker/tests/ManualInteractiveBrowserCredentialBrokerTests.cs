// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    public class ManualInteractiveBrowserCredentialBrokerTests
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

            var cred = new InteractiveBrowserCredential(new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle) { UseOperatingSystemAccount = true });

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
                new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle) { IsProofOfPossessionRequired = true }),
                new PopClientOptions() { Diagnostics = { IsLoggingContentEnabled = true, LoggedHeaderNames = { "Authorization" } } });
            var response = isAsync ?
                await client.GetAsync(new Uri("https://20.190.132.47/beta/me"), CancellationToken.None) :
                client.Get(new Uri("https://20.190.132.47/beta/me"), CancellationToken.None);
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
