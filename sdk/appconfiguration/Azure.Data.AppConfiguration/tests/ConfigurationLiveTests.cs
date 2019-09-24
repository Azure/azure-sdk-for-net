﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Testing;

namespace Azure.Data.AppConfiguration.Tests
{
    public class ConfigurationLiveTests : RecordedTestBase
    {
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
        public async Task DeleteSettingWithETag()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            // Prepare environment
            await service.SetAsync(testSetting);
            ConfigurationSetting setting = await service.GetAsync(testSetting.Key, testSetting.Label);

            // Test
            await service.DeleteAsync(setting.Key, setting.Label, setting.ETag, CancellationToken.None);
            //Try to get the non-existing setting
            RequestFailedException e = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.GetAsync(testSetting.Key, testSetting.Label);
            });

            Assert.AreEqual(404, e.Status);
        }

        [Test]
        public async Task SetSetting()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                ConfigurationSetting setting = await service.SetAsync(testSetting);
                Assert.AreEqual(testSetting, setting);
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
                Assert.AreEqual(testSetting, setting);
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

                Assert.AreEqual(testSetting, setting);
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

                Assert.AreEqual(testSettingNoLabel, setting);
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
                await foreach (Response<ConfigurationSetting> value in service.GetRevisionsAsync(selector, CancellationToken.None))
                {
                    if (value.Value.Label.Contains("update"))
                    {
                        Assert.AreEqual(value.Value, testSettingUpdate);
                    }
                    else
                    {
                        Assert.AreEqual(value.Value, setting);
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
                Assert.AreEqual(testSettingNoLabel, setting);
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
                Assert.AreEqual(testSetting, responseSetting);
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
                ConfigurationSetting responseSetting = await service.GetAsync(testSetting.Key, testSetting.Label, DateTimeOffset.MaxValue);
                Assert.AreEqual(testSetting, responseSetting);
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
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
                Response<ConfigurationSetting>[] batch = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                Assert.AreEqual(1, batch.Length);
                Assert.AreEqual(testSetting.Key, batch[0].Value.Key);
                Assert.AreEqual(testSetting.Label, batch[0].Value.Label);
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
                Response<ConfigurationSetting>[] batch = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                Assert.AreEqual(1, batch.Length);
                Assert.AreEqual(testSetting.Key, batch[0].Value.Key);
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

                Response<ConfigurationSetting>[] batch = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                //At least there should be one key available
                Assert.GreaterOrEqual(batch.Length, 1);
                Assert.AreEqual(testSetting.Label, batch[0].Value.Label);
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

                Response<ConfigurationSetting>[] batch = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                Assert.AreEqual(1, batch.Length);

                Assert.IsNotNull(batch[0].Value.Key);
                Assert.IsNotNull(batch[0].Value.Label);
                Assert.IsNotNull(batch[0].Value.ETag);
                Assert.IsNull(batch[0].Value.Value);
                Assert.IsNull(batch[0].Value.ContentType);
                Assert.IsNull(batch[0].Value.LastModified);
                Assert.IsNull(batch[0].Value.Locked);
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

                Response<ConfigurationSetting>[] batch = (await service.GetSettingsAsync(selector, CancellationToken.None).ToEnumerableAsync())
                    .ToArray();

                Assert.AreEqual(1, batch.Length);

                Assert.IsNotNull(batch[0].Value.Key);
                Assert.IsNotNull(batch[0].Value.Label);
                Assert.IsNotNull(batch[0].Value.Value);
                Assert.IsNotNull(batch[0].Value.ContentType);
                Assert.IsNotNull(batch[0].Value.ETag);
                Assert.IsNotNull(batch[0].Value.LastModified);
                Assert.IsNotNull(batch[0].Value.Locked);
            }
            finally
            {
                await service.DeleteAsync(setting.Key, setting.Label);
            }
        }

        [Test]
        public async Task HasChangedNoValueNotFound()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting setting0 = CreateSetting();

            bool hasChanged = await service.HasChangedAsync(setting0);

            Assert.IsFalse(hasChanged);
        }

        [Test]
        public async Task HasChangedNoValueNewValue()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting setting0 = CreateSetting();

            try
            {
                ConfigurationSetting setting1 = await service.SetAsync(setting0);

                // Test
                bool hasChanged = await service.HasChangedAsync(setting0);

                Assert.IsTrue(hasChanged);
            }
            finally
            {
                await service.DeleteAsync(setting0.Key, setting0.Label);
            }
        }

        [Test]
        public async Task HasChangedValuesMatch()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting setting0 = CreateSetting();

            try
            {
                ConfigurationSetting setting1 = await service.SetAsync(setting0);

                // Test
                bool hasChanged = await service.HasChangedAsync(setting1);

                Assert.IsFalse(hasChanged);
            }
            finally
            {
                await service.DeleteAsync(setting0.Key, setting0.Label);
            }
        }

        [Test]
        public async Task HasChangedValuesDontMatch()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting setting0 = CreateSetting();

            try
            {
                ConfigurationSetting setting1 = await service.SetAsync(setting0);
                setting0.Value = "test_value2";
                ConfigurationSetting setting2 = await service.SetAsync(setting0);

                // Test
                bool hasChanged = await service.HasChangedAsync(setting1);

                Assert.IsTrue(hasChanged);
            }
            finally
            {
                await service.DeleteAsync(setting0.Key, setting0.Label);
            }
        }

        [Test]
        public async Task HasChangedValueNotFound()
        {
            ConfigurationClient service = GetClient();
            ConfigurationSetting setting0 = CreateSetting();

            try
            {
                ConfigurationSetting setting1 = await service.SetAsync(setting0);
                var response = await service.DeleteAsync(setting1.Key, setting1.Label);

                // Test
                bool hasChanged = await service.HasChangedAsync(setting1);

                Assert.IsTrue(hasChanged);
            }
            finally
            {
                await service.DeleteAsync(setting0.Key, setting0.Label);
            }
        }
    }
}
