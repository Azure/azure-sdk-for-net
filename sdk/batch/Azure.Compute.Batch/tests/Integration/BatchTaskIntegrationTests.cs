// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Compute.Batch.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.Integration
{
    internal class BatchTaskIntegrationTests : BatchLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchPoolIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchTaskIntegrationTests(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchPoolIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchTaskIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task AddTask()
        {
            var client = CreateBatchClient();
            IaasLinuxPoolFixture iaasWindowsPoolFixture = new IaasLinuxPoolFixture(client, "AddTask", isPlayBack());
            string poolID = iaasWindowsPoolFixture.PoolId;
            string jobID = "batchJob1";
            string taskID = "Task1";
            string commandLine = "cmd /c echo Hello World";
            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                BatchPoolInfo batchPoolInfo = new BatchPoolInfo()
                {
                    PoolId = pool.Id
                };
                BatchJobCreateContent batchJobCreateContent = new BatchJobCreateContent(jobID, batchPoolInfo);
                Response response = await client.CreateJobAsync(batchJobCreateContent);

                var job = await client.GetJobAsync(jobID);
                Assert.IsNotNull(job);

                using RequestContent content = RequestContent.Create(new
                {
                    id = taskID,
                    commandLine = commandLine,
                });
                response = await client.CreateTaskAsync(jobID, content);

                BatchTask task = await client.GetTaskAsync(jobID, taskID);
                Assert.IsNotNull(task);
                Assert.AreEqual(commandLine, task.CommandLine);
            }
            finally
            {
                await client.DeleteJobAsync(jobID);
                await client.DeletePoolAsync(poolID);
            }
        }
    }
}
