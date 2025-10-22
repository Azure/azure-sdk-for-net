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
            DateTime unboundDNRU = DateTime.Parse("2026-08-18T00:00:00.0000000Z");

            BatchJobScheduleConfiguration schedule = new BatchJobScheduleConfiguration()
            {
                DoNotRunUntil = unboundDNRU,
            };
            // create a new pool
            BatchVmImageReference imageReference = new BatchVmImageReference()
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

            BatchJobScheduleCreateOptions jobSchedule = new BatchJobScheduleCreateOptions(jobScheduleId, schedule, jobSpecification);

            try
            {
                Response response = await client.CreateJobScheduleAsync(jobSchedule);

                // check to see if the job schedule exists
                bool result = await client.JobScheduleExistsAsync(jobScheduleId);
                Assert.True(result);

                // get the job schedule and verify
                BatchJobSchedule batchJobSchedule = await client.GetJobScheduleAsync(jobScheduleId);
                Assert.NotNull(batchJobSchedule);
                Assert.AreEqual(batchJobSchedule.JobSpecification.PoolInfo.AutoPoolSpecification.Pool.VirtualMachineConfiguration.ImageReference.Sku, "2019-datacenter-smalldisk");

                // disable the schedule
                response = await client.DisableJobScheduleAsync(jobScheduleId);
                Assert.AreEqual(204, response.Status);

                // enable the schedule
                response = await client.EnableJobScheduleAsync(jobScheduleId);
                Assert.AreEqual(204, response.Status);

                TerminateJobScheduleOperation terminateJobScheduleOperation = await client.TerminateJobScheduleAsync(jobScheduleId, force: true);
                await terminateJobScheduleOperation.WaitForCompletionAsync().ConfigureAwait(false);
                Assert.IsTrue(terminateJobScheduleOperation.HasCompleted);
                Assert.IsTrue(terminateJobScheduleOperation.HasValue);
            }
            finally
            {
                DeleteJobScheduleOperation operation = await client.DeleteJobScheduleAsync(jobScheduleId, force: true);
                await operation.WaitForCompletionAsync();
                Assert.IsTrue(operation.HasCompleted);
                Assert.IsTrue(operation.HasValue);
                Assert.IsTrue(operation.Value);
            }
        }

        [RecordedTest]
        public async Task JobScheduleTerminate()
        {
            var client = CreateBatchClient();
            string jobScheduleId = "jobSchedule2";
            BatchJobScheduleConfiguration schedule = new BatchJobScheduleConfiguration()
            ;
            // create a new pool
            BatchVmImageReference imageReference = new BatchVmImageReference()
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
            BatchJobManagerTask batchJobManagerTask = new BatchJobManagerTask("task1", "cmd / c timeout 60");

            BatchJobSpecification jobSpecification = new BatchJobSpecification(poolInfo)
            {
                JobManagerTask = batchJobManagerTask,
            };

            BatchJobScheduleCreateOptions jobSchedule = new BatchJobScheduleCreateOptions(jobScheduleId, schedule, jobSpecification);

            try
            {
                Response response = await client.CreateJobScheduleAsync(jobSchedule);

                TerminateJobScheduleOperation terminateJobScheduleOperation = await client.TerminateJobScheduleAsync(jobScheduleId, force: false);
                await terminateJobScheduleOperation.WaitForCompletionAsync().ConfigureAwait(false);
                Assert.IsTrue(terminateJobScheduleOperation.HasCompleted);
                Assert.IsTrue(terminateJobScheduleOperation.HasValue);
            }
            finally
            {
                await client.DeleteJobScheduleAsync(jobScheduleId, force: false);
            }
        }

        [RecordedTest]
        public async Task GetJobsFromSchedules()
        {
            var client = CreateBatchClient();
            string jobScheduleId = "jobSchedule2";
            BatchJobScheduleConfiguration schedule = new BatchJobScheduleConfiguration()
            ;
            // create a new pool
            BatchVmImageReference imageReference = new BatchVmImageReference()
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
            BatchJobManagerTask batchJobManagerTask = new BatchJobManagerTask("task1", "cmd / c echo Hello World");

            BatchJobSpecification jobSpecification = new BatchJobSpecification(poolInfo)
            {
                JobManagerTask = batchJobManagerTask,
            };

            BatchJobScheduleCreateOptions jobSchedule = new BatchJobScheduleCreateOptions(jobScheduleId, schedule, jobSpecification);

            try
            {
                Response response = await client.CreateJobScheduleAsync(jobSchedule);

                // check to see if the job schedule exists via list
                bool found = false;
                await foreach (BatchJobSchedule item in client.GetJobSchedulesAsync())
                {
                    if ( item.Id == jobScheduleId)
                        found = true;
                }

                Assert.True(found);

                // update the job schedule
                int jobCount = 0;
                await foreach (BatchJob item in client.GetJobsFromSchedulesAsync(jobScheduleId))
                {
                    jobCount++;
                }

                Assert.AreEqual(1, jobCount);
            }
            finally
            {
                await client.DeleteJobScheduleAsync(jobScheduleId,force:true);
            }
        }

        [RecordedTest]
        public async Task JobScheduleUpdate()
        {
            var client = CreateBatchClient();
            string jobScheduleId = "jobSchedule3";
            DateTime unboundDNRU = DateTime.Parse("2026-08-18T00:00:00.0000000Z");
            BatchJobScheduleConfiguration schedule = new BatchJobScheduleConfiguration()
            {
                DoNotRunUntil = unboundDNRU,
            };
            // create a new pool
            BatchVmImageReference imageReference = new BatchVmImageReference()
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

            BatchJobScheduleCreateOptions jobSchedule = new BatchJobScheduleCreateOptions(jobScheduleId, schedule, jobSpecification);

            try
            {
                Response response = await client.CreateJobScheduleAsync(jobSchedule);

                BatchJobSchedule batchJobSchedule = await client.GetJobScheduleAsync(jobScheduleId);
                Assert.NotNull(batchJobSchedule);

                response = await client.ReplaceJobScheduleAsync(jobScheduleId, batchJobSchedule);
                Assert.AreEqual(200, response.Status);

                // blocked due to not having a model
                //await client.UpdateJobScheduleAsync()
            }
            finally
            {
                await client.DeleteJobScheduleAsync(jobScheduleId);
            }
        }

        [RecordedTest]
        public async Task JobSchedulePatch()
        {
            var client = CreateBatchClient();
            string jobScheduleId = "jobSchedulePatch";
            DateTime unboundDNRU = DateTime.Parse("2026-08-18T00:00:00.0000000Z");
            BatchJobScheduleConfiguration schedule = new BatchJobScheduleConfiguration()
            {
                DoNotRunUntil = unboundDNRU,
            };
            // create a new pool
            BatchVmImageReference imageReference = new BatchVmImageReference()
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
                TargetDedicatedNodes = 0,
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

            BatchJobScheduleCreateOptions jobSchedule = new BatchJobScheduleCreateOptions(jobScheduleId, schedule, jobSpecification);

            try
            {
                Response response = await client.CreateJobScheduleAsync(jobSchedule);

                BatchJobScheduleUpdateOptions batchJobScheduleUpdateContent = new BatchJobScheduleUpdateOptions();
                batchJobScheduleUpdateContent.Metadata.Add(new BatchMetadataItem("name", "value"));

                response = await client.UpdateJobScheduleAsync(jobScheduleId, batchJobScheduleUpdateContent);
                Assert.AreEqual(200, response.Status);

                BatchJobSchedule patchJobSchedule = await client.GetJobScheduleAsync(jobScheduleId);

                Assert.IsNotNull(patchJobSchedule);
                Assert.AreEqual(patchJobSchedule.Metadata.First().Value, "value");
            }
            finally
            {
                await client.DeleteJobScheduleAsync(jobScheduleId);
            }
        }
    }
}
