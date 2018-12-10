using Azure.Core.Net;
using NUnit.Framework;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Configuration.Test;
using Azure.Core.Testing;

namespace Azure.Configuration.Tests
{
    public class ConfigurationServiceTests
    {
        static readonly string connectionString = "Endpoint=https://contoso.azconfig.io;Id=b1d9b31;Secret=aabbccdd";
        static readonly ConfigurationSetting s_testKey = new ConfigurationSetting()
        {
            Key = "test_key",
            Label = "test_label",
            Value = "test_value",
            ETag = "c3c231fd-39a0-4cb6-3237-4614474b92c6",
            ContentType = "test_content_type",
            LastModified = new DateTimeOffset(2018, 11, 28, 9, 55, 0, 0, default),
            Locked = false
        };

        private static (ConfigurationClient service, TestPool<byte> pool) CreateTestService(MockHttpClientTransport transport)
        {
            var service = new ConfigurationClient(connectionString);
            var pool = new TestPool<byte>();

            if (transport.Responses.Count == 0)
            {
                transport.Responses.Add(HttpStatusCode.NotFound);
                transport.Responses.Add(HttpStatusCode.OK);
            }
            service.Pipeline.Transport = transport;
            service.Pipeline.Pool = pool;

            return (service, pool);
        }

        private static void AssertEqual(ConfigurationSetting expected, ConfigurationSetting actual)
        {
            Assert.AreEqual(s_testKey.Key, actual.Key);
            Assert.AreEqual(s_testKey.Label, actual.Label);
            Assert.AreEqual(s_testKey.ContentType, actual.ContentType);
            Assert.AreEqual(s_testKey.Locked, actual.Locked);
        }

        [Test]
        public async Task Get()
        {
            var transport = new GetMockTransport(s_testKey);
            var (service, pool) = CreateTestService(transport);

            Response<ConfigurationSetting> response = await service.GetAsync(key: "test_key", options: default, CancellationToken.None);

            AssertEqual(s_testKey, response.Result);

            response.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task GetNotFound()
        {
            var transport = new GetMockTransport(HttpStatusCode.NotFound);
            var (service, pool) = CreateTestService(transport);

            Response<ConfigurationSetting> response = await service.GetAsync(key: "test_key_not_present", options: default, CancellationToken.None);

            Assert.AreEqual(404, response.Status);
            Assert.IsNull(response.Result);

            response.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Add()
        {
            var transport = new AddMockTransport(s_testKey);
            var (service, pool) = CreateTestService(transport);

            Response<ConfigurationSetting> response = await service.AddAsync(s_testKey, CancellationToken.None);

            AssertEqual(s_testKey, response.Result);

            response.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Set()
        {
            var transport = new SetMockTransport(s_testKey);
            var (service, pool) = CreateTestService(transport);

            Response<ConfigurationSetting> response = await service.SetAsync(s_testKey, CancellationToken.None);

            AssertEqual(s_testKey, response.Result);

            response.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Update()
        {
            var transport = new UpdateMockTransport(s_testKey);
            var (service, pool) = CreateTestService(transport);

            Response<ConfigurationSetting> response = await service.UpdateAsync(s_testKey, CancellationToken.None);

            AssertEqual(s_testKey, response.Result);

            response.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Delete()
        {
            var transport = new DeleteMockTransport(s_testKey);
            var (service, pool) = CreateTestService(transport);

            Response<ConfigurationSetting> response = await service.DeleteAsync(s_testKey, CancellationToken.None);

            AssertEqual(s_testKey, response.Result);

            response.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Lock()
        {
            var (service, pool) = CreateTestService(new LockingMockTransport(s_testKey, lockOtherwiseUnlock: true));

            Response<ConfigurationSetting> response = await service.LockAsync(s_testKey, CancellationToken.None);

            AssertEqual(s_testKey, response.Result);

            response.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task Unlock()
        {
            var (service, pool) = CreateTestService(new LockingMockTransport(s_testKey, lockOtherwiseUnlock: false));

            Response<ConfigurationSetting> response = await service.UnlockAsync(s_testKey, CancellationToken.None);

            AssertEqual(s_testKey, response.Result);

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

            var query = new BatchQueryOptions();
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
    }
}
