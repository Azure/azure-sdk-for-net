// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Extensions.Tests
{
    internal class TestClientWithCredentials : TestClient
    {
        public TokenCredential Credential { get; }
        public AzureKeyCredential AzureKeyCredential { get; }
        public AzureSasCredential AzureSasCredential { get; }

        public TestClientWithCredentials(Uri uri, TestClientOptions options) : base(uri, options)
        {
        }

        public TestClientWithCredentials(Uri uri, AzureKeyCredential credential, TestClientOptions options) : base(uri, options)
        {
            if (credential == null) throw new ArgumentNullException(nameof(credential));
            AzureKeyCredential = credential;
        }

        public TestClientWithCredentials(Uri uri, AzureSasCredential credential, TestClientOptions options) : base(uri, options)
        {
            if (credential == null) throw new ArgumentNullException(nameof(credential));
            AzureSasCredential = credential;
        }

        public TestClientWithCredentials(Uri uri, TokenCredential credential, TestClientOptions options) : base(uri, options)
        {
            if (credential == null) throw new ArgumentNullException(nameof(credential));
            Credential = credential;
        }
    }
}