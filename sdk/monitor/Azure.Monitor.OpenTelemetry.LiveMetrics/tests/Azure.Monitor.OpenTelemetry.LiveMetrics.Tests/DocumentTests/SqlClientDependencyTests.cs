// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using OpenTelemetry;
using Xunit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;
using System.Net.Http;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests.DocumentTests
{
    public class SqlClientDependencyTests
    {
        private const string TestServerUrl = "http://localhost:9996/";

        [Fact]
        public void VerifySqlClientAttributes()
        {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData(SqlClientConstants.SqlDataBeforeExecuteCommand, SqlClientConstants.SqlDataAfterExecuteCommand, CommandType.StoredProcedure, "SP_GetOrders")]
        [InlineData(SqlClientConstants.SqlDataBeforeExecuteCommand, SqlClientConstants.SqlDataAfterExecuteCommand, CommandType.Text, "select * from sys.databases")]
        public void VerifySqlClientDependency(
            string beforeCommand,
            string afterCommand,
            CommandType commandType,
            string commandText)
        {
            string testConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=master";
            using var sqlConnection = new SqlConnection(testConnectionString);
            using var sqlCommand = sqlConnection.CreateCommand();

            var fakeSqlClientDiagnosticSource = new FakeSqlClientDiagnosticSource();

            var exportedActivities = new List<Activity>();
            using (Sdk.CreateTracerProviderBuilder()
                .AddSqlClientInstrumentation(options =>
                {
                    options.SetDbStatementForText = true;
                    options.SetDbStatementForStoredProcedure = true;
                    //options.RecordException = recordException;
                })
                .AddInMemoryExporter(exportedActivities)
                .Build())
            {
                var operationId = Guid.NewGuid();
                sqlCommand.CommandText = commandText;
                sqlCommand.CommandType = commandType;

                var beforeExecuteEventData = new
                {
                    OperationId = operationId,
                    Command = sqlCommand,
                    Timestamp = (long?)1000000L,
                };

                fakeSqlClientDiagnosticSource.Write(
                    beforeCommand,
                    beforeExecuteEventData);

                var afterExecuteEventData = new
                {
                    OperationId = operationId,
                    Command = sqlCommand,
                    Timestamp = 2000000L,
                };

                fakeSqlClientDiagnosticSource.Write(
                    afterCommand,
                    afterExecuteEventData);

                //var beforeExecuteEventData = new
                //{
                //    OperationId = operationId,
                //    Command = sqlCommand,
                //    Timestamp = (long?)1000000L,
                //};

                //fakeSqlClientDiagnosticSource.Write(
                //    SqlClientConstants.SqlDataBeforeExecuteCommand,
                //    beforeExecuteEventData);

                //var commandErrorEventData = new
                //{
                //    OperationId = operationId,
                //    Command = sqlCommand,
                //    Exception = new System.Exception("Boom!"),
                //    Timestamp = 2000000L,
                //};

                //fakeSqlClientDiagnosticSource.Write(
                //    SqlClientConstants.SqlDataAfterExecuteCommand,
                //    commandErrorEventData);
            }

            WaitForActivityExport(exportedActivities);
            Assert.True(exportedActivities.Any(), "test project did not capture telemetry");
            var remoteDependencyActivity = exportedActivities.First(x => x.Kind == ActivityKind.Client)!;

            var remoteDependencyDocument = DocumentHelper.ConvertToRemoteDependency(remoteDependencyActivity);

            Assert.Equal(DocumentIngressDocumentType.RemoteDependency, remoteDependencyDocument.DocumentType);
            Assert.Equal(remoteDependencyActivity.Duration.TotalMilliseconds, remoteDependencyDocument.Extension_Duration); //TODO: SWITCH TO OTHER DURATION
            Assert.Equal(commandText, remoteDependencyDocument.CommandName);
        }

        /// <summary>
        /// Wait for End callback to execute because it is executed after response was returned.
        /// </summary>
        /// <remarks>
        /// Copied from <see href="https://github.com/open-telemetry/opentelemetry-dotnet/blob/f471a9f197d797015123fe95d3e12b6abf8e1f5f/test/OpenTelemetry.Instrumentation.AspNetCore.Tests/BasicTests.cs#L558-L570"/>.
        /// </remarks>
        internal void WaitForActivityExport(List<Activity> telemetryItems)
        {
            var result = SpinWait.SpinUntil(
                condition: () =>
                {
                    Thread.Sleep(10);
                    return telemetryItems.Any();
                },
                timeout: TimeSpan.FromSeconds(10));

            Assert.True(result, $"{nameof(WaitForActivityExport)} failed.");
        }

        private static class SqlClientConstants
        {
            internal const string SqlClientDiagnosticListenerName = "SqlClientDiagnosticListener";

            public const string SqlDataBeforeExecuteCommand = "System.Data.SqlClient.WriteCommandBefore";
            public const string SqlMicrosoftBeforeExecuteCommand = "Microsoft.Data.SqlClient.WriteCommandBefore";

            public const string SqlDataAfterExecuteCommand = "System.Data.SqlClient.WriteCommandAfter";
            public const string SqlMicrosoftAfterExecuteCommand = "Microsoft.Data.SqlClient.WriteCommandAfter";

            public const string SqlDataWriteCommandError = "System.Data.SqlClient.WriteCommandError";
            public const string SqlMicrosoftWriteCommandError = "Microsoft.Data.SqlClient.WriteCommandError";
        }

        /// <summary>
        /// Copied from https://github.com/open-telemetry/opentelemetry-dotnet/blob/1.6.0-beta.3/test/OpenTelemetry.Instrumentation.SqlClient.Tests/SqlClientTests.cs
        /// </summary>
        private class FakeSqlClientDiagnosticSource : IDisposable
        {
            private readonly DiagnosticListener listener;

            public FakeSqlClientDiagnosticSource()
            {
                listener = new DiagnosticListener(SqlClientConstants.SqlClientDiagnosticListenerName);
            }

            public void Write(string name, object value)
            {
                if (listener.IsEnabled(name))
                {
                    listener.Write(name, value);
                }
            }

            public void Dispose()
            {
                listener.Dispose();
            }
        }
    }
}
