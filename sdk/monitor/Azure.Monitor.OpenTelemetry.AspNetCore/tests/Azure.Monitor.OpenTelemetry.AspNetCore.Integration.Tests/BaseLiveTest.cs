// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Logs;
using Azure.Monitor.Query.Logs.Models;
using NUnit.Framework;
using static Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests.TelemetryValidationHelper;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    public abstract class BaseLiveTest : RecordedTestBase<AzureMonitorTestEnvironment>
    {
        public BaseLiveTest(bool isAsync, RecordedTestMode? mode = null, bool usesMultiTenantExport = false) : base(isAsync, mode)
        {
            UsesMultiTenantExport = usesMultiTenantExport;
            ValidateExecutionMode();
        }

        protected string? _testStartTimeStamp;
        private LogsQueryClient? _logsQueryClient = null;
        protected bool? _useTimestampInQuery;

        protected bool UsesMultiTenantExport { get; }
        protected LogsQueryClient QueryClient => _logsQueryClient!;

        internal static void ValidateExecutionMode(bool multiTenantFixture, bool multiTenantRun, RecordedTestMode? mode, bool switchEnabled)
        {
            if (multiTenantFixture && (!multiTenantRun || mode != RecordedTestMode.Live))
            {
                throw new InvalidOperationException("Multi-tenant tests require AZURE_TEST_MODE=Live and MONITOR_MULTI_TENANT_LIVE=true in a fresh, filtered test host.");
            }

            if (!multiTenantFixture && (multiTenantRun || switchEnabled))
            {
                throw new InvalidOperationException("Ordinary integration fixtures must run in a separate test host with multi-tenant export disabled.");
            }
        }

        private void ValidateExecutionMode()
        {
            ValidateExecutionMode(UsesMultiTenantExport,
                string.Equals(Environment.GetEnvironmentVariable("MONITOR_MULTI_TENANT_LIVE"), "true", StringComparison.OrdinalIgnoreCase),
                TestEnvironment.Mode,
                AppContext.TryGetSwitch("Azure.Monitor.OpenTelemetry.EnableMultiTenantExport", out var enabled) && enabled);
        }

        [SetUp] // SetUp is run before every individual test method.
        public void Setup()
        {
            ValidateExecutionMode();

            // Print the current test Name and Mode. This is needed to identify the Mode when reviewing logs.
            var startupMessage = $"Integration test '{TestContext.CurrentContext.Test.Name}' running in mode '{TestEnvironment.Mode}'";
            Console.WriteLine(startupMessage);
            Debug.WriteLine(startupMessage);
            TestContext.Out.WriteLine(startupMessage);

            // Record the current timestamp. This is used when querying telemetry.
            _testStartTimeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ");

            // Timestamp cannot be used in Record or Playback mode.
            _useTimestampInQuery = TestEnvironment.Mode == RecordedTestMode.Live;

            // Initialize the Logs Analytics client. This is used to query telemetry.
            _logsQueryClient = InstrumentClient(new LogsQueryClient(
                TestEnvironment.LogsEndpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new LogsQueryClientOptions()
                {
                    Diagnostics = { IsLoggingContentEnabled = !UsesMultiTenantExport }
                })
            ));
        }

        public override void GlobalTimeoutTearDown()
        {
            // Turn off global timeout errors because these tests can be slower
            // base.GlobalTimeoutTearDown();
        }

        internal async Task QueryAndVerifyDependency(string workspaceId, string description, string query, ExpectedAppDependency expectedAppDependency)
        {
            LogsTable? logsTable = await _logsQueryClient!.QueryTelemetryAsync(workspaceId, description, query);
            ValidateExpectedTelemetry(description, logsTable, expectedAppDependency);
        }

        internal async Task QueryAndVerifyRequest(string workspaceId, string description, string query, ExpectedAppRequest expectedAppRequest)
        {
            LogsTable? logsTable = await _logsQueryClient!.QueryTelemetryAsync(workspaceId, description, query);
            ValidateExpectedTelemetry(description, logsTable, expectedAppRequest);
        }

        internal async Task QueryAndVerifyMetric(string workspaceId, string description, string query, ExpectedAppMetric expectedAppMetric)
        {
            LogsTable? logsTable = await _logsQueryClient!.QueryTelemetryAsync(workspaceId, description, query);
            ValidateExpectedTelemetry(description, logsTable, expectedAppMetric);
        }

        internal async Task QueryAndVerifyTrace(string workspaceId, string description, string query, ExpectedAppTrace expectedAppTrace)
        {
            LogsTable? logsTable = await _logsQueryClient!.QueryTelemetryAsync(workspaceId, description, query);
            ValidateExpectedTelemetry(description, logsTable, expectedAppTrace);
        }
    }
}
#endif
