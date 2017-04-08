// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure;
using Microsoft.Azure.Management.DataLake.Analytics;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;
namespace DataLakeAnalytics.Tests
{
    public class AccountOperationTests : TestBase
    {
        private CommonTestFixture commonData;
        [Fact]
        public void CreateGetUpdateDeleteTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                commonData = new CommonTestFixture(context, true);
                var clientToUse = this.GetDataLakeAnalyticsAccountManagementClient(context);

                // ensure the account doesn't exist
                Assert.False(clientToUse.Account.Exists(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName));

                // Create a test account
                var responseCreate =
                    clientToUse.Account.Create(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName,
                        parameters: new DataLakeAnalyticsAccount
                        {
                            Location = commonData.Location,
                            DefaultDataLakeStoreAccount = commonData.DataLakeStoreAccountName,
                            DataLakeStoreAccounts = new List<DataLakeStoreAccountInfo>
                            {
                                new DataLakeStoreAccountInfo
                                {
                                    Name = commonData.DataLakeStoreAccountName,
                                    Suffix = commonData.DataLakeStoreAccountSuffix
                                }
                            },
                            Tags = new Dictionary<string, string>
                            {
                                { "testkey","testvalue" }
                            },
                            NewTier = TierType.Commitment100AUHours
                        });

                // verify the account exists
                Assert.True(clientToUse.Account.Exists(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName));

                // get the account and ensure that all the values are properly set.
                var responseGet = clientToUse.Account.Get(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName);

                // validate the account creation process
                Assert.True(responseGet.ProvisioningState == DataLakeAnalyticsAccountStatus.Creating || responseGet.ProvisioningState == DataLakeAnalyticsAccountStatus.Succeeded);
                Assert.NotNull(responseCreate.Id);
                Assert.NotNull(responseGet.Id);
                Assert.Contains(commonData.DataLakeAnalyticsAccountName, responseGet.Id);
                Assert.Equal(commonData.Location, responseGet.Location);
                Assert.Equal(commonData.DataLakeAnalyticsAccountName, responseGet.Name);
                Assert.Equal("Microsoft.DataLakeAnalytics/accounts", responseGet.Type);

                Assert.True(responseGet.DataLakeStoreAccounts.Count == 1);
                Assert.True(responseGet.DataLakeStoreAccounts.ToList()[0].Name.Equals(commonData.DataLakeStoreAccountName));

                // wait for provisioning state to be Succeeded
                // we will wait a maximum of 15 minutes for this to happen and then report failures
                int timeToWaitInMinutes = 15;
                int minutesWaited = 0;
                while (responseGet.ProvisioningState != DataLakeAnalyticsAccountStatus.Succeeded && responseGet.ProvisioningState != DataLakeAnalyticsAccountStatus.Failed && minutesWaited <= timeToWaitInMinutes)
                {
                    TestUtilities.Wait(60000); // Wait for one minute and then go again.
                    minutesWaited++;
                    responseGet = clientToUse.Account.Get(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName);
                }

                // Confirm that the account creation did succeed
                Assert.True(responseGet.ProvisioningState == DataLakeAnalyticsAccountStatus.Succeeded);
                Assert.Equal(TierType.Commitment100AUHours, responseGet.CurrentTier);
                Assert.Equal(TierType.Commitment100AUHours, responseGet.NewTier);
                // Update the account and confirm the updates make it in.
                var newAccount = responseGet;
                var firstStorageAccountName = newAccount.DataLakeStoreAccounts.ToList()[0].Name;
                newAccount.Tags = new Dictionary<string, string>
                {
                    {"updatedKey", "updatedValue"}
                };

                // need to null out deep properties to prevent an error
                newAccount.DataLakeStoreAccounts = null;
                newAccount.StorageAccounts = null;

                var updateAccount = new DataLakeAnalyticsAccountUpdateParameters
                {
                    Tags = newAccount.Tags,
                    NewTier = TierType.Consumption
                };

                var updateResponse = clientToUse.Account.Update(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName, updateAccount);

                Assert.Equal(DataLakeAnalyticsAccountStatus.Succeeded, updateResponse.ProvisioningState);

                // get the account and ensure that all the values are properly set.
                var updateResponseGet = clientToUse.Account.Get(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName);

                Assert.NotNull(updateResponse.Id);
                Assert.Contains(responseGet.Id, updateResponseGet.Id);
                Assert.Equal(responseGet.Location, updateResponseGet.Location);
                Assert.Equal(newAccount.Name, updateResponseGet.Name);
                Assert.Equal(responseGet.Type, updateResponseGet.Type);

                // verify the new tags. NOTE: sequence equal is not ideal if we have more than 1 tag, since the ordering can change.
                Assert.True(updateResponseGet.Tags.SequenceEqual(newAccount.Tags));
                Assert.True(updateResponseGet.DataLakeStoreAccounts.Count == 1);
                Assert.True(updateResponseGet.DataLakeStoreAccounts.ToList()[0].Name.Equals(firstStorageAccountName));
                Assert.Equal(TierType.Commitment100AUHours, updateResponseGet.CurrentTier);
                Assert.Equal(TierType.Consumption, updateResponseGet.NewTier);

