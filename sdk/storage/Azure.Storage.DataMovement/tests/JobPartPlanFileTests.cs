// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class JobPartPlanFileTests : DataMovementTestBase
    {
        public JobPartPlanFileTests(bool async) : base(async)
        {
        }

        [Test]
        public async Task CreateJobPartPlanFileAsync_Base()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            await CreateRandomFileAsync(test.DirectoryPath);
            int jobPart = 5;
            string transferId = GetNewTransferId();

            var data = GetRandomBuffer(Constants.KB);
            JobPartPlanFile file;
            using (Stream stream = new MemoryStream(data))
            {
                 file = await JobPartPlanFile.CreateJobPartPlanFileAsync(
                    checkpointerPath: test.DirectoryPath,
                    id: transferId,
                    jobPart: jobPart,
                    headerStream: stream);
            }

            JobPartPlanFileName fileName = new JobPartPlanFileName(
                checkpointerPath: test.DirectoryPath,
                id: transferId,
                jobPartNumber: jobPart);

            Assert.NotNull(file);
            Assert.AreEqual(file._jobPlanFileName.JobPartNumber, jobPart);
            Assert.AreEqual(file._jobPlanFileName.Id, transferId);
            Assert.AreEqual(file.FilePath, fileName.FullPath);
        }

        [Test]
        public async Task CreateJobPartPlanFileAsync_FileName()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            await CreateRandomFileAsync(test.DirectoryPath);
            int jobPart = 5;
            string transferId = GetNewTransferId();
            JobPartPlanFileName fileName = new JobPartPlanFileName(
                checkpointerPath: test.DirectoryPath,
                id: transferId,
                jobPartNumber: jobPart);

            var data = GetRandomBuffer(Constants.KB);
            JobPartPlanFile file;
            using (Stream stream = new MemoryStream(data))
            {
                file = await JobPartPlanFile.CreateJobPartPlanFileAsync(
                   fileName: fileName,
                   headerStream: stream);
            }

            Assert.NotNull(file);
            Assert.AreEqual(file._jobPlanFileName.JobPartNumber, jobPart);
            Assert.AreEqual(file._jobPlanFileName.Id, transferId);
            Assert.AreEqual(file._jobPlanFileName.FullPath, fileName.FullPath);
            Assert.AreEqual(file.FilePath, fileName.FullPath);
        }
    }
}
