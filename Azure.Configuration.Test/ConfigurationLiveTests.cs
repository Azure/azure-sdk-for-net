using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Configuration.Tests
{
    public class ConfigurationLiveTests
    {
        static readonly ConfigurationSetting s_testSetting = new ConfigurationSetting()
        {
            Key = "test_key",
            Label = "test_label",
            Value = "test_value",
            ContentType = "test_content_type",
            LastModified = new DateTimeOffset(2018, 11, 28, 9, 55, 0, 0, default),
            Locked = false
        };


        [Test]
        public async Task Set()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");
            var service = new ConfigurationClient(connectionString);

            Response<ConfigurationSetting> response = await service.SetAsync(s_testSetting, CancellationToken.None);

            Assert.AreEqual(200, response.Status);
            Assert.True(response.TryGetHeader("ETag", out string etagHeader));

            ConfigurationSetting setting = response.Result;

            Assert.AreEqual(s_testSetting.Value, setting.Value);

            response.Dispose();
        }
    }
}
