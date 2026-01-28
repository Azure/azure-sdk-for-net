// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.JobPlan;
using NUnit.Framework;
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

            Assert.That(file, Is.Not.Null);
            Assert.That(jobPart, Is.EqualTo(file.FileName.JobPartNumber));
            Assert.That(transferId, Is.EqualTo(file.FileName.Id));
            Assert.That(fileName.FullPath, Is.EqualTo(file.FilePath));
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

            Assert.That(file, Is.Not.Null);
            Assert.That(jobPart, Is.EqualTo(file.FileName.JobPartNumber));
            Assert.That(transferId, Is.EqualTo(file.FileName.Id));
            Assert.That(fileName.FullPath, Is.EqualTo(file.FileName.FullPath));
            Assert.That(fileName.FullPath, Is.EqualTo(file.FilePath));
        }
    }
}
