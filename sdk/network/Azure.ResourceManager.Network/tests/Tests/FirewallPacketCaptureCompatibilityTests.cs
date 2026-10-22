// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class FirewallPacketCaptureCompatibilityTests
    {
        [Test]
        public void NativeRequestRoundTripsWithoutLegacyInheritance()
        {
            Assert.That(typeof(FirewallPacketCaptureRequestContent).BaseType, Is.EqualTo(typeof(object)));
            Assert.That(typeof(FirewallPacketCaptureRequestContent).GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            const string json = """{"durationInSeconds":12,"numberOfPacketsToCapture":3,"sasUrl":"https://example.com/capture","fileName":"capture.pcap","protocol":"TCP","flags":[{"type":"syn"}],"filters":[{"sources":["10.0.0.1"],"destinations":["10.0.0.2"],"destinationPorts":["443"]}],"operation":"Start","futureField":42}""";
            var reader = new Utf8JsonReader(BinaryData.FromString(json).ToMemory().Span);
            var request = ((IJsonModel<FirewallPacketCaptureRequestContent>)new FirewallPacketCaptureRequestContent()).Create(ref reader, ModelReaderWriterOptions.Json);
            Assert.That(reader.TokenType, Is.EqualTo(JsonTokenType.EndObject));
            Assert.That(request.DurationInSeconds, Is.EqualTo(12));
            Assert.That(request.NumberOfPacketsToCapture, Is.EqualTo(3));
            Assert.That(request.FileName, Is.EqualTo("capture.pcap"));
            Assert.That(request.Flags.Count, Is.EqualTo(1));
            Assert.That(request.Filters.Count, Is.EqualTo(1));
            Assert.That(request.Filters.Single().Sources.Single(), Is.EqualTo("10.0.0.1"));
            Assert.That(request.Filters.Single().Destinations.Single(), Is.EqualTo("10.0.0.2"));
            Assert.That(request.Filters.Single().DestinationPorts.Single(), Is.EqualTo("443"));
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<FirewallPacketCaptureRequestContent>)request).Write(writer, ModelReaderWriterOptions.Json);
            }
            foreach (BinaryData persisted in new[]
            {
                BinaryData.FromBytes(stream.ToArray()),
                ModelReaderWriter.Write(request),
                ((IPersistableModel<FirewallPacketCaptureRequestContent>)request).Write(ModelReaderWriterOptions.Json)
            })
            {
                using JsonDocument document = JsonDocument.Parse(persisted);
                Assert.That(document.RootElement.GetProperty("futureField").GetInt32(), Is.EqualTo(42));
                var restored = ModelReaderWriter.Read<FirewallPacketCaptureRequestContent>(persisted);
                Assert.That(restored.DurationInSeconds, Is.EqualTo(request.DurationInSeconds));
                Assert.That(restored.SasUri, Is.EqualTo(request.SasUri));
                Assert.That(restored.Protocol, Is.EqualTo(request.Protocol));
                Assert.That(restored.Operation, Is.EqualTo(request.Operation));
                Assert.That(restored.Flags.Select(flag => flag.FlagsType), Is.EqualTo(request.Flags.Select(flag => flag.FlagsType)));
                Assert.That(restored.Filters.Single().Sources, Is.EqualTo(request.Filters.Single().Sources));
            }
            Assert.That(ModelReaderWriter.Read<FirewallPacketCaptureRequestContent>(BinaryData.FromString("null")), Is.Null);
            Assert.Throws<FormatException>(() => ((IPersistableModel<FirewallPacketCaptureRequestContent>)request).Create(BinaryData.FromString("{}"), new ModelReaderWriterOptions("X")));
        }

        [Test]
        public void PacketCaptureOverloadsRetainTheirHistoricalContracts()
        {
            Assert.That(typeof(FirewallPacketCaptureContent).BaseType, Is.EqualTo(typeof(NetworkSubResource)));
            Assert.That(typeof(FirewallPacketCaptureContent).GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(typeof(FirewallPacketCaptureContent).GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never));
            Assert.That(typeof(FirewallPacketCaptureContent).GetProperty("Operation"), Is.Null);
            var content = new FirewallPacketCaptureContent();
            Assert.That(content.Flags, Is.Empty);
            Assert.That(content.Filters, Is.Empty);

            MethodInfo[] legacy = typeof(AzureFirewallResource).GetMethods()
                .Where(method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(FirewallPacketCaptureContent))).ToArray();
            Assert.That(legacy.Select(method => method.Name), Is.EquivalentTo(new[] { "PacketCapture", "PacketCaptureAsync" }));
            foreach (MethodInfo method in legacy)
            {
                Assert.That(method.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
                Assert.That(method.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never));
                Assert.That(method.GetParameters().Last().IsOptional, Is.True);
                Assert.That(method.GetParameters().Last().HasDefaultValue, Is.True);
                Assert.That(method.ReturnType, Is.EqualTo(method.Name.EndsWith("Async", StringComparison.Ordinal) ? typeof(Task<ArmOperation>) : typeof(ArmOperation)));
            }

            MethodInfo[] native = typeof(AzureFirewallResource).GetMethods()
                .Where(method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(FirewallPacketCaptureRequestContent))).ToArray();
            Assert.That(native.Select(method => method.Name), Is.EquivalentTo(new[] { "PacketCapture", "PacketCaptureAsync", "PacketCaptureOperation", "PacketCaptureOperationAsync" }));
            foreach (MethodInfo method in native)
            {
                Assert.That(method.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
                Assert.That(method.GetParameters().Last().IsOptional, Is.True);
                Assert.That(method.GetParameters().Last().HasDefaultValue, Is.True);
                Type operationType = method.Name.StartsWith("PacketCaptureOperation", StringComparison.Ordinal) ? typeof(ArmOperation<AzureFirewallPacketCaptureResult>) : typeof(ArmOperation);
                Assert.That(method.ReturnType, Is.EqualTo(method.Name.EndsWith("Async", StringComparison.Ordinal) ? typeof(Task<>).MakeGenericType(operationType) : operationType));
            }
        }

        [Test]
        public async Task LegacyPacketCaptureForwardsConvertedContent()
        {
            var flags = new List<AzureFirewallPacketCaptureFlags> { new AzureFirewallPacketCaptureFlags() };
            var filters = new List<AzureFirewallPacketCaptureRule> { new AzureFirewallPacketCaptureRule() };
            var legacy = new FirewallPacketCaptureContent(
                new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/azureFirewalls/fw"),
                new Dictionary<string, BinaryData> { ["futureField"] = BinaryData.FromString("42") },
                12, 3, new Uri("https://example.com/capture"), "capture.pcap", AzureFirewallNetworkRuleProtocol.Tcp, flags, filters);
            var firewall = new PacketCaptureProbe();
            using var cancellation = new CancellationTokenSource();

            Assert.That(firewall.PacketCapture(WaitUntil.Started, legacy, cancellation.Token), Is.Null);
            AssertConvertedContent(firewall.Content);
            Assert.That(firewall.WaitUntil, Is.EqualTo(WaitUntil.Started));
            Assert.That(firewall.CancellationToken, Is.EqualTo(cancellation.Token));
            Assert.That(await firewall.PacketCaptureAsync(WaitUntil.Completed, legacy, cancellation.Token), Is.Null);
            AssertConvertedContent(firewall.Content);
            Assert.That(firewall.WaitUntil, Is.EqualTo(WaitUntil.Completed));
            Assert.That(firewall.CancellationToken, Is.EqualTo(cancellation.Token));

            void AssertConvertedContent(FirewallPacketCaptureRequestContent request)
            {
                Assert.That(request.DurationInSeconds, Is.EqualTo(legacy.DurationInSeconds));
                Assert.That(request.NumberOfPacketsToCapture, Is.EqualTo(legacy.NumberOfPacketsToCapture));
                Assert.That(request.SasUri, Is.EqualTo(legacy.SasUri));
                Assert.That(request.FileName, Is.EqualTo(legacy.FileName));
                Assert.That(request.Protocol, Is.EqualTo(legacy.Protocol));
                Assert.That(request.Flags, Is.SameAs(flags));
                Assert.That(request.Filters, Is.SameAs(filters));
                Assert.That(request.Operation, Is.Null);
                using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(request));
                Assert.That(document.RootElement.GetProperty("futureField").GetInt32(), Is.EqualTo(42));
                Assert.That(document.RootElement.TryGetProperty("id", out _), Is.False);
                Assert.That(document.RootElement.TryGetProperty("operation", out _), Is.False);
            }
        }

        [Test]
        public void NativeModelFactoryPreservesAllCaptureFields()
        {
            var flags = new[] { new AzureFirewallPacketCaptureFlags() };
            var filters = new[] { new AzureFirewallPacketCaptureRule() };
            var request = ArmNetworkModelFactory.FirewallPacketCaptureRequestContent(
                12, 3, new Uri("https://example.com/capture"), "capture.pcap",
                AzureFirewallNetworkRuleProtocol.Tcp, flags, filters, AzureFirewallPacketCaptureOperationType.Status);
            Assert.That(request.DurationInSeconds, Is.EqualTo(12));
            Assert.That(request.NumberOfPacketsToCapture, Is.EqualTo(3));
            Assert.That(request.SasUri, Is.EqualTo(new Uri("https://example.com/capture")));
            Assert.That(request.FileName, Is.EqualTo("capture.pcap"));
            Assert.That(request.Protocol, Is.EqualTo(AzureFirewallNetworkRuleProtocol.Tcp));
            Assert.That(request.Flags, Is.EqualTo(flags));
            Assert.That(request.Filters, Is.EqualTo(filters));
            Assert.That(request.Operation, Is.EqualTo(AzureFirewallPacketCaptureOperationType.Status));
        }

        [Test]
        public void LegacySerializationRetainsHistoricalUnsupportedBehavior()
        {
            var legacy = (IPersistableModel<FirewallPacketCaptureContent>)new FirewallPacketCaptureContent();
            Assert.Throws<NotImplementedException>(() => legacy.Create(BinaryData.FromString("{}"), ModelReaderWriterOptions.Json));
            Assert.Throws<NotImplementedException>(() => legacy.Write(ModelReaderWriterOptions.Json));
            Assert.Throws<NotImplementedException>(() => legacy.GetFormatFromOptions(ModelReaderWriterOptions.Json));
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            Assert.Throws<NotImplementedException>(() => ((IJsonModel<FirewallPacketCaptureContent>)legacy).Write(writer, ModelReaderWriterOptions.Json));
            Assert.Throws<NotImplementedException>(() =>
            {
                var reader = new Utf8JsonReader("{}"u8);
                ((IJsonModel<FirewallPacketCaptureContent>)legacy).Create(ref reader, ModelReaderWriterOptions.Json);
            });
        }

        private sealed class PacketCaptureProbe : AzureFirewallResource
        {
            public FirewallPacketCaptureRequestContent Content { get; private set; }
            public WaitUntil WaitUntil { get; private set; }
            public CancellationToken CancellationToken { get; private set; }

            public override ArmOperation PacketCapture(WaitUntil waitUntil, FirewallPacketCaptureRequestContent content, CancellationToken cancellationToken)
            {
                Content = content;
                WaitUntil = waitUntil;
                CancellationToken = cancellationToken;
                return null;
            }

            public override Task<ArmOperation> PacketCaptureAsync(WaitUntil waitUntil, FirewallPacketCaptureRequestContent content, CancellationToken cancellationToken)
            {
                return Task.FromResult(PacketCapture(waitUntil, content, cancellationToken));
            }
        }
    }
}
