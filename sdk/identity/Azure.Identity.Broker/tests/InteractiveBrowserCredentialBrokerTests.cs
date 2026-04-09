// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    internal class InteractiveBrowserCredentialBrokerTests
    {
        public class ExtendedInteractiveBrowserCredentialOptions : InteractiveBrowserCredentialOptions, IMsalPublicClientInitializerOptions
        {
            private Action<PublicClientApplicationBuilder> _beforeBuildClient;

            public ExtendedInteractiveBrowserCredentialOptions(Action<PublicClientApplicationBuilder> beforeBuildClient)
            {
                _beforeBuildClient = beforeBuildClient;
            }

            public bool IsProofOfPossessionRequired { get; set; }

            public bool UseDefaultBrokerAccount { get; set; }

            Action<PublicClientApplicationBuilder> IMsalPublicClientInitializerOptions.BeforeBuildClient { get { return _beforeBuildClient; } }
        }

        [Test]
        public async Task InvokesBeforeBuildClientOnExtendedOptions()
        {
            bool beforeBuildClientInvoked = false;

            var cancelSource = new CancellationTokenSource(2000);

            Action<PublicClientApplicationBuilder> beforeBuildClient = builder =>
            {
                Assert.NotNull(builder);
                beforeBuildClientInvoked = true;
                cancelSource.Cancel();
            };

            var credential = CreateCredentialWithBeforeBuildClient(beforeBuildClient);

            try
            {
                await credential.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }), cancelSource.Token);
            }
            catch (OperationCanceledException) { }
            catch (CredentialUnavailableException) { }
            catch (AuthenticationFailedException) { }

            Assert.True(beforeBuildClientInvoked);
        }

        [Test]
        public void FailsWithCredentialUnavailableExceptionWhenChainedInBrokerMode()
        {
            bool beforeBuildClientInvoked = false;

            var cancelSource = new CancellationTokenSource(2000);

            Action<PublicClientApplicationBuilder> beforeBuildClient = builder =>
            {
                Assert.NotNull(builder);
                beforeBuildClientInvoked = true;
                cancelSource.Cancel();
            };

            var credential = CreateCredentialWithBrokerMode(beforeBuildClient);

            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }), cancelSource.Token));

            Assert.True(beforeBuildClientInvoked);
        }

        protected virtual TokenCredential CreateCredentialWithBeforeBuildClient(Action<PublicClientApplicationBuilder> beforeBuildClient)
        {
            var options = new ExtendedInteractiveBrowserCredentialOptions(beforeBuildClient);
            return new InteractiveBrowserCredential(options);
        }

        protected virtual TokenCredential CreateCredentialWithBrokerMode(Action<PublicClientApplicationBuilder> beforeBuildClient)
        {
            var options = new ExtendedInteractiveBrowserCredentialOptions(beforeBuildClient);
            options.UseDefaultBrokerAccount = true;
            options.IsChainedCredential = true;
            return new InteractiveBrowserCredential(options);
        }
    }
}
