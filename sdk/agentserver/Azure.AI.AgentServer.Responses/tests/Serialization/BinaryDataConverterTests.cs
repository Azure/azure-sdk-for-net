// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Internal;

namespace Azure.AI.AgentServer.Responses.Tests.Serialization;

/// <summary>
/// Tests for <see cref="BinaryDataConverter"/>, the JSON converter that preserves
/// raw JSON during <see cref="BinaryData"/> serialization and deserialization.
/// </summary>
public class BinaryDataConverterTests
{
    private readonly JsonSerializerOptions _options;

    public BinaryDataConverterTests()
    {
        _options = new JsonSerializerOptions();
        _options.Converters.Add(new BinaryDataConverter());
    }

    // ── Read (deserialization) ─────────────────────────────────────────

    [Test]
    public void Read_StringValue_PreservesJsonString()
    {
        var json = @"""hello world""";
        var result = JsonSerializer.Deserialize<BinaryData>(json, _options);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.ToString(), Is.EqualTo(@"""hello world"""));
    }

    [Test]
    public void Read_NumberValue_PreservesRawText()
    {
        var result = JsonSerializer.Deserialize<BinaryData>("42", _options);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.ToString(), Is.EqualTo("42"));
    }

    [Test]
    public void Read_BooleanValue_PreservesRawText()
    {
        var result = JsonSerializer.Deserialize<BinaryData>("true", _options);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.ToString(), Is.EqualTo("true"));
    }

    [Test]
    public void Read_NullValue_ReturnsNull()
    {
        // System.Text.Json returns null for JSON null with reference types
        var result = JsonSerializer.Deserialize<BinaryData>("null", _options);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void Read_ObjectValue_PreservesFullJson()
    {
        var json = @"{""name"":""test"",""value"":123}";
        var result = JsonSerializer.Deserialize<BinaryData>(json, _options);

        Assert.That(result, Is.Not.Null);
        using var doc = JsonDocument.Parse(result!.ToString());
        Assert.That(doc.RootElement.GetProperty("name").GetString(), Is.EqualTo("test"));
        Assert.That(doc.RootElement.GetProperty("value").GetInt32(), Is.EqualTo(123));
    }

    [Test]
    public void Read_ArrayValue_PreservesFullJson()
    {
        var json = @"[1,2,3]";
        var result = JsonSerializer.Deserialize<BinaryData>(json, _options);

        Assert.That(result, Is.Not.Null);
        using var doc = JsonDocument.Parse(result!.ToString());
        Assert.That(doc.RootElement.GetArrayLength(), Is.EqualTo(3));
    }

    [Test]
    public void Read_NestedObject_PreservesStructure()
    {
        var json = @"{""outer"":{""inner"":""value""}}";
        var result = JsonSerializer.Deserialize<BinaryData>(json, _options);

        Assert.That(result, Is.Not.Null);
        using var doc = JsonDocument.Parse(result!.ToString());
        Assert.That(
            doc.RootElement.GetProperty("outer").GetProperty("inner").GetString(),
            Is.EqualTo("value"));
    }

    // ── Write (serialization) ──────────────────────────────────────────

    [Test]
    public void Write_StringBinaryData_WritesRawJson()
    {
        var data = BinaryData.FromString(@"""hello""");
        var json = JsonSerializer.Serialize(data, _options);

        Assert.That(json, Is.EqualTo(@"""hello"""));
    }

    [Test]
    public void Write_ObjectBinaryData_WritesRawJson()
    {
        var data = BinaryData.FromString(@"{""key"":""value""}");
        var json = JsonSerializer.Serialize(data, _options);

        Assert.That(json, Is.EqualTo(@"{""key"":""value""}"));
    }

    [Test]
    public void Write_NullBinaryData_WritesJsonNull()
    {
        BinaryData? data = null;
        var json = JsonSerializer.Serialize(data, _options);

        Assert.That(json, Is.EqualTo("null"));
    }

    [Test]
    public void Write_ArrayBinaryData_WritesRawJson()
    {
        var data = BinaryData.FromString("[1,2,3]");
        var json = JsonSerializer.Serialize(data, _options);

        Assert.That(json, Is.EqualTo("[1,2,3]"));
    }

    // ── Round-trip ─────────────────────────────────────────────────────

    [Test]
    public void RoundTrip_Object_PreservesAllProperties()
    {
        var original = @"{""id"":""test_123"",""nested"":{""arr"":[1,true,null]}}";
        var data = BinaryData.FromString(original);

        var serialized = JsonSerializer.Serialize(data, _options);
        var deserialized = JsonSerializer.Deserialize<BinaryData>(serialized, _options);

        Assert.That(deserialized, Is.Not.Null);
        Assert.That(deserialized!.ToString(), Is.EqualTo(original));
    }

    [Test]
    public void RoundTrip_WithinHostObject_PreservesBinaryDataField()
    {
        // Simulate a model class with a BinaryData property serialized within
        // a larger JSON object
        var wrapper = new { toolChoice = BinaryData.FromString(@"""auto""") };
        var json = JsonSerializer.Serialize(wrapper, _options);
        Assert.That(json, Does.Contain(@"""auto"""));

        using var doc = JsonDocument.Parse(json);
        Assert.That(doc.RootElement.GetProperty("toolChoice").GetString(), Is.EqualTo("auto"));
    }
}
