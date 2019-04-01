// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ApplicationModel.Configuration.Tests
{
    [Category("Live")]
    public class ConfigurationLiveTests
    {
        static readonly ConfigurationSetting s_testSetting = new ConfigurationSetting(
            string.Concat("key-", Guid.NewGuid().ToString("N")),
            "test_value"
        )
        {
            Label = "test_label",
            ContentType = "test_content_type",
            Tags = new Dictionary<string, string>
            {
                { "tag1", "value1" },
                { "tag2", "value2" }
            }
        };

        private static string GetEnvironment()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            return connectionString;
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
            string key = string.Concat("key-", Guid.NewGuid().ToString("N"));

            /*
             * The configuration store contains a KV with the Key
             * that represents {expectedEvents} data points.
             * If not set, create the {expectedEvents} data points and the "BatchKey"
            */
            const string batchKey = "BatchKey";

            try
            {
                var responseGet = await service.GetAsync(batchKey);
                key = responseGet.Result.Value;
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
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            var response = await service.DeleteAsync(s_testSetting.Key);

            Assert.AreEqual(204, response.Status);
            response.Dispose();
        }

        [Test]
        public async Task DeleteSetting()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            try
            {
                // Prepare environment
                var testSettingDiff = s_testSetting.Clone();
                testSettingDiff.Label = null;
                await service.SetAsync(s_testSetting);
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
                await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            }
        }

        [Test]
        public async Task DeleteSettingWithLabel()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            try
            {
                // Prepare environment
                var testSettingDiff = s_testSetting.Clone();
                testSettingDiff.Label = "test_label_diff";
                await service.SetAsync(s_testSetting);
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
                await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            }
        }

        [Test]
        public async Task DeleteSettingWithETag()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            // Prepare environment
            await service.SetAsync(s_testSetting);
            ConfigurationSetting setting = await service.GetAsync(s_testSetting.Key, s_testSetting.Label);

            // Test
            await service.DeleteAsync(setting.Key, setting.Label, setting.ETag, CancellationToken.None);
            //Try to get the non-existing setting
            var e = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.GetAsync(s_testSetting.Key, s_testSetting.Label);
            });

            Assert.AreEqual(404, e.Status);
        }

        [Test]
        public async Task SetSetting()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            try
            {
                ConfigurationSetting setting = await service.SetAsync(s_testSetting);
                Assert.AreEqual(s_testSetting, setting);
            }
            finally
            {
                await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            }
        }

        [Test]
        public async Task SetExistingSetting()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            try
            {
                await service.AddAsync(s_testSetting);

                ConfigurationSetting setting = await service.SetAsync(s_testSetting);
                Assert.AreEqual(s_testSetting, setting);
            }
            finally
            {
                await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            }
        }

        [Test]
        public async Task SetKeyValue()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            string key = string.Concat("key-", Guid.NewGuid().ToString("N"));

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
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            string key = string.Concat("key-", Guid.NewGuid().ToString("N"));
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
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            try
            {
                Response<ConfigurationSetting> response = await service.SetAsync(s_testSetting);
                response.TryGetHeader("x-ms-client-request-id", out string requestId);
                Assert.IsNotEmpty(requestId);
                response.Dispose();
            }
            finally
            {
                await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            }
        }

        [Test]
        public async Task AddExistingSetting()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            try
            {
                await service.AddAsync(s_testSetting);

                var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    await service.AddAsync(s_testSetting);
                });

                Assert.AreEqual(412, exception.Status);
            }
            finally
            {
                await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            }
        }

        [Test]
        public async Task AddSetting()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            try
            {
                ConfigurationSetting setting = await service.AddAsync(s_testSetting);

                Assert.AreEqual(s_testSetting, setting);
            }
            finally
            {
                await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            }
        }

        [Test]
        public async Task AddSettingNoLabel()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            var testSettingNoLabel = s_testSetting.Clone();
            testSettingNoLabel.Label = null;

            try
            {
                ConfigurationSetting setting = await service.AddAsync(testSettingNoLabel);

                Assert.AreEqual(testSettingNoLabel, setting);
            }
            finally
            {
                await service.DeleteAsync(s_testSetting.Key);
            }
        }

        [Test]
        public async Task AddKeyValue()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            string key = string.Concat("key-", Guid.NewGuid().ToString("N"));

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
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            string key = string.Concat("key-", Guid.NewGuid().ToString("N"));
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
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            string key = string.Concat("key-", Guid.NewGuid().ToString("N"));
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
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            var testSettingDiff = s_testSetting.Clone();
            testSettingDiff.Label = "test_label_diff";

            var testSettingUpdate = s_testSetting.Clone();
            testSettingUpdate.Value = "test_value_update";

            try
            {
                await service.SetAsync(s_testSetting);
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
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.UpdateAsync(s_testSetting);
            });
            Assert.AreEqual(412, exception.Status);
        }

        [Test]
        public async Task UpdateSettingIfETag()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            await service.SetAsync(s_testSetting);
            ConfigurationSetting responseGet = await service.GetAsync(s_testSetting.Key, s_testSetting.Label);

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
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            await service.SetAsync(s_testSetting);
            ConfigurationSetting responseGet = await service.GetAsync(s_testSetting.Key, s_testSetting.Label);


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
                await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            }
        }

        [Test]
        public async Task GetRevisions()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            //Prepare environment
            ConfigurationSetting setting = s_testSetting;
            setting.Key = string.Concat("key-", Guid.NewGuid().ToString("N"));
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
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            // Prepare environment
            var testSettingNoLabel = s_testSetting.Clone();
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
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.GetAsync(s_testSetting.Key);
            });

            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        public async Task GetSettingWithLabel()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            // Prepare environment
            var testSettingNoLabel = s_testSetting.Clone();
            testSettingNoLabel.Label = null;

            try
            {
                await service.SetAsync(testSettingNoLabel);
                await service.SetAsync(s_testSetting);

                // Test
                ConfigurationSetting responseSetting = await service.GetAsync(s_testSetting.Key, s_testSetting.Label);
                Assert.AreEqual(s_testSetting, responseSetting);
            }
            finally
            {
                await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
                await service.DeleteAsync(testSettingNoLabel.Key);
            }
        }

        [Test]
        public async Task GetWithAcceptDateTime()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            try
            {
                await service.SetAsync(s_testSetting);

                // Test
                ConfigurationSetting responseSetting = await service.GetAsync(s_testSetting.Key, s_testSetting.Label, DateTimeOffset.MaxValue);
                Assert.AreEqual(s_testSetting, responseSetting);
            }
            finally
            {
                await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            }
        }

        [Test]
        public async Task GetBatchSettingPagination()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            const int expectedEvents = 105;
            var key = await SetMultipleKeys(service, expectedEvents);

            int resultsReturned = 0;
            SettingSelector selector = new SettingSelector(key);
            while (true)
            {
                using (Response<SettingBatch> response = await service.GetBatchAsync(selector, CancellationToken.None))
                {
                    SettingBatch batch = response.Result;
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
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            try
            {
                await service.SetAsync(s_testSetting);

                var selector = new SettingSelector();

                Assert.AreEqual(selector.Keys.First(), "*");
                Assert.AreEqual(selector.Labels.First(), "*");

                SettingBatch batch = await service.GetBatchAsync(selector, CancellationToken.None);
                int resultsReturned = batch.Count;

                //At least there should be one key available
                Assert.GreaterOrEqual(resultsReturned, 1);
            }
            finally
            {
                await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            }
        }

        [Test]
        public async Task GetBatchSettingKeyLabel()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            try
            {
                await service.SetAsync(s_testSetting);

                var selector = new SettingSelector(s_testSetting.Key, s_testSetting.Label);
                SettingBatch batch = await service.GetBatchAsync(selector, CancellationToken.None);

                Assert.AreEqual(batch.Count, 1);
                Assert.AreEqual(batch[0].Key, s_testSetting.Key);
                Assert.AreEqual(batch[0].Label, s_testSetting.Label);
            }
            finally
            {
                await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            }
        }

        [Test]
        public async Task GetBatchSettingOnlyKey()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            try
            {
                await service.SetAsync(s_testSetting);

                var selector = new SettingSelector(s_testSetting.Key);
                SettingBatch batch = await service.GetBatchAsync(selector, CancellationToken.None);

                Assert.AreEqual(batch.Count, 1);
                Assert.AreEqual(batch[0].Key, s_testSetting.Key);
            }
            finally
            {
                await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            }
        }

        [Test]
        public async Task GetBatchSettingOnlyLabel()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            try
            {
                await service.SetAsync(s_testSetting);

                var selector = new SettingSelector(null, s_testSetting.Label);

                Assert.AreEqual(selector.Keys.First(), "*");

                SettingBatch batch = await service.GetBatchAsync(selector, CancellationToken.None);
                int resultsReturned = batch.Count;

                //At least there should be one key available
                Assert.GreaterOrEqual(resultsReturned, 1);
                Assert.AreEqual(batch[0].Label, s_testSetting.Label);
            }
            finally
            {
                await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            }
        }

        [Test]
        public async Task GetBatchSettingWithFields()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            try
            {
                await service.SetAsync(s_testSetting);

                SettingSelector selector = new SettingSelector()
                {
                    Fields = SettingFields.Key | SettingFields.Label | SettingFields.Value,
                };

                SettingBatch batch = await service.GetBatchAsync(selector, CancellationToken.None);
                int resultsReturned = batch.Count;

                //At least there should be one key available
                Assert.GreaterOrEqual(resultsReturned, 1);
            }
            finally
            {
                await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            }
        }

        [Test]
        public async Task LockUnlockSetting()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            try
            {
                // Prepare environment
                await service.SetAsync(s_testSetting);

                // Test Lock
                ConfigurationSetting responseLockSetting = await service.LockAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);

                //Test update
                var testSettingUpdate = s_testSetting.Clone();
                testSettingUpdate.Value = "test_value_update";

                var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    await service.UpdateAsync(testSettingUpdate);
                });
                Assert.AreEqual(409, exception.Status);

                // Test Unlock
                ConfigurationSetting responseUnlockSetting = await service.UnlockAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);
                await service.UpdateAsync(testSettingUpdate);
            }
            finally
            {
                await service.DeleteAsync(s_testSetting.Key, s_testSetting.Label);
            }
        }

        [Test]
        public void LockSettingNotFound()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.LockAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);
            });

            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        public void UnlockSettingNotFound()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await service.UnlockAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);
            });

            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        public void FilterReservedCharacter()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);
            var selector = new SettingSelector()
            {
                Keys = new List<string>() { "my_key", "key,key" },
                Labels = new List<string>() { "my_label", "label,label" },
            };

            var builder = new UriBuilder();
            service.BuildBatchQuery(builder, selector);

            Assert.AreEqual(builder.Uri.AbsoluteUri, @"http://localhost/?key=my_key,key%5C,key&label=my_label,label%5C,label");
            
        }

        [Test]
        public void FilterContains()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);
            var selector = new SettingSelector()
            {
                Keys = new List<string>() { "*key*" },
                Labels = new List<string>() { "*label*" },
            };

            var builder = new UriBuilder();
            service.BuildBatchQuery(builder, selector);

            Assert.AreEqual(builder.Uri.AbsoluteUri, "http://localhost/?key=*key*&label=*label*");
        }

        [Test]
        public void FilterNullLabel()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);
            var selector = new SettingSelector()
            {
                Labels = new List<string>() { "" },
            };

            var builder = new UriBuilder();
            service.BuildBatchQuery(builder, selector);

            Assert.AreEqual(builder.Uri.AbsoluteUri, "http://localhost/?key=*&label=%00");
        }

        [Test]
        public void FilterOnlyKey()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            var key = "my-key";
            var selector = new SettingSelector(key);

            var builder = new UriBuilder();
            service.BuildBatchQuery(builder, selector);

            Assert.AreEqual(builder.Uri.AbsoluteUri, $"http://localhost/?key={key}");
        }

        [Test]
        public void FilterOnlyLabel()
        {
            string connectionString = GetEnvironment();
            var service = new ConfigurationClient(connectionString);

            var label = "my-label";
            var selector = new SettingSelector(null, label);

            var builder = new UriBuilder();
            service.BuildBatchQuery(builder, selector);

            Assert.AreEqual(builder.Uri.AbsoluteUri, $"http://localhost/?key=*&label={label}");
        }

        [Test]
        public void ConfigurationSettingEquals()
        {
            //Case tests
            var testSettingUpperCase = s_testSetting.Clone();
            testSettingUpperCase.Key = testSettingUpperCase.Key.ToUpper();

            var testSettingLowerCase = s_testSetting.Clone();
            testSettingLowerCase.Key = testSettingLowerCase.Key.ToLower();
            Assert.AreNotEqual(testSettingUpperCase, testSettingLowerCase);

            var testSettingsameCase = s_testSetting.Clone();
            Assert.AreEqual(testSettingsameCase, s_testSetting);

            //Etag tests
            var testSettingEtagDiff = testSettingsameCase.Clone();
            testSettingsameCase.ETag = new ETag(Guid.NewGuid().ToString());
            testSettingEtagDiff.ETag = new ETag(Guid.NewGuid().ToString());
            Assert.AreNotEqual(testSettingsameCase, testSettingEtagDiff);

            // Different tags
            var testSettingDiffTags = s_testSetting.Clone();
            testSettingDiffTags.Tags.Add("tag3", "test_value3");
            Assert.AreNotEqual(s_testSetting, testSettingDiffTags);
        }

        private bool SettingSelectoComparissonr(SettingSelector actual, SettingSelector other)
        {
            if (actual != null && other == null) return false;
            if (!actual.Keys.SequenceEqual(other.Keys)) return false;
            if (!actual.Labels.SequenceEqual(other.Labels)) return false;
            if (!actual.Fields.Equals(other.Fields)) return false;
            if (actual.AsOf != other.AsOf) return false;
            
            return true;
        }

        [Test]
        public void SettingSelectorCloneWithBatchLink()
        {
            SettingSelector selector = new SettingSelector()
            {
                Keys = new List<string> { "key1", "key2", "key3" },
                Labels = { "label1" },
                Fields = SettingFields.Key | SettingFields.Label | SettingFields.Value,
                AsOf = DateTimeOffset.Now
            };

            var selectorWithLink = selector.CloneWithBatchLink("someLink");

            Assert.IsTrue(SettingSelectoComparissonr(selector, selectorWithLink));

            selector.Keys.Add("Key4");
            selector.Labels.Add("Label2");
            selector.Fields = SettingFields.All;

            Assert.IsFalse(SettingSelectoComparissonr(selector, selectorWithLink));
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
