// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Compute.Batch.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.Integration
{
    internal class BatchJobScheduleIntegrationTests : BatchLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchJobScheduleIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchJobScheduleIntegrationTests(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchJobScheduleIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchJobScheduleIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task JobScheduleAutoPool()
        {
            var client = CreateBatchClient();
            string jobScheduleId = "jobSchedule1";
            DateTime unboundDNRU = DateTime.UtcNow.AddYears(1);
            BatchJobScheduleConfiguration schedule = new BatchJobScheduleConfiguration()
            {
                DoNotRunUntil = unboundDNRU,
            };
            // create a new pool
            ImageReference imageReference = new ImageReference()
            {
                Publisher = "MicrosoftWindowsServer",
                Offer = "WindowsServer",
                Sku = "2019-datacenter-smalldisk",
                Version = "latest"
            };
            VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(imageReference, "batch.node.windows amd64");

            BatchPoolSpecification batchPoolSpecification = new BatchPoolSpecification("STANDARD_D1_v2")
            {
                VirtualMachineConfiguration = virtualMachineConfiguration,
                TargetDedicatedNodes = 1,
            };
            BatchAutoPoolSpecification autoPoolSpecification = new BatchAutoPoolSpecification(BatchPoolLifetimeOption.Job)
            {
                KeepAlive = false,
                Pool = batchPoolSpecification,
            };
            BatchPoolInfo poolInfo = new BatchPoolInfo()
            {
                AutoPoolSpecification = autoPoolSpecification,
            };
            BatchJobSpecification jobSpecification = new BatchJobSpecification(poolInfo);

            BatchJobScheduleCreateContent jobSchedule = new BatchJobScheduleCreateContent(jobScheduleId, schedule, jobSpecification);

            Response response = await client.CreateJobScheduleAsync(jobSchedule);

            // check to see if the job schedule exists
            bool result = client.JobScheduleExists(jobScheduleId);
            Assert.True(result);

            // get the job schedule and verify
            BatchJobSchedule batchJobSchedule = await client.GetJobScheduleAsync(jobScheduleId);
            Assert.NotNull(batchJobSchedule);
            Assert.AreEqual(batchJobSchedule.JobSpecification.PoolInfo.AutoPoolSpecification.Pool.VirtualMachineConfiguration.ImageReference.Sku, "2019-datacenter-smalldisk");

            // update the job schedule
            //await client.UpdateJobScheduleAsync
            //await client.ReplaceJobScheduleAsync
        }
    }
}
