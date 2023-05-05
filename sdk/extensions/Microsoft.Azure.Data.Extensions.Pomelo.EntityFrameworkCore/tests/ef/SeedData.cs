// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Sample.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Repository
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            IDbContextFactory<ChecklistContext> contextFactory = serviceProvider.GetRequiredService<IDbContextFactory<ChecklistContext>>();
            using var context = await contextFactory.CreateDbContextAsync();
            await InitializeAsync(context);
        }

        public static async Task InitializeAsync(ChecklistContext context)
        {
            if (context == null || context.Checklists == null)
            {
                throw new ArgumentNullException("Null Checklists");
            }

            // Look for any checklist.
            if (await context.Checklists.AnyAsync())
            {
                return;   // DB has been seeded
            }

            await context.Checklists.AddRangeAsync(
                new Checklist
                {
                    Name = "Checklist 1",
                    Date = DateTime.UtcNow,
                    Description = "Checklist 1 Description",
                    CheckItems = new List<CheckItem>
                    {
                            new CheckItem { Description = "CheckItem 1"},
                            new CheckItem { Description = "CheckItem 3"},
                            new CheckItem { Description = "CheckItem 4"},
                            new CheckItem { Description = "CheckItem 5"},
                    }
                },
                new Checklist
                {
                    Name = "Checklist 2",
                    Date = DateTime.UtcNow,
                    Description = "Checklist 2 Description",
                    CheckItems = new List<CheckItem>
                    {
                            new CheckItem { Description = "CheckItem 1"},
                            new CheckItem { Description = "CheckItem 3"},
                            new CheckItem { Description = "CheckItem 4"},
                            new CheckItem { Description = "CheckItem 5"},
                    }
                }
            );
            await context.SaveChangesAsync();
        }
    }
}