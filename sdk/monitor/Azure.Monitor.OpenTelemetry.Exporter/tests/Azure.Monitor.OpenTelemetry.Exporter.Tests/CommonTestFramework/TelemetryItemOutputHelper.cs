// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework
{
    internal class TelemetryItemOutputHelper
    {
        private readonly ITestOutputHelper output;

        public TelemetryItemOutputHelper(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void Write(IEnumerable<TelemetryItem> telemetryItems)
        {
            if (telemetryItems == null)
            {
                return;
            }

            foreach (var telemetryItem in telemetryItems)
            {
                this.Write(telemetryItem);
            }
        }

        public void Write(TelemetryItem telemetryItem)
        {
            output.WriteLine($"Name: {telemetryItem.Name}");
            output.WriteLine($"Tags: {telemetryItem.Tags.Count}");
            foreach (var tag in telemetryItem.Tags)
            {
                output.WriteLine($"\t{tag.Key}: {tag.Value}");
            }

            WriteBaseData(telemetryItem);
        }

        private void WriteBaseData(TelemetryItem telemetryItem)
        {
            var baseType = telemetryItem.Data.BaseType;
            output.WriteLine($"\nBaseData: {baseType}");

            switch (baseType)
            {
                case nameof(RequestData):
                    WriteRequestData((RequestData)telemetryItem.Data.BaseData);
                    break;
                case nameof(RemoteDependencyData):
                    WriteRemoteDependencyData((RemoteDependencyData)telemetryItem.Data.BaseData);
                    break;
                default:
                    output.WriteLine($"***WriteBaseData not implemented for '{baseType}'***");
                    break;
            }
        }

        private void WriteRemoteDependencyData(RemoteDependencyData remoteDependencyData)
        {
            output.WriteLine($"Name: {remoteDependencyData.Name}");

            output.WriteLine($"Properties: {remoteDependencyData.Properties.Count}");
            foreach (var prop in remoteDependencyData.Properties)
            {
                output.WriteLine($"\t{prop.Key}: {prop.Value}");
            }
        }

        private void WriteRequestData(RequestData requestData)
        {
            output.WriteLine($"Url: {requestData.Url}");
            output.WriteLine($"ResponseCode: {requestData.ResponseCode}");
        }
    }
}
