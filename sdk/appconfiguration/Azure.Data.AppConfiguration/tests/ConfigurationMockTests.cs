// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class ConfigurationMockTests : ClientTestBase
    {
        private static readonly string s_endpoint = "https://contoso.appconfig.io";
        private static readonly string s_credential = "b1d9b31";
        private static readonly string s_secret = "aabbccdd";
        private static readonly string s_connectionString = $"Endpoint={s_endpoint};Id={s_credential};Secret={s_secret}";
        private static readonly string s_version = new ConfigurationClientOptions().GetVersionString();

        private static readonly ConfigurationSetting s_testSetting = new ConfigurationSetting("test_key", "test_value")
        {
            Label = "test_label",
            ContentType = "test_content_type",
            Tags = new Dictionary<string, string>
            {
                { "tag1", "value1" },
                { "tag2", "value2" }
            }
        };

        public ConfigurationMockTests(bool isAsync) : base(isAsync) { }

        private ConfigurationClient CreateTestService(HttpPipelineTransport transport)
        {
            var options = new ConfigurationClientOptions
            {
                Transport = transport
            };

            var client = InstrumentClient(new ConfigurationClient(s_connectionString, options));

            return client;
        }

        [Test]
        public async Task Get()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            ConfigurationSetting setting = await service.GetConfigurationSettingAsync(s_testSetting.Key);

            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Get, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?api-version={s_version}", request.Uri.ToString());
            Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(s_testSetting, setting));
        }

        [Test]
        public async Task GetWithLabel()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            ConfigurationSetting setting = await service.GetConfigurationSettingAsync(s_testSetting.Key, s_testSetting.Label);
            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Get, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?label=test_label&api-version={s_version}", request.Uri.ToString());
            Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(s_testSetting, setting));
        }

        [Test]
        public void GetNotFound()
        {
            var response = new MockResponse(404);
            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.GetConfigurationSettingAsync(key: s_testSetting.Key);
            });

            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        public async Task GetIfChangedModified()
        {
            var requestSetting = s_testSetting.Clone();
            requestSetting.ETag = new ETag("v1");

            var responseSetting = s_testSetting.Clone();
            responseSetting.ETag = new ETag("v2");

            var mockResponse = new MockResponse(200);
            mockResponse.SetContent(SerializationHelpers.Serialize(responseSetting, SerializeSetting));

            var mockTransport = new MockTransport(mockResponse);
            ConfigurationClient service = CreateTestService(mockTransport);

            Response<ConfigurationSetting> response = await service.GetConfigurationSettingAsync(requestSetting, onlyIfChanged: true);

            // TODO: Should this be response.Status?
            Assert.AreEqual(200, response.GetRawResponse().Status);
            ConfigurationSetting setting = new ConfigurationSetting();
            Assert.DoesNotThrow(() => { setting = response; });

            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Get, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?label=test_label&api-version={s_version}", request.Uri.ToString());
            Assert.True(request.Headers.TryGetValue("If-None-Match", out var ifNoneMatch));
            Assert.AreEqual("\"v1\"", ifNoneMatch);
            Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(responseSetting, setting));
        }

        [Test]
        public async Task GetIfChangedUnmodified()
        {
            var requestSetting = s_testSetting.Clone();
            requestSetting.ETag = new ETag("v1");

            var mockTransport = new MockTransport(new MockResponse(304));
            ConfigurationClient service = CreateTestService(mockTransport);

            Response<ConfigurationSetting> response = await service.GetConfigurationSettingAsync(requestSetting, onlyIfChanged: true);

            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Get, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?label=test_label&api-version={s_version}", request.Uri.ToString());
            Assert.True(request.Headers.TryGetValue("If-None-Match", out var ifNoneMatch));
            Assert.AreEqual("\"v1\"", ifNoneMatch);
            Assert.AreEqual(304, response.GetRawResponse().Status);
            bool throws = false;
            try
            {
                ConfigurationSetting setting = response.Value;
            }
            catch
            {
                throws = true;
            }

            Assert.True(throws);
        }

        [Test]
        public async Task GetWithAcceptDateTime()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(mockResponse);
            ConfigurationClient service = CreateTestService(mockTransport);

            Response<ConfigurationSetting> response = await service.GetConfigurationSettingAsync(s_testSetting, DateTimeOffset.MaxValue);

            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Get, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?label=test_label&api-version={s_version}", request.Uri.ToString());
            Assert.True(request.Headers.TryGetValue("Accept-Datetime", out var acceptDateTime));
            Assert.AreEqual(DateTimeOffset.MaxValue.UtcDateTime.ToString("R", CultureInfo.InvariantCulture), acceptDateTime);
            Assert.False(request.Headers.TryGetValue("If-Match", out var ifMatch));
            Assert.False(request.Headers.TryGetValue("If-None-Match", out var ifNoneMatch));
        }

        [Test]
        public async Task Add()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            ConfigurationSetting setting = await service.AddConfigurationSettingAsync(s_testSetting);
            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Put, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?label=test_label&api-version={s_version}", request.Uri.ToString());
            Assert.True(request.Headers.TryGetValue("If-None-Match", out var ifNoneMatch));
            Assert.AreEqual("*", ifNoneMatch);
            AssertContent(SerializationHelpers.Serialize(s_testSetting, SerializeRequestSetting), request);
            Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(s_testSetting, setting));
        }

        [Test]
        public void AddAlreadyExists()
        {
            var response = new MockResponse(412);

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                ConfigurationSetting setting = await service.AddConfigurationSettingAsync(s_testSetting);
            });
            Assert.AreEqual(412, exception.Status);
        }

        [Test]
        public async Task Set()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            ConfigurationSetting setting = await service.SetConfigurationSettingAsync(s_testSetting);
            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Put, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?label=test_label&api-version={s_version}", request.Uri.ToString());
            AssertContent(SerializationHelpers.Serialize(s_testSetting, SerializeRequestSetting), request);
            Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(s_testSetting, setting));
        }

        [Test]
        public void SetReadOnlySetting()
        {
            var response = new MockResponse(409);

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                ConfigurationSetting setting = await service.SetConfigurationSettingAsync(s_testSetting);
            });
            Assert.AreEqual(409, exception.Status);
        }

        [Test]
        public async Task SetIfUnchangedUnmodified()
        {
            var requestSetting = s_testSetting.Clone();
            requestSetting.ETag = new ETag("v1");

            var responseSetting = s_testSetting.Clone();
            responseSetting.ETag = new ETag("v1");

            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(responseSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            ConfigurationSetting setting = await service.SetConfigurationSettingAsync(requestSetting, onlyIfUnchanged: true);
            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Put, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?label=test_label&api-version={s_version}", request.Uri.ToString());
            Assert.True(request.Headers.TryGetValue("If-Match", out var ifMatch));
            Assert.AreEqual("\"v1\"", ifMatch);
            AssertContent(SerializationHelpers.Serialize(requestSetting, SerializeRequestSetting), request);
            Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(responseSetting, setting));
        }

        [Test]
        public void SetIfUnchangedModified()
        {
            var requestSetting = s_testSetting.Clone();
            requestSetting.ETag = new ETag("v1");

            var responseSetting = s_testSetting.Clone();
            responseSetting.ETag = new ETag("v2");

            var mockResponse = new MockResponse(412);
            mockResponse.SetContent(SerializationHelpers.Serialize(responseSetting, SerializeSetting));

            var mockTransport = new MockTransport(mockResponse);
            ConfigurationClient service = CreateTestService(mockTransport);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                Response<ConfigurationSetting> response = await service.SetConfigurationSettingAsync(requestSetting, onlyIfUnchanged: true);
            });
            Assert.AreEqual(412, exception.Status);

            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Put, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?label=test_label&api-version={s_version}", request.Uri.ToString());
            Assert.True(request.Headers.TryGetValue("If-Match", out var ifMatch));
            Assert.AreEqual("\"v1\"", ifMatch);
        }

        [Test]
        public async Task Delete()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            await service.DeleteConfigurationSettingAsync(s_testSetting.Key);
            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Delete, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?api-version={s_version}", request.Uri.ToString());
        }

        [Test]
        public async Task DeleteWithLabel()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            await service.DeleteConfigurationSettingAsync(s_testSetting.Key, s_testSetting.Label);
            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Delete, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?label=test_label&api-version={s_version}", request.Uri.ToString());
        }

        [Test]
        public void DeleteNotFound()
        {
            var response = new MockResponse(404);
            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.DeleteConfigurationSettingAsync(s_testSetting.Key);
            });

            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        public void DeleteReadOnlySetting()
        {
            var mockTransport = new MockTransport(new MockResponse(409));
            ConfigurationClient service = CreateTestService(mockTransport);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                Response response = await service.DeleteConfigurationSettingAsync(s_testSetting);
            });
            Assert.AreEqual(409, exception.Status);
        }

        [Test]
        public async Task DeleteIfUnchangedUnmodified()
        {
            var requestSetting = s_testSetting.Clone();
            requestSetting.ETag = new ETag("v1");

            var responseSetting = s_testSetting.Clone();
            responseSetting.ETag = new ETag("v1");

            var mockResponse = new MockResponse(200);
            mockResponse.SetContent(SerializationHelpers.Serialize(responseSetting, SerializeSetting));

            var mockTransport = new MockTransport(mockResponse);
            ConfigurationClient service = CreateTestService(mockTransport);

            Response response = await service.DeleteConfigurationSettingAsync(requestSetting, onlyIfUnchanged: true);
            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Delete, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?label=test_label&api-version={s_version}", request.Uri.ToString());
            Assert.True(request.Headers.TryGetValue("If-Match", out var ifMatch));
            Assert.AreEqual("\"v1\"", ifMatch);
            Assert.AreEqual(200, response.Status);
        }

        [Test]
        public void DeleteIfUnchangedModified()
        {
            var requestSetting = s_testSetting.Clone();
            requestSetting.ETag = new ETag("v1");

            var responseSetting = s_testSetting.Clone();
            responseSetting.ETag = new ETag("v2");

            var mockResponse = new MockResponse(412);
            mockResponse.SetContent(SerializationHelpers.Serialize(responseSetting, SerializeSetting));

            var mockTransport = new MockTransport(mockResponse);
            ConfigurationClient service = CreateTestService(mockTransport);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                Response response = await service.DeleteConfigurationSettingAsync(requestSetting, onlyIfUnchanged: true);
            });
            Assert.AreEqual(412, exception.Status);

            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Delete, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?label=test_label&api-version={s_version}", request.Uri.ToString());
            Assert.True(request.Headers.TryGetValue("If-Match", out var ifMatch));
            Assert.AreEqual("\"v1\"", ifMatch);
        }

        [Test]
        public async Task GetBatch()
        {
            var response1 = new MockResponse(200);
            response1.SetContent(SerializationHelpers.Serialize(new[]
            {
                CreateSetting(0),
                CreateSetting(1),
            }, SerializeBatch));
            response1.AddHeader(new HttpHeader("Link", $"</kv?after=5>;rel=\"next\""));

            var response2 = new MockResponse(200);
            response2.SetContent(SerializationHelpers.Serialize(new[]
            {
                CreateSetting(2),
                CreateSetting(3),
                CreateSetting(4),
            }, SerializeBatch));

            var mockTransport = new MockTransport(response1, response2);
            ConfigurationClient service = CreateTestService(mockTransport);

            var query = new SettingSelector();
            int keyIndex = 0;

            await foreach (ConfigurationSetting value in service.GetConfigurationSettingsAsync(query, CancellationToken.None))
            {
                Assert.AreEqual("key" + keyIndex, value.Key);
                keyIndex++;
            }

            Assert.AreEqual(2, mockTransport.Requests.Count);

            MockRequest request1 = mockTransport.Requests[0];
            Assert.AreEqual(RequestMethod.Get, request1.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv/?api-version={s_version}", request1.Uri.ToString());
            AssertRequestCommon(request1);

            MockRequest request2 = mockTransport.Requests[1];
            Assert.AreEqual(RequestMethod.Get, request2.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv/?after=5&api-version={s_version}", request2.Uri.ToString());
            AssertRequestCommon(request1);
        }

        [Test]
        public async Task ConfiguringTheClient()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(new MockResponse(503), response);

            var options = new ConfigurationClientOptions();
            options.Diagnostics.ApplicationId = "test_application";
            options.Transport = mockTransport;

            ConfigurationClient client = CreateClient<ConfigurationClient>(s_connectionString, options);

            ConfigurationSetting setting = await client.GetConfigurationSettingAsync(s_testSetting.Key);
            Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(s_testSetting, setting));
            Assert.AreEqual(2, mockTransport.Requests.Count);
        }

        [Test]
        public async Task RequestHasApiVersionQuery()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            ConfigurationSetting setting = await service.AddConfigurationSettingAsync(s_testSetting);
            MockRequest request = mockTransport.SingleRequest;

            StringAssert.Contains("api-version", request.Uri.ToUri().ToString());
        }

        [Test]
        public async Task RequestHasSpecificApiVersion()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            var options = new ConfigurationClientOptions(ConfigurationClientOptions.ServiceVersion.V1_0);
            options.Diagnostics.ApplicationId = "test_application";
            options.Transport = mockTransport;

            ConfigurationClient client = CreateClient<ConfigurationClient>(s_connectionString, options);

            ConfigurationSetting setting = await client.AddConfigurationSettingAsync(s_testSetting);
            MockRequest request = mockTransport.SingleRequest;

            StringAssert.Contains("api-version=1.0", request.Uri.ToUri().ToString());
        }

        [Test]
        public async Task RequestHasSpecificApiVersionOnlyOnceOnRetry()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(new MockResponse(503), response);
            var options = new ConfigurationClientOptions(ConfigurationClientOptions.ServiceVersion.V1_0);
            options.Diagnostics.ApplicationId = "test_application";
            options.Transport = mockTransport;

            ConfigurationClient client = CreateClient<ConfigurationClient>(s_connectionString, options);

            await client.AddConfigurationSettingAsync(s_testSetting);
            MockRequest request = mockTransport.Requests[0];
            MockRequest retriedRequest = mockTransport.Requests[1];

            const string expectedApiString = "api-version=1.0";
            StringAssert.Contains(expectedApiString, request.Uri.Query);
            StringAssert.Contains(expectedApiString, retriedRequest.Uri.Query);

            var apiStringFirstIndex = retriedRequest.Uri.Query.IndexOf(expectedApiString, StringComparison.Ordinal);
            var apiStringLastIndex = retriedRequest.Uri.Query.LastIndexOf(expectedApiString, StringComparison.Ordinal);
            Assert.AreEqual(apiStringFirstIndex, apiStringLastIndex);
        }

        [Test]
        public async Task AuthorizationHeaderFormat()
        {
            var expectedSyntax = $"HMAC-SHA256 Credential={s_credential}&SignedHeaders=date;host;x-ms-content-sha256&Signature=(.+)";

            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            ConfigurationSetting setting = await service.AddConfigurationSettingAsync(s_testSetting);
            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.True(request.Headers.TryGetValue("Authorization", out var authHeader));

            Assert.True(Regex.IsMatch(authHeader, expectedSyntax));
        }

        [Test]
        public async Task SetReadOnly()
        {
            var response = new MockResponse(200);
            var testSetting = new ConfigurationSetting("test_key", "test_value")
            {
                Label = "test_label",
                ContentType = "test_content_type",
                Tags = new Dictionary<string, string>
                {
                    { "tag1", "value1" },
                    { "tag2", "value2" }
                },
                IsReadOnly = true
            };
            response.SetContent(SerializationHelpers.Serialize(testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            ConfigurationSetting setting = await service.SetReadOnlyAsync(testSetting.Key, true);
            var request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Put, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/locks/test_key?api-version={s_version}", request.Uri.ToString());
            Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting));
        }

        [Test]
        public async Task SetReadOnlyWithLabel()
        {
            var response = new MockResponse(200);
            var testSetting = new ConfigurationSetting("test_key", "test_value")
            {
                Label = "test_label",
                ContentType = "test_content_type",
                Tags = new Dictionary<string, string>
                {
                    { "tag1", "value1" },
                    { "tag2", "value2" }
                },
                IsReadOnly = true
            };
            response.SetContent(SerializationHelpers.Serialize(testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            ConfigurationSetting setting = await service.SetReadOnlyAsync(testSetting.Key, testSetting.Label, true);
            var request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Put, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/locks/test_key?label=test_label&api-version={s_version}", request.Uri.ToString());
            Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting));
        }

        [Test]
        public void SetReadOnlyNotFound()
        {
            var response = new MockResponse(404);
            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.SetReadOnlyAsync(s_testSetting.Key, true);
            });

            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        public async Task ClearReadOnly()
        {
            var response = new MockResponse(200);
            var testSetting = new ConfigurationSetting("test_key", "test_value")
            {
                Label = "test_label",
                ContentType = "test_content_type",
                Tags = new Dictionary<string, string>
                {
                    { "tag1", "value1" },
                    { "tag2", "value2" }
                },
                IsReadOnly = false
            };
            response.SetContent(SerializationHelpers.Serialize(testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            ConfigurationSetting setting = await service.SetReadOnlyAsync(testSetting.Key, false);
            var request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Delete, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/locks/test_key?api-version={s_version}", request.Uri.ToString());
            Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting));
        }

        [Test]
        public async Task ClearReadOnlyWithLabel()
        {
            var response = new MockResponse(200);
            var testSetting = new ConfigurationSetting("test_key", "test_value")
            {
                Label = "test_label",
                ContentType = "test_content_type",
                Tags = new Dictionary<string, string>
                {
                    { "tag1", "value1" },
                    { "tag2", "value2" }
                },
                IsReadOnly = false
            };
            response.SetContent(SerializationHelpers.Serialize(testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            ConfigurationSetting setting = await service.SetReadOnlyAsync(testSetting.Key, testSetting.Label, false);
            var request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Delete, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/locks/test_key?label=test_label&api-version={s_version}", request.Uri.ToString());
            Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting));
        }

        [Test]
        public void ClearReadOnlyNotFound()
        {
            var response = new MockResponse(404);
            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.SetReadOnlyAsync(s_testSetting.Key, false);
            });

            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        public async Task CustomHeadersAreAdded()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            var activity = new Activity("Azure.CustomDiagnosticHeaders");

            activity.Start();
            activity.AddTag("x-ms-client-request-id", "CustomRequestId");
            activity.AddTag("x-ms-correlation-request-id", "CorrelationRequestId");
            activity.AddTag("correlation-context", "CorrelationContextValue1,CorrelationContextValue2");
            activity.AddTag("x-ms-random-id", "RandomValue");

            ConfigurationSetting setting = await service.SetConfigurationSettingAsync(s_testSetting);
            activity.Stop();

            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.IsTrue(request.Headers.TryGetValue("x-ms-client-request-id", out string clientRequestId));
            Assert.IsTrue(request.Headers.TryGetValue("x-ms-correlation-request-id", out string correlationRequestId));
            Assert.IsTrue(request.Headers.TryGetValue("correlation-context", out string correlationContext));
            Assert.IsFalse(request.Headers.TryGetValue("x-ms-random-id", out string randomId));

            Assert.AreEqual(clientRequestId, "CustomRequestId");
            Assert.AreEqual(correlationRequestId, "CorrelationRequestId");
            Assert.AreEqual(correlationContext, "CorrelationContextValue1,CorrelationContextValue2");
        }

        [Test]
        public async Task AuthorizationHeadersAddedOnceWithRetries()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(new MockResponse(503), response);
            ConfigurationClient service = CreateTestService(mockTransport);

            await service.GetConfigurationSettingAsync(s_testSetting.Key, s_testSetting.Label);

            var retriedRequest = mockTransport.Requests[1];

            AssertRequestCommon(retriedRequest);
            Assert.True(retriedRequest.Headers.TryGetValues("Date", out var dateHeaders));
            Assert.True(retriedRequest.Headers.TryGetValues("x-ms-content-sha256", out var contentHashHeaders));
            Assert.True(retriedRequest.Headers.TryGetValues("Authorization", out var authorizationHeaders));
            Assert.AreEqual(1, dateHeaders.Count());
            Assert.AreEqual(1, contentHashHeaders.Count());
            Assert.AreEqual(1, authorizationHeaders.Count());
        }

        [Test]
        public async Task CustomHeadersAreAddedOnceWithRetries()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(new MockResponse(503), response);
            ConfigurationClient service = CreateTestService(mockTransport);

            var activity = new Activity("Azure.CustomDiagnosticHeaders");

            activity.Start();
            activity.AddTag("x-ms-client-request-id", "CustomRequestId");
            activity.AddTag("x-ms-correlation-request-id", "CorrelationRequestId");
            activity.AddTag("correlation-context", "CorrelationContextValue1,CorrelationContextValue2");
            activity.AddTag("x-ms-random-id", "RandomValue");

            await service.SetConfigurationSettingAsync(s_testSetting);
            activity.Stop();

            var retriedRequest = mockTransport.Requests[1];

            AssertRequestCommon(retriedRequest);
            Assert.IsTrue(retriedRequest.Headers.TryGetValues("x-ms-client-request-id", out var clientRequestIds));
            Assert.IsTrue(retriedRequest.Headers.TryGetValues("x-ms-correlation-request-id", out var correlationRequestIds));
            Assert.IsTrue(retriedRequest.Headers.TryGetValues("correlation-context", out var correlationContexts));
            Assert.IsFalse(retriedRequest.Headers.TryGetValues("x-ms-random-id", out var randomId));

            Assert.AreEqual(1, clientRequestIds.Count());
            Assert.AreEqual(1, correlationRequestIds.Count());
            Assert.AreEqual(1, correlationContexts.Count());
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
            Assert.True(request.Headers.TryGetValue("User-Agent", out var value));
            Version version = typeof(ConfigurationClient).Assembly.GetName().Version;
            StringAssert.Contains($"azsdk-net-Data.AppConfiguration/{version.Major}.{version.Minor}.{version.Build}", value);
        }

        private static ConfigurationSetting CreateSetting(int i)
        {
            return new ConfigurationSetting($"key{i}", "val") { Label = "label", ETag = new ETag("c3c231fd-39a0-4cb6-3237-4614474b92c1"), ContentType = "text" };
        }

        private void SerializeRequestSetting(ref Utf8JsonWriter json, ConfigurationSetting setting)
        {
            json.WriteStartObject();
            json.WriteString("value", setting.Value);
            json.WriteString("content_type", setting.ContentType);
            if (setting.Tags != null)
            {
                json.WriteStartObject("tags");
                foreach (KeyValuePair<string, string> tag in setting.Tags)
                {
                    json.WriteString(tag.Key, tag.Value);
                }
                json.WriteEndObject();
            }
            if (setting.ETag != default)
                json.WriteString("etag", setting.ETag.ToString());
            if (setting.LastModified.HasValue)
                json.WriteString("last_modified", setting.LastModified.Value.ToString());
            if (setting.IsReadOnly.HasValue)
                json.WriteBoolean("locked", setting.IsReadOnly.Value);
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
                foreach (KeyValuePair<string, string> tag in setting.Tags)
                {
                    json.WriteString(tag.Key, tag.Value);
                }
                json.WriteEndObject();
            }
            if (setting.ETag != default)
                json.WriteString("etag", setting.ETag.ToString());
            if (setting.LastModified.HasValue)
                json.WriteString("last_modified", setting.LastModified.Value.ToString());
            if (setting.IsReadOnly.HasValue)
                json.WriteBoolean("locked", setting.IsReadOnly.Value);
            json.WriteEndObject();
        }

        private void SerializeBatch(ref Utf8JsonWriter json, ConfigurationSetting[] settings)
        {
            json.WriteStartObject();
            json.WriteStartArray("items");
            foreach (ConfigurationSetting item in settings)
            {
                SerializeSetting(ref json, item);
            }
            json.WriteEndArray();
            json.WriteEndObject();
        }
    }
}