                // Create another account and ensure that list account returns both
                responseGet = clientToUse.Account.Get(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName);
                var accountToChange = responseGet;
                var newAcctName = accountToChange.Name + "secondacct";

                clientToUse.Account.Create(commonData.ResourceGroupName, newAcctName, new DataLakeAnalyticsAccount
                {
                    Location = accountToChange.Location,
                    DefaultDataLakeStoreAccount = accountToChange.DefaultDataLakeStoreAccount,
                    DataLakeStoreAccounts = accountToChange.DataLakeStoreAccounts
                });

                var listResponse = clientToUse.Account.List();

                // Assert that there are at least two accounts in the list
                Assert.True(listResponse.Count() > 1);

                // now list with the resource group
                listResponse = clientToUse.Account.ListByResourceGroup(commonData.ResourceGroupName);

                // Assert that there are at least two accounts in the list
                Assert.True(listResponse.Count() > 1);

                // Add, list and remove a data source to the first account
                // validate the data source doesn't exist first
                Assert.False(clientToUse.Account.DataLakeStoreAccountExists(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName, commonData.SecondDataLakeStoreAccountName));
                clientToUse.DataLakeStoreAccounts.Add(
                    commonData.ResourceGroupName,
                    commonData.DataLakeAnalyticsAccountName,
                    commonData.SecondDataLakeStoreAccountName, 
                    new AddDataLakeStoreParameters {Suffix = commonData.DataLakeStoreAccountSuffix});

                // verify that the store account does exist now
                Assert.True(clientToUse.Account.DataLakeStoreAccountExists(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName, commonData.SecondDataLakeStoreAccountName));

                // Get the data sources and confirm there are 2
                var getDataSourceResponse =
                    clientToUse.DataLakeStoreAccounts.ListByAccount(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, null);

                Assert.Equal(2, getDataSourceResponse.Count());

                // get the specific data source
                var getSingleDataSourceResponse =
                    clientToUse.DataLakeStoreAccounts.Get(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.SecondDataLakeStoreAccountName);

                Assert.Equal(commonData.SecondDataLakeStoreAccountName, getSingleDataSourceResponse.Name);
                Assert.Equal(commonData.SecondDataLakeStoreAccountSuffix, getSingleDataSourceResponse.Suffix);

                // Remove the data source we added
                clientToUse.DataLakeStoreAccounts.Delete(commonData.ResourceGroupName,
                    commonData.DataLakeAnalyticsAccountName, commonData.SecondDataLakeStoreAccountName);

                // Confirm that there is now only one data source.
                getDataSourceResponse =
                    clientToUse.DataLakeStoreAccounts.ListByAccount(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, null);

                Assert.Equal(1, getDataSourceResponse.Count());

                // Add, list and remove an azure blob source to the first account
                // verify the blob doesn't exist
                Assert.False(clientToUse.Account.StorageAccountExists(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName, commonData.StorageAccountName));
                clientToUse.StorageAccounts.Add(
                    commonData.ResourceGroupName,
                    commonData.DataLakeAnalyticsAccountName,
                    commonData.StorageAccountName,
                    new AddStorageAccountParameters
                    {
                        Suffix = commonData.StorageAccountSuffix,
                        AccessKey = commonData.StorageAccountAccessKey
                    });

                // verify the blob exists now
                Assert.True(clientToUse.Account.StorageAccountExists(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName, commonData.StorageAccountName));

                // Get the data sources and confirm there is 1
                var getDataSourceBlobResponse =
                    clientToUse.StorageAccounts.ListByAccount(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, null);

                Assert.Equal(1, getDataSourceBlobResponse.Count());

                // Get the specific data source we added and confirm that it has the same properties
                var getSingleDataSourceBlobResponse =
                    clientToUse.StorageAccounts.Get(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.StorageAccountName);

                Assert.Equal(commonData.StorageAccountName, getSingleDataSourceBlobResponse.Name);
                Assert.True(string.IsNullOrEmpty(getSingleDataSourceBlobResponse.AccessKey));
                Assert.Equal(commonData.StorageAccountSuffix, getSingleDataSourceBlobResponse.Suffix);

                // Remove the data source we added
                clientToUse.StorageAccounts.Delete(commonData.ResourceGroupName,
                    commonData.DataLakeAnalyticsAccountName, commonData.StorageAccountName);

                // Confirm that there no azure data sources.
                getDataSourceBlobResponse =
                    clientToUse.StorageAccounts.ListByAccount(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, null);

                Assert.Equal(0, getDataSourceBlobResponse.Count());

                // Delete the account and confirm that it is deleted.
                clientToUse.Account.Delete(commonData.ResourceGroupName, newAccount.Name);

                // delete the account again and make sure it continues to result in a succesful code.
                clientToUse.Account.Delete(commonData.ResourceGroupName, newAccount.Name);

                // delete the account with its old name, which should also succeed.
                clientToUse.Account.Delete(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName);

