// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class VisualStudioCodeCredentialLiveTests : ClientTestBase
    {
        public VisualStudioCodeCredentialLiveTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task AuthenticateWithVisualStudioCodeCredential()
        {
            var cred = InstrumentClient(new VisualStudioCodeCredential());

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(Array.Empty<string>()), CancellationToken.None);

            Assert.IsNotNull(token.Token);
        }
    }
}
