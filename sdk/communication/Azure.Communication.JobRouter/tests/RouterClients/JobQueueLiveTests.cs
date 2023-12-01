// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
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
            var queueLabels = new Dictionary<string, LabelValue?>() { ["Label_1"] = new LabelValue("Value_1") };
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
            var queueLabels = new Dictionary<string, LabelValue?>
            {
                ["Label_1"] = new LabelValue("Value_1"),
                ["Label_2"] = new LabelValue(2),
                ["Label_3"] = new LabelValue(true)
            };
            var createQueueResponse = await routerClient.CreateQueueAsync(
                new CreateQueueOptions(queueId,
                    createDistributionPolicyResponse.Value.Id)
                {
                    Name = queueName,
                    Labels =
                    {
                        ["Label_1"] = new LabelValue("Value_1"),
                        ["Label_2"] = new LabelValue(2),
                        ["Label_3"] = new LabelValue(true)
                    }
                });
            AddForCleanup(new Task(async () => await routerClient.DeleteQueueAsync(createQueueResponse.Value.Id)));
            AssertQueueResponseIsEqual(createQueueResponse, queueId, createDistributionPolicyResponse.Value.Id, queueName, queueLabels);

            var updatedLabels = new Dictionary<string, LabelValue?>(createQueueResponse.Value.Labels.ToDictionary(x => x.Key, x => (LabelValue?)x.Value))
            {
                ["Label_1"] = null,
                ["Label_2"] = new LabelValue(null),
                ["Label_3"] = new LabelValue("Value_Updated_3"),
                ["Label_4"] = new LabelValue("Value_4")
            };

            var updateOptions = new UpdateQueueOptions(queueId);
            updateOptions.Labels.Append(updatedLabels);

            var updatedQueueResponse = await routerClient.UpdateQueueAsync(updateOptions);

            AssertQueueResponseIsEqual(updatedQueueResponse, queueId, createDistributionPolicyResponse.Value.Id, queueName, new Dictionary<string, LabelValue?>
            {
                ["Label_3"] = new LabelValue("Value_Updated_3"),
                ["Label_4"] = new LabelValue("Value_4")
            });
        }

        #endregion Queue Tests
    }
}