                // delete the second account that was created to ensure that we properly clean up after ourselves.
                clientToUse.Account.Delete(commonData.ResourceGroupName, accountToChange.Name);
            }
        }

        [Fact]
        public void FirewallTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                commonData = new CommonTestFixture(context);
                var clientToUse = this.GetDataLakeAnalyticsAccountManagementClient(context);

                // Create a an account with trusted ID provider and firewall rules.
                var firewallStart = "127.0.0.1";
                var firewallEnd = "127.0.0.2";
                var firewallRuleName1 = TestUtilities.GenerateName("firerule1");
                var adlaAcocunt = TestUtilities.GenerateName("adla01");
                // Create a test account
                var responseCreate =
                    clientToUse.Account.Create(commonData.ResourceGroupName, adlaAcocunt,
                        parameters: new DataLakeAnalyticsAccount
                        {
                            Location = commonData.Location,
                            DefaultDataLakeStoreAccount = commonData.DataLakeStoreAccountName,
                            DataLakeStoreAccounts = new List<DataLakeStoreAccountInfo>
                            {
                                new DataLakeStoreAccountInfo
                                {
                                    Name = commonData.DataLakeStoreAccountName,
                                    Suffix = commonData.DataLakeStoreAccountSuffix
                                }
                            },
                            FirewallRules = new List<FirewallRule>
                            {
                                new FirewallRule(firewallStart, firewallEnd, name: firewallRuleName1)
                            },
                            FirewallAllowAzureIps = FirewallAllowAzureIpsState.Enabled,
                            FirewallState = FirewallState.Enabled
                        });

                Assert.Equal(DataLakeAnalyticsAccountStatus.Succeeded, responseCreate.ProvisioningState);

                // get the account and ensure that all the values are properly set.
                var responseGet = clientToUse.Account.Get(commonData.ResourceGroupName, adlaAcocunt);

                // validate the account creation process
                Assert.Equal(DataLakeAnalyticsAccountStatus.Succeeded, responseGet.ProvisioningState);
                Assert.NotNull(responseCreate.Id);
                Assert.NotNull(responseGet.Id);
                Assert.Contains(adlaAcocunt, responseGet.Id);
                Assert.Equal(commonData.Location, responseGet.Location);
                Assert.Equal(adlaAcocunt, responseGet.Name);
                Assert.Equal("Microsoft.DataLakeAnalytics/accounts", responseGet.Type);

                // validate firewall state
                Assert.Equal(FirewallState.Enabled, responseGet.FirewallState);
                Assert.Equal(1, responseGet.FirewallRules.Count());
                Assert.Equal(firewallStart, responseGet.FirewallRules[0].StartIpAddress);
                Assert.Equal(firewallEnd, responseGet.FirewallRules[0].EndIpAddress);
                Assert.Equal(firewallRuleName1, responseGet.FirewallRules[0].Name);
                
                // TODO: re-enable when this is re-enabled on the server side.
                //Assert.Equal(FirewallAllowAzureIpsState.Enabled, responseGet.FirewallAllowAzureIps);

                // Test getting the specific firewall rules
                var firewallRule = clientToUse.FirewallRules.Get(commonData.ResourceGroupName, adlaAcocunt, firewallRuleName1);
                Assert.Equal(firewallStart, firewallRule.StartIpAddress);
                Assert.Equal(firewallEnd, firewallRule.EndIpAddress);
                Assert.Equal(firewallRuleName1, firewallRule.Name);


                var updatedFirewallStart = "192.168.0.0";
                var updatedFirewallEnd = "192.168.0.1";
                firewallRule.StartIpAddress = updatedFirewallStart;
                firewallRule.EndIpAddress = updatedFirewallEnd;

                // Update the firewall rule to change the start/end ip addresses
                firewallRule = clientToUse.FirewallRules.CreateOrUpdate(commonData.ResourceGroupName, adlaAcocunt, firewallRuleName1, firewallRule);
                Assert.Equal(updatedFirewallStart, firewallRule.StartIpAddress);
                Assert.Equal(updatedFirewallEnd, firewallRule.EndIpAddress);
                Assert.Equal(firewallRuleName1, firewallRule.Name);

                // just update the firewall rule start IP
                firewallRule = clientToUse.FirewallRules.Update(
                    commonData.ResourceGroupName,
                    adlaAcocunt,
                    firewallRuleName1,
                    new UpdateFirewallRuleParameters
                    {
                        StartIpAddress = firewallStart
                    });

                Assert.Equal(firewallStart, firewallRule.StartIpAddress);
                Assert.Equal(updatedFirewallEnd, firewallRule.EndIpAddress);
                Assert.Equal(firewallRuleName1, firewallRule.Name);

                // Remove the firewall rule and verify it is gone.
                clientToUse.FirewallRules.Delete(commonData.ResourceGroupName, adlaAcocunt, firewallRuleName1);

                try
                {
                    firewallRule = clientToUse.FirewallRules.Get(commonData.ResourceGroupName, adlaAcocunt, firewallRuleName1);
                    Assert.True(false, "Attempting to retrieve a deleted firewall rule did not throw.");
                }
                catch (CloudException e)
                {
                    Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
                }
            }
        }
    }
}
