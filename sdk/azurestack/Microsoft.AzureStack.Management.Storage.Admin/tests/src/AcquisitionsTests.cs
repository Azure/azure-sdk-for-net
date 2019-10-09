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
            Assert.NotNull(acquisition.Maximumblobsize);
            Assert.NotNull(acquisition.Status);
            Assert.NotNull(acquisition.Storageaccount);
            Assert.NotNull(acquisition.Susbcriptionid);
            //Assert.NotNull(acquisition.Tags);
        }

        [Fact]
        public void ListAllAcquisitions() {
            RunTest((client) => {
                var acquisitions = client.Acquisitions.List(Location);
                Common.WriteIEnumerableToFile<Acquisition>(acquisitions.Value, "ListAllAcquisitions.txt");
            });
        }
        
    }
}
