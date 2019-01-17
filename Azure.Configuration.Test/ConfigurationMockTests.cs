// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using NUnit.Framework;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Core;
using Azure.Core.Net;
using System.Buffers;
using Azure.Core.Net.Pipeline;
using Azure.ApplicationModel.Configuration.Test;

namespace Azure.ApplicationModel.Configuration.Tests
{
    public class ConfigurationMockTests
    {
        static readonly string connectionString = "Endpoint=https://contoso.azconfig.io;Id=b1d9b31;Secret=aabbccdd";
        static readonly ConfigurationSetting s_testSetting = new ConfigurationSetting("test_key", "test_value")
        {
            Label = "test_label",
            ETag = "c3c231fd-39a0-4cb6-3237-4614474b92c6",
            ContentType = "test_content_type",
            LastModified = new DateTimeOffset(2018, 11, 28, 9, 55, 0, 0, default),
            Locked = false
        };

        private static (ConfigurationClient service, TestPool<byte> pool) CreateTestService(MockHttpClientTransport transport)
        {
            var options = new PipelineOptions();
            var testPool = new TestPool<byte>();
            options.Pool = testPool;

            options.Transport = transport;

            var service = new ConfigurationClient(connectionString, options);

            return (service, testPool);
        }

        private static void AssertEqual(ConfigurationSetting expected, ConfigurationSetting actual)
        {
            Assert.AreEqual(s_testSetting.Key, actual.Key);
            Assert.AreEqual(s_testSetting.Label, actual.Label);
            Assert.AreEqual(s_testSetting.ContentType, actual.ContentType);
            Assert.AreEqual(s_testSetting.Locked, actual.Locked);
        }

        [Test]
        public async Task Get()
        {
            var transport = new GetMockTransport(s_testSetting.Key, default, s_testSetting);
            var (service, pool) = CreateTestService(transport);

            Response<ConfigurationSetting> response = await service.GetAsync(key: s_testSetting.Key, filter : default, CancellationToken.None);

            Assert.AreEqual(200, response.Status);

            AssertEqual(s_testSetting, response.Result);

            response.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task GetNotFound()
        {
            var transport = new GetMockTransport(s_testSetting.Key, default, HttpStatusCode.NotFound);
            var (service, pool) = CreateTestService(transport);

            Response<ConfigurationSetting> response = await service.GetAsync(key: s_testSetting.Key, filter: default, CancellationToken.None);

            Assert.AreEqual(404, response.Status);
            Assert.IsNull(response.Result);

            response.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Add()
        {
            var transport = new AddMockTransport(s_testSetting);
            var (service, pool) = CreateTestService(transport);

            Response<ConfigurationSetting> response = await service.AddAsync(setting: s_testSetting, CancellationToken.None);

            AssertEqual(s_testSetting, response.Result);

            response.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Set()
        {
            var transport = new SetMockTransport(s_testSetting);
            var (service, pool) = CreateTestService(transport);

            Response<ConfigurationSetting> response = await service.SetAsync(s_testSetting, CancellationToken.None);

            Assert.AreEqual(200, response.Status);
            AssertEqual(s_testSetting, response.Result);

            response.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Update()
        {
            var transport = new UpdateMockTransport(s_testSetting);
            var (service, pool) = CreateTestService(transport);

            Response<ConfigurationSetting> response = await service.UpdateAsync(s_testSetting, CancellationToken.None);

            AssertEqual(s_testSetting, response.Result);

            response.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }
        
        [Test]
        public async Task Delete()
        {
            var transport = new DeleteMockTransport(s_testSetting.Key, new SettingFilter() {Label = s_testSetting.Label }, s_testSetting);
            var (service, pool) = CreateTestService(transport);

            Response<ConfigurationSetting> response = await service.DeleteAsync(key: s_testSetting.Key, filter: s_testSetting.Label);

            Assert.AreEqual(200, response.Status);

            AssertEqual(s_testSetting, response.Result);

            response.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task DeleteNotFound()
        {
            var transport = new DeleteMockTransport(s_testSetting.Key, default, HttpStatusCode.NotFound);
            var (service, pool) = CreateTestService(transport);

            Response<ConfigurationSetting> response = await service.DeleteAsync(key: s_testSetting.Key, filter: default, CancellationToken.None);

            Assert.AreEqual(404, response.Status);
            Assert.IsNull(response.Result);

            response.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Lock()
        {
            var (service, pool) = CreateTestService(new LockingMockTransport(s_testSetting, lockOtherwiseUnlock: true));

            Response<ConfigurationSetting> response = await service.LockAsync(s_testSetting.Key, s_testSetting.Label);

            AssertEqual(s_testSetting, response.Result);

            response.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Unlock()
        {
            var (service, pool) = CreateTestService(new LockingMockTransport(s_testSetting, lockOtherwiseUnlock: false));

            Response<ConfigurationSetting> response = await service.UnlockAsync(s_testSetting.Key, s_testSetting.Label);

            AssertEqual(s_testSetting, response.Result);

            response.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task GetBatch()
        {
            var transport = new GetBatchMockTransport(5);
            transport.Batches.Add((0, 4));
            transport.Batches.Add((4, 1));

            var (service, pool) = CreateTestService(transport);

            var query = new SettingBatchFilter();
            int keyIndex = 0;
            while (true)
            {
                using (var response = await service.GetBatchAsync(query, CancellationToken.None))
                {
                    SettingBatch batch = response.Result;
                    foreach (var value in batch)
                    {
                        Assert.AreEqual("key" + keyIndex.ToString(), value.Key);
                        keyIndex++;
                    }
                    query.StartIndex = batch.NextIndex;

                    if (query.StartIndex == 0) break;
                }
            }

            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task ConfiguringTheClient()
        {
            var options = new PipelineOptions();
            options.ApplicationId = "test_application";
            options.Pool = ArrayPool<byte>.Create(1024 * 1024 * 4, maxArraysPerBucket: 4);
            options.Transport = new GetMockTransport(s_testSetting.Key, default, s_testSetting);
            options.RetryPolicy = RetryPolicy.CreateFixed(5, default, 404);

            var client = new ConfigurationClient(connectionString, options);
            Response<ConfigurationSetting> response = await client.GetAsync(key: s_testSetting.Key, filter: null, CancellationToken.None);

            response.Dispose();
        }
    }
}
