// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    [ClientTestFixture(
        ConfigurationClientOptions.ServiceVersion.V1_0,
        ConfigurationClientOptions.ServiceVersion.V2023_10_01)]
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

        private ConfigurationClient GetClient()
        {
            if (string.IsNullOrEmpty(TestEnvironment.ConnectionString))
            {
                throw new TestRecordingMismatchException();
            }
            var options = InstrumentClientOptions(new ConfigurationClientOptions(_serviceVersion));
            return InstrumentClient(new ConfigurationClient(TestEnvironment.ConnectionString, options));
        }

        private ConfigurationClient GetAADClient()
        {
            string endpoint = TestEnvironment.Endpoint;
            TokenCredential credential = TestEnvironment.Credential;
            ConfigurationClientOptions options = InstrumentClientOptions(new ConfigurationClientOptions(_serviceVersion));
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

        private async Task<string> SetMultipleKeys(ConfigurationClient service, int expectedEvents)
        {
            string key = GenerateKeyId("key-");

            /*
             * The configuration store contains a KV with the Key
             * that represents {expectedEvents} data points.
             * If not set, create the {expectedEvents} data points and the "BatchKey"
            */
            const string batchKey = "BatchKey";

            try
            {
                Response<ConfigurationSetting> responseGet = await service.GetConfigurationSettingAsync(batchKey);
                key = responseGet.Value.Value;
            }
            catch
            {
                for (int i = 0; i < expectedEvents; i++)
                {
                    await service.AddConfigurationSettingAsync(new ConfigurationSetting(key, "test_value", $"{i.ToString()}"));
                }

                await service.SetConfigurationSettingAsync(new ConfigurationSetting(batchKey, key));
            }
            return key;
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

        private void ValidateCreatedSnapshot(ConfigurationSnapshot createdSnapshot, ConfigurationSnapshot retrievedSnapshot, string expectedName)
        {
            Assert.NotNull(createdSnapshot);
            Assert.AreEqual(expectedName, createdSnapshot.Name);

            Assert.NotNull(retrievedSnapshot);
            Assert.AreEqual(createdSnapshot.Name, retrievedSnapshot.Name);
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
