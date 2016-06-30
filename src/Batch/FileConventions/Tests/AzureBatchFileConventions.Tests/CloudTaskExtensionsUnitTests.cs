using Microsoft.Azure.Batch.Conventions.Files.UnitTests.Utilities;
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
    public class CloudTaskExtensionsUnitTests
    {
        [Fact]
        public void CannotCreateOutputStorageForNullTask()
        {
            CloudTask task = null;
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("fake", new byte[] { 65, 66, 67, 68 }), true);
            var ex = Assert.Throws<ArgumentNullException>(() => task.OutputStorage(storageAccount));
            Assert.Equal("task", ex.ParamName);
        }

        [Fact]
        public async Task CannotCreateOutputStorageForNullStorageAccount()
        {
            var taskResponse = new Batch.Protocol.Models.CloudTask
            {
                Id = "faketask",
                Url = $"http://contoso.noregion.batch.azure.com/jobs/fakejob/tasks/faketask",  // TODO: remove if .NET client library can surface CloudTask.JobId directly
            };

            using (var batchClient = await BatchClient.OpenAsync(new FakeBatchServiceClient(taskResponse)))
            {
                CloudTask task = batchClient.JobOperations.GetTask("fakejob", "faketask");
                CloudStorageAccount storageAccount = null;
                var ex = Assert.Throws<ArgumentNullException>(() => task.OutputStorage(storageAccount));
                Assert.Equal("storageAccount", ex.ParamName);
            }
        }
    }
}
