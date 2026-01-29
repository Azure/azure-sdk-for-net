// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.JobPlan;
using NUnit.Framework;
using static Azure.Storage.DataMovement.Tests.TransferUtility;

namespace Azure.Storage.DataMovement.Tests
{
    public class JobPlanFileTests : DataMovementTestBase
    {
        public JobPlanFileTests(bool async) : base(async, default)
        {
        }

        [Test]
        public async Task CreateJobPlanFileAsync()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            string transferId = GetNewTransferId();

            var data = Encoding.UTF8.GetBytes("Hello World!");

            JobPlanFile file;
            using (Stream stream = new MemoryStream(data))
            {
                file = await JobPlanFile.CreateJobPlanFileAsync(
                   checkpointerPath: test.DirectoryPath,
                   id: transferId,
                   headerStream: stream);
            }
            string filePath = Path.Combine(test.DirectoryPath, $"{transferId}{DataMovementConstants.JobPlanFile.FileExtension}");

            Assert.That(file, Is.Not.Null);
            Assert.That(file.Id, Is.EqualTo(transferId));
            Assert.That(file.FilePath, Is.EqualTo(filePath));
        }

        [Test]
        public async Task LoadExistingJobPlanFile()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            string transferId = GetNewTransferId();

            // Setup existing job plan file
            string filePath = Path.Combine(test.DirectoryPath, $"{transferId}{DataMovementConstants.JobPlanFile.FileExtension}");
            var data = Encoding.UTF8.GetBytes("Hello World!");
            using (FileStream fileStream = File.OpenWrite(filePath))
            {
                await fileStream.WriteAsync(data, 0, data.Length);
            }

            JobPlanFile jobPlanFile = JobPlanFile.LoadExistingJobPlanFile(filePath);

            Assert.That(jobPlanFile, Is.Not.Null);
            Assert.That(jobPlanFile.Id, Is.EqualTo(transferId));
            Assert.That(jobPlanFile.FilePath, Is.EqualTo(filePath));
        }
    }
}
