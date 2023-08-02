// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests
{
    public class DefaultAzureMonitorOptionsTests
    {
        private const string ConnectionStringEnvironmentVariable = "APPLICATIONINSIGHTS_CONNECTION_STRING";

        [Fact]
        public void VerifyConfigure_NoConnectionStringSet()
        {
            var defaultAzureMonitorOptions = new DefaultAzureMonitorOptions();

            var azureMonitorOptions = new AzureMonitorOptions();

            defaultAzureMonitorOptions.Configure(azureMonitorOptions);

            Assert.Null(azureMonitorOptions.ConnectionString);
        }

#if !NETFRAMEWORK
        [Fact]
        public void VerifyConfigure_ViaJson()
        {
            var appSettings = @"{""AzureMonitor"":{
                ""ConnectionString"" : ""testJsonValue""
                }}";

            var configuration = new ConfigurationBuilder()
                .AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(appSettings)))
                .Build();

            var defaultAzureMonitorOptions = new DefaultAzureMonitorOptions(configuration);

            var azureMonitorOptions = new AzureMonitorOptions();

            defaultAzureMonitorOptions.Configure(azureMonitorOptions);

            Assert.Equal("testJsonValue", azureMonitorOptions.ConnectionString);
        }
#endif

        [Fact]
        public void VerifyConfigure_ViaIConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string?> { [ConnectionStringEnvironmentVariable] = "testValue" })
                .Build();

            var defaultAzureMonitorOptions = new DefaultAzureMonitorOptions(configuration);

            var azureMonitorOptions = new AzureMonitorOptions();

            defaultAzureMonitorOptions.Configure(azureMonitorOptions);

            Assert.Equal("testValue", azureMonitorOptions.ConnectionString);
        }

        [Fact]
        public void VerifyConfigure_ViaEnvironmentVar()
        {
            try
            {
                Environment.SetEnvironmentVariable(ConnectionStringEnvironmentVariable, "testEnvVarValue");

                var configuration = new ConfigurationBuilder()
                    .AddEnvironmentVariables()
                    .Build();

                var defaultAzureMonitorOptions = new DefaultAzureMonitorOptions(configuration);

                var azureMonitorOptions = new AzureMonitorOptions();

                defaultAzureMonitorOptions.Configure(azureMonitorOptions);

                Assert.Equal("testEnvVarValue", azureMonitorOptions.ConnectionString);
            }
            finally
            {
                Environment.SetEnvironmentVariable(ConnectionStringEnvironmentVariable, null);
            }
        }
    }
}
