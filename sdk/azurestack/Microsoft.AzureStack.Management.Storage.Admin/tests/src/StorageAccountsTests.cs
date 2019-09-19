using System.Linq;
using Microsoft.AzureStack.Management.Storage.Admin;
using Microsoft.AzureStack.Management.Storage.Admin.Models;
using Xunit;
using System;
using System.Collections.Generic;

namespace Storage.Tests
{
    public class StorageAccountsTests : StorageTestBase
    {
        private void AssertAreEqual(StorageAccount expected, StorageAccount found) {
            if (expected == null)
            {
                Assert.NotNull(found);
            }
            else
            {
                ValidateStorageAccount(found);
                Assert.Equal(expected.AccountId, found.AccountId);
                Assert.Equal(expected.AccountStatus, found.AccountStatus);
                Assert.Equal(expected.AccountType, found.AccountType);
            }
        }

        private void ValidateStorageAccount(StorageAccount account) {
            Assert.NotNull(account);
            // Assert.NotNull(account.AccountId);
            Assert.NotNull(account.AccountStatus);
            Assert.NotNull(account.AccountType);
            //Assert.NotNull(account.AlternateName);
            Assert.NotNull(account.CreationTime);
            //Assert.NotNull(account.CustomDomain);
            //Assert.NotNull(account.DeletedTime);
            Assert.NotNull(account.Id);
            Assert.NotNull(account.Location);
            Assert.NotNull(account.Name);
            //Assert.NotNull(account.Permissions);
            Assert.NotNull(account.PrimaryEndpoints);
            Assert.NotNull(account.PrimaryLocation);
            Assert.NotNull(account.ProvisioningState);
            //Assert.NotNull(account.RecoveredTime);
            //Assert.NotNull(account.RecycledTime);
            //Assert.NotNull(account.ResourceAdminApiVersion);
            Assert.NotNull(account.StatusOfPrimary);
            Assert.NotNull(account.TenantResourceGroupName);
            Assert.NotNull(account.TenantStorageAccountName);
            Assert.NotNull(account.TenantSubscriptionId);
            Assert.NotNull(account.TenantViewId);
            Assert.NotNull(account.Type);
            //Assert.NotNull(account.WacInternalState);
        }

        [Fact]
        public void ListAllStorageAccounts() {
            RunTest((client) => {
                var storageAccounts = client.StorageAccounts.List(Location, summary: false);
                storageAccounts.ForEach(ValidateStorageAccount);
            });
        }

        [Fact]
        public void GetStorageAccount() {
            RunTest((client) => {
                var storageAccounts = client.StorageAccounts.List(Location, summary: false);
                foreach (var storageAccount in storageAccounts)
                {
                    var sName = ExtractName(storageAccount.Name);
                    var account = client.StorageAccounts.Get(Location, sName);
                    AssertAreEqual(storageAccount, account);
                    return;
                }
            });
        }

        [Fact]
        public void GetAllStorageAccounts() {
            RunTest((client) => {
                List<StorageAccount> storageAccountList = new List<StorageAccount>();
                var storageAccounts = client.StorageAccounts.List(Location, summary: false);
                storageAccountList.AddRange(storageAccounts);
                while(storageAccounts.NextPageLink != null)
                {
                    storageAccounts = client.StorageAccounts.ListNext(storageAccounts.NextPageLink);
                    storageAccountList.AddRange(storageAccounts);
                }

                foreach (var storageAccount in storageAccountList)
                {
                    var sName = ExtractName(storageAccount.Name);
                    var account = client.StorageAccounts.Get(Location, sName);
                    AssertAreEqual(storageAccount, account);
                }
            });
        }

        [Fact(Skip = "Don't know how I would test this for now.")]
        public void UnDeleteStorageAccount() {
            RunTest((client) => {
                // TODO
            });
        }

        [Fact(Skip = "Don't know how I would test this for now.")]
        public void OndemandGCAccounts() {
            RunTest((client) => {
                // TODO
            });
        }
    }
}
