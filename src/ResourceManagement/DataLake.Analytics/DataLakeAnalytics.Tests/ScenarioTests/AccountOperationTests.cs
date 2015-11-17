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
using Microsoft.Azure.Management.DataLake.Analytics;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using Microsoft.Azure.Test;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;
namespace DataLakeAnalytics.Tests
{
    public class AccountOperationTests : TestBase
    {
        [Fact]
        public void CreateGetUpdateDeleteTest()
        {
            TestUtilities.StartTest();
            try
            {
                UndoContext.Current.Start();
                CommonTestFixture commonData = new CommonTestFixture();
                var clientToUse = this.GetDataLakeAnalyticsManagementClient();

                // Create a test account
                AzureAsyncOperationResponse responseCreate =
                    clientToUse.DataLakeAnalyticsAccount.Create(commonData.ResourceGroupName,
                        parameters: new DataLakeAnalyticsAccountCreateOrUpdateParameters
                        {
                            DataLakeAnalyticsAccount = new DataLakeAnalyticsAccount
                            {
                                Name = commonData.DataLakeAnalyticsAccountName,
                                Location = commonData.Location,
                                Properties = new DataLakeAnalyticsAccountProperties
                                {
                                    DefaultDataLakeStoreAccount = commonData.DataLakeStoreAccountName,
                                    DataLakeStoreAccounts = new List<DataLakeStoreAccount>
                                    {
                                        new DataLakeStoreAccount
                                        {
                                            Name = commonData.DataLakeStoreAccountName,
                                            Properties = new DataLakeStoreAccountProperties
                                            {
                                                Suffix = commonData.DataLakeStoreAccountSuffix
                                            }
                                        }
                                    }
                                },
                                Tags = new Dictionary<string, string>
                                {
                                    { "testkey","testvalue" }
                                }
                            }
                        });

                Assert.Equal(HttpStatusCode.OK, responseCreate.StatusCode);

                // get the account and ensure that all the values are properly set.
                var responseGet = clientToUse.DataLakeAnalyticsAccount.Get(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName);

                // validate the account creation process
                Assert.True(responseGet.DataLakeAnalyticsAccount.Properties.ProvisioningState == DataLakeAnalyticsAccountStatus.Creating || responseGet.DataLakeAnalyticsAccount.Properties.ProvisioningState == DataLakeAnalyticsAccountStatus.Succeeded);
                Assert.NotNull(responseCreate.RequestId);
                Assert.NotNull(responseGet.RequestId);
                Assert.Contains(commonData.DataLakeAnalyticsAccountName, responseGet.DataLakeAnalyticsAccount.Id);
                Assert.Equal(commonData.Location, responseGet.DataLakeAnalyticsAccount.Location);
                Assert.Equal(commonData.DataLakeAnalyticsAccountName, responseGet.DataLakeAnalyticsAccount.Name);
                Assert.Equal("Microsoft.DataLakeAnalytics/accounts", responseGet.DataLakeAnalyticsAccount.Type);

                Assert.True(responseGet.DataLakeAnalyticsAccount.Properties.DataLakeStoreAccounts.Count == 1);
                Assert.True(responseGet.DataLakeAnalyticsAccount.Properties.DataLakeStoreAccounts.ToList()[0].Name.Equals(commonData.DataLakeStoreAccountName));

                // wait for provisioning state to be Succeeded
                // we will wait a maximum of 15 minutes for this to happen and then report failures
                int timeToWaitInMinutes = 15;
                int minutesWaited = 0;
                while (responseGet.DataLakeAnalyticsAccount.Properties.ProvisioningState != DataLakeAnalyticsAccountStatus.Succeeded && responseGet.DataLakeAnalyticsAccount.Properties.ProvisioningState != DataLakeAnalyticsAccountStatus.Failed && minutesWaited <= timeToWaitInMinutes)
                {
                    TestUtilities.Wait(60000); // Wait for one minute and then go again.
                    minutesWaited++;
                    responseGet = clientToUse.DataLakeAnalyticsAccount.Get(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName);
                }

                // Confirm that the account creation did succeed
                Assert.True(responseGet.DataLakeAnalyticsAccount.Properties.ProvisioningState == DataLakeAnalyticsAccountStatus.Succeeded);

                // Update the account and confirm the updates make it in.
                var newAccount = responseGet.DataLakeAnalyticsAccount;
                var firstStorageAccountName = newAccount.Properties.DataLakeStoreAccounts.ToList()[0].Name;
                newAccount.Tags = new Dictionary<string, string>
                {
                    {"updatedKey", "updatedValue"}
                };

                // need to null out deep properties to prevent an error
                newAccount.Properties.DataLakeStoreAccounts = null;
                newAccount.Properties.StorageAccounts = null;

                var updateResponse = clientToUse.DataLakeAnalyticsAccount.Update(commonData.ResourceGroupName, new DataLakeAnalyticsAccountCreateOrUpdateParameters
                    {
                        DataLakeAnalyticsAccount = newAccount,
                    });

                Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);
                Assert.Equal(updateResponse.Status, OperationStatus.Succeeded);

                // get the account and ensure that all the values are properly set.
                var updateResponseGet = clientToUse.DataLakeAnalyticsAccount.Get(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName);

                Assert.NotNull(updateResponse.RequestId);
                Assert.Contains(responseGet.DataLakeAnalyticsAccount.Id, updateResponseGet.DataLakeAnalyticsAccount.Id);
                Assert.Equal(responseGet.DataLakeAnalyticsAccount.Location, updateResponseGet.DataLakeAnalyticsAccount.Location);
                Assert.Equal(newAccount.Name, updateResponseGet.DataLakeAnalyticsAccount.Name);
                Assert.Equal(responseGet.DataLakeAnalyticsAccount.Type, updateResponseGet.DataLakeAnalyticsAccount.Type);

                // verify the new tags. NOTE: sequence equal is not ideal if we have more than 1 tag, since the ordering can change.
                Assert.True(updateResponseGet.DataLakeAnalyticsAccount.Tags.SequenceEqual(newAccount.Tags));
                Assert.True(updateResponseGet.DataLakeAnalyticsAccount.Properties.DataLakeStoreAccounts.Count == 1);
                Assert.True(updateResponseGet.DataLakeAnalyticsAccount.Properties.DataLakeStoreAccounts.ToList()[0].Name.Equals(firstStorageAccountName));

                // Create another account and ensure that list account returns both
                var accountToChange = responseGet.DataLakeAnalyticsAccount;
                accountToChange.Name = accountToChange.Name + "secondacct";
                var parameters = new DataLakeAnalyticsAccountCreateOrUpdateParameters
                {
                    DataLakeAnalyticsAccount = accountToChange
                };

                clientToUse.DataLakeAnalyticsAccount.Create(commonData.ResourceGroupName, parameters);

                DataLakeAnalyticsAccountListResponse listResponse = clientToUse.DataLakeAnalyticsAccount.List(commonData.ResourceGroupName, null);

                // Assert that there are at least two accounts in the list
                Assert.True(listResponse.Value.Count > 1);

                // Add, list and remove a data source to the first account
                var addDataSourceResponse =
                    clientToUse.DataLakeAnalyticsAccount.AddDataLakeStoreAccount(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.SecondDataLakeStoreAccountName,
                        new AddDataLakeStoreParameters
                        {
                            Properties =
                                new DataLakeStoreAccountProperties {Suffix = commonData.DataLakeStoreAccountSuffix}
                        });

                Assert.Equal(HttpStatusCode.OK, addDataSourceResponse.StatusCode);

                // Get the data sources and confirm there are 2
                var getDataSourceResponse =
                    clientToUse.DataLakeAnalyticsAccount.ListDataLakeStoreAccounts(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, null);

                Assert.Equal(HttpStatusCode.OK, getDataSourceResponse.StatusCode);
                Assert.Equal(2, getDataSourceResponse.Value.Count);

                // get the specific data source
                var getSingleDataSourceResponse =
                    clientToUse.DataLakeAnalyticsAccount.GetDataLakeStoreAccount(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.SecondDataLakeStoreAccountName);

                Assert.Equal(HttpStatusCode.OK, getSingleDataSourceResponse.StatusCode);
                Assert.Equal(commonData.SecondDataLakeStoreAccountName, getSingleDataSourceResponse.DataLakeStoreAccount.Name);
                Assert.Equal(commonData.SecondDataLakeStoreAccountSuffix, getSingleDataSourceResponse.DataLakeStoreAccount.Properties.Suffix);

                // Remove the data source we added
                var removeDataSourceResponse =
                    clientToUse.DataLakeAnalyticsAccount.DeleteDataLakeStoreAccount(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.SecondDataLakeStoreAccountName);

                Assert.Equal(HttpStatusCode.OK, removeDataSourceResponse.StatusCode);

                // Confirm that there is now only one data source.
                getDataSourceResponse =
                    clientToUse.DataLakeAnalyticsAccount.ListDataLakeStoreAccounts(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, null);

                Assert.Equal(HttpStatusCode.OK, getDataSourceResponse.StatusCode);
                Assert.Equal(1, getDataSourceResponse.Value.Count);

                // Add, list and remove an azure blob source to the first account
                var addDataSourceBlobResponse =
                    clientToUse.DataLakeAnalyticsAccount.AddStorageAccount(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.StorageAccountName,
                        new AddStorageAccountParameters
                        {
                            Properties =
                                new StorageAccountProperties
                                {
                                    Suffix = commonData.StorageAccountSuffix,
                                    AccessKey = commonData.StorageAccountAccessKey
                                }
                        });

                Assert.Equal(HttpStatusCode.OK, addDataSourceBlobResponse.StatusCode);

                // Get the data sources and confirm there is 1
                var getDataSourceBlobResponse =
                    clientToUse.DataLakeAnalyticsAccount.ListStorageAccounts(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, null);

                Assert.Equal(HttpStatusCode.OK, getDataSourceBlobResponse.StatusCode);
                Assert.Equal(1, getDataSourceBlobResponse.Value.Count);

                // Get the specific data source we added and confirm that it has the same properties
                var getSingleDataSourceBlobResponse =
                    clientToUse.DataLakeAnalyticsAccount.GetStorageAccount(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.StorageAccountName);

                Assert.Equal(HttpStatusCode.OK, getSingleDataSourceBlobResponse.StatusCode);
                Assert.Equal(commonData.StorageAccountName, getSingleDataSourceBlobResponse.StorageAccount.Name);
                Assert.True(string.IsNullOrEmpty(getSingleDataSourceBlobResponse.StorageAccount.Properties.AccessKey));
                Assert.Equal(commonData.StorageAccountSuffix, getSingleDataSourceBlobResponse.StorageAccount.Properties.Suffix);

                // Remove the data source we added
                var removeDataSourceBlobResponse =
                    clientToUse.DataLakeAnalyticsAccount.DeleteStorageAccount(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.StorageAccountName);

                Assert.Equal(HttpStatusCode.OK, removeDataSourceBlobResponse.StatusCode);

                // Confirm that there no azure data sources.
                getDataSourceBlobResponse =
                    clientToUse.DataLakeAnalyticsAccount.ListStorageAccounts(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, null);

                Assert.Equal(HttpStatusCode.OK, getDataSourceResponse.StatusCode);
                Assert.Equal(0, getDataSourceBlobResponse.Value.Count);

                // Delete the account and confirm that it is deleted.
                AzureOperationResponse deleteResponse = clientToUse.DataLakeAnalyticsAccount.Delete(commonData.ResourceGroupName, newAccount.Name);

                // define the list of accepted status codes when deleting an account.
                List<HttpStatusCode> acceptedStatusCodes = new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
                HttpStatusCode.Accepted,
                HttpStatusCode.NotFound,
                HttpStatusCode.NoContent
            };

                Assert.Contains<HttpStatusCode>(deleteResponse.StatusCode, acceptedStatusCodes);
                Assert.NotNull(deleteResponse.RequestId);

                // delete the account again and make sure it continues to result in a succesful code.
                deleteResponse = clientToUse.DataLakeAnalyticsAccount.Delete(commonData.ResourceGroupName, newAccount.Name);
                Assert.Contains<HttpStatusCode>(deleteResponse.StatusCode, acceptedStatusCodes);

                // delete the account with its old name, which should also succeed.
                deleteResponse = clientToUse.DataLakeAnalyticsAccount.Delete(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName);
                Assert.Contains<HttpStatusCode>(deleteResponse.StatusCode, acceptedStatusCodes);

                // delete the second account that was created to ensure that we properly clean up after ourselves.
                deleteResponse = clientToUse.DataLakeAnalyticsAccount.Delete(commonData.ResourceGroupName, accountToChange.Name);
                Assert.Contains<HttpStatusCode>(deleteResponse.StatusCode, acceptedStatusCodes);
            }
            finally
            {
                // we don't catch any exceptions, those should all be bubbled up.
                UndoContext.Current.UndoAll();
                TestUtilities.EndTest();
            }
        }
    }
}
