// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class JobPartPlanFileTests : DataMovementTestBase
    {
        public JobPartPlanFileTests(bool async) : base(async)
        {
        }

        internal static JobPartPlanFileName CreateTempPartPlanFileName(
            string checkpointerPath)
        {
            return new JobPartPlanFileName(
                checkpointerPath,
                GetNewTransferId(),
                5);
        }

        public void Ctor()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            JobPartPlanFileName file = CreateTempPartPlanFileName(test.DirectoryPath);

            Assert.NotNull(file);
            Assert.NotNull(file.JobPartNumber);
        }
    }
}
