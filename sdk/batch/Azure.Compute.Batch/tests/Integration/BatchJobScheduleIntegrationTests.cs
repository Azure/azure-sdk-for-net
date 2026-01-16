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
                Assert.That(result, Is.True);

                // get the job schedule and verify
                BatchJobSchedule batchJobSchedule = await client.GetJobScheduleAsync(jobScheduleId);
                Assert.That(batchJobSchedule, Is.Not.Null);
                Assert.That(batchJobSchedule.JobSpecification.PoolInfo.AutoPoolSpecification.Pool.VirtualMachineConfiguration.ImageReference.Sku, Is.EqualTo("2019-datacenter-smalldisk"));

                // disable the schedule
                response = await client.DisableJobScheduleAsync(jobScheduleId);
                Assert.That(response.Status, Is.EqualTo(204));

                // enable the schedule
                response = await client.EnableJobScheduleAsync(jobScheduleId);
                Assert.That(response.Status, Is.EqualTo(204));

                TerminateJobScheduleOperation terminateJobScheduleOperation = await client.TerminateJobScheduleAsync(jobScheduleId, force: true);
                await terminateJobScheduleOperation.WaitForCompletionAsync().ConfigureAwait(false);
                Assert.That(terminateJobScheduleOperation.HasCompleted, Is.True);
                Assert.That(terminateJobScheduleOperation.HasValue, Is.True);
            }
            finally
            {
                DeleteJobScheduleOperation operation = await client.DeleteJobScheduleAsync(jobScheduleId, force: true);
                await operation.WaitForCompletionAsync();
                Assert.That(operation.HasCompleted, Is.True);
                Assert.That(operation.HasValue, Is.True);
                Assert.That(operation.Value, Is.True);
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
                Assert.That(terminateJobScheduleOperation.HasCompleted, Is.True);
                Assert.That(terminateJobScheduleOperation.HasValue, Is.True);
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

                Assert.That(found, Is.True);

                // update the job schedule
                int jobCount = 0;
                await foreach (BatchJob item in client.GetJobsFromSchedulesAsync(jobScheduleId))
                {
                    jobCount++;
                }

                Assert.That(jobCount, Is.EqualTo(1));
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
                Assert.That(batchJobSchedule, Is.Not.Null);

                response = await client.ReplaceJobScheduleAsync(jobScheduleId, batchJobSchedule);
                Assert.That(response.Status, Is.EqualTo(200));

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
                Assert.That(response.Status, Is.EqualTo(200));

                BatchJobSchedule patchJobSchedule = await client.GetJobScheduleAsync(jobScheduleId);

                Assert.That(patchJobSchedule, Is.Not.Null);
                Assert.That(patchJobSchedule.Metadata.First().Value, Is.EqualTo("value"));
            }
            finally
            {
                await client.DeleteJobScheduleAsync(jobScheduleId);
            }
        }
    }
}
