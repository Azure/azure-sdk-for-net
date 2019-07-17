// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Extensions.Tests
{
    internal class TestClientWithCredentials : TestClient
    {
        public TokenCredential Credential { get; }

        public TestClientWithCredentials(Uri uri, TokenCredential credential, TestClientOptions options) : base(uri, options)
        {
            Credential = credential;
        }
    }
}