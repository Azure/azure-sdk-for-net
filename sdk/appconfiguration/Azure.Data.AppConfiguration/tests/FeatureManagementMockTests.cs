﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
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
    public class FeatureManagementMockTests : ClientTestBase
    {
        private static readonly string s_endpoint = "https://contoso.appconfig.io";
        private static readonly string s_credential = "b1d9b31";
        private static readonly string s_secret = "aabbccdd";
        private static readonly string s_connectionString = $"Endpoint={s_endpoint};Id={s_credential};Secret={s_secret}";
        private static readonly string s_troubleshootingLink = "https://aka.ms/azsdk/net/appconfiguration/troubleshoot";
        private static readonly string s_version = new ConfigurationClientOptions().Version;

        private static readonly FeatureFlag s_testFlag = ConfigurationModelFactory.FeatureFlag(
            name: "test_flag",
            enabled: true,
            label: "test_label",
            description: "test_description",
            tags: new Dictionary<string, string>
            {
                { "tag1", "value1" },
                { "tag2", "value2" }
            }
        );

        public FeatureManagementMockTests(bool isAsync) : base(isAsync) { }

        private ConfigurationClient CreateTestService(HttpPipelineTransport transport)
        {
            var options = new ConfigurationClientOptions
            {
                Transport = transport
            };

            return InstrumentClient(new ConfigurationClient(s_connectionString, options));
        }

        [Test]
        public async Task GetFeatureFlag()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testFlag, SerializeFeatureFlag));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            FeatureFlag flag = await service.GetFeatureFlagAsync(s_testFlag.Name);

            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Get, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/ff/test_flag?api-version={s_version}", request.Uri.ToString());
            Assert.True(FeatureFlagEqualityComparer.Instance.Equals(s_testFlag, flag));
        }

        [Test]
        public async Task GetFeatureFlagWithLabel()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testFlag, SerializeFeatureFlag));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            FeatureFlag flag = await service.GetFeatureFlagAsync(s_testFlag.Name, s_testFlag.Label);
            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Get, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/ff/test_flag?api-version={s_version}&label=test_label", request.Uri.ToString());
            Assert.True(FeatureFlagEqualityComparer.Instance.Equals(s_testFlag, flag));
        }

        [Test]
        public void GetFeatureFlagNotFound()
        {
            var response = new MockResponse(404);
            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.GetFeatureFlagAsync(name: s_testFlag.Name);
            });

            Assert.AreEqual(404, exception.Status);
        }

        // This test validates that the client throws an exception with the expected error message when it receives a
        // non-success status code from the service.
        [TestCase((int)HttpStatusCode.Unauthorized)]
        [TestCase(403)]
        [TestCase((int)HttpStatusCode.NotFound)]
        public void GetFeatureFlagUnsuccessfulResponse(int statusCode)
        {
            var response = new MockResponse(statusCode);
            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.GetFeatureFlagAsync(name: s_testFlag.Name);
            });

            Assert.AreEqual(statusCode, exception.Status);

            Assert.True(exception?.Message.Contains(s_troubleshootingLink));
        }

        [Test]
        public async Task GetFeatureFlagIfChangedModified()
        {
            var requestFlag = s_testFlag.Clone();
            requestFlag.ETag = new ETag("v1");

            var responseFlag = s_testFlag.Clone();
            responseFlag.ETag = new ETag("v2");

            var mockResponse = new MockResponse(200);
            mockResponse.SetContent(SerializationHelpers.Serialize(responseFlag, SerializeFeatureFlag));

            var mockTransport = new MockTransport(mockResponse);
            ConfigurationClient service = CreateTestService(mockTransport);

            Response<FeatureFlag> response = await service.GetFeatureFlagAsync(requestFlag.Name, requestFlag.Label,
                matchConditions: new MatchConditions { IfNoneMatch = requestFlag.ETag });

            Assert.AreEqual(200, response.GetRawResponse().Status);
            FeatureFlag flag = ConfigurationModelFactory.FeatureFlag();
            Assert.DoesNotThrow(() => { flag = response; });

            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Get, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/ff/test_flag?api-version={s_version}&label=test_label", request.Uri.ToString());
            Assert.True(request.Headers.TryGetValue("If-None-Match", out var ifNoneMatch));
            Assert.AreEqual("\"v1\"", ifNoneMatch);
            Assert.True(FeatureFlagEqualityComparer.Instance.Equals(responseFlag, flag));
        }

        [Test]
        public async Task GetFeatureFlagIfChangedUnmodified()
        {
            var requestFlag = s_testFlag.Clone();
            requestFlag.ETag = new ETag("v1");

            var mockTransport = new MockTransport(new MockResponse(304));
            ConfigurationClient service = CreateTestService(mockTransport);

            Response<FeatureFlag> response = await service.GetFeatureFlagAsync(requestFlag.Name, requestFlag.Label,
                matchConditions: new MatchConditions { IfNoneMatch = requestFlag.ETag });

            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Get, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/ff/test_flag?api-version={s_version}&label=test_label", request.Uri.ToString());
            Assert.True(request.Headers.TryGetValue("If-None-Match", out var ifNoneMatch));
            Assert.AreEqual("\"v1\"", ifNoneMatch);
            Assert.AreEqual(304, response.GetRawResponse().Status);
            bool throws = false;
            try
            {
                FeatureFlag flag = response.Value;
            }
            catch
            {
                throws = true;
            }

            Assert.True(throws);
        }

        [Test]
        public async Task GetFeatureFlagWithAcceptDateTime()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.SetContent(SerializationHelpers.Serialize(s_testFlag, SerializeFeatureFlag));

            var mockTransport = new MockTransport(mockResponse);
            ConfigurationClient service = CreateTestService(mockTransport);

            Response<FeatureFlag> response = await service.GetFeatureFlagAsync(s_testFlag.Name, s_testFlag.Label,
                acceptDatetime: DateTimeOffset.MaxValue.UtcDateTime.ToString("R", CultureInfo.InvariantCulture));

            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Get, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/ff/test_flag?api-version={s_version}&label=test_label", request.Uri.ToString());
            Assert.True(request.Headers.TryGetValue("Accept-Datetime", out var acceptDateTime));
            Assert.AreEqual(DateTimeOffset.MaxValue.UtcDateTime.ToString("R", CultureInfo.InvariantCulture), acceptDateTime);
            Assert.False(request.Headers.TryGetValue("If-Match", out var ifMatch));
            Assert.False(request.Headers.TryGetValue("If-None-Match", out var ifNoneMatch));
        }

        [Test]
        public async Task PutFeatureFlag()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testFlag, SerializeFeatureFlag));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            FeatureFlag flag = await service.PutFeatureFlagAsync(s_testFlag.Name, s_testFlag, s_testFlag.Label);
            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Put, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/ff/test_flag?api-version={s_version}&label=test_label", request.Uri.ToString());
            AssertContent(ModelReaderWriter.Write(s_testFlag, ModelSerializationExtensions.WireOptions).ToArray(), request);
            Assert.True(FeatureFlagEqualityComparer.Instance.Equals(s_testFlag, flag));
        }

        [Test]
        public void PutFeatureFlagAlreadyExists()
        {
            var response = new MockResponse(412);

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                FeatureFlag flag = await service.PutFeatureFlagAsync(s_testFlag.Name, s_testFlag, s_testFlag.Label,
                    matchConditions: new MatchConditions { IfNoneMatch = ETag.All });
            });
            Assert.AreEqual(412, exception.Status);
        }

        [Test]
        public void PutFeatureFlagReadOnlyFlagError()
        {
            var response = new MockResponse(409);

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                FeatureFlag flag = await service.PutFeatureFlagAsync(s_testFlag.Name, s_testFlag, s_testFlag.Label);
            });
            Assert.AreEqual(409, exception.Status);
        }

        [Test]
        public async Task PutFeatureFlagIfUnchangedUnmodified()
        {
            var requestFlag = s_testFlag.Clone();
            requestFlag.ETag = new ETag("v1");

            var responseFlag = s_testFlag.Clone();
            responseFlag.ETag = new ETag("v1");

            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(responseFlag, SerializeFeatureFlag));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            FeatureFlag flag = await service.PutFeatureFlagAsync(requestFlag.Name, requestFlag, requestFlag.Label,
                matchConditions: new MatchConditions { IfMatch = requestFlag.ETag });
            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Put, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/ff/test_flag?api-version={s_version}&label=test_label", request.Uri.ToString());
            Assert.True(request.Headers.TryGetValue("If-Match", out var ifMatch));
            Assert.AreEqual("\"v1\"", ifMatch);
            AssertContent(SerializationHelpers.Serialize(requestFlag, SerializeRequestFeatureFlag), request);
            Assert.True(FeatureFlagEqualityComparer.Instance.Equals(responseFlag, flag));
        }

        [Test]
        public void PutFeatureFlagIfUnchangedModified()
        {
            var requestFlag = s_testFlag.Clone();
            requestFlag.ETag = new ETag("v1");

            var responseFlag = s_testFlag.Clone();
            responseFlag.ETag = new ETag("v2");

            var mockResponse = new MockResponse(412);
            mockResponse.SetContent(SerializationHelpers.Serialize(responseFlag, SerializeFeatureFlag));

            var mockTransport = new MockTransport(mockResponse);
            ConfigurationClient service = CreateTestService(mockTransport);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                Response<FeatureFlag> response = await service.PutFeatureFlagAsync(requestFlag.Name, requestFlag, requestFlag.Label,
                    matchConditions: new MatchConditions { IfMatch = requestFlag.ETag });
            });
            Assert.AreEqual(412, exception.Status);

            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Put, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/ff/test_flag?api-version={s_version}&label=test_label", request.Uri.ToString());
            Assert.True(request.Headers.TryGetValue("If-Match", out var ifMatch));
            Assert.AreEqual("\"v1\"", ifMatch);
        }

        [Test]
        public async Task DeleteFeatureFlag()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testFlag, SerializeFeatureFlag));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            await service.DeleteFeatureFlagAsync(s_testFlag.Name);
            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Delete, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/ff/test_flag?api-version={s_version}", request.Uri.ToString());
        }

        [Test]
        public async Task DeleteFeatureFlagWithLabel()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testFlag, SerializeFeatureFlag));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            await service.DeleteFeatureFlagAsync(s_testFlag.Name, s_testFlag.Label);
            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Delete, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/ff/test_flag?api-version={s_version}&label=test_label", request.Uri.ToString());
        }

        [Test]
        public void DeleteFeatureFlagNotFound()
        {
            var response = new MockResponse(404);
            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.DeleteFeatureFlagAsync(s_testFlag.Name);
            });

            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        public void DeleteFeatureFlagReadOnlyError()
        {
            var mockTransport = new MockTransport(new MockResponse(409));
            ConfigurationClient service = CreateTestService(mockTransport);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                Response<FeatureFlag> response = await service.DeleteFeatureFlagAsync(s_testFlag.Name, s_testFlag.Label);
            });
            Assert.AreEqual(409, exception.Status);
        }

        [Test]
        public async Task DeleteFeatureFlagIfUnchangedUnmodified()
        {
            var requestFlag = s_testFlag.Clone();
            requestFlag.ETag = new ETag("v1");

            var responseFlag = s_testFlag.Clone();
            responseFlag.ETag = new ETag("v1");

            var mockResponse = new MockResponse(200);
            mockResponse.SetContent(SerializationHelpers.Serialize(responseFlag, SerializeFeatureFlag));

            var mockTransport = new MockTransport(mockResponse);
            ConfigurationClient service = CreateTestService(mockTransport);

            Response<FeatureFlag> response = await service.DeleteFeatureFlagAsync(requestFlag.Name, requestFlag.Label,
                ifMatch: requestFlag.ETag);
            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Delete, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/ff/test_flag?api-version={s_version}&label=test_label", request.Uri.ToString());
            Assert.True(request.Headers.TryGetValue("If-Match", out var ifMatch));
            Assert.AreEqual("\"v1\"", ifMatch);
            Assert.AreEqual(200, response.GetRawResponse().Status);
        }

        [Test]
        public void DeleteFeatureFlagIfUnchangedModified()
        {
            var requestFlag = s_testFlag.Clone();
            requestFlag.ETag = new ETag("v1");

            var responseFlag = s_testFlag.Clone();
            responseFlag.ETag = new ETag("v2");

            var mockResponse = new MockResponse(412);
            mockResponse.SetContent(SerializationHelpers.Serialize(responseFlag, SerializeFeatureFlag));

            var mockTransport = new MockTransport(mockResponse);
            ConfigurationClient service = CreateTestService(mockTransport);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                Response<FeatureFlag> response = await service.DeleteFeatureFlagAsync(requestFlag.Name, requestFlag.Label,
                    ifMatch: requestFlag.ETag);
            });
            Assert.AreEqual(412, exception.Status);

            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Delete, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/ff/test_flag?api-version={s_version}&label=test_label", request.Uri.ToString());
            Assert.True(request.Headers.TryGetValue("If-Match", out var ifMatch));
            Assert.AreEqual("\"v1\"", ifMatch);
        }

        [Test]
        public async Task GetFeatureFlagsBatch()
        {
            var response1 = new MockResponse(200);
            var response1Flags = new[]
            {
                CreateFeatureFlag(0),
                CreateFeatureFlag(1)
            };
            response1.SetContent(SerializationHelpers.Serialize((Flags: response1Flags, NextLink: $"https://contoso.appconfig.io/feature-management/ff?after=5&api-version={s_version}"), SerializeFeatureFlagBatch));

            var response2 = new MockResponse(200);
            var response2Flags = new[]
            {
                CreateFeatureFlag(2),
                CreateFeatureFlag(3),
                CreateFeatureFlag(4),
            };
            response2.SetContent(SerializationHelpers.Serialize((Flags: response2Flags, NextLink: (string)null), SerializeFeatureFlagBatch));

            var mockTransport = new MockTransport(response1, response2);
            ConfigurationClient service = CreateTestService(mockTransport);

            int flagIndex = 0;

            await foreach (FeatureFlag value in service.GetFeatureFlagsAsync())
            {
                Assert.AreEqual("flag" + flagIndex, value.Name);
                flagIndex++;
            }

            Assert.AreEqual(2, mockTransport.Requests.Count);

            MockRequest request1 = mockTransport.Requests[0];
            Assert.AreEqual(RequestMethod.Get, request1.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/ff?api-version={s_version}", request1.Uri.ToString());
            AssertRequestCommon(request1);

            MockRequest request2 = mockTransport.Requests[1];
            Assert.AreEqual(RequestMethod.Get, request2.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/ff?after=5&api-version={s_version}", request2.Uri.ToString());
            AssertRequestCommon(request1);
        }

        [Test]
        public async Task GetFeatureFlagsBatchUsingTags()
        {
            var response1 = new MockResponse(200);
            var mockTags = new Dictionary<string, string>
            {
                { "tag1", "value1" },
                { "tag2", "value2" }
            };
            var response1Flags = new[]
            {
                CreateFeatureFlag(0, mockTags),
                CreateFeatureFlag(1, mockTags)
            };
            response1.SetContent(SerializationHelpers.Serialize((Flags: response1Flags, NextLink: $"https://contoso.appconfig.io/feature-management/ff?after=5&api-version={s_version}"), SerializeFeatureFlagBatch));

            var response2 = new MockResponse(200);
            var response2Flags = new[]
            {
                CreateFeatureFlag(2, mockTags),
                CreateFeatureFlag(3, mockTags),
                CreateFeatureFlag(4, mockTags),
            };
            response2.SetContent(SerializationHelpers.Serialize((Flags: response2Flags, NextLink: (string)null), SerializeFeatureFlagBatch));

            var mockTransport = new MockTransport(response1, response2);
            ConfigurationClient service = CreateTestService(mockTransport);

            var parsedTags = mockTags.Select(t => $"{t.Key}={t.Value}").ToList();
            int flagIndex = 0;

            await foreach (FeatureFlag value in service.GetFeatureFlagsAsync(tags: parsedTags, cancellationToken: CancellationToken.None))
            {
                Assert.AreEqual("flag" + flagIndex, value.Name);
                Assert.AreEqual(mockTags, value.Tags);
                flagIndex++;
            }

            Assert.AreEqual(2, mockTransport.Requests.Count);

            MockRequest request1 = mockTransport.Requests[0];
            var expectedTagsQuery = string.Join("&tags=", parsedTags.Select(Uri.EscapeDataString));
            Assert.AreEqual(RequestMethod.Get, request1.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/ff?api-version={s_version}&tags={expectedTagsQuery}", request1.Uri.ToString());
            AssertRequestCommon(request1);

            MockRequest request2 = mockTransport.Requests[1];
            Assert.AreEqual(RequestMethod.Get, request2.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/ff?after=5&api-version={s_version}", request2.Uri.ToString());
            AssertRequestCommon(request1);
        }

        [Test]
        public async Task FeatureManagementConfigurableClient()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testFlag, SerializeFeatureFlag));

            var mockTransport = new MockTransport(new MockResponse(503), response);

            var options = new ConfigurationClientOptions();
            options.Diagnostics.ApplicationId = "test_application";
            options.Transport = mockTransport;

            FeatureManagement client = CreateClient<ConfigurationClient>(s_connectionString, options).GetFeatureManagementClient();

            FeatureFlag flag = await client.GetFeatureFlagAsync(s_testFlag.Name);
            Assert.True(FeatureFlagEqualityComparer.Instance.Equals(s_testFlag, flag));
            Assert.AreEqual(2, mockTransport.Requests.Count);
        }

        [Test]
        public async Task FeatureManagementHasApiVersionQuery()
        {
            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testFlag, SerializeFeatureFlag));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            FeatureFlag flag = await service.PutFeatureFlagAsync(s_testFlag.Name, s_testFlag, s_testFlag.Label);
            MockRequest request = mockTransport.SingleRequest;

            StringAssert.Contains("api-version", request.Uri.ToUri().ToString());
        }

        [Test]
        public async Task FeatureManagementAuthorizationHeaderFormat()
        {
            var expectedSyntax = $"HMAC-SHA256 Credential={s_credential}&SignedHeaders=date;host;x-ms-content-sha256&Signature=(.+)";

            var response = new MockResponse(200);
            response.SetContent(SerializationHelpers.Serialize(s_testFlag, SerializeFeatureFlag));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            FeatureFlag flag = await service.PutFeatureFlagAsync(s_testFlag.Name, s_testFlag, s_testFlag.Label);
            MockRequest request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.True(request.Headers.TryGetValue("Authorization", out var authHeader));

            Assert.True(Regex.IsMatch(authHeader, expectedSyntax));
        }

        [Test]
        public async Task LockFeatureFlag()
        {
            var response = new MockResponse(200);
            var testFlag = ConfigurationModelFactory.FeatureFlag(
                name: "test_flag",
                enabled: true,
                isReadOnly: true,
                label: "test_label",
                description: "test_description",
                tags: new Dictionary<string, string>
                {
                    { "tag1", "value1" },
                    { "tag2", "value2" }
                }
            );
            response.SetContent(SerializationHelpers.Serialize(testFlag, SerializeFeatureFlag));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            FeatureFlag flag = await service.PutFeatureFlagLockAsync(testFlag.Name, testFlag.Label);
            var request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Put, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/locks/test_flag?api-version={s_version}&label=test_label", request.Uri.ToString());
            Assert.True(FeatureFlagEqualityComparer.Instance.Equals(testFlag, flag));
        }

        [Test]
        public async Task UnlockFeatureFlag()
        {
            var response = new MockResponse(200);
            var testFlag = ConfigurationModelFactory.FeatureFlag(
                name: "test_flag",
                enabled: true,
                isReadOnly: false,
                label: "test_label",
                description: "test_description",
                tags: new Dictionary<string, string>
                {
                    { "tag1", "value1" },
                    { "tag2", "value2" }
                }
            );
            response.SetContent(SerializationHelpers.Serialize(testFlag, SerializeFeatureFlag));

            var mockTransport = new MockTransport(response);
            ConfigurationClient service = CreateTestService(mockTransport);

            FeatureFlag flag = await service.DeleteFeatureFlagLockAsync(testFlag.Name, testFlag.Label);
            var request = mockTransport.SingleRequest;

            AssertRequestCommon(request);
            Assert.AreEqual(RequestMethod.Delete, request.Method);
            Assert.AreEqual($"https://contoso.appconfig.io/feature-management/locks/test_flag?api-version={s_version}&label=test_label", request.Uri.ToString());
            Assert.True(FeatureFlagEqualityComparer.Instance.Equals(testFlag, flag));
        }

        [Test]
        public async Task SupportsCustomTransportUse()
        {
            var expectedKey = "abc";
            var expectedValue = "ghi";
            var expectedLabel = "def";
            var expectedContent = @$"{{""key"":""{expectedKey}"",""label"":""{expectedLabel}"",""value"":""{expectedValue}""}}";

            var client = new ConfigurationClient(
                s_connectionString,
                new ConfigurationClientOptions
                {
                    Transport = new HttpClientTransport(new EchoHttpMessageHandler(expectedContent))
                }
            );

            var result = await client.GetConfigurationSettingAsync("doesnt-matter");
            Assert.AreEqual(expectedKey, result.Value.Key);
            Assert.AreEqual(expectedValue, result.Value.Value);
            Assert.AreEqual(expectedLabel, result.Value.Label);

            var result2 = await client.SetConfigurationSettingAsync("whatever", "somevalue");
            Assert.AreEqual(expectedKey, result.Value.Key);
            Assert.AreEqual(expectedValue, result.Value.Value);
            Assert.AreEqual(expectedLabel, result.Value.Label);
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

        private static FeatureFlag CreateFeatureFlag(int i, IDictionary<string, string> tags = null)
        {
            var flag = ConfigurationModelFactory.FeatureFlag(
                name: $"flag{i}",
                enabled: true,
                label: "label",
                description: "test description",
                eTag: new ETag("c3c231fd-39a0-4cb6-3237-4614474b92c1")
            );

            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    flag.Tags[tag.Key] = tag.Value;
                }
            }

            return flag;
        }

        private static SettingLabel CreateLabel(int i)
        {
            return new SettingLabel($"label{i}");
        }

        private void SerializeRequestFeatureFlag(ref Utf8JsonWriter json, FeatureFlag flag)
        {
            json.WriteStartObject();
            json.WriteString("label", flag.Label);
            json.WriteString("description", flag.Description);
            json.WriteBoolean("enabled", flag.Enabled ?? false);
            if (flag.Tags != null && flag.Tags.Count > 0)
            {
                json.WriteStartObject("tags");
                foreach (KeyValuePair<string, string> tag in flag.Tags)
                {
                    json.WriteString(tag.Key, tag.Value);
                }
                json.WriteEndObject();
            }
            if (flag.IsReadOnly.HasValue)
                json.WriteBoolean("locked", flag.IsReadOnly.Value);
            json.WriteEndObject();
        }

        private void SerializeFeatureFlag(ref Utf8JsonWriter json, FeatureFlag flag)
        {
            json.WriteStartObject();
            json.WriteString("name", flag.Name);
            if (flag.Alias != null)
                json.WriteString("alias", flag.Alias);
            json.WriteString("label", flag.Label);
            json.WriteString("description", flag.Description);
            json.WriteBoolean("enabled", flag.Enabled ?? false);

            if (flag.Conditions != null)
            {
                json.WritePropertyName("conditions");
                ((IJsonModel<FeatureFlagConditions>)flag.Conditions).Write(json, ModelSerializationExtensions.WireOptions);
            }

            if (flag.Variants != null && flag.Variants.Count > 0)
            {
                json.WriteStartArray("variants");
                foreach (var variant in flag.Variants)
                {
                    ((IJsonModel<FeatureFlagVariant>)variant).Write(json, ModelSerializationExtensions.WireOptions);
                }
                json.WriteEndArray();
            }

            if (flag.Allocation != null)
            {
                json.WritePropertyName("allocation");
                ((IJsonModel<FeatureFlagAllocation>)flag.Allocation).Write(json, ModelSerializationExtensions.WireOptions);
            }

            if (flag.Telemetry != null)
            {
                json.WritePropertyName("telemetry");
                ((IJsonModel<FeatureFlagTelemetry>)flag.Telemetry).Write(json, ModelSerializationExtensions.WireOptions);
            }

            if (flag.Tags != null && flag.Tags.Count > 0)
            {
                json.WriteStartObject("tags");
                foreach (KeyValuePair<string, string> tag in flag.Tags)
                {
                    json.WriteString(tag.Key, tag.Value);
                }
                json.WriteEndObject();
            }
            if (flag.ETag != default)
                json.WriteString("etag", flag.ETag.ToString());
            if (flag.LastModified.HasValue)
                json.WriteString("last_modified", flag.LastModified.Value.ToString());
            if (flag.IsReadOnly.HasValue)
                json.WriteBoolean("locked", flag.IsReadOnly.Value);
            json.WriteEndObject();
        }

        private void SerializeFeatureFlagBatch(ref Utf8JsonWriter json, (FeatureFlag[] Flags, string NextLink) content)
        {
            json.WriteStartObject();
            if (content.NextLink != null)
            {
                json.WriteString("@nextLink", content.NextLink);
            }
            json.WriteStartArray("items");
            foreach (FeatureFlag item in content.Flags)
            {
                SerializeFeatureFlag(ref json, item);
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
                FeatureManagementMockTests.SerializeLabel(ref json, label);
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
