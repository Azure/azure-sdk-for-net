// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
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
            LastModified = new DateTimeOffset(2018, 11, 28, 9, 55, 0, 0, default),
            Locked = false,
            Tags = new Dictionary<string, string>
            {
                { "tag1", "value1" },
                { "tag2", "value2" }
            }
        };

        private static void AssertEqual(ConfigurationSetting expected, ConfigurationSetting actual)
        {
            Assert.AreEqual(expected.Key, actual.Key);
            Assert.AreEqual(expected.Label, actual.Label);
            Assert.AreEqual(expected.ContentType, actual.ContentType);
            Assert.AreEqual(expected.Locked, actual.Locked);
            Assert.IsTrue(TagsEqual(expected.Tags, actual.Tags));
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
            string key = string.Concat("key-", Guid.NewGuid().ToString("N")); ;
            
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
        public async Task DeleteNotFound()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            var response = await service.DeleteAsync(key: s_testSetting.Key, options: default, CancellationToken.None);

            Assert.AreEqual(204, response.Status);
            response.Dispose();
        }

        [Test]
        public async Task Delete()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            try
            {
                // Prepare environment
                var testSettingDiff = s_testSetting.Clone();
                testSettingDiff.Label = "test_label_diff";
                await service.SetAsync(s_testSetting);
                await service.SetAsync(testSettingDiff);

                // Test
                await service.DeleteAsync(key: testSettingDiff.Key, options: testSettingDiff.Label, CancellationToken.None);
            }
            finally
            {
                await service.DeleteAsync(key: s_testSetting.Key, options: s_testSetting.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task DeleteWithLabel()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            // Prepare environment
            await service.SetAsync(s_testSetting);

            // Test
            await service.DeleteAsync(key: s_testSetting.Key, options: s_testSetting.Label, CancellationToken.None);
        }

        [Test]
        public async Task DeleteWithETag()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            // Prepare environment
            await service.SetAsync(s_testSetting);

            // Test
            ConfigurationSetting settting = await service.GetAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);
            RequestOptions options = new RequestOptions()
            {
                ETag = new ETagFilter() { IfMatch = new ETag(settting.ETag) },
                Label = settting.Label
            };

            await service.DeleteAsync(key: s_testSetting.Key, options: options, CancellationToken.None);
        }

        [Test]
        public async Task Set()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            try
            {
                Response<ConfigurationSetting> response = await service.SetAsync(s_testSetting);

                Assert.True(response.TryGetHeader("ETag", out string etagHeader));

                ConfigurationSetting setting = response.Result;
                AssertEqual(s_testSetting, setting);
                response.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: s_testSetting.Key, options: s_testSetting.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task Add()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            try
            {
                Response<ConfigurationSetting> response = await service.AddAsync(s_testSetting);

                Assert.True(response.TryGetHeader("ETag", out string etagHeader));

                ConfigurationSetting setting = response.Result;
                AssertEqual(s_testSetting, setting);
                response.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: s_testSetting.Key, options: s_testSetting.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task UpdateIfAny()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            var testSettingDiff = s_testSetting.Clone();
            testSettingDiff.Label = "test_label_diff";

            var testSettingUpdate = s_testSetting.Clone();
            testSettingUpdate.Value = "test_value_update";

            try
            {
                await service.SetAsync(s_testSetting);
                await service.SetAsync(testSettingDiff);

                RequestOptions options = new RequestOptions()
                {
                    ETag = new ETagFilter() { IfMatch = new ETag("*") }
                };

                ConfigurationSetting responseSetting = await service.UpdateAsync(testSettingUpdate, options, CancellationToken.None);

                AssertEqual(testSettingUpdate, responseSetting);
            }
            finally
            {
                await service.DeleteAsync(key: testSettingUpdate.Key, options: testSettingUpdate.Label, CancellationToken.None);
                await service.DeleteAsync(key: testSettingDiff.Key, options: testSettingDiff.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task UpdateIfETag()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            await service.SetAsync(s_testSetting);
            ConfigurationSetting responseGet = await service.GetAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);

            var testSettingDiff = responseGet.Clone();
            testSettingDiff.Value = "test_value_diff";

            try
            {
                RequestOptions options = new RequestOptions()
                {
                    ETag = new ETagFilter() { IfMatch = new ETag(testSettingDiff.ETag) }
                };

                ConfigurationSetting responseSetting = await service.UpdateAsync(testSettingDiff, options, CancellationToken.None);

                AssertEqual(testSettingDiff, responseSetting);
            }
            finally
            {
                await service.DeleteAsync(key: testSettingDiff.Key, options: testSettingDiff.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task UpdateIfNoMatch()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            await service.SetAsync(s_testSetting);
            ConfigurationSetting setting = await service.GetAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);

            try
            {
                RequestOptions options = new RequestOptions()
                {
                    ETag = new ETagFilter() { IfNoneMatch = new ETag(setting.ETag) }
                };

                var exception = Assert.ThrowsAsync<ResponseFailedException>(async () =>
                {
                    await service.UpdateAsync(setting, options, CancellationToken.None);
                });

                var response = exception.Response;
                Assert.AreEqual(412, response.Status);
            }
            finally
            {
                await service.DeleteAsync(key: setting.Key, options: setting.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task UpdateWrongETag()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            var testSettingDiff = s_testSetting.Clone();
            testSettingDiff.Value = "test_value_diff";

            try
            {
                await service.SetAsync(s_testSetting);

                var eTag = "ehHuajgQNq5Qg4ruJVB7hlhX8xs";
                RequestOptions options = new RequestOptions()
                {
                    ETag = new ETagFilter() { IfMatch = new ETag(eTag) }
                };

                var exception = Assert.ThrowsAsync<ResponseFailedException>(async () =>
                {
                    await service.UpdateAsync(testSettingDiff, options, CancellationToken.None);
                });

                var response = exception.Response;
                Assert.AreEqual(412, response.Status);
            }
            finally
            {
                await service.DeleteAsync(key: s_testSetting.Key, options: s_testSetting.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task UpdateTags()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            await service.SetAsync(s_testSetting);
            ConfigurationSetting responseGet = await service.GetAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);

            RequestOptions options = new RequestOptions()
            {
                ETag = new ETagFilter() { IfMatch = new ETag("*") }
            };
            
            try
            {
                // Different tags
                var testSettingDiff = responseGet.Clone();
                var settingTags = testSettingDiff.Tags;
                if (settingTags.ContainsKey("tag1")) settingTags["tag1"] = "value-updated";
                settingTags.Add("tag3", "test_value3");
                testSettingDiff.Tags = settingTags;
                
                ConfigurationSetting responseSetting = await service.UpdateAsync(testSettingDiff, options, CancellationToken.None);
                AssertEqual(testSettingDiff, responseSetting);

                // No tags
                var testSettingNoTags = responseGet.Clone();
                testSettingNoTags.Tags = null;

                responseSetting = await service.UpdateAsync(testSettingNoTags, options, CancellationToken.None);
                AssertEqual(testSettingNoTags, responseSetting);
            }
            finally
            {
                await service.DeleteAsync(key: s_testSetting.Key, options: s_testSetting.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task GetIfNoMatch()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            await service.SetAsync(s_testSetting);
            ConfigurationSetting setting = await service.GetAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);
            
            try
            {
                RequestOptions options = new RequestOptions()
                {
                    Label = setting.Label,
                    ETag = new ETagFilter() { IfNoneMatch = new ETag(setting.ETag) }
                };

                var exception = Assert.ThrowsAsync<ResponseFailedException>(async () =>
                {
                    await service.GetAsync(setting.Key, options, CancellationToken.None);
                });

                var response = exception.Response;
                Assert.AreEqual(304, response.Status);
            }
            finally
            {
                await service.DeleteAsync(key: setting.Key, options: setting.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task Revisions()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
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
                var filter = new BatchRequestOptions();
                filter.Key = setting.Key;
                filter.Revision = DateTimeOffset.MaxValue;
                SettingBatch batch = await service.GetRevisionsAsync(filter, CancellationToken.None);

                int resultsReturned = 0;
                for (int i = 0; i < batch.Count; i++)
                {
                    var value = batch[i];
                    if (value.Label.Contains("update"))
                    {
                        AssertEqual(value, testSettingUpdate);
                    }
                    else
                    {
                        AssertEqual(value, setting);
                    }
                    resultsReturned++;
                }

                Assert.AreEqual(expectedEvents, resultsReturned);
            }
            finally
            {
                await service.DeleteAsync(key: setting.Key, options: setting.Label, CancellationToken.None);
                await service.DeleteAsync(key: testSettingUpdate.Key, options: testSettingUpdate.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task Get()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            // Prepare environment
            var testSettingNoLabel = s_testSetting.Clone();
            testSettingNoLabel.Label = null;
            
            try
            {
                await service.SetAsync(testSettingNoLabel);
                // Test
                Response<ConfigurationSetting> response = await service.GetAsync(key: testSettingNoLabel.Key, options: default, CancellationToken.None);

                Assert.True(response.TryGetHeader("ETag", out string etagHeader));

                ConfigurationSetting setting = response.Result;
                AssertEqual(testSettingNoLabel, setting);
                response.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: testSettingNoLabel.Key, options: default, CancellationToken.None);
            }
        }

        [Test]
        public void GetNotFound()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);
            
            var e = Assert.ThrowsAsync<ResponseFailedException>(async () =>
            {
                await service.GetAsync(key: s_testSetting.Key, options: default, CancellationToken.None);
            });

            var response = e.Response;
            Assert.AreEqual(404, response.Status);
            response.Dispose();
        }

        [Test]
        public async Task GetWithLabel()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            // Prepare environment
            var testSettingNoLabel = s_testSetting.Clone();
            testSettingNoLabel.Label = null;
            
            try
            {
                await service.SetAsync(testSettingNoLabel);
                await service.SetAsync(s_testSetting);

                // Test
                Response<ConfigurationSetting> response = await service.GetAsync(key: s_testSetting.Key, options: s_testSetting.Label, CancellationToken.None);

                Assert.True(response.TryGetHeader("ETag", out string etagHeader));

                ConfigurationSetting responseSetting = response.Result;
                AssertEqual(s_testSetting, responseSetting);
                response.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: s_testSetting.Key, options: s_testSetting.Label, CancellationToken.None);
                await service.DeleteAsync(key: testSettingNoLabel.Key, options: default, CancellationToken.None);
            }
        }

        [Test]
        public async Task GetBatchPagination()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            const int expectedEvents = 105;
            var key = await SetMultipleKeys(service, expectedEvents);

            int resultsReturned = 0;
            BatchRequestOptions options = new BatchRequestOptions() { Key = key };
            while (true)
            {
                using (Response<SettingBatch> response = await service.GetBatchAsync(options, CancellationToken.None))
                {
                    SettingBatch batch = response.Result;
                    resultsReturned += batch.Count;
                    options = batch.NextBatch;

                    if (string.IsNullOrEmpty(options.BatchLink)) break;
                }
            }
            Assert.AreEqual(expectedEvents, resultsReturned);
        }


        [Test]
        public async Task GetBatchWithFields()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            try
            {
                await service.SetAsync(s_testSetting);

                BatchRequestOptions options = new BatchRequestOptions()
                {
                    Fields = SettingFields.Key | SettingFields.Label | SettingFields.Value
                };

                SettingBatch batch = await service.GetBatchAsync(options, CancellationToken.None);
                int resultsReturned = batch.Count;

                //At least there should be one key available
                Assert.GreaterOrEqual(resultsReturned, 1);
            }
            finally
            {
                await service.DeleteAsync(key: s_testSetting.Key, options: s_testSetting.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task GetWithNullLabel()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            var testSettingNoLabel = s_testSetting.Clone();
            testSettingNoLabel.Label = null;
            
            try
            {
                await service.SetAsync(testSettingNoLabel);

                ConfigurationSetting setting = await service.GetAsync(testSettingNoLabel.Key, LabelFilters.Null, CancellationToken.None);
                
                AssertEqual(testSettingNoLabel, setting);
            }
            finally
            {
                await service.DeleteAsync(key: testSettingNoLabel.Key);
            }
        }

        [Test]
        public async Task LockUnlock()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            try
            {
                // Prepare environment
                await service.SetAsync(s_testSetting);

                // Test Lock
                ConfigurationSetting responseLockSetting = await service.LockAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);

                s_testSetting.Locked = true;
                AssertEqual(s_testSetting, responseLockSetting);
                
                //Test update
                var testSettingUpdate = s_testSetting.Clone();
                testSettingUpdate.Value = "test_value_update";

                var e = Assert.ThrowsAsync<ResponseFailedException>(async () =>
                {
                    await service.UpdateAsync(testSettingUpdate);
                });
                var response = e.Response;
                Assert.AreEqual(403, response.Status);
                response.Dispose();
                
                // Test Unlock
                ConfigurationSetting responseUnlockSetting = await service.UnlockAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);

                s_testSetting.Locked = false;
                AssertEqual(s_testSetting, responseUnlockSetting);
            }
            finally
            {
                await service.DeleteAsync(key: s_testSetting.Key, options: s_testSetting.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task GetWithRequestId()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            try
            {
                var options = new RequestOptions() { RequestId = Guid.NewGuid() };
                Response<ConfigurationSetting> response = await service.SetAsync(s_testSetting, options, CancellationToken.None);

                Assert.True(response.TryGetHeader("ETag", out string etagHeader));
                response.TryGetHeader("x-ms-client-request-id", out string requestId);

                ConfigurationSetting setting = response.Result;
                AssertEqual(s_testSetting, setting);
                Assert.AreEqual(requestId, options.RequestId.ToString());
                response.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: s_testSetting.Key, options: s_testSetting.Label, CancellationToken.None);
            }
        }
    }

    public static class ConfigurationSettingExtensions
    {
        public static ConfigurationSetting Clone(this ConfigurationSetting setting)
        {
            return new ConfigurationSetting(setting.Key, setting.Value)
            {
                Label = setting.Label,
                ContentType = setting.ContentType,
                LastModified = setting.LastModified,
                Locked = setting.Locked,
                ETag = setting.ETag,
                Tags = setting.Tags
            };
        }
    }
}
