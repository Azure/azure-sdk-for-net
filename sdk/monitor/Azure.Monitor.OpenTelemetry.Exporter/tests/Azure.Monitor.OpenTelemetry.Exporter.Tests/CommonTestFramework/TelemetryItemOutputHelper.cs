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

        public void Write(IEnumerable<TelemetryItem>? telemetryItems)
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
            output.WriteLine(new string('-', 32));

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
            var baseData = telemetryItem.Data.BaseData;
            output.WriteLine($"\nBaseData: {baseType}");

            switch (baseType)
            {
                case nameof(RequestData):
                    WriteRequestData((RequestData)baseData);
                    break;
                case nameof(RemoteDependencyData):
                    WriteRemoteDependencyData((RemoteDependencyData)baseData);
                    break;
                case nameof(MessageData):
                    WriteMessageData((MessageData)baseData);
                    break;
                case "MetricData":
                    WriteMetricsData((MetricsData)baseData);
                    break;
                case "ExceptionData":
                    WriteExceptionData((TelemetryExceptionData)baseData);
                    break;
                default:
                    output.WriteLine($"***WriteBaseData not implemented for '{baseType}'***");
                    break;
            }
        }

        private void WriteExceptionData(TelemetryExceptionData exceptionData)
        {
            output.WriteLine($"SeverityLevel: {exceptionData.SeverityLevel}");

            output.WriteLine($"Exceptions: {exceptionData.Exceptions.Count}");
            foreach (var exceptionDetails in exceptionData.Exceptions)
            {
                output.WriteLine($"\tTypeName: {exceptionDetails.TypeName}");
                output.WriteLine($"\tMessage: {exceptionDetails.Message}");
            }

            output.WriteLine($"Properties: {exceptionData.Properties.Count}");
            foreach (var prop in exceptionData.Properties)
            {
                output.WriteLine($"\t{prop.Key}: {prop.Value}");
            }
        }

        private void WriteMetricsData(MetricsData metricsData)
        {
            foreach (var metric in metricsData.Metrics)
            {
                output.WriteLine($"Name: {metric.Name}");
                output.WriteLine($"Namespace: {metric.Namespace}");
                output.WriteLine($"\tCount: {metric.Count}");
                output.WriteLine($"\tValue: {metric.Value}");
                output.WriteLine($"\tMin: {metric.Min}");
                output.WriteLine($"\tMax: {metric.Max}");
            }
        }

        private void WriteMessageData(MessageData messageData)
        {
            output.WriteLine($"Name: {messageData.Message}");
            output.WriteLine($"SeverityLevel: {messageData.SeverityLevel}");

            output.WriteLine($"Properties: {messageData.Properties.Count}");
            foreach (var prop in messageData.Properties)
            {
                output.WriteLine($"\t{prop.Key}: {prop.Value}");
            }
        }

        private void WriteRemoteDependencyData(RemoteDependencyData remoteDependencyData)
        {
            output.WriteLine($"Name: {remoteDependencyData.Name}");
            output.WriteLine($"Id: {remoteDependencyData.Id}");

            output.WriteLine($"Properties: {remoteDependencyData.Properties.Count}");
            foreach (var prop in remoteDependencyData.Properties)
            {
                output.WriteLine($"\t{prop.Key}: {prop.Value}");
            }
        }

        private void WriteRequestData(RequestData requestData)
        {
            output.WriteLine($"Name: {requestData.Name}");
            output.WriteLine($"Id: {requestData.Id}");
            output.WriteLine($"Url: {requestData.Url}");
            output.WriteLine($"ResponseCode: {requestData.ResponseCode}");

            output.WriteLine($"Properties: {requestData.Properties.Count}");
            foreach (var prop in requestData.Properties)
            {
                output.WriteLine($"\t{prop.Key}: {prop.Value}");
            }
        }
    }
}
