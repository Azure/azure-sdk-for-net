// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;
using static Azure.ResourceManager.Network.Tests.CompatibilityTestHelpers;

#pragma warning disable CS0618 // Exercise the released retired-query model contracts.

namespace Azure.ResourceManager.Network.Tests
{
    [NUnit.Framework.Category("Compatibility")]
    public class ConnectionMonitorQueryCompatibilityTests
    {
        private const string SnapshotJson = """
            {"connectionState":"future-state","startTime":"2025-01-02T03:04:05.1234567+02:00",
             "endTime":"2025-01-02T03:09:05.1234567+02:00","evaluationState":"future-evaluation",
             "avgLatencyInMs":3000000001,"minLatencyInMs":3000000000,"maxLatencyInMs":3000000002,
             "probesSent":10000000000,"probesFailed":3000000003,
             "hops":[{"id":"hop-1","type":"VirtualMachine","address":"10.0.0.1",
                      "nextHopIds":["hop-2"],"futureHop":{"value":true}}],
             "futureSnapshot":{"items":[1,null,true]}}
            """;
        private static readonly DateTimeOffset Start = DateTimeOffset.Parse("2025-01-02T03:04:05.1234567+02:00");

        [Test]
        public void FactoriesPreserveAllInputsAndCopyTheirCollections()
        {
            var hop = ModelReaderWriter.Read<ConnectivityHopInfo>(BinaryData.FromString("""{"id":"hop-1","address":"10.0.0.1"}"""));
            var hops = new List<ConnectivityHopInfo> { hop };
            var snapshot = ArmNetworkModelFactory.ConnectionStateSnapshot(
                new NetworkConnectionState("future-state"), Start, Start.AddMinutes(5),
                new EvaluationState("future-evaluation"), 3000000001, 3000000000, 3000000002,
                10000000000, 3000000003, hops);
            AssertSnapshot(snapshot);
            Assert.That(snapshot.StartOn.Value.Offset, Is.EqualTo(Start.Offset));
            Assert.That(snapshot.Hops[0], Is.SameAs(hop));
            hops.Clear();
            Assert.That(snapshot.Hops, Has.Count.EqualTo(1));

            var states = new List<ConnectionStateSnapshot> { snapshot };
            var result = ArmNetworkModelFactory.ConnectionMonitorQueryResult(new ConnectionMonitorSourceStatus("future-source"), states);
            Assert.That(result.SourceStatus.ToString(), Is.EqualTo("future-source"));
            Assert.That(result.States[0], Is.SameAs(snapshot));
            states.Clear();
            Assert.That(result.States, Has.Count.EqualTo(1));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void FactoryDefaultsPreserveExplicitEmptyCollections(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var result = ArmNetworkModelFactory.ConnectionMonitorQueryResult();
            var snapshot = ArmNetworkModelFactory.ConnectionStateSnapshot();
            Assert.That(result.States, Is.Empty);
            Assert.That(snapshot.Hops, Is.Empty);
            using JsonDocument queryJson = JsonDocument.Parse(ModelReaderWriter.Write(result, options, AzureResourceManagerNetworkContext.Default));
            Assert.That(queryJson.RootElement.GetProperty("states").GetArrayLength(), Is.Zero);
            using JsonDocument snapshotJson = JsonDocument.Parse(ModelReaderWriter.Write(snapshot, options, AzureResourceManagerNetworkContext.Default));
            Assert.That(snapshotJson.RootElement.TryGetProperty("hops", out JsonElement hops), Is.EqualTo(format == "J"));
            if (format == "J")
                Assert.That(hops.GetArrayLength(), Is.Zero);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripPreservesValuesAndReleasedWireFiltering(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            string payload = """{"sourceStatus":"future-source","states":[""" + SnapshotJson + """,null],"futureResult":{"version":1}}""";
            var result = ModelReaderWriter.Read<ConnectionMonitorQueryResult>(BinaryData.FromString(payload), options, AzureResourceManagerNetworkContext.Default);
            Assert.That(result.SourceStatus.ToString(), Is.EqualTo("future-source"));
            Assert.That(result.States, Has.Count.EqualTo(2));
            AssertSnapshot(result.States[0]);
            Assert.That(result.States[0].StartOn.Value.Offset, Is.EqualTo(Start.Offset));
            Assert.That(result.States[1], Is.Null);
            Assert.That(result.States[0].Hops[0].Address, Is.EqualTo("10.0.0.1"));

            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(result, options, AzureResourceManagerNetworkContext.Default));
            JsonElement snapshotJson = json.RootElement.GetProperty("states")[0];
            Assert.That(json.RootElement.GetProperty("states")[1].ValueKind, Is.EqualTo(JsonValueKind.Null));
            Assert.That(snapshotJson.GetProperty("connectionState").GetString(), Is.EqualTo("future-state"));
            Assert.That(snapshotJson.GetProperty("avgLatencyInMs").GetInt64(), Is.EqualTo(3000000001));
            Assert.That(snapshotJson.GetProperty("startTime").GetDateTimeOffset(), Is.EqualTo(Start));
            Assert.That(snapshotJson.TryGetProperty("hops", out JsonElement hops), Is.EqualTo(format == "J"));
            Assert.That(json.RootElement.TryGetProperty("futureResult", out _), Is.EqualTo(format == "J"));
            Assert.That(snapshotJson.TryGetProperty("futureSnapshot", out _), Is.EqualTo(format == "J"));
            if (format == "J")
            {
                Assert.That(hops[0].GetProperty("futureHop").GetProperty("value").GetBoolean(), Is.True);
                var roundTrip = ModelReaderWriter.Read<ConnectionMonitorQueryResult>(BinaryData.FromString(json.RootElement.GetRawText()), options, AzureResourceManagerNetworkContext.Default);
                AssertSnapshot(roundTrip.States[0]);
                Assert.That(roundTrip.States[0].StartOn.Value.Offset, Is.EqualTo(TimeSpan.Zero));
            }
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Utf8ReaderAndWriterPreserveSnapshotValues(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var snapshot = ReadJson<ConnectionStateSnapshot>(SnapshotJson, options);
            AssertSnapshot(snapshot);
            using JsonDocument json = JsonDocument.Parse(WriteJson(snapshot, options));
            Assert.That(json.RootElement.GetProperty("endTime").GetDateTimeOffset(), Is.EqualTo(Start.AddMinutes(5)));
            Assert.That(json.RootElement.GetProperty("minLatencyInMs").GetInt64(), Is.EqualTo(3000000000));
            Assert.That(json.RootElement.GetProperty("maxLatencyInMs").GetInt64(), Is.EqualTo(3000000002));
            Assert.That(json.RootElement.GetProperty("probesSent").GetInt64(), Is.EqualTo(10000000000));
            Assert.That(json.RootElement.GetProperty("probesFailed").GetInt64(), Is.EqualTo(3000000003));
            Assert.That(json.RootElement.TryGetProperty("hops", out _), Is.EqualTo(format == "J"));

            var result = ReadJson<ConnectionMonitorQueryResult>(
                """{"sourceStatus":"future-source","states":[""" + SnapshotJson + "]}", options);
            AssertSnapshot(result.States.Single());
            using JsonDocument resultJson = JsonDocument.Parse(WriteJson(result, options));
            Assert.That(resultJson.RootElement.GetProperty("sourceStatus").GetString(), Is.EqualTo("future-source"));
        }

        [TestCase(typeof(ConnectionMonitorQueryResult), "states")]
        [TestCase(typeof(ConnectionStateSnapshot), "hops")]
        public void MissingNullAndExplicitEmptyCollectionsKeepReleasedDistinction(Type modelType, string collection)
        {
            foreach (string format in new[] { "J", "W" })
            {
                var options = new ModelReaderWriterOptions(format);
                foreach (string value in new[] { null, "null", "[]" })
                {
                    string payload = value is null ? "{}" : "{\"" + collection + "\":" + value + "}";
                    object model = ModelReaderWriter.Read(BinaryData.FromString(payload), modelType, options, AzureResourceManagerNetworkContext.Default);
                    using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model, options, AzureResourceManagerNetworkContext.Default));
                    bool expected = value == "[]" && (collection == "states" || format == "J");
                    Assert.That(json.RootElement.TryGetProperty(collection, out _), Is.EqualTo(expected), $"{modelType.Name}, {format}, {payload}");
                }
            }
        }

