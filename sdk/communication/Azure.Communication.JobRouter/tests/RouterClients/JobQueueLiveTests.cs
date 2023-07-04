// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class JobQueueLiveTests : RouterLiveTestBase
    {
        public JobQueueLiveTests(bool isAsync) : base(isAsync)
        {
        }

        #region Queue Tests
        [Test]
        public async Task CreateQueueTest()
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();
            var createDistributionPolicyResponse = await CreateDistributionPolicy(nameof(CreateQueueTest));
            var queueId = GenerateUniqueId(IdPrefix, nameof(CreateQueueTest));
            var queueName = "DefaultQueueWithLabels" + queueId;
            var queueLabels = new Dictionary<string, LabelValue>() { ["Label_1"] = new LabelValue("Value_1") };
            var createQueueResponse = await routerClient.CreateQueueAsync(
                new CreateQueueOptions(queueId,
                    createDistributionPolicyResponse.Value.Id)
                {
                    Name = queueName,
                    Labels = { ["Label_1"] = new LabelValue("Value_1") }
                });

            AddForCleanup(new Task(async () => await routerClient.DeleteQueueAsync(createQueueResponse.Value.Id)));
            AssertQueueResponseIsEqual(createQueueResponse, queueId, createDistributionPolicyResponse.Value.Id, queueName, queueLabels);
        }

        [Test]
        public async Task UpdateQueueTest()
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();
            var createDistributionPolicyResponse = await CreateDistributionPolicy(nameof(CreateQueueTest));
            var queueId = GenerateUniqueId(IdPrefix, nameof(CreateQueueTest));
            var queueName = "DefaultQueueWithLabels" + queueId;
            var queueLabels = new Dictionary<string, LabelValue>() { ["Label_1"] = new LabelValue("Value_1") };
            var createQueueResponse = await routerClient.CreateQueueAsync(
                new CreateQueueOptions(queueId,
                    createDistributionPolicyResponse.Value.Id)
                {
                    Name = queueName,
                    Labels = { ["Label_1"] = new LabelValue("Value_1") }
                });
            AddForCleanup(new Task(async () => await routerClient.DeleteQueueAsync(createQueueResponse.Value.Id)));
            AssertQueueResponseIsEqual(createQueueResponse, queueId, createDistributionPolicyResponse.Value.Id, queueName, queueLabels);

            var updatedLabels = new Dictionary<string, LabelValue>(createQueueResponse.Value.Labels.ToDictionary(x => x.Key, x => x.Value))
            {
                ["Label2"] = new("Value2")
            };

            var updateOptions = new UpdateQueueOptions(queueId);
            updateOptions.Labels.Append(updatedLabels);

            var updatedQueueResponse = await routerClient.UpdateQueueAsync(updateOptions);

            AssertQueueResponseIsEqual(updatedQueueResponse, queueId, createDistributionPolicyResponse.Value.Id, queueName, updatedLabels);
        }

        [Test]
        public async Task CreateQueueAndRemoveProperty()
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();
            var createDistributionPolicyResponse = await CreateDistributionPolicy(nameof(CreateQueueAndRemoveProperty));
            var queueId = GenerateUniqueId(IdPrefix, nameof(CreateQueueAndRemoveProperty));
            var queueName = "DefaultQueueWithLabels" + queueId;
            var createQueueResponse = await routerClient.CreateQueueAsync(
                new CreateQueueOptions(queueId,
                    createDistributionPolicyResponse.Value.Id)
                {
                    Name = queueName,
                    Labels = { ["Label_1"] = new LabelValue("Value_1") }
                });
            AddForCleanup(new Task(async () => await routerClient.DeleteQueueAsync(createQueueResponse.Value.Id)));

            Assert.False(string.IsNullOrWhiteSpace(createQueueResponse.Value.Name));

            var updatedQueueResponse =
                await routerClient.UpdateQueueAsync(queueId, RequestContent.Create(new { Name = (string?)null }));

            var queriedQueue = await routerClient.GetQueueAsync(queueId);
            Assert.True(string.IsNullOrWhiteSpace(queriedQueue.Value.Name));
        }

        #endregion Queue Tests
    }
}
