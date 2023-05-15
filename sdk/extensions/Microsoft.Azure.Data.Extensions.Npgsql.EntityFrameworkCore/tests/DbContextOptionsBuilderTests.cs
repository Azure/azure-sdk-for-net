// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Sample.Repository;
using System.Threading.Tasks;

namespace Microsoft.Azure.Data.Extensions.Npgsql.EntityFrameworkCore.Tests
{
    public class DbContextOptionsBuilderTests : LiveTestBase<NpgsqlTestEnvironment>
    {
        [Test]
        public async Task EFDefault()
        {
            var services = new ServiceCollection();
            services.AddDbContextFactory<ChecklistContext>(options =>
            {
                options.UseNpgsql(TestEnvironment.ConnectionString,
                    npgsqlOptions => npgsqlOptions.UseAzureADAuthentication(TestEnvironment.Credential));
            });

            var serviceProvider = services.BuildServiceProvider();
            var contextFactory = serviceProvider.GetRequiredService<IDbContextFactory<ChecklistContext>>();
            using var dbContext = await contextFactory.CreateDbContextAsync();
            await dbContext.Database.OpenConnectionAsync();
            var rows = await dbContext.Database.ExecuteSqlRawAsync("SELECT now()");
            Assert.AreEqual(1, rows);
        }
    }
}
