// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Identity;
using Npgsql;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Data.Extensions.Npgsql.Tests
{
    public class TokenCredentialNpgsqlPasswordProviderTests : LiveTestBase<ConfigurationTestEnvironment>
    {
        private static async Task ValidateDataSourceAsync(NpgsqlDataSource dataSource)
        {
            Assert.IsNotNull(dataSource);
            using NpgsqlConnection connection = await dataSource.OpenConnectionAsync();
            using NpgsqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT now()";
            DateTime? serverDate = (DateTime?)await cmd.ExecuteScalarAsync();
            Assert.IsNotNull(serverDate);
        }

        [Test]
        public async Task TokenCredentialNpgsqlPasswordProviderConnection()
        {
            TokenCredentialNpgsqlPasswordProvider passwordProvider = new TokenCredentialNpgsqlPasswordProvider(TestEnvironment.Credential);
            // Connection string does not contain password
            NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder(TestEnvironment.ConnectionString);
            NpgsqlDataSource dataSource = dataSourceBuilder
                            .UsePeriodicPasswordProvider(passwordProvider.PasswordProvider, TimeSpan.FromMinutes(2), TimeSpan.FromMilliseconds(100))
                            .Build();
            await ValidateDataSourceAsync(dataSource);
        }
    }
}
