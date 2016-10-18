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
using Microsoft.Rest.Azure;
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
        [Fact]
        public void FirewallAndTrustedProviderTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                commonData = new CommonTestFixture(context);
                var clientToUse = this.GetDataLakeStoreAccountManagementClient(context);

                // Create a an account with trusted ID provider and firewall rules.
                var firewallStart = "127.0.0.1";
                var firewallEnd = "127.0.0.2";
                var firewallRuleName1 = TestUtilities.GenerateName("firerule1");

                var trustedId = TestUtilities.GenerateGuid();
                var trustedUrl = string.Format("https://sts.windows.net/{0}", trustedId.ToString());
                var trustedIdName = TestUtilities.GenerateName("trustedrule1");

                var adlsAccountName = TestUtilities.GenerateName("adlsacct");
                
                var responseCreate =
                    clientToUse.Account.Create(resourceGroupName: commonData.ResourceGroupName, name: adlsAccountName,
                        parameters: new DataLakeStoreAccount
                        {
                            Name = adlsAccountName,
                            Location = commonData.Location,
                            Properties = new DataLakeStoreAccountProperties(firewallRules: new List<FirewallRule>
                            {
                                new FirewallRule
                                {
                                    Name = firewallRuleName1,
                                    Properties = new FirewallRuleProperties
                                    {
                                        StartIpAddress = firewallStart,
                                        EndIpAddress = firewallEnd
                                    }
                                }
                            },
                            trustedIdProviders: new List<TrustedIdProvider>
                            {
                                new TrustedIdProvider
                                {
                                    Name = trustedIdName,
                                    Properties = new TrustedIdProviderProperties
                                    {
                                        IdProvider = trustedUrl
                                    }
                                }
                            })
                            {
                                FirewallState = FirewallState.Enabled,
                                TrustedIdProviderState = TrustedIdProviderState.Enabled,
                            }
                        });

                Assert.Equal(DataLakeStoreAccountStatus.Succeeded, responseCreate.Properties.ProvisioningState);

                // get the account and ensure that all the values are properly set.
                var responseGet = clientToUse.Account.Get(commonData.ResourceGroupName, adlsAccountName);

                // validate the account creation process
                Assert.Equal(DataLakeStoreAccountStatus.Succeeded, responseGet.Properties.ProvisioningState);
                Assert.NotNull(responseCreate.Id);
                Assert.NotNull(responseGet.Id);
                Assert.Contains(adlsAccountName, responseGet.Id);
                Assert.Contains(adlsAccountName, responseGet.Properties.Endpoint);
                Assert.Equal(commonData.Location, responseGet.Location);
                Assert.Equal(adlsAccountName, responseGet.Name);
                Assert.Equal("Microsoft.DataLakeStore/accounts", responseGet.Type);

                // validate firewall state
                Assert.Equal(FirewallState.Enabled, responseGet.Properties.FirewallState);
                Assert.Equal(1, responseGet.Properties.FirewallRules.Count());
                Assert.Equal(firewallStart, responseGet.Properties.FirewallRules[0].Properties.StartIpAddress);
                Assert.Equal(firewallEnd, responseGet.Properties.FirewallRules[0].Properties.EndIpAddress);
                Assert.Equal(firewallRuleName1, responseGet.Properties.FirewallRules[0].Name);

                // validate trusted identity provider state
                Assert.Equal(TrustedIdProviderState.Enabled, responseGet.Properties.TrustedIdProviderState);
                Assert.Equal(1, responseGet.Properties.TrustedIdProviders.Count());
                Assert.Equal(trustedUrl, responseGet.Properties.TrustedIdProviders[0].Properties.IdProvider);
                Assert.Equal(trustedIdName, responseGet.Properties.TrustedIdProviders[0].Name);

                // Test getting the specific firewall rules
                var firewallRule = clientToUse.Account.GetFirewallRule(commonData.ResourceGroupName, adlsAccountName, firewallRuleName1);
                Assert.Equal(firewallStart, firewallRule.Properties.StartIpAddress);
                Assert.Equal(firewallEnd, firewallRule.Properties.EndIpAddress);
                Assert.Equal(firewallRuleName1, firewallRule.Name);


                var updatedFirewallStart = "192.168.0.0";
                var updatedFirewallEnd = "192.168.0.1";
                firewallRule.Properties.StartIpAddress = updatedFirewallStart;
                firewallRule.Properties.EndIpAddress = updatedFirewallEnd;

                // Update the firewall rule to change the start/end ip addresses
                firewallRule = clientToUse.Account.CreateOrUpdateFirewallRule(commonData.ResourceGroupName, adlsAccountName,firewallRuleName1, firewallRule);
                Assert.Equal(updatedFirewallStart, firewallRule.Properties.StartIpAddress);
                Assert.Equal(updatedFirewallEnd, firewallRule.Properties.EndIpAddress);
                Assert.Equal(firewallRuleName1, firewallRule.Name);

                // Remove the firewall rule and verify it is gone.
                clientToUse.Account.DeleteFirewallRule(commonData.ResourceGroupName, adlsAccountName, firewallRuleName1);

                try
                {
                    firewallRule = clientToUse.Account.GetFirewallRule(commonData.ResourceGroupName, adlsAccountName, firewallRuleName1);
                    Assert.True(false, "Attempting to retrieve a deleted firewall rule did not throw.");
                }
                catch (CloudException e)
                {
                    Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
                }

                // Test getting the specific trusted identity provider
                var trustedIdProvider = clientToUse.Account.GetTrustedIdProvider(commonData.ResourceGroupName, adlsAccountName, trustedIdName);
                Assert.Equal(trustedUrl, trustedIdProvider.Properties.IdProvider);
                Assert.Equal(trustedIdName, trustedIdProvider.Name);


                var updatedIdUrl = string.Format("https://sts.windows.net/{0}", TestUtilities.GenerateGuid().ToString());
                trustedIdProvider.Properties.IdProvider = updatedIdUrl;

                // Update the firewall rule to change the start/end ip addresses
                trustedIdProvider = clientToUse.Account.CreateOrUpdateTrustedIdProvider(commonData.ResourceGroupName, adlsAccountName, trustedIdName, trustedIdProvider);
                Assert.Equal(updatedIdUrl, trustedIdProvider.Properties.IdProvider);
                Assert.Equal(trustedIdName, trustedIdProvider.Name);

                // Remove the firewall rule and verify it is gone.
                clientToUse.Account.DeleteTrustedIdProvider(commonData.ResourceGroupName, adlsAccountName, trustedIdName);

                try
                {
                    trustedIdProvider = clientToUse.Account.GetTrustedIdProvider(commonData.ResourceGroupName, adlsAccountName, trustedIdName);
                    Assert.True(false, "Attempting to retrieve a deleted trusted identity provider did not throw.");
                }
                catch (CloudException e)
                {
                    Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
                }
            }
        }
    }
}
