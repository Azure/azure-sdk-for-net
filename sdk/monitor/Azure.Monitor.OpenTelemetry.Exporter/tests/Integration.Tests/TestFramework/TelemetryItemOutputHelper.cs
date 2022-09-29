// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Models;

using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.TestFramework
{
    internal class TelemetryItemOutputHelper
    {
        private readonly ITestOutputHelper output;

        public TelemetryItemOutputHelper(ITestOutputHelper output)
        {
            this.output = output;
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
            output.WriteLine($"BaseData: {baseType}");

            switch (baseType)
            {
                case nameof(RequestData):
                    WriteRequestData((RequestData)telemetryItem.Data.BaseData);
                    break;
                default:
                    output.WriteLine($"WriteBaseData not implemented for '{baseType}'");
                    break;
            }
        }

        private void WriteRequestData(RequestData requestData)
        {
            output.WriteLine($"Url: {requestData.Url}");
            output.WriteLine($"ResponseCode: {requestData.ResponseCode}");
        }
    }
}
