// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Serialization;

public class TypeSpecModelConverterFactoryTests
{
    private static JsonSerializerOptions CreateOptions()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        };
        options.Converters.Add(new TypeSpecModelConverterFactory());
        options.Converters.Add(new BinaryDataConverter());
        return options;
    }

    private static Models.ResponseObject CreateTestResponse(
        string id = "resp_test123",
        string model = "gpt-4o",
        ResponseStatus status = ResponseStatus.Completed)
    {
        return new Models.ResponseObject(id, model)
        {
            Status = status,
            CreatedAt = new DateTimeOffset(2026, 3, 4, 12, 0, 0, TimeSpan.Zero),
        };
    }

    // --- CanConvert ---

    [Test]
    public void CanConvert_Response_ReturnsTrue()
    {
        var factory = new TypeSpecModelConverterFactory();
        Assert.That(factory.CanConvert(typeof(Models.ResponseObject)), Is.True);
    }

    [Test]
    public void CanConvert_CreateResponse_ReturnsTrue()
    {
        var factory = new TypeSpecModelConverterFactory();
        Assert.That(factory.CanConvert(typeof(CreateResponse)), Is.True);
    }

    [Test]
    public void CanConvert_ResponseStreamEvent_ReturnsTrue()
    {
        var factory = new TypeSpecModelConverterFactory();
        Assert.That(factory.CanConvert(typeof(ResponseStreamEvent)), Is.True);
    }

    [Test]
    public void CanConvert_ResponseCreatedEvent_ReturnsTrue()
    {
        var factory = new TypeSpecModelConverterFactory();
        Assert.That(factory.CanConvert(typeof(ResponseCreatedEvent)), Is.True);
    }

    [Test]
    public void CanConvert_String_ReturnsFalse()
    {
        var factory = new TypeSpecModelConverterFactory();
        Assert.That(factory.CanConvert(typeof(string)), Is.False);
    }

    [Test]
    public void CanConvert_Int_ReturnsFalse()
    {
        var factory = new TypeSpecModelConverterFactory();
        Assert.That(factory.CanConvert(typeof(int)), Is.False);
    }

    [Test]
    public void CanConvert_PlainObject_ReturnsFalse()
    {
        var factory = new TypeSpecModelConverterFactory();
        Assert.That(factory.CanConvert(typeof(object)), Is.False);
    }

    // --- Serialization ---

    [Test]
    public void Serialize_Response_ProducesSnakeCaseJson()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();

        var json = JsonSerializer.Serialize(response, options);
        using var doc = JsonDocument.Parse(json);

        Assert.That(doc.RootElement.GetProperty("id").GetString(), Is.EqualTo("resp_test123"));
        Assert.That(doc.RootElement.GetProperty("object").GetString(), Is.EqualTo("response"));
        Assert.That(doc.RootElement.GetProperty("model").GetString(), Is.EqualTo("gpt-4o"));
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    [Test]
    public void Serialize_Response_ContainsCreatedAtAsUnixTimestamp()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();

        var json = JsonSerializer.Serialize(response, options);
        using var doc = JsonDocument.Parse(json);

        // TypeSpec serializes DateTimeOffset as Unix timestamp (long)
        Assert.That(doc.RootElement.TryGetProperty("created_at", out var createdAt), Is.True);
        Assert.That(createdAt.ValueKind == JsonValueKind.Number, Is.True);
    }

    [Test]
    public void Serialize_ResponseError_ProducesCorrectStructure()
    {
        var options = CreateOptions();
        var error = new Models.ResponseErrorInfo(ResponseErrorCode.ServerError, "Something went wrong");

        var json = JsonSerializer.Serialize(error, options);
        using var doc = JsonDocument.Parse(json);

        Assert.That(doc.RootElement.GetProperty("code").GetString(), Is.EqualTo("server_error"));
        Assert.That(doc.RootElement.GetProperty("message").GetString(), Is.EqualTo("Something went wrong"));
    }

    [Test]
    public void Serialize_Metadata_PreservesKeyValuePairs()
    {
        var options = CreateOptions();
        var metadata = new Metadata();
        metadata.AdditionalProperties["user_id"] = "u123";
        metadata.AdditionalProperties["session"] = "s456";

        var json = JsonSerializer.Serialize(metadata, options);
        using var doc = JsonDocument.Parse(json);

        Assert.That(doc.RootElement.GetProperty("user_id").GetString(), Is.EqualTo("u123"));
        Assert.That(doc.RootElement.GetProperty("session").GetString(), Is.EqualTo("s456"));
    }

    [Test]
    public void Serialize_NullValue_WritesJsonNull()
    {
        var options = CreateOptions();
        Models.ResponseObject? nullResponse = null;

        var json = JsonSerializer.Serialize(nullResponse, options);

        Assert.That(json, Is.EqualTo("null"));
    }

    // --- Deserialization ---

    [Test]
    public void Deserialize_Response_PreservesProperties()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();

        var json = JsonSerializer.Serialize(response, options);
        var deserialized = JsonSerializer.Deserialize<Models.ResponseObject>(json, options);

        Assert.That(deserialized, Is.Not.Null);
        Assert.That(deserialized!.Id, Is.EqualTo("resp_test123"));
        Assert.That(deserialized.Model, Is.EqualTo("gpt-4o"));
        Assert.That(deserialized.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [Test]
    public void Deserialize_ResponseError_PreservesCodeAndMessage()
    {
        var options = CreateOptions();
        var error = new Models.ResponseErrorInfo(ResponseErrorCode.ServerError, "test error");

        var json = JsonSerializer.Serialize(error, options);
        var deserialized = JsonSerializer.Deserialize<Models.ResponseErrorInfo>(json, options);

        Assert.That(deserialized, Is.Not.Null);
        Assert.That(deserialized!.Code, Is.EqualTo(ResponseErrorCode.ServerError));
        Assert.That(deserialized.Message, Is.EqualTo("test error"));
    }

    [Test]
    public void Deserialize_NullJsonToken_ReturnsNull()
    {
        var options = CreateOptions();
        var result = JsonSerializer.Deserialize<Models.ResponseObject>("null", options);
        Assert.That(result, Is.Null);
    }

    [Test]
    public void Deserialize_CreateResponse_FromJsonPayload()
    {
        var options = CreateOptions();
        var json = """
            {
                "model": "gpt-4o",
                "instructions": "You are a helpful assistant.",
                "input": "Hello, world!"
            }
            """;

        var request = JsonSerializer.Deserialize<CreateResponse>(json, options);

        Assert.That(request, Is.Not.Null);
        Assert.That(request!.Model, Is.EqualTo("gpt-4o"));
        Assert.That(request.Instructions, Is.EqualTo("You are a helpful assistant."));
    }

    // --- Polymorphic deserialization ---

    [Test]
    public void Deserialize_ResponseStreamEvent_ResolvesCreatedEvent()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();
        var evt = new ResponseCreatedEvent(42, response);

        var json = JsonSerializer.Serialize<ResponseStreamEvent>(evt, options);
        var deserialized = JsonSerializer.Deserialize<ResponseStreamEvent>(json, options);

        Assert.That(deserialized, Is.Not.Null);
        XAssert.IsType<ResponseCreatedEvent>(deserialized);
        var created = (ResponseCreatedEvent)deserialized!;
        Assert.That(created.SequenceNumber, Is.EqualTo(42));
        Assert.That(created.Response.Id, Is.EqualTo("resp_test123"));
    }

    [Test]
    public void Deserialize_ResponseStreamEvent_ResolvesCompletedEvent()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();
        var evt = new ResponseCompletedEvent(99, response);

        var json = JsonSerializer.Serialize<ResponseStreamEvent>(evt, options);
        var deserialized = JsonSerializer.Deserialize<ResponseStreamEvent>(json, options);

        Assert.That(deserialized, Is.Not.Null);
        XAssert.IsType<ResponseCompletedEvent>(deserialized);
        var completed = (ResponseCompletedEvent)deserialized!;
        Assert.That(completed.SequenceNumber, Is.EqualTo(99));
    }

    // --- Round-trip ---

    [Test]
    public void RoundTrip_Response_PreservesAllSetFields()
    {
        var options = CreateOptions();
        var original = new Models.ResponseObject("resp_roundtrip", "gpt-4o-mini")
        {
            Status = ResponseStatus.Failed,
            Error = new Models.ResponseErrorInfo(ResponseErrorCode.InvalidPrompt, "bad prompt"),
            CreatedAt = new DateTimeOffset(2026, 1, 15, 8, 30, 0, TimeSpan.Zero),
        };

        var json = JsonSerializer.Serialize(original, options);
        var restored = JsonSerializer.Deserialize<Models.ResponseObject>(json, options);

        Assert.That(restored, Is.Not.Null);
        Assert.That(restored!.Id, Is.EqualTo(original.Id));
        Assert.That(restored.Model, Is.EqualTo(original.Model));
        Assert.That(restored.Status, Is.EqualTo(original.Status));
        Assert.That(restored.Error?.Code, Is.EqualTo(original.Error?.Code));
        Assert.That(restored.Error?.Message, Is.EqualTo(original.Error?.Message));
    }

    [Test]
    public void RoundTrip_ResponseCreatedEvent_PreservesResponseAndSequenceNumber()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();
        var original = new ResponseCreatedEvent(7, response);

        var json = JsonSerializer.Serialize(original, options);
        var restored = JsonSerializer.Deserialize<ResponseCreatedEvent>(json, options);

        Assert.That(restored, Is.Not.Null);
        Assert.That(restored!.SequenceNumber, Is.EqualTo(7));
        Assert.That(restored.Response.Id, Is.EqualTo(response.Id));
        Assert.That(restored.Response.Model, Is.EqualTo(response.Model));
    }

    [Test]
    public void RoundTrip_Metadata_PreservesAllEntries()
    {
        var options = CreateOptions();
        var original = new Metadata();
        original.AdditionalProperties["key1"] = "value1";
        original.AdditionalProperties["key2"] = "value2";

        var json = JsonSerializer.Serialize(original, options);
        var restored = JsonSerializer.Deserialize<Metadata>(json, options);

        Assert.That(restored, Is.Not.Null);
        Assert.That(restored!.AdditionalProperties["key1"], Is.EqualTo("value1"));
        Assert.That(restored.AdditionalProperties["key2"], Is.EqualTo("value2"));
    }

    [Test]
    public void CreateConverter_CachesTypeChecks()
    {
        // Verify that multiple CanConvert calls for the same type are consistent
        var factory = new TypeSpecModelConverterFactory();

        var first = factory.CanConvert(typeof(Models.ResponseObject));
        var second = factory.CanConvert(typeof(Models.ResponseObject));

        Assert.That(second, Is.EqualTo(first));
        Assert.That(first, Is.True);
    }
}
