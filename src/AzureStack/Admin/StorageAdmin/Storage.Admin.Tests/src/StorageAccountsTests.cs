using System.Linq;
using Microsoft.AzureStack.Management.Storage.Admin;
using Microsoft.AzureStack.Management.Storage.Admin.Models;
using Xunit;
using System;

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
                Assert.Equal(expected.AcquisitionOperationCount, found.AcquisitionOperationCount);
                Assert.Equal(expected.AlternateName, found.AlternateName);
                Assert.Equal(expected.CurrentOperation, found.CurrentOperation);
                Assert.Equal(expected.CustomDomain, found.CustomDomain);
            }
        }

        private void ValidateStorageAccount(StorageAccount account) {
            Assert.NotNull(account);
            // Assert.NotNull(account.AccountId);
            Assert.NotNull(account.AccountStatus);
            Assert.NotNull(account.AccountType);
            Assert.NotNull(account.AcquisitionOperationCount);
            //Assert.NotNull(account.AlternateName);
            Assert.NotNull(account.CreationTime);
            Assert.NotNull(account.CurrentOperation);
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
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var storageAccounts = client.StorageAccounts.List(ResourceGroupName, fName, false);
                    storageAccounts.ForEach(ValidateStorageAccount);
                }
            });
        }

        [Fact]
        public void GetStorageAccount() {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var storageAccounts = client.StorageAccounts.List(ResourceGroupName, fName, false);
                    foreach (var storageAccount in storageAccounts)
                    {
                        var sName = ExtractName(storageAccount.Name);
                        var account = client.StorageAccounts.Get(ResourceGroupName, fName, sName);
                        AssertAreEqual(storageAccount, account);
                        return;
                    }
                }
            });
        }

        [Fact]
        public void GetAllStorageAccounts() {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var storageAccounts = client.StorageAccounts.List(ResourceGroupName, fName, false);
                    foreach (var storageAccount in storageAccounts)
                    {
                        var sName = ExtractName(storageAccount.Name);
                        var account = client.StorageAccounts.Get(ResourceGroupName, fName, sName);
                        AssertAreEqual(storageAccount, account);
                    }
                }
            });
        }


        [Fact(Skip = "Don't know how I would test this for now.")]
        public void UnDeleteStorageAccount() {
            RunTest((client) => {
                // TODO
            });
        }
    }
}
