// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Serialization;

/// <summary>
/// Tests for model serialization round-trips.
/// T058: CreateResponse deserialization
/// T059: Models.ResponseObject serialization
/// T060: ResponseStreamEvent serialization
/// T061: Full round-trip for all model types
/// </summary>
public class ModelRoundTripTests
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

    // ========================================
    // T058: CreateResponse Deserialization
    // ========================================

    [Test]
    public void CreateResponse_Deserialize_FullPayload()
    {
        var options = CreateOptions();
        var json = """
            {
                "model": "gpt-4o",
                "instructions": "You are a helpful assistant.",
                "input": "What is the capital of France?",
                "stream": true,
                "temperature": 0.7,
                "top_p": 0.9,
                "max_output_tokens": 1024,
                "store": true,
                "metadata": {
                    "user_id": "u123",
                    "session_id": "s456"
                }
            }
            """;

        var request = JsonSerializer.Deserialize<CreateResponse>(json, options);

        Assert.That(request, Is.Not.Null);
        Assert.That(request!.Model, Is.EqualTo("gpt-4o"));
        Assert.That(request.Instructions, Is.EqualTo("You are a helpful assistant."));
        Assert.That(request.Stream, Is.True);
        Assert.That(request.Temperature, Is.EqualTo(0.7));
        Assert.That(request.TopP, Is.EqualTo(0.9));
        Assert.That(request.MaxOutputTokens, Is.EqualTo(1024));
        Assert.That(request.Store, Is.True);
        Assert.That(request.Metadata, Is.Not.Null);
        Assert.That(request.Metadata.AdditionalProperties["user_id"], Is.EqualTo("u123"));
        Assert.That(request.Metadata.AdditionalProperties["session_id"], Is.EqualTo("s456"));
    }

    [Test]
    public void CreateResponse_Deserialize_MinimalPayload()
    {
        var options = CreateOptions();
        var json = """{ "model": "gpt-4o" }""";

        var request = JsonSerializer.Deserialize<CreateResponse>(json, options);

        Assert.That(request, Is.Not.Null);
        Assert.That(request!.Model, Is.EqualTo("gpt-4o"));
        Assert.That(request.Instructions, Is.Null);
        Assert.That(request.Stream, Is.Null);
        Assert.That(request.Temperature, Is.Null);
    }

    [Test]
    public void CreateResponse_Deserialize_WithPreviousResponseId()
    {
        var options = CreateOptions();
        var json = """
            {
                "model": "gpt-4o",
                "previous_response_id": "resp_prev123"
            }
            """;

        var request = JsonSerializer.Deserialize<CreateResponse>(json, options);

        Assert.That(request, Is.Not.Null);
        Assert.That(request!.PreviousResponseId, Is.EqualTo("resp_prev123"));
    }

    [Test]
    public void CreateResponse_Deserialize_WithBackground()
    {
        var options = CreateOptions();
        var json = """
            {
                "model": "gpt-4o",
                "background": true,
                "stream": false
            }
            """;

        var request = JsonSerializer.Deserialize<CreateResponse>(json, options);

        Assert.That(request, Is.Not.Null);
        Assert.That(request!.Background, Is.True);
        Assert.That(request.Stream, Is.False);
    }

    // ========================================
    // T059: Models.ResponseObject Serialization
    // ========================================

    [Test]
    public void Response_Serialize_ContainsRequiredFields()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();

        var json = JsonSerializer.Serialize(response, options);
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        Assert.That(root.GetProperty("id").GetString(), Is.EqualTo("resp_test123"));
        Assert.That(root.GetProperty("object").GetString(), Is.EqualTo("response"));
        Assert.That(root.GetProperty("status").GetString(), Is.EqualTo("completed"));
        Assert.That(root.GetProperty("model").GetString(), Is.EqualTo("gpt-4o"));
        Assert.That(root.TryGetProperty("created_at", out _), Is.True);
        Assert.That(root.TryGetProperty("output", out var output), Is.True);
        Assert.That(output.ValueKind, Is.EqualTo(JsonValueKind.Array));
    }

    [Test]
    public void Response_Serialize_WithError_ContainsErrorObject()
    {
        var options = CreateOptions();
        var response = new Models.ResponseObject("resp_err", "gpt-4o")
        {
            Status = ResponseStatus.Failed,
            Error = new Models.ResponseErrorInfo(ResponseErrorCode.ServerError, "Internal failure"),
            CreatedAt = new DateTimeOffset(2026, 3, 4, 12, 0, 0, TimeSpan.Zero),
        };

        var json = JsonSerializer.Serialize(response, options);
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        Assert.That(root.GetProperty("status").GetString(), Is.EqualTo("failed"));
        Assert.That(root.TryGetProperty("error", out var errorProp), Is.True);
        Assert.That(errorProp.GetProperty("code").GetString(), Is.EqualTo("server_error"));
        Assert.That(errorProp.GetProperty("message").GetString(), Is.EqualTo("Internal failure"));
    }

    [Test]
    public void Response_Serialize_WithMetadata_ContainsMetadataObject()
    {
        var options = CreateOptions();
        var metadata = new Metadata();
        metadata.AdditionalProperties["env"] = "test";

        var response = new Models.ResponseObject("resp_meta", "gpt-4o")
        {
            Status = ResponseStatus.Completed,
            Metadata = metadata,
            CreatedAt = new DateTimeOffset(2026, 3, 4, 12, 0, 0, TimeSpan.Zero),
        };

        var json = JsonSerializer.Serialize(response, options);
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        Assert.That(root.TryGetProperty("metadata", out var metaProp), Is.True);
        Assert.That(metaProp.GetProperty("env").GetString(), Is.EqualTo("test"));
    }

    [Test]
    public void Response_Serialize_InProgressStatus()
    {
        var options = CreateOptions();
        var response = CreateTestResponse(status: ResponseStatus.InProgress);

        var json = JsonSerializer.Serialize(response, options);
        using var doc = JsonDocument.Parse(json);

        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("in_progress"));
    }

    // ========================================
    // T060: ResponseStreamEvent Serialization
    // ========================================

    [Test]
    public void ResponseCreatedEvent_Serialize_HasCorrectTypeDiscriminator()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();
        var evt = new ResponseCreatedEvent(1, response);

        var json = JsonSerializer.Serialize(evt, options);
        using var doc = JsonDocument.Parse(json);

        Assert.That(doc.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.created"));
    }

    [Test]
    public void ResponseCompletedEvent_Serialize_HasCorrectTypeDiscriminator()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();
        var evt = new ResponseCompletedEvent(2, response);

        var json = JsonSerializer.Serialize(evt, options);
        using var doc = JsonDocument.Parse(json);

        Assert.That(doc.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.completed"));
    }

    [Test]
    public void ResponseIncompleteEvent_Serialize_HasCorrectTypeDiscriminator()
    {
        var options = CreateOptions();
        var response = CreateTestResponse(status: ResponseStatus.Incomplete);
        var evt = new ResponseIncompleteEvent(3, response);

        var json = JsonSerializer.Serialize(evt, options);
        using var doc = JsonDocument.Parse(json);

        Assert.That(doc.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.incomplete"));
    }

    [Test]
    public void ResponseCreatedEvent_Serialize_ContainsSequenceNumber()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();
        var evt = new ResponseCreatedEvent(42, response);

        var json = JsonSerializer.Serialize(evt, options);
        using var doc = JsonDocument.Parse(json);

        Assert.That(doc.RootElement.GetProperty("sequence_number").GetInt64(), Is.EqualTo(42));
    }

    [Test]
    public void ResponseCreatedEvent_Serialize_ContainsNestedResponse()
    {
        var options = CreateOptions();
        var response = CreateTestResponse(id: "resp_nested");
        var evt = new ResponseCreatedEvent(0, response);

        var json = JsonSerializer.Serialize(evt, options);
        using var doc = JsonDocument.Parse(json);

        Assert.That(doc.RootElement.TryGetProperty("response", out var responseProp), Is.True);
        Assert.That(responseProp.GetProperty("id").GetString(), Is.EqualTo("resp_nested"));
        Assert.That(responseProp.GetProperty("object").GetString(), Is.EqualTo("response"));
    }

    [Test]
    public void ResponseErrorEvent_Serialize_HasCorrectStructure()
    {
        var options = CreateOptions();
        var evt = new ResponseErrorEvent(
            sequenceNumber: 5,
            code: "server_error",
            message: "Something broke",
            param: null);

        var json = JsonSerializer.Serialize(evt, options);
        using var doc = JsonDocument.Parse(json);

        Assert.That(doc.RootElement.GetProperty("type").GetString(), Is.EqualTo("error"));
        Assert.That(doc.RootElement.GetProperty("sequence_number").GetInt64(), Is.EqualTo(5));
        Assert.That(doc.RootElement.GetProperty("code").GetString(), Is.EqualTo("server_error"));
        Assert.That(doc.RootElement.GetProperty("message").GetString(), Is.EqualTo("Something broke"));
    }

    // ========================================
    // T061: Full Round-Trip Tests
    // ========================================

    [Test]
    public void Response_RoundTrip_PreservesIdModelStatus()
    {
        var options = CreateOptions();
        var original = CreateTestResponse(id: "resp_rt1", model: "gpt-4o-mini", status: ResponseStatus.Failed);

        var json = JsonSerializer.Serialize(original, options);
        var restored = JsonSerializer.Deserialize<Models.ResponseObject>(json, options);

        Assert.That(restored, Is.Not.Null);
        Assert.That(restored!.Id, Is.EqualTo("resp_rt1"));
        Assert.That(restored.Model, Is.EqualTo("gpt-4o-mini"));
        Assert.That(restored.Status, Is.EqualTo(ResponseStatus.Failed));
    }

    [Test]
    public void Response_RoundTrip_WithError_PreservesError()
    {
        var options = CreateOptions();
        var original = new Models.ResponseObject("resp_err_rt", "gpt-4o")
        {
            Status = ResponseStatus.Failed,
            Error = new Models.ResponseErrorInfo(ResponseErrorCode.RateLimitExceeded, "Too many requests"),
            CreatedAt = new DateTimeOffset(2026, 3, 4, 12, 0, 0, TimeSpan.Zero),
        };

        var json = JsonSerializer.Serialize(original, options);
        var restored = JsonSerializer.Deserialize<Models.ResponseObject>(json, options);

        Assert.That(restored, Is.Not.Null);
        Assert.That(restored!.Error, Is.Not.Null);
        Assert.That(restored.Error.Code, Is.EqualTo(ResponseErrorCode.RateLimitExceeded));
        Assert.That(restored.Error.Message, Is.EqualTo("Too many requests"));
    }

    [Test]
    public void ResponseCreatedEvent_RoundTrip_PreservesAll()
    {
        var options = CreateOptions();
        var response = CreateTestResponse(id: "resp_evtrt");
        var original = new ResponseCreatedEvent(10, response);

        var json = JsonSerializer.Serialize(original, options);
        var restored = JsonSerializer.Deserialize<ResponseCreatedEvent>(json, options);

        Assert.That(restored, Is.Not.Null);
        Assert.That(restored!.SequenceNumber, Is.EqualTo(10));
        Assert.That(restored.Response.Id, Is.EqualTo("resp_evtrt"));
    }

    [Test]
    public void ResponseCompletedEvent_RoundTrip_PreservesAll()
    {
        var options = CreateOptions();
        var response = CreateTestResponse(id: "resp_comprt", status: ResponseStatus.Completed);
        var original = new ResponseCompletedEvent(20, response);

        var json = JsonSerializer.Serialize(original, options);
        var restored = JsonSerializer.Deserialize<ResponseCompletedEvent>(json, options);

        Assert.That(restored, Is.Not.Null);
        Assert.That(restored!.SequenceNumber, Is.EqualTo(20));
        Assert.That(restored.Response.Id, Is.EqualTo("resp_comprt"));
    }

    [Test]
    public void ResponseError_RoundTrip_AllErrorCodes()
    {
        var options = CreateOptions();
        var codes = new[]
        {
            ResponseErrorCode.ServerError,
            ResponseErrorCode.RateLimitExceeded,
            ResponseErrorCode.InvalidPrompt,
        };

        foreach (var code in codes)
        {
            var original = new Models.ResponseErrorInfo(code, $"Error: {code}");
            var json = JsonSerializer.Serialize(original, options);
            var restored = JsonSerializer.Deserialize<Models.ResponseErrorInfo>(json, options);

            Assert.That(restored, Is.Not.Null);
            Assert.That(restored!.Code, Is.EqualTo(code));
            Assert.That(restored.Message, Is.EqualTo($"Error: {code}"));
        }
    }

    [Test]
    public void Metadata_RoundTrip_PreservesAllEntries()
    {
        var options = CreateOptions();
        var original = new Metadata();
        original.AdditionalProperties["key1"] = "value1";
        original.AdditionalProperties["key2"] = "value2";
        original.AdditionalProperties["key3"] = "value3";

        var json = JsonSerializer.Serialize(original, options);
        var restored = JsonSerializer.Deserialize<Metadata>(json, options);

        Assert.That(restored, Is.Not.Null);
        Assert.That(restored!.AdditionalProperties.Count, Is.EqualTo(3));
        Assert.That(restored.AdditionalProperties["key1"], Is.EqualTo("value1"));
        Assert.That(restored.AdditionalProperties["key2"], Is.EqualTo("value2"));
        Assert.That(restored.AdditionalProperties["key3"], Is.EqualTo("value3"));
    }

    [Test]
    public void CreateResponse_RoundTrip_PreservesModelAndInstructions()
    {
        var options = CreateOptions();
        // Serialize a CreateResponse JSON, deserialize, re-serialize, compare
        var json = """
            {
                "model": "gpt-4o",
                "instructions": "Be concise.",
                "stream": true,
                "temperature": 0.5
            }
            """;

        var deserialized = JsonSerializer.Deserialize<CreateResponse>(json, options);
        Assert.That(deserialized, Is.Not.Null);

        var reserialized = JsonSerializer.Serialize(deserialized, options);
        var roundTripped = JsonSerializer.Deserialize<CreateResponse>(reserialized, options);

        Assert.That(roundTripped, Is.Not.Null);
        Assert.That(roundTripped!.Model, Is.EqualTo("gpt-4o"));
        Assert.That(roundTripped.Instructions, Is.EqualTo("Be concise."));
        Assert.That(roundTripped.Stream, Is.True);
        Assert.That(roundTripped.Temperature, Is.EqualTo(0.5));
    }

    [Test]
    public void ResponseStreamEvent_Polymorphic_RoundTrip_CreatedEvent()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();
        ResponseStreamEvent original = new ResponseCreatedEvent(5, response);

        // Serialize as base type
        var json = JsonSerializer.Serialize(original, original.GetType(), options);
        // Deserialize as base type — discriminator should resolve concrete type
        var restored = JsonSerializer.Deserialize<ResponseStreamEvent>(json, options);

        Assert.That(restored, Is.Not.Null);
        XAssert.IsType<ResponseCreatedEvent>(restored);
        Assert.That(((ResponseCreatedEvent)restored!).SequenceNumber, Is.EqualTo(5));
    }

    [Test]
    public void ResponseStreamEvent_Polymorphic_RoundTrip_CompletedEvent()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();
        ResponseStreamEvent original = new ResponseCompletedEvent(15, response);

        var json = JsonSerializer.Serialize(original, original.GetType(), options);
        var restored = JsonSerializer.Deserialize<ResponseStreamEvent>(json, options);

        Assert.That(restored, Is.Not.Null);
        XAssert.IsType<ResponseCompletedEvent>(restored);
        Assert.That(((ResponseCompletedEvent)restored!).SequenceNumber, Is.EqualTo(15));
    }

    [Test]
    public void DeleteResponseResult_Serialize_ProducesCorrectFields()
    {
        var options = CreateOptions();
        var result = new DeleteResponseResult("resp_del123");

        var json = JsonSerializer.Serialize(result, options);
        using var doc = JsonDocument.Parse(json);

        Assert.That(doc.RootElement.GetProperty("id").GetString(), Is.EqualTo("resp_del123"));
        Assert.That(doc.RootElement.GetProperty("deleted").GetBoolean(), Is.True);
        Assert.That(doc.RootElement.GetProperty("object").GetString(), Is.EqualTo("response"),
            "DeleteResponseResult must serialize 'object': 'response'");
    }

    [Test]
    public void DeleteResponseResult_RoundTrip()
    {
        var options = CreateOptions();
        var original = new DeleteResponseResult("resp_del456");

        var json = JsonSerializer.Serialize(original, options);
        var restored = JsonSerializer.Deserialize<DeleteResponseResult>(json, options);

        Assert.That(restored, Is.Not.Null);
        Assert.That(restored!.Id, Is.EqualTo("resp_del456"));
        Assert.That(restored.Deleted, Is.True);
        Assert.That(restored.Object, Is.EqualTo("response"),
            "DeleteResponseResult.Object must round-trip as 'response'");
    }

    [Test]
    public void AgentsPagedResultOutputItem_Serialize_IncludesObjectList()
    {
        var options = CreateOptions();
        var paged = ResponsesModelFactory.AgentsPagedResultOutputItem(
            data: Array.Empty<OutputItem>(),
            hasMore: false);

        var json = JsonSerializer.Serialize(paged, options);
        using var doc = JsonDocument.Parse(json);

        Assert.That(doc.RootElement.GetProperty("object").GetString(), Is.EqualTo("list"),
            "AgentsPagedResultOutputItem must serialize 'object': 'list'");
        Assert.That(doc.RootElement.GetProperty("has_more").GetBoolean(), Is.False);
    }
}
