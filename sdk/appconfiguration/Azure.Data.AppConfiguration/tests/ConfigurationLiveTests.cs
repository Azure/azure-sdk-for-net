// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    [ClientTestFixture(
        ConfigurationClientOptions.ServiceVersion.V1_0,
        ConfigurationClientOptions.ServiceVersion.V2023_10_01,
        ConfigurationClientOptions.ServiceVersion.V2023_11_01)]
    public class ConfigurationLiveTests : RecordedTestBase<AppConfigurationTestEnvironment>
    {
        private readonly ConfigurationClientOptions.ServiceVersion _serviceVersion;

        private string specialChars = "~`!@#$^&()_+=[]{}|;\"'<>./-";

        public ConfigurationLiveTests(bool isAsync, ConfigurationClientOptions.ServiceVersion serviceVersion) : base(isAsync)
        {
            _serviceVersion = serviceVersion;
        }

        private string GenerateKeyId(string prefix = null)
        {
            return prefix + Recording.GenerateId();
        }

        private string GenerateSnapshotName(string prefix = "snapshot-")
        {
            return prefix + Recording.GenerateId();
        }

        private ConfigurationClient GetClient(bool skipClientInstrumentation = false)
        {
            if (string.IsNullOrEmpty(TestEnvironment.ConnectionString))
            {
                throw new TestRecordingMismatchException();
            }
            var options = InstrumentClientOptions(new ConfigurationClientOptions(_serviceVersion));
            var client = new ConfigurationClient(TestEnvironment.ConnectionString, options);

            if (!skipClientInstrumentation)
            {
                client = InstrumentClient(client);
            }

            return client;
        }

        private ConfigurationClient GetAADClient(ConfigurationClientOptions clientOptions = null)
        {
            string endpoint = TestEnvironment.Endpoint;
            TokenCredential credential = TestEnvironment.Credential;
            ConfigurationClientOptions configurationClientOptions = clientOptions ?? new ConfigurationClientOptions(_serviceVersion);
            ConfigurationClientOptions options = InstrumentClientOptions(configurationClientOptions);
            return InstrumentClient(new ConfigurationClient(new Uri(endpoint), credential, options));
        }

        private ConfigurationSetting CreateSetting()
        {
            return new ConfigurationSetting()
            {
                Key = GenerateKeyId("key-"),
                Value = "test_value",
                Label = "test_label",
                ContentType = "test_content_type",
                Tags = new Dictionary<string, string>
                {
                    { "tag1", "value1" },
                    { "tag2", "value2" }
                }
            };
        }

        private ConfigurationSetting CreateSetting(string key, string value, string label)
        {
            return new ConfigurationSetting()
            {
                Key = GenerateKeyId($"{key}-"),
                Value = value,
                Label = label,
            };
        }

        private ConfigurationSetting CreateSettingSpecialCharacters()
        {
            return CreateSetting($"{specialChars}", $"value-{specialChars}", $"label-{specialChars}");
        }

        private async Task<string> SetMultipleKeys(ConfigurationClient service, int expectedEvents, [CallerMemberName] string batchKey = null)
        {
            string key = GenerateKeyId("key-");

            /*
             * The configuration store contains a KV with the Key
             * that represents {expectedEvents} data points.
             * If not set, create the {expectedEvents} data points and the "batchKey"
            */

            try
            {
                Response<ConfigurationSetting> responseGet = await service.GetConfigurationSettingAsync(batchKey);
                key = responseGet.Value.Value;
            }
            catch
            {
                for (int i = 0; i < expectedEvents; i++)
                {
                    await service.AddConfigurationSettingAsync(new ConfigurationSetting(key, "test_value", $"{i}"));
                }

                await service.SetConfigurationSettingAsync(new ConfigurationSetting(batchKey, key));
            }
            return key;
        }

        private async Task<string> SetMultipleKeysWithLabels(ConfigurationClient service, int expectedEvents, [CallerMemberName] string batchKey = null)
        {
            string key = GenerateKeyId("key-l");
            string label = key;

            try
            {
                Response<ConfigurationSetting> responseGet = await service.GetConfigurationSettingAsync(batchKey, label);
                label = responseGet.Value.Label;
            }
            catch
            {
                for (int i = 0; i < expectedEvents; i++)
                {
                    await service.AddConfigurationSettingAsync(new ConfigurationSetting(key, "test_value", $"{label}_{i}"));
                }

                await service.SetConfigurationSettingAsync(new ConfigurationSetting(batchKey, label));
            }
            return label;
        }

        // This test validates that the correct token audience is parsed from the test endpoint
        // when the client is created with no specified audience.
        [RecordedTest]
        public async Task TokenAudienceDefaultAudience()
        {
            ConfigurationClient service = GetAADClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddConfigurationSettingAsync(testSetting);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting));
            }
        }

        // This test validates that the client successfully authenticates and calls the service operation
        // when the client is created with a specified audience. The audience is derived from the test endpoint.
        [RecordedTest]
        public async Task TokenAudienceSpecifiedAudience()
        {
            ConfigurationClientOptions options = new(_serviceVersion)
            {
                Audience = TestEnvironment.GetAudience()
            };
            ConfigurationClient service = GetAADClient(options);
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddConfigurationSettingAsync(testSetting);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting));
            }
        }

        [RecordedTest]
        public async Task DeleteSettingNotFound()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            Response response = await service.DeleteConfigurationSettingAsync(testSetting.Key);

            Assert.AreEqual(204, response.Status);
            response.Dispose();
        }

        [RecordedTest]
        public async Task DeleteSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                // Prepare environment
                ConfigurationSetting testSettingDiff = testSetting.Clone();
                testSettingDiff.Label = null;
                await service.SetConfigurationSettingAsync(testSetting);
                await service.SetConfigurationSettingAsync(testSettingDiff);

                // Test
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSettingDiff.Key));

                //Try to get the non-existing setting
                RequestFailedException e = Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    await service.GetConfigurationSettingAsync(testSettingDiff.Key);
                });

                Assert.AreEqual(404, e.Status);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task DeleteSettingWithLabel()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                // Prepare environment
                ConfigurationSetting testSettingDiff = testSetting.Clone();
                testSettingDiff.Label = "test_label_diff";
                await service.SetConfigurationSettingAsync(testSetting);
                await service.SetConfigurationSettingAsync(testSettingDiff);

                // Test
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSettingDiff.Key, testSettingDiff.Label));

                //Try to get the non-existing setting
                RequestFailedException e = Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    await service.GetConfigurationSettingAsync(testSettingDiff.Key, testSettingDiff.Label);
                });

                Assert.AreEqual(404, e.Status);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task DeleteSettingReadOnly()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                var setting = await service.AddConfigurationSettingAsync(testSetting);
                var readOnly = await service.SetReadOnlyAsync(testSetting.Key, testSetting.Label, true);

                // Test
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                    await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label)
                );
                Assert.AreEqual(409, exception.Status);
            }
            finally
            {
                await service.SetReadOnlyAsync(testSetting.Key, testSetting.Label, false);
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task DeleteIfUnchangedSettingUnmodified()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            ConfigurationSetting setting = await service.AddConfigurationSettingAsync(testSetting);
            AssertStatus200(await service.DeleteConfigurationSettingAsync(setting, onlyIfUnchanged: true));
        }

        [RecordedTest]
        public async Task DeleteIfUnchangedSettingModified()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddConfigurationSettingAsync(testSetting);
                ConfigurationSetting modifiedSetting = setting.Clone();
                modifiedSetting.Value = "new_value";
                modifiedSetting = await service.SetConfigurationSettingAsync(modifiedSetting);

                // Test
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                    await service.DeleteConfigurationSettingAsync(setting, onlyIfUnchanged: true));
                Assert.AreEqual(412, exception.Status);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task SetSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.SetConfigurationSettingAsync(testSetting);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task SetExistingSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.AddConfigurationSettingAsync(testSetting);

                ConfigurationSetting setting = await service.SetConfigurationSettingAsync(testSetting);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task SetSettingReadOnly()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.AddConfigurationSettingAsync(testSetting);
                await service.SetReadOnlyAsync(testSetting.Key, testSetting.Label, true);

                testSetting.Value = "new_value";

                // Test
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                    await service.SetConfigurationSettingAsync(testSetting.Key, "new_value", testSetting.Label));
                Assert.AreEqual(409, exception.Status);
            }
            finally
            {
                await service.SetReadOnlyAsync(testSetting.Key, testSetting.Label, false);
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task SetIfUnchangedSettingUnmodified()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddConfigurationSettingAsync(testSetting);
                setting.Value = "new_value";

                // Test
                Response<ConfigurationSetting> response = await service.SetConfigurationSettingAsync(setting, onlyIfUnchanged: true);
                Assert.AreEqual(200, response.GetRawResponse().Status);
                Assert.AreEqual(setting.Value, response.Value.Value);
                Assert.AreNotEqual(setting.ETag, response.Value.ETag);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task SetIfUnchangedSettingModified()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddConfigurationSettingAsync(testSetting);
                ConfigurationSetting modifiedSetting = setting.Clone();
                modifiedSetting.Value = "new_value";
                modifiedSetting = await service.SetConfigurationSettingAsync(modifiedSetting);

                // Test
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                    await service.SetConfigurationSettingAsync(setting, onlyIfUnchanged: true));
                Assert.AreEqual(412, exception.Status);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task SetKeyValue()
        {
            ConfigurationClient service = GetClient();

            string key = GenerateKeyId("key-");

            try
            {
                string value = "my_value";
                ConfigurationSetting setting = await service.SetConfigurationSettingAsync(key, value);

                Assert.AreEqual(key, setting.Key);
                Assert.AreEqual(value, setting.Value);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(key));
            }
        }

        [RecordedTest]
        public async Task SetKeyValueLabel()
        {
            ConfigurationClient service = GetClient();

            string key = GenerateKeyId("key-");
            string value = "my_value";
            string label = "my_label";

            try
            {
                ConfigurationSetting setting = await service.SetConfigurationSettingAsync(key, value, label);

                Assert.AreEqual(key, setting.Key);
                Assert.AreEqual(value, setting.Value);
                Assert.AreEqual(label, setting.Label);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(key, label));
            }
        }

        [RecordedTest]
        public async Task GetRequestId()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                Response<ConfigurationSetting> response = await service.SetConfigurationSettingAsync(testSetting);
                response.GetRawResponse().Headers.TryGetValue("x-ms-client-request-id", out string requestId);
                Assert.IsNotEmpty(requestId);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task AddExistingSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.AddConfigurationSettingAsync(testSetting);

                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    await service.AddConfigurationSettingAsync(testSetting);
                });

                Assert.AreEqual(412, exception.Status);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task AddSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddConfigurationSettingAsync(testSetting);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task AddSettingNoLabel()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            ConfigurationSetting testSettingNoLabel = testSetting.Clone();
            testSettingNoLabel.Label = null;

            try
            {
                ConfigurationSetting setting = await service.AddConfigurationSettingAsync(testSettingNoLabel);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSettingNoLabel, setting));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key));
            }
        }

        [RecordedTest]
        public async Task AddKeyValue()
        {
            ConfigurationClient service = GetClient();

            string key = GenerateKeyId("key-");

            try
            {
                string value = "my_value";
                ConfigurationSetting setting = await service.AddConfigurationSettingAsync(key, value);

                Assert.AreEqual(key, setting.Key);
                Assert.AreEqual(value, setting.Value);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(key));
            }
        }

        [RecordedTest]
        public async Task AddKeyValueLabel()
        {
            ConfigurationClient service = GetClient();

            string key = GenerateKeyId("key-");
            string value = "my_value";
            string label = "my_label";

            try
            {
                ConfigurationSetting setting = await service.AddConfigurationSettingAsync(key, value, label);

                Assert.AreEqual(key, setting.Key);
                Assert.AreEqual(value, setting.Value);
                Assert.AreEqual(label, setting.Label);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(key, label));
            }
        }

        [RecordedTest]
        public async Task GetRevisions()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            //Prepare environment
            ConfigurationSetting setting = testSetting;

            setting.Key = GenerateKeyId("key-");
            ConfigurationSetting testSettingUpdate = setting.Clone();
            testSettingUpdate.Label = "test_label_update";
            int expectedEvents = 2;

            try
            {
                await service.SetConfigurationSettingAsync(setting);
                await service.SetConfigurationSettingAsync(testSettingUpdate);

                // Test
                var selector = new SettingSelector
                {
                    KeyFilter = setting.Key,
                    AcceptDateTime = DateTimeOffset.MaxValue
                };

                int resultsReturned = 0;
                await foreach (ConfigurationSetting value in service.GetRevisionsAsync(selector, CancellationToken.None))
                {
                    if (value.Label.Contains("update"))
                    {
                        Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(value, testSettingUpdate));
                    }
                    else
                    {
                        Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(value, setting));
                    }
                    resultsReturned++;
                }

                Assert.AreEqual(expectedEvents, resultsReturned);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(setting.Key, setting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSettingUpdate.Key, testSettingUpdate.Label));
            }
        }

        // Validates that the expected revisions are retrieved correctly when specifying a list of tags.
        [RecordedTest]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_11_01)]
        public async Task GetRevisionsByTags()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            //Prepare environment
            ConfigurationSetting setting = testSetting;

            setting.Key = GenerateKeyId("key-");
            ConfigurationSetting testSettingUpdate = setting.Clone();
            testSettingUpdate.Label = "test_label_update";
            testSettingUpdate.Tags = new Dictionary<string, string>
            {
                { "foo", "bar" },
                { "foo2", "bar2" },
                { "foo3", "bar3" },
                { "foo4", "bar4" },
                { "foo5", "bar5" }
            };
            int expectedRevisions = 1;

            try
            {
                await service.SetConfigurationSettingAsync(setting);
                await service.SetConfigurationSettingAsync(testSettingUpdate);

                // Test
                var selector = new SettingSelector
                {
                    KeyFilter = setting.Key,
                    AcceptDateTime = DateTimeOffset.MaxValue
                };

                foreach (var tag in testSettingUpdate.Tags)
                {
                    var parsedTag = $"{tag.Key}={tag.Value}";
                    selector.TagsFilter.Add(parsedTag);
                }

                int resultsReturned = 0;
                await foreach (ConfigurationSetting value in service.GetRevisionsAsync(selector, CancellationToken.None))
                {
                    if (value.Label.Contains("update"))
                    {
                        Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(value, testSettingUpdate));
                    }
                    else
                    {
                        Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(value, setting));
                    }
                    resultsReturned++;
                }

                Assert.AreEqual(expectedRevisions, resultsReturned);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(setting.Key, setting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSettingUpdate.Key, testSettingUpdate.Label));
            }
        }

        [RecordedTest]
        public async Task GetRevisionsByKeyAndLabel()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            //Prepare environment
            ConfigurationSetting setting = testSetting;

            setting.Key = GenerateKeyId("key-");
            ConfigurationSetting testSettingUpdate = setting.Clone();
            testSettingUpdate.Label = "test_label_update";

            try
            {
                await service.SetConfigurationSettingAsync(setting);
                await service.SetConfigurationSettingAsync(testSettingUpdate);
                AsyncPageable<ConfigurationSetting> revisions = service.GetRevisionsAsync(testSettingUpdate.Key, testSettingUpdate.Label, CancellationToken.None);

                int resultsReturned = 0;
                await foreach (ConfigurationSetting value in revisions)
                {
                    Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(value, testSettingUpdate));
                    resultsReturned++;
                }

                Assert.AreEqual(1, resultsReturned);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(setting.Key, setting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSettingUpdate.Key, testSettingUpdate.Label));
            }
        }

        [RecordedTest]
        public async Task GetSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            // Prepare environment
            ConfigurationSetting testSettingNoLabel = testSetting.Clone();
            testSettingNoLabel.Label = null;

            try
            {
                await service.SetConfigurationSettingAsync(testSettingNoLabel);
                // Test
                ConfigurationSetting setting = await service.GetConfigurationSettingAsync(testSettingNoLabel.Key);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSettingNoLabel, setting));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSettingNoLabel.Key));
            }
        }

        [RecordedTest]
        public void GetSettingNotFound()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.GetConfigurationSettingAsync(testSetting.Key);
            });

            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public async Task GetSettingWithLabel()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            // Prepare environment
            ConfigurationSetting testSettingNoLabel = testSetting.Clone();
            testSettingNoLabel.Label = null;

            try
            {
                await service.SetConfigurationSettingAsync(testSettingNoLabel);
                await service.SetConfigurationSettingAsync(testSetting);

                // Test
                ConfigurationSetting responseSetting = await service.GetConfigurationSettingAsync(testSetting.Key, testSetting.Label);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, responseSetting));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSettingNoLabel.Key));
            }
        }

        [RecordedTest]
        public async Task GetSettingWithIfMatch_Matches()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                testSetting = await service.SetConfigurationSettingAsync(testSetting);

                // Test
                ConfigurationSetting responseSetting = await service.GetConfigurationSettingAsync(testSetting.Key, testSetting.Label, acceptDateTime: null, new MatchConditions()
                {
                    IfMatch = testSetting.ETag
                });

                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, responseSetting));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task GetSettingWithIfMatch_NoMatch()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                testSetting = await service.SetConfigurationSettingAsync(testSetting);

                // Test
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                    await service.GetConfigurationSettingAsync(testSetting.Key, testSetting.Label, acceptDateTime: null, new MatchConditions()
                    {
                        IfMatch = new ETag("this won't match")
                    }));

                Assert.AreEqual(412, exception.Status);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task GetSettingWithIfNoneMatch_Matches()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                testSetting = await service.SetConfigurationSettingAsync(testSetting);

                // Test
                Response<ConfigurationSetting> responseSetting = await service.GetConfigurationSettingAsync(testSetting.Key, testSetting.Label, acceptDateTime: null, new MatchConditions()
                {
                    IfNoneMatch = testSetting.ETag
                });

                Assert.Catch<Exception>(() => _ = responseSetting.Value);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task GetSettingWithIfNoneMatch_NoMatch()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                testSetting = await service.SetConfigurationSettingAsync(testSetting);

                // Test
                ConfigurationSetting responseSetting = await service.GetConfigurationSettingAsync(testSetting.Key, testSetting.Label, acceptDateTime: null, new MatchConditions()
                {
                    IfNoneMatch = new ETag("this won't match")
                });

                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, responseSetting));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task GetWithAcceptDateTime()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.SetConfigurationSettingAsync(testSetting);

                // Test
                // TODO: add a test with a more granular timestamp.
                ConfigurationSetting responseSetting = await service.GetConfigurationSettingAsync(testSetting, DateTimeOffset.MaxValue);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, responseSetting));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task GetIfChangedSettingModified()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddConfigurationSettingAsync(testSetting);
                ConfigurationSetting modifiedSetting = setting.Clone();
                modifiedSetting.Value = "new_value";
                modifiedSetting = await service.SetConfigurationSettingAsync(modifiedSetting);

                Response<ConfigurationSetting> response = await service.GetConfigurationSettingAsync(setting, onlyIfChanged: true).ConfigureAwait(false);
                Assert.AreEqual(200, response.GetRawResponse().Status);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(modifiedSetting, response.Value));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task GetIfChangedSettingNotModified()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddConfigurationSettingAsync(testSetting);

                Response<ConfigurationSetting> response = await service.GetConfigurationSettingAsync(new ConfigurationSetting(setting.Key, "", setting.Label, setting.ETag), onlyIfChanged: true).ConfigureAwait(false);
                Assert.AreEqual(304, response.GetRawResponse().Status);
                Assert.Catch<Exception>(() => _ = response.Value);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task GetIfChangedSettingUnmodified()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddConfigurationSettingAsync(testSetting);

                // Test
                Response<ConfigurationSetting> response = await service.GetConfigurationSettingAsync(setting, onlyIfChanged: true).ConfigureAwait(false);
                Assert.AreEqual(304, response.GetRawResponse().Status);

                bool throws = false;
                try
                {
                    ConfigurationSetting value = response.Value;
                }
                catch
                {
                    throws = true;
                }

                Assert.IsTrue(throws);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task GetIfChangedSettingUnmodifiedDoesNotLogWarning()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            string logMessage = null;
            Action<EventWrittenEventArgs, string> warningLog = (_, text) =>
            {
                logMessage = text;
            };

            try
            {
                testSetting = await service.AddConfigurationSettingAsync(testSetting);

                using (var listener = new AzureEventSourceListener(warningLog, EventLevel.Warning))
                {
                    Response<ConfigurationSetting> response = await service.GetConfigurationSettingAsync(testSetting, onlyIfChanged: true);
                    Assert.AreEqual(304, response.GetRawResponse().Status);
                }

                Assert.Null(logMessage);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting));
            }
        }

        [RecordedTest]
        public async Task GetSettingSpecialCharacters()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSettingSpecialCharacters();

            // Prepare environment
            ConfigurationSetting testSettingNoLabel = testSetting.Clone();
            testSettingNoLabel.Label = null;

            try
            {
                await service.SetConfigurationSettingAsync(testSettingNoLabel);

                // Test
                ConfigurationSetting setting = await service.GetConfigurationSettingAsync(testSettingNoLabel.Key);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSettingNoLabel, setting));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSettingNoLabel.Key));
            }
        }

        [RecordedTest]
        public async Task GetSettingSpecialCharactersWithLabel()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSettingSpecialCharacters();

            try
            {
                await service.SetConfigurationSettingAsync(testSetting);

                // Test
                ConfigurationSetting setting = await service.GetConfigurationSettingAsync(testSetting.Key, testSetting.Label);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting));
            }
        }

        [RecordedTest]
        public async Task GetBatchSettingPagination()
        {
            ConfigurationClient service = GetClient();

            const int expectedEvents = 105;
            var key = await SetMultipleKeys(service, expectedEvents);

            int resultsReturned = 0;
            SettingSelector selector = new SettingSelector { KeyFilter = key };

            await foreach (ConfigurationSetting item in service.GetConfigurationSettingsAsync(selector, CancellationToken.None))
            {
                Assert.AreEqual("test_value", item.Value);
                resultsReturned++;
            }

            Assert.AreEqual(expectedEvents, resultsReturned);
        }

        [RecordedTest]
        [AsyncOnly]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
        public async Task GetBatchSettingIfChangedWithUnmodifiedPage()
        {
            ConfigurationClient service = GetClient(skipClientInstrumentation: true);

            const int expectedEvents = 105;
            var key = await SetMultipleKeys(service, expectedEvents);

            SettingSelector selector = new SettingSelector { KeyFilter = key };
            var matchConditionsList = new List<MatchConditions>();

            await foreach (Page<ConfigurationSetting> page in service.GetConfigurationSettingsAsync(selector).AsPages())
            {
                Response response = page.GetRawResponse();
                var matchConditions = new MatchConditions()
                {
                    IfNoneMatch = response.Headers.ETag
                };

                matchConditionsList.Add(matchConditions);
            }

            int pagesCount = 0;

            await foreach (Page<ConfigurationSetting> page in service.GetConfigurationSettingsAsync(selector).AsPages(matchConditionsList))
            {
                Response response = page.GetRawResponse();

                Assert.AreEqual(304, response.Status);
                Assert.IsEmpty(page.Values);

                pagesCount++;
            }

            Assert.AreEqual(2, pagesCount);
        }

        [RecordedTest]
        [SyncOnly]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
        public async Task GetBatchSettingIfChangedWithUnmodifiedPageSync()
        {
            ConfigurationClient service = GetClient(skipClientInstrumentation: true);

            const int expectedEvents = 105;
            var key = await SetMultipleKeys(service, expectedEvents);

            SettingSelector selector = new SettingSelector { KeyFilter = key };
            var matchConditionsList = new List<MatchConditions>();

            foreach (Page<ConfigurationSetting> page in service.GetConfigurationSettings(selector).AsPages())
            {
                Response response = page.GetRawResponse();
                var matchConditions = new MatchConditions()
                {
                    IfNoneMatch = response.Headers.ETag
                };

                matchConditionsList.Add(matchConditions);
            }

            int pagesCount = 0;

            foreach (Page<ConfigurationSetting> page in service.GetConfigurationSettings(selector).AsPages(matchConditionsList))
            {
                Response response = page.GetRawResponse();

                Assert.AreEqual(304, response.Status);
                Assert.IsEmpty(page.Values);

                pagesCount++;
            }

            Assert.AreEqual(2, pagesCount);
        }

        [RecordedTest]
        [AsyncOnly]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
        public async Task GetBatchSettingIfChangedWithUnmodifiedPageDoesNotLogWarningAsync()
        {
            ConfigurationClient service = GetClient(skipClientInstrumentation: true);

            const int expectedEvents = 105;
            var key = await SetMultipleKeys(service, expectedEvents);

            SettingSelector selector = new SettingSelector { KeyFilter = key };
            var matchConditionsList = new List<MatchConditions>();

            var pagesEnumerator = service.GetConfigurationSettingsAsync(selector).AsPages().GetAsyncEnumerator();
            await pagesEnumerator.MoveNextAsync();

            Page<ConfigurationSetting> firstPage = pagesEnumerator.Current;

            var matchConditions = new MatchConditions()
            {
                IfNoneMatch = firstPage.GetRawResponse().Headers.ETag
            };
            matchConditionsList.Add(matchConditions);

            string logMessage = null;
            Action<EventWrittenEventArgs, string> warningLog = (_, text) =>
            {
                logMessage = text;
            };

            pagesEnumerator = service.GetConfigurationSettingsAsync(selector).AsPages(matchConditionsList).GetAsyncEnumerator();

            using (var listener = new AzureEventSourceListener(warningLog, EventLevel.Warning))
            {
                await pagesEnumerator.MoveNextAsync();
                firstPage = pagesEnumerator.Current;
                Assert.AreEqual(304, firstPage.GetRawResponse().Status);
            }

            Assert.Null(logMessage);
        }

        [RecordedTest]
        [SyncOnly]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
        public async Task GetBatchSettingIfChangedWithUnmodifiedPageDoesNotLogWarningSync()
        {
            ConfigurationClient service = GetClient(skipClientInstrumentation: true);

            const int expectedEvents = 105;
            var key = await SetMultipleKeys(service, expectedEvents);

            SettingSelector selector = new SettingSelector { KeyFilter = key };
            var matchConditionsList = new List<MatchConditions>();

            var pagesEnumerator = service.GetConfigurationSettings(selector).AsPages().GetEnumerator();
            pagesEnumerator.MoveNext();

            Page<ConfigurationSetting> firstPage = pagesEnumerator.Current;

            var matchConditions = new MatchConditions()
            {
                IfNoneMatch = firstPage.GetRawResponse().Headers.ETag
            };
            matchConditionsList.Add(matchConditions);

            string logMessage = null;
            Action<EventWrittenEventArgs, string> warningLog = (_, text) =>
            {
                logMessage = text;
            };

            pagesEnumerator = service.GetConfigurationSettings(selector).AsPages(matchConditionsList).GetEnumerator();

            using (var listener = new AzureEventSourceListener(warningLog, EventLevel.Warning))
            {
                pagesEnumerator.MoveNext();
                firstPage = pagesEnumerator.Current;
                Assert.AreEqual(304, firstPage.GetRawResponse().Status);
            }

            Assert.Null(logMessage);
        }

        [RecordedTest]
        [AsyncOnly]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
        public async Task GetBatchSettingIfChangedWithModifiedPage()
        {
            ConfigurationClient service = GetClient(skipClientInstrumentation: true);

            const int expectedEvents = 105;
            var key = await SetMultipleKeys(service, expectedEvents);

            SettingSelector selector = new SettingSelector { KeyFilter = key };
            var matchConditionsList = new List<MatchConditions>();
            ConfigurationSetting lastSetting = null;

            await foreach (Page<ConfigurationSetting> page in service.GetConfigurationSettingsAsync(selector).AsPages())
            {
                Response response = page.GetRawResponse();
                var matchConditions = new MatchConditions()
                {
                    IfNoneMatch = response.Headers.ETag
                };

                matchConditionsList.Add(matchConditions);
                lastSetting = page.Values.Last();
            }

            lastSetting.Value += "1";
            await service.SetConfigurationSettingAsync(lastSetting);

            int pagesCount = 0;

            await foreach (Page<ConfigurationSetting> page in service.GetConfigurationSettingsAsync(selector).AsPages(matchConditionsList))
            {
                Response response = page.GetRawResponse();

                if (pagesCount == 0)
                {
                    Assert.AreEqual(304, response.Status);
                    Assert.IsEmpty(page.Values);
                }
                else
                {
                    Assert.AreEqual(200, response.Status);
                    Assert.IsNotEmpty(page.Values);
                }

                pagesCount++;
            }

            Assert.AreEqual(2, pagesCount);
        }

        [RecordedTest]
        [SyncOnly]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
        public async Task GetBatchSettingIfChangedWithModifiedPageSync()
        {
            ConfigurationClient service = GetClient(skipClientInstrumentation: true);

            const int expectedEvents = 105;
            var key = await SetMultipleKeys(service, expectedEvents);

            SettingSelector selector = new SettingSelector { KeyFilter = key };
            var matchConditionsList = new List<MatchConditions>();
            ConfigurationSetting lastSetting = null;

            foreach (Page<ConfigurationSetting> page in service.GetConfigurationSettings(selector).AsPages())
            {
                Response response = page.GetRawResponse();
                var matchConditions = new MatchConditions()
                {
                    IfNoneMatch = response.Headers.ETag
                };

                matchConditionsList.Add(matchConditions);
                lastSetting = page.Values.Last();
            }

            lastSetting.Value += "1";
            await service.SetConfigurationSettingAsync(lastSetting);

            int pagesCount = 0;

            foreach (Page<ConfigurationSetting> page in service.GetConfigurationSettings(selector).AsPages(matchConditionsList))
            {
                Response response = page.GetRawResponse();

                if (pagesCount == 0)
                {
                    Assert.AreEqual(304, response.Status);
                    Assert.IsEmpty(page.Values);
                }
                else
                {
                    Assert.AreEqual(200, response.Status);
                    Assert.IsNotEmpty(page.Values);
                }

                pagesCount++;
            }

            Assert.AreEqual(2, pagesCount);
        }

        [RecordedTest]
        public async Task GetBatchSettingAny()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.SetConfigurationSettingAsync(testSetting);

                var selector = new SettingSelector();

                Assert.AreEqual(null, selector.KeyFilter);
                Assert.AreEqual(null, selector.LabelFilter);

                var resultsReturned = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).Count;

                //At least there should be one key available
                Assert.GreaterOrEqual(resultsReturned, 1);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task GetBatchSettingKeyLabel()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.SetConfigurationSettingAsync(testSetting);

                var selector = new SettingSelector
                {
                    KeyFilter = testSetting.Key,
                    LabelFilter = testSetting.Label
                };

                ConfigurationSetting[] batch = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                Assert.AreEqual(1, batch.Length);
                Assert.AreEqual(testSetting.Key, batch[0].Key);
                Assert.AreEqual(testSetting.Label, batch[0].Label);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task GetBatchSettingOnlyKey()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.SetConfigurationSettingAsync(testSetting);

                var selector = new SettingSelector { KeyFilter = testSetting.Key };
                ConfigurationSetting[] batch = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                Assert.AreEqual(1, batch.Length);
                Assert.AreEqual(testSetting.Key, batch[0].Key);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task GetBatchSettingOnlyLabel()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.SetConfigurationSettingAsync(testSetting);

                var selector = new SettingSelector { LabelFilter = testSetting.Label };

                Assert.AreEqual(null, selector.KeyFilter);

                ConfigurationSetting[] batch = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                //At least there should be one key available
                CollectionAssert.IsNotEmpty(batch);
                Assert.AreEqual(testSetting.Label, batch[0].Label);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task GetBatchSettingWithFields()
        {
            ConfigurationClient service = GetClient();

            string key = GenerateKeyId("keyFields-");
            ConfigurationSetting setting = await service.AddConfigurationSettingAsync(key, "my_value", "my_label");

            try
            {
                SettingSelector selector = new SettingSelector
                {
                    KeyFilter = key,
                    Fields = SettingFields.Key | SettingFields.Label | SettingFields.ETag
                };

                ConfigurationSetting[] batch = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                Assert.AreEqual(1, batch.Length);

                Assert.IsNotNull(batch[0].Key);
                Assert.IsNotNull(batch[0].Label);
                Assert.AreNotEqual(batch[0].ETag, default(ETag));
                Assert.IsNull(batch[0].Value);
                Assert.IsNull(batch[0].ContentType);
                Assert.IsNull(batch[0].LastModified);
                Assert.IsNull(batch[0].IsReadOnly);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(setting.Key, setting.Label));
            }
        }

        [RecordedTest]
        public async Task GetBatchSettingWithReadOnly()
        {
            ConfigurationClient service = GetClient();

            string key = GenerateKeyId("key-");
            ConfigurationSetting setting = await service.AddConfigurationSettingAsync(key, "my_value", "my_label");

            try
            {
                SettingSelector selector = new SettingSelector
                {
                    KeyFilter = key,
                    Fields = SettingFields.Key | SettingFields.IsReadOnly
                };

                List<ConfigurationSetting> batch = await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync();

                CollectionAssert.IsNotEmpty(batch);
                Assert.IsNotNull(batch[0].Key);
                Assert.IsNotNull(batch[0].IsReadOnly);
                Assert.IsNull(batch[0].Label);
                Assert.IsNull(batch[0].Value);
                Assert.IsNull(batch[0].ContentType);
                Assert.IsNull(batch[0].LastModified);
                Assert.AreEqual(batch[0].ETag, default(ETag));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(setting.Key, setting.Label));
            }
        }

        [RecordedTest]
        public async Task GetBatchSettingWithAllFields()
        {
            ConfigurationClient service = GetClient();
            string key = GenerateKeyId("keyFields-");
            ConfigurationSetting setting = await service.AddConfigurationSettingAsync(new ConfigurationSetting(key, "my_value", "my_label")
            {
                ContentType = "content-type"
            });

            try
            {
                SettingSelector selector = new SettingSelector
                {
                    KeyFilter = key,
                    Fields = SettingFields.All
                };

                ConfigurationSetting[] batch = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                Assert.AreEqual(1, batch.Length);

                Assert.IsNotNull(batch[0].Key);
                Assert.IsNotNull(batch[0].Label);
                Assert.IsNotNull(batch[0].Value);
                Assert.IsNotNull(batch[0].ContentType);
                Assert.AreNotEqual(batch[0].ETag, default(ETag));
                Assert.IsNotNull(batch[0].LastModified);
                Assert.IsNotNull(batch[0].IsReadOnly);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(setting.Key, setting.Label));
            }
        }

        [RecordedTest]
        public async Task GetBatchSettingWithAllFieldsSetExplicitly()
        {
            ConfigurationClient service = GetClient();
            string key = GenerateKeyId("keyFields-");
            ConfigurationSetting setting = await service.AddConfigurationSettingAsync(new ConfigurationSetting(key, "my_value", "my_label")
            {
                ContentType = "content-type",
                Tags = { { "my_tag", "my_tag_value" } }
            });

            try
            {
                SettingSelector selector = new SettingSelector
                {
                    KeyFilter = key,
                    Fields = SettingFields.Key | SettingFields.Label | SettingFields.Value | SettingFields.ContentType
                        | SettingFields.ETag | SettingFields.LastModified | SettingFields.IsReadOnly | SettingFields.Tags
                };

                ConfigurationSetting[] batch = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                Assert.AreEqual(1, batch.Length);

                Assert.IsNotNull(batch[0].Key);
                Assert.IsNotNull(batch[0].Label);
                Assert.IsNotNull(batch[0].Value);
                Assert.IsNotNull(batch[0].ContentType);
                Assert.AreNotEqual(batch[0].ETag, default(ETag));
                Assert.IsNotNull(batch[0].LastModified);
                Assert.IsNotNull(batch[0].IsReadOnly);
                Assert.IsNotEmpty(batch[0].Tags);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(setting.Key, setting.Label));
            }
        }

        [RecordedTest]
        public async Task GetBatchSettingSpecialCharacters()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSettingSpecialCharacters();

            try
            {
                await service.SetConfigurationSettingAsync(testSetting);

                var selector = new SettingSelector { KeyFilter = testSetting.Key };

                ConfigurationSetting[] settings = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                // There should be at least one key available
                CollectionAssert.IsNotEmpty(settings);
                Assert.AreEqual(testSetting.Key, settings[0].Key);
                Assert.AreEqual(testSetting.Label, settings[0].Label);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting));
            }
        }

        [RecordedTest]
        public async Task GetBatchSettingStartsWith()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting("abcde", "Starts with abc", "abcde");

            try
            {
                await service.SetConfigurationSettingAsync(testSetting);

                var selector = new SettingSelector { KeyFilter = "abc*" };

                ConfigurationSetting[] settings = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                // There should be at least one key available.
                CollectionAssert.IsNotEmpty(settings);

                foreach (ConfigurationSetting setting in settings)
                {
                    StringAssert.StartsWith("abc", setting.Key);
                }
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_11_01)]
        public async Task GetBatchSettingByTags()
        {
            ConfigurationClient service = GetClient();
            var expectedTags = new Dictionary<string, string>
            {
                { "my_tag", "my_tag_value" }
            };

            ConfigurationSetting abcSetting = new ConfigurationSetting("abcd", "foobar")
            {
                Tags = expectedTags
            };
            ConfigurationSetting xyzSetting = new ConfigurationSetting("wxyz", "barfoo")
            {
                Tags = expectedTags
            };

            try
            {
                await service.SetConfigurationSettingAsync(abcSetting);
                await service.SetConfigurationSettingAsync(xyzSetting);

                var tags = expectedTags.Select(t => $"{t.Key}={t.Value}").ToArray();
                var selector = new SettingSelector();
                foreach (var tag in expectedTags)
                {
                    var parsedTag = $"{tag.Key}={tag.Value}";
                    selector.TagsFilter.Add(parsedTag);
                }

                ConfigurationSetting[] settings = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                Assert.AreEqual(2, settings.Length);
                Assert.IsTrue(settings.Any(s => s.Key == "abcd"));
                Assert.IsTrue(settings.Any(s => s.Key == "wxyz"));
                Assert.IsTrue(settings.Any(s => s.Tags.Any() == true));
                Assert.IsTrue(settings.Any(s => s.Tags.SequenceEqual(expectedTags)));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(abcSetting.Key));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(xyzSetting.Key));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_11_01)]
        public async Task GetBatchSettingByTagsNoMatchingSettings()
        {
            ConfigurationClient service = GetClient();
            var tags = new Dictionary<string, string>
            {
                { "my_tag", "my_tag_value" }
            };

            ConfigurationSetting abcSetting = new ConfigurationSetting("abcd", "foobar");
            ConfigurationSetting xyzSetting = new ConfigurationSetting("wxyz", "barfoo");

            try
            {
                await service.SetConfigurationSettingAsync(abcSetting);
                await service.SetConfigurationSettingAsync(xyzSetting);

                var selector = new SettingSelector();
                foreach (var tag in tags)
                {
                    var parsedTag = $"{tag.Key}={tag.Value}";
                    selector.TagsFilter.Add(parsedTag);
                }

                ConfigurationSetting[] settings = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                Assert.AreEqual(0, settings.Length);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(abcSetting.Key));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(xyzSetting.Key));
            }
        }

        [RecordedTest]
        public async Task GetBatchSettingsWithCommaInSelectorKey()
        {
            ConfigurationClient service = GetClient();

            ConfigurationSetting abcSetting = new ConfigurationSetting("ab,cd", "comma in key");
            ConfigurationSetting xyzSetting = new ConfigurationSetting("wx,yz", "comma in key");

            try
            {
                await service.SetConfigurationSettingAsync(abcSetting);
                await service.SetConfigurationSettingAsync(xyzSetting);

                var selector = new SettingSelector { KeyFilter = @"ab\,cd,wx\,yz" };

                ConfigurationSetting[] settings = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                Assert.GreaterOrEqual(settings.Length, 2);
                Assert.IsTrue(settings.Any(s => s.Key == "ab,cd"));
                Assert.IsTrue(settings.Any(s => s.Key == "wx,yz"));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(abcSetting.Key));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(xyzSetting.Key));
            }
        }

        [RecordedTest]
        public async Task GetBatchSettingsWithCommaInSelectorKeyDoesNotOr()
        {
            ConfigurationClient service = GetClient();

            ConfigurationSetting abcSetting = new ConfigurationSetting("abc", "abc setting");
            ConfigurationSetting xyzSetting = new ConfigurationSetting("xyz", "xyz setting");

            try
            {
                await service.SetConfigurationSettingAsync(abcSetting);
                await service.SetConfigurationSettingAsync(xyzSetting);

                var selector = new SettingSelector { KeyFilter = $@"{abcSetting.Key}\,{xyzSetting.Key}" };

                ConfigurationSetting[] settings = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                CollectionAssert.IsEmpty(settings);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(abcSetting.Key));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(xyzSetting.Key));
            }
        }

        [RecordedTest]
        public async Task GetBatchSettingsWithMultipleKeys()
        {
            ConfigurationClient service = GetClient();

            ConfigurationSetting abcSetting = new ConfigurationSetting("abc", "abc setting");
            ConfigurationSetting xyzSetting = new ConfigurationSetting("xyz", "xyz setting");

            try
            {
                await service.SetConfigurationSettingAsync(abcSetting);
                await service.SetConfigurationSettingAsync(xyzSetting);

                var selector = new SettingSelector { KeyFilter = "abc,xyz" };

                ConfigurationSetting[] settings = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                Assert.GreaterOrEqual(settings.Length, 2);
                Assert.IsTrue(settings.Any(s => s.Key == "abc"));
                Assert.IsTrue(settings.Any(s => s.Key == "xyz"));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(abcSetting.Key));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(xyzSetting.Key));
            }
        }

        [RecordedTest]
        public async Task GetBatchSettingsWithMultipleLabels()
        {
            ConfigurationClient service = GetClient();

            ConfigurationSetting abcSetting = new ConfigurationSetting("key-abc", "abc setting", "abc");
            ConfigurationSetting xyzSetting = new ConfigurationSetting("label-xyz", "xyz setting", "xyz");

            try
            {
                await service.SetConfigurationSettingAsync(abcSetting);
                await service.SetConfigurationSettingAsync(xyzSetting);

                var selector = new SettingSelector { LabelFilter = "abc,xyz" };

                ConfigurationSetting[] settings = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                Assert.GreaterOrEqual(settings.Length, 2);
                Assert.IsTrue(settings.Any(s => s.Label == "abc"));
                Assert.IsTrue(settings.Any(s => s.Label == "xyz"));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(abcSetting.Key, abcSetting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(xyzSetting.Key, xyzSetting.Label));
            }
        }

        [RecordedTest]
        public async Task SetReadOnlyOnSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                var setting = await service.AddConfigurationSettingAsync(testSetting);
                var readOnly = await service.SetReadOnlyAsync(testSetting.Key, testSetting.Label, true);
                Assert.IsTrue(readOnly.Value.IsReadOnly);
            }
            finally
            {
                await service.SetReadOnlyAsync(testSetting.Key, testSetting.Label, false);
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public void SetReadOnlySettingNotFound()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            Assert.ThrowsAsync<RequestFailedException>(async () => { await service.SetReadOnlyAsync(testSetting.Key, true); });
        }

        [RecordedTest]
        public async Task ConfigurationClient_SetReadOnly_OnlyIfUnchanged_Unmodified([Values(true, false)] bool isReadOnly)
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddConfigurationSettingAsync(testSetting);
                setting = await service.SetReadOnlyAsync(setting, !isReadOnly, onlyIfUnchanged: true);
                Assert.AreEqual(!isReadOnly, setting.IsReadOnly);
                setting = await service.SetReadOnlyAsync(setting, isReadOnly, onlyIfUnchanged: true);
                Assert.AreEqual(isReadOnly, setting.IsReadOnly);
            }
            finally
            {
                await service.SetReadOnlyAsync(testSetting.Key, testSetting.Label, false);
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task ConfigurationClient_SetReadOnly_OnlyIfUnchanged_Modified([Values(true, false)] bool isReadOnly)
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddConfigurationSettingAsync(testSetting);
                ConfigurationSetting modifiedSetting = setting.Clone();
                modifiedSetting.Value = "new_value";
                await service.SetConfigurationSettingAsync(modifiedSetting);

                // Test
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await service.SetReadOnlyAsync(setting, isReadOnly, onlyIfUnchanged: true));
                Assert.AreEqual(412, exception.Status);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        public async Task ClearReadOnlyFromSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                var setting = await service.AddConfigurationSettingAsync(testSetting);
                var readOnly = await service.SetReadOnlyAsync(testSetting.Key, testSetting.Label, false);
                Assert.IsFalse(readOnly.Value.IsReadOnly);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting));
            }
        }

        [RecordedTest]
        public void ClearReadOnlySettingNotFound()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            Assert.ThrowsAsync<RequestFailedException>(async () => { await service.SetReadOnlyAsync(testSetting.Key, true); });
        }

        [RecordedTest]
        public async Task AddSettingDefaultAAD()
        {
            ConfigurationClient service = GetAADClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddConfigurationSettingAsync(testSetting);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting));
            }
        }

        [RecordedTest]
        public async Task CanAddAndGetFeatureFlag()
        {
            ConfigurationClient service = GetClient();
            var testSetting = new FeatureFlagConfigurationSetting(GenerateKeyId("feature 1"), true);

            try
            {
                var settingResponse = await service.AddConfigurationSettingAsync(testSetting);
                var setting = settingResponse.Value;

                Assert.IsInstanceOf<FeatureFlagConfigurationSetting>(setting);
                Assert.AreEqual(testSetting.Key, setting.Key);
                Assert.AreEqual(testSetting.Value, setting.Value);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting));
            }
        }

        [RecordedTest]
        public async Task CanAddAndUpdateFeatureFlag()
        {
            ConfigurationClient service = GetClient();
            var testSetting = new FeatureFlagConfigurationSetting(GenerateKeyId("feature 1"), true)
            {
                Description = "Feature description",
                DisplayName = "Feature display name",
                ClientFilters =
                {
                    new FeatureFlagFilter("FilterA"),
                    new FeatureFlagFilter("Microsoft.TimeWindow", new Dictionary<string, object>()
                    {
                        { "Start", "Wed, 01 May 2019 13:59:59 GMT" },
                        { "End", "Mon, 01 July 2019 00:00:00 GMT" }
                    })
                }
            };

            try
            {
                var settingResponse = await service.AddConfigurationSettingAsync(testSetting);

                var setting = (FeatureFlagConfigurationSetting) settingResponse.Value;
                Assert.True(setting.IsEnabled);
                setting.IsEnabled = false;

                await service.SetConfigurationSettingAsync(setting);

                settingResponse = await service.GetConfigurationSettingAsync(setting.Key);
                setting = (FeatureFlagConfigurationSetting) settingResponse.Value;

                Assert.IsInstanceOf<FeatureFlagConfigurationSetting>(settingResponse.Value);
                Assert.AreEqual("Feature description", setting.Description);
                Assert.AreEqual("Feature display name", setting.DisplayName);
                Assert.AreEqual(2, setting.ClientFilters.Count);
                var filter1 = setting.ClientFilters[0];
                Assert.AreEqual("FilterA", filter1.Name);
                var filter2 = setting.ClientFilters[1];
                Assert.AreEqual("Microsoft.TimeWindow", filter2.Name);
                Assert.AreEqual(new Dictionary<string, object>()
                {
                    { "Start", "Wed, 01 May 2019 13:59:59 GMT" },
                    { "End", "Mon, 01 July 2019 00:00:00 GMT" }
                }, filter2.Parameters);
                Assert.False(setting.IsEnabled);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting));
            }
        }

        [RecordedTest]
        public async Task CanAddAndGetMultipleFeatureFlags()
        {
            ConfigurationClient service = GetClient();

            var testSetting1 = new FeatureFlagConfigurationSetting(GenerateKeyId("feature 1-2"), true)
            {
                Description = "Feature description"
            };
            var testSetting2 = new FeatureFlagConfigurationSetting(GenerateKeyId("feature 1-1"), true)
            {
                Description = "Feature description"
            };

            try
            {
                await service.AddConfigurationSettingAsync(testSetting1);
                await service.AddConfigurationSettingAsync(testSetting2);

                var selectedSettings = await service.GetConfigurationSettingsAsync(
                    new SettingSelector() { KeyFilter = FeatureFlagConfigurationSetting.KeyPrefix + "feature 1-*"})
                    .ToEnumerableAsync();

                Assert.AreEqual(2, selectedSettings.Count);
                foreach (var setting in selectedSettings)
                {
                    FeatureFlagConfigurationSetting featureFlag = (FeatureFlagConfigurationSetting) setting;
                    Assert.AreEqual("Feature description", featureFlag.Description);
                }
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting1));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting2));
            }
        }

        [RecordedTest]
        public async Task CanAddAndGetSecretReference()
        {
            ConfigurationClient service = GetClient();
            var testSetting = new SecretReferenceConfigurationSetting(GenerateKeyId("secret"), new Uri("http://secret1.com/"));

            try
            {
                var settingResponse = await service.AddConfigurationSettingAsync(testSetting);
                var setting = settingResponse.Value;

                Assert.IsInstanceOf<SecretReferenceConfigurationSetting>(setting);
                Assert.AreEqual(testSetting.Key, setting.Key);
                Assert.AreEqual(testSetting.Value, setting.Value);
                Assert.AreEqual("http://secret1.com/", ((SecretReferenceConfigurationSetting)setting).SecretId.AbsoluteUri);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting));
            }
        }

        [RecordedTest]
        public async Task CanAddAndUpdateSecretReference()
        {
            ConfigurationClient service = GetClient();
            var testSetting = new SecretReferenceConfigurationSetting(GenerateKeyId("secret"), new Uri("http://secret1.com/"));

            try
            {
                var settingResponse = await service.AddConfigurationSettingAsync(testSetting);

                var setting = (SecretReferenceConfigurationSetting) settingResponse.Value;
                setting.SecretId = new Uri("http://secret2.com/");

                await service.SetConfigurationSettingAsync(setting);

                settingResponse = await service.GetConfigurationSettingAsync(setting.Key);
                setting = (SecretReferenceConfigurationSetting) settingResponse.Value;

                Assert.IsInstanceOf<SecretReferenceConfigurationSetting>(settingResponse.Value);
                Assert.AreEqual("http://secret2.com/", setting.SecretId.AbsoluteUri);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting));
            }
        }

        [RecordedTest]
        public async Task CanAddAndGetMultipleSecretReferences()
        {
            ConfigurationClient service = GetClient();

            var testSetting1 = new SecretReferenceConfigurationSetting(GenerateKeyId("secret 1-1"), new Uri("http://secret1.com/"));
            var testSetting2 = new SecretReferenceConfigurationSetting(GenerateKeyId("secret 1-2"), new Uri("http://secret2.com/"));

            try
            {
                await service.AddConfigurationSettingAsync(testSetting1);
                await service.AddConfigurationSettingAsync(testSetting2);

                var selectedSettings = await service.GetConfigurationSettingsAsync(
                    new SettingSelector() { KeyFilter = "secret 1-*"})
                    .ToEnumerableAsync();

                Assert.AreEqual(2, selectedSettings.Count);
                foreach (var setting in selectedSettings)
                {
                    SecretReferenceConfigurationSetting featureFlag = (SecretReferenceConfigurationSetting) setting;
                    StringAssert.StartsWith("http://secret", featureFlag.SecretId.AbsoluteUri);
                    StringAssert.EndsWith(".com/", featureFlag.SecretId.AbsoluteUri);
                }
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting1));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting2));
            }
        }

        [RecordedTest]
        public async Task CanModifyTheFilterParameterValues()
        {
            ConfigurationClient service = GetClient();

            var testSetting1 = new FeatureFlagConfigurationSetting(GenerateKeyId(), true)
            {
                FeatureId = "my_feature",
                ClientFilters =
                {
                    new FeatureFlagFilter("Microsoft.Targeting", new Dictionary<string, object>()
                    {
                        {"Audience", new Dictionary<string, object>()
                            {
                                {
                                    "Groups", new List<object>()
                                    {
                                        new Dictionary<string, object>()
                                        {
                                            {"Name", "Group1"},
                                            {"RolloutPercentage", 100},
                                        }
                                    }
                                }
                            }}
                    })
                }
            };

            try
            {
                await service.AddConfigurationSettingAsync(testSetting1);

                var selectedSetting = (FeatureFlagConfigurationSetting)await service.GetConfigurationSettingAsync(testSetting1.Key);
                var audience = (IDictionary) selectedSetting.ClientFilters[0].Parameters["Audience"];
                var groups = (IList) audience["Groups"];

                groups.Add(new Dictionary<string, object>()
                {
                    {"Name", "Group2"},
                    {"RolloutPercentage", 50},
                });

                var resultingSetting = await service.SetConfigurationSettingAsync(selectedSetting);
                Assert.AreEqual("{\"id\":\"my_feature\",\"enabled\":true,\"conditions\":{\"client_filters\":[{\"name\":\"Microsoft.Targeting\",\"parameters\":{\"Audience\":{\"Groups\":[{\"Name\":\"Group1\",\"RolloutPercentage\":100},{\"Name\":\"Group2\",\"RolloutPercentage\":50}]}}}]}}", resultingSetting.Value.Value);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting1));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
        public async Task CreateSnapshotUsingAutomaticPolling()
        {
            var service = GetClient();
            var testSetting = CreateSetting();

            try
            {
                await service.AddConfigurationSettingAsync(testSetting);

                var settingsFilter = new List<ConfigurationSettingsFilter>(new ConfigurationSettingsFilter[] { new ConfigurationSettingsFilter(testSetting.Key) });
                var settingsSnapshot = new ConfigurationSnapshot(settingsFilter);

                var snapshotName = GenerateSnapshotName();
                var operation = await service.CreateSnapshotAsync(WaitUntil.Completed, snapshotName, settingsSnapshot);
                ValidateCompletedOperation(operation);
                var createdSnapshot = operation.Value;

                var retrievedSnapshot = await service.GetSnapshotAsync(snapshotName);
                ValidateCreatedSnapshot(createdSnapshot, retrievedSnapshot, snapshotName);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
        public async Task CreateSnapshotUsingWaitForCompletion()
        {
            var service = GetClient();
            var testSetting = CreateSetting();

            try
            {
                await service.AddConfigurationSettingAsync(testSetting);

                var settingsFilter = new List<ConfigurationSettingsFilter>(new ConfigurationSettingsFilter[] { new ConfigurationSettingsFilter(testSetting.Key) });
                var settingsSnapshot = new ConfigurationSnapshot(settingsFilter);

                var snapshotName = GenerateSnapshotName();
                var operation = await service.CreateSnapshotAsync(WaitUntil.Started, snapshotName, settingsSnapshot);
                await operation.WaitForCompletionAsync().ConfigureAwait(false);
                ValidateCompletedOperation(operation);
                var createdSnapshot = operation.Value;

                var retrievedSnapshot = await service.GetSnapshotAsync(snapshotName);
                ValidateCreatedSnapshot(createdSnapshot, retrievedSnapshot, snapshotName);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        // Validates that the snapshot is successfully created for the settings that match the key and tags filter. In
        // addition, the settings' filters are validated in the created snapshot.
        [RecordedTest]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_11_01)]
        public async Task CreateSnapshotWithTagsUsingWaitForCompletion()
        {
            var service = GetClient();
            var testSetting = CreateSetting();

            try
            {
                await service.AddConfigurationSettingAsync(testSetting);
                var settingsFilter = new ConfigurationSettingsFilter(testSetting.Key);

                foreach (var tag in testSetting.Tags)
                {
                    var parsedTag = $"{tag.Key}={tag.Value}";
                    settingsFilter.Tags.Add(parsedTag);
                }

                var settingsFilters = new List<ConfigurationSettingsFilter>(
                    new ConfigurationSettingsFilter[]
                    {
                        settingsFilter
                    });
                var settingsSnapshot = new ConfigurationSnapshot(settingsFilters);

                var snapshotName = GenerateSnapshotName();
                var operation = await service.CreateSnapshotAsync(WaitUntil.Started, snapshotName, settingsSnapshot);
                await operation.WaitForCompletionAsync().ConfigureAwait(false);
                ValidateCompletedOperation(operation);
                var createdSnapshot = operation.Value;

                var retrievedSnapshot = await service.GetSnapshotAsync(snapshotName);
                ValidateCreatedSnapshot(createdSnapshot, retrievedSnapshot, snapshotName);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
        public async Task CreateSnapshotUsingManualPolling()
        {
            var service = GetClient();
            var testSetting = CreateSetting();

            try
            {
                await service.AddConfigurationSettingAsync(testSetting);

                var settingsFilter = new List<ConfigurationSettingsFilter>(new ConfigurationSettingsFilter[] { new ConfigurationSettingsFilter(testSetting.Key) });
                var settingsSnapshot = new ConfigurationSnapshot(settingsFilter);

                var snapshotName = GenerateSnapshotName();
                var operation = await service.CreateSnapshotAsync(WaitUntil.Started, snapshotName, settingsSnapshot);
                while (true)
                {
                    await operation.UpdateStatusAsync();
                    if (operation.HasCompleted)
                    {
                        ValidateCompletedOperation(operation);
                        break;
                    }
                    await Delay(125);
                }
                var createdSnapshot = operation.Value;

                var retrievedSnapshot = await service.GetSnapshotAsync(snapshotName);
                ValidateCreatedSnapshot(createdSnapshot, retrievedSnapshot, snapshotName);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
        public async Task CreateSnapshotUsingWildCardKeyFilter()
        {
            var service = GetClient();
            var key1 = GenerateKeyId("Key-1");
            var key2 = GenerateKeyId("Key-2");
            var key3 = GenerateKeyId("Key1");
            var key4 = GenerateKeyId("Key2");
            var firstSetting = new ConfigurationSetting(key1, "value1");
            var secondSetting = new ConfigurationSetting(key2, "value2");
            var thirdSetting = new ConfigurationSetting(key3, "value3");
            var fourthSetting = new ConfigurationSetting(key4, "value4");

            try
            {
                await service.AddConfigurationSettingAsync(firstSetting);
                await service.AddConfigurationSettingAsync(secondSetting);
                await service.AddConfigurationSettingAsync(thirdSetting);
                await service.AddConfigurationSettingAsync(fourthSetting);

                var settingsFilter = new List<ConfigurationSettingsFilter>(new ConfigurationSettingsFilter[] { new ConfigurationSettingsFilter("Key-*") });
                var snapshotName = GenerateSnapshotName();
                var operation = await service.CreateSnapshotAsync(WaitUntil.Completed, snapshotName, new ConfigurationSnapshot(settingsFilter));
                ValidateCompletedOperation(operation);

                ConfigurationSetting[] settings = (await service.GetConfigurationSettingsForSnapshotAsync(snapshotName, CancellationToken.None).ToEnumerableAsync()).ToArray();
                Assert.GreaterOrEqual(2, settings.Count());

                Assert.AreEqual(key1, settings[0].Key);
                Assert.AreEqual(key2, settings[1].Key);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(firstSetting.Key, firstSetting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(secondSetting.Key, secondSetting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(thirdSetting.Key, thirdSetting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(fourthSetting.Key, fourthSetting.Label));
            }
        }

        // Validates that the snapshots are created for the settings that match the key and tags filter.
        [RecordedTest]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_11_01)]
        public async Task CreateSnapshotUsingTags()
        {
            var service = GetClient();
            var key1 = GenerateKeyId("KeyBar-1");
            var key2 = GenerateKeyId("KeyBar-2");
            var key3 = GenerateKeyId("KeyBar-3");
            var key4 = GenerateKeyId("Key1");
            var expectedTags = new Dictionary<string, string>
            {
                { "foo", "bartemp1" }
            };
            var firstSetting = new ConfigurationSetting(key1, "value1")
            {
                Tags = expectedTags
            };
            var secondSetting = new ConfigurationSetting(key2, "value2")
            {
                Tags = expectedTags
            };
            var thirdSetting = new ConfigurationSetting(key3, "value3")
            {
                Tags = expectedTags
            };
            var fourthSetting = new ConfigurationSetting(key4, "value4");

            try
            {
                await service.AddConfigurationSettingAsync(firstSetting);
                await service.AddConfigurationSettingAsync(secondSetting);
                await service.AddConfigurationSettingAsync(thirdSetting);
                await service.AddConfigurationSettingAsync(fourthSetting);

                var settingsFilter = new ConfigurationSettingsFilter("KeyBar-*");
                foreach (var tag in expectedTags)
                {
                    var parsedTag = $"{tag.Key}={tag.Value}";
                    settingsFilter.Tags.Add(parsedTag);
                }

                var settingsFilters = new List<ConfigurationSettingsFilter>(new ConfigurationSettingsFilter[]
                {
                    settingsFilter
                });
                var snapshotName = GenerateSnapshotName();
                var operation = await service.CreateSnapshotAsync(WaitUntil.Completed, snapshotName, new ConfigurationSnapshot(settingsFilters));
                ValidateCompletedOperation(operation);

                ConfigurationSetting[] settings = (await service.GetConfigurationSettingsForSnapshotAsync(snapshotName, CancellationToken.None).ToEnumerableAsync()).ToArray();
                Assert.AreEqual(3, settings.Count());

                Assert.AreEqual(key1, settings[0].Key);
                Assert.AreEqual(key2, settings[1].Key);
                Assert.AreEqual(key3, settings[2].Key);
                Assert.AreEqual(expectedTags, settings[0].Tags);
                Assert.AreEqual(expectedTags, settings[1].Tags);
                Assert.AreEqual(expectedTags, settings[2].Tags);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(firstSetting.Key, firstSetting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(secondSetting.Key, secondSetting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(thirdSetting.Key, thirdSetting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(fourthSetting.Key, fourthSetting.Label));
            }
        }

        // Validates that a snapshot is not created for a setting when the filter does not match any existing setting.
        [RecordedTest]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_11_01)]
        public async Task CreateSnapshotUsingTagsNoMatchingSetting()
        {
            var service = GetClient();
            var key1 = GenerateKeyId("KeyBar-1");
            var key2 = GenerateKeyId("KeyBar-2");
            var key3 = GenerateKeyId("KeyBar-3");
            var key4 = GenerateKeyId("KeyBar-4");
            var expectedTags = new Dictionary<string, string>
            {
                { "foo", "bar" }
            };
            var firstSetting = new ConfigurationSetting(key1, "value1")
            {
                Tags = expectedTags
            };
            var secondSetting = new ConfigurationSetting(key2, "value2")
            {
                Tags = expectedTags
            };
            var thirdSetting = new ConfigurationSetting(key3, "value3")
            {
                Tags = expectedTags
            };
            var fourthSetting = new ConfigurationSetting(key4, "value4");

            try
            {
                await service.AddConfigurationSettingAsync(firstSetting);
                await service.AddConfigurationSettingAsync(secondSetting);
                await service.AddConfigurationSettingAsync(thirdSetting);
                await service.AddConfigurationSettingAsync(fourthSetting);

                var settingFilter = new ConfigurationSettingsFilter("KeyBar-*");
                settingFilter.Tags.Add("uknown=tag");

                var settingsFilters = new List<ConfigurationSettingsFilter>(new ConfigurationSettingsFilter[]
                {
                    settingFilter
                });
                var snapshotName = GenerateSnapshotName();
                var operation = await service.CreateSnapshotAsync(WaitUntil.Completed, snapshotName, new ConfigurationSnapshot(settingsFilters));
                ValidateCompletedOperation(operation);

                ConfigurationSetting[] settings = (await service.GetConfigurationSettingsForSnapshotAsync(snapshotName, CancellationToken.None).ToEnumerableAsync()).ToArray();
                Assert.AreEqual(0, settings.Count());
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(firstSetting.Key, firstSetting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(secondSetting.Key, secondSetting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(thirdSetting.Key, thirdSetting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(fourthSetting.Key, fourthSetting.Label));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
        public async Task ArchiveSnapshotStatus()
        {
            var service = GetClient();
            var testSetting = CreateSetting();

            try
            {
                await service.AddConfigurationSettingAsync(testSetting);

                var settingsFilter = new List<ConfigurationSettingsFilter>(new ConfigurationSettingsFilter[] { new ConfigurationSettingsFilter(testSetting.Key) });
                var settingsSnapshot = new ConfigurationSnapshot(settingsFilter);

                var snapshotName = GenerateSnapshotName();
                var operation = await service.CreateSnapshotAsync(WaitUntil.Completed, snapshotName, settingsSnapshot);
                ValidateCompletedOperation(operation);
                var createdSnapshot = operation.Value;

                var retrievedSnapshot = await service.GetSnapshotAsync(snapshotName);
                ValidateCreatedSnapshot(createdSnapshot, retrievedSnapshot, snapshotName);

                ConfigurationSnapshot archivedSnapshot = await service.ArchiveSnapshotAsync(snapshotName);
                Assert.NotNull(archivedSnapshot);
                Assert.AreEqual(ConfigurationSnapshotStatus.Archived, archivedSnapshot.Status);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
        public async Task RecoverSnapshotStatus()
        {
            var service = GetClient();
            var testSetting = CreateSetting();

            try
            {
                await service.AddConfigurationSettingAsync(testSetting);

                var settingsFilter = new List<ConfigurationSettingsFilter>(new ConfigurationSettingsFilter[] { new ConfigurationSettingsFilter(testSetting.Key) });
                var settingsSnapshot = new ConfigurationSnapshot(settingsFilter);

                var snapshotName = GenerateSnapshotName();
                var operation = await service.CreateSnapshotAsync(WaitUntil.Completed, snapshotName, settingsSnapshot);
                ValidateCompletedOperation(operation);
                var createdSnapshot = operation.Value;

                var retrievedSnapshot = await service.GetSnapshotAsync(snapshotName);
                ValidateCreatedSnapshot(createdSnapshot, retrievedSnapshot, snapshotName);

                ConfigurationSnapshot archivedSnapshot = await service.ArchiveSnapshotAsync(snapshotName);
                Assert.NotNull(archivedSnapshot);
                Assert.AreEqual(ConfigurationSnapshotStatus.Archived, archivedSnapshot.Status);

                ConfigurationSnapshot recoveredSnapshot = await service.RecoverSnapshotAsync(snapshotName);
                Assert.NotNull(recoveredSnapshot);
                Assert.AreEqual(ConfigurationSnapshotStatus.Ready, recoveredSnapshot.Status);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
        public async Task GetSnapshots()
        {
            var service = GetClient();
            var firstSetting = new ConfigurationSetting("first_key", "first_value");
            var secondSetting = new ConfigurationSetting("second_key", "second_value");

            try
            {
                await service.AddConfigurationSettingAsync(firstSetting);
                await service.AddConfigurationSettingAsync(secondSetting);

                var firstSnapshotFilter = new List<ConfigurationSettingsFilter>(new ConfigurationSettingsFilter[] { new ConfigurationSettingsFilter(firstSetting.Key) });
                var firstSnapshotName = GenerateSnapshotName("first_snapshot");
                var firstOperation = await service.CreateSnapshotAsync(WaitUntil.Completed, firstSnapshotName, new ConfigurationSnapshot(firstSnapshotFilter));
                ValidateCompletedOperation(firstOperation);

                var secondSnapshotFilter = new List<ConfigurationSettingsFilter>(new ConfigurationSettingsFilter[] { new ConfigurationSettingsFilter(secondSetting.Key) });
                var secondSnapshotName = GenerateSnapshotName("second_snapshot");
                var secondOperation = await service.CreateSnapshotAsync(WaitUntil.Completed, secondSnapshotName, new ConfigurationSnapshot(secondSnapshotFilter));
                ValidateCompletedOperation(secondOperation);

                var selector = new SnapshotSelector();
                var snapshots = service.GetSnapshotsAsync(selector);
                var resultsReturned = (await snapshots.ToEnumerableAsync()).Count;
                Assert.GreaterOrEqual(resultsReturned, 2);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(firstSetting.Key, firstSetting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(secondSetting.Key, secondSetting.Label));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
        public async Task GetSnapshotsUsingNameFilter()
        {
            var service = GetClient();
            var firstSetting = new ConfigurationSetting("first_key", "first_value");
            var secondSetting = new ConfigurationSetting("second_key", "second_value");

            try
            {
                await service.AddConfigurationSettingAsync(firstSetting);
                await service.AddConfigurationSettingAsync(secondSetting);

                var firstSnapshotFilter = new List<ConfigurationSettingsFilter>(new ConfigurationSettingsFilter[] { new ConfigurationSettingsFilter(firstSetting.Key) });
                var firstSnapshotName = GenerateSnapshotName("first_snapshot");
                var firstOperation = await service.CreateSnapshotAsync(WaitUntil.Completed, firstSnapshotName, new ConfigurationSnapshot(firstSnapshotFilter));
                ValidateCompletedOperation(firstOperation);

                var secondSnapshotFilter = new List<ConfigurationSettingsFilter>(new ConfigurationSettingsFilter[] { new ConfigurationSettingsFilter(secondSetting.Key) });
                var secondSnapshotName = GenerateSnapshotName("second_snapshot");
                var secondOperation = await service.CreateSnapshotAsync(WaitUntil.Completed, secondSnapshotName, new ConfigurationSnapshot(secondSnapshotFilter));
                ValidateCompletedOperation(secondOperation);

                var selector = new SnapshotSelector()
                {
                    NameFilter = firstSnapshotName
                };

                ConfigurationSnapshot[] batch = (await service.GetSnapshotsAsync(selector).ToEnumerableAsync()).ToArray();

                Assert.AreEqual(1, batch.Length);
                Assert.AreEqual(firstSnapshotName, batch[0].Name);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(firstSetting.Key, firstSetting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(secondSetting.Key, secondSetting.Label));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
        public async Task GetConfigurationSettingsForSnapshot()
        {
            var service = GetClient();
            var setting = new ConfigurationSetting("Test_Key", "Test_Value");

            try
            {
                await service.AddConfigurationSettingAsync(setting);

                var settingsFilter = new List<ConfigurationSettingsFilter>(new ConfigurationSettingsFilter[] { new ConfigurationSettingsFilter(setting.Key) });
                var snapshotName = GenerateSnapshotName();
                var operation = await service.CreateSnapshotAsync(WaitUntil.Completed, snapshotName, new ConfigurationSnapshot(settingsFilter));
                ValidateCompletedOperation(operation);

                var settingsForSnapshot = service.GetConfigurationSettingsForSnapshotAsync(snapshotName);
                var settingscount = (await settingsForSnapshot.ToEnumerableAsync()).Count;
                Assert.GreaterOrEqual(settingscount, 1);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(setting.Key));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
        public async Task UnchangedSnapshotAfterSettingsUpdate()
        {
            var service = GetClient();
            var setting = new ConfigurationSetting("Test_Key", "Test_Value");

            try
            {
                ConfigurationSetting createdSetting = await service.AddConfigurationSettingAsync(setting);

                var settingsFilter = new List<ConfigurationSettingsFilter>(new ConfigurationSettingsFilter[] { new ConfigurationSettingsFilter(createdSetting.Key) });
                var snapshotName = GenerateSnapshotName();
                var operation = await service.CreateSnapshotAsync(WaitUntil.Completed, snapshotName, new ConfigurationSnapshot(settingsFilter));
                ValidateCompletedOperation(operation);

                setting.Value = "Updated_Value";
                await service.SetConfigurationSettingAsync(setting);

                var settingsForSnapshot = service.GetConfigurationSettingsForSnapshotAsync(snapshotName);
                var settings = await settingsForSnapshot.ToEnumerableAsync();
                Assert.GreaterOrEqual(settings.Count, 1);

                var settingForSnapshot = settings.FirstOrDefault();
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(createdSetting, settingForSnapshot));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(setting.Key));
            }
        }

        // This test validates that a label is successfully retrieved by name.
        [RecordedTest]
        public async Task GetLabelByName()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            //Prepare environment
            ConfigurationSetting setting = testSetting;

            try
            {
                await service.SetConfigurationSettingAsync(setting);
                var selector = new SettingLabelSelector()
                {
                    NameFilter = setting.Label
                };

                int resultsReturned = 0;
                int expectedLabels = 1;
                await foreach (SettingLabel label in service.GetLabelsAsync(selector, CancellationToken.None))
                {
                    Assert.AreEqual(setting.Label, label.Name);
                    resultsReturned++;
                }

                Assert.AreEqual(expectedLabels, resultsReturned);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(setting.Key, setting.Label));
            }
        }

        // This test validates that all the labels for a set of settings are successfully retrieved by name.
        [RecordedTest]
        [TestCase("*")]
        [TestCase("")]
        public async Task GetAllLabels(string delimiter)
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting1 = CreateSetting();
            ConfigurationSetting testSetting2 = testSetting1.Clone();
            testSetting2.Key = GenerateKeyId("key-");
            testSetting2.Label = $"{testSetting1.Label}_update";

            try
            {
                await service.SetConfigurationSettingAsync(testSetting1);
                await service.SetConfigurationSettingAsync(testSetting2);

                // match all labels that start with the label of the first setting
                SettingLabelSelector selector = new SettingLabelSelector();
                if (!string.IsNullOrEmpty(delimiter))
                {
                    selector = new SettingLabelSelector()
                    {
                        NameFilter = delimiter
                    };
                }

                var labels = await service.GetLabelsAsync(selector, CancellationToken.None).ToEnumerableAsync();
                Assert.GreaterOrEqual(labels.Count, 2);

                bool foundLabel1 = false;
                bool foundLabel2 = false;
                foreach (SettingLabel label in labels)
                {
                    if (foundLabel1 && foundLabel2)
                    {
                        break;
                    }

                    if (label.Name == testSetting1.Label)
                    {
                        foundLabel1 = true;
                    }
                    else if (label.Name == testSetting2.Label)
                    {
                        foundLabel2 = true;
                    }
                }

                Assert.IsTrue(foundLabel1);
                Assert.IsTrue(foundLabel2);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting1.Key, testSetting1.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting2.Key, testSetting2.Label));
            }
        }

        // This test validates that the labels for a set of settings are successfully retrieved by keyword.
        [RecordedTest]
        public async Task GetLabelsStartsWith()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting1 = CreateSetting("abcde", "sample value", "abcde");
            ConfigurationSetting testSetting2 = CreateSetting("abcdef", "sample value", "abcdef");

            try
            {
                await service.SetConfigurationSettingAsync(testSetting1);
                await service.SetConfigurationSettingAsync(testSetting2);

                var selector = new SettingLabelSelector()
                {
                    NameFilter = "abc*"
                };

                List<SettingLabel> labels = await service.GetLabelsAsync(selector, CancellationToken.None).ToEnumerableAsync();

                // There should be at least one label retrieved.
                CollectionAssert.IsNotEmpty(labels);

                foreach (SettingLabel label in labels)
                {
                    StringAssert.StartsWith("abc", label.Name);
                }
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting1.Key, testSetting1.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting2.Key, testSetting2.Label));
            }
        }

        [RecordedTest]
        public async Task GetLabelsWithCommaInSelectorKey()
        {
            ConfigurationClient service = GetClient();

            ConfigurationSetting abcSetting = new ConfigurationSetting("abcd", "comma in label", "ab,cd");
            ConfigurationSetting xyzSetting = new ConfigurationSetting("wxyz", "comma in label", "wx,yz");

            try
            {
                await service.SetConfigurationSettingAsync(abcSetting);
                await service.SetConfigurationSettingAsync(xyzSetting);

                var selector = new SettingLabelSelector()
                {
                    NameFilter = @"ab\,cd,wx\,yz"
                };

                SettingLabel[] labels = (await service.GetLabelsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                Assert.GreaterOrEqual(2, labels.Length);
                Assert.IsTrue(labels.Any(l => l.Name == "ab,cd"));
                Assert.IsTrue(labels.Any(l => l.Name == "wx,yz"));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(abcSetting.Key, abcSetting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(xyzSetting.Key, xyzSetting.Label));
            }
        }

        // This test validates that the labels for a set of settings are successfully using the OR delimiter.
        [RecordedTest]
        public async Task GetLabelsByOr()
        {
            ConfigurationClient service = GetClient();

            ConfigurationSetting abcSetting = new ConfigurationSetting("key-abc", "abc setting", "abc");
            ConfigurationSetting xyzSetting = new ConfigurationSetting("label-xyz", "xyz setting", "xyz");

            try
            {
                await service.SetConfigurationSettingAsync(abcSetting);
                await service.SetConfigurationSettingAsync(xyzSetting);

                var selector = new SettingLabelSelector()
                {
                    NameFilter = "abc,xyz"
                };

                SettingLabel[] labels = (await service.GetLabelsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                Assert.GreaterOrEqual(2, labels.Length);
                Assert.IsTrue(labels.Any(l => l.Name == "abc"));
                Assert.IsTrue(labels.Any(l => l.Name == "xyz"));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(abcSetting.Key, abcSetting.Label));
                AssertStatus200(await service.DeleteConfigurationSettingAsync(xyzSetting.Key, xyzSetting.Label));
            }
        }

        // This test validates that the labels for multiple settings are retrieved successfully from a paginated response.
        [RecordedTest]
        public async Task GetLabelsPagination()
        {
            ConfigurationClient service = GetClient();

            const int expectedEvents = 106;
            var labelPrefix = await SetMultipleKeysWithLabels(service, expectedEvents);

            int resultsReturned = 0;
            var selector = new SettingLabelSelector()
            {
                NameFilter = labelPrefix + "*"
            };

            await foreach (SettingLabel label in service.GetLabelsAsync(selector, CancellationToken.None))
            {
                StringAssert.StartsWith(labelPrefix, label.Name);
                resultsReturned++;
            }

            Assert.AreEqual(expectedEvents, resultsReturned);
        }

        [RecordedTest]
        public async Task GetLabelsWithFields()
        {
            ConfigurationClient service = GetClient();

            string key = GenerateKeyId("keyFields-");
            ConfigurationSetting setting = await service.AddConfigurationSettingAsync(key, "my_value", "my_label");

            try
            {
                var fieldSelector = SettingLabelFields.Name;
                var selector = new SettingLabelSelector()
                {
                    NameFilter = setting.Label
                };
                selector.Fields.Add(fieldSelector);

                SettingLabel[] labels = (await service.GetLabelsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                Assert.AreEqual(1, labels.Length);

                Assert.IsNotNull(labels[0].Name);
                Assert.AreEqual(setting.Label, labels[0].Name);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(setting.Key, setting.Label));
            }
        }

        // This test validates that a label is successfully retrieved by name, but it's name field is not populated
        // because it is not included in the fields selector.
        [RecordedTest]
        public async Task GetLabelsWithFieldsCustomField()
        {
            ConfigurationClient service = GetClient();

            string key = GenerateKeyId("keyFields-");
            ConfigurationSetting setting = await service.AddConfigurationSettingAsync(key, "my_value", "my_label");

            try
            {
                var unknownFieldSelector1 = new SettingLabelFields("uknown_field");
                var unknownFieldSelector2 = new SettingLabelFields("unknown_field2");
                var selector = new SettingLabelSelector()
                {
                    NameFilter = setting.Label
                };
                selector.Fields.Add(unknownFieldSelector1);
                selector.Fields.Add(unknownFieldSelector2);

                SettingLabel[] labels = (await service.GetLabelsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                Assert.AreEqual(1, labels.Length);
                Assert.IsNull(labels[0].Name);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(setting.Key, setting.Label));
            }
        }

        [RecordedTest]
        public async Task GetLabelsWithAcceptDateTime()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.SetConfigurationSettingAsync(testSetting);
                var selector = new SettingLabelSelector()
                {
                    NameFilter = testSetting.Label,
                    AcceptDateTime = DateTimeOffset.MaxValue
                };

                SettingLabel[] labels = (await service.GetLabelsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                Assert.AreEqual(1, labels.Length);
                Assert.AreEqual(testSetting.Label, labels[0].Name);
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        private void ValidateCreatedSnapshot(ConfigurationSnapshot createdSnapshot, ConfigurationSnapshot retrievedSnapshot, string expectedName)
        {
            Assert.NotNull(createdSnapshot);
            Assert.AreEqual(expectedName, createdSnapshot.Name);

            Assert.NotNull(retrievedSnapshot);
            Assert.AreEqual(createdSnapshot.Name, retrievedSnapshot.Name);

            // validate retrieved filters
            if (createdSnapshot.Filters != null)
            {
                Assert.NotNull(retrievedSnapshot.Filters);
                Assert.AreEqual(createdSnapshot.Filters.Count, retrievedSnapshot.Filters.Count);
                for (int i = 0; i < createdSnapshot.Filters.Count; i++)
                {
                    Assert.AreEqual(createdSnapshot.Filters[i].Key, retrievedSnapshot.Filters[i].Key);
                    Assert.AreEqual(createdSnapshot.Filters[i].Tags, retrievedSnapshot.Filters[i].Tags);
                }
            }
        }

        private static void ValidateCompletedOperation(CreateSnapshotOperation operation)
        {
            Assert.IsTrue(operation.HasValue);
            Assert.IsTrue(operation.HasCompleted);
            Assert.NotNull(operation.Id);
        }

        private static void AssertStatus200(Response response) => Assert.AreEqual(200, response.Status);
    }
}
