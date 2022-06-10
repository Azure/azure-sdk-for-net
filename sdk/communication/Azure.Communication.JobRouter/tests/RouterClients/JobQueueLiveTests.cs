// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class JobQueueLiveTests : RouterLiveTestBase
    {
        /// <inheritdoc />
        public JobQueueLiveTests(bool isAsync) : base(isAsync)
        {
        }

        #region Queue Tests
        [Test]
        public async Task CreateQueueTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var createDistributionPolicyResponse = await CreateDistributionPolicy(nameof(CreateQueueTest));
            var queueId = GenerateUniqueId(IdPrefix, nameof(CreateQueueTest));
            var createQueueResponse = await routerClient.CreateQueueAsync(queueId,
                createDistributionPolicyResponse.Value.Id);
            AssertQueueResponseIsEqual(createQueueResponse, queueId, createDistributionPolicyResponse.Value.Id);
            AddForCleanup(new Task(async () => await routerClient.DeleteQueueAsync(createQueueResponse.Value.Id)));

            var queueName = "DefaultQueueWithLabels" + queueId;
            var queueLabels = new LabelCollection() { ["Label_1"] = "Value_1" };
            createQueueResponse = await routerClient.UpdateQueueAsync(queueId,
                new UpdateQueueOptions()
                {
                    Name = queueName,
                    Labels = queueLabels,
                });
            AssertQueueResponseIsEqual(createQueueResponse, queueId, createDistributionPolicyResponse.Value.Id, queueName, queueLabels);
            AddForCleanup(new Task(async () => await routerClient.DeleteQueueAsync(createQueueResponse.Value.Id)));
        }

        #endregion Queue Tests
    }
}
