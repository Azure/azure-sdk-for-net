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
            Locked = false
        };

        private static void AssertEqual(ConfigurationSetting expected, ConfigurationSetting actual)
        {
            Assert.AreEqual(expected.Key, actual.Key);
            Assert.AreEqual(expected.Label, actual.Label);
            Assert.AreEqual(expected.ContentType, actual.ContentType);
            Assert.AreEqual(expected.Locked, actual.Locked);
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

            var response = await service.DeleteAsync(key: s_testSetting.Key, filter: default, CancellationToken.None);

            Assert.AreEqual(204, response.Status);
            response.Dispose();
        }

        [Test]
        public async Task Delete()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            // Prepare environment
            var testSettingDiff = s_testSetting.Clone();
            testSettingDiff.Label = "test_label_diff";

            Response<ConfigurationSetting> responseSet = await service.SetAsync(s_testSetting, CancellationToken.None);
            Response<ConfigurationSetting> responseSetDiff = await service.SetAsync(testSettingDiff, CancellationToken.None);

            try
            {
                // Test
                var response = await service.DeleteAsync(key: testSettingDiff.Key, filter: testSettingDiff.Label, CancellationToken.None);
                response.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: s_testSetting.Key, filter: s_testSetting.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task DeleteWithLabel()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            // Prepare environment
            Response<ConfigurationSetting> responseSet = await service.SetAsync(s_testSetting, CancellationToken.None);

            // Test
            var response = await service.DeleteAsync(key: s_testSetting.Key, filter: s_testSetting.Label, CancellationToken.None);

            response.Dispose();
            responseSet.Dispose();
        }

        [Test]
        public async Task DeleteWithETag()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            // Prepare environment
            Response<ConfigurationSetting> responseSet = await service.SetAsync(s_testSetting, CancellationToken.None);
            Response<ConfigurationSetting> responseGet = await service.GetAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);

            // Test
            ConfigurationSetting settting = responseGet.Result;
            SettingFilter filter = new SettingFilter()
            {
                ETag = new ETagFilter() { IfMatch = new ETag(settting.ETag) },
                Label = settting.Label
            };

            Response response = await service.DeleteAsync(key: s_testSetting.Key, filter: filter, CancellationToken.None);

            response.Dispose();
            responseSet.Dispose();
            responseGet.Dispose();
        }

        [Test]
        public async Task Set()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            try
            {
                Response<ConfigurationSetting> response = await service.SetAsync(s_testSetting, CancellationToken.None);

                Assert.True(response.TryGetHeader("ETag", out string etagHeader));

                ConfigurationSetting setting = response.Result;
                AssertEqual(s_testSetting, setting);
                response.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: s_testSetting.Key, filter: s_testSetting.Label, CancellationToken.None);
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
                Response<ConfigurationSetting> response = await service.AddAsync(s_testSetting, CancellationToken.None);

                Assert.True(response.TryGetHeader("ETag", out string etagHeader));

                ConfigurationSetting setting = response.Result;
                AssertEqual(s_testSetting, setting);
                response.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: s_testSetting.Key, filter: s_testSetting.Label, CancellationToken.None);
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

            Response<ConfigurationSetting> responseSet = await service.SetAsync(s_testSetting, CancellationToken.None);
            Response<ConfigurationSetting> responseSetDiff = await service.SetAsync(testSettingDiff, CancellationToken.None);
            
            var testSettingUpdate = s_testSetting.Clone();
            testSettingUpdate.Value = "test_value_update";

            try
            {
                SettingFilter filter = new SettingFilter()
                {
                    ETag = new ETagFilter() { IfMatch = new ETag("*") }
                };

                Response<ConfigurationSetting> response = await service.UpdateAsync(testSettingUpdate, filter, CancellationToken.None);

                ConfigurationSetting responseSetting = response.Result;
                AssertEqual(testSettingUpdate, responseSetting);
                response.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: testSettingUpdate.Key, filter: testSettingUpdate.Label, CancellationToken.None);
                await service.DeleteAsync(key: testSettingDiff.Key, filter: testSettingDiff.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task UpdateIfETag()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            Response<ConfigurationSetting> responseSet = await service.SetAsync(s_testSetting, CancellationToken.None);
            Response<ConfigurationSetting> responseGet = await service.GetAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);

            var testSettingDiff = responseGet.Result.Clone();
            testSettingDiff.Value = "test_value_diff";

            try
            {
                SettingFilter filter = new SettingFilter()
                {
                    ETag = new ETagFilter() { IfMatch = new ETag(testSettingDiff.ETag) }
                };
                Response<ConfigurationSetting> response = await service.UpdateAsync(testSettingDiff, filter, CancellationToken.None);

                ConfigurationSetting responseSetting = response.Result;
                AssertEqual(testSettingDiff, responseSetting);
                response.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: testSettingDiff.Key, filter: testSettingDiff.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task UpdateIfNoMatch()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            Response<ConfigurationSetting> responseSet = await service.SetAsync(s_testSetting, CancellationToken.None);
            Response<ConfigurationSetting> responseGet = await service.GetAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);
            var setting = responseGet.Result;

            try
            {
                SettingFilter filter = new SettingFilter()
                {
                    ETag = new ETagFilter() { IfNoneMatch = new ETag(setting.ETag) }
                };

                var exception = Assert.ThrowsAsync<ResponseFailedException>(async () =>
                {
                    await service.UpdateAsync(setting, filter, CancellationToken.None);
                });

                var response = exception.Response;
                Assert.AreEqual(412, response.Status);

                responseSet.Dispose();
                responseGet.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: setting.Key, filter: setting.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task UpdateWrongETag()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            Response<ConfigurationSetting> responseSet = await service.SetAsync(s_testSetting, CancellationToken.None);
            
            var testSettingDiff = s_testSetting.Clone();
            testSettingDiff.Value = "test_value_diff";

            try
            {
                var eTag = "ehHuajgQNq5Qg4ruJVB7hlhX8xs";
                SettingFilter filter = new SettingFilter()
                {
                    ETag = new ETagFilter() { IfMatch = new ETag(eTag) }
                };

                var exception = Assert.ThrowsAsync<ResponseFailedException>(async () =>
                {
                    await service.UpdateAsync(testSettingDiff, filter, CancellationToken.None);
                });

                var response = exception.Response;
                Assert.AreEqual(412, response.Status);

                responseSet.Dispose();
            }
            finally
            {
                var responseDelete = await service.DeleteAsync(key: s_testSetting.Key, filter: s_testSetting.Label, CancellationToken.None);
            }
        }

        [Test]
        public async Task GetIfNoMatch()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            Response<ConfigurationSetting> responseSet = await service.SetAsync(s_testSetting, CancellationToken.None);
            Response<ConfigurationSetting> responseGet = await service.GetAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);
            var setting = responseGet.Result;

            try
            {
                SettingFilter filter = new SettingFilter()
                {
                    Label = setting.Label,
                    ETag = new ETagFilter() { IfNoneMatch = new ETag(setting.ETag) }
                };

                var exception = Assert.ThrowsAsync<ResponseFailedException>(async () =>
                {
                    await service.GetAsync(setting.Key, filter, CancellationToken.None);
                });

                var response = exception.Response;
                Assert.AreEqual(304, response.Status);
                
                responseSet.Dispose();
                responseGet.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: setting.Key, filter: setting.Label, CancellationToken.None);
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

            Response<ConfigurationSetting> responseSet = await service.SetAsync(setting, CancellationToken.None);
            Response<ConfigurationSetting> responseSetUpdate = await service.SetAsync(testSettingUpdate, CancellationToken.None);

            try
            {
                // Test
                var filter = new SettingBatchFilter();
                filter.Key = setting.Key;

                Response<SettingBatch> response = await service.GetRevisionsAsync(filter, CancellationToken.None);

                int resultsReturned = 0;
                SettingBatch batch = response.Result;
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
                response.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: setting.Key, filter: setting.Label, CancellationToken.None);
                await service.DeleteAsync(key: testSettingUpdate.Key, filter: testSettingUpdate.Label, CancellationToken.None);
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
            Response<ConfigurationSetting> responseSet = await service.SetAsync(testSettingNoLabel, CancellationToken.None);

            try
            {
                // Test
                Response<ConfigurationSetting> response = await service.GetAsync(key: testSettingNoLabel.Key, filter: default, CancellationToken.None);

                Assert.True(response.TryGetHeader("ETag", out string etagHeader));

                ConfigurationSetting setting = response.Result;
                AssertEqual(testSettingNoLabel, setting);
                response.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: testSettingNoLabel.Key, filter: default, CancellationToken.None);
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
                await service.GetAsync(key: s_testSetting.Key, filter: default, CancellationToken.None);
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
            Response<ConfigurationSetting> responseSetNoLabel = await service.SetAsync(testSettingNoLabel, CancellationToken.None);
            Response<ConfigurationSetting> responseSet = await service.SetAsync(s_testSetting, CancellationToken.None);
            
            try
            {
                // Test
                Response<ConfigurationSetting> response = await service.GetAsync(key: s_testSetting.Key, filter: s_testSetting.Label, CancellationToken.None);

                Assert.True(response.TryGetHeader("ETag", out string etagHeader));

                ConfigurationSetting responseSetting = response.Result;
                AssertEqual(s_testSetting, responseSetting);
                response.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: s_testSetting.Key, filter: s_testSetting.Label, CancellationToken.None);
                await service.DeleteAsync(key: testSettingNoLabel.Key, filter: default, CancellationToken.None);
            }
        }

        [Test]
        public async Task GetBatch()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            const int expectedEvents = 105;
            var key = await SetMultipleKeys(service, expectedEvents);

            int resultsReturned = 0;
            SettingBatchFilter filter = new SettingBatchFilter() { Key = key };
            while (true)
            {
                using (Response<SettingBatch> response = await service.GetBatchAsync(filter, CancellationToken.None))
                {
                    SettingBatch batch = response.Result;
                    resultsReturned += batch.Count;
                    filter.BatchLink = batch.Link;

                    if (string.IsNullOrEmpty(filter.BatchLink)) break;
                }
            }
            Assert.AreEqual(expectedEvents, resultsReturned);
        }


        [Test]
        public async Task GetList()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            Response<ConfigurationSetting> responseSet = await service.SetAsync(s_testSetting, CancellationToken.None);

            try
            {
                Response<SettingBatch> response = await service.GetListAsync(CancellationToken.None);
                
                SettingBatch batch = response.Result;

                int resultsReturned = batch.Count;
                //At least there should be one key available
                Assert.GreaterOrEqual(resultsReturned, 1);
                response.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: s_testSetting.Key, filter: s_testSetting.Label, CancellationToken.None);
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
            Response<ConfigurationSetting> responseSet = await service.SetAsync(testSettingNoLabel, CancellationToken.None);
            
            try
            {
                var response = await service.GetAsync(testSettingNoLabel.Key, LabelFilters.Null, CancellationToken.None);
                
                ConfigurationSetting setting = response.Result;
                AssertEqual(testSettingNoLabel, setting);

                response.Dispose();
                responseSet.Dispose();
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

            // Prepare environment
            Response<ConfigurationSetting> responseSet = await service.SetAsync(s_testSetting, CancellationToken.None);

            try
            {
                // Test Lock
                Response<ConfigurationSetting> responseLock = await service.LockAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);

                ConfigurationSetting responseLockSetting = responseLock.Result;
                s_testSetting.Locked = true;
                AssertEqual(s_testSetting, responseLockSetting);
                responseLock.Dispose();

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
                Response<ConfigurationSetting> responseUnlock = await service.UnlockAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);

                ConfigurationSetting responseUnlockSetting = responseUnlock.Result;
                s_testSetting.Locked = false;
                AssertEqual(s_testSetting, responseUnlockSetting);
                responseUnlock.Dispose();
            }
            finally
            {
                await service.DeleteAsync(key: s_testSetting.Key, filter: s_testSetting.Label, CancellationToken.None);
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
                ETag = setting.ETag
            };
        }
    }
}
