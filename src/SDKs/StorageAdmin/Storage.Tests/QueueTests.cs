using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestCommon;

using Microsoft.AzureStack.Storage.Admin;
using Microsoft.AzureStack.Storage.Admin.Models;

namespace Storage.Tests
{
    [TestClass]
    public class QueueTests : TestBase
    {

        private void ValidateFarm(FarmModel farm)
        {
            Assert.IsNotNull(farm);
            Assert.IsNotNull(farm.Id);
            Assert.AreEqual<string>(parameters.Location, farm.Location);
            Assert.IsNotNull(farm.Name);
            Assert.IsNotNull(farm.Properties);
            // Assert.IsNotNull(farm.Properties.HealthStatus);
            Assert.IsNotNull(farm.Properties.SettingsStore);
            
        }

        [TestMethod]
        public void Test1()
        {
            RunTest(() => {
                var rgName = "rgdeletewhendone";
                var client = Common.CreateAndValidateStorageAdminClient(parameters);
                var quotas = client.Quotas.List(parameters.Location).Value;
                foreach(var quota in quotas) {
                    Assert.IsNotNull(quota);
                }

                client.Quotas.CreateOrUpdate(parameters.Location, "herro", new QuotaParameters() {
                    Type = "Microsoft.Storage.Admin/locations/quotas",
                    Properties = new StorageQuota(50, 1000)
                });
                client.Quotas.Delete(parameters.Location, "herro");

            });
        }
    }
}
