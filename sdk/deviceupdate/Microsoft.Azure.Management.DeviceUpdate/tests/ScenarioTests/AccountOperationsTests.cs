// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.Azure.Management.DeviceUpdate.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.DeviceUpdate.Tests.ScenarioTests
{
    public class AccountOperationsTests : DeviceUpdateTestBase
    {
        private const string AccountName = "aducpsdktestaccount1";

        [Fact]
        public async Task AccountCrudTests()
        {
            using MockContext context = MockContext.Start(GetType());
            DeviceUpdateClient client = CreateDeviceUpdateClient(context);

            // 1. Create Account

            Account account = new Account(this.Location);

            account = await client.Accounts.CreateAsync(ResourceGroupName, AccountName, account, this.CancellationToken);
            Assert.NotNull(account);

            // 2. Get Account

            account = await client.Accounts.GetAsync(ResourceGroupName, AccountName, this.CancellationToken);
            Assert.NotNull(account);

            // 3. List Accounts by Resource Group

            IPage<Account> accounts = await client.Accounts.ListByResourceGroupAsync(ResourceGroupName, this.CancellationToken);
            Assert.NotEmpty(accounts);

            // 4. Delete Account

            await client.Accounts.DeleteAsync(ResourceGroupName, AccountName, this.CancellationToken);
        }
    }
}