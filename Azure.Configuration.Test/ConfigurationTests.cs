using Azure.Core.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Configuration.Test;
using Azure.Core.Testing;
using System.Collections.Generic;

namespace Azure.Configuration.Tests
{
    public class ConfigurationServiceTests
    {
        static readonly KeyValue s_testKey = new KeyValue() {
            Key = "test",
            Label = "test",
            Value = "test_now",
            ETag = "c3c231fd-39a0-4cb6-3237-4614474b92c6",
            ContentType = "text",
            LastModified = new DateTimeOffset(2018, 11, 28, 9, 55, 0, 0, default),
            Locked = false
        };

        [Test]
        public async Task SetKeyValue()
        {
            string connectionString = "Endpoint=https://contoso.azconfig.io;Id=b1d9b31;Secret=aabbccdd";
            ConfigurationService.ParseConnectionString(connectionString, out var uri, out var credential, out var secret);

            var service = new ConfigurationService(uri, credential, secret);

            var transport = new SetKeyValueMockTransport();
            transport.KeyValue = s_testKey;
            transport.Responses.Add(HttpStatusCode.NotFound);
            transport.Responses.Add(HttpStatusCode.OK);
            service.Pipeline.Transport = transport;
            var pool = new TestPool<byte>();
            service.Pipeline.Pool = pool;

            Response<KeyValue> added = await service.SetAsync(s_testKey, CancellationToken.None);

            Assert.AreEqual(s_testKey.Key, added.Result.Key);
            Assert.AreEqual(s_testKey.Label, added.Result.Label);
            Assert.AreEqual(s_testKey.ContentType, added.Result.ContentType);
            Assert.AreEqual(s_testKey.Locked, added.Result.Locked);

            added.Dispose();
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public async Task GetKeyValue()
        {
            string connectionString = "Endpoint=https://contoso.azconfig.io;Id=b1d9b31;Secret=aabbccdd";
            ConfigurationService.ParseConnectionString(connectionString, out var uri, out var credential, out var secret);

            var service = new ConfigurationService(uri, credential, secret);

            var transport = new GetKeyValueMockTransport();
            transport.KeyValue = s_testKey;
            transport.Responses.Add(HttpStatusCode.NotFound);
            transport.Responses.Add(HttpStatusCode.OK);
            service.Pipeline.Transport = transport;
            var pool = new TestPool<byte>();
            service.Pipeline.Pool = pool;

            Response<KeyValue> added = await service.GetAsync("test", default, CancellationToken.None);

            Assert.AreEqual(s_testKey.Key, added.Result.Key);
            Assert.AreEqual(s_testKey.Label, added.Result.Label);
            Assert.AreEqual(s_testKey.ContentType, added.Result.ContentType);
            Assert.AreEqual(s_testKey.Locked, added.Result.Locked);
        }

        [Test]
        public async Task GetKeyValues()
        {
            string connectionString = "Endpoint=https://contoso.azconfig.io;Id=b1d9b31;Secret=aabbccdd";
            ConfigurationService.ParseConnectionString(connectionString, out var uri, out var credential, out var secret);

            var service = new ConfigurationService(uri, credential, secret);

            var transport = new GetBatchAsyncMockTransport(5);
            transport.Batches.Add((0, 4));
            transport.Batches.Add((4, 1));

            transport.Responses.Add(HttpStatusCode.NotFound);
            transport.Responses.Add(HttpStatusCode.OK);
            service.Pipeline.Transport = transport;
            var pool = new TestPool<byte>();
            service.Pipeline.Pool = pool;

            var query = new QueryKeyValueCollectionOptions();
            int keyIndex = 0;
            while(true)
            {
                using (var response = await service.GetBatchAsync(query, CancellationToken.None))
                {
                    KeyValueBatch batch = response.Result;
                    foreach (var value in batch)
                    {
                        Assert.AreEqual("key" + keyIndex.ToString(), value.Key);
                        keyIndex++;
                    }
                    query.Index = batch.NextIndex;
                    if (query.Index == 0) break;
                }
            }
        }
    }

    class SetKeyValueMockTransport : MockHttpClientTransport
    {
        public KeyValue KeyValue;
        
        public SetKeyValueMockTransport()
        {
            _expectedMethod = HttpMethod.Put;
            _expectedUri = "https://contoso.azconfig.io/kv/test?label=test";
            _expectedContent = "{\"key\":\"test_now\",\"content_type\":\"text\"}";
        }

        protected override void WriteResponseCore(HttpResponseMessage response)
        {
            string json = JsonConvert.SerializeObject(KeyValue).ToLowerInvariant();
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

            long jsonByteCount = Encoding.UTF8.GetByteCount(json);
            response.Content.Headers.Add("Content-Length", jsonByteCount.ToString());
        }
    }

    class GetKeyValueMockTransport : MockHttpClientTransport
    {
        public KeyValue KeyValue;

        public GetKeyValueMockTransport()
        {
            _expectedMethod = HttpMethod.Get;
            _expectedUri = "https://contoso.azconfig.io/kv/test";
            _expectedContent = null;
        }

        protected override void WriteResponseCore(HttpResponseMessage response)
        {
            string json = JsonConvert.SerializeObject(KeyValue).ToLowerInvariant();
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

            long jsonByteCount = Encoding.UTF8.GetByteCount(json);
            response.Content.Headers.Add("Content-Length", jsonByteCount.ToString());
        }
    }

    class GetBatchAsyncMockTransport : MockHttpClientTransport
    {
        public List<KeyValue> KeyValues = new List<KeyValue>();
        public List<(int index, int count)> Batches = new List<(int index, int count)>();
        int _currentBathIndex = 0;
        
        public GetBatchAsyncMockTransport(int numberOfItems)
        {
            _expectedMethod = HttpMethod.Get;
            _expectedUri = null;
            _expectedContent = null;
            for(int i=0; i< numberOfItems; i++)
            {
                var item = new KeyValue()
                {
                    Key = $"key{i}",
                    Label = "label",
                    Value = "val",
                    ETag = "c3c231fd-39a0-4cb6-3237-4614474b92c1",
                    ContentType = "text"
                };
                KeyValues.Add(item);
            }
        }

        protected override void WriteResponseCore(HttpResponseMessage response)
        {
            var batch = Batches[_currentBathIndex++];
            var bathItems = new List<KeyValue>(batch.count);
            int itemIndex = batch.index;
            int count = batch.count;
            while(count -- > 0)
            {
                bathItems.Add(KeyValues[itemIndex++]);
            }
            string json = JsonConvert.SerializeObject(bathItems).ToLowerInvariant();
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

            long jsonByteCount = Encoding.UTF8.GetByteCount(json);
            response.Content.Headers.Add("Content-Length", jsonByteCount.ToString());
            if (itemIndex < KeyValues.Count)
            {
                response.Headers.Add("Link", $"</kv?after={itemIndex}>;rel=\"next\"");
            }
        }
    }
}
