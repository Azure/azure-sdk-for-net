// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.DataMovement.JobPlanModels;

namespace Azure.Storage.DataMovement.Tests
{
    public class JobPartPlanHeaderTests : DataMovementTestBase
    {
        public JobPartPlanHeaderTests(bool async) : base(async, default)
        {
        }

        public void Ctor()
        {
            /*
            string transferId = GetNewTransferId();
            long partNumber = 5;
            DateTimeOffset dateTime = DateTimeOffset.UtcNow;
            JobPartPlanHeader header = new JobPartPlanHeader(
                version: DataMovementConstants.PlanFile.SchemaVersion,
                startTime: dateTime,
                transferId: transferId,
                partNumber: partNumber,
                sourcePath: );
            */
        }
    }
}
