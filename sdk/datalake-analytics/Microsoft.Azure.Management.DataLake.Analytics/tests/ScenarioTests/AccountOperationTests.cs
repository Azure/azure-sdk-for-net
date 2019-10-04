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
        public void AccountCRUDTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                commonData = new CommonTestFixture(context, true);
                var clientToUse = this.GetDataLakeAnalyticsAccountManagementClient(context);
                
                // Ensure that the account doesn't exist and that the account name is available
                Assert.False(
                    clientToUse.Accounts.Exists(
                        commonData.ResourceGroupName, 
                        commonData.DataLakeAnalyticsAccountName
                    )
                );

                var checkNameParam = new CheckNameAvailabilityParameters
                {
                    Name = commonData.DataLakeAnalyticsAccountName
                };

                var responseNameCheck = 
                    clientToUse.Accounts.CheckNameAvailability(
                        commonData.Location.Replace(" ", ""), 
                        checkNameParam
                    );

                Assert.True(responseNameCheck.NameAvailable);

                // Create a test account
                var responseCreate =
                    clientToUse.Accounts.Create(
                        commonData.ResourceGroupName, 
                        commonData.DataLakeAnalyticsAccountName,
                        parameters : new CreateDataLakeAnalyticsAccountParameters
                        {
                            Location = commonData.Location,
                            Tags = new Dictionary<string, string>
                            {
                                { "testkey", "testvalue" }
                            },
                            DefaultDataLakeStoreAccount = commonData.DataLakeStoreAccountName,
                            DataLakeStoreAccounts = new List<AddDataLakeStoreWithAccountParameters>
                            {
                                new AddDataLakeStoreWithAccountParameters
                                {
                                    Name = commonData.DataLakeStoreAccountName,
                                    Suffix = commonData.DataLakeStoreAccountSuffix
                                }
                            },
                            NewTier = TierType.Commitment100AUHours
                        }
                    );

                // Verify that the account exists and that the account name is no longer available
                Assert.True(
                    clientToUse.Accounts.Exists(
                        commonData.ResourceGroupName, 
                        commonData.DataLakeAnalyticsAccountName
                    )
                );

                responseNameCheck = 
                    clientToUse.Accounts.CheckNameAvailability(
                        commonData.Location.Replace(" ", ""), 
                        checkNameParam
                    );

                Assert.False(responseNameCheck.NameAvailable);

                // Get the account and ensure that all the values are properly set.
                var responseGet = 
                    clientToUse.Accounts.Get(
                        commonData.ResourceGroupName, 
                        commonData.DataLakeAnalyticsAccountName
                    );

                // Validate the account creation process
                Assert.True(responseGet.ProvisioningState == DataLakeAnalyticsAccountStatus.Creating || responseGet.ProvisioningState == DataLakeAnalyticsAccountStatus.Succeeded);
                Assert.NotNull(responseCreate.Id);
                Assert.NotNull(responseGet.Id);
                Assert.Contains(commonData.DataLakeAnalyticsAccountName, responseGet.Id);
                Assert.Equal(commonData.Location, responseGet.Location);
                Assert.Equal(commonData.DataLakeAnalyticsAccountName, responseGet.Name);
                Assert.Equal("Microsoft.DataLakeAnalytics/accounts", responseGet.Type);
                Assert.True(responseGet.DataLakeStoreAccounts.Count == 1);
                Assert.Equal(responseGet.DataLakeStoreAccounts.ToList()[0].Name, commonData.DataLakeStoreAccountName);

                // Wait for provisioning state to be Succeeded
                // We will wait a maximum of 15 minutes for this to happen and then report failures
                int timeToWaitInMinutes = 15;
                int minutesWaited = 0;
                while (responseGet.ProvisioningState != DataLakeAnalyticsAccountStatus.Succeeded && 
                       responseGet.ProvisioningState != DataLakeAnalyticsAccountStatus.Failed && 
                       minutesWaited <= timeToWaitInMinutes)
                {
                    TestUtilities.Wait(60000); // Wait for one minute and then go again.
                    minutesWaited++;
                    responseGet = 
                        clientToUse.Accounts.Get(
                            commonData.ResourceGroupName, 
                            commonData.DataLakeAnalyticsAccountName
                        );
                }

                // Confirm that the account creation did succeed
                Assert.True(responseGet.ProvisioningState == DataLakeAnalyticsAccountStatus.Succeeded);
                Assert.Equal(TierType.Commitment100AUHours, responseGet.CurrentTier);
                Assert.Equal(TierType.Commitment100AUHours, responseGet.NewTier);

                // Update the account and confirm that the updates make it in.
                var responseUpdate =
                    clientToUse.Accounts.Update(
                        commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName,
                        parameters : new UpdateDataLakeAnalyticsAccountParameters
                        {
                            Tags = new Dictionary<string, string>
                            {
                                { "updatedKey", "updatedValue" }
                            },
                            NewTier = TierType.Consumption
                        }
                    );

                Assert.Equal(DataLakeAnalyticsAccountStatus.Succeeded, responseUpdate.ProvisioningState);

                // Get the account and ensure that all the values are properly set.
                var responseUpdateGet = 
                    clientToUse.Accounts.Get(
                        commonData.ResourceGroupName, 
                        commonData.DataLakeAnalyticsAccountName
                    );

                Assert.NotNull(responseUpdate.Id);
                Assert.Contains(responseGet.Id, responseUpdateGet.Id);
                Assert.Equal(responseGet.Location, responseUpdateGet.Location);
                Assert.Equal(responseGet.Name, responseUpdateGet.Name);
                Assert.Equal(responseGet.Type, responseUpdateGet.Type);

                // Verify the new tags and tier
                Assert.True(responseUpdateGet.Tags.Count == 1);
                Assert.True(responseUpdateGet.Tags.ContainsKey("updatedKey"));
                Assert.True(responseUpdateGet.Tags.Values.Contains("updatedValue"));
                Assert.Equal(TierType.Commitment100AUHours, responseUpdateGet.CurrentTier);
                Assert.Equal(TierType.Consumption, responseUpdateGet.NewTier);

                // Create another account and ensure that list account returns both
                clientToUse.Accounts.Create(
                    commonData.ResourceGroupName,
                    commonData.DataLakeAnalyticsAccountName + "secondacct", 
                    new CreateDataLakeAnalyticsAccountParameters
                    {
                        Location = commonData.Location,
                        DefaultDataLakeStoreAccount = commonData.DataLakeStoreAccountName,
                        DataLakeStoreAccounts = new List<AddDataLakeStoreWithAccountParameters>
                        {
                            new AddDataLakeStoreWithAccountParameters
                            {
                                Name = commonData.DataLakeStoreAccountName,
                                Suffix = commonData.DataLakeStoreAccountSuffix
                            }
                        },
                    }
                );

                var listResponse = clientToUse.Accounts.List();

                // Assert that there are at least two accounts in the list
                Assert.True(listResponse.Count() > 1);

                // Now list with the resource group
                listResponse = clientToUse.Accounts.ListByResourceGroup(commonData.ResourceGroupName);

                // Assert that there are at least two accounts in the list
                Assert.True(listResponse.Count() > 1);

                // Add, list and remove a data source to the first account
                // Validate the data source doesn't exist first
                Assert.False(
                    clientToUse.Accounts.DataLakeStoreAccountExists(
                        commonData.ResourceGroupName, 
                        commonData.DataLakeAnalyticsAccountName, 
                        commonData.SecondDataLakeStoreAccountName
                    )
                );

                clientToUse.DataLakeStoreAccounts.Add(
                    commonData.ResourceGroupName,
                    commonData.DataLakeAnalyticsAccountName,
                    commonData.SecondDataLakeStoreAccountName, 
                    new AddDataLakeStoreParameters
                    {
                        Suffix = commonData.DataLakeStoreAccountSuffix
                    }
                );

                // Verify that the store account does exist now
                Assert.True(
                    clientToUse.Accounts.DataLakeStoreAccountExists(
                        commonData.ResourceGroupName, 
                        commonData.DataLakeAnalyticsAccountName, 
                        commonData.SecondDataLakeStoreAccountName
                    )
                );

                // Get the data sources and confirm there are 2
                var getDataSourceResponse = 
                    clientToUse.DataLakeStoreAccounts.ListByAccount(
                        commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName
                    );

                Assert.Equal(2, getDataSourceResponse.Count());

                // Get the specific data source
                var getSingleDataSourceResponse = 
                    clientToUse.DataLakeStoreAccounts.Get(
                        commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, 
                        commonData.SecondDataLakeStoreAccountName
                    );

                Assert.Equal(commonData.SecondDataLakeStoreAccountName, getSingleDataSourceResponse.Name);
                Assert.Equal(commonData.SecondDataLakeStoreAccountSuffix, getSingleDataSourceResponse.Suffix);

                // Remove the data source we added
                clientToUse.DataLakeStoreAccounts.Delete(
                    commonData.ResourceGroupName,
                    commonData.DataLakeAnalyticsAccountName, 
                    commonData.SecondDataLakeStoreAccountName
                );

                // Confirm that there is now only one data source.
                getDataSourceResponse = 
                    clientToUse.DataLakeStoreAccounts.ListByAccount(
                        commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName
                    );

                Assert.True(getDataSourceResponse.Count() == 1);

                // Add, list and remove an azure blob source to the first account
                // Verify the blob doesn't exist
                Assert.False(
                    clientToUse.Accounts.StorageAccountExists(
                        commonData.ResourceGroupName, 
                        commonData.DataLakeAnalyticsAccountName, 
                        commonData.StorageAccountName
                    )
                );

                clientToUse.StorageAccounts.Add(
                    commonData.ResourceGroupName,
                    commonData.DataLakeAnalyticsAccountName,
                    commonData.StorageAccountName,
                    new AddStorageAccountParameters
                    {
                        Suffix = commonData.StorageAccountSuffix,
                        AccessKey = commonData.StorageAccountAccessKey
                    }
                );

                // Verify the blob exists now
                Assert.True(
                    clientToUse.Accounts.StorageAccountExists(
                        commonData.ResourceGroupName, 
                        commonData.DataLakeAnalyticsAccountName, 
                        commonData.StorageAccountName
                    )
                );

                // Get the data sources and confirm there is 1
                var getDataSourceBlobResponse = 
                    clientToUse.StorageAccounts.ListByAccount(
                        commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName
                    );

                Assert.True(getDataSourceBlobResponse.Count() == 1);

                // Get the specific data source we added and confirm that it has the same properties
                var getSingleDataSourceBlobResponse = 
                    clientToUse.StorageAccounts.Get(
                        commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, 
                        commonData.StorageAccountName
                    );

                Assert.Equal(commonData.StorageAccountName, getSingleDataSourceBlobResponse.Name);
                Assert.Equal(commonData.StorageAccountSuffix, getSingleDataSourceBlobResponse.Suffix);

                // Remove the data source we added
                clientToUse.StorageAccounts.Delete(
                    commonData.ResourceGroupName,
                    commonData.DataLakeAnalyticsAccountName, 
                    commonData.StorageAccountName
                );

                // Confirm that there no azure data sources.
                getDataSourceBlobResponse = 
                    clientToUse.StorageAccounts.ListByAccount(
                        commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName
                    );

                Assert.True(getDataSourceBlobResponse.Count() == 0);

                // Check that Locations_GetCapability and Operations_List are functional
                var responseGetCapability = 
                    clientToUse.Locations.GetCapability(
                        commonData.Location.Replace(" ", "")
                    );

                Assert.NotNull(responseGetCapability);

                var responseListOps = clientToUse.Operations.List();

                Assert.NotNull(responseListOps);

                // Delete the account and confirm that it is deleted.
                clientToUse.Accounts.Delete(
                    commonData.ResourceGroupName,
                    commonData.DataLakeAnalyticsAccountName + "secondacct"
                );

                // Delete the account again and make sure it continues to result in a succesful code.
                clientToUse.Accounts.Delete(
                    commonData.ResourceGroupName,
                    commonData.DataLakeAnalyticsAccountName + "secondacct"
                );

                // Delete the account with its old name, which should also succeed.
                clientToUse.Accounts.Delete(
                    commonData.ResourceGroupName, 
                    commonData.DataLakeAnalyticsAccountName
                );
            }
        }

        [Fact]
        public void ComputePolicyCRUDTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                commonData = new CommonTestFixture(context, true);
                var clientToUse = this.GetDataLakeAnalyticsAccountManagementClient(context);
                var userPolicyObjectId = new Guid("8ce05900-7a9e-4895-b3f0-0fbcee507803");
                var userPolicyName = TestUtilities.GenerateName("adlapolicy1");
                var groupPolicyObjectId = new Guid("0583cfd7-60f5-43f0-9597-68b85591fc69");
                var groupPolicyName = TestUtilities.GenerateName("adlapolicy2");
                var adlaAccountName = TestUtilities.GenerateName("adlaacct1");

                // Ensure the account doesn't exist
                Assert.False(
                    clientToUse.Accounts.Exists(
                        commonData.ResourceGroupName, 
                        adlaAccountName
                    )
                );

                // Create a test account
                var responseCreate =
                    clientToUse.Accounts.Create(
                        commonData.ResourceGroupName, 
                        adlaAccountName,
                        parameters: new CreateDataLakeAnalyticsAccountParameters
                        {
                            Location = commonData.Location,
                            DefaultDataLakeStoreAccount = commonData.DataLakeStoreAccountName,
                            DataLakeStoreAccounts = new List<AddDataLakeStoreWithAccountParameters>
                            {
                                new AddDataLakeStoreWithAccountParameters
                                {
                                    Name = commonData.DataLakeStoreAccountName,
                                    Suffix = commonData.DataLakeStoreAccountSuffix
                                }
                            },
                            NewTier = TierType.Commitment100AUHours,
                            ComputePolicies = new List<CreateComputePolicyWithAccountParameters>
                            {
                                new CreateComputePolicyWithAccountParameters
                                {
                                    Name = userPolicyName,
                                    ObjectId = userPolicyObjectId,
                                    ObjectType = AADObjectType.User,
                                    MaxDegreeOfParallelismPerJob = 1,
                                    MinPriorityPerJob = 1,
                                }
                            }
                        }
                    );

                // Get the account and ensure that all the values are properly set.
                var responseGet = 
                    clientToUse.Accounts.Get(
                        commonData.ResourceGroupName, 
                        adlaAccountName
                    );

                // Validate compute policies are set on creation.
                Assert.True(responseGet.ComputePolicies.Count == 1);
                Assert.Equal(responseGet.ComputePolicies.ToList()[0].Name, userPolicyName);

                // Validate compute policy CRUD
                // Add another account
                var computePolicy = 
                    clientToUse.ComputePolicies.CreateOrUpdate(
                        commonData.ResourceGroupName,
                        adlaAccountName,
                        groupPolicyName,
                        new CreateOrUpdateComputePolicyParameters
                        {
                            ObjectId = groupPolicyObjectId,
                            ObjectType = AADObjectType.Group,
                            MaxDegreeOfParallelismPerJob = 1,
                            MinPriorityPerJob = 1,
                        }
                    );

                Assert.Equal(1, computePolicy.MaxDegreeOfParallelismPerJob);
                Assert.Equal(1, computePolicy.MinPriorityPerJob);
                Assert.Equal(groupPolicyObjectId, computePolicy.ObjectId);
                Assert.Equal(AADObjectType.Group, computePolicy.ObjectType);

                // Get the compute policy
                computePolicy = 
                    clientToUse.ComputePolicies.Get(
                        commonData.ResourceGroupName,
                        adlaAccountName,
                        groupPolicyName
                    );

                Assert.Equal(1, computePolicy.MaxDegreeOfParallelismPerJob);
                Assert.Equal(1, computePolicy.MinPriorityPerJob);
                Assert.Equal(groupPolicyObjectId, computePolicy.ObjectId);
                Assert.Equal(AADObjectType.Group, computePolicy.ObjectType);

                // List all policies
                var policyList = 
                    clientToUse.ComputePolicies.ListByAccount(
                        commonData.ResourceGroupName,
                        adlaAccountName
                    );

                Assert.Equal(2, policyList.Count());

                // Remove the new policy
                clientToUse.ComputePolicies.Delete(
                    commonData.ResourceGroupName,
                    adlaAccountName,
                    groupPolicyName
                );

                policyList = 
                    clientToUse.ComputePolicies.ListByAccount(
                        commonData.ResourceGroupName,
                        adlaAccountName
                    );

                Assert.True(policyList.Count() == 1);

                // Delete the account
                clientToUse.Accounts.Delete(commonData.ResourceGroupName, adlaAccountName);
            }
        }

        [Fact]
        public void FirewallCRUDTest()
        {
            using (var context = MockContext.Start(this.GetType()))
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
                    clientToUse.Accounts.Create(
                        commonData.ResourceGroupName, 
                        adlaAcocunt,
                        parameters : new CreateDataLakeAnalyticsAccountParameters
                        {
                            Location = commonData.Location,
                            DefaultDataLakeStoreAccount = commonData.DataLakeStoreAccountName,
                            DataLakeStoreAccounts = new List<AddDataLakeStoreWithAccountParameters>
                            {
                                new AddDataLakeStoreWithAccountParameters
                                {
                                    Name = commonData.DataLakeStoreAccountName,
                                    Suffix = commonData.DataLakeStoreAccountSuffix
                                }
                            },
                            FirewallState = FirewallState.Enabled,
                            FirewallAllowAzureIps = FirewallAllowAzureIpsState.Enabled,
                            FirewallRules = new List<CreateFirewallRuleWithAccountParameters>
                            {
                                new CreateFirewallRuleWithAccountParameters
                                {
                                    Name = firewallRuleName1,
                                    StartIpAddress = firewallStart,
                                    EndIpAddress = firewallEnd,
                                }
                            },
                        }
                    );

                Assert.Equal(DataLakeAnalyticsAccountStatus.Succeeded, responseCreate.ProvisioningState);

                // Get the account and ensure that all the values are properly set.
                var responseGet = 
                    clientToUse.Accounts.Get(
                        commonData.ResourceGroupName, 
                        adlaAcocunt
                    );

                // Validate the account creation process
                Assert.Equal(DataLakeAnalyticsAccountStatus.Succeeded, responseGet.ProvisioningState);
                Assert.NotNull(responseCreate.Id);
                Assert.NotNull(responseGet.Id);
                Assert.Contains(adlaAcocunt, responseGet.Id);
                Assert.Equal(commonData.Location, responseGet.Location);
                Assert.Equal(adlaAcocunt, responseGet.Name);
                Assert.Equal("Microsoft.DataLakeAnalytics/accounts", responseGet.Type);

                // Validate firewall state
                Assert.Equal(FirewallState.Enabled, responseGet.FirewallState);
                Assert.True(responseGet.FirewallRules.Count() == 1);
                Assert.Equal(firewallStart, responseGet.FirewallRules[0].StartIpAddress);
                Assert.Equal(firewallEnd, responseGet.FirewallRules[0].EndIpAddress);
                Assert.Equal(firewallRuleName1, responseGet.FirewallRules[0].Name);
                Assert.Equal(FirewallAllowAzureIpsState.Enabled, responseGet.FirewallAllowAzureIps);

                // Test getting the specific firewall rules
                var firewallRule = 
                    clientToUse.FirewallRules.Get(
                        commonData.ResourceGroupName, 
                        adlaAcocunt, 
                        firewallRuleName1
                    );

                Assert.Equal(firewallStart, firewallRule.StartIpAddress);
                Assert.Equal(firewallEnd, firewallRule.EndIpAddress);
                Assert.Equal(firewallRuleName1, firewallRule.Name);

                var updatedFirewallStart = "192.168.0.0";
                var updatedFirewallEnd = "192.168.0.1";

                // Update the firewall rule to change the start/end ip addresses
                firewallRule = 
                    clientToUse.FirewallRules.CreateOrUpdate(
                        commonData.ResourceGroupName, 
                        adlaAcocunt, 
                        firewallRuleName1, 
                        parameters : new CreateOrUpdateFirewallRuleParameters
                        {
                            StartIpAddress = updatedFirewallStart,
                            EndIpAddress = updatedFirewallEnd,
                        }
                    );

                Assert.Equal(updatedFirewallStart, firewallRule.StartIpAddress);
                Assert.Equal(updatedFirewallEnd, firewallRule.EndIpAddress);
                Assert.Equal(firewallRuleName1, firewallRule.Name);

                // Just update the firewall rule start IP
                firewallRule = 
                    clientToUse.FirewallRules.Update(
                        commonData.ResourceGroupName,
                        adlaAcocunt,
                        firewallRuleName1,
                        parameters : new UpdateFirewallRuleParameters
                        {
                            StartIpAddress = firewallStart
                        }
                    );

                Assert.Equal(firewallStart, firewallRule.StartIpAddress);
                Assert.Equal(updatedFirewallEnd, firewallRule.EndIpAddress);
                Assert.Equal(firewallRuleName1, firewallRule.Name);

                // Remove the firewall rule and verify it is gone.
                clientToUse.FirewallRules.Delete(
                    commonData.ResourceGroupName, 
                    adlaAcocunt, 
                    firewallRuleName1
                );

                try
                {
                    firewallRule = 
                        clientToUse.FirewallRules.Get(
                            commonData.ResourceGroupName, 
                            adlaAcocunt, 
                            firewallRuleName1
                        );

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

