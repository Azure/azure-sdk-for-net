using FsCheck.Xunit;
using Microsoft.Azure.Batch.Conventions.Files.UnitTests.Generators;
using Microsoft.Azure.Batch.Conventions.Files.UnitTests.Utilities;
using Microsoft.Azure.Batch.Conventions.Files.Utilities;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Batch.Conventions.Files.UnitTests
{
    [Arbitrary(typeof(BatchIdGenerator))]
    public class CloudJobExtensionsUnitTests
    {
        [Fact]
        public void CannotCreateOutputStorageForNullJob()
        {
            CloudJob job = null;
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("fake", new byte[] { 65, 66, 67, 68 }), true);
            var ex = Assert.Throws<ArgumentNullException>(() => job.OutputStorage(storageAccount));
            Assert.Equal("job", ex.ParamName);
        }

        [Fact]
        public async Task CannotCreateOutputStorageForNullStorageAccount()
        {
            using (var batchClient = await BatchClient.OpenAsync(new FakeBatchServiceClient()))
            {
                CloudJob job = batchClient.JobOperations.CreateJob();
                job.Id = "fakejob";
                CloudStorageAccount storageAccount = null;
                var ex = Assert.Throws<ArgumentNullException>(() => job.OutputStorage(storageAccount));
                Assert.Equal("storageAccount", ex.ParamName);
            }
        }

        [Fact]
        public async Task CannotPrepareOutputStorageForNullJob()
        {
            CloudJob job = null;
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("fake", new byte[] { 65, 66, 67, 68 }), true);
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => job.PrepareOutputStorageAsync(storageAccount));
            Assert.Equal("job", ex.ParamName);
        }

        [Property]
        public void JobOutputStorageContainerNameAgreesWithSafeContainerName(BatchId jobId)
        {
            using (var batchClient = BatchClient.Open(new FakeBatchServiceClient()))  // FsCheck doesn't like async tests
            {
                CloudJob job = batchClient.JobOperations.CreateJob();
                job.Id = jobId.ToString();
                var actualContainerName = job.OutputStorageContainerName();
                var expectedContainerName = ContainerNameUtils.GetSafeContainerName(job.Id);
                Assert.Equal(expectedContainerName, actualContainerName);  // We have other tests for validating the outputs of GetSafeContainerName - we do not need to reproduce those here
            }
        }

        [Fact]
        public void CannotGetOutputStorageContainerNameForNullJob()
        {
            CloudJob job = null;
            var ex = Assert.Throws<ArgumentNullException>(() => job.OutputStorageContainerName());
            Assert.Equal("job", ex.ParamName);
        }
    }
}
