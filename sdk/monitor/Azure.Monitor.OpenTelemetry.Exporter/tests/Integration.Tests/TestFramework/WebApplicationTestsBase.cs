// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Microsoft.AspNetCore.Mvc.Testing;

using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.TestFramework
{
    public abstract class WebApplicationTestsBase : IClassFixture<WebApplicationFactory<AspNetCoreWebApp.Startup>>
    {
        protected readonly WebApplicationFactory<AspNetCoreWebApp.Startup> factory;
        protected readonly ITestOutputHelper output;
        internal readonly TelemetryItemOutputHelper telemetryOutput;

        public WebApplicationTestsBase(WebApplicationFactory<AspNetCoreWebApp.Startup> factory, ITestOutputHelper output)
        {
            this.factory = factory;
            this.output = output;
            this.telemetryOutput = new TelemetryItemOutputHelper(output);
        }

        /// <summary>
        /// Wait for End callback to execute because it is executed after response was returned.
        /// </summary>
        /// <remarks>
        /// Copied from <see href="https://github.com/open-telemetry/opentelemetry-dotnet/blob/f471a9f197d797015123fe95d3e12b6abf8e1f5f/test/OpenTelemetry.Instrumentation.AspNetCore.Tests/BasicTests.cs#L558-L570"/>.
        /// </remarks>
        internal void WaitForActivityExport(ConcurrentBag<TelemetryItem> telemetryItems)
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

        internal void AssertRequestTelemetry(TelemetryItem telemetryItem, string expectedResponseCode, string expectedUrl)
        {
            Assert.Equal("Request", telemetryItem.Name);

            // Tags
            Assert.Contains("ai.operation.id", telemetryItem.Tags.Keys);
            Assert.Contains("ai.operation.name", telemetryItem.Tags.Keys);
            Assert.Contains("ai.location.ip", telemetryItem.Tags.Keys);
            Assert.Contains("ai.cloud.role", telemetryItem.Tags.Keys);
            Assert.Contains("ai.cloud.roleInstance", telemetryItem.Tags.Keys);
            Assert.Contains("ai.internal.sdkVersion", telemetryItem.Tags.Keys);

            // BaseData
            Assert.Equal("RequestData", telemetryItem.Data.BaseType);
            var requestData = (RequestData)telemetryItem.Data.BaseData;
            Assert.Equal(expectedResponseCode, requestData.ResponseCode);
            Assert.Equal(expectedUrl, requestData.Url);
        }
    }
}
