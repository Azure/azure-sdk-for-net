using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Configuration.Tests
{
    public class ConfigurationLiveTests
    {
        private static void AssertEqual(ConfigurationSetting expected, ConfigurationSetting actual)
        {
            Assert.AreEqual(expected.Key, actual.Key);
            Assert.AreEqual(expected.Label, actual.Label);
            Assert.AreEqual(expected.ContentType, actual.ContentType);
            Assert.AreEqual(expected.Locked, actual.Locked);
        }

        [Test]
        public async Task Set()
        {
            ConfigurationSetting testSetting = new ConfigurationSetting()
            {
                Key = "test_key_set",
                Label = "test_label_set",
                Value = "test_value_set",
                ETag = "c3c231fd-39a0-4cb6-3237-4614474b92c6",
                ContentType = "test_content_type",
                LastModified = new DateTimeOffset(2018, 11, 28, 9, 55, 0, 0, default),
                Locked = false
            };

            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            Response<ConfigurationSetting> response = await service.SetAsync(testSetting, CancellationToken.None);

            Assert.AreEqual(200, response.Status);
            Assert.True(response.TryGetHeader("ETag", out string etagHeader));
            
            ConfigurationSetting setting = response.Result;

            AssertEqual(testSetting, setting);

            response.Dispose();
        }

        [Test]
        public async Task UpdateIfAny()
        {
            ConfigurationSetting testSetting = new ConfigurationSetting()
            {
                Key = "test_key_update",
                Label = "test_label_update",
                Value = "test_value_update",
                ETag = "*",
                ContentType = "test_content_type",
                LastModified = new DateTimeOffset(2018, 11, 28, 9, 55, 0, 0, default),
                Locked = false
            };

            ConfigurationSetting testSetting2 = new ConfigurationSetting()
            {
                Key = "test_key_update",
                Label = "test_label_update_2",
                Value = "test_value_update_2",
                ETag = "*",
                ContentType = "test_content_type",
                LastModified = new DateTimeOffset(2018, 11, 28, 9, 55, 0, 0, default),
                Locked = false
            };

            ConfigurationSetting testSettingNewValue = new ConfigurationSetting()
            {
                Key = "test_key_update",
                Label = "test_label_update",
                Value = "test_value_update_3",
                ETag = "*",
                ContentType = "test_content_type",
                LastModified = new DateTimeOffset(2018, 11, 28, 9, 55, 0, 0, default),
                Locked = false
            };
                       

            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            // Prepare environment
            await service.SetAsync(testSetting, CancellationToken.None);
            await service.SetAsync(testSetting2, CancellationToken.None);
            
            // Test
            Response<ConfigurationSetting> response = await service.UpdateAsync(testSettingNewValue, CancellationToken.None);

            Assert.AreEqual(200, response.Status);
            
            ConfigurationSetting responseSetting = response.Result;

            AssertEqual(testSettingNewValue, responseSetting);

            response.Dispose();
        }

        [Test]
        public async Task Get()
        {
            ConfigurationSetting testSetting = new ConfigurationSetting()
            {
                Key = "test_key_get",
                Value = "test_value_get",
                ETag = "c3c231fd-39a0-4cb6-3237-4614474b92c6",
                ContentType = "test_content_type",
                LastModified = new DateTimeOffset(2018, 11, 28, 9, 55, 0, 0, default),
                Locked = false
            };

            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            // Prepare environment
            await service.SetAsync(testSetting, CancellationToken.None);

            // Test
            Response<ConfigurationSetting> response = await service.GetAsync(key:testSetting.Key, filter: default, CancellationToken.None);

            Assert.AreEqual(200, response.Status);
            Assert.True(response.TryGetHeader("ETag", out string etagHeader));

            ConfigurationSetting setting = response.Result;

            AssertEqual(testSetting, setting);

            response.Dispose();
        }

        [Test]
        public async Task GetWithLabel()
        {
            ConfigurationSetting testSettingNoLabel = new ConfigurationSetting()
            {
                Key = "test_key_getl",
                Value = "test_value_getl",
                ETag = "c3c231fd-39a0-4cb6-3237-4614474b92c6",
                ContentType = "test_content_type",
                LastModified = new DateTimeOffset(2018, 11, 28, 9, 55, 0, 0, default),
                Locked = false
            };

            ConfigurationSetting testSettingWithLabel = new ConfigurationSetting()
            {
                Key = "test_key_getl",
                Label = "test_label_getl",
                Value = "test_value_getl",
                ETag = "c3c231fd-39a0-4cb6-3237-4614474b92c6",
                ContentType = "test_content_type",
                LastModified = new DateTimeOffset(2018, 11, 28, 9, 55, 0, 0, default),
                Locked = false
            };

            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            // Prepare environment
            await service.SetAsync(testSettingNoLabel, CancellationToken.None);
            await service.SetAsync(testSettingWithLabel, CancellationToken.None);

            // Test
            Response<ConfigurationSetting> response = await service.GetAsync(key: testSettingWithLabel.Key, filter: new SettingFilter() { Label = testSettingWithLabel.Label }, CancellationToken.None);

            Assert.AreEqual(200, response.Status);
            Assert.True(response.TryGetHeader("ETag", out string etagHeader));

            ConfigurationSetting responseSetting = response.Result;

            AssertEqual(testSettingWithLabel, responseSetting);

            response.Dispose();
        }

    }
}
