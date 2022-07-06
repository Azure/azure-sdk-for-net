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
            var queueName = "DefaultQueueWithLabels" + queueId;
            var queueLabels = new LabelCollection() { ["Label_1"] = new LabelValue("Value_1") };
            var createQueueResponse = await routerClient.CreateQueueAsync(
                queueId,
                createDistributionPolicyResponse.Value.Id,
                new CreateQueueOptions()
                {
                    Name = queueName,
                    Labels = queueLabels
                });
            AssertQueueResponseIsEqual(createQueueResponse, queueId, createDistributionPolicyResponse.Value.Id, queueName, queueLabels);
            AddForCleanup(new Task(async () => await routerClient.DeleteQueueAsync(createQueueResponse.Value.Id)));
        }

        [Test]
        [Ignore(reason: "Known bug: fix required for update queue")]
        public async Task UpdateQueueTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var createDistributionPolicyResponse = await CreateDistributionPolicy(nameof(CreateQueueTest));
            var queueId = GenerateUniqueId(IdPrefix, nameof(CreateQueueTest));
            var queueName = "DefaultQueueWithLabels" + queueId;
            var queueLabels = new LabelCollection() { ["Label_1"] = new LabelValue("Value_1") };
            var createQueueResponse = await routerClient.CreateQueueAsync(
                queueId,
                createDistributionPolicyResponse.Value.Id,
                new CreateQueueOptions()
                {
                    Name = queueName,
                    Labels = queueLabels
                });
            AssertQueueResponseIsEqual(createQueueResponse, queueId, createDistributionPolicyResponse.Value.Id, queueName, queueLabels);

            var updatedLabels =
                new LabelCollection(createQueueResponse.Value.Labels.ToDictionary(x => x.Key, x => x.Value));
            updatedLabels["Label2"] = new LabelValue("Value2");

            var updatedQueueResponse =
                await routerClient.UpdateQueueAsync(queueId, new UpdateQueueOptions() { Labels = updatedLabels, });

            AssertQueueResponseIsEqual(updatedQueueResponse, queueId, createDistributionPolicyResponse.Value.Id, queueName, updatedLabels);

            AddForCleanup(new Task(async () => await routerClient.DeleteQueueAsync(createQueueResponse.Value.Id)));
        }

        #endregion Queue Tests
    }
}
