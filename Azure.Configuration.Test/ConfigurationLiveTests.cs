using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Configuration.Tests
{
    [Category("Live")]
    public class ConfigurationLiveTests
    {
        static readonly ConfigurationSetting s_testSetting = new ConfigurationSetting()
        {
            Key = "test_key",
            Value = "test_value",
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

        [Test]
        public async Task DeleteNotFound()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            Response<ConfigurationSetting> response = await service.DeleteAsync(key: s_testSetting.Key, filter: default, CancellationToken.None);

            Assert.AreEqual(204, response.Status);
            Assert.IsNull(response.Result);

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

            await service.SetAsync(s_testSetting, CancellationToken.None);
            await service.SetAsync(testSettingDiff, CancellationToken.None);

            try
            {
                // Test
                Response<ConfigurationSetting> response = await service.DeleteAsync(key: testSettingDiff.Key, filter: testSettingDiff.Label, CancellationToken.None);

                Assert.AreEqual(200, response.Status);

                ConfigurationSetting setting = response.Result;
                AssertEqual(testSettingDiff, setting);

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
            await service.SetAsync(s_testSetting, CancellationToken.None);

            // Test
            Response<ConfigurationSetting> response = await service.DeleteAsync(key: s_testSetting.Key, filter: s_testSetting.Label, CancellationToken.None);

            Assert.AreEqual(200, response.Status);

            ConfigurationSetting setting = response.Result;
            AssertEqual(s_testSetting, setting);

            response.Dispose();
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

                Assert.AreEqual(200, response.Status);
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

                Assert.AreEqual(200, response.Status);
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

            // Prepare environment
            var testSettingDiff = s_testSetting.Clone();
            testSettingDiff.Label = "test_label_diff";

            await service.SetAsync(s_testSetting, CancellationToken.None);
            await service.SetAsync(testSettingDiff, CancellationToken.None);

            var testSettingUpdate = s_testSetting.Clone();
            testSettingUpdate.Value = "test_value_update";
            testSettingUpdate.ETag = "*";

            try
            {
                // Test
                Response<ConfigurationSetting> response = await service.UpdateAsync(testSettingUpdate, CancellationToken.None);

                Assert.AreEqual(200, response.Status);

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
        public async Task Get()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            // Prepare environment
            var testSettingNoLabel = s_testSetting.Clone();
            testSettingNoLabel.Label = null;
            await service.SetAsync(testSettingNoLabel, CancellationToken.None);

            try
            {
                // Test
                Response<ConfigurationSetting> response = await service.GetAsync(key: testSettingNoLabel.Key, filter: default, CancellationToken.None);

                Assert.AreEqual(200, response.Status);
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
        public async Task GetNotFound()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            // Test
            Response<ConfigurationSetting> response = await service.GetAsync(key: s_testSetting.Key, filter: default, CancellationToken.None);

            Assert.AreEqual(404, response.Status);
            Assert.IsNull(response.Result);

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
            await service.SetAsync(testSettingNoLabel, CancellationToken.None);
            await service.SetAsync(s_testSetting, CancellationToken.None);

            try
            {
                // Test
                Response<ConfigurationSetting> response = await service.GetAsync(key: s_testSetting.Key, filter: s_testSetting.Label, CancellationToken.None);

                Assert.AreEqual(200, response.Status);
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
        public async Task LockUnlock()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            // Prepare environment
            await service.SetAsync(s_testSetting, CancellationToken.None);
                        
            try
            {
                // Test Lock
                Response<ConfigurationSetting> responseLock = await service.LockAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);

                Assert.AreEqual(200, responseLock.Status);

                ConfigurationSetting responseLockSetting = responseLock.Result;
                s_testSetting.Locked = true;
                AssertEqual(s_testSetting, responseLockSetting);
                responseLock.Dispose();

                // Test Unlock
                Response<ConfigurationSetting> responseUnlock = await service.UnlockAsync(s_testSetting.Key, s_testSetting.Label, CancellationToken.None);

                Assert.AreEqual(200, responseUnlock.Status);

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
            return new ConfigurationSetting
            {
                Key = setting.Key,
                Value = setting.Value,
                Label = setting.Label,
                ContentType = setting.ContentType,
                LastModified = setting.LastModified,
                Locked = setting.Locked
            };
        }
    }
}
