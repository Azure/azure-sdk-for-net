// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Extensions.Tests
{
    internal class TestClientMultipleOptionsParameters
    {
        public string ConnectionString { get; }
        public TestClientOptionsMultipleParameters Options { get; }

        public TestClientMultipleOptionsParameters(string connectionString, TestClientOptionsMultipleParameters options)
        {
            ConnectionString = connectionString;
            Options = options;
        }
    }
}