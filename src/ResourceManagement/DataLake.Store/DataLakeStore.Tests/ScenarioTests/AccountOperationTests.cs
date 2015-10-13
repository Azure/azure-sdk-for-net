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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;
namespace DataLakeStore.Tests
{
    public class AccountOperationTests : TestBase, IUseFixture<CommonTestFixture>
    {   
        private CommonTestFixture commonData;
        public void SetFixture(CommonTestFixture data)
        {
            commonData = data;
        }

        [Fact]
        public void CreateGetUpdateDeleteTest()
        {
            TestUtilities.StartTest();
            var clientToUse = this.GetDataLakeStoreManagementClient();

            // Create a test account
            var responseCreate =
                clientToUse.DataLakeStoreAccount.Create(resourceGroupName: commonData.ResourceGroupName,
                    parameters: new DataLakeStoreAccountCreateOrUpdateParameters
                    {
                        DataLakeStoreAccount = new DataLakeStoreAccount
                        {
                            Name = commonData.DataLakeStoreAccountName,
                            Location = commonData.Location,
                            Tags = new Dictionary<string, string>
                            {
                                { "testkey","testvalue" }
                            }
                        }
                    });

            Assert.Equal(HttpStatusCode.OK, responseCreate.StatusCode);
            Assert.Equal(OperationStatus.Succeeded, responseCreate.Status);
            
            // get the account and ensure that all the values are properly set.
            var responseGet = clientToUse.DataLakeStoreAccount.Get(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName);

            // validate the account creation process
            Assert.True(responseGet.DataLakeStoreAccount.Properties.ProvisioningState == DataLakeStoreAccountStatus.Creating || responseGet.DataLakeStoreAccount.Properties.ProvisioningState == DataLakeStoreAccountStatus.Succeeded);
            Assert.NotNull(responseCreate.RequestId);
            Assert.NotNull(responseGet.RequestId);
            Assert.Contains(commonData.DataLakeStoreAccountName, responseGet.DataLakeStoreAccount.Id);
            Assert.Contains(commonData.DataLakeStoreAccountName, responseGet.DataLakeStoreAccount.Properties.Endpoint);
            Assert.Equal(commonData.Location, responseGet.DataLakeStoreAccount.Location);
            Assert.Equal(commonData.DataLakeStoreAccountName, responseGet.DataLakeStoreAccount.Name);
            Assert.Equal("Microsoft.DataLakeStore/accounts", responseGet.DataLakeStoreAccount.Type);

            // wait for provisioning state to be Succeeded
            // we will wait a maximum of 15 minutes for this to happen and then report failures
            int timeToWaitInMinutes = 15;
            int minutesWaited = 0;
            while (responseGet.DataLakeStoreAccount.Properties.ProvisioningState != DataLakeStoreAccountStatus.Succeeded && responseGet.DataLakeStoreAccount.Properties.ProvisioningState != DataLakeStoreAccountStatus.Failed && minutesWaited <= timeToWaitInMinutes)
            {
                TestUtilities.Wait(60000); // Wait for one minute and then go again.
                minutesWaited++;
                responseGet = clientToUse.DataLakeStoreAccount.Get(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName);
            }

            // Confirm that the account creation did succeed
            Assert.True(responseGet.DataLakeStoreAccount.Properties.ProvisioningState == DataLakeStoreAccountStatus.Succeeded);

            // Update the account and confirm the updates make it in.
            var newAccount = responseGet.DataLakeStoreAccount;
            newAccount.Tags = new Dictionary<string, string>
            {
                {"updatedKey", "updatedValue"}
            };

            var updateResponse = clientToUse.DataLakeStoreAccount.Update(commonData.ResourceGroupName, new DataLakeStoreAccountCreateOrUpdateParameters
                {
                    DataLakeStoreAccount = new DataLakeStoreAccount
                    {
                        Name = newAccount.Name,
                        Tags = new Dictionary<string, string>
                        {
                            {"updatedKey", "updatedValue"}
                        }
                    }
                });

            Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);
            Assert.Equal(OperationStatus.Succeeded, updateResponse.Status);

            var updateResponseGet = clientToUse.DataLakeStoreAccount.Get(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName);

            Assert.NotNull(updateResponse.RequestId);
            Assert.Contains(responseGet.DataLakeStoreAccount.Id, updateResponseGet.DataLakeStoreAccount.Id);
            Assert.Equal(responseGet.DataLakeStoreAccount.Location, updateResponseGet.DataLakeStoreAccount.Location);
            Assert.Equal(newAccount.Name, updateResponseGet.DataLakeStoreAccount.Name);
            Assert.Equal(responseGet.DataLakeStoreAccount.Type, updateResponseGet.DataLakeStoreAccount.Type);

            // verify the new tags. NOTE: sequence equal is not ideal if we have more than 1 tag, since the ordering can change.
            Assert.True(updateResponseGet.DataLakeStoreAccount.Tags.SequenceEqual(newAccount.Tags));

            // Create another account and ensure that list account returns both
            var accountToChange = updateResponseGet.DataLakeStoreAccount;
            accountToChange.Name = accountToChange.Name + "acct2";
            var parameters = new DataLakeStoreAccountCreateOrUpdateParameters
            {
                DataLakeStoreAccount = accountToChange
            };

            clientToUse.DataLakeStoreAccount.Create(commonData.ResourceGroupName, parameters);

            DataLakeStoreAccountListResponse listResponse = clientToUse.DataLakeStoreAccount.List(commonData.ResourceGroupName, null);

            // Assert that there are at least two accounts in the list
            Assert.True(listResponse.Value.Count > 1);

            // Delete the account and confirm that it is deleted.
            AzureOperationResponse deleteResponse = clientToUse.DataLakeStoreAccount.Delete(commonData.ResourceGroupName, newAccount.Name);

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
            deleteResponse = clientToUse.DataLakeStoreAccount.Delete(commonData.ResourceGroupName, newAccount.Name);
            Assert.Contains<HttpStatusCode>(deleteResponse.StatusCode, acceptedStatusCodes);

            // delete the account with its old name, which should also succeed.
            deleteResponse = clientToUse.DataLakeStoreAccount.Delete(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName);
            Assert.Contains<HttpStatusCode>(deleteResponse.StatusCode, acceptedStatusCodes);

            TestUtilities.EndTest();
        }
    }
}
