// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    public class ServiceBusAccountTests
    {
        private readonly IConfiguration _configuration;

        public ServiceBusAccountTests()
        {
            _configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();
        }

        [Fact]
        public void GetConnectionString_ReturnsExpectedConnectionString()
        {
            string defaultConnection = "Endpoint=sb://default.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
            var options = new ServiceBusOptions()
            {
                ConnectionString = defaultConnection
            };
            var attribute = new ServiceBusTriggerAttribute("entity-name");
            var account = new ServiceBusAccount(options, _configuration, attribute);

            Assert.True(defaultConnection == account.ConnectionString);
        }

        [Fact]
        public void GetConnectionString_ThrowsIfConnectionStringNullOrEmpty()
        {
            var config = new ServiceBusOptions();
            var attribute = new ServiceBusTriggerAttribute("testqueue");
            attribute.Connection = "MissingConnection";

            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                var account = new ServiceBusAccount(config, _configuration, attribute);
                var cs = account.ConnectionString;
            });
            Assert.Equal("Microsoft Azure WebJobs SDK ServiceBus connection string 'MissingConnection' is missing or empty.", ex.Message);

            attribute.Connection = null;
            config.ConnectionString = null;
            ex = Assert.Throws<InvalidOperationException>(() =>
            {
                var account = new ServiceBusAccount(config, _configuration, attribute);
                var cs = account.ConnectionString;
            });
            Assert.Equal("Microsoft Azure WebJobs SDK ServiceBus connection string 'AzureWebJobsServiceBus' is missing or empty.", ex.Message);
        }
    }
}
