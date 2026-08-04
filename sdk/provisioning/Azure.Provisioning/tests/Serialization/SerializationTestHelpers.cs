// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Serialization;

/// <summary>
/// Shared helpers for serialization tests.
/// </summary>
internal static class SerializationTestHelpers
{
    public static string SerializeToJson(Infrastructure infra)
    {
        using MemoryStream stream = new();
        using (Utf8JsonWriter writer = new(stream, new JsonWriterOptions { Indented = true }))
        {
            ((IJsonModel<Infrastructure>)infra).Write(writer, ModelReaderWriterOptions.Json);
        }
        return Encoding.UTF8.GetString(stream.ToArray());
    }

    public static Infrastructure DeserializeFromJson(string json)
    {
        Infrastructure template = new();
        IPersistableModel<Infrastructure> model = template;
        return model.Create(new BinaryData(json), ModelReaderWriterOptions.Json)!;
    }

    public static void AssertJsonRoundTrip(Infrastructure infra)
    {
        string json1 = SerializeToJson(infra);
        Assert.IsNotNull(json1);
        Assert.IsNotEmpty(json1);

        SchemaComplianceTests.AssertSchemaCompliance(json1);

        Infrastructure deserialized = DeserializeFromJson(json1);

        Assert.AreEqual(infra, deserialized, "Infrastructure round-trip deep comparison failed.");

        string json2 = SerializeToJson(deserialized);
        Assert.AreEqual(json1, json2, "JSON round-trip failed.");
    }

    public static void AssertBicepEquivalence(Infrastructure infra)
    {
        ProvisioningPlan plan1 = infra.Build();
        IDictionary<string, string> bicep1 = plan1.Compile();

        string json = SerializeToJson(infra);
        Infrastructure deserialized = DeserializeFromJson(json);

        ProvisioningPlan plan2 = deserialized.Build();
        IDictionary<string, string> bicep2 = plan2.Compile();

        Assert.AreEqual(bicep1.Count, bicep2.Count, "Module count mismatch");
        foreach (var kvp in bicep1)
        {
            Assert.IsTrue(bicep2.ContainsKey(kvp.Key), $"Missing module: {kvp.Key}");
            Assert.AreEqual(kvp.Value, bicep2[kvp.Key], $"Bicep mismatch for module {kvp.Key}");
        }
    }

    public static void AssertExpressionRoundTrip(Azure.Provisioning.Expressions.BicepExpression expr)
    {
        BinaryData json = ModelReaderWriter.Write<Azure.Provisioning.Expressions.BicepExpression>(expr, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
        Azure.Provisioning.Expressions.BicepExpression deserialized = ModelReaderWriter.Read<Azure.Provisioning.Expressions.BicepExpression>(json, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default)!;
        Assert.AreEqual(expr, deserialized, $"Round-trip failed for {expr.GetType().Name}. JSON: {json}");

        BinaryData bicep = ModelReaderWriter.Write<Azure.Provisioning.Expressions.BicepExpression>(expr, new ModelReaderWriterOptions("bicep"), AzureProvisioningContext.Default);
        Assert.IsNotEmpty(bicep.ToString(), $"Bicep output empty for {expr.GetType().Name}");
    }
}
