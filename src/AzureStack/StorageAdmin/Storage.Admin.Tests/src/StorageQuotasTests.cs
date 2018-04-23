using System.Linq;
using Microsoft.AzureStack.Management.Storage.Admin;
using Microsoft.AzureStack.Management.Storage.Admin.Models;
using Xunit;

namespace Storage.Tests
{
    public class StorageQuotasTests : StorageTestBase
    {
        private void AssertAreEqual(StorageQuota expected, StorageQuota found) {
            if (expected == null)
            {
                Assert.NotNull(found);
            }
            else
            {
                ValidateQuota(found);
                Assert.Equal(expected.CapacityInGb, found.CapacityInGb);
                Assert.Equal(expected.NumberOfStorageAccounts, found.NumberOfStorageAccounts);
            }
        }

        private void ValidateQuota(StorageQuota quota) {
            Assert.NotNull(quota);
            Assert.NotNull(quota.CapacityInGb);
            Assert.NotNull(quota.NumberOfStorageAccounts);
            Assert.NotNull(quota.Id);
            Assert.NotNull(quota.Location);
            Assert.NotNull(quota.Name);
            Assert.NotNull(quota.Type);
            //Assert.NotNull(quota.Tags);
        }

        [Fact]
        public void ListAllStorageQuotas() {
            RunTest((client) => {
                var quotas = client.StorageQuotas.List(Location);
                quotas.ForEach(ValidateQuota);
                Common.WriteIEnumerableToFile<StorageQuota>(quotas, "ListAllStorageQuotas.txt");
            });
        }

        [Fact]
        public void GetStorageQuota() {
            RunTest((client) => {
                var quota = client.StorageQuotas.List(Location).First();
                var qName = ExtractName(quota.Name);
                var result = client.StorageQuotas.Get(Location, qName);
                AssertAreEqual(quota, result);
            });
        }

        [Fact]
        public void GetAllStorageQuotas() {
            RunTest((client) => {
                var quotas = client.StorageQuotas.List(Location);
                foreach(var quota in quotas)
                {
                    var qName = ExtractName(quota.Name);
                    var result= client.StorageQuotas.Get(Location, qName);
                    AssertAreEqual(quota, result);
                }
            });
        }

        [Fact]
        public void CreateQuota() {
            RunTest((client) => {
                var name = "TestCreateQuota";
                IgnoreExceptions(() => client.StorageQuotas.Delete(Location, name));

                var parameters = new StorageQuota()
                {
                    CapacityInGb = -100000000,
                    NumberOfStorageAccounts = -1000000000
                };
                var retrieved = client.StorageQuotas.CreateOrUpdate(Location, name, parameters);

                Assert.NotNull(retrieved);
                Assert.Equal(parameters.CapacityInGb, retrieved.CapacityInGb);
                Assert.Equal(parameters.NumberOfStorageAccounts, retrieved.NumberOfStorageAccounts);
                retrieved = client.StorageQuotas.Get(Location, name);

                IgnoreExceptions(() => client.StorageQuotas.Delete(Location, name));
            });
        }

        [Fact]
        public void UpdateQuota() {
            RunTest((client) => {
                var quotaName = "TestUpdateQuota";
                IgnoreExceptions(() => client.StorageQuotas.Delete(Location, quotaName));

                var parameters = new StorageQuota()
                {
                    CapacityInGb = 50,
                    NumberOfStorageAccounts = 100
                };
                var retrieved = client.StorageQuotas.CreateOrUpdate(Location, quotaName, parameters);
                ValidateQuota(retrieved);
                Assert.Equal(parameters.CapacityInGb, retrieved.CapacityInGb);
                Assert.Equal(parameters.NumberOfStorageAccounts, retrieved.NumberOfStorageAccounts);

                parameters.CapacityInGb = 123;
                parameters.NumberOfStorageAccounts = 10;
                retrieved = client.StorageQuotas.CreateOrUpdate(Location, quotaName, parameters);
                ValidateQuota(retrieved);
                Assert.Equal(parameters.CapacityInGb, retrieved.CapacityInGb);
                Assert.Equal(parameters.NumberOfStorageAccounts, retrieved.NumberOfStorageAccounts);

                IgnoreExceptions(() => client.StorageQuotas.Delete(Location, quotaName));
            });
        }

        [Fact]
        public void DeleteQuota() {
            RunTest((client) => {
                var name = $"TestDeleteQuota";
                IgnoreExceptions(() => client.StorageQuotas.Delete(Location, name));

                var parameters = new StorageQuota() 
                {
                    CapacityInGb = 0,
                    NumberOfStorageAccounts = -1
                };
                IgnoreExceptions(() => client.StorageQuotas.CreateOrUpdate(Location, name, parameters));
                client.StorageQuotas.Delete(Location, name);
            });
        }
    }
}
