// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

// The following tests were originally copied from OpenTelemetry and modified for Azure Monitor.
// https://github.com/open-telemetry/opentelemetry-dotnet-contrib/blob/Instrumentation.SqlClient-1.9.0-beta.1/test/OpenTelemetry.Instrumentation.SqlClient.Tests/SqlClientTests.cs

#if NET

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Instrumentation.SqlClient;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests.E2ETests
{
    public class SqlClientInstrumentationTests
    {
        private const string SqlClientDiagnosticListenerName = "SqlClientDiagnosticListener";
        private const string SqlDataBeforeExecuteCommand = "System.Data.SqlClient.WriteCommandBefore";
        private const string SqlMicrosoftBeforeExecuteCommand = "Microsoft.Data.SqlClient.WriteCommandBefore";
        private const string SqlDataAfterExecuteCommand = "System.Data.SqlClient.WriteCommandAfter";
        private const string SqlMicrosoftAfterExecuteCommand = "Microsoft.Data.SqlClient.WriteCommandAfter";
        private const string SqlDataWriteCommandError = "System.Data.SqlClient.WriteCommandError";
        private const string SqlMicrosoftWriteCommandError = "Microsoft.Data.SqlClient.WriteCommandError";

        private const string TestSqlConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=master";

        private readonly FakeSqlClientDiagnosticSource _fakeSqlClientDiagnosticSource = new FakeSqlClientDiagnosticSource();

        private readonly TelemetryItemOutputHelper _telemetryOutput;

        public SqlClientInstrumentationTests(ITestOutputHelper output)
        {
            _telemetryOutput = new TelemetryItemOutputHelper(output);
        }

        [Theory]
        [InlineData(SqlDataBeforeExecuteCommand, SqlDataWriteCommandError)]
        [InlineData(SqlDataBeforeExecuteCommand, SqlDataWriteCommandError, false)]
        [InlineData(SqlDataBeforeExecuteCommand, SqlDataWriteCommandError, false, true)]
        [InlineData(SqlMicrosoftBeforeExecuteCommand, SqlMicrosoftWriteCommandError)]
        [InlineData(SqlMicrosoftBeforeExecuteCommand, SqlMicrosoftWriteCommandError, false)]
        [InlineData(SqlMicrosoftBeforeExecuteCommand, SqlMicrosoftWriteCommandError, false, true)]
        public async Task SqlClientErrorsAreCollectedSuccessfully(
            string beforeCommand,
            string errorCommand,
            bool shouldEnrich = true,
            bool recordException = false)
        {
            // SETUP MOCK TRANSMITTER TO CAPTURE AZURE MONITOR TELEMETRY
            var testConnectionString = $"InstrumentationKey=unitTest-{nameof(SqlClientErrorsAreCollectedSuccessfully)}";
            var telemetryItems = new List<TelemetryItem>();
            var mockTransmitter = new Exporter.Tests.CommonTestFramework.MockTransmitter(telemetryItems);
            // The TransmitterFactory is invoked by the Exporter during initialization to ensure that there's only one instance of a transmitter/connectionString shared by all Exporters.
            // Here we're setting that instance to use the MockTransmitter so this test can capture telemetry before it's sent to Azure Monitor.
            Exporter.Internals.TransmitterFactory.Instance.Set(connectionString: testConnectionString, transmitter: mockTransmitter);

            // SETUP OPENTELEMETRY WITH AZURE MONITOR DISTRO
            var activities = new List<Activity>();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOpenTelemetry()
                .UseAzureMonitor(x => x.ConnectionString = testConnectionString)
                .WithTracing(x => x.AddInMemoryExporter(activities))
                // Custom resources must be added AFTER AzureMonitor to override the included ResourceDetectors.
                .ConfigureResource(x => x.AddAttributes(SharedTestVars.TestResourceAttributes));
            serviceCollection.Configure<SqlClientTraceInstrumentationOptions>(options =>
            {
                options.RecordException = recordException;
                if (shouldEnrich)
                {
                    options.Enrich = ActivityEnrichment;
                }
            });
            using var serviceProvider = serviceCollection.BuildServiceProvider();

            await StartHostedServicesAsync(serviceProvider);

            // We must resolve the TracerProvider here to ensure that it is initialized.
            // In a normal app, the OpenTelemetry.Extensions.Hosting package would handle this.
            var tracerProvider = serviceProvider.GetRequiredService<TracerProvider>();

            // SETUP
            var operationId = Guid.NewGuid();
            using var sqlConnection = new SqlConnection(TestSqlConnectionString);
            using var sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SP_GetOrders";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // ACT
            _fakeSqlClientDiagnosticSource.Write(
                name: beforeCommand,
                value: new
                {
                    OperationId = operationId,
                    Command = sqlCommand,
                    Timestamp = 1000000L,
                });

            _fakeSqlClientDiagnosticSource.Write(
                name: errorCommand,
                value: new
                {
                    OperationId = operationId,
                    Command = sqlCommand,
                    Exception = new Exception("Boom!"),
                    Timestamp = 2000000L,
                });

            // SHUTDOWN
            tracerProvider.ForceFlush();
            tracerProvider.Shutdown();

            // ASSERT
            _telemetryOutput.Write(telemetryItems);
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            var telemetryItem = telemetryItems.Where(x => x.Name == "RemoteDependency").Single();
            Assert.Single(activities);
            var activity = activities[0];

            VerifyTelemetryItem(
                commandType: sqlCommand.CommandType,
                commandText: sqlCommand.CommandText,
                captureStoredProcedureCommandName: true,
                captureTextCommandContent: false,
                isFailure: true,
                shouldEnrich: shouldEnrich,
                dataSource: sqlConnection.DataSource,
                telemetryItem: telemetryItem,
                activity: activity);
        }

        [Theory]
        [InlineData(SqlDataBeforeExecuteCommand, SqlDataAfterExecuteCommand, CommandType.StoredProcedure, "SP_GetOrders", true, false)]
        [InlineData(SqlDataBeforeExecuteCommand, SqlDataAfterExecuteCommand, CommandType.StoredProcedure, "SP_GetOrders", true, false, false)]
        [InlineData(SqlDataBeforeExecuteCommand, SqlDataAfterExecuteCommand, CommandType.Text, "select * from sys.databases", true, false)]
        [InlineData(SqlDataBeforeExecuteCommand, SqlDataAfterExecuteCommand, CommandType.Text, "select * from sys.databases", true, false, false)]
        [InlineData(SqlMicrosoftBeforeExecuteCommand, SqlMicrosoftAfterExecuteCommand, CommandType.StoredProcedure, "SP_GetOrders", false, true)]
        [InlineData(SqlMicrosoftBeforeExecuteCommand, SqlMicrosoftAfterExecuteCommand, CommandType.StoredProcedure, "SP_GetOrders", false, true, false)]
        [InlineData(SqlMicrosoftBeforeExecuteCommand, SqlMicrosoftAfterExecuteCommand, CommandType.Text, "select * from sys.databases", false, true)]
        [InlineData(SqlMicrosoftBeforeExecuteCommand, SqlMicrosoftAfterExecuteCommand, CommandType.Text, "select * from sys.databases", false, true, false)]
        public async Task SqlClientCallsAreCollectedSuccessfully(
            string beforeCommand,
            string afterCommand,
            CommandType commandType,
            string commandText,
            bool captureStoredProcedureCommandName,
            bool captureTextCommandContent,
            bool shouldEnrich = true)
        {
            // SETUP MOCK TRANSMITTER TO CAPTURE AZURE MONITOR TELEMETRY
            var testConnectionString = $"InstrumentationKey=unitTest-{nameof(SqlClientCallsAreCollectedSuccessfully)}";
            var telemetryItems = new List<TelemetryItem>();
            var mockTransmitter = new Exporter.Tests.CommonTestFramework.MockTransmitter(telemetryItems);
            // The TransmitterFactory is invoked by the Exporter during initialization to ensure that there's only one instance of a transmitter/connectionString shared by all Exporters.
            // Here we're setting that instance to use the MockTransmitter so this test can capture telemetry before it's sent to Azure Monitor.
            Exporter.Internals.TransmitterFactory.Instance.Set(connectionString: testConnectionString, transmitter: mockTransmitter);

            // SETUP OPENTELEMETRY WITH AZURE MONITOR DISTRO
            var activities = new List<Activity>();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOpenTelemetry()
                .UseAzureMonitor(x => x.ConnectionString = testConnectionString)
                .WithTracing(x => x.AddInMemoryExporter(activities))
                // Custom resources must be added AFTER AzureMonitor to override the included ResourceDetectors.
                .ConfigureResource(x => x.AddAttributes(SharedTestVars.TestResourceAttributes));
            serviceCollection.Configure<SqlClientTraceInstrumentationOptions>(options =>
            {
                options.SetDbStatementForText = captureTextCommandContent;
                options.SetDbStatementForStoredProcedure = captureStoredProcedureCommandName;
                if (shouldEnrich)
                {
                    options.Enrich = ActivityEnrichment;
                }
            });
            using var serviceProvider = serviceCollection.BuildServiceProvider();

            await StartHostedServicesAsync(serviceProvider);

            // We must resolve the TracerProvider here to ensure that it is initialized.
            // In a normal app, the OpenTelemetry.Extensions.Hosting package would handle this.
            var tracerProvider = serviceProvider.GetRequiredService<TracerProvider>();

            // SETUP
            var operationId = Guid.NewGuid();
            using var sqlConnection = new SqlConnection(TestSqlConnectionString);
            using var sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = commandType;
            sqlCommand.CommandText = commandText;

            // ACT
            _fakeSqlClientDiagnosticSource.Write(
                name: beforeCommand,
                value: new
                {
                    OperationId = operationId,
                    Command = sqlCommand,
                    Timestamp = 1000000L,
                });

            _fakeSqlClientDiagnosticSource.Write(
                name: afterCommand,
                value: new
                {
                    OperationId = operationId,
                    Command = sqlCommand,
                    Timestamp = 2000000L,
                });

            // SHUTDOWN
            tracerProvider.ForceFlush();
            tracerProvider.Shutdown();

            // ASSERT
            _telemetryOutput.Write(telemetryItems);
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            var telemetryItem = telemetryItems.Where(x => x.Name == "RemoteDependency").Single();
            var activity = activities.Single();

            VerifyTelemetryItem(
                commandType: sqlCommand.CommandType,
                commandText: sqlCommand.CommandText,
                captureStoredProcedureCommandName: captureStoredProcedureCommandName,
                captureTextCommandContent: captureTextCommandContent,
                isFailure: false,
                shouldEnrich: shouldEnrich,
                dataSource: sqlConnection.DataSource,
                telemetryItem: telemetryItem,
                activity: activity);
        }

        internal static void ActivityEnrichment(Activity activity, string method, object obj)
        {
            activity.SetTag("enriched", "yes");

            switch (method)
            {
                case "OnCustom":
                    Assert.True(obj is SqlCommand);
                    break;

                default:
                    break;
            }
        }

        internal static void VerifyTelemetryItem(
            CommandType commandType,
            string commandText,
            bool captureStoredProcedureCommandName,
            bool captureTextCommandContent,
            bool isFailure,
            bool shouldEnrich,
            string dataSource,
            TelemetryItem telemetryItem,
            Activity activity)
        {
            // TELEMETRY ITEM
            Assert.Equal(5, telemetryItem.Tags.Count);
            Assert.Contains(telemetryItem.Tags, kvp => kvp.Key == "ai.operation.id" && kvp.Value == activity.TraceId.ToHexString());
            Assert.Contains(telemetryItem.Tags, kvp => kvp.Key == "ai.cloud.role" && kvp.Value == SharedTestVars.TestRoleName);
            Assert.Contains(telemetryItem.Tags, kvp => kvp.Key == "ai.application.ver" && kvp.Value == SharedTestVars.TestServiceVersion);
            Assert.Contains(telemetryItem.Tags, kvp => kvp.Key == "ai.cloud.roleInstance" && kvp.Value == SharedTestVars.TestServiceInstance);
            Assert.Contains(telemetryItem.Tags, kvp => kvp.Key == "ai.internal.sdkVersion");

            // TELEMETRY DATA
            var remoteDependencyData = (RemoteDependencyData)telemetryItem.Data.BaseData;

            Assert.Equal("master", remoteDependencyData.Name);
            Assert.Equal($"{dataSource} | master", remoteDependencyData.Target);
            Assert.Equal("SQL", remoteDependencyData.Type);
            Assert.Equal(activity.SpanId.ToHexString(), remoteDependencyData.Id);
            Assert.Equal(!isFailure, remoteDependencyData.Success);
            Assert.Null(remoteDependencyData.ResultCode);

            string? expectedData = commandType switch
            {
                CommandType.StoredProcedure when captureStoredProcedureCommandName => commandText,
                CommandType.StoredProcedure => null,
                CommandType.Text when captureTextCommandContent => commandText,
                CommandType.Text => null,
                _ => throw new ArgumentOutOfRangeException()
            };
            Assert.Equal(expectedData, remoteDependencyData.Data);

            var expectedCount = shouldEnrich? 3 : 2;
            Assert.Equal(expectedCount, remoteDependencyData.Properties.Count);
            Assert.Contains(remoteDependencyData.Properties, kvp => kvp.Key == "db.name" && kvp.Value == "master");
            Assert.Contains(remoteDependencyData.Properties, kvp => kvp.Key == "_MS.ProcessedByMetricExtractors" && kvp.Value == "(Name: X,Ver:'1.1')");
            if (shouldEnrich)
            {
                Assert.Contains(remoteDependencyData.Properties, kvp => kvp.Key == "enriched" && kvp.Value == "yes");
            }
        }

        private static async Task StartHostedServicesAsync(ServiceProvider serviceProvider)
        {
            var hostedServices = serviceProvider.GetServices<IHostedService>();
            foreach (var hostedService in hostedServices)
            {
                await hostedService.StartAsync(CancellationToken.None);
            }
        }

        private class FakeSqlClientDiagnosticSource : IDisposable
        {
            private readonly DiagnosticListener listener;

            public FakeSqlClientDiagnosticSource()
            {
                this.listener = new DiagnosticListener(SqlClientDiagnosticListenerName);
            }

            public void Write(string name, object value)
            {
                if (this.listener.IsEnabled(name))
                {
                    this.listener.Write(name, value);
                }
            }

            public void Dispose()
            {
                this.listener.Dispose();
            }
        }
    }
}
#endif
