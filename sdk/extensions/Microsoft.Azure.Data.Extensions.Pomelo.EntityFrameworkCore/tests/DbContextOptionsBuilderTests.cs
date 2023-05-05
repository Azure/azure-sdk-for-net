// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Sample.Repository;
using System.Threading.Tasks;

namespace Microsoft.Azure.Data.Extensions.Pomelo.EntityFrameworkCore.Tests
{
    public class DbContextOptionsBuilderTests : LiveTestBase<MySqlTestEnvironment>
    {
        private static readonly ServerVersion serverVersion = ServerVersion.Parse("5.7", ServerType.MySql);

        [Test]
        public async Task EFDefault()
        {
            var services = new ServiceCollection();
            services.AddDbContextFactory<ChecklistContext>(options =>
            {
                options
                    .UseMySql(TestEnvironment.ConnectionString, serverVersion)
                    .UseAzureADAuthentication(TestEnvironment.Credential);
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
