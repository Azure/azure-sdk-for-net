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
            var queueLabels = new Dictionary<string, RouterValue?>() { ["Label_1"] = new RouterValue("Value_1") };
            var createQueueResponse = await routerClient.CreateQueueAsync(
                new CreateQueueOptions(queueId,
                    createDistributionPolicyResponse.Value.Id)
                {
                    Name = queueName,
                    Labels = { ["Label_1"] = new RouterValue("Value_1") }
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
            var queueLabels = new Dictionary<string, RouterValue?>
            {
                ["Label_1"] = new RouterValue("Value_1"),
                ["Label_2"] = new RouterValue(2),
                ["Label_3"] = new RouterValue(true)
            };
            var createQueueResponse = await routerClient.CreateQueueAsync(
                new CreateQueueOptions(queueId,
                    createDistributionPolicyResponse.Value.Id)
                {
                    Name = queueName,
                    Labels =
                    {
                        ["Label_1"] = new RouterValue("Value_1"),
                        ["Label_2"] = new RouterValue(2),
                        ["Label_3"] = new RouterValue(true)
                    }
                });
            AddForCleanup(new Task(async () => await routerClient.DeleteQueueAsync(createQueueResponse.Value.Id)));
            AssertQueueResponseIsEqual(createQueueResponse, queueId, createDistributionPolicyResponse.Value.Id, queueName, queueLabels);

            createQueueResponse.Value.Labels["Label_1"] = null;
            createQueueResponse.Value.Labels["Label_2"] = new RouterValue(null);
            createQueueResponse.Value.Labels["Label_3"] = new RouterValue("Value_Updated_3");
            createQueueResponse.Value.Labels["Label_4"] = new RouterValue("Value_4");

            var updatedQueueResponse = await routerClient.UpdateQueueAsync(createQueueResponse.Value);

            AssertQueueResponseIsEqual(updatedQueueResponse, queueId, createDistributionPolicyResponse.Value.Id, queueName, new Dictionary<string, RouterValue?>
            {
                ["Label_3"] = new RouterValue("Value_Updated_3"),
                ["Label_4"] = new RouterValue("Value_4")
            });
        }

        #endregion Queue Tests
    }
}
