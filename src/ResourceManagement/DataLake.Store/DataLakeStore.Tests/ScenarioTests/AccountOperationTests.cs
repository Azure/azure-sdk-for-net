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
using Microsoft.Azure;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;
namespace DataLakeStore.Tests
{
    public class AccountOperationTests : TestBase
    {   
        private CommonTestFixture commonData;

        [Fact]
        public void CreateGetUpdateDeleteTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                commonData = new CommonTestFixture(context);
                var clientToUse = this.GetDataLakeStoreAccountManagementClient(context);

                // Create a test account
                var responseCreate =
                    clientToUse.Account.Create(resourceGroupName: commonData.ResourceGroupName, name: commonData.DataLakeStoreAccountName,
                        parameters: new DataLakeStoreAccount
                        {
                            Name = commonData.DataLakeStoreAccountName,
                            Location = commonData.Location,
                            Tags = new Dictionary<string, string>
                            {
                            { "testkey","testvalue" }
                            },
                            Identity = new EncryptionIdentity
                            {
                                Type = EncryptionIdentityType.SystemAssigned
                            },
                            Properties = new DataLakeStoreAccountProperties
                            {
                                EncryptionConfig = new EncryptionConfig
                                {
                                    Type = EncryptionConfigType.ServiceManaged
                                },
                                EncryptionState = EncryptionState.Enabled
                            }
                        });

                Assert.Equal(DataLakeStoreAccountStatus.Succeeded, responseCreate.Properties.ProvisioningState);

                // get the account and ensure that all the values are properly set.
                var responseGet = clientToUse.Account.Get(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName);

                // validate the account creation process
                Assert.Equal(DataLakeStoreAccountStatus.Succeeded, responseGet.Properties.ProvisioningState);
                Assert.NotNull(responseCreate.Id);
                Assert.NotNull(responseGet.Id);
                Assert.Contains(commonData.DataLakeStoreAccountName, responseGet.Id);
                Assert.Contains(commonData.DataLakeStoreAccountName, responseGet.Properties.Endpoint);
                Assert.Equal(commonData.Location, responseGet.Location);
                Assert.Equal(commonData.DataLakeStoreAccountName, responseGet.Name);
                Assert.Equal("Microsoft.DataLakeStore/accounts", responseGet.Type);

                // wait for provisioning state to be Succeeded
                // we will wait a maximum of 15 minutes for this to happen and then report failures
                int timeToWaitInMinutes = 15;
                int minutesWaited = 0;
                while (responseGet.Properties.ProvisioningState != DataLakeStoreAccountStatus.Succeeded && responseGet.Properties.ProvisioningState != DataLakeStoreAccountStatus.Failed && minutesWaited <= timeToWaitInMinutes)
                {
                    TestUtilities.Wait(60000); // Wait for one minute and then go again.
                    minutesWaited++;
                    responseGet = clientToUse.Account.Get(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName);
                }

                // Confirm that the account creation did succeed
                Assert.True(responseGet.Properties.ProvisioningState == DataLakeStoreAccountStatus.Succeeded);

                // Validate the encryption state is set
                Assert.Equal(EncryptionState.Enabled, responseGet.Properties.EncryptionState.GetValueOrDefault());
                Assert.Equal(EncryptionIdentityType.SystemAssigned, responseGet.Identity.Type.GetValueOrDefault());
                Assert.True(responseGet.Identity.PrincipalId.HasValue);
                Assert.True(responseGet.Identity.TenantId.HasValue);
                Assert.Equal(EncryptionConfigType.ServiceManaged, responseGet.Properties.EncryptionConfig.Type.GetValueOrDefault());

                // Update the account and confirm the updates make it in.
                var newAccount = responseGet;
                newAccount.Tags = new Dictionary<string, string>
            {
                {"updatedKey", "updatedValue"}
            };

                var updateResponse = clientToUse.Account.Update(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName,
                new DataLakeStoreAccount
                {
                    Name = newAccount.Name,
                    Tags = new Dictionary<string, string>
                    {
                        {"updatedKey", "updatedValue"}
                    }
                });

                Assert.Equal(DataLakeStoreAccountStatus.Succeeded, updateResponse.Properties.ProvisioningState);

                var updateResponseGet = clientToUse.Account.Get(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName);

                Assert.NotNull(updateResponse.Id);
                Assert.Contains(responseGet.Id, updateResponseGet.Id);
                Assert.Equal(responseGet.Location, updateResponseGet.Location);
                Assert.Equal(newAccount.Name, updateResponseGet.Name);
                Assert.Equal(responseGet.Type, updateResponseGet.Type);

                // verify the new tags. NOTE: sequence equal is not ideal if we have more than 1 tag, since the ordering can change.
                Assert.True(updateResponseGet.Tags.SequenceEqual(newAccount.Tags));

                // Create another account and ensure that list account returns both
                var accountToChange = updateResponseGet;
                accountToChange.Name = accountToChange.Name + "acct2";

                clientToUse.Account.Create(commonData.ResourceGroupName, accountToChange.Name, accountToChange);

                var listResponse = clientToUse.Account.List();

                // Assert that there are at least two accounts in the list
                Assert.True(listResponse.Count() > 1);

                // now list by resource group:
                listResponse = clientToUse.Account.ListByResourceGroup(commonData.ResourceGroupName);

                // Assert that there are at least two accounts in the list
                Assert.True(listResponse.Count() > 1);

                // test that the account exists
                Assert.True(clientToUse.Account.Exists(commonData.ResourceGroupName, newAccount.Name));

                // Delete the account and confirm that it is deleted.
                clientToUse.Account.Delete(commonData.ResourceGroupName, newAccount.Name);

                // delete the account again and make sure it continues to result in a succesful code.
                clientToUse.Account.Delete(commonData.ResourceGroupName, newAccount.Name);

                // delete the account with its old name, which should also succeed.
                clientToUse.Account.Delete(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName);

                // test that the account is gone
                Assert.False(clientToUse.Account.Exists(commonData.ResourceGroupName, newAccount.Name));
            }
        }
    }
}
