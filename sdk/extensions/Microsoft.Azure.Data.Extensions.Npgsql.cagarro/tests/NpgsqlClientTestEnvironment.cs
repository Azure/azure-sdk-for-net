// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Microsoft.Azure.Data.Extensions.Npgsql.Tests
{
    public class NpgsqlClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("Npgsql_ENDPOINT");

        // Add other client paramters here as above.
    }
}
