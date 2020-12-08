// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    public class DispatchQueueEndToEndTests : IDisposable
    {
        // tells you how many function with different arguments have been ran
        private static ConcurrentStringSet _funcInvocation;

        private static Stopwatch _stopwatch = new Stopwatch();

        private QueueClient _sharedQueue;
        private QueueClient _poisonQueue;

        // Each test should set this up; it will be used during cleanup.
        private IHost _host;

        // thin wrapper around concurrentDictionary
        private class ConcurrentStringSet
        {
            private ConcurrentDictionary<String, int> _internal = new ConcurrentDictionary<string, int>();
            private bool _duplicate = false;
            private int _total = 0;
            public void Add(string value)
            {
                _internal.AddOrUpdate(value, 1, (k, v) =>
                {
                    _duplicate = true;
                    return v + 1;
                });
                Interlocked.Increment(ref _total);
            }

            public int TotalAdd()
            {
                return _total;
            }

            public bool HasDuplicate()
            {
                return _duplicate;
            }
        }

        [Test]
        [Ignore("Fix DispatchQueue")]
        // same trigger type, multiple functions
        public async Task DispatchQueueBatchTriggerTest()
        {
            _host = new HostBuilder()
                .ConfigureDefaultTestHost<SampleTrigger>(b =>
                {
                    // each test will have a unique hostId so that consecutive test run will not be affected by clean up code
                    b.UseHostId(Guid.NewGuid().ToString("N"))
                    .AddAzureStorageBlobs().AddAzureStorageQueues()
                    .AddExtension<DispatchQueueTestConfig>();
                })
                .Build();

            {
                _funcInvocation = new ConcurrentStringSet();

                _host.Start();

                _stopwatch.Restart();

                int twoFuncCount = DispatchQueueTestConfig.BatchSize * 2;
                await TestHelpers.Await(() => _funcInvocation.TotalAdd() >= twoFuncCount || _funcInvocation.HasDuplicate(),
                                        7000, 1000);

                // make sure each function is triggered once and only once
                Assert.AreEqual(twoFuncCount, _funcInvocation.TotalAdd());
                Assert.False(_funcInvocation.HasDuplicate());

                _stopwatch.Stop();
            }
        }

        [Test]
        [Ignore("Fix DispatchQueue")]
        public async Task PoisonQueueTest()
        {
            _host = new HostBuilder()
                .ConfigureDefaultTestHost<SampleTriggerWithPoisonQueue>(b =>
                {
                    // each test will have a unique hostId so that consecutive test run will not be affected by clean up code
                    b.UseHostId(Guid.NewGuid().ToString("N"))
                    .AddAzureStorageBlobs().AddAzureStorageQueues()
                    .AddExtension<DispatchQueueTestConfig>();
                })
                .Build();

            {
                _funcInvocation = new ConcurrentStringSet();

                _host.Start();

                _stopwatch.Restart();

                // this test takes long since it does at least 5 dequeue on the poison message
                // count retries caused by failures and poison queue function process
                int funcWithExceptionCount = DispatchQueueTestConfig.BatchSize + _host.GetOptions<QueuesOptions>().MaxDequeueCount;
                await TestHelpers.Await(() => _funcInvocation.TotalAdd() >= funcWithExceptionCount, 10000, 1000);

                Assert.AreEqual(funcWithExceptionCount, _funcInvocation.TotalAdd());
                Assert.True(_funcInvocation.HasDuplicate());
                Assert.True(SampleTriggerWithPoisonQueue.PoisonQueueResult);

                _stopwatch.Stop();
            }
        }

        public void Dispose()
        {
            // each test will have a different hostId
            // and therefore a different sharedQueue and poisonQueue
            if (_host != null)
            {
                var client = _host.GetStorageAccount().CreateQueueServiceClient();
                _sharedQueue = client.GetQueueClient("azure-webjobs-shared-" + _host.Services.GetService<IHostIdProvider>().GetHostIdAsync(CancellationToken.None).Result);
                _poisonQueue = client.GetQueueClient("azure-webjobs-poison-" + _host.Services.GetService<IHostIdProvider>().GetHostIdAsync(CancellationToken.None).Result);
                _sharedQueue.DeleteIfExistsAsync().Wait();
                _poisonQueue.DeleteIfExistsAsync().Wait();

                _host.Dispose();
            }
        }

        public class SampleTriggerWithPoisonQueue
        {
            public static bool PoisonQueueResult = false;
            public void PoisonQueueTrigger([DispatchQueueTrigger]JObject json)
            {
                int order = json["order"].Value<int>();
                string funcSignature = "PoisonQueueTrigger arg: " + order;
                _funcInvocation.Add(funcSignature);
                TestContext.WriteLine(funcSignature + " elapsed time: " + _stopwatch.ElapsedMilliseconds + " ms");
                if (order == 0)
                {
                    throw new Exception("Can't deal with zero :(");
                }
            }

            public void PosionQueueProcess([QueueTrigger("azure-webjobs-poison-pqtest")]JObject message)
            {
                string functionId = message["FunctionId"].Value<string>();
                int value = message["Data"]["order"].Value<int>();
                if (functionId.Contains("PoisonQueueTrigger") && value == 0)
                {
                    PoisonQueueResult = true;
                }
                _funcInvocation.Add("PosionQueueProcess");
                TestContext.WriteLine("PoisonQueueProcess" + " elapsed time: " + _stopwatch.ElapsedMilliseconds + " ms");
            }
        }

        public class SampleTrigger
        {
            public void DispatchQueueTrigger([DispatchQueueTrigger]JObject json)
            {
                string funcSignature = "DispatchQueueTrigger arg: " + json["order"].Value<int>();
                _funcInvocation.Add(funcSignature);
                TestContext.WriteLine(funcSignature + " elapsed time: " + _stopwatch.ElapsedMilliseconds + " ms");
            }

            public void DispatchQueueTrigger2([DispatchQueueTrigger]JObject json)
            {
                string funcSignature = "DispatchQueueTrigger2 arg: " + json["order"].Value<int>();
                _funcInvocation.Add(funcSignature);
                TestContext.WriteLine(funcSignature + " elapsed time: " + _stopwatch.ElapsedMilliseconds + " ms");
            }
        }
    }
}
