// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests
{
    public class OpenTelemetryBuilderExtensionsTests
    {
#if NET
        private const string ConnectionStringEnvironmentVariable = "APPLICATIONINSIGHTS_CONNECTION_STRING";

        [Theory]
        [InlineData(false, false, false, false, false, false, null)] // If nothing set, ConnectionString will be null.
        [InlineData(true, false, false, false, false, false, null)] // If nothing set, ConnectionString will be null.
        [InlineData(false, true, false, false, false, false, "testJsonValue")] // only AzureMonitor in json
        [InlineData(true, true, false, false, false, false, null)] // only AzureMonitor in json
        [InlineData(false, false, true, false, false, false, "testJsonEnvVarValue")] // only EnvVar in json
        [InlineData(true, false, true, false, false, false, "testJsonEnvVarValue")] // only EnvVar in json
        [InlineData(false, true, true, false, false, false, "testJsonEnvVarValue")] // both AzureMonitor & EnvVar in json
        [InlineData(true, true, true, false, false, false, "testJsonEnvVarValue")] // both AzureMonitor & EnvVar in json
        [InlineData(false, false, false, true, false, false, "testInMemoryCollectionValue")] // only IConfig InMemoryCollection
        [InlineData(true, false, false, true, false, false, "testInMemoryCollectionValue")] // only IConfig InMemoryCollection
        [InlineData(false, false, false, false, true, false, null)] // only IConfig EnvVars, without EnvVar set.
        [InlineData(true, false, false, false, true, false, null)] // only IConfig EnvVars, without EnvVar set.
        [InlineData(false, false, false, false, true, true, "testEnvVarValue")] // only IConfig EnvVars, with EnvVar set.
        [InlineData(true, false, false, false, true, true, "testEnvVarValue")] // only IConfig EnvVars, with EnvVar set.
        [InlineData(false, false, false, true, true, true, "testEnvVarValue")] // both IConfig InMemoryCollection & IConfig EnvVars with EnvVar set
        [InlineData(true, false, false, true, true, true, "testEnvVarValue")] // both IConfig InMemoryCollection & IConfig EnvVars with EnvVar set
        [InlineData(false, false, false, true, true, false, "testInMemoryCollectionValue")] // both IConfig InMemoryCollection & IConfig EnvVars without EnvVar set
        [InlineData(true, false, false, true, true, false, "testInMemoryCollectionValue")] // both IConfig InMemoryCollection & IConfig EnvVars without EnvVar set
        [InlineData(false, false, false, false, false, true, "testEnvVarValue")] // only EnvironmentVariable
        [InlineData(true, false, false, false, false, true, "testEnvVarValue")] // only EnvironmentVariable
        [InlineData(false, true, true, true, true, true, "testEnvVarValue")]
        [InlineData(true, true, true, true, true, true, "testEnvVarValue")]
        public void Verify_UseAzureMonitor_SetsConnectionString(bool useConfigure, bool jsonAzureMonitor, bool jsonEnvVar, bool iconfigCollection, bool iconfigEnvVar, bool setEnvVar, string expectedConnectionStringValue)
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
                bool usesConfigBuilder = false;

                if (jsonAzureMonitor || jsonEnvVar)
                {
                    configBulider.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(jsonString)));
                    usesConfigBuilder = true;
                }

                if (iconfigCollection)
                {
                    configBulider.AddInMemoryCollection(new Dictionary<string, string?> { [ConnectionStringEnvironmentVariable] = "testInMemoryCollectionValue" });
                    usesConfigBuilder = true;
                }

                if (iconfigEnvVar)
                {
                    configBulider.AddEnvironmentVariables();
                }

                // ACT
                var serviceCollection = new ServiceCollection();

                if (usesConfigBuilder)
                {
                    var configuration = configBulider.Build();
                    serviceCollection.AddSingleton<IConfiguration>(configuration);
                }

                if (useConfigure)
                {
                    serviceCollection.AddOpenTelemetry().UseAzureMonitor(x => { });
                }
                else
                {
                    serviceCollection.AddOpenTelemetry().UseAzureMonitor();
                }

                using var serviceProvider = serviceCollection.BuildServiceProvider();

                // ASSERT
                var azureMonitorOptions = serviceProvider.GetServices<IOptions<AzureMonitorOptions>>().Single().Value;
                Assert.Equal(expectedConnectionStringValue, azureMonitorOptions.ConnectionString);

                var azureMonitorExporterOptions = serviceProvider.GetServices<IOptions<AzureMonitorExporterOptions>>().Single().Value;
                Assert.Equal(expectedConnectionStringValue, azureMonitorExporterOptions.ConnectionString);
            }
            finally
            {
                Environment.SetEnvironmentVariable(ConnectionStringEnvironmentVariable, null);
            }
        }
#endif
    }
}
