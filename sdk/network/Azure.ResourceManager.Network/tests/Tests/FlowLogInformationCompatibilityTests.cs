// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class FlowLogInformationCompatibilityTests
    {
        private const string WirePath = "flowAnalyticsConfiguration.networkWatcherFlowAnalyticsConfiguration";

        [Test]
        public void ReleasedPropertyIsTheOnlyActiveFlattenedMember()
        {
            PropertyInfo property = typeof(FlowLogInformation).GetProperty("TrafficAnalyticsConfiguration");
            Assert.That(property, Is.Not.Null);
            Assert.That(property.PropertyType, Is.EqualTo(typeof(TrafficAnalyticsConfigurationProperties)));
            Assert.That(property.GetMethod.IsPublic && property.SetMethod.IsPublic, Is.True);
            Assert.That(property.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(property.GetCustomAttribute<EditorBrowsableAttribute>(), Is.Null);
            Assert.That(typeof(FlowLogInformation).GetProperty("NetworkWatcherFlowAnalyticsConfiguration"), Is.Null);
            Assert.That(GetWirePath(property), Is.EqualTo(WirePath));
            Assert.That(typeof(FlowLogInformation).GetProperties().Count(p => GetWirePath(p) == WirePath), Is.EqualTo(1));
            Assert.That(typeof(FlowLogData).GetProperty("NetworkWatcherFlowAnalyticsConfiguration"), Is.Not.Null);
        }

        [Test]
        public void GetterAndSetterUseLiveNestedStorageAndPreserveNullSemantics()
        {
            FlowLogInformation model = ModelReaderWriter.Read<FlowLogInformation>(BinaryData.FromString("{}"));
            Assert.That(model.FlowAnalyticsConfiguration, Is.Null);
            Assert.That(model.TrafficAnalyticsConfiguration, Is.Null);
            Assert.That(model.FlowAnalyticsConfiguration, Is.Null);

            model.TrafficAnalyticsConfiguration = null;
            Assert.That(model.FlowAnalyticsConfiguration, Is.Not.Null);
            Assert.That(model.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration, Is.Null);

            var configuration = new TrafficAnalyticsConfigurationProperties { Enabled = true };
            model.TrafficAnalyticsConfiguration = configuration;
            Assert.That(model.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration, Is.SameAs(configuration));
            var replacement = new TrafficAnalyticsConfigurationProperties { Enabled = false };
            model.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration = replacement;
            Assert.That(model.TrafficAnalyticsConfiguration, Is.SameAs(replacement));
            model.TrafficAnalyticsConfiguration = null;
            Assert.That(model.FlowAnalyticsConfiguration, Is.Not.Null);
            Assert.That(model.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration, Is.Null);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void NativeJsonRoundTripsAndPersistsCanonicalPropertyMutations(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            FlowLogInformation model = ModelReaderWriter.Read<FlowLogInformation>(
                BinaryData.FromString("""
                    {"targetResourceId":"/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg/providers/Microsoft.Network/networkSecurityGroups/nsg",
                     "properties":{"storageId":"/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg/providers/Microsoft.Storage/storageAccounts/storage","enabled":true},
                     "flowAnalyticsConfiguration":{"networkWatcherFlowAnalyticsConfiguration":{"enabled":true,"workspaceId":"before","trafficAnalyticsInterval":10}}}
                    """),
                options);
            Assert.That(model.TrafficAnalyticsConfiguration.Enabled, Is.True);
            Assert.That(model.TrafficAnalyticsConfiguration.WorkspaceId, Is.EqualTo("before"));
            model.TrafficAnalyticsConfiguration.WorkspaceId = "after";
            model.TrafficAnalyticsConfiguration.TrafficAnalyticsIntervalInMinutes = 60;
            BinaryData serialized = ModelReaderWriter.Write(model, options);
            using JsonDocument document = JsonDocument.Parse(serialized);
            JsonElement outer = document.RootElement.GetProperty("flowAnalyticsConfiguration");
            Assert.That(outer.EnumerateObject().Count(p => p.Name == "networkWatcherFlowAnalyticsConfiguration"), Is.EqualTo(1));
            Assert.That(document.RootElement.TryGetProperty("trafficAnalyticsConfiguration", out _), Is.False);
            Assert.That(outer.GetProperty("networkWatcherFlowAnalyticsConfiguration").GetProperty("workspaceId").GetString(), Is.EqualTo("after"));
            Assert.That(outer.GetProperty("networkWatcherFlowAnalyticsConfiguration").GetProperty("trafficAnalyticsInterval").GetInt32(), Is.EqualTo(60));
            FlowLogInformation restored = ModelReaderWriter.Read<FlowLogInformation>(serialized, options);
            Assert.That(restored.TrafficAnalyticsConfiguration.WorkspaceId, Is.EqualTo("after"));
            Assert.That(restored.TrafficAnalyticsConfiguration, Is.SameAs(restored.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration));
        }

        private static string GetWirePath(PropertyInfo property) =>
            property.GetCustomAttributesData().FirstOrDefault(a => a.AttributeType.Name == "WirePathAttribute")
                ?.ConstructorArguments[0].Value as string;
    }
}