        [TestCase("J")]
        [TestCase("W")]
        public void NullScalarValuesAreNotInvented(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            const string snapshotPayload = """
                {"connectionState":null,"startTime":null,"endTime":null,"evaluationState":null,
                 "avgLatencyInMs":null,"minLatencyInMs":null,"maxLatencyInMs":null,
                 "probesSent":null,"probesFailed":null,"hops":null}
                """;
            var snapshot = ModelReaderWriter.Read<ConnectionStateSnapshot>(BinaryData.FromString(snapshotPayload), options, AzureResourceManagerNetworkContext.Default);
            Assert.That(snapshot.Hops, Is.Empty);
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(snapshot, options, AzureResourceManagerNetworkContext.Default));
            Assert.That(json.RootElement.EnumerateObject(), Is.Empty);
            var result = ReadJson<ConnectionMonitorQueryResult>("""{"sourceStatus":null,"states":null}""", options);
            Assert.That(result.SourceStatus, Is.Null);
            Assert.That(result.States, Is.Empty);
        }

        [TestCase(typeof(ConnectionMonitorQueryResult))]
        [TestCase(typeof(ConnectionStateSnapshot))]
        public void NullPayloadsAndDefaultInstancesRetainReleasedBehavior(Type modelType)
        {
            foreach (string format in new[] { "J", "W" })
            {
                var options = new ModelReaderWriterOptions(format);
                Assert.That(ModelReaderWriter.Read(BinaryData.FromString("null"), modelType, options, AzureResourceManagerNetworkContext.Default), Is.Null);
                object model = Activator.CreateInstance(modelType, nonPublic: true);
                Assert.That(ModelReaderWriter.Write(model, options, AzureResourceManagerNetworkContext.Default).ToString(), Is.EqualTo("{}"));
            }
            Assert.That(modelType == typeof(ConnectionMonitorQueryResult)
                ? (object)ReadJson<ConnectionMonitorQueryResult>("null", ModelReaderWriterOptions.Json)
                : ReadJson<ConnectionStateSnapshot>("null", ModelReaderWriterOptions.Json), Is.Null);
        }

