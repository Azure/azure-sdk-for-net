using System.Linq;
using Microsoft.AzureStack.Management.Storage.Admin;
using Microsoft.AzureStack.Management.Storage.Admin.Models;
using Xunit;

namespace Storage.Tests
{
    public class FarmsTests : StorageTestBase
    {
        [Fact]
        public void GetSettings()
        {
            RunTest((client) => {
                var storageSettings = client.StorageSettings.Get(Location);
                Assert.NotNull(storageSettings.RetentionPeriodForDeletedStorageAccountsInDays);
            });
        }

        [Fact]
        public void UpdateSettings()
        {
            RunTest((client) => {
                int? originalStorageSettings = client.StorageSettings.Get(Location).RetentionPeriodForDeletedStorageAccountsInDays;
                int targetStorageSettings = originalStorageSettings.GetValueOrDefault() + 1;
                Settings storageSettings = client.StorageSettings.Update(Location, targetStorageSettings);
                Assert.Equal(targetStorageSettings, storageSettings.RetentionPeriodForDeletedStorageAccountsInDays.Value);
            });
        }
        
    }
}
