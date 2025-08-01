// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.TelemetryClient.Tests;

public class DependencyTelemetryClientHttpMockTests  : AbstractTelemetryClientHttpMockTest
{
    [Fact]
    public async Task TrackSqlDependencyWithSimpleMethod()
    {
        var dependencyTypeName = "SQL";
        var dependencyName = "SELECT";
        var data = "SELECT * FROM Table";
        var startTime = DateTimeOffset.UtcNow.AddSeconds(-5);
        var duration = TimeSpan.FromSeconds(5);
        var success = true;

        await VerifyTrackMethod(
            c => c.TrackDependency(dependencyTypeName, dependencyName, data, startTime, duration, success), "dependency/expected-dependency-simple-method-sql.json"
        );
    }

    [Fact]
    public async Task TrackHTTPDependencyWithSimpleMethod()
    {
        var dependencyTypeName = "HTTP";
        var dependencyName = "GET /api/orders";
        var data = "https://api.example.com/api/orders";
        var startTime = DateTimeOffset.UtcNow.AddSeconds(-5);
        var duration = TimeSpan.FromSeconds(2);
        var success = true;

        await VerifyTrackMethod(
            c => c.TrackDependency(dependencyTypeName, dependencyName, data, startTime, duration, success), "dependency/expected-dependency-simple-method-http.json"
        );
    }

    [Fact]
    public async Task TrackSqlMsSqlDependencyWithSeveralMethodArguments
        ()
    {
        var dependencyTypeName = "SQL";
        // Only "mssql" is mapped to the SQL type by the .net exporter today: https://github.com/Azure/azure-sdk-for-net/blob/7bcb4cd862cc692320c8692eba16321df21ea196/sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/src/Internals/AzMonListExtensions.cs#L18
        var target = "mssql";
        var dependencyName = "SELECT";
        var data = "SELECT * FROM Table";
        var startTime = DateTimeOffset.UtcNow.AddSeconds(-5);
        var duration= TimeSpan.FromSeconds(5);
        var resultCode = "0";
        var success = true;

        await VerifyTrackMethod(
            c => c.TrackDependency(dependencyTypeName, target, dependencyName, data, startTime, duration, resultCode,
                success), "dependency/expected-dependency-with-several-method-arguments-sql.json"
        );
    }

    [Fact]
    public async Task TrackSqlOracleDependencyWithSeveralMethodArguments()
    {
        var dependencyTypeName = "SQL";
        var target = "oracle";
        var dependencyName = "SELECT";
        var data = "SELECT * FROM ORDERS";
        var startTime = DateTimeOffset.UtcNow.AddSeconds(-5);
        var duration = TimeSpan.FromSeconds(5);
        var resultCode = "0";
        var success = true;

        await VerifyTrackMethod(
            c => c.TrackDependency(dependencyTypeName, target, dependencyName, data, startTime, duration, resultCode,
                success), "dependency/expected-dependency-with-several-method-arguments-sql-oracle.json"
        );
    }

    [Fact]
    public async Task TrackHTTPDependencyWithSeveralMethodArguments()
    {
        void ClientConsumer(TelemetryClient telemetryClient)
        {
            telemetryClient.Context.GlobalProperties["global-Key1"] = "global-Value1";
            telemetryClient.Context.GlobalProperties["global-Key2"] = "global-Value2";

            var dependencyTypeName = "HTTP";
            var target = "api.example.com.target";
            var dependencyName = "GET /api/orders";
            var data = "https://api.example.com/api/orders";
            var startTime = DateTimeOffset.UtcNow.AddSeconds(-5);
            var duration = TimeSpan.FromSeconds(2);
            var resultCode = "200";
            var success = false;

            telemetryClient.TrackDependency(dependencyTypeName, target, dependencyName, data, startTime, duration,
                resultCode,
                success);
        }

        await VerifyTrackMethod(ClientConsumer, "dependency/expected-dependency-with-several-method-arguments-http.json");
    }
}
