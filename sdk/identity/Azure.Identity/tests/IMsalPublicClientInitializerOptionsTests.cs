// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class IMsalPublicClientInitializerOptionsTests : CredentialTestBase
    {
        public IMsalPublicClientInitializerOptionsTests(bool isAsync) : base(isAsync)
        { }

        public class ExtendedInteractiveBrowserCredentialOptions : InteractiveBrowserCredentialOptions, IMsalPublicClientInitializerOptions
        {
            private Action<PublicClientApplicationBuilder> _beforeBuildClient;

            public ExtendedInteractiveBrowserCredentialOptions(Action<PublicClientApplicationBuilder> beforeBuildClient)
            {
                _beforeBuildClient = beforeBuildClient;
            }

            Action<PublicClientApplicationBuilder> IMsalPublicClientInitializerOptions.BeforeBuildClient { get { return _beforeBuildClient; } }
        }

        [Test]
        public async Task InvokesBeforeBuildClient()
        {
            bool beforeBuildClientInvoked = false;

            var cancelSource = new CancellationTokenSource(2000);

            var options = new ExtendedInteractiveBrowserCredentialOptions( builder =>
                {
                    Assert.NotNull(builder);
                    beforeBuildClientInvoked = true;
                    cancelSource.Cancel();
                }
            );

            var credential = InstrumentClient(new InteractiveBrowserCredential(options));

            try
            {
                await credential.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }), cancelSource.Token);
            }
            catch (OperationCanceledException) { }

            Assert.True(beforeBuildClientInvoked);
        }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options) => InstrumentClient(
            new InteractiveBrowserCredential(TenantId, ClientId, options, null, mockPublicMsalClient));
    }
}
