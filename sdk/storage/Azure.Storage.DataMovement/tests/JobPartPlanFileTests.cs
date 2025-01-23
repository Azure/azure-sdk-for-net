// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Storage.DataMovement.JobPlan;
using static Azure.Storage.DataMovement.Tests.TransferUtility;

namespace Azure.Storage.DataMovement.Tests
{
    public class JobPartPlanFileTests : DataMovementTestBase
    {
        public JobPartPlanFileTests(bool async) : base(async, default)
        {
        }

        [Test]
        public async Task CreateJobPartPlanFileAsync_Base()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
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
                    header: new(
                        DataMovementConstants.JobPartPlanFile.SchemaVersion,
                        transferId,
                        jobPart,
                        System.DateTimeOffset.Now,
                        "mock",
                        "mock",
                        "mock",
                        "mock",
                        default,
                        default,
                        default,
                        default,
                        new()));
            }

            JobPartPlanFileName fileName = new JobPartPlanFileName(
                checkpointerPath: test.DirectoryPath,
                id: transferId,
                jobPartNumber: jobPart);

            Assert.NotNull(file);
            Assert.AreEqual(file.FileName.JobPartNumber, jobPart);
            Assert.AreEqual(file.FileName.Id, transferId);
            Assert.AreEqual(file.FilePath, fileName.FullPath);
        }

        [Test]
        public async Task CreateJobPartPlanFileAsync_FileName()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
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
                   header: new(
                        DataMovementConstants.JobPartPlanFile.SchemaVersion,
                        transferId,
                        jobPart,
                        System.DateTimeOffset.Now,
                        "mock",
                        "mock",
                        "mock",
                        "mock",
                        default,
                        default,
                        default,
                        default,
                        new()));
            }

            Assert.NotNull(file);
            Assert.AreEqual(file.FileName.JobPartNumber, jobPart);
            Assert.AreEqual(file.FileName.Id, transferId);
            Assert.AreEqual(file.FileName.FullPath, fileName.FullPath);
            Assert.AreEqual(file.FilePath, fileName.FullPath);
        }
    }
}
