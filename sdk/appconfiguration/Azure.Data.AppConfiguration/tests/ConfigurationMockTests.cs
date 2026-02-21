// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        private static readonly string s_troubleshootingLink = "https://aka.ms/azsdk/net/appconfiguration/troubleshoot";
        private static readonly string s_version = new ConfigurationClientOptions().Version;

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
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?api-version={s_version}&label=test_label", request.Uri.ToString());
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

        // This test validates that the client throws an exception with the expected error message when it receives a
        // non-success status code from the service.
        [TestCase((int)HttpStatusCode.Unauthorized)]
        [TestCase(403)]
        [TestCase((int)HttpStatusCode.NotFound)]
        public void GetUnsucessfulResponse(int statusCode)
        {
            var response = new MockResponse(statusCode);
            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.GetConfigurationSettingAsync(key: s_testSetting.Key);
            });

            Assert.AreEqual(statusCode, exception.Status);

            Assert.True(exception?.Message.Contains(s_troubleshootingLink));
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
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?api-version={s_version}&label=test_label", request.Uri.ToString());
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
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?api-version={s_version}&label=test_label", request.Uri.ToString());
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
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?api-version={s_version}&label=test_label", request.Uri.ToString());
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
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?api-version={s_version}&label=test_label", request.Uri.ToString());
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
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?api-version={s_version}&label=test_label", request.Uri.ToString());
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
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?api-version={s_version}&label=test_label", request.Uri.ToString());
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
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?api-version={s_version}&label=test_label", request.Uri.ToString());
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
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?api-version={s_version}&label=test_label", request.Uri.ToString());
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
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?api-version={s_version}&label=test_label", request.Uri.ToString());
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
            Assert.AreEqual($"https://contoso.appconfig.io/kv/test_key?api-version={s_version}&label=test_label", request.Uri.ToString());
            Assert.True(request.Headers.TryGetValue("If-Match", out var ifMatch));
            Assert.AreEqual("\"v1\"", ifMatch);
        }

        [Test]
        public async Task GetBatch()
        {
            var response1 = new MockResponse(200);
            var response1Settings = new[]
            {
                CreateSetting(0),
                CreateSetting(1)
            };
            response1.SetContent(SerializationHelpers.Serialize((Settings: response1Settings, NextLink: $"/kv?after=5&api-version={s_version}"), SerializeBatch));

            var response2 = new MockResponse(200);
            var response2Settings = new[]
            {
                CreateSetting(2),
                CreateSetting(3),
                CreateSetting(4),
            };
            response2.SetContent(SerializationHelpers.Serialize((Settings: response2Settings, NextLink: (string)null), SerializeBatch));

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
            Assert.AreEqual($"https://contoso.appconfig.io/kv?api-version={s_version}", request1.Uri.ToString());
            AssertRequestCommon(request1);

            MockRequest request2 = mockTransport.Requests[1];
            Assert.AreEqual(RequestMethod.Get, request2.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv?after=5&api-version={s_version}", request2.Uri.ToString());
            AssertRequestCommon(request1);
        }

        [Test]
        public async Task GetBatchUsingTags()
        {
            var response1 = new MockResponse(200);
            var mockTags = new Dictionary<string, string>
            {
                { "tag1", "value1" },
                { "tag2", "value2" }
            };
            var response1Settings = new[]
            {
                CreateSetting(0, mockTags),
                CreateSetting(1, mockTags)
            };
            response1.SetContent(SerializationHelpers.Serialize((Settings: response1Settings, NextLink: $"/kv?after=5&api-version={s_version}"), SerializeBatch));

            var response2 = new MockResponse(200);
            var response2Settings = new[]
            {
                CreateSetting(2, mockTags),
                CreateSetting(3, mockTags),
                CreateSetting(4, mockTags),
            };
            response2.SetContent(SerializationHelpers.Serialize((Settings: response2Settings, NextLink: (string)null), SerializeBatch));

            var mockTransport = new MockTransport(response1, response2);
            ConfigurationClient service = CreateTestService(mockTransport);

            var parsedTags = mockTags.Select(t => $"{t.Key}={t.Value}").ToList();
            var query = new SettingSelector();
            foreach (var tag in mockTags)
            {
                query.TagsFilter.Add($"{tag.Key}={tag.Value}");
            }
            int keyIndex = 0;

            await foreach (ConfigurationSetting value in service.GetConfigurationSettingsAsync(query, CancellationToken.None))
            {
                Assert.AreEqual("key" + keyIndex, value.Key);
                Assert.AreEqual(mockTags, value.Tags);
                keyIndex++;
            }

            Assert.AreEqual(2, mockTransport.Requests.Count);

            MockRequest request1 = mockTransport.Requests[0];
            var expectedTagsQuery = string.Join("&tags=", parsedTags.Select(Uri.EscapeDataString));
            Assert.AreEqual(RequestMethod.Get, request1.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv?api-version={s_version}&tags={expectedTagsQuery}", request1.Uri.ToString());
            AssertRequestCommon(request1);

            MockRequest request2 = mockTransport.Requests[1];
            Assert.AreEqual(RequestMethod.Get, request2.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv?after=5&api-version={s_version}", request2.Uri.ToString());
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
            Assert.AreEqual($"https://contoso.appconfig.io/locks/test_key?api-version={s_version}&label=test_label", request.Uri.ToString());
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
            Assert.AreEqual($"https://contoso.appconfig.io/locks/test_key?api-version={s_version}&label=test_label", request.Uri.ToString());
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
        public async Task GetLabels()
        {
            var response1 = new MockResponse(200);
            var response1Labels = new[]
            {
                CreateLabel(0),
                CreateLabel(1)
            };
            response1.SetContent(SerializationHelpers.Serialize((Items: response1Labels, NextLink: $"/labels?after=5&api-version={s_version}"), SerializeLabels));

            var response2 = new MockResponse(200);
            var response2Labels = new[]
            {
                CreateLabel(2),
                CreateLabel(3),
                CreateLabel(4),
            };
            response2.SetContent(SerializationHelpers.Serialize((Settings: response2Labels, NextLink: (string)null), SerializeLabels));

            var mockTransport = new MockTransport(response1, response2);
            ConfigurationClient service = CreateTestService(mockTransport);

            var query = new SettingLabelSelector();
            int keyIndex = 0;

            await foreach (SettingLabel label in service.GetLabelsAsync(query, CancellationToken.None))
            {
                Assert.AreEqual("label" + keyIndex, label.Name);
                keyIndex++;
            }

            Assert.AreEqual(2, mockTransport.Requests.Count);

            MockRequest request1 = mockTransport.Requests[0];
            Assert.AreEqual(RequestMethod.Get, request1.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/labels?api-version={s_version}", request1.Uri.ToString());
            AssertRequestCommon(request1);

            MockRequest request2 = mockTransport.Requests[1];
            Assert.AreEqual(RequestMethod.Get, request2.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/labels?after=5&api-version={s_version}", request2.Uri.ToString());
            AssertRequestCommon(request1);
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

        [Test]
        public async Task ExternalSyncTokenIsSentWithRequest()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            service.UpdateSyncToken("syncToken1=val1;sn=1");
            await service.GetConfigurationSettingAsync(s_testSetting.Key, s_testSetting.Label);

            var request = mockTransport.Requests[0];

            AssertRequestCommon(request);
            Assert.True(request.Headers.TryGetValue("Sync-Token", out var syncToken));
            Assert.AreEqual("syncToken1=val1", syncToken);
        }

        [Test]
        public async Task ExternalSyncTokensFollowRulesWhenAdded()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testSetting, SerializeSetting));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            service.UpdateSyncToken("syncToken1=val1;sn=1");
            service.UpdateSyncToken("syncToken1=val2;sn=2,syncToken2=val3;sn=2");
            service.UpdateSyncToken("syncToken2=val1;sn=1");
            await service.GetConfigurationSettingAsync(s_testSetting.Key, s_testSetting.Label);

            var request = mockTransport.Requests[0];

            AssertRequestCommon(request);
            Assert.True(request.Headers.TryGetValues("Sync-Token", out var syncTokens));
            CollectionAssert.Contains(syncTokens, "syncToken2=val3");
            CollectionAssert.Contains(syncTokens, "syncToken1=val2");
        }

        [Test]
        public async Task VerifyNullClientFilter()
        {
            var response = new MockResponse(200);
            response.SetContent("{\"key\":\".appconfig.featureflag/flagtest\",\"content_type\":\"application/vnd.microsoft.appconfig.ff+json;charset=utf-8\",\"value\":\"{\\\"id\\\":\\\"feature 1829697669\\\",\\\"enabled\\\":true,\\\"conditions\\\":{\\\"client_filters\\\":null}}\"}");

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            var setting = await service.GetConfigurationSettingAsync(".appconfig.featureflag/flagtest");
            var feature = (FeatureFlagConfigurationSetting)setting.Value;
            Assert.IsEmpty(feature.ClientFilters);
        }

        [Test]
        public async Task QueryParametersAreSorted()
        {
            var response1 = new MockResponse(200);
            var mockTags = new Dictionary<string, string>
            {
                { "tag2", "value2" },
                { "tag1", "value1" }
            };
            ConfigurationSetting testSetting = CreateSetting(0, mockTags);
            response1.SetContent(SerializationHelpers.Serialize((Settings: new[] { testSetting }, NextLink: $"/kv?key=key%2A&label=label&tags=tag2%3Dvalue2&tags=tag1%3Dvalue1&after=test_after&api-version={s_version}"), SerializeBatch));

            var response2 = new MockResponse(200);
            var testSetting2 = CreateSetting(1, mockTags);
            response2.SetContent(SerializationHelpers.Serialize((Settings: new[] { testSetting2 }, NextLink: (string)null), SerializeBatch));

            var mockTransport = new MockTransport(response1, response2);
            ConfigurationClient service = CreateTestService(mockTransport);

            var query = new SettingSelector
            {
                KeyFilter = "key*",
                LabelFilter = "label"
            };
            foreach (var tag in mockTags)
            {
                query.TagsFilter.Add($"{tag.Key}={tag.Value}");
            }

            await foreach (ConfigurationSetting value in service.GetConfigurationSettingsAsync(query, CancellationToken.None))
            {
                continue;
            }

            Assert.AreEqual(2, mockTransport.Requests.Count);

            // Verify the first request has sorted query parameters (lowercase, alphabetically ordered)
            MockRequest request1 = mockTransport.Requests[0];
            var expectedUri1 = $"https://contoso.appconfig.io/kv?api-version={s_version}&key=key%2A&label=label&tags=tag2%3Dvalue2&tags=tag1%3Dvalue1";
            Assert.AreEqual(expectedUri1, request1.Uri.ToString());

            // Verify the next link request has sorted query parameters including "after"
            MockRequest request2 = mockTransport.Requests[1];
            var expectedUri2 = $"https://contoso.appconfig.io/kv?after=test_after&api-version={s_version}&key=key%2A&label=label&tags=tag2%3Dvalue2&tags=tag1%3Dvalue1";
            Assert.AreEqual(expectedUri2, request2.Uri.ToString());
        }

        [Test]
        public async Task GetSnapshot()
        {
            var mockResponse = new MockResponse(200);
            // Minimal snapshot payload; we only validate the request URI
            mockResponse.SetContent("{\"name\":\"test-snapshot\"}");

            var mockTransport = new MockTransport(mockResponse);
            ConfigurationClient service = CreateTestService(mockTransport);

            await service.GetSnapshotAsync("test-snapshot");

            MockRequest request = mockTransport.SingleRequest;
            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Get, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/snapshots/test-snapshot?api-version={s_version}", request.Uri.ToString());
        }

        [Test]
        public async Task GetConfigurationSettingsForSnapshot()
        {
            var mockResponse = new MockResponse(200);
            // Reuse existing batch serialization helper for key-values
            var settings = new[] { s_testSetting };
            mockResponse.SetContent(SerializationHelpers.Serialize((Settings: settings, NextLink: (string)null), SerializeBatch));

            var mockTransport = new MockTransport(mockResponse);
            ConfigurationClient service = CreateTestService(mockTransport);

            await foreach (ConfigurationSetting setting in service.GetConfigurationSettingsForSnapshotAsync("test-snapshot", CancellationToken.None))
            {
                break;
            }

            MockRequest request = mockTransport.SingleRequest;
            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Get, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/kv?api-version={s_version}&snapshot=test-snapshot", request.Uri.ToString());
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

        private static ConfigurationSetting CreateSetting(int i, IDictionary<string, string> tags = null)
        {
            if (tags != null)
            {
                return new ConfigurationSetting($"key{i}", "val") { Label = "label", ETag = new ETag("c3c231fd-39a0-4cb6-3237-4614474b92c1"), ContentType = "text", Tags = tags };
            }

            return new ConfigurationSetting($"key{i}", "val") { Label = "label", ETag = new ETag("c3c231fd-39a0-4cb6-3237-4614474b92c1"), ContentType = "text" };
        }

        private static SettingLabel CreateLabel(int i)
        {
            return new SettingLabel($"label{i}");
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

        private void SerializeBatch(ref Utf8JsonWriter json, (ConfigurationSetting[] Settings, string NextLink) content)
        {
            json.WriteStartObject();
            if (content.NextLink != null)
            {
                json.WriteString("@nextLink", content.NextLink);
            }
            json.WriteStartArray("items");
            foreach (ConfigurationSetting item in content.Settings)
            {
                SerializeSetting(ref json, item);
            }
            json.WriteEndArray();
            json.WriteEndObject();
        }

        private static void SerializeLabel(ref Utf8JsonWriter json, SettingLabel label)
        {
            json.WriteStartObject();
            json.WritePropertyName("name"u8);
            json.WriteStringValue(label.Name);
            json.WriteEndObject();
        }

        private void SerializeLabels(ref Utf8JsonWriter json, (SettingLabel[] Labels, string NextLink) content)
        {
            json.WriteStartObject();
            if (content.NextLink != null)
            {
                json.WriteString("@nextLink", content.NextLink);
            }
            json.WriteStartArray("items");
            foreach (SettingLabel label in content.Labels)
            {
                ConfigurationMockTests.SerializeLabel(ref json, label);
            }
            json.WriteEndArray();
            json.WriteEndObject();
        }

        private class EchoHttpMessageHandler : HttpMessageHandler
        {
            private readonly string _expectedContent;

            public EchoHttpMessageHandler(string expectedJsonContent)
            {
                _expectedContent = expectedJsonContent;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(_expectedContent, Encoding.UTF8, "application/json")
                });
            }
        }
    }
}
