// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Test.Shared;
using NUnit.Framework;
using Azure.Storage.Test;

namespace Azure.Storage.DataMovement.Tests
{
    public class LocalTransferCheckpointerTests
    {
        public static DisposingLocalDirectory GetTestLocalDirectoryAsync(string directoryPath = default)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                directoryPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            }
            return new DisposingLocalDirectory(directoryPath);
        }

        public string CreateCheckpointerPath()
        {
            DirectoryInfo dir = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "checkpointerPath"));
            return dir.FullName;
        }

        internal void CreateJobPlanFile(
            string checkpointerPath,
            string transferId,
            int jobPartCount)
        {
            for (int i = 0; i < jobPartCount; i++)
            {
                JobPartPlanFileName fileName = new JobPartPlanFileName(checkpointerPath, transferId, i);
                File.Create(fileName.ToString());
            }
        }

        [Test]
        public void Ctor()
        {
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer();

            Assert.NotNull(transferCheckpointer);
        }

        [Test]
        public void Ctor_CustomPath()
        {
            string customPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            DisposingLocalDirectory test = GetTestLocalDirectoryAsync(customPath);
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            Assert.NotNull(transferCheckpointer);
        }

        [Test]
        public void Ctor_Error()
        {
            string customPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new LocalTransferCheckpointer(customPath),
                e => Errors.MissingCheckpointerPath(customPath).Message.Equals(e.Message));
        }

        [Test]
        public async Task AddNewJobAsync_InvalidId()
        {
            string customPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            DisposingLocalDirectory test = GetTestLocalDirectoryAsync(customPath);
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = Guid.NewGuid().ToString();
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                transferCheckpointer.AddNewJobAsync(transferId),
                e => Assert.AreEqual(Errors.MissingCheckpointerPath(customPath).Message, e.Message));
        }
    }
}
