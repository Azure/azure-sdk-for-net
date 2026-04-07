// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Microsoft.Azure.PostgreSQL.Auth;

/// <summary>
/// Base class for PostgreSQL Entra ID authentication recorded tests.
/// </summary>
public abstract class PostgreSqlLiveTestBase : RecordedTestBase<PostgreSqlTestEnvironment>
{
    protected PostgreSqlLiveTestBase(bool isAsync) : base(isAsync)
    {
    }
}
