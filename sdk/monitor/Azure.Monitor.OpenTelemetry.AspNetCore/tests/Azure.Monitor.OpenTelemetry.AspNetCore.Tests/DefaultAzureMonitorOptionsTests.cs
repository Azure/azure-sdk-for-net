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
    [CollectionDefinition("ManipulatesEnvironmentVariable", DisableParallelization = true)]
    [Collection("ManipulatesEnvironmentVariable")] // These tests need to manipulate environment variables and must not be run in parallel.
    public class DefaultAzureMonitorOptionsTests
    {
        private const string ConnectionStringEnvironmentVariable = "APPLICATIONINSIGHTS_CONNECTION_STRING";

        [Fact]
        public void VerifyConfigure_Default()
        {
            var defaultAzureMonitorOptions = new DefaultAzureMonitorOptions();

            var azureMonitorOptions = new AzureMonitorOptions();

            defaultAzureMonitorOptions.Configure(azureMonitorOptions);

            Assert.Null(azureMonitorOptions.ConnectionString);
            Assert.False(azureMonitorOptions.DisableOfflineStorage);
            Assert.Equal(1.0F, azureMonitorOptions.SamplingRatio);
            Assert.Null(azureMonitorOptions.StorageDirectory);
        }

#if NET
        [Fact]
        public void VerifyConfigure_ViaJson()
        {
            var appSettings = @"{""AzureMonitor"":{
                ""ConnectionString"" : ""testJsonValue"",
                ""DisableOfflineStorage"" : ""true"",
                ""SamplingRatio"" : 0.5,
                ""StorageDirectory"" : ""testJsonValue""
                }}";

            var configuration = new ConfigurationBuilder()
                .AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(appSettings)))
                .Build();

            var defaultAzureMonitorOptions = new DefaultAzureMonitorOptions(configuration);

            var azureMonitorOptions = new AzureMonitorOptions();

            defaultAzureMonitorOptions.Configure(azureMonitorOptions);

            Assert.Equal("testJsonValue", azureMonitorOptions.ConnectionString);
            Assert.True(azureMonitorOptions.DisableOfflineStorage);
            Assert.Equal(0.5F, azureMonitorOptions.SamplingRatio);
            Assert.Equal("testJsonValue", azureMonitorOptions.StorageDirectory);
        }

        [Theory]
        [InlineData(false, false, false, false, false, null)] // If nothing set, ConnectionString will be null.
        [InlineData(true, false, false, false, false, "testJsonValue")] // only AzureMonitor in json
        [InlineData(false, true, false, false, false, "testJsonEnvVarValue")] // only EnvVar in json
        [InlineData(true, true, false, false, false, "testJsonEnvVarValue")] // both AzureMonitor & EnvVar in json
        [InlineData(false, false, true, false, false, "testInMemoryCollectionValue")] // only IConfig InMemoryCollection
        [InlineData(false, false, false, true, false, null)] // only IConfig EnvVars, without EnvVar set.
        [InlineData(false, false, false, true, true, "testEnvVarValue")] // only IConfig EnvVars, with EnvVar set.
        [InlineData(false, false, true, true, true, "testEnvVarValue")] // both IConfig InMemoryCollection & IConfig EnvVars with EnvVar set
        [InlineData(false, false, true, true, false, "testInMemoryCollectionValue")] // both IConfig InMemoryCollection & IConfig EnvVars without EnvVar set
        [InlineData(false, false, false, false, true, "testEnvVarValue")] // only EnvironmentVariable
        [InlineData(true, true, true, true, true, "testEnvVarValue")]
        public void VerifyConfigure_SetsConnectionString(bool jsonAzureMonitor, bool jsonEnvVar, bool iconfigCollection, bool iconfigEnvVar, bool setEnvVar, string expectedConnectionStringValue)
        {
            try
            {
                Environment.SetEnvironmentVariable(ConnectionStringEnvironmentVariable, setEnvVar ? "testEnvVarValue" : null);

                // BUILD JSON STRING
                var jsonString = "{";

                if (jsonAzureMonitor)
                {
                    jsonString += @"""AzureMonitor"":{ ""ConnectionString"" : ""testJsonValue"" }";
                }

                if (jsonAzureMonitor && jsonEnvVar)
                {
                    jsonString += ",";
                }

                if (jsonEnvVar)
                {
                    jsonString += @"""APPLICATIONINSIGHTS_CONNECTION_STRING"" :  ""testJsonEnvVarValue""";
                }

                jsonString += "}";

                // BUILD CONFIGURATION OBJECT
                var configBulider = new ConfigurationBuilder();

                if (jsonAzureMonitor || jsonEnvVar)
                {
                    configBulider.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(jsonString)));
                }

                if (iconfigCollection)
                {
                    configBulider.AddInMemoryCollection(new Dictionary<string, string?> { [ConnectionStringEnvironmentVariable] = "testInMemoryCollectionValue" });
                }

                if (iconfigEnvVar)
                {
                    // TODO: This test case requires a fix, even after commenting this section test passes.
                    // configBulider.AddEnvironmentVariables();
                }

                var configuration = configBulider.Build();

                // RUN TEST
                var defaultAzureMonitorOptions = new DefaultAzureMonitorOptions(configuration);
                var azureMonitorOptions = new AzureMonitorOptions();
                defaultAzureMonitorOptions.Configure(azureMonitorOptions);
                Assert.Equal(expectedConnectionStringValue, azureMonitorOptions.ConnectionString);
            }
            finally
            {
                Environment.SetEnvironmentVariable(ConnectionStringEnvironmentVariable, null);
            }
        }
#endif

        [Fact]
        public void VerifyConfig_SetsConnectionString_WithoutIConfig()
        {
            try
            {
                Environment.SetEnvironmentVariable(ConnectionStringEnvironmentVariable, "testEnvVarValue");

                var defaultAzureMonitorOptions = new DefaultAzureMonitorOptions();
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
