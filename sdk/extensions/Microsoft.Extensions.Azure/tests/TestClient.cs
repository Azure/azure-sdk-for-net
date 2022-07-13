// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Extensions.Tests
{
    internal class TestClient
    {
        public Uri Uri { get; }
        public Guid Guid { get; }
        public string ConnectionString { get; }
        public CompositeObject Composite { get; }
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

        public TestClient(Guid guid, TestClientOptions options)
        {
            Guid = guid;
            Options = options;
        }

        public TestClient(Uri uri, CompositeObject composite, TestClientOptions options)
        {
            Uri = uri;
            Composite = composite;
            Options = options;
        }

        public TestClient(CompositeObject composite, TestClientOptions options)
        {
            Composite = composite;
            Options = options;
        }

        public class CompositeObject
        {
            public string A { get; }
            public string B { get; }
            public Uri C { get; }

            public CompositeObject(string a)
            {
                A = a;
            }

            public CompositeObject(string a, string b)
            {
                A = a;
                B = b;
            }

            public CompositeObject(Uri c)
            {
                C = c;
            }
        }
    }
}