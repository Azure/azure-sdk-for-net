// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class RouterWorkerLiveTests: RouterLiveTestBase
    {
        public RouterWorkerLiveTests(bool isAsync) : base(isAsync)
        {
        }

        #region Worker Tests
        [Test]
        public async Task CreateWorkerTest()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(CreateWorkerTest));

            // Register worker
            var workerId = GenerateUniqueId($"{IdPrefix}{nameof(CreateWorkerTest)}");
            var totalCapacity = 100;

            var channelConfig1 = new ChannelConfiguration(20) { MaxNumberOfJobs = 5 };

            var channelConfigList = new Dictionary<string, ChannelConfiguration?>()
            {
                ["ACS_Chat_Channel"] = channelConfig1
            };
            var workerLabels = new Dictionary<string, LabelValue?>()
            {
                ["test_label_1"] = new LabelValue("testLabel"),
                ["test_label_2"] = new LabelValue(12),
            };

            var queueAssignments = new Dictionary<string, RouterQueueAssignment?> {{ createQueueResponse.Value.Id, new RouterQueueAssignment() }};

            var routerWorkerResponse = await routerClient.CreateWorkerAsync(
                new CreateWorkerOptions(workerId, totalCapacity)
                {
                    QueueAssignments = { { createQueueResponse.Value.Id, new RouterQueueAssignment() } },
                    Labels =
                    {
                        ["test_label_1"] = new LabelValue("testLabel"),
                        ["test_label_2"] = new LabelValue(12),
                    },
                    ChannelConfigurations = { ["ACS_Chat_Channel"] = channelConfig1 }
                });
            AddForCleanup(new Task(async () => await routerClient.DeleteWorkerAsync(workerId)));

            Assert.NotNull(routerWorkerResponse.Value);
            AssertRegisteredWorkerIsValid(routerWorkerResponse, workerId, queueAssignments,
                totalCapacity, workerLabels, channelConfigList);
        }

        [Test]
        public async Task RegisterWorkerShouldNotThrowArgumentNullExceptionTest()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();

            // Register worker with only id and total capacity
            var workerId = $"{IdPrefix}-WorkerIDRegisterWorker";

            var totalCapacity = 100;
            var routerWorkerResponse = await routerClient.CreateWorkerAsync(new CreateWorkerOptions(workerId, totalCapacity) {AvailableForOffers = true});
            AddForCleanup(new Task(async () => await routerClient.DeleteWorkerAsync(workerId)));

            Assert.NotNull(routerWorkerResponse.Value);
        }

        /*[Test]
        public async Task GetWorkersTest()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();

            // Setup queue 1
            var createQueue1Response = await CreateQueueAsync($"Q1{nameof(GetWorkersTest)}");
            var createQueue1 = createQueue1Response.Value;

            // Setup queue 2
            var createQueue2Response = await CreateQueueAsync($"Q2{nameof(GetWorkersTest)}");
            var createQueue2 = createQueue2Response.Value;

            // Setup workers
            var workerId1 = GenerateUniqueId($"{IdPrefix}GetWorkersTest_1");
            var workerId2 = GenerateUniqueId($"{IdPrefix}GetWorkersTest_2");
            var workerId3 = GenerateUniqueId($"{IdPrefix}GetWorkersTest_3");
            var workerId4 = GenerateUniqueId($"{IdPrefix}GetWorkersTest_4");

            var expectedWorkerIds = new List<string>() { workerId1, workerId2, workerId3, workerId4 };

            var registerWorker1Response = await routerClient.CreateWorkerAsync(
                new CreateWorkerOptions(workerId1, 10)
                {
                    QueueAssignments = { [createQueue1.Id] = new RouterQueueAssignment() },
                    ChannelConfigurations =
                    {
                        ["WebChat"] = new ChannelConfiguration(1),
                        ["Voip"] = new ChannelConfiguration(10)
                    },
                    AvailableForOffers = true
                });
            var registerWorker1 = registerWorker1Response.Value;
            AddForCleanup(new Task(async () => await routerClient.UpdateWorkerAsync(new UpdateWorkerOptions(workerId1) { AvailableForOffers = false})));

            var registerWorker2Response = await routerClient.CreateWorkerAsync(
                new CreateWorkerOptions(workerId2, 10)
                {
                    QueueAssignments = { [createQueue2.Id] = new RouterQueueAssignment() },
                    ChannelConfigurations =
                    {
                        ["WebChat"] = new ChannelConfiguration(5) { MaxNumberOfJobs = 1 },
                        ["Voip"] = new ChannelConfiguration(10) { MaxNumberOfJobs = 1 }
                    },
                    AvailableForOffers = true,
                });
            var registerWorker2 = registerWorker2Response.Value;
            AddForCleanup(new Task(async () => await routerClient.UpdateWorkerAsync(new UpdateWorkerOptions(workerId2) { AvailableForOffers = false })));

            var registerWorker3Response = await routerClient.CreateWorkerAsync(
                new CreateWorkerOptions(workerId3, 12)
                {
                    QueueAssignments =
                    {
                        [createQueue1.Id] = new RouterQueueAssignment(),
                        [createQueue2.Id] = new RouterQueueAssignment()
                    },
                    ChannelConfigurations =
                    {
                        ["WebChat"] = new ChannelConfiguration(1) { MaxNumberOfJobs = 12 },
                        ["Voip"] = new ChannelConfiguration(10)
                    },
                    AvailableForOffers = true,
                });
            var registerWorker3 = registerWorker3Response.Value;
            AddForCleanup(new Task(async () => await routerClient.UpdateWorkerAsync(new UpdateWorkerOptions(workerId3) { AvailableForOffers = false })));

            var registerWorker4Response = await routerClient.CreateWorkerAsync(
                new CreateWorkerOptions(workerId4, 10)
                {
                    QueueAssignments = { [createQueue1.Id] = new RouterQueueAssignment() },
                    ChannelConfigurations = { ["WebChat"] = new ChannelConfiguration(1) },
                    AvailableForOffers = true,
                });
            var registerWorker4 = registerWorker4Response.Value;
            AddForCleanup(new Task(async () => await routerClient.UpdateWorkerAsync( new UpdateWorkerOptions(workerId4) { AvailableForOffers = false })));

            // Query all workers with channel filter
            var channel2Workers = new HashSet<string>() { workerId1, workerId2, workerId3 };
            var getWorkersResponse = routerClient.GetWorkersAsync(new GetWorkersOptions() { ChannelId = "Voip" });
            await foreach (var workerPage in getWorkersResponse.AsPages(pageSizeHint: 1))
            {
                Assert.AreEqual(1, workerPage.Values.Count);
                foreach (var worker in workerPage.Values)
                {
                    if (channel2Workers.Contains(worker.Worker.Id))
                    {
                        channel2Workers.Remove(worker.Worker.Id);
                    }
                }
            }
            Assert.IsEmpty(channel2Workers);

            // Query all workers with queue filter
            var queue2Workers = new HashSet<string>() { workerId2, workerId3 };
            getWorkersResponse = routerClient.GetWorkersAsync(new GetWorkersOptions() { QueueId = createQueue2.Id });
            await foreach (var workerPage in getWorkersResponse.AsPages(pageSizeHint: 1))
            {
                Assert.AreEqual(1, workerPage.Values.Count);
                foreach (var worker in workerPage.Values)
                {
                    if (queue2Workers.Contains(worker.Worker.Id))
                    {
                        queue2Workers.Remove(worker.Worker.Id);
                    }
                }
            }
            Assert.IsEmpty(queue2Workers);

            // Query all workers with channel + hasCapacity filter
            var channel1Workers = new HashSet<string>() { workerId1, workerId2, workerId3, workerId4 }; // no worker is expected to get any job
            getWorkersResponse = routerClient.GetWorkersAsync(new GetWorkersOptions() { ChannelId = "WebChat", HasCapacity = true});
            await foreach (var workerPage in getWorkersResponse.AsPages(pageSizeHint: 1))
            {
                Assert.AreEqual(1, workerPage.Values.Count);
                foreach (var worker in workerPage.Values)
                {
                    if (channel1Workers.Contains(worker.Worker.Id))
                    {
                        channel1Workers.Remove(worker.Worker.Id);
                    }
                }
            }
            Assert.IsEmpty(channel1Workers);

            // Deregister worker1
            await routerClient.UpdateWorkerAsync(new UpdateWorkerOptions(workerId1) { AvailableForOffers = false});

            var checkWorker1Status = await Poll(async () => await routerClient.GetWorkerAsync(workerId1),
                w => w.Value.State == RouterWorkerState.Inactive, TimeSpan.FromSeconds(10));

            Assert.AreEqual(RouterWorkerState.Inactive, checkWorker1Status.Value.State);

            // Query all workers with status: active
            var activeWorkers = new HashSet<string>();
            getWorkersResponse = routerClient.GetWorkersAsync(new GetWorkersOptions() { ChannelId = "WebChat", State = RouterWorkerStateSelector.Active});
            await foreach (var workerPage in getWorkersResponse.AsPages(pageSizeHint: 1))
            {
                Assert.AreEqual(1, workerPage.Values.Count);
                foreach (var worker in workerPage.Values)
                {
                    activeWorkers.Add(worker.Worker.Id);
                }
            }

            Assert.IsTrue(activeWorkers.Contains(workerId2));
            Assert.IsTrue(activeWorkers.Contains(workerId3));
            Assert.IsTrue(activeWorkers.Contains(workerId4));

            // Query all workers with status: inactive
            var inactiveWorkers = new HashSet<string>();
            getWorkersResponse = routerClient.GetWorkersAsync(new GetWorkersOptions() { ChannelId = "WebChat", State = RouterWorkerStateSelector.Inactive });
            await foreach (var workerPage in getWorkersResponse.AsPages(pageSizeHint: 1))
            {
                Assert.AreEqual(1, workerPage.Values.Count);
                foreach (var worker in workerPage.Values)
                {
                    inactiveWorkers.Add(worker.Worker.Id);
                }
            }
            Assert.IsTrue(inactiveWorkers.Contains(workerId1));

            // in-test cleanup workers before deleting queue and channel
            await routerClient.DeleteWorkerAsync(expectedWorkerIds[0]);
            await routerClient.DeleteWorkerAsync(expectedWorkerIds[1]);
            await routerClient.DeleteWorkerAsync(expectedWorkerIds[2]);
            await routerClient.DeleteWorkerAsync(expectedWorkerIds[3]);
        }*/

        [Test]
        public async Task UpdateWorkerTest()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(UpdateWorkerTest));

            // Register worker
            var workerId = GenerateUniqueId($"{IdPrefix}{nameof(UpdateWorkerTest)}");
            var totalCapacity = 100;
            var channelConfigList = new Dictionary<string, ChannelConfiguration?>()
            {
                ["ACS_Chat_Channel"] = new(20) { MaxNumberOfJobs = 5 },
                ["ACS_Voice_Channel"] = new(10) { MaxNumberOfJobs = 3}
            };
            var workerLabels = new Dictionary<string, LabelValue?>()
            {
                ["test_label_1"] = new("testLabel"),
                ["test_label_2"] = new(12),
            };
            var workerTags = new Dictionary<string, LabelValue?>()
            {
                ["test_tag_1"] = new("tag"),
                ["test_tag_2"] = new(12),
            };

            var queueAssignments = new Dictionary<string, RouterQueueAssignment?> {{ createQueueResponse.Value.Id, new RouterQueueAssignment() }};

            var createWorkerOptions = new CreateWorkerOptions(workerId, totalCapacity)
            {
                AvailableForOffers = true
            };
            createWorkerOptions.Labels.Append(workerLabels);
            createWorkerOptions.ChannelConfigurations.Append(channelConfigList);
            createWorkerOptions.QueueAssignments.Append(queueAssignments);
            createWorkerOptions.Tags.Append(workerTags);

            var routerWorkerResponse = await routerClient.CreateWorkerAsync(createWorkerOptions);
            AddForCleanup(new Task(async () => await routerClient.DeleteWorkerAsync(workerId)));

            Assert.NotNull(routerWorkerResponse.Value);
            AssertRegisteredWorkerIsValid(routerWorkerResponse, workerId, queueAssignments,
                totalCapacity, workerLabels, channelConfigList, workerTags);

            // Remove queue assignment, channel configuration and label
            queueAssignments[createQueueResponse.Value.Id] = null;
            channelConfigList[channelConfigList.First().Key] = null;
            workerLabels[workerLabels.First().Key] = null;
            workerTags[workerTags.First().Key] = null;

            var updateWorkerOptions = new UpdateWorkerOptions(workerId)
            {
                AvailableForOffers = false
            };
            updateWorkerOptions.Labels.Append(workerLabels);
            updateWorkerOptions.ChannelConfigurations.Append(channelConfigList);
            updateWorkerOptions.QueueAssignments.Append(queueAssignments);
            updateWorkerOptions.Tags.Append(workerTags);

            var updateWorkerResponse = await routerClient.UpdateWorkerAsync(updateWorkerOptions);

            updateWorkerOptions.ChannelConfigurations.Remove(channelConfigList.First().Key);
            updateWorkerOptions.Labels.Remove(workerLabels.First().Key);
            updateWorkerOptions.Tags.Remove(workerTags.First().Key);

            AssertRegisteredWorkerIsValid(updateWorkerResponse, workerId, new Dictionary<string, RouterQueueAssignment?>(),
                totalCapacity, updateWorkerOptions.Labels, updateWorkerOptions.ChannelConfigurations, updateWorkerOptions.Tags);
        }

        #endregion Worker Tests
    }
}
