// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Microsoft.Azure.PostgreSQL.Auth;

/// <summary>
/// Test environment for PostgreSQL authentication tests.
/// </summary>
public class PostgreSqlTestEnvironment : TestEnvironment
{
    // Add any environment-specific variables here if needed
    // For example, if you need connection strings from environment variables:
    // public string PostgreSqlConnectionString => GetRecordedVariable("POSTGRESQL_CONNECTION_STRING");
}
