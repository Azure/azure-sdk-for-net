// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Azure.Identity.Tests.Mock
{
    internal class MockMsalConfidentialClient : MsalConfidentialClient
    {
        private Func<string[], AuthenticationResult> _factory = null;

        public MockMsalConfidentialClient(AuthenticationResult result)
        {
            _factory = (_) => result;
        }

        public MockMsalConfidentialClient(Exception exception)
        {
            _factory = (_) => throw exception;
        }

        public MockMsalConfidentialClient(Func<string[], AuthenticationResult> factory)
        {
            _factory = factory;
        }

        public override Task<AuthenticationResult> AcquireTokenForClientAsync(string[] scopes, bool async, CancellationToken cancellationToken)
        {
            return Task.FromResult(_factory(scopes));
        }
    }
}
