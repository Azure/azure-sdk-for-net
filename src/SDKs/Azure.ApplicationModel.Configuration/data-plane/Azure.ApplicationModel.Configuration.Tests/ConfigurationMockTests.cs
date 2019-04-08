// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using NUnit.Framework;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Base.Testing;
using Azure.Base;
using Azure.Base.Http;
using System.Buffers;
using Azure.Base.Http.Pipeline;
using Azure.ApplicationModel.Configuration.Test;
using System.Collections.Generic;

namespace Azure.ApplicationModel.Configuration.Tests
{
    public class ConfigurationMockTests
    {
        static readonly string connectionString = "Endpoint=https://contoso.azconfig.io;Id=b1d9b31;Secret=aabbccdd";
        static readonly ConfigurationSetting s_testSetting = new ConfigurationSetting("test_key", "test_value")
        {
            Label = "test_label",
            ContentType = "test_content_type",
            Tags = new Dictionary<string, string>
            {
                { "tag1", "value1" },
                { "tag2", "value2" }
            }
        };

        private static (ConfigurationClient service, TestPool<byte> pool) CreateTestService(MockHttpClientTransport transport)
        {
            HttpPipelineOptions options = ConfigurationClient.CreateDefaultPipelineOptions();
            var testPool = new TestPool<byte>();
            options.AddService(testPool, typeof(ArrayPool<byte>));

            options.Transport = transport;

            var service = new ConfigurationClient(connectionString, options);

            return (service, testPool);
        }

        private static bool TagsEqual(IDictionary<string, string> expected, IDictionary<string, string> actual)
        {
            if (expected == null && actual == null) return true;
            if (expected?.Count != actual?.Count) return false;
            foreach (var pair in expected)
            {
                if (!actual.TryGetValue(pair.Key, out string value)) return false;
                if (!string.Equals(value, pair.Value, StringComparison.Ordinal)) return false;
            }
            return true;
        }

        [Test]
        public async Task Get()
        {
            var transport = new GetMockTransport(s_testSetting.Key, default, s_testSetting);
            var (service, pool) = CreateTestService(transport);

            ConfigurationSetting setting = await service.GetAsync(s_testSetting.Key);

            Assert.AreEqual(s_testSetting, setting);
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task GetWithLabel()
        {
            var transport = new GetMockTransport(s_testSetting.Key, s_testSetting.Label, s_testSetting);
            var (service, pool) = CreateTestService(transport);

            ConfigurationSetting setting = await service.GetAsync(s_testSetting.Key, s_testSetting.Label);

            Assert.AreEqual(s_testSetting, setting);
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public void GetNotFound()
        {
            var transport = new GetMockTransport(s_testSetting.Key, default, s_testSetting, HttpStatusCode.NotFound);
            var (service, pool) = CreateTestService(transport);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.GetAsync(key: s_testSetting.Key);
            });
            Assert.AreEqual(404, exception.Status);

            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Add()
        {
            var transport = new AddMockTransport(s_testSetting);
            var (service, pool) = CreateTestService(transport);

            ConfigurationSetting setting = await service.AddAsync(setting: s_testSetting);

            Assert.AreEqual(s_testSetting, setting);
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Set()
        {
            var transport = new SetMockTransport(s_testSetting);
            var (service, pool) = CreateTestService(transport);

            ConfigurationSetting setting = await service.SetAsync(s_testSetting);

            Assert.AreEqual(s_testSetting, setting);
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Update()
        {
            var transport = new UpdateMockTransport(s_testSetting);
            var (service, pool) = CreateTestService(transport);

            ConfigurationSetting setting = await service.UpdateAsync(s_testSetting, CancellationToken.None);

            Assert.AreEqual(s_testSetting, setting);
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Delete()
        {
            var transport = new DeleteMockTransport(s_testSetting.Key, default, s_testSetting);
            var (service, pool) = CreateTestService(transport);

            await service.DeleteAsync(s_testSetting.Key);
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task DeletewithLabel()
        {
            var transport = new DeleteMockTransport(s_testSetting.Key, s_testSetting.Label, s_testSetting);
            var (service, pool) = CreateTestService(transport);

            await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public void DeleteNotFound()
        {
            var transport = new DeleteMockTransport(s_testSetting.Key, default, HttpStatusCode.NotFound);
            var (service, pool) = CreateTestService(transport);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.DeleteAsync(s_testSetting.Key);
            });
            Assert.AreEqual(404, exception.Status);

            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Lock()
        {
            var (service, pool) = CreateTestService(new LockingMockTransport(s_testSetting, lockOtherwiseUnlock: true));

            ConfigurationSetting setting = await service.LockAsync(s_testSetting.Key, s_testSetting.Label);

            Assert.True(setting.Locked);
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Unlock()
        {
            var (service, pool) = CreateTestService(new LockingMockTransport(s_testSetting, lockOtherwiseUnlock: false));

            ConfigurationSetting setting = await service.UnlockAsync(s_testSetting.Key, s_testSetting.Label);

            Assert.False(setting.Locked);
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task GetBatch()
        {
            var transport = new GetBatchMockTransport(5);
            transport.Batches.Add((0, 4));
            transport.Batches.Add((4, 1));

            var (service, pool) = CreateTestService(transport);

            var query = new SettingSelector();
            int keyIndex = 0;
            while (true)
            {
                using (var response = await service.GetBatchAsync(query, CancellationToken.None))
                {
                    SettingBatch batch = response.Value;
                    for (int i = 0; i < batch.Count; i++)
                    {
                        ConfigurationSetting value = batch[i];
                        Assert.AreEqual("key" + keyIndex.ToString(), value.Key);
                        keyIndex++;
                    }
                    var nextBatch = batch.NextBatch;

                    if (nextBatch == null) break;

                    query = nextBatch;
                }
            }

            Assert.AreEqual(0, pool.CurrentlyRented);
        }

#if WindowsOS
        [Test]
        public async Task ConfiguringTheClient()
        {
            var options = ConfigurationClient.CreateDefaultPipelineOptions();
            options.ApplicationId = "test_application";
            options.AddService(ArrayPool<byte>.Create(1024 * 1024 * 4, maxArraysPerBucket: 4), typeof(ArrayPool<byte>));
            options.Transport = new GetMockTransport(s_testSetting.Key, default, s_testSetting, HttpStatusCode.RequestTimeout, HttpStatusCode.OK);
            options.RetryPolicy = RetryPolicy.CreateFixed(2, TimeSpan.FromMilliseconds(100), 408 /* RequestTimeout */);

            var testPolicy = new TestPolicy();
            options.AddPerRetryPolicy(testPolicy);

            var client = new ConfigurationClient(connectionString, options);

            ConfigurationSetting setting = await client.GetAsync(s_testSetting.Key);
            Assert.AreEqual(s_testSetting, setting);
            Assert.AreEqual(2, testPolicy.Retries);
        }
#endif

        // TODO (pri 2): this should check the UA header, but this in turn requires the ability to read headers.
        // TODO (pri 2): this should try to retrieve the service, but currently services are not passed to the pipeline.
        class TestPolicy : HttpPipelinePolicy
        {
            int _retries = 0;

            public int Retries => _retries;

            public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                _retries++;
                await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
            }
        }
    }
}
