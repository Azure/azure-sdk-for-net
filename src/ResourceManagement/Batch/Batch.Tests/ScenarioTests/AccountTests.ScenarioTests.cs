//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;


namespace Batch.Tests.ScenarioTests
{
    public class AccountTests : BatchScenarioTestBase
    {
        [Fact]
        public async Task BatchAccountEndToEndAsync()
        {
            using (MockContext context = StartMockContextAndInitializeClients(this.GetType().FullName))
            {
                string resourceGroupName = TestUtilities.GenerateName();
                string batchAccountName = TestUtilities.GenerateName();
                ResourceGroup group = new ResourceGroup(this.Location);
                await this.ResourceManagementClient.ResourceGroups.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, group);

                try
                {
                    // Create an account
                    BatchAccountCreateParameters createParams = new BatchAccountCreateParameters(this.Location);
                    await this.BatchManagementClient.BatchAccount.CreateAsync(resourceGroupName, batchAccountName, createParams);

                    // Get the account and verify some properties
                    BatchAccount batchAccount = await this.BatchManagementClient.BatchAccount.GetAsync(resourceGroupName, batchAccountName);
                    Assert.Equal(batchAccountName, batchAccount.Name);
                    Assert.True(batchAccount.CoreQuota > 0);

                    // Rotate a key
                    BatchAccountKeys originalKeys = await this.BatchManagementClient.BatchAccount.GetKeysAsync(resourceGroupName, batchAccountName);
                    BatchAccountKeys newKeys = await this.BatchManagementClient.BatchAccount.RegenerateKeyAsync(resourceGroupName, batchAccountName, AccountKeyType.Primary);
                    Assert.NotEqual(originalKeys.Primary, newKeys.Primary);
                    Assert.Equal(originalKeys.Secondary, newKeys.Secondary);

                    // List accounts under the resource group
                    IPage<BatchAccount> listResponse = await this.BatchManagementClient.BatchAccount.ListByResourceGroupAsync(resourceGroupName);
                    List<BatchAccount> accounts = new List<BatchAccount>(listResponse);
                    string nextLink = listResponse.NextPageLink;
                    while (nextLink != null)
                    {
                        listResponse = await this.BatchManagementClient.BatchAccount.ListByResourceGroupNextAsync(nextLink);
                        accounts.AddRange(listResponse);
                        nextLink = listResponse.NextPageLink;
                    }

                    Assert.Equal(1, accounts.Count);
                    Assert.Equal(batchAccountName, accounts.First().Name);

                    // Delete the account
                    try
                    {
                        await this.BatchManagementClient.BatchAccount.DeleteAsync(resourceGroupName, batchAccountName);
                    }
                    catch (CloudException ex)
                    {
                        /*  Account deletion is a long running operation. This .DeleteAsync() method will submit the account deletion request and
                         *  poll for the status of the long running operation until the account is deleted. Currently, querying for the operation
                         *  status after the account is deleted will return a 404 error, so we have to add this catch statement. This behavior will
                         *  be fixed in a future service release.
                         */
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound)
                        {
                            throw;
                        }
                    }
                    // Verify account was deleted. A GET operation will return a 404 error and result in an exception
                    try
                    {
                        await this.BatchManagementClient.BatchAccount.GetAsync(resourceGroupName, batchAccountName);
                    }
                    catch (CloudException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    await this.ResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroupName);
                }
            }
        }
    }
}
