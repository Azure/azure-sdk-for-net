// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Identity;
using Npgsql;
using NUnit.Framework;

namespace Microsoft.Azure.PostgreSQL.Auth.Tests.Samples
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the
    ///   Microsoft.Azure.PostgreSQL.Auth samples.
    /// </summary>
    public partial class Sample01_HelloWorld
    {
        [Test]
        public async Task ConfigureSyncAuthentication()
        {
            #region Snippet:PostgreSqlAuth_Sample01_Sync

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var connectionString = "Host=<< YOUR SERVER >>.postgres.database.azure.com;Database=<< YOUR DATABASE >>;SSL Mode=Require";
#else
            var credential = new TestTokenCredential(PostgreSqlTestEnvironment.CreateValidJwtToken(PostgreSqlTestEnvironment.EntraUser));
            var connectionString = "Host=localhost;Database=testdb";
#endif

            var builder = new NpgsqlDataSourceBuilder(connectionString);
            builder.UseEntraAuthentication(credential);

            await using var dataSource = builder.Build();

            #endregion
        }

        [Test]
        public async Task ConfigureAsyncAuthentication()
        {
            #region Snippet:PostgreSqlAuth_Sample01_Async

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var connectionString = "Host=<< YOUR SERVER >>.postgres.database.azure.com;Database=<< YOUR DATABASE >>;SSL Mode=Require";
#else
            var credential = new TestTokenCredential(PostgreSqlTestEnvironment.CreateValidJwtToken(PostgreSqlTestEnvironment.EntraUser));
            var connectionString = "Host=localhost;Database=testdb";
#endif

            var builder = new NpgsqlDataSourceBuilder(connectionString);
            await builder.UseEntraAuthenticationAsync(credential);

#if SNIPPET
            await using var dataSource = builder.Build();
#endif

            #endregion
        }

        [Test]
        public async Task QueryDatabase()
        {
#if SNIPPET
            var credential = new DefaultAzureCredential();
            var builder = new NpgsqlDataSourceBuilder("Host=myserver.postgres.database.azure.com;Database=mydb;SSL Mode=Require");
            await builder.UseEntraAuthenticationAsync(credential);
            await using var dataSource = builder.Build();

            #region Snippet:PostgreSqlAuth_Sample01_Query
            await using var connection = await dataSource.OpenConnectionAsync();
            await using var cmd = new NpgsqlCommand("SELECT version()", connection);
            var version = await cmd.ExecuteScalarAsync();
            #endregion
#else
            await Task.CompletedTask;
#endif
        }

        [Test]
        public void ConfigureExplicitUsername()
        {
            #region Snippet:PostgreSqlAuth_Sample01_ExplicitUsername

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var connectionString = "Host=<< YOUR SERVER >>.postgres.database.azure.com;Database=<< YOUR DATABASE >>;Username=my-db-role;SSL Mode=Require";
#else
            var credential = new TestTokenCredential(PostgreSqlTestEnvironment.CreateValidJwtToken(PostgreSqlTestEnvironment.EntraUser));
            var connectionString = "Host=localhost;Database=testdb;Username=my-db-role";
#endif

            var builder = new NpgsqlDataSourceBuilder(connectionString);
            builder.UseEntraAuthentication(credential);

            #endregion
        }
    }
}
