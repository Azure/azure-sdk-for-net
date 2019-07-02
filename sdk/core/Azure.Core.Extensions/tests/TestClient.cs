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

    internal class TestClient
    {
        public Uri Uri { get; }
        public string ConnectionString { get; }
        public TestClientOptions Options { get; }

        public TestClient(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public TestClient(string connectionString, TestClientOptions options)
        {
            if (connectionString == "throw")
            {
                throw new ArgumentException("Throwing");
            }

            ConnectionString = connectionString;
            Options = options;
        }

        public TestClient(Uri uri, TestClientOptions options)
        {
            Uri = uri;
            Options = options;
        }
    }
}