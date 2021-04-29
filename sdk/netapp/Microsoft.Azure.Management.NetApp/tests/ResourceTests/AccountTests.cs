using NetApp.Tests.Helpers;
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
using Microsoft.Rest.Azure;

namespace NetApp.Tests.ResourceTests
{
    public class AccountTests : TestBase
    {
        [Fact]
        public void CreateDeleteAccount()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var accountsInitial = netAppMgmtClient.Accounts.List(ResourceUtils.resourceGroup);
                int initialCount = accountsInitial.Count();

                // create the account with only the one required property
                var netAppAccount = new NetAppAccount()
                {
                    Location = ResourceUtils.location
                };

                var resource = netAppMgmtClient.Accounts.CreateOrUpdate(netAppAccount, ResourceUtils.resourceGroup, ResourceUtils.accountName1);
                Assert.Equal(resource.Name, ResourceUtils.accountName1);
                Assert.Null(resource.Tags);
                Assert.Null(resource.ActiveDirectories);

                // get all accounts and check
                var accountsBefore = netAppMgmtClient.Accounts.List(ResourceUtils.resourceGroup);
                Assert.Equal(initialCount + 1, accountsBefore.Count());

                // remove the account and check
                netAppMgmtClient.Accounts.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1);

                // get all accounts and check
                var accountsAfter = netAppMgmtClient.Accounts.List(ResourceUtils.resourceGroup);
                Assert.Equal(initialCount, accountsAfter.Count());
            }
        }

        [Fact]
        public void CreateAccountWithProperties()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var dict = new Dictionary<string, string>();
                dict.Add("Tag1", "Value1");

                // create the account
                var resource = ResourceUtils.CreateAccount(netAppMgmtClient, tags: dict, activeDirectory: ResourceUtils.activeDirectory);
                Assert.True(resource.Tags.ContainsKey("Tag1"));
                Assert.Equal("Value1", resource.Tags["Tag1"]);
                Assert.NotNull(resource.ActiveDirectories);

                // remove the account
                netAppMgmtClient.Accounts.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1);
            }
        }

        [Fact]
        public void UpdateAccount()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the account
                ResourceUtils.CreateAccount(netAppMgmtClient);

                // perform create/update operation again for same account
                // this should be treated as an update and accepted
                // could equally do this with some property fields added

                var dict = new Dictionary<string, string>();
                dict.Add("Tag1", "Value2");

                var resource = ResourceUtils.CreateAccount(netAppMgmtClient, tags: dict);
                Assert.True(resource.Tags.ContainsKey("Tag1"));
                Assert.Equal("Value2", resource.Tags["Tag1"]);
            }
        }

        [Fact]
        public void ListAccounts()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var accountsBefore = netAppMgmtClient.Accounts.List(ResourceUtils.resourceGroup);
                int count = accountsBefore.Count();
                // create two accounts
                ResourceUtils.CreateAccount(netAppMgmtClient);
                ResourceUtils.CreateAccount(netAppMgmtClient, ResourceUtils.accountName2);

                // get the account list and check
                var accounts = netAppMgmtClient.Accounts.List(ResourceUtils.resourceGroup);
                Assert.Contains(accounts, item => item.Name == ResourceUtils.accountName1);
                Assert.Contains(accounts, item => item.Name == ResourceUtils.accountName2);

                // clean up - delete the two accounts
                ResourceUtils.DeleteAccount(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient, ResourceUtils.accountName2);
            }
        }

        [Fact]
        public void GetAccountByName()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
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
        public void GetAccountByNameNotFound()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            string expectedErrorCode = "ResourceNotFound";
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // get and check the account
                try
                {
                    var account = netAppMgmtClient.Accounts.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1);
                    Assert.True(false); // expecting exception
                }

                catch (CloudException cex)
                {
                    Assert.Equal(cex.Body.Code, expectedErrorCode);
                }
            }
        }

        [Fact]
        public void PatchAccount()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the account
                ResourceUtils.CreateAccount(netAppMgmtClient, activeDirectory: ResourceUtils.activeDirectory);

                var dict = new Dictionary<string, string>();
                dict.Add("Tag2", "Value1");

                // Now try and modify it
                var netAppAccountPatch = new NetAppAccountPatch()
                {
                    Tags = dict
                };

                // tag changes but active directory still present
                var resource = netAppMgmtClient.Accounts.Update(netAppAccountPatch, ResourceUtils.resourceGroup, ResourceUtils.accountName1);
                Assert.True(resource.Tags.ContainsKey("Tag2"));
                Assert.Equal("Value1", resource.Tags["Tag2"]);
                Assert.NotNull(resource.ActiveDirectories);
                Assert.Equal("sdkuser", resource.ActiveDirectories.First().Username);

                // so deleting the active directory requires the put operation
                // but changing an active directory can be done but requires the id

                ResourceUtils.activeDirectory2.ActiveDirectoryId = resource.ActiveDirectories.First().ActiveDirectoryId;
                var activeDirectories = new List<ActiveDirectory> { ResourceUtils.activeDirectory2 };

                dict.Add("Tag3", "Value3");

                // Now try and modify it
                var netAppAccountPatch2 = new NetAppAccountPatch()
                {
                    ActiveDirectories = activeDirectories,
                    Tags = dict
                };

                var resource2 = netAppMgmtClient.Accounts.Update(netAppAccountPatch2, ResourceUtils.resourceGroup, ResourceUtils.accountName1);
                Assert.True(resource2.Tags.ContainsKey("Tag2"));
                Assert.Equal("Value1", resource2.Tags["Tag2"]);
                Assert.True(resource2.Tags.ContainsKey("Tag3"));
                Assert.Equal("Value3", resource2.Tags["Tag3"]);
                Assert.NotNull(resource2.ActiveDirectories);
                Assert.Equal("sdkuser1", resource2.ActiveDirectories.First().Username);

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
