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
    ///   Microsoft.Azure.PostgreSQL.Auth README.
    /// </summary>
    [TestFixture]
    public class ReadMeSnippets
    {
        [Test]
        public void Authenticate()
        {
            #region Snippet:PostgreSqlAuth_ReadMe_Authenticate

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var builder = new NpgsqlDataSourceBuilder("Host=<< YOUR SERVER >>.postgres.database.azure.com;Database=<< YOUR DATABASE >>;SSL Mode=Require");
#else
            var credential = new TestTokenCredential(PostgreSqlTestEnvironment.CreateValidJwtToken(PostgreSqlTestEnvironment.EntraUser));
            var builder = new NpgsqlDataSourceBuilder("Host=localhost;Database=testdb");
#endif
            builder.UseEntraAuthentication(credential);

            #endregion
        }

        [Test]
        public void SynchronousAuthentication()
        {
            #region Snippet:PostgreSqlAuth_ReadMe_Sync

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var builder = new NpgsqlDataSourceBuilder("Host=<< YOUR SERVER >>.postgres.database.azure.com;Database=<< YOUR DATABASE >>;SSL Mode=Require");
#else
            var credential = new TestTokenCredential(PostgreSqlTestEnvironment.CreateValidJwtToken(PostgreSqlTestEnvironment.EntraUser));
            var builder = new NpgsqlDataSourceBuilder("Host=localhost;Database=testdb");
#endif
            builder.UseEntraAuthentication(credential);

            #endregion
        }

        [Test]
        public async Task AsynchronousAuthentication()
        {
            #region Snippet:PostgreSqlAuth_ReadMe_Async

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var builder = new NpgsqlDataSourceBuilder("Host=<< YOUR SERVER >>.postgres.database.azure.com;Database=<< YOUR DATABASE >>;SSL Mode=Require");
#else
            var credential = new TestTokenCredential(PostgreSqlTestEnvironment.CreateValidJwtToken(PostgreSqlTestEnvironment.EntraUser));
            var builder = new NpgsqlDataSourceBuilder("Host=localhost;Database=testdb");
#endif
            await builder.UseEntraAuthenticationAsync(credential);

            #endregion
        }
    }
}
