﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class ConfigurationLiveTests : RecordedTestBase
    {
        private string specialChars = "~`!@#$^&()_+=[]{}|;\"'<>./-";

        public ConfigurationLiveTests(bool isAsync) : base(isAsync)
        {
            Sanitizer = new ConfigurationRecordedTestSanitizer();
            Matcher = new ConfigurationRecordMatcher(Sanitizer);
        }

        private string GenerateKeyId(string prefix = null)
        {
            return prefix + Recording.GenerateId();
        }

        private ConfigurationClient GetClient()
        {
            return InstrumentClient(
                new ConfigurationClient(
                    Recording.GetConnectionStringFromEnvironment("APPCONFIGURATION_CONNECTION_STRING"),
                    Recording.InstrumentClientOptions(new ConfigurationClientOptions())));
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
                Response<ConfigurationSetting> responseGet = await service.GetAsync(batchKey);
                key = responseGet.Value.Value;
            }
            catch
            {
                for (int i = 0; i < expectedEvents; i++)
                {
                    await service.AddAsync(new ConfigurationSetting(key, "test_value", $"{i.ToString()}"));
                }

                await service.SetAsync(new ConfigurationSetting(batchKey, key));
            }
            return key;
        }

        [Test]
        public async Task DeleteSettingNotFound()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            Response response = await service.DeleteAsync(testSetting.Key);

            Assert.AreEqual(204, response.Status);
            response.Dispose();
        }

        [Test]
        public async Task DeleteSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                // Prepare environment
                ConfigurationSetting testSettingDiff = testSetting.Clone();
                testSettingDiff.Label = null;
                await service.SetAsync(testSetting);
                await service.SetAsync(testSettingDiff);

                // Test
                await service.DeleteAsync(testSettingDiff.Key);

                //Try to get the non-existing setting
                RequestFailedException e = Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    await service.GetAsync(testSettingDiff.Key);
                });

                Assert.AreEqual(404, e.Status);
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task DeleteSettingWithLabel()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                // Prepare environment
                ConfigurationSetting testSettingDiff = testSetting.Clone();
                testSettingDiff.Label = "test_label_diff";
                await service.SetAsync(testSetting);
                await service.SetAsync(testSettingDiff);

                // Test
                await service.DeleteAsync(testSettingDiff.Key, testSettingDiff.Label);

                //Try to get the non-existing setting
                RequestFailedException e = Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    await service.GetAsync(testSettingDiff.Key, testSettingDiff.Label);
                });

                Assert.AreEqual(404, e.Status);
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task DeleteSettingReadOnly()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                var setting = await service.AddAsync(testSetting);
                var readOnly = await service.SetReadOnlyAsync(testSetting.Key, testSetting.Label);

                // Test
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                    await service.DeleteAsync(testSetting.Key, testSetting.Label)
                );
                Assert.AreEqual(409, exception.Status);
            }
            finally
            {
                await service.ClearReadOnlyAsync(testSetting.Key, testSetting.Label);
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task DeleteIfUnchangedSettingUnmodified()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddAsync(testSetting);

                // Test
                Response response = await service.DeleteAsync(setting, onlyIfUnchanged: true);
                Assert.AreEqual(200, response.Status);
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task DeleteIfUnchangedSettingModified()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddAsync(testSetting);
                ConfigurationSetting modifiedSetting = setting.Clone();
                modifiedSetting.Value = "new_value";
                modifiedSetting = await service.SetAsync(modifiedSetting);

                // Test
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                    await service.DeleteAsync(setting, onlyIfUnchanged: true));
                Assert.AreEqual(412, exception.Status);
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task SetSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.SetAsync(testSetting);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting));
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task SetExistingSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.AddAsync(testSetting);

                ConfigurationSetting setting = await service.SetAsync(testSetting);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting));
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task SetSettingReadOnly()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                var setting = await service.AddAsync(testSetting);
                var readOnly = await service.SetReadOnlyAsync(testSetting.Key, testSetting.Label);

                testSetting.Value = "new_value";

                // Test
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                    await service.SetAsync(testSetting.Key, "new_value", testSetting.Label));
                Assert.AreEqual(409, exception.Status);
            }
            finally
            {
                await service.ClearReadOnlyAsync(testSetting.Key, testSetting.Label);
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task SetIfUnchangedSettingUnmodified()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddAsync(testSetting);
                setting.Value = "new_value";

                // Test
                Response<ConfigurationSetting> response = await service.SetAsync(setting, onlyIfUnchanged: true);
                Assert.AreEqual(200, response.GetRawResponse().Status);
                Assert.AreEqual(setting.Value, response.Value.Value);
                Assert.AreNotEqual(setting.ETag, response.Value.ETag);
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task SetIfUnchangedSettingModified()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddAsync(testSetting);
                ConfigurationSetting modifiedSetting = setting.Clone();
                modifiedSetting.Value = "new_value";
                modifiedSetting = await service.SetAsync(modifiedSetting);

                // Test
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                    await service.SetAsync(setting, onlyIfUnchanged: true));
                Assert.AreEqual(412, exception.Status);
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task SetKeyValue()
        {
            ConfigurationClient service = GetClient();

            string key = GenerateKeyId("key-");

            try
            {
                string value = "my_value";
                ConfigurationSetting setting = await service.SetAsync(key, value);

                Assert.AreEqual(key, setting.Key);
                Assert.AreEqual(value, setting.Value);
            }
            finally
            {
                await service.DeleteAsync(key);
            }
        }

        [Test]
        public async Task SetKeyValueLabel()
        {
            ConfigurationClient service = GetClient();

            string key = GenerateKeyId("key-");
            string value = "my_value";
            string label = "my_label";

            try
            {
                ConfigurationSetting setting = await service.SetAsync(key, value, label);

                Assert.AreEqual(key, setting.Key);
                Assert.AreEqual(value, setting.Value);
                Assert.AreEqual(label, setting.Label);
            }
            finally
            {
                await service.DeleteAsync(key, label);
            }
        }

        [Test]
        public async Task GetRequestId()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                Response<ConfigurationSetting> response = await service.SetAsync(testSetting);
                response.GetRawResponse().Headers.TryGetValue("x-ms-client-request-id", out string requestId);
                Assert.IsNotEmpty(requestId);
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task AddExistingSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.AddAsync(testSetting);

                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    await service.AddAsync(testSetting);
                });

                Assert.AreEqual(412, exception.Status);
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task AddSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddAsync(testSetting);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting));
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task AddSettingNoLabel()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            ConfigurationSetting testSettingNoLabel = testSetting.Clone();
            testSettingNoLabel.Label = null;

            try
            {
                ConfigurationSetting setting = await service.AddAsync(testSettingNoLabel);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSettingNoLabel, setting));
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key);
            }
        }

        [Test]
        public async Task AddKeyValue()
        {
            ConfigurationClient service = GetClient();

            string key = GenerateKeyId("key-");

            try
            {
                string value = "my_value";
                ConfigurationSetting setting = await service.AddAsync(key, value);

                Assert.AreEqual(key, setting.Key);
                Assert.AreEqual(value, setting.Value);
            }
            finally
            {
                await service.DeleteAsync(key);
            }
        }

        [Test]
        public async Task AddKeyValueLabel()
        {
            ConfigurationClient service = GetClient();

            string key = GenerateKeyId("key-");
            string value = "my_value";
            string label = "my_label";

            try
            {
                ConfigurationSetting setting = await service.AddAsync(key, value, label);

                Assert.AreEqual(key, setting.Key);
                Assert.AreEqual(value, setting.Value);
                Assert.AreEqual(label, setting.Label);
            }
            finally
            {
                await service.DeleteAsync(key, label);
            }
        }

        [Test]
        public async Task GetRevisions()
        {
            // The service keeps revision history even after the key was removed
            // Avoid reusing ids
            Recording.DisableIdReuse();

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
                await service.SetAsync(setting);
                await service.SetAsync(testSettingUpdate);

                // Test
                var selector = new SettingSelector(setting.Key)
                {
                    AsOf = DateTimeOffset.MaxValue
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
                await service.DeleteAsync(setting.Key, setting.Label);
                await service.DeleteAsync(testSettingUpdate.Key, testSettingUpdate.Label);
            }
        }

        [Test]
        public async Task GetSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            // Prepare environment
            ConfigurationSetting testSettingNoLabel = testSetting.Clone();
            testSettingNoLabel.Label = null;

            try
            {
                await service.SetAsync(testSettingNoLabel);
                // Test
                ConfigurationSetting setting = await service.GetAsync(testSettingNoLabel.Key);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSettingNoLabel, setting));
            }
            finally
            {
                await service.DeleteAsync(testSettingNoLabel.Key);
            }
        }

        [Test]
        public void GetSettingNotFound()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.GetAsync(testSetting.Key);
            });

            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        public async Task GetSettingWithLabel()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            // Prepare environment
            ConfigurationSetting testSettingNoLabel = testSetting.Clone();
            testSettingNoLabel.Label = null;

            try
            {
                await service.SetAsync(testSettingNoLabel);
                await service.SetAsync(testSetting);

                // Test
                ConfigurationSetting responseSetting = await service.GetAsync(testSetting.Key, testSetting.Label);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, responseSetting));
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
                await service.DeleteAsync(testSettingNoLabel.Key);
            }
        }

        [Test]
        public async Task GetWithAcceptDateTime()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.SetAsync(testSetting);

                // Test
                // TODO: add a test with a more granular timestamp.
                ConfigurationSetting responseSetting = await service.GetAsync(testSetting.Key, testSetting.Label, DateTimeOffset.MaxValue, requestOptions: default);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, responseSetting));
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task GetIfChangedSettingModified()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddAsync(testSetting);
                ConfigurationSetting modifiedSetting = setting.Clone();
                modifiedSetting.Value = "new_value";
                modifiedSetting = await service.SetAsync(modifiedSetting);

                Response<ConfigurationSetting> response = await service.GetAsync(setting, onlyIfChanged: true).ConfigureAwait(false);
                Assert.AreEqual(200, response.GetRawResponse().Status);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(modifiedSetting, response.Value));
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task GetIfChangedSettingUnmodified()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.AddAsync(testSetting);

                // Test
                Response<ConfigurationSetting> response = await service.GetAsync(setting, onlyIfChanged: true).ConfigureAwait(false);
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
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task GetSettingSpecialCharacters()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSettingSpecialCharacters();

            // Prepare environment
            ConfigurationSetting testSettingNoLabel = testSetting.Clone();
            testSettingNoLabel.Label = null;

            try
            {
                await service.SetAsync(testSettingNoLabel);

                // Test
                ConfigurationSetting setting = await service.GetAsync(testSettingNoLabel.Key);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSettingNoLabel, setting));
            }
            finally
            {
                await service.DeleteAsync(testSettingNoLabel.Key);
            }
        }

        [Test]
        public async Task GetSettingSpecialCharactersWithLabel()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSettingSpecialCharacters();

            try
            {
                await service.SetAsync(testSetting);

                // Test
                ConfigurationSetting setting = await service.GetAsync(testSetting.Key, testSetting.Label);
                Assert.True(ConfigurationSettingEqualityComparer.Instance.Equals(testSetting, setting));
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key);
            }
        }

        [Test]
        public async Task GetBatchSettingPagination()
        {
            ConfigurationClient service = GetClient();

            const int expectedEvents = 105;
            var key = await SetMultipleKeys(service, expectedEvents);

            int resultsReturned = 0;
            SettingSelector selector = new SettingSelector(key);

            await foreach (ConfigurationSetting item in service.GetSettingsAsync(selector, CancellationToken.None))
            {
                Assert.AreEqual("test_value", item.Value);
                resultsReturned++;
            }

            Assert.AreEqual(expectedEvents, resultsReturned);
        }

        [Test]
        public async Task GetBatchSettingAny()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.SetAsync(testSetting);

                var selector = new SettingSelector();

                Assert.AreEqual("*", selector.Keys.First());
                Assert.AreEqual("*", selector.Labels.First());

                var resultsReturned = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .Count();

                //At least there should be one key available
                Assert.GreaterOrEqual(resultsReturned, 1);
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task GetBatchSettingKeyLabel()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.SetAsync(testSetting);

                var selector = new SettingSelector(testSetting.Key, testSetting.Label);
                ConfigurationSetting[] batch = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                Assert.AreEqual(1, batch.Length);
                Assert.AreEqual(testSetting.Key, batch[0].Key);
                Assert.AreEqual(testSetting.Label, batch[0].Label);
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task GetBatchSettingOnlyKey()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.SetAsync(testSetting);

                var selector = new SettingSelector(testSetting.Key);
                ConfigurationSetting[] batch = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                Assert.AreEqual(1, batch.Length);
                Assert.AreEqual(testSetting.Key, batch[0].Key);
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task GetBatchSettingOnlyLabel()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.SetAsync(testSetting);

                var selector = new SettingSelector(null, testSetting.Label);

                Assert.AreEqual("*", selector.Keys.First());

                ConfigurationSetting[] batch = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                //At least there should be one key available
                CollectionAssert.IsNotEmpty(batch);
                Assert.AreEqual(testSetting.Label, batch[0].Label);
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task GetBatchSettingWithFields()
        {
            ConfigurationClient service = GetClient();

            string key = GenerateKeyId("keyFields-");
            ConfigurationSetting setting = await service.AddAsync(key, "my_value", "my_label");

            try
            {
                SettingSelector selector = new SettingSelector(key)
                {
                    Fields = SettingFields.Key | SettingFields.Label | SettingFields.ETag
                };

                ConfigurationSetting[] batch = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                Assert.AreEqual(1, batch.Length);

                Assert.IsNotNull(batch[0].Key);
                Assert.IsNotNull(batch[0].Label);
                Assert.IsNotNull(batch[0].ETag);
                Assert.IsNull(batch[0].Value);
                Assert.IsNull(batch[0].ContentType);
                Assert.IsNull(batch[0].LastModified);
                Assert.IsNull(batch[0].ReadOnly);
            }
            finally
            {
                await service.DeleteAsync(setting.Key, setting.Label);
            }
        }

        [Test]
        public async Task GetBatchSettingWithReadOnly()
        {
            ConfigurationClient service = GetClient();

            string key = GenerateKeyId("key-");
            ConfigurationSetting setting = await service.AddAsync(key, "my_value", "my_label");

            try
            {
                SettingSelector selector = new SettingSelector(key)
                {
                    Fields = SettingFields.Key | SettingFields.ReadOnly
                };

                List<ConfigurationSetting> batch = await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync();

                CollectionAssert.IsNotEmpty(batch);
                Assert.IsNotNull(batch[0].Key);
                Assert.IsNotNull(batch[0].ReadOnly);
                Assert.IsNull(batch[0].Label);
                Assert.IsNull(batch[0].Value);
                Assert.IsNull(batch[0].ContentType);
                Assert.IsNull(batch[0].LastModified);
                Assert.AreEqual(batch[0].ETag, default(ETag));
            }
            finally
            {
                await service.DeleteAsync(setting.Key, setting.Label);
            }
        }

        [Test]
        public async Task GetBatchSettingWithAllFields()
        {
            ConfigurationClient service = GetClient();
            string key = GenerateKeyId("keyFields-");
            ConfigurationSetting setting = await service.AddAsync(new ConfigurationSetting(key, "my_value", "my_label")
            {
                ContentType = "content-type"
            });

            try
            {
                SettingSelector selector = new SettingSelector(key)
                {
                    Fields = SettingFields.All
                };

                ConfigurationSetting[] batch = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                Assert.AreEqual(1, batch.Length);

                Assert.IsNotNull(batch[0].Key);
                Assert.IsNotNull(batch[0].Label);
                Assert.IsNotNull(batch[0].Value);
                Assert.IsNotNull(batch[0].ContentType);
                Assert.IsNotNull(batch[0].ETag);
                Assert.IsNotNull(batch[0].LastModified);
                Assert.IsNotNull(batch[0].ReadOnly);
            }
            finally
            {
                await service.DeleteAsync(setting.Key, setting.Label);
            }
        }

        [Test]
        public async Task GetBatchSettingSpecialCharacters()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSettingSpecialCharacters();

            try
            {
                await service.SetAsync(testSetting);

                var selector = new SettingSelector(testSetting.Key);

                ConfigurationSetting[] settings = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                // There should be at least one key available
                CollectionAssert.IsNotEmpty(settings);
                Assert.AreEqual(testSetting.Key, settings[0].Key);
                Assert.AreEqual(testSetting.Label, settings[0].Label);
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key);
            }
        }

        [Test]
        public async Task GetBatchSettingStartsWith()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting("abcde", "Starts with abc", "abcde");

            try
            {
                await service.SetAsync(testSetting);

                var selector = new SettingSelector("abc*");

                ConfigurationSetting[] settings = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                // There should be at least one key available.
                CollectionAssert.IsNotEmpty(settings);

                foreach (ConfigurationSetting setting in settings)
                {
                    StringAssert.StartsWith("abc", setting.Key);
                }
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key);
            }
        }

        [Test]
        public async Task GetBatchSettingEndsWith()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting("yzabc", "Test of ends with", "yzabc");
            string endsWith = testSetting.Key.Substring(5);

            try
            {
                await service.SetAsync(testSetting);

                var selector = new SettingSelector($"*{endsWith}");

                ConfigurationSetting[] settings = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                // There should be at least one key available.
                CollectionAssert.IsNotEmpty(settings);

                foreach (ConfigurationSetting setting in settings)
                {
                    StringAssert.EndsWith(endsWith, setting.Key);
                }
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key);
            }
        }

        [Test]
        public async Task GetBatchSettingContains()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting("yzabcde", "Contains abc", "yzabcde");

            try
            {
                await service.SetAsync(testSetting);

                var selector = new SettingSelector("*abc*");

                ConfigurationSetting[] settings = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                // There should be at least one key available.
                CollectionAssert.IsNotEmpty(settings);

                foreach (ConfigurationSetting setting in settings)
                {
                    StringAssert.Contains("abc", setting.Key);
                }
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key);
            }
        }

        [Test]
        public async Task GetBatchSettingsWithCommaInSelectorKey()
        {
            ConfigurationClient service = GetClient();

            ConfigurationSetting abcSetting = new ConfigurationSetting("ab,cd", "comma in key");
            ConfigurationSetting xyzSetting = new ConfigurationSetting("wx,yz", "comma in key");

            try
            {
                await service.SetAsync(abcSetting);
                await service.SetAsync(xyzSetting);

                var selector = new SettingSelector("ab,cd");
                selector.Keys.Add("wx,yz");

                ConfigurationSetting[] settings = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                Assert.GreaterOrEqual(settings.Length, 2);
                Assert.IsTrue(settings.Any(s => s.Key == "ab,cd"));
                Assert.IsTrue(settings.Any(s => s.Key == "wx,yz"));
            }
            finally
            {
                await service.DeleteAsync(abcSetting.Key);
                await service.DeleteAsync(xyzSetting.Key);
            }
        }

        [Test]
        public async Task GetBatchSettingsWithCommaInSelectorKeyDoesNotOr()
        {
            ConfigurationClient service = GetClient();

            ConfigurationSetting abcSetting = new ConfigurationSetting("abc", "abc setting");
            ConfigurationSetting xyzSetting = new ConfigurationSetting("xyz", "xyz setting");

            try
            {
                await service.SetAsync(abcSetting);
                await service.SetAsync(xyzSetting);

                var selector = new SettingSelector($"{abcSetting.Key},{xyzSetting.Key}");

                ConfigurationSetting[] settings = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                CollectionAssert.IsEmpty(settings);
            }
            finally
            {
                await service.DeleteAsync(abcSetting.Key);
                await service.DeleteAsync(xyzSetting.Key);
            }
        }

        [Test]
        public async Task GetBatchSettingsWithMultipleKeys()
        {
            ConfigurationClient service = GetClient();

            ConfigurationSetting abcSetting = new ConfigurationSetting("abc", "abc setting");
            ConfigurationSetting xyzSetting = new ConfigurationSetting("xyz", "xyz setting");

            try
            {
                await service.SetAsync(abcSetting);
                await service.SetAsync(xyzSetting);

                var selector = new SettingSelector("abc");
                selector.Keys.Add("xyz");

                ConfigurationSetting[] settings = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                Assert.GreaterOrEqual(settings.Length, 2);
                Assert.IsTrue(settings.Any(s => s.Key == "abc"));
                Assert.IsTrue(settings.Any(s => s.Key == "xyz"));
            }
            finally
            {
                await service.DeleteAsync(abcSetting.Key);
                await service.DeleteAsync(xyzSetting.Key);
            }
        }

        [Test]
        public async Task GetBatchSettingsWithMultipleLabels()
        {
            ConfigurationClient service = GetClient();

            ConfigurationSetting abcSetting = new ConfigurationSetting("key-abc", "abc setting", "abc");
            ConfigurationSetting xyzSetting = new ConfigurationSetting("label-xyz", "xyz setting", "xyz");

            try
            {
                await service.SetAsync(abcSetting);
                await service.SetAsync(xyzSetting);

                var selector = new SettingSelector(null, "abc");
                selector.Labels.Add("xyz");

                ConfigurationSetting[] settings = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync()).ToArray();

                Assert.GreaterOrEqual(settings.Length, 2);
                Assert.IsTrue(settings.Any(s => s.Label == "abc"));
                Assert.IsTrue(settings.Any(s => s.Label == "xyz"));
            }
            finally
            {
                await service.DeleteAsync(abcSetting.Key);
                await service.DeleteAsync(xyzSetting.Key);
            }
        }

        [Test]
        public async Task SetReadOnlyOnSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                var setting = await service.AddAsync(testSetting);
                var readOnly = await service.SetReadOnlyAsync(testSetting.Key, testSetting.Label);
                Assert.IsTrue(readOnly.Value.ReadOnly);
            }
            finally
            {
                await service.ClearReadOnlyAsync(testSetting.Key, testSetting.Label);
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task SetReadOnlySettingNotFound()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    await service.SetReadOnlyAsync(testSetting.Key);
                });
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task ClearReadOnlyFromSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                var setting = await service.AddAsync(testSetting);
                var readOnly = await service.ClearReadOnlyAsync(testSetting.Key, testSetting.Label);
                Assert.IsFalse(readOnly.Value.ReadOnly);
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task ClearReadOnlySettingNotFound()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    await service.SetReadOnlyAsync(testSetting.Key);
                });
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }
    }
}
