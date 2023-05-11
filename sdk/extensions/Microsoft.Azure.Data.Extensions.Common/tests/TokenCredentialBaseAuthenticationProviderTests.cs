// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Data.Extensions.Common.Tests
{
    public class TokenCredentialBaseAuthenticationProviderTests
    {
        //[Test]
        //public async Task NoExtensionDefaultAzureCredential()
        //{
        //    TokenCredentialNpgsqlPasswordProvider passwordProvider = new TokenCredentialNpgsqlPasswordProvider(new DefaultAzureCredential());
        //    // Connection string does not contain password
        //    NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder(configuration.GetConnectionString());
        //    NpgsqlDataSource dataSource = dataSourceBuilder
        //                    .UsePeriodicPasswordProvider(passwordProvider.PasswordProvider, TimeSpan.FromMinutes(2), TimeSpan.FromMilliseconds(100))
        //                    .Build();
        //    await ValidateDataSourceAsync(dataSource);
        //}

        ////[TestCategory("server-only")]
        //[Test]
        //public async Task NoExtensionConstructorWithManagedIdentity()
        //{
        //    Assert.IsNotNull(configuration);
        //    string? managedIdentityClientId = configuration.GetManagedIdentityClientId();
        //    Assert.IsNotNull(managedIdentityClientId);
        //    TokenCredentialNpgsqlPasswordProvider passwordProvider = new TokenCredentialNpgsqlPasswordProvider(new DefaultAzureCredential(new DefaultAzureCredentialOptions { ManagedIdentityClientId = managedIdentityClientId }));
        //    NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder(configuration.GetConnectionString());
        //    NpgsqlDataSource dataSource = dataSourceBuilder
        //                    .UsePeriodicPasswordProvider(passwordProvider.PasswordProvider, TimeSpan.FromMinutes(2), TimeSpan.FromMilliseconds(100))
        //                    .Build();
        //    await ValidateDataSourceAsync(dataSource);
        //}

        ////[TestCategory("local-only")]
        //[Test]
        //public async Task NoExtensionConstructorWithTokenCredential()
        //{
        //    Assert.IsNotNull(configuration);
        //    AzureCliCredential credential = new AzureCliCredential();
        //    TokenCredentialNpgsqlPasswordProvider passwordProvider = new TokenCredentialNpgsqlPasswordProvider(credential);
        //    NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder(configuration.GetConnectionString());
        //    NpgsqlDataSource dataSource = dataSourceBuilder
        //                    .UsePeriodicPasswordProvider(passwordProvider.PasswordProvider, TimeSpan.FromMinutes(2), TimeSpan.FromMilliseconds(100))
        //                    .Build();
        //    await ValidateDataSourceAsync(dataSource);
        //}
    }
}
