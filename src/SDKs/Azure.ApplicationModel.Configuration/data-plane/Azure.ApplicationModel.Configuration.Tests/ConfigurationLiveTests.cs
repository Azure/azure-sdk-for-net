// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ApplicationModel.Configuration.Tests
{
    [Category("Live")]
    public class ConfigurationLiveTests
    {
        private string GenerateKeyId(string prefix = null)
        {
            return prefix + Guid.NewGuid().ToString("N");
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

        private static bool TagsEqual(IDictionary<string, string> expected, IDictionary<string, string> actual)
        {
            if (expected == null && actual == null) return true;
            if (expected?.Count != actual?.Count) return false;
            foreach (var pair in expected)
            {
                if (!actual.TryGetValue(pair.Key, out string value)) return false;
                if (!string.Equals(value, pair.Value, StringComparison.Ordinal)) return false;
            }
            return true;
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
                var responseGet = await service.GetAsync(batchKey);
                key = responseGet.Value.Value;
                responseGet.Dispose();
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
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            var response = await service.DeleteAsync(testSetting.Key);

            Assert.AreEqual(204, response.Status);
            response.Dispose();
        }

        [Test]
        public async Task DeleteSetting()
        {
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                // Prepare environment
                var testSettingDiff = testSetting.Clone();
                testSettingDiff.Label = null;
                await service.SetAsync(testSetting);
                await service.SetAsync(testSettingDiff);

                // Test
                await service.DeleteAsync(testSettingDiff.Key);

                //Try to get the non-existing setting
                var e = Assert.ThrowsAsync<RequestFailedException>(async () =>
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
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                // Prepare environment
                var testSettingDiff = testSetting.Clone();
                testSettingDiff.Label = "test_label_diff";
                await service.SetAsync(testSetting);
                await service.SetAsync(testSettingDiff);

                // Test
                await service.DeleteAsync(testSettingDiff.Key, testSettingDiff.Label);

                //Try to get the non-existing setting
                var e = Assert.ThrowsAsync<RequestFailedException>(async () =>
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
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            // Prepare environment
            await service.SetAsync(testSetting);
            ConfigurationSetting setting = await service.GetAsync(testSetting.Key, testSetting.Label);

            // Test
            await service.DeleteAsync(setting.Key, setting.Label, setting.ETag, CancellationToken.None);
            //Try to get the non-existing setting
            var e = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.GetAsync(testSetting.Key, testSetting.Label);
            });

            Assert.AreEqual(404, e.Status);
        }

        [Test]
        public async Task SetSetting()
        {
            ConfigurationClient service = TestEnvironment.GetClient();
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
            ConfigurationClient service = TestEnvironment.GetClient();
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
            ConfigurationClient service = TestEnvironment.GetClient();

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
            ConfigurationClient service = TestEnvironment.GetClient();

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
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                Response<ConfigurationSetting> response = await service.SetAsync(testSetting);
                response.TryGetHeader("x-ms-client-request-id", out string requestId);
                Assert.IsNotEmpty(requestId);
                response.Dispose();
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task AddExistingSetting()
        {
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.AddAsync(testSetting);

                var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
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
            ConfigurationClient service = TestEnvironment.GetClient();
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
            ConfigurationClient service = TestEnvironment.GetClient();
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
            ConfigurationClient service = TestEnvironment.GetClient();

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
            ConfigurationClient service = TestEnvironment.GetClient();

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
        public async Task UpdateKeyValue()
        {
            ConfigurationClient service = TestEnvironment.GetClient();

            string key = GenerateKeyId("key-");
            await service.SetAsync(key, "my_value");

            try
            {
                string value = "my_value2";
                ConfigurationSetting responseSetting = await service.UpdateAsync(key, value);

                Assert.AreEqual(key, responseSetting.Key);
                Assert.AreEqual(value, responseSetting.Value);
            }
            finally
            {
                await service.DeleteAsync(key);
            }
        }

        [Test]
        public async Task UpdateSetting()
        {
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            var testSettingDiff = testSetting.Clone();
            testSettingDiff.Label = "test_label_diff";

            var testSettingUpdate = testSetting.Clone();
            testSettingUpdate.Value = "test_value_update";

            try
            {
                await service.SetAsync(testSetting);
                await service.SetAsync(testSettingDiff);

                ConfigurationSetting responseSetting = await service.UpdateAsync(testSettingUpdate, CancellationToken.None);

                Assert.AreEqual(testSettingUpdate, responseSetting);
            }
            finally
            {
                await service.DeleteAsync(testSettingUpdate.Key, testSettingUpdate.Label);
                await service.DeleteAsync(testSettingDiff.Key, testSettingDiff.Label);
            }
        }

        [Test]
        public void UpdateNoExistingSetting()
        {
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.UpdateAsync(testSetting);
            });
            Assert.AreEqual(412, exception.Status);
        }

        [Test]
        public async Task UpdateSettingIfETag()
        {
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            await service.SetAsync(testSetting);
            ConfigurationSetting responseGet = await service.GetAsync(testSetting.Key, testSetting.Label);

            try
            {
                responseGet.Value = "test_value_diff";
                ConfigurationSetting responseSetting = await service.UpdateAsync(responseGet, CancellationToken.None);

                Assert.AreNotEqual(responseGet, responseSetting);
            }
            finally
            {
                await service.DeleteAsync(responseGet.Key, responseGet.Label);
            }
        }

        [Test]
        public async Task UpdateSettingTags()
        {
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            await service.SetAsync(testSetting);
            ConfigurationSetting responseGet = await service.GetAsync(testSetting.Key, testSetting.Label);


            try
            {
                // Different tags
                var testSettingDiff = responseGet.Clone();
                var settingTags = testSettingDiff.Tags;
                if (settingTags.ContainsKey("tag1")) settingTags["tag1"] = "value-updated";
                settingTags.Add("tag3", "test_value3");
                testSettingDiff.Tags = settingTags;

                ConfigurationSetting responseSetting = await service.UpdateAsync(testSettingDiff, CancellationToken.None);
                Assert.AreEqual(testSettingDiff, responseSetting);

                // No tags
                var testSettingNoTags = responseGet.Clone();
                testSettingNoTags.Tags = null;

                responseSetting = await service.UpdateAsync(testSettingNoTags, CancellationToken.None);
                Assert.AreEqual(testSettingNoTags, responseSetting);
            }
            finally
            {
                await service.DeleteAsync(testSetting.Key, testSetting.Label);
            }
        }

        [Test]
        public async Task GetRevisions()
        {
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            //Prepare environment
            ConfigurationSetting setting = testSetting;
            setting.Key = GenerateKeyId("key-");
            var testSettingUpdate = setting.Clone();
            testSettingUpdate.Label = "test_label_update";
            int expectedEvents = 2;

            try
            {
                await service.SetAsync(setting);
                await service.SetAsync(testSettingUpdate);

                // Test
                var selector = new SettingSelector(setting.Key);
                selector.AsOf = DateTimeOffset.MaxValue;
                SettingBatch batch = await service.GetRevisionsAsync(selector, CancellationToken.None);

                int resultsReturned = 0;
                for (int i = 0; i < batch.Count; i++)
                {
                    var value = batch[i];
                    if (value.Label.Contains("update"))
                    {
                        Assert.AreEqual(value, testSettingUpdate);
                    }
                    else
                    {
                        Assert.AreEqual(value, setting);
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
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            // Prepare environment
            var testSettingNoLabel = testSetting.Clone();
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
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.GetAsync(testSetting.Key);
            });

            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        public async Task GetSettingWithLabel()
        {
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            // Prepare environment
            var testSettingNoLabel = testSetting.Clone();
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
            ConfigurationClient service = TestEnvironment.GetClient();
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
            ConfigurationClient service = TestEnvironment.GetClient();

            const int expectedEvents = 105;
            var key = await SetMultipleKeys(service, expectedEvents);

            int resultsReturned = 0;
            SettingSelector selector = new SettingSelector(key);
            while (true)
            {
                using (Response<SettingBatch> response = await service.GetBatchAsync(selector, CancellationToken.None))
                {
                    SettingBatch batch = response.Value;
                    resultsReturned += batch.Count;
                    var nextBatch = batch.NextBatch;

                    if (nextBatch == null) break;

                    selector = nextBatch;
                }
            }
            Assert.AreEqual(expectedEvents, resultsReturned);
        }

        [Test]
        public async Task GetBatchSettingAny()
        {
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.SetAsync(testSetting);

                var selector = new SettingSelector();

                Assert.AreEqual("*", selector.Keys.First());
                Assert.AreEqual("*", selector.Labels.First());

                SettingBatch batch = await service.GetBatchAsync(selector, CancellationToken.None);
                int resultsReturned = batch.Count;

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
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.SetAsync(testSetting);

                var selector = new SettingSelector(testSetting.Key, testSetting.Label);
                SettingBatch batch = await service.GetBatchAsync(selector, CancellationToken.None);

                Assert.AreEqual(1, batch.Count);
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
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.SetAsync(testSetting);

                var selector = new SettingSelector(testSetting.Key);
                SettingBatch batch = await service.GetBatchAsync(selector, CancellationToken.None);

                Assert.AreEqual(1, batch.Count);
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
            ConfigurationClient service = TestEnvironment.GetClient();
            ConfigurationSetting testSetting = CreateSetting();

            try
            {
                await service.SetAsync(testSetting);

                var selector = new SettingSelector(null, testSetting.Label);

                Assert.AreEqual("*", selector.Keys.First());

                SettingBatch batch = await service.GetBatchAsync(selector, CancellationToken.None);
                int resultsReturned = batch.Count;

                //At least there should be one key available
                Assert.GreaterOrEqual(resultsReturned, 1);
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
            ConfigurationClient service = TestEnvironment.GetClient();

            string key = GenerateKeyId("keyFields-");
            ConfigurationSetting setting = await service.AddAsync(key, "my_value", "my_label");

            try
            {
                SettingSelector selector = new SettingSelector(key)
                {
                    Fields = SettingFields.Key | SettingFields.Label | SettingFields.ETag
                };

                SettingBatch batch = await service.GetBatchAsync(selector, CancellationToken.None);
                int resultsReturned = batch.Count;

                Assert.AreEqual(1, resultsReturned);

                Assert.IsNotNull(batch[0].Key);
                Assert.IsNotNull(batch[0].Label);
                Assert.IsNotNull(batch[0].ETag);
                Assert.IsNull(batch[0].Value);
                Assert.IsNull(batch[0].ContentType);
                Assert.IsNull(batch[0].LastModified);
                Assert.IsNull(batch[0].Locked);
            }
            finally
            {
                await service.DeleteAsync(setting.Key, setting.Label);
            }
        }

        [Test]
        public async Task GetBatchSettingWithAllFields()
        {
            ConfigurationClient service = TestEnvironment.GetClient();
            string key = GenerateKeyId("keyFields-");
            ConfigurationSetting setting = await service.AddAsync(key, "my_value", "my_label");

            try
            {
                SettingSelector selector = new SettingSelector(key)
                {
                    Fields = SettingFields.All
                };
                SettingBatch batch = await service.GetBatchAsync(selector, CancellationToken.None);

                Assert.AreEqual(1, batch.Count);

                Assert.IsNotNull(batch[0].Key);
                Assert.IsNotNull(batch[0].Label);
                Assert.IsNotNull(batch[0].Value);
                Assert.IsNotNull(batch[0].ContentType);
                Assert.IsNotNull(batch[0].ETag);
                Assert.IsNotNull(batch[0].LastModified);
                Assert.IsNotNull(batch[0].Locked);
            }
            finally
            {
                await service.DeleteAsync(setting.Key, setting.Label);
            }
        }
    }

    public static class ConfigurationSettingExtensions
    {
        public static ConfigurationSetting Clone(this ConfigurationSetting setting)
        {
            Dictionary<string, string> tags = new Dictionary<string, string>();
            foreach (string key in setting.Tags.Keys)
            {
                tags.Add(key, setting.Tags[key]);
            }

            return new ConfigurationSetting(setting.Key, setting.Value)
            {
                Label = setting.Label,
                ContentType = setting.ContentType,
                Tags = tags
            };
        }
    }
}
