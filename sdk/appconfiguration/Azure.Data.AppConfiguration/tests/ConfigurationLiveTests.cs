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
                Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting), Is.True);
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
                Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting), Is.True);
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

            Assert.That(response.Status, Is.EqualTo(204));
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

                Assert.That(e.Status, Is.EqualTo(404));
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

                Assert.That(e.Status, Is.EqualTo(404));
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
                Assert.That(exception.Status, Is.EqualTo(409));
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
                Assert.That(exception.Status, Is.EqualTo(412));
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
                Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting), Is.True);
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
                Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting), Is.True);
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
                Assert.That(exception.Status, Is.EqualTo(409));
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
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Value, Is.EqualTo(setting.Value));
                Assert.That(response.Value.ETag, Is.Not.EqualTo(setting.ETag));
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
                Assert.That(exception.Status, Is.EqualTo(412));
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

                Assert.That(setting.Key, Is.EqualTo(key));
                Assert.That(setting.Value, Is.EqualTo(value));
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

                Assert.That(setting.Key, Is.EqualTo(key));
                Assert.That(setting.Value, Is.EqualTo(value));
                Assert.That(setting.Label, Is.EqualTo(label));
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
                Assert.That(requestId, Is.Not.Empty);
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

                Assert.That(exception.Status, Is.EqualTo(412));
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
                Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting), Is.True);
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
                Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(testSettingNoLabel, setting), Is.True);
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

                Assert.That(setting.Key, Is.EqualTo(key));
                Assert.That(setting.Value, Is.EqualTo(value));
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

                Assert.That(setting.Key, Is.EqualTo(key));
                Assert.That(setting.Value, Is.EqualTo(value));
                Assert.That(setting.Label, Is.EqualTo(label));
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
                        Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(value, testSettingUpdate), Is.True);
                    }
                    else
                    {
                        Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(value, setting), Is.True);
                    }
                    resultsReturned++;
                }

                Assert.That(resultsReturned, Is.EqualTo(expectedEvents));
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
                        Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(value, testSettingUpdate), Is.True);
                    }
                    else
                    {
                        Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(value, setting), Is.True);
                    }
                    resultsReturned++;
                }

                Assert.That(resultsReturned, Is.EqualTo(expectedRevisions));
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
                    Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(value, testSettingUpdate), Is.True);
                    resultsReturned++;
                }

                Assert.That(resultsReturned, Is.EqualTo(1));
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
                Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(testSettingNoLabel, setting), Is.True);
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

            Assert.That(exception.Status, Is.EqualTo(404));
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
                Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, responseSetting), Is.True);
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

                Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, responseSetting), Is.True);
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

                Assert.That(exception.Status, Is.EqualTo(412));
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

                Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, responseSetting), Is.True);
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
                Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, responseSetting), Is.True);
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
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(modifiedSetting, response.Value), Is.True);
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
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(304));
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
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(304));

                bool throws = false;
                try
                {
                    ConfigurationSetting value = response.Value;
                }
                catch
                {
                    throws = true;
                }

                Assert.That(throws, Is.True);
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
                    Assert.That(response.GetRawResponse().Status, Is.EqualTo(304));
                }

                Assert.That(logMessage, Is.Null);
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
                Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(testSettingNoLabel, setting), Is.True);
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
                Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting), Is.True);
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
                Assert.That(item.Value, Is.EqualTo("test_value"));
                resultsReturned++;
            }

            Assert.That(resultsReturned, Is.EqualTo(expectedEvents));
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

                Assert.That(response.Status, Is.EqualTo(304));
                Assert.That(page.Values, Is.Empty);

                pagesCount++;
            }

            Assert.That(pagesCount, Is.EqualTo(2));
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

                Assert.That(response.Status, Is.EqualTo(304));
                Assert.That(page.Values, Is.Empty);

                pagesCount++;
            }

            Assert.That(pagesCount, Is.EqualTo(2));
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
                Assert.That(firstPage.GetRawResponse().Status, Is.EqualTo(304));
            }

            Assert.That(logMessage, Is.Null);
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
                Assert.That(firstPage.GetRawResponse().Status, Is.EqualTo(304));
            }

            Assert.That(logMessage, Is.Null);
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
                    Assert.That(response.Status, Is.EqualTo(304));
                    Assert.That(page.Values, Is.Empty);
                }
                else
                {
                    Assert.That(response.Status, Is.EqualTo(200));
                    Assert.That(page.Values, Is.Not.Empty);
                }

                pagesCount++;
            }

            Assert.That(pagesCount, Is.EqualTo(2));
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
                    Assert.That(response.Status, Is.EqualTo(304));
                    Assert.That(page.Values, Is.Empty);
                }
                else
                {
                    Assert.That(response.Status, Is.EqualTo(200));
                    Assert.That(page.Values, Is.Not.Empty);
                }

                pagesCount++;
            }

            Assert.That(pagesCount, Is.EqualTo(2));
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

                Assert.That(selector.KeyFilter, Is.EqualTo(null));
                Assert.That(selector.LabelFilter, Is.EqualTo(null));

                var resultsReturned = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).Count;

                //At least there should be one key available
                Assert.That(resultsReturned, Is.GreaterThanOrEqualTo(1));
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

                Assert.That(batch.Length, Is.EqualTo(1));
                Assert.That(batch[0].Key, Is.EqualTo(testSetting.Key));
                Assert.That(batch[0].Label, Is.EqualTo(testSetting.Label));
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

                Assert.That(batch.Length, Is.EqualTo(1));
                Assert.That(batch[0].Key, Is.EqualTo(testSetting.Key));
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

                Assert.That(selector.KeyFilter, Is.EqualTo(null));

                ConfigurationSetting[] batch = (await service.GetConfigurationSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                //At least there should be one key available
                Assert.That(batch, Is.Not.Empty);
                Assert.That(batch[0].Label, Is.EqualTo(testSetting.Label));
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

                Assert.That(batch.Length, Is.EqualTo(1));

                Assert.That(batch[0].Key, Is.Not.Null);
                Assert.That(batch[0].Label, Is.Not.Null);
                Assert.That(default(ETag), Is.Not.EqualTo(batch[0].ETag));
                Assert.That(batch[0].Value, Is.Null);
                Assert.That(batch[0].ContentType, Is.Null);
                Assert.That(batch[0].LastModified, Is.Null);
                Assert.That(batch[0].IsReadOnly, Is.Null);
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

                Assert.That(batch, Is.Not.Empty);
                Assert.That(batch[0].Key, Is.Not.Null);
                Assert.That(batch[0].IsReadOnly, Is.Not.Null);
                Assert.That(batch[0].Label, Is.Null);
                Assert.That(batch[0].Value, Is.Null);
                Assert.That(batch[0].ContentType, Is.Null);
                Assert.That(batch[0].LastModified, Is.Null);
                Assert.That(default(ETag), Is.EqualTo(batch[0].ETag));
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

                Assert.That(batch.Length, Is.EqualTo(1));

                Assert.That(batch[0].Key, Is.Not.Null);
                Assert.That(batch[0].Label, Is.Not.Null);
                Assert.That(batch[0].Value, Is.Not.Null);
                Assert.That(batch[0].ContentType, Is.Not.Null);
                Assert.That(default(ETag), Is.Not.EqualTo(batch[0].ETag));
                Assert.That(batch[0].LastModified, Is.Not.Null);
                Assert.That(batch[0].IsReadOnly, Is.Not.Null);
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

                Assert.That(batch.Length, Is.EqualTo(1));

                Assert.That(batch[0].Key, Is.Not.Null);
                Assert.That(batch[0].Label, Is.Not.Null);
                Assert.That(batch[0].Value, Is.Not.Null);
                Assert.That(batch[0].ContentType, Is.Not.Null);
                Assert.That(default(ETag), Is.Not.EqualTo(batch[0].ETag));
                Assert.That(batch[0].LastModified, Is.Not.Null);
                Assert.That(batch[0].IsReadOnly, Is.Not.Null);
                Assert.That(batch[0].Tags, Is.Not.Empty);
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
                Assert.That(settings, Is.Not.Empty);
                Assert.That(settings[0].Key, Is.EqualTo(testSetting.Key));
                Assert.That(settings[0].Label, Is.EqualTo(testSetting.Label));
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
                Assert.That(settings, Is.Not.Empty);

                foreach (ConfigurationSetting setting in settings)
                {
                    Assert.That(setting.Key, Does.StartWith("abc"));
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

                Assert.That(settings.Length, Is.EqualTo(2));
                Assert.That(settings.Any(s => s.Key == "abcd"), Is.True);
                Assert.That(settings.Any(s => s.Key == "wxyz"), Is.True);
                Assert.That(settings.Any(s => s.Tags.Any() == true), Is.True);
                Assert.That(settings.Any(s => s.Tags.SequenceEqual(expectedTags)), Is.True);
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

                Assert.That(settings.Length, Is.EqualTo(0));
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

                Assert.That(settings.Length, Is.GreaterThanOrEqualTo(2));
                Assert.That(settings.Any(s => s.Key == "ab,cd"), Is.True);
                Assert.That(settings.Any(s => s.Key == "wx,yz"), Is.True);
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

                Assert.That(settings, Is.Empty);
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

                Assert.That(settings.Length, Is.GreaterThanOrEqualTo(2));
                Assert.That(settings.Any(s => s.Key == "abc"), Is.True);
                Assert.That(settings.Any(s => s.Key == "xyz"), Is.True);
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

                Assert.That(settings.Length, Is.GreaterThanOrEqualTo(2));
                Assert.That(settings.Any(s => s.Label == "abc"), Is.True);
                Assert.That(settings.Any(s => s.Label == "xyz"), Is.True);
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
                Assert.That(readOnly.Value.IsReadOnly, Is.True);
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
                Assert.That(setting.IsReadOnly, Is.EqualTo(!isReadOnly));
                setting = await service.SetReadOnlyAsync(setting, isReadOnly, onlyIfUnchanged: true);
                Assert.That(setting.IsReadOnly, Is.EqualTo(isReadOnly));
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
                Assert.That(exception.Status, Is.EqualTo(412));
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
                Assert.That(readOnly.Value.IsReadOnly, Is.False);
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
                Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting), Is.True);
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

                Assert.That(setting, Is.InstanceOf<FeatureFlagConfigurationSetting>());
                Assert.That(setting.Key, Is.EqualTo(testSetting.Key));
                Assert.That(setting.Value, Is.EqualTo(testSetting.Value));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting));
            }
        }

        [RecordedTest]
        public async Task CanAddAndGetMinimalFeatureFlag()
        {
            ConfigurationClient service = GetClient();
            string featureId = GenerateKeyId("minimal-feature");
            string key = FeatureFlagConfigurationSetting.KeyPrefix + featureId;

            var minimalFeatureFlagSetting = new ConfigurationSetting(key, "{\"id\":\"" + featureId + "\"}")
            {
                ContentType = FeatureFlagConfigurationSetting.FeatureFlagContentType
            };

            try
            {
                var addResponse = await service.AddConfigurationSettingAsync(minimalFeatureFlagSetting);
                Assert.That(addResponse.Value.Key, Is.EqualTo(key));
                Assert.That(addResponse.Value.ContentType, Is.EqualTo(FeatureFlagConfigurationSetting.FeatureFlagContentType));

                var getResponse = await service.GetConfigurationSettingAsync(key);
                var retrievedSetting = getResponse.Value;

                Assert.That(retrievedSetting, Is.InstanceOf<FeatureFlagConfigurationSetting>());
                Assert.That(retrievedSetting.Key, Is.EqualTo(key));
                Assert.That(retrievedSetting.ContentType, Is.EqualTo(FeatureFlagConfigurationSetting.FeatureFlagContentType));

                var featureFlag = (FeatureFlagConfigurationSetting)retrievedSetting;
                Assert.That(featureFlag.FeatureId, Is.EqualTo(featureId));
                Assert.That(featureFlag.IsEnabled, Is.EqualTo(false));
                Assert.That(featureFlag.ClientFilters.Count, Is.EqualTo(0));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(key));
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
                Assert.That(setting.IsEnabled, Is.True);
                setting.IsEnabled = false;

                await service.SetConfigurationSettingAsync(setting);

                settingResponse = await service.GetConfigurationSettingAsync(setting.Key);
                setting = (FeatureFlagConfigurationSetting) settingResponse.Value;

                Assert.That(settingResponse.Value, Is.InstanceOf<FeatureFlagConfigurationSetting>());
                Assert.That(setting.Description, Is.EqualTo("Feature description"));
                Assert.That(setting.DisplayName, Is.EqualTo("Feature display name"));
                Assert.That(setting.ClientFilters.Count, Is.EqualTo(2));
                var filter1 = setting.ClientFilters[0];
                Assert.That(filter1.Name, Is.EqualTo("FilterA"));
                var filter2 = setting.ClientFilters[1];
                Assert.That(filter2.Name, Is.EqualTo("Microsoft.TimeWindow"));
                Assert.That(filter2.Parameters, Is.EqualTo(new Dictionary<string, object>()
                {
                    { "Start", "Wed, 01 May 2019 13:59:59 GMT" },
                    { "End", "Mon, 01 July 2019 00:00:00 GMT" }
                }));
                Assert.That(setting.IsEnabled, Is.False);
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

                Assert.That(selectedSettings.Count, Is.EqualTo(2));
                foreach (var setting in selectedSettings)
                {
                    FeatureFlagConfigurationSetting featureFlag = (FeatureFlagConfigurationSetting) setting;
                    Assert.That(featureFlag.Description, Is.EqualTo("Feature description"));
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

                Assert.That(setting, Is.InstanceOf<SecretReferenceConfigurationSetting>());
                Assert.That(setting.Key, Is.EqualTo(testSetting.Key));
                Assert.That(setting.Value, Is.EqualTo(testSetting.Value));
                Assert.That(((SecretReferenceConfigurationSetting)setting).SecretId.AbsoluteUri, Is.EqualTo("http://secret1.com/"));
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

                Assert.That(settingResponse.Value, Is.InstanceOf<SecretReferenceConfigurationSetting>());
                Assert.That(setting.SecretId.AbsoluteUri, Is.EqualTo("http://secret2.com/"));
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

                Assert.That(selectedSettings.Count, Is.EqualTo(2));
                foreach (var setting in selectedSettings)
                {
                    SecretReferenceConfigurationSetting featureFlag = (SecretReferenceConfigurationSetting) setting;
                    Assert.That(featureFlag.SecretId.AbsoluteUri, Does.StartWith("http://secret"));
                    Assert.That(featureFlag.SecretId.AbsoluteUri, Does.EndWith(".com/"));
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
                Assert.That(resultingSetting.Value.Value, Is.EqualTo("{\"id\":\"my_feature\",\"enabled\":true,\"conditions\":{\"client_filters\":[{\"name\":\"Microsoft.Targeting\",\"parameters\":{\"Audience\":{\"Groups\":[{\"Name\":\"Group1\",\"RolloutPercentage\":100},{\"Name\":\"Group2\",\"RolloutPercentage\":50}]}}}]}}"));
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
                Assert.That(2, Is.GreaterThanOrEqualTo(settings.Count()));

                Assert.That(settings[0].Key, Is.EqualTo(key1));
                Assert.That(settings[1].Key, Is.EqualTo(key2));
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
                Assert.That(settings.Count(), Is.EqualTo(3));

                Assert.That(settings[0].Key, Is.EqualTo(key1));
                Assert.That(settings[1].Key, Is.EqualTo(key2));
                Assert.That(settings[2].Key, Is.EqualTo(key3));
                Assert.That(settings[0].Tags, Is.EqualTo(expectedTags));
                Assert.That(settings[1].Tags, Is.EqualTo(expectedTags));
                Assert.That(settings[2].Tags, Is.EqualTo(expectedTags));
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
                Assert.That(settings.Count(), Is.EqualTo(0));
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
                Assert.That(archivedSnapshot, Is.Not.Null);
                Assert.That(archivedSnapshot.Status, Is.EqualTo(ConfigurationSnapshotStatus.Archived));
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
                Assert.That(archivedSnapshot, Is.Not.Null);
                Assert.That(archivedSnapshot.Status, Is.EqualTo(ConfigurationSnapshotStatus.Archived));

                ConfigurationSnapshot recoveredSnapshot = await service.RecoverSnapshotAsync(snapshotName);
                Assert.That(recoveredSnapshot, Is.Not.Null);
                Assert.That(recoveredSnapshot.Status, Is.EqualTo(ConfigurationSnapshotStatus.Ready));
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
                Assert.That(resultsReturned, Is.GreaterThanOrEqualTo(2));
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

                Assert.That(batch.Length, Is.EqualTo(1));
                Assert.That(batch[0].Name, Is.EqualTo(firstSnapshotName));
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
                Assert.That(settingscount, Is.GreaterThanOrEqualTo(1));
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
                Assert.That(settings.Count, Is.GreaterThanOrEqualTo(1));

                var settingForSnapshot = settings.FirstOrDefault();
                Assert.That(ConfigurationSettingEqualityComparer.Instance.Equals(createdSetting, settingForSnapshot), Is.True);
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
                    Assert.That(label.Name, Is.EqualTo(setting.Label));
                    resultsReturned++;
                }

                Assert.That(resultsReturned, Is.EqualTo(expectedLabels));
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
                Assert.That(labels.Count, Is.GreaterThanOrEqualTo(2));

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

                Assert.That(foundLabel1, Is.True);
                Assert.That(foundLabel2, Is.True);
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
                Assert.That(labels, Is.Not.Empty);

                foreach (SettingLabel label in labels)
                {
                    Assert.That(label.Name, Does.StartWith("abc"));
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

                Assert.That(2, Is.GreaterThanOrEqualTo(labels.Length));
                Assert.That(labels.Any(l => l.Name == "ab,cd"), Is.True);
                Assert.That(labels.Any(l => l.Name == "wx,yz"), Is.True);
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

                Assert.That(2, Is.GreaterThanOrEqualTo(labels.Length));
                Assert.That(labels.Any(l => l.Name == "abc"), Is.True);
                Assert.That(labels.Any(l => l.Name == "xyz"), Is.True);
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
                Assert.That(label.Name, Does.StartWith(labelPrefix));
                resultsReturned++;
            }

            Assert.That(resultsReturned, Is.EqualTo(expectedEvents));
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

                Assert.That(labels.Length, Is.EqualTo(1));

                Assert.That(labels[0].Name, Is.Not.Null);
                Assert.That(labels[0].Name, Is.EqualTo(setting.Label));
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

                Assert.That(labels.Length, Is.EqualTo(1));
                Assert.That(labels[0].Name, Is.Null);
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

                Assert.That(labels.Length, Is.EqualTo(1));
                Assert.That(labels[0].Name, Is.EqualTo(testSetting.Label));
            }
            finally
            {
                AssertStatus200(await service.DeleteConfigurationSettingAsync(testSetting.Key, testSetting.Label));
            }
        }

        private void ValidateCreatedSnapshot(ConfigurationSnapshot createdSnapshot, ConfigurationSnapshot retrievedSnapshot, string expectedName)
        {
            Assert.That(createdSnapshot, Is.Not.Null);
            Assert.That(createdSnapshot.Name, Is.EqualTo(expectedName));

            Assert.That(retrievedSnapshot, Is.Not.Null);
            Assert.That(retrievedSnapshot.Name, Is.EqualTo(createdSnapshot.Name));

            // validate retrieved filters
            if (createdSnapshot.Filters != null)
            {
                Assert.That(retrievedSnapshot.Filters, Is.Not.Null);
                Assert.That(retrievedSnapshot.Filters.Count, Is.EqualTo(createdSnapshot.Filters.Count));
                for (int i = 0; i < createdSnapshot.Filters.Count; i++)
                {
                    Assert.That(retrievedSnapshot.Filters[i].Key, Is.EqualTo(createdSnapshot.Filters[i].Key));
                    Assert.That(retrievedSnapshot.Filters[i].Tags, Is.EqualTo(createdSnapshot.Filters[i].Tags));
                }
            }
        }

        private static void ValidateCompletedOperation(CreateSnapshotOperation operation)
        {
            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Id, Is.Not.Null);
        }

        private static void AssertStatus200(Response response) => Assert.That(response.Status, Is.EqualTo(200));
    }
}
