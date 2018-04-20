using System.Linq;
using Microsoft.AzureStack.Management.Storage.Admin;
using Microsoft.AzureStack.Management.Storage.Admin.Models;
using Xunit;

namespace Storage.Tests
{
    public class AcquisitionsTests : StorageTestBase
    {
        private void AssertAreEqual(Acquisition expected, Acquisition found) {
            if (expected == null)
            {
                Assert.NotNull(found);
            }
            else
            {
                ValidateAcquisition(found);
            }
        }

        private void ValidateAcquisition(Acquisition acquisition) {
            Assert.NotNull(acquisition);
            Assert.NotNull(acquisition.Acquisitionid);
            Assert.NotNull(acquisition.Blob);
            Assert.NotNull(acquisition.Container);
            Assert.NotNull(acquisition.FilePath);
            Assert.NotNull(acquisition.Id);
            Assert.NotNull(acquisition.Location);
            Assert.NotNull(acquisition.Maximumblobsize);
            Assert.NotNull(acquisition.Name);
            Assert.NotNull(acquisition.Status);
            Assert.NotNull(acquisition.Storageaccount);
            Assert.NotNull(acquisition.Susbcriptionid);
            //Assert.NotNull(acquisition.Tags);
            Assert.NotNull(acquisition.Type);
        }

        [Fact]
        public void ListAllAcquisitions() {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms) {
                    var name = ExtractName(farm.Name);
                    var result = client.Acquisitions.List(ResourceGroupName, name);
                    Common.WriteIEnumerableToFile<Acquisition>(result, "ListAllAcquisitions.txt");
                }
            });
        }
        
    }
}
