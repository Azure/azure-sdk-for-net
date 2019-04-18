using NUnit.Framework;
using System;

namespace Azure.ApplicationModel.Configuration.Tests
{
    public static class TestEnvironment
    {
        public static ConfigurationClient GetClient()
        {
            var connectionString = Environment.GetEnvironmentVariable("APP_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set APP_CONFIG_CONNECTION environment variable to the connection string");
            return new ConfigurationClient(connectionString);
        }
    }
}
