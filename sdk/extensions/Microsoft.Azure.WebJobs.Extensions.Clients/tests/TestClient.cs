// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.Clients.Tests
{
    public class TestClient
    {
        public string ConnectionString { get; }
        public Uri Uri { get; }
        public TestClientOptions Options { get; }

        public TestClient(string connectionString, TestClientOptions options)
        {
            ConnectionString = connectionString;
            Options = options;
        }

        public TestClient(Uri endpoint, TestClientOptions options)
        {
            Uri = endpoint;
            Options = options;
        }
    }
}