// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Npgsql;
using NUnit.Framework;

namespace Microsoft.Azure.PostgreSQL.Auth;

/// <summary>
/// Recorded tests for Entra ID authentication with Azure Database for PostgreSQL.
/// </summary>
public class EntraIdExtensionLiveTests : PostgreSqlLiveTestBase
{
    public EntraIdExtensionLiveTests(bool isAsync) : base(isAsync)
    {
    }

    [LiveOnly]
    [RecordedTest]
    public void CanConfigureEntraAuthentication()
    {
        var credential = TestEnvironment.Credential;
        var builder = new NpgsqlDataSourceBuilder(TestEnvironment.ConnectionString);

        builder.UseEntraAuthentication(credential);

        Assert.That(builder.ConnectionStringBuilder.Username, Is.Not.Null.And.Not.Empty);
    }

    [LiveOnly]
    [RecordedTest]
    public async Task CanConfigureEntraAuthenticationAsync()
    {
        var credential = TestEnvironment.Credential;
        var builder = new NpgsqlDataSourceBuilder(TestEnvironment.ConnectionString);

        await builder.UseEntraAuthenticationAsync(credential);

        Assert.That(builder.ConnectionStringBuilder.Username, Is.Not.Null.And.Not.Empty);
    }

    [LiveOnly]
    [RecordedTest]
    public async Task CanOpenConnectionWithEntraAuth()
    {
        var credential = TestEnvironment.Credential;
        var builder = new NpgsqlDataSourceBuilder(TestEnvironment.ConnectionString);

        await builder.UseEntraAuthenticationAsync(credential);

        await using var dataSource = builder.Build();
        await using var connection = await dataSource.OpenConnectionAsync();

        Assert.That(connection.State, Is.EqualTo(System.Data.ConnectionState.Open));

        using var cmd = new NpgsqlCommand("SELECT 1", connection);
        var result = await cmd.ExecuteScalarAsync();
        Assert.That(result, Is.EqualTo(1));
    }
}
