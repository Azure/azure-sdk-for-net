// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class NetworkBatchFiveInvestigationTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";
        private const string WatcherId = "/subscriptions/" + SubscriptionId + "/resourceGroups/rg/providers/Microsoft.Network/networkWatchers/watcher";

        [TestCase(typeof(ApplicationGatewayAuthenticationCertificate))]
        [TestCase(typeof(ApplicationGatewaySslCertificate))]
        [TestCase(typeof(ApplicationGatewayTrustedClientCertificate))]
        [TestCase(typeof(ApplicationGatewayTrustedRootCertificate))]
        public void CertificateDataUsesNativeFlattenedStorage(Type type)
        {
            typeof(NetworkBatchFiveInvestigationTests)
                .GetMethod(nameof(CheckCertificateData), BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(type).Invoke(null, null);
        }

        private static void CheckCertificateData<T>() where T : new()
        {
            var value = new T();
            PropertyInfo dataProperty = typeof(T).GetProperty("Data");
            PropertyInfo propertiesProperty = typeof(T).GetProperty("Properties", BindingFlags.NonPublic | BindingFlags.Instance);
            var payload = BinaryData.FromBytes(new byte[] { 1, 2, 3 });
            dataProperty.SetValue(value, payload);
            Assert.That(dataProperty.GetValue(value), Is.SameAs(payload));
            object properties = propertiesProperty.GetValue(value);
            Assert.That(properties.GetType().GetProperty("Data").GetValue(properties), Is.SameAs(payload));

            using JsonDocument wire = JsonDocument.Parse(ModelReaderWriter.Write(value, new ModelReaderWriterOptions("W")));
            Assert.That(wire.RootElement.GetProperty("properties").GetProperty("data").GetString(), Is.EqualTo("AQID"));
            T restored = ModelReaderWriter.Read<T>(ModelReaderWriter.Write(value));
            Assert.That(((BinaryData)dataProperty.GetValue(restored)).ToArray(), Is.EqualTo(payload.ToArray()));

            propertiesProperty.SetValue(value, null);
            Assert.That(dataProperty.GetValue(value), Is.Null);
            dataProperty.SetValue(value, payload);
            Assert.That(dataProperty.GetValue(value), Is.SameAs(payload));
            dataProperty.SetValue(value, null);
            Assert.That(propertiesProperty.GetValue(value).GetType().GetProperty("Data").GetValue(propertiesProperty.GetValue(value)), Is.Null);
        }

        [TestCase(typeof(ApplicationGatewaySslCertificate), "PublicCertData", "publicCertData")]
        [TestCase(typeof(ApplicationGatewayTrustedClientCertificate), "ValidatedCertData", "validatedCertData")]
        public void CertificateOutputDataRemainsReadOnly(Type type, string propertyName, string wireName)
        {
            typeof(NetworkBatchFiveInvestigationTests)
                .GetMethod(nameof(CheckCertificateOutput), BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(type).Invoke(null, new object[] { propertyName, wireName });
        }

        private static void CheckCertificateOutput<T>(string propertyName, string wireName)
        {
            var value = ModelReaderWriter.Read<T>(BinaryData.FromString($$$"""{"properties":{"{{{wireName}}}":"AQID"}}"""));
            PropertyInfo property = typeof(T).GetProperty(propertyName);
            Assert.That(property.CanWrite, Is.False);
            Assert.That(((BinaryData)property.GetValue(value)).ToArray(), Is.EqualTo(new byte[] { 1, 2, 3 }));
            object properties = typeof(T).GetProperty("Properties", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(value);
            Assert.That(property.GetValue(value), Is.SameAs(properties.GetType().GetProperty(propertyName).GetValue(properties)));
            using JsonDocument persisted = JsonDocument.Parse(ModelReaderWriter.Write(value));
            Assert.That(persisted.RootElement.GetProperty("properties").GetProperty(wireName).GetString(), Is.EqualTo("AQID"));
            using JsonDocument wire = JsonDocument.Parse(ModelReaderWriter.Write(value, new ModelReaderWriterOptions("W")));
            Assert.That(wire.RootElement.GetProperty("properties").TryGetProperty(wireName, out _), Is.False);
        }

        [Test]
        public void RedirectUriUsesNativeFlattenedStorage()
        {
            var value = new ApplicationGatewayRedirectConfiguration();
            var target = new Uri("https://example.test/redirect");
            value.TargetUri = target;
            Assert.That(value.TargetUri, Is.SameAs(target));
            Assert.That(value.Properties.TargetUri, Is.SameAs(target));
            using JsonDocument wire = JsonDocument.Parse(ModelReaderWriter.Write(value, new ModelReaderWriterOptions("W")));
            Assert.That(wire.RootElement.GetProperty("properties").GetProperty("targetUrl").GetString(), Is.EqualTo(target.AbsoluteUri));
            var restored = ModelReaderWriter.Read<ApplicationGatewayRedirectConfiguration>(ModelReaderWriter.Write(value));
            Assert.That(restored.TargetUri, Is.EqualTo(target));
            Assert.That(restored.TargetUri, Is.SameAs(restored.Properties.TargetUri));
            value.Properties = null;
            Assert.That(value.TargetUri, Is.Null);
            value.TargetUri = target;
            Assert.That(value.Properties.TargetUri, Is.SameAs(target));
            value.TargetUri = null;
            Assert.That(value.Properties.TargetUri, Is.Null);
        }

        [Test]
        public void ConnectionMonitorCollectionsReadAndPersistFlattenedState()
        {
            var value = ModelReaderWriter.Read<ConnectionMonitorData>(BinaryData.FromString("""
                {"location":"westus2","tags":{"environment":"test"},"properties":{"endpoints":[{"name":"source"}],"testConfigurations":[{"name":"tcp","protocol":"Tcp"}],"testGroups":[{"name":"group","testConfigurations":["tcp"],"sources":["source"],"destinations":["destination"]}],"outputs":[{"type":"Workspace"}],"notes":"monitor notes","connectionMonitorType":"MultiEndpoint"}}
                """));
            Assert.That(value.Endpoints[0].Name, Is.EqualTo("source"));
            Assert.That(value.TestConfigurations[0].Name, Is.EqualTo("tcp"));
            Assert.That(value.TestGroups[0].Name, Is.EqualTo("group"));
            Assert.That(value.Outputs, Has.Count.EqualTo(1));
            Assert.That(value.Notes, Is.EqualTo("monitor notes"));
            Assert.That(value.ConnectionMonitorType, Is.EqualTo(ConnectionMonitorType.MultiEndpoint));
            Assert.That(value.Endpoints[0], Is.SameAs(value.Properties.Endpoints[0]));
            value.Properties.Endpoints.Add(new ConnectionMonitorEndpoint("destination"));
            Assert.That(value.Endpoints, Has.Count.EqualTo(2));
            var restored = ModelReaderWriter.Read<ConnectionMonitorData>(ModelReaderWriter.Write(value));
            Assert.That(restored.Endpoints[1].Name, Is.EqualTo("destination"));
            Assert.That(restored.TestConfigurations[0].Name, Is.EqualTo("tcp"));
            Assert.That(restored.TestGroups[0].Name, Is.EqualTo("group"));
            Assert.That(restored.Outputs, Has.Count.EqualTo(1));
        }

        [Test]
        public void ConnectionMonitorMissingPropertiesRemainNull()
        {
            var value = ModelReaderWriter.Read<ConnectionMonitorData>(BinaryData.FromString("{}"));
            Assert.That(value.Endpoints, Is.Null);
            Assert.That(value.TestConfigurations, Is.Null);
            Assert.That(value.TestGroups, Is.Null);
            Assert.That(value.Outputs, Is.Null);
        }

        [TestCase("MultiEndpoint")]
        [TestCase("SingleSourceDestination")]
        [TestCase("FutureMonitorCategory")]
        [TestCase(null)]
        public void MonitorCategoryFactoriesAndPersistencePreserveWireValues(string wireValue)
        {
            ConnectionMonitorType? monitorType = wireValue is null ? (ConnectionMonitorType?)null : new ConnectionMonitorType(wireValue);
            ConnectionMonitorData data = ArmNetworkModelFactory.ConnectionMonitorData(notes: "category test", connectionMonitorType: monitorType);
            ConnectionMonitorData nativeData = ArmNetworkModelFactory.ConnectionMonitorData(
                default, default, default, default, default(ConnectionMonitorSource), default,
                default, default, default, default, default, default, "category test",
                default, default, default, monitorType, default, default, default);
            Assert.That(data.ConnectionMonitorType, Is.EqualTo(monitorType));
            Assert.That(nativeData.ConnectionMonitorType, Is.EqualTo(monitorType));
            var restoredData = ModelReaderWriter.Read<ConnectionMonitorData>(ModelReaderWriter.Write(data));
            Assert.That(restoredData.ConnectionMonitorType, Is.EqualTo(monitorType));

            var properties = data.Properties;
            var nativeProperties = nativeData.Properties;
            Assert.That(properties.ConnectionMonitorType, Is.EqualTo(monitorType));
            Assert.That(nativeProperties.ConnectionMonitorType, Is.EqualTo(monitorType));
            var restoredProperties = ModelReaderWriter.Read<ConnectionMonitorResultProperties>(ModelReaderWriter.Write(properties));
            Assert.That(restoredProperties.ConnectionMonitorType, Is.EqualTo(monitorType));
            if (wireValue is not null)
            {
                using JsonDocument persisted = JsonDocument.Parse(ModelReaderWriter.Write(data));
                Assert.That(persisted.RootElement.GetProperty("properties").GetProperty("connectionMonitorType").GetString(), Is.EqualTo(wireValue));
            }
        }

        [Test]
        public void MonitorCategoryFactoriesPreservePresentDefaultStructs()
        {
            ConnectionMonitorData data = ArmNetworkModelFactory.ConnectionMonitorData(connectionMonitorType: default(ConnectionMonitorType));
            Assert.That(data.ConnectionMonitorType.HasValue, Is.True);
            Assert.That(data.ConnectionMonitorType.Value.ToString(), Is.Null);
            Assert.That(data.Properties.ConnectionMonitorType.HasValue, Is.True);
            Assert.That(data.Properties.ConnectionMonitorType.Value.ToString(), Is.Null);
            var properties = ArmNetworkModelFactory.ConnectionMonitorData(
                default, default, default, default, default(ConnectionMonitorSource), default,
                default, default, default, default, default, default, default,
                default, default, default, default(ConnectionMonitorType), default, default, default).Properties;
            Assert.That(properties.ConnectionMonitorType.HasValue, Is.True);
            Assert.That(properties.ConnectionMonitorType.Value.ToString(), Is.Null);
        }

        [Test]
        public void CompleteConnectionMonitorRequestSerializesEnvelopeAndWritableSettings()
        {
            ConnectionMonitorCreateOrUpdateContent value = CreateConnectionMonitorContent();
            Assert.That(typeof(ConnectionMonitorCreateOrUpdateContent).GetProperty("Location").PropertyType, Is.EqualTo(typeof(AzureLocation?)));
            foreach (string name in new[] { "Source", "Destination", "AutoStart", "MonitoringIntervalInSeconds", "Notes" })
            {
                Assert.That(typeof(ConnectionMonitorCreateOrUpdateContent).GetProperty(name).CanWrite, Is.True, name);
            }
            Assert.That(value.Endpoints, Is.SameAs(value.Properties.Endpoints));
            Assert.That(value.Source, Is.SameAs(value.Properties.Source));
            using JsonDocument wire = JsonDocument.Parse(ModelReaderWriter.Write(value, new ModelReaderWriterOptions("W")));
            AssertConnectionMonitorRequest(wire.RootElement);
            var restored = ModelReaderWriter.Read<ConnectionMonitorCreateOrUpdateContent>(ModelReaderWriter.Write(value));
            Assert.That(restored.Location, Is.EqualTo(value.Location));
            Assert.That(restored.Tags["environment"], Is.EqualTo("test"));
            Assert.That(restored.Notes, Is.EqualTo("monitor notes"));
            Assert.That(restored.AutoStart, Is.True);
            Assert.That(restored.MonitoringIntervalInSeconds, Is.EqualTo(30));
            Assert.That(restored.Endpoints[0].Name, Is.EqualTo("source"));
        }

        [Test]
        public void ReleasedConnectionMonitorNameUsesCanonicalPersistence()
        {
            ConnectionMonitorContent value = CreateConnectionMonitorContent().ToConnectionMonitorContent();
            using JsonDocument wire = JsonDocument.Parse(ModelReaderWriter.Write(value, new ModelReaderWriterOptions("W")));
            AssertConnectionMonitorRequest(wire.RootElement);
            using JsonDocument canonicalWire = JsonDocument.Parse(ModelReaderWriter.Write<ConnectionMonitorCreateOrUpdateContent>(value, new ModelReaderWriterOptions("W")));
            AssertConnectionMonitorRequest(canonicalWire.RootElement);
            var restored = ModelReaderWriter.Read<ConnectionMonitorContent>(ModelReaderWriter.Write(value));
            Assert.That(restored.Source.ResourceId, Is.EqualTo(value.Source.ResourceId));
            Assert.That(restored.Location, Is.EqualTo(value.Location));
            Assert.That(restored.Endpoints, Is.SameAs(restored.Properties.Endpoints));
            restored.Notes = "changed";
            Assert.That(restored.Properties.Notes, Is.EqualTo("changed"));

            var unknown = ModelReaderWriter.Read<ConnectionMonitorContent>(BinaryData.FromString("""
                {"location":"westus2","future":{"value":42},"properties":{"notes":"retained","futureSetting":true}}
                """));
            using JsonDocument persisted = JsonDocument.Parse(ModelReaderWriter.Write(unknown));
            Assert.That(persisted.RootElement.GetProperty("future").GetProperty("value").GetInt32(), Is.EqualTo(42));
            Assert.That(persisted.RootElement.GetProperty("properties").GetProperty("futureSetting").GetBoolean(), Is.True);
            Assert.Throws<FormatException>(() => ModelReaderWriter.Write(value, new ModelReaderWriterOptions("X")));

            var reader = new Utf8JsonReader(ModelReaderWriter.Write(value).ToMemory().Span);
            ConnectionMonitorContent jsonRestored = ((IJsonModel<ConnectionMonitorContent>)value).Create(ref reader, ModelReaderWriterOptions.Json);
            Assert.That(jsonRestored.Notes, Is.EqualTo(value.Notes));
            Assert.That(new ConnectionMonitorContent().Tags, Is.Empty);
            Assert.That(new ConnectionMonitorContent().Endpoints, Is.Empty);
        }

        [Test]
        public void ReleasedConnectionMonitorFactoriesPopulateConnectedSettings()
        {
            ConnectionMonitorCreateOrUpdateContent content = CreateConnectionMonitorContent();
            ConnectionMonitorCreateOrUpdateContent canonical = ArmNetworkModelFactory.ConnectionMonitorCreateOrUpdateContent(
                content.Source, content.Destination, content.AutoStart, content.MonitoringIntervalInSeconds,
                content.Endpoints, content.TestConfigurations, content.TestGroups, content.Outputs, content.Notes);
            canonical.Location = content.Location;
            canonical.Tags.Add("environment", "test");
            using JsonDocument canonicalWire = JsonDocument.Parse(ModelReaderWriter.Write(canonical, new ModelReaderWriterOptions("W")));
            AssertConnectionMonitorRequest(canonicalWire.RootElement);
            var tags = new Dictionary<string, string> { ["environment"] = "test" };
            ConnectionMonitorContent compatibility = ArmNetworkModelFactory.ConnectionMonitorContent(
                content.Source, content.Destination, content.AutoStart, content.MonitoringIntervalInSeconds,
                content.Endpoints, content.TestConfigurations, content.TestGroups, content.Outputs, content.Notes,
                content.Location, tags);
            Assert.That(compatibility.Tags, Is.SameAs(tags));
            using JsonDocument compatibilityWire = JsonDocument.Parse(ModelReaderWriter.Write(compatibility, new ModelReaderWriterOptions("W")));
            AssertConnectionMonitorRequest(compatibilityWire.RootElement);
            Assert.That(ArmNetworkModelFactory.ConnectionMonitorCreateOrUpdateContent().Tags, Is.Empty);
            Assert.That(ArmNetworkModelFactory.ConnectionMonitorContent().Endpoints, Is.Empty);
        }

        [TestCase(false, null, false)]
        [TestCase(false, "true", false)]
        [TestCase(true, null, false)]
        [TestCase(true, "true", false)]
        [TestCase(false, null, true)]
        [TestCase(false, "true", true)]
        [TestCase(true, null, true)]
        [TestCase(true, "true", true)]
        public async Task NativeConnectionMonitorCreateUsesServiceOperation(bool asynchronous, string migrate, bool compatibilityName)
        {
            var transport = new MockTransport(new MockResponse(200).SetContent($$$"""
                {"id":"{{{WatcherId}}}/connectionMonitors/monitor","name":"monitor","type":"Microsoft.Network/networkWatchers/connectionMonitors","location":"westus2","properties":{"provisioningState":"Succeeded"}}
                """));
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            ConnectionMonitorCollection collection = client.GetNetworkWatcherResource(new ResourceIdentifier(WatcherId)).GetConnectionMonitors();
            ConnectionMonitorCreateOrUpdateContent content = CreateConnectionMonitorContent();
            ArmOperation<ConnectionMonitorResource> operation;
            if (compatibilityName)
            {
                ConnectionMonitorContent compatibility = content.ToConnectionMonitorContent();
                operation = asynchronous
                    ? await collection.CreateOrUpdateAsync(WaitUntil.Completed, "monitor", compatibility, migrate, CancellationToken.None)
                    : collection.CreateOrUpdate(WaitUntil.Completed, "monitor", compatibility, migrate, CancellationToken.None);
            }
            else
            {
                operation = asynchronous
                    ? await collection.CreateOrUpdateAsync(WaitUntil.Completed, "monitor", content, migrate, CancellationToken.None)
                    : collection.CreateOrUpdate(WaitUntil.Completed, "monitor", content, migrate, CancellationToken.None);
            }
            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Id.ToString(), Is.EqualTo(WatcherId + "/connectionMonitors/monitor"));
            Assert.That(transport.SingleRequest.Method, Is.EqualTo(RequestMethod.Put));
            string uri = transport.SingleRequest.Uri.ToString();
            Assert.That(uri, Does.Contain("/networkWatchers/watcher/connectionMonitors/monitor?"));
            Assert.That(uri, Does.Contain("api-version=2026-01-01"));
            Assert.That(uri.Contains("migrate=true"), Is.EqualTo(migrate != null));
            using var stream = new MemoryStream();
            transport.SingleRequest.Content.WriteTo(stream, CancellationToken.None);
            using JsonDocument wire = JsonDocument.Parse(stream.ToArray());
            AssertConnectionMonitorRequest(wire.RootElement);
        }

        [TestCase("three")]
        [TestCase("cancellation")]
        [TestCase("named-cancellation")]
        public async Task ReleasedAsyncOverloadsForwardToNativeOperation(string overload)
        {
            var transport = new MockTransport(new MockResponse(200).SetContent($$$"""
                {"id":"{{{WatcherId}}}/connectionMonitors/monitor","name":"monitor","type":"Microsoft.Network/networkWatchers/connectionMonitors","properties":{"provisioningState":"Succeeded"}}
                """));
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            ConnectionMonitorCollection collection = client.GetNetworkWatcherResource(new ResourceIdentifier(WatcherId)).GetConnectionMonitors();
            ConnectionMonitorCreateOrUpdateContent content = CreateConnectionMonitorContent();
            ArmOperation<ConnectionMonitorResource> operation = overload switch
            {
                "three" => await collection.CreateOrUpdateAsync(WaitUntil.Completed, "monitor", content),
                "cancellation" => await collection.CreateOrUpdateAsync(WaitUntil.Completed, "monitor", content, CancellationToken.None),
                _ => await collection.CreateOrUpdateAsync(WaitUntil.Completed, "monitor", content, cancellationToken: CancellationToken.None)
            };
            Assert.That(operation.HasValue, Is.True);
            Assert.That(transport.SingleRequest.Uri.ToString(), Does.Not.Contain("migrate="));
            using var stream = new MemoryStream();
            transport.SingleRequest.Content.WriteTo(stream, CancellationToken.None);
            using JsonDocument wire = JsonDocument.Parse(stream.ToArray());
            AssertConnectionMonitorRequest(wire.RootElement);
        }

        private static ConnectionMonitorCreateOrUpdateContent CreateConnectionMonitorContent()
        {
            var value = new ConnectionMonitorCreateOrUpdateContent
            {
                Location = AzureLocation.WestUS2,
                Source = new ConnectionMonitorSource(new ResourceIdentifier("/subscriptions/" + SubscriptionId + "/resourceGroups/rg/providers/Microsoft.Compute/virtualMachines/source")),
                Destination = new ConnectionMonitorDestination { Address = "example.test", Port = 443 },
                AutoStart = true,
                MonitoringIntervalInSeconds = 30,
                Notes = "monitor notes"
            };
            value.Tags.Add("environment", "test");
            value.Endpoints.Add(new ConnectionMonitorEndpoint("source"));
            value.TestConfigurations.Add(new ConnectionMonitorTestConfiguration("tcp", ConnectionMonitorTestConfigurationProtocol.Tcp));
            value.TestGroups.Add(new ConnectionMonitorTestGroup("group", new[] { "tcp" }, new[] { "source" }, new[] { "destination" }));
            value.Outputs.Add(new ConnectionMonitorOutput { OutputType = OutputType.Workspace });
            return value;
        }

        private static void AssertConnectionMonitorRequest(JsonElement root)
        {
            Assert.That(root.GetProperty("location").GetString(), Is.EqualTo("westus2"));
            Assert.That(root.GetProperty("tags").GetProperty("environment").GetString(), Is.EqualTo("test"));
            JsonElement properties = root.GetProperty("properties");
            Assert.That(properties.TryGetProperty("location", out _), Is.False);
            Assert.That(properties.TryGetProperty("tags", out _), Is.False);
            Assert.That(properties.GetProperty("notes").GetString(), Is.EqualTo("monitor notes"));
            Assert.That(properties.GetProperty("autoStart").GetBoolean(), Is.True);
            Assert.That(properties.GetProperty("monitoringIntervalInSeconds").GetInt32(), Is.EqualTo(30));
            Assert.That(properties.GetProperty("source").GetProperty("resourceId").GetString(), Does.EndWith("/virtualMachines/source"));
            Assert.That(properties.GetProperty("destination").GetProperty("address").GetString(), Is.EqualTo("example.test"));
            Assert.That(properties.GetProperty("endpoints")[0].GetProperty("name").GetString(), Is.EqualTo("source"));
            Assert.That(properties.GetProperty("testConfigurations")[0].GetProperty("name").GetString(), Is.EqualTo("tcp"));
            Assert.That(properties.GetProperty("testGroups")[0].GetProperty("name").GetString(), Is.EqualTo("group"));
            Assert.That(properties.GetProperty("outputs")[0].GetProperty("type").GetString(), Is.EqualTo("Workspace"));
        }
    }
}
