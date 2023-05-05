// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using MySqlConnector;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Data.Extensions.MySqlConnector.Tests
{
    public class MySqlConnectionTests : LiveTestBase<MySqlConnectorTestEnvironment>
    {
        private static async Task ValidateConnectionAsync(MySqlConnection connection)
        {
            Assert.IsNotNull(connection);
            await connection.OpenAsync();
            MySqlCommand cmd = new MySqlCommand("SELECT now()", connection);
            DateTime? serverDate = (DateTime?)await cmd.ExecuteScalarAsync();
            Assert.IsNotNull(serverDate);
        }

        [Test]
        public async Task ProviderDefaultAzureCredential()
        {
            TokenCredentialMysqlPasswordProvider passwordProvider = new TokenCredentialMysqlPasswordProvider(TestEnvironment.Credential);
            using MySqlConnection connection = new MySqlConnection(TestEnvironment.ConnectionString);
            connection.ProvidePasswordCallback = passwordProvider.ProvidePassword;
            await ValidateConnectionAsync(connection);
        }
    }
}