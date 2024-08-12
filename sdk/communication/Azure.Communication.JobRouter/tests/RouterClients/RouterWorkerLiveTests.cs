// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
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
            var capacity = 100;

            var channel1 = new RouterChannel("ACS_Chat_Channel", 20) { MaxNumberOfJobs = 5 };

            var channels = new List<RouterChannel> { channel1 };

            var workerLabels = new Dictionary<string, RouterValue?>()
            {
                ["test_label_1"] = new RouterValue("testLabel"),
                ["test_label_2"] = new RouterValue(12),
            };

            var queues = new List<string> { createQueueResponse.Value.Id };

            var routerWorkerResponse = await routerClient.CreateWorkerAsync(
                new CreateWorkerOptions(workerId, capacity)
                {
                    Queues = { createQueueResponse.Value.Id },
                    Labels =
                    {
                        ["test_label_1"] = new RouterValue("testLabel"),
                        ["test_label_2"] = new RouterValue(12),
                    },
                    Channels = { channel1 }
                });
            AddForCleanup(new Task(async () => await routerClient.DeleteWorkerAsync(workerId)));

            Assert.NotNull(routerWorkerResponse.Value);
            AssertRegisteredWorkerIsValid(routerWorkerResponse, workerId, queues,
                capacity, workerLabels, channels);

            routerWorkerResponse.Value.AvailableForOffers = false;
            routerWorkerResponse.Value.Queues.RemoveAt(0);

            await routerClient.UpdateWorkerAsync(routerWorkerResponse);
        }

        [Test]
        public async Task RegisterWorkerShouldNotThrowArgumentNullExceptionTest()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();

            // Register worker with only id and total capacity
            var workerId = $"{IdPrefix}-WorkerIDRegisterWorker";

            var capacity = 100;
            var routerWorkerResponse = await routerClient.CreateWorkerAsync(new CreateWorkerOptions(workerId, capacity) {AvailableForOffers = true});
            AddForCleanup(new Task(async () => await routerClient.DeleteWorkerAsync(workerId)));

            Assert.NotNull(routerWorkerResponse.Value);

            routerWorkerResponse.Value.AvailableForOffers = false;
            await routerClient.UpdateWorkerAsync(routerWorkerResponse);
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
                    Queues = { createQueue1.Id, },
                    Channels =
                    {
                        new RouterChannel("WebChat", 1),
                        ["Voip"] = new RouterChannel(10)
                    },
                    AvailableForOffers = true
                });
            var registerWorker1 = registerWorker1Response.Value;
            AddForCleanup(new Task(async () => await routerClient.UpdateWorkerAsync(new RouterWorker(workerId1) { AvailableForOffers = false})));

            var registerWorker2Response = await routerClient.CreateWorkerAsync(
                new CreateWorkerOptions(workerId2, 10)
                {
                    Queues = { createQueue2.Id, },
                    Channels =
                    {
                        ["WebChat"] = new RouterChannel(5) { MaxNumberOfJobs = 1 },
                        ["Voip"] = new RouterChannel(10) { MaxNumberOfJobs = 1 }
                    },
                    AvailableForOffers = true,
                });
            var registerWorker2 = registerWorker2Response.Value;
            AddForCleanup(new Task(async () => await routerClient.UpdateWorkerAsync(new RouterWorker(workerId2) { AvailableForOffers = false })));

            var registerWorker3Response = await routerClient.CreateWorkerAsync(
                new CreateWorkerOptions(workerId3, 12)
                {
                    Queues =
                    {
                        createQueue1.Id,,
                        createQueue2.Id,
                    },
                    Channels =
                    {
                        ["WebChat"] = new RouterChannel(1) { MaxNumberOfJobs = 12 },
                        ["Voip"] = new RouterChannel(10)
                    },
                    AvailableForOffers = true,
                });
            var registerWorker3 = registerWorker3Response.Value;
            AddForCleanup(new Task(async () => await routerClient.UpdateWorkerAsync(new RouterWorker(workerId3) { AvailableForOffers = false })));

            var registerWorker4Response = await routerClient.CreateWorkerAsync(
                new CreateWorkerOptions(workerId4, 10)
                {
                    Queues = { createQueue1.Id, },
                    Channels = { ["WebChat"] = new RouterChannel(1) },
                    AvailableForOffers = true,
                });
            var registerWorker4 = registerWorker4Response.Value;
            AddForCleanup(new Task(async () => await routerClient.UpdateWorkerAsync( new RouterWorker(workerId4) { AvailableForOffers = false })));

            // Query all workers with channel filter
            var channel2Workers = new HashSet<string>() { workerId1, workerId2, workerId3 };
            var getWorkersResponse = routerClient.GetWorkersAsync(new GetWorkersOptions() { ChannelId = "Voip" });
            await foreach (var workerPage in getWorkersResponse.AsPages(pageSizeHint: 1))
            {
                Assert.AreEqual(1, workerPage.Values.Count);
                foreach (var worker in workerPage.Values)
                {
                    if (channel2Workers.Contains(worker.Id))
                    {
                        channel2Workers.Remove(worker.Id);
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
                    if (queue2Workers.Contains(worker.Id))
                    {
                        queue2Workers.Remove(worker.Id);
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
                    if (channel1Workers.Contains(worker.Id))
                    {
                        channel1Workers.Remove(worker.Id);
                    }
                }
            }
            Assert.IsEmpty(channel1Workers);

            // Deregister worker1
            await routerClient.UpdateWorkerAsync(new RouterWorker(workerId1) { AvailableForOffers = false});

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
                    activeWorkers.Add(worker.Id);
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
                    inactiveWorkers.Add(worker.Id);
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
            var capacity = 100;
            var channels = new List<RouterChannel>()
            {
                new("ACS_Chat_Channel", 20) { MaxNumberOfJobs = 5 },
                new("ACS_Voice_Channel", 10) { MaxNumberOfJobs = 3 }
            };
            var workerLabels = new Dictionary<string, RouterValue?>()
            {
                ["test_label_1"] = new("testLabel"),
                ["test_label_2"] = new(12),
            };
            var workerTags = new Dictionary<string, RouterValue?>()
            {
                ["test_tag_1"] = new("tag"),
                ["test_tag_2"] = new(12),
            };

            var queues = new List<string> { createQueueResponse.Value.Id };

            var createWorkerOptions = new CreateWorkerOptions(workerId, capacity)
            {
                AvailableForOffers = true
            };
            createWorkerOptions.Labels.Append(workerLabels);
            createWorkerOptions.Channels.AddRange(channels);
            createWorkerOptions.Queues.AddRange(queues);
            createWorkerOptions.Tags.Append(workerTags);

            var routerWorkerResponse = await routerClient.CreateWorkerAsync(createWorkerOptions);
            AddForCleanup(new Task(async () => await routerClient.DeleteWorkerAsync(workerId)));

            Assert.NotNull(routerWorkerResponse.Value);
            AssertRegisteredWorkerIsValid(routerWorkerResponse, workerId, queues,
                capacity, workerLabels, channels, workerTags);

            var updatedWorker = routerWorkerResponse.Value;
            updatedWorker.Labels[workerLabels.First().Key] = null;
            updatedWorker.Tags[workerTags.First().Key] = null;
            updatedWorker.Queues.Remove(createQueueResponse.Value.Id);
            updatedWorker.Channels.RemoveAt(0);

            var updateWorkerResponse = await routerClient.UpdateWorkerAsync(updatedWorker);

            updatedWorker.Labels.Remove("Id");
            updatedWorker.Labels.Remove(workerLabels.First().Key);
            updatedWorker.Tags.Remove(workerTags.First().Key);

            AssertRegisteredWorkerIsValid(updateWorkerResponse, workerId, new List<string>(),
                capacity, updatedWorker.Labels, updatedWorker.Channels, updatedWorker.Tags);

            // in-test cleanup
            updatedWorker.AvailableForOffers = false;

            await routerClient.UpdateWorkerAsync(updatedWorker);
        }

        #endregion Worker Tests
    }
}
