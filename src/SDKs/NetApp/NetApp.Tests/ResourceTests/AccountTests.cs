﻿using NetApp.Tests.Helpers;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using Xunit;
using System;
using Microsoft.Azure.Management.NetApp.Models;
using System.Collections.Generic;

namespace NetApp.Tests.ResourceTests
{
    public class AccountTests : TestBase
    {
        [Fact]
        public void CreateDeleteAccount()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the account
                ResourceUtils.CreateAccount(netAppMgmtClient);

                // get all accounts and check
                var accountsBefore = netAppMgmtClient.Accounts.List(ResourceUtils.resourceGroup);
                Assert.Single(accountsBefore);

                // remove the account and check
                netAppMgmtClient.Accounts.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1);

                // get all accounts and check
                var accountsAfter = netAppMgmtClient.Accounts.List(ResourceUtils.resourceGroup);
                Assert.Empty(accountsAfter);
            }
        }

        [Fact]
        public void ListAccounts()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create two accounts
                ResourceUtils.CreateAccount(netAppMgmtClient);
                ResourceUtils.CreateAccount(netAppMgmtClient, ResourceUtils.accountName2);

                // get the account list and check
                var accounts = netAppMgmtClient.Accounts.List(ResourceUtils.resourceGroup);
                Assert.Equal(accounts.ElementAt(0).Name, ResourceUtils.accountName1);
                Assert.Equal(accounts.ElementAt(1).Name, ResourceUtils.accountName2);
                Assert.Equal(2, accounts.Count());

                // clean up - delete the two accounts
                ResourceUtils.DeleteAccount(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient, ResourceUtils.accountName2);
            }
        }

        [Fact]
        public void GetAccountByName()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the account
                ResourceUtils.CreateAccount(netAppMgmtClient, ResourceUtils.accountName1);

                // get and check the account
                var account = netAppMgmtClient.Accounts.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1);
                Assert.Equal(account.Name, ResourceUtils.accountName1);

                // clean up - delete the account
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void UpdateAccountNotPermitted()
        {
            // a put update is not a valid operation

            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the account
                ResourceUtils.CreateAccount(netAppMgmtClient);

                // Now try and modify it
                var netAppAccount = new NetAppAccount()
                {
                    Location = ResourceUtils.location,
                };

                try
                {
                    netAppMgmtClient.Accounts.CreateOrUpdate(netAppAccount, ResourceUtils.resourceGroup, ResourceUtils.accountName1);
                    Assert.True(false);
                }
                catch (Exception ex)
                {
                    Assert.Contains("MethodNotAllowed", ex.Message);
                }

                // cleanup - remove the account
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void GetAccountByNameNotFound()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // get and check the account
                try
                {
                    var account = netAppMgmtClient.Accounts.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1);
                    Assert.True(false); // expecting exception
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }
            }
        }

        [Fact]
        public void PatchAccount()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the account
                ResourceUtils.CreateAccount(netAppMgmtClient);

                var dict = new Dictionary<string, string>();
                dict.Add("Tag1", "Value1");

                // Now try and modify it
                var netAppAccountPatch = new NetAppAccountPatch()
                {
                    Tags = dict
                };

                var resource = netAppMgmtClient.Accounts.Update(netAppAccountPatch, ResourceUtils.resourceGroup, ResourceUtils.accountName1);
                Assert.True(resource.Tags.ToString().Contains("Tag1") && resource.Tags.ToString().Contains("Value1"));

                // cleanup - remove the account
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(NetApp.Tests.ResourceTests.AccountTests).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}
