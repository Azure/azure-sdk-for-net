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

    private static Models.Response CreateTestResponse(
        string id = "resp_test123",
        string model = "gpt-4o",
        ResponseStatus status = ResponseStatus.Completed)
    {
        return new Models.Response(id, model)
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
        Assert.IsTrue(factory.CanConvert(typeof(Models.Response)));
    }

    [Test]
    public void CanConvert_CreateResponse_ReturnsTrue()
    {
        var factory = new TypeSpecModelConverterFactory();
        Assert.IsTrue(factory.CanConvert(typeof(CreateResponse)));
    }

    [Test]
    public void CanConvert_ResponseStreamEvent_ReturnsTrue()
    {
        var factory = new TypeSpecModelConverterFactory();
        Assert.IsTrue(factory.CanConvert(typeof(ResponseStreamEvent)));
    }

    [Test]
    public void CanConvert_ResponseCreatedEvent_ReturnsTrue()
    {
        var factory = new TypeSpecModelConverterFactory();
        Assert.IsTrue(factory.CanConvert(typeof(ResponseCreatedEvent)));
    }

    [Test]
    public void CanConvert_String_ReturnsFalse()
    {
        var factory = new TypeSpecModelConverterFactory();
        Assert.IsFalse(factory.CanConvert(typeof(string)));
    }

    [Test]
    public void CanConvert_Int_ReturnsFalse()
    {
        var factory = new TypeSpecModelConverterFactory();
        Assert.IsFalse(factory.CanConvert(typeof(int)));
    }

    [Test]
    public void CanConvert_PlainObject_ReturnsFalse()
    {
        var factory = new TypeSpecModelConverterFactory();
        Assert.IsFalse(factory.CanConvert(typeof(object)));
    }

    // --- Serialization ---

    [Test]
    public void Serialize_Response_ProducesSnakeCaseJson()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();

        var json = JsonSerializer.Serialize(response, options);
        using var doc = JsonDocument.Parse(json);

        Assert.AreEqual("resp_test123", doc.RootElement.GetProperty("id").GetString());
        Assert.AreEqual("response", doc.RootElement.GetProperty("object").GetString());
        Assert.AreEqual("gpt-4o", doc.RootElement.GetProperty("model").GetString());
        Assert.AreEqual("completed", doc.RootElement.GetProperty("status").GetString());
    }

    [Test]
    public void Serialize_Response_ContainsCreatedAtAsUnixTimestamp()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();

        var json = JsonSerializer.Serialize(response, options);
        using var doc = JsonDocument.Parse(json);

        // TypeSpec serializes DateTimeOffset as Unix timestamp (long)
        Assert.IsTrue(doc.RootElement.TryGetProperty("created_at", out var createdAt));
        Assert.IsTrue(createdAt.ValueKind == JsonValueKind.Number);
    }

    [Test]
    public void Serialize_ResponseError_ProducesCorrectStructure()
    {
        var options = CreateOptions();
        var error = new Models.ResponseError(ResponseErrorCode.ServerError, "Something went wrong");

        var json = JsonSerializer.Serialize(error, options);
        using var doc = JsonDocument.Parse(json);

        Assert.AreEqual("server_error", doc.RootElement.GetProperty("code").GetString());
        Assert.AreEqual("Something went wrong", doc.RootElement.GetProperty("message").GetString());
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

        Assert.AreEqual("u123", doc.RootElement.GetProperty("user_id").GetString());
        Assert.AreEqual("s456", doc.RootElement.GetProperty("session").GetString());
    }

    [Test]
    public void Serialize_NullValue_WritesJsonNull()
    {
        var options = CreateOptions();
        Models.Response? nullResponse = null;

        var json = JsonSerializer.Serialize(nullResponse, options);

        Assert.AreEqual("null", json);
    }

    // --- Deserialization ---

    [Test]
    public void Deserialize_Response_PreservesProperties()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();

        var json = JsonSerializer.Serialize(response, options);
        var deserialized = JsonSerializer.Deserialize<Models.Response>(json, options);

        Assert.IsNotNull(deserialized);
        Assert.AreEqual("resp_test123", deserialized!.Id);
        Assert.AreEqual("gpt-4o", deserialized.Model);
        Assert.AreEqual(ResponseStatus.Completed, deserialized.Status);
    }

    [Test]
    public void Deserialize_ResponseError_PreservesCodeAndMessage()
    {
        var options = CreateOptions();
        var error = new Models.ResponseError(ResponseErrorCode.ServerError, "test error");

        var json = JsonSerializer.Serialize(error, options);
        var deserialized = JsonSerializer.Deserialize<Models.ResponseError>(json, options);

        Assert.IsNotNull(deserialized);
        Assert.AreEqual(ResponseErrorCode.ServerError, deserialized!.Code);
        Assert.AreEqual("test error", deserialized.Message);
    }

    [Test]
    public void Deserialize_NullJsonToken_ReturnsNull()
    {
        var options = CreateOptions();
        var result = JsonSerializer.Deserialize<Models.Response>("null", options);
        Assert.IsNull(result);
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

        Assert.IsNotNull(request);
        Assert.AreEqual("gpt-4o", request!.Model);
        Assert.AreEqual("You are a helpful assistant.", request.Instructions);
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

        Assert.IsNotNull(deserialized);
        XAssert.IsType<ResponseCreatedEvent>(deserialized);
        var created = (ResponseCreatedEvent)deserialized!;
        Assert.AreEqual(42, created.SequenceNumber);
        Assert.AreEqual("resp_test123", created.Response.Id);
    }

    [Test]
    public void Deserialize_ResponseStreamEvent_ResolvesCompletedEvent()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();
        var evt = new ResponseCompletedEvent(99, response);

        var json = JsonSerializer.Serialize<ResponseStreamEvent>(evt, options);
        var deserialized = JsonSerializer.Deserialize<ResponseStreamEvent>(json, options);

        Assert.IsNotNull(deserialized);
        XAssert.IsType<ResponseCompletedEvent>(deserialized);
        var completed = (ResponseCompletedEvent)deserialized!;
        Assert.AreEqual(99, completed.SequenceNumber);
    }

    // --- Round-trip ---

    [Test]
    public void RoundTrip_Response_PreservesAllSetFields()
    {
        var options = CreateOptions();
        var original = new Models.Response("resp_roundtrip", "gpt-4o-mini")
        {
            Status = ResponseStatus.Failed,
            Error = new Models.ResponseError(ResponseErrorCode.InvalidPrompt, "bad prompt"),
            CreatedAt = new DateTimeOffset(2026, 1, 15, 8, 30, 0, TimeSpan.Zero),
        };

        var json = JsonSerializer.Serialize(original, options);
        var restored = JsonSerializer.Deserialize<Models.Response>(json, options);

        Assert.IsNotNull(restored);
        Assert.AreEqual(original.Id, restored!.Id);
        Assert.AreEqual(original.Model, restored.Model);
        Assert.AreEqual(original.Status, restored.Status);
        Assert.AreEqual(original.Error?.Code, restored.Error?.Code);
        Assert.AreEqual(original.Error?.Message, restored.Error?.Message);
    }

    [Test]
    public void RoundTrip_ResponseCreatedEvent_PreservesResponseAndSequenceNumber()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();
        var original = new ResponseCreatedEvent(7, response);

        var json = JsonSerializer.Serialize(original, options);
        var restored = JsonSerializer.Deserialize<ResponseCreatedEvent>(json, options);

        Assert.IsNotNull(restored);
        Assert.AreEqual(7, restored!.SequenceNumber);
        Assert.AreEqual(response.Id, restored.Response.Id);
        Assert.AreEqual(response.Model, restored.Response.Model);
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

        Assert.IsNotNull(restored);
        Assert.AreEqual("value1", restored!.AdditionalProperties["key1"]);
        Assert.AreEqual("value2", restored.AdditionalProperties["key2"]);
    }

    [Test]
    public void CreateConverter_CachesTypeChecks()
    {
        // Verify that multiple CanConvert calls for the same type are consistent
        var factory = new TypeSpecModelConverterFactory();

        var first = factory.CanConvert(typeof(Models.Response));
        var second = factory.CanConvert(typeof(Models.Response));

        Assert.AreEqual(first, second);
        Assert.IsTrue(first);
    }
}
