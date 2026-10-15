// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.MachineLearning.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearning.Tests
{
    public class NullableCollectionCompatibilityTests
    {
        [TestCase("GroupIds", "J")]
        [TestCase("GroupIds", "W")]
        [TestCase("Emails", "J")]
        [TestCase("Emails", "W")]
        [TestCase("CaptureHeaders", "J")]
        [TestCase("CaptureHeaders", "W")]
        public void ExplicitNullCollectionCanBeReplaced(string property, string format)
        {
            var options = new ModelReaderWriterOptions(format);
            switch (property)
            {
                case "GroupIds":
                    var connection = ModelReaderWriter.Read<RegistryPrivateEndpointConnection>(BinaryData.FromString("{\"properties\":{\"groupIds\":null,\"provisioningState\":\"Succeeded\"}}"), options);
                    Assert.That(connection.GroupIds, Is.Null);
                    connection.GroupIds = new List<string> { "workspace" };
                    Assert.That(connection.GroupIds, Is.EqualTo(new[] { "workspace" }));
                    using (var json = JsonDocument.Parse(ModelReaderWriter.Write(connection, options)))
                        Assert.That(json.RootElement.GetProperty("properties").GetProperty("provisioningState").GetString(), Is.EqualTo("Succeeded"));
                    connection.GroupIds = null;
                    Assert.That(connection.GroupIds, Is.Null);
                    using (var json = JsonDocument.Parse(ModelReaderWriter.Write(connection, options)))
                        Assert.That(json.RootElement.GetProperty("properties").GetProperty("groupIds").ValueKind, Is.EqualTo(JsonValueKind.Null));
                    break;
                case "Emails":
                    var monitor = ModelReaderWriter.Read<MonitorDefinition>(BinaryData.FromString("{\"signals\":{},\"alertNotificationSettings\":{\"emailNotificationSettings\":{\"emails\":null}}}"), options);
                    Assert.That(monitor.Emails, Is.Null);
                    monitor.Emails = new List<string> { "test@example.com" };
                    Assert.That(monitor.Emails, Is.EqualTo(new[] { "test@example.com" }));
                    monitor.Emails = null;
                    Assert.That(monitor.Emails, Is.Null);
                    using (var json = JsonDocument.Parse(ModelReaderWriter.Write(monitor, options)))
                        Assert.That(json.RootElement.GetProperty("alertNotificationSettings").GetProperty("emailNotificationSettings").GetProperty("emails").ValueKind, Is.EqualTo(JsonValueKind.Null));
                    break;
                default:
                    var collector = ModelReaderWriter.Read<DataCollector>(BinaryData.FromString("{\"collections\":{},\"requestLogging\":{\"captureHeaders\":null}}"), options);
                    Assert.That(collector.RequestLoggingCaptureHeaders, Is.Null);
                    collector.RequestLoggingCaptureHeaders = new List<string> { "x-request-id" };
                    Assert.That(collector.RequestLoggingCaptureHeaders, Is.EqualTo(new[] { "x-request-id" }));
                    collector.RequestLoggingCaptureHeaders = null;
                    Assert.That(collector.RequestLoggingCaptureHeaders, Is.Null);
                    using (var json = JsonDocument.Parse(ModelReaderWriter.Write(collector, options)))
                        Assert.That(json.RootElement.GetProperty("requestLogging").GetProperty("captureHeaders").ValueKind, Is.EqualTo(JsonValueKind.Null));
                    break;
            }
        }
    }
}
