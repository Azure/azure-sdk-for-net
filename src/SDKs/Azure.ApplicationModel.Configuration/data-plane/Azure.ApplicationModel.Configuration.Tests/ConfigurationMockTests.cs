// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using Azure.Base.Testing;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

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

        private static ConfigurationClient CreateTestService(HttpPipelineTransport transport)
        {
            var options = new ConfigurationClientOptions();
            options.Transport = transport;
            return new ConfigurationClient(connectionString, options);
        }

        [Test]
        public async Task Get()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            ConfigurationSetting setting = await service.GetAsync(s_testSetting.Key);

            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(HttpPipelineMethod.Get, request.Method);
            Assert.AreEqual("https://contoso.azconfig.io/kv/test_key", request.Uri.ToString());
            Assert.AreEqual(s_testSetting, setting);
        }


        [Test]
        public async Task GetWithLabel()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            ConfigurationSetting setting = await service.GetAsync(s_testSetting.Key, s_testSetting.Label);
            var request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(HttpPipelineMethod.Get, request.Method);
            Assert.AreEqual("https://contoso.azconfig.io/kv/test_key?label=test_label", request.Uri.ToString());
            Assert.AreEqual(s_testSetting, setting);
        }

        [Test]
        public void GetNotFound()
        {
            var response = new MockResponse(404);
            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.GetAsync(key: s_testSetting.Key);
            });

            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        public async Task Add()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            ConfigurationSetting setting = await service.AddAsync(s_testSetting);
            var request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(HttpPipelineMethod.Put, request.Method);
            Assert.AreEqual("https://contoso.azconfig.io/kv/test_key?label=test_label", request.Uri.ToString());
            Assert.True(request.TryGetHeader("If-None-Match", out var ifNoneMatch));
            Assert.AreEqual("*", ifNoneMatch);
            AssertContent(SerializationHelpers.Serialize(s_testSetting, SerializeRequestSetting), request);
            Assert.AreEqual(s_testSetting, setting);
        }

        [Test]
        public async Task Set()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            ConfigurationSetting setting = await service.SetAsync(s_testSetting);
            var request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(HttpPipelineMethod.Put, request.Method);
            Assert.AreEqual("https://contoso.azconfig.io/kv/test_key?label=test_label", request.Uri.ToString());
            AssertContent(SerializationHelpers.Serialize(s_testSetting, SerializeRequestSetting), request);
            Assert.AreEqual(s_testSetting, setting);
        }

        [Test]
        public async Task Update()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            ConfigurationSetting setting = await service.UpdateAsync(s_testSetting, CancellationToken.None);
            var request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(HttpPipelineMethod.Put, request.Method);
            Assert.AreEqual("https://contoso.azconfig.io/kv/test_key?label=test_label", request.Uri.ToString());
            AssertContent(SerializationHelpers.Serialize(s_testSetting, SerializeRequestSetting), request);
            Assert.AreEqual(s_testSetting, setting);
            Assert.True(request.TryGetHeader("If-Match", out var ifMatch));
            Assert.AreEqual("*", ifMatch);
        }

        [Test]
        public async Task Delete()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            await service.DeleteAsync(s_testSetting.Key);
            var request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(HttpPipelineMethod.Delete, request.Method);
            Assert.AreEqual("https://contoso.azconfig.io/kv/test_key", request.Uri.ToString());
        }

        [Test]
        public async Task DeleteWithLabel()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            var request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(HttpPipelineMethod.Delete, request.Method);
            Assert.AreEqual("https://contoso.azconfig.io/kv/test_key?label=test_label", request.Uri.ToString());
        }

        [Test]
        public void DeleteNotFound()
        {
            var response = new MockResponse(404);
            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.DeleteAsync(s_testSetting.Key);
            });

            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        public async Task GetBatch()
        {
            var response1 = new MockResponse(200);
            response1.SetContent(SerializationHelpers.Serialize(new []
            {
                CreateSetting(0),
                CreateSetting(1),
            }, SerializeBatch));
            response1.AddHeader(new HttpHeader("Link", $"</kv?after=5>;rel=\"next\""));

            var response2 = new MockResponse(200);
            response2.SetContent(SerializationHelpers.Serialize(new []
            {
                CreateSetting(2),
                CreateSetting(3),
                CreateSetting(4),
            }, SerializeBatch));

            var mockTransport = new MockTransport(response1, response2);
            ConfigurationClient service = CreateTestService(mockTransport);

            var query = new SettingSelector();
            int keyIndex = 0;
            while (true)
            {
                using (Response<SettingBatch> response = await service.GetBatchAsync(query, CancellationToken.None))
                {
                    SettingBatch batch = response.Value;
                    for (int i = 0; i < batch.Count; i++)
                    {
                        ConfigurationSetting value = batch[i];
                        Assert.AreEqual("key" + keyIndex, value.Key);
                        keyIndex++;
                    }

                    var nextBatch = batch.NextBatch;

                    if (nextBatch == null)
                        break;

                    query = nextBatch;
                }
            }

            Assert.AreEqual(2, mockTransport.Requests.Count);

            MockRequest request1 = mockTransport.Requests[0];
            Assert.AreEqual(HttpPipelineMethod.Get, request1.Method);
            Assert.AreEqual("https://contoso.azconfig.io/kv/?key=*&label=*", request1.Uri.ToString());
            AssertRequestCommon(request1);

            MockRequest request2 = mockTransport.Requests[1];
            Assert.AreEqual(HttpPipelineMethod.Get, request2.Method);
            Assert.AreEqual("https://contoso.azconfig.io/kv/?key=*&label=*&after=5", request2.Uri.ToString());
            AssertRequestCommon(request1);
        }

        [Test]
        public async Task ConfiguringTheClient()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(new MockResponse(503), response);

            var options = new ConfigurationClientOptions();
            options.ApplicationId = "test_application";
            options.Transport = mockTransport;

            var client = new ConfigurationClient(connectionString, options);

            ConfigurationSetting setting = await client.GetAsync(s_testSetting.Key);
            Assert.AreEqual(s_testSetting, setting);
            Assert.AreEqual(2, mockTransport.Requests.Count);
        }

        private void AssertContent(byte[] expected, MockRequest request, bool compareAsString = true)
        {
            using (var stream = new MemoryStream())
            {
                request.Content.WriteTo(stream, CancellationToken.None);
                if (compareAsString)
                {
                    Assert.AreEqual(Encoding.UTF8.GetString(expected), Encoding.UTF8.GetString(stream.ToArray()));
                }
                else
                {
                    CollectionAssert.AreEqual(expected, stream.ToArray());
                }
            }
        }

        private void AssertRequestCommon(MockRequest request)
        {
            var expected = HttpHeader.Common.CreateUserAgent("config", "1.0.0.0").Value;
            Assert.True(request.TryGetHeader("User-Agent", out var value));
            StringAssert.StartsWith(expected, value);
        }

        private static ConfigurationSetting CreateSetting(int i)
        {
            return new ConfigurationSetting($"key{i}", "val") {  Label = "label", ETag = new ETag("c3c231fd-39a0-4cb6-3237-4614474b92c1"), ContentType = "text" };
        }

        private void SerializeRequestSetting(ref Utf8JsonWriter json, ConfigurationSetting setting)
        {
            json.WriteStartObject();
            json.WriteString("value", setting.Value);
            json.WriteString("content_type", setting.ContentType);
            if (setting.Tags != null)
            {
                json.WriteStartObject("tags");
                foreach (var tag in setting.Tags)
                {
                    json.WriteString(tag.Key, tag.Value);
                }
                json.WriteEndObject();
            }
            if (setting.ETag != default) json.WriteString("etag", setting.ETag.ToString());
            if (setting.LastModified.HasValue) json.WriteString("last_modified", setting.LastModified.Value.ToString());
            if (setting.Locked.HasValue) json.WriteBoolean("locked", setting.Locked.Value);
            json.WriteEndObject();
        }

        private void SerializeSetting(ref Utf8JsonWriter json, ConfigurationSetting setting)
        {
            json.WriteStartObject();
            json.WriteString("key", setting.Key);
            json.WriteString("label", setting.Label);
            json.WriteString("value", setting.Value);
            json.WriteString("content_type", setting.ContentType);
            if (setting.Tags != null)
            {
                json.WriteStartObject("tags");
                foreach (var tag in setting.Tags)
                {
                    json.WriteString(tag.Key, tag.Value);
                }
                json.WriteEndObject();
            }
            if (setting.ETag != default) json.WriteString("etag", setting.ETag.ToString());
            if (setting.LastModified.HasValue) json.WriteString("last_modified", setting.LastModified.Value.ToString());
            if (setting.Locked.HasValue) json.WriteBoolean("locked", setting.Locked.Value);
            json.WriteEndObject();
        }

        private void SerializeBatch(ref Utf8JsonWriter json, ConfigurationSetting[] settings)
        {
            json.WriteStartObject();
            json.WriteStartArray("items");
            foreach (var item in settings)
            {
                SerializeSetting(ref json, item);
            }
            json.WriteEndArray();
            json.WriteEndObject();
        }
    }
}