        [TestCase(typeof(ConnectionMonitorQueryResult))]
        [TestCase(typeof(ConnectionStateSnapshot))]
        public void UnsupportedFormatsFailInsteadOfReturningEmptyModels(Type modelType)
        {
            object model = Activator.CreateInstance(modelType, nonPublic: true);
            var persistable = (IPersistableModel<object>)model;
            var options = new ModelReaderWriterOptions("X");
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("{}"), options));
            Assert.Throws<FormatException>(() => persistable.Write(options));
            Assert.Throws<FormatException>(() => WriteJson((IJsonModel<object>)model, options));
            if (modelType == typeof(ConnectionMonitorQueryResult))
                Assert.Throws<FormatException>(() => ReadJson<ConnectionMonitorQueryResult>("{}", options));
            else
                Assert.Throws<FormatException>(() => ReadJson<ConnectionStateSnapshot>("{}", options));
        }

        [TestCase(typeof(ConnectionMonitorQueryResult))]
        [TestCase(typeof(ConnectionStateSnapshot))]
        public void MalformedPayloadsAreNotSilentlyAccepted(Type modelType)
        {
            foreach (string format in new[] { "J", "W" })
            {
                var options = new ModelReaderWriterOptions(format);
                Assert.Catch<JsonException>(() => ModelReaderWriter.Read(BinaryData.FromString("{"), modelType, options, AzureResourceManagerNetworkContext.Default));
            }
            if (modelType == typeof(ConnectionMonitorQueryResult))
                Assert.Throws<InvalidOperationException>(() => ReadJson<ConnectionMonitorQueryResult>("""{"states":{}}""", ModelReaderWriterOptions.Json));
            else
                Assert.Throws<FormatException>(() => ReadJson<ConnectionStateSnapshot>("""{"startTime":"not-a-date"}""", ModelReaderWriterOptions.Json));
        }

        [TestCase(typeof(ConnectionMonitorQueryResult))]
        [TestCase(typeof(ConnectionStateSnapshot))]
        public void ProtectedWriterWritesMembersInsideTheCallersObject(Type modelType)
        {
            object model = modelType == typeof(ConnectionMonitorQueryResult)
                ? (object)ArmNetworkModelFactory.ConnectionMonitorQueryResult(new ConnectionMonitorSourceStatus("future-source"))
                : ArmNetworkModelFactory.ConnectionStateSnapshot(avgLatencyInMs: 42);
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                writer.WriteStartObject();
                modelType.GetMethod("JsonModelWriteCore", BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(model, new object[] { writer, ModelReaderWriterOptions.Json });
                writer.WriteEndObject();
            }
            using JsonDocument json = JsonDocument.Parse(stream.ToArray());
            Assert.That(json.RootElement.TryGetProperty(modelType == typeof(ConnectionMonitorQueryResult) ? "sourceStatus" : "avgLatencyInMs", out _), Is.True);
        }

        private static void AssertSnapshot(ConnectionStateSnapshot snapshot)
        {
            Assert.That(snapshot.NetworkConnectionState.ToString(), Is.EqualTo("future-state"));
            Assert.That(snapshot.StartOn, Is.EqualTo(Start));
            Assert.That(snapshot.StartOn.Value.UtcTicks, Is.EqualTo(Start.UtcTicks));
            Assert.That(snapshot.EndOn, Is.EqualTo(Start.AddMinutes(5)));
            Assert.That(snapshot.EvaluationState.ToString(), Is.EqualTo("future-evaluation"));
            Assert.That(snapshot.AvgLatencyInMs, Is.EqualTo(3000000001));
            Assert.That(snapshot.MinLatencyInMs, Is.EqualTo(3000000000));
            Assert.That(snapshot.MaxLatencyInMs, Is.EqualTo(3000000002));
            Assert.That(snapshot.ProbesSent, Is.EqualTo(10000000000));
            Assert.That(snapshot.ProbesFailed, Is.EqualTo(3000000003));
            Assert.That(snapshot.Hops, Has.Count.EqualTo(1));
            Assert.That(snapshot.Hops[0].Id, Is.EqualTo("hop-1"));
        }
    }
}
