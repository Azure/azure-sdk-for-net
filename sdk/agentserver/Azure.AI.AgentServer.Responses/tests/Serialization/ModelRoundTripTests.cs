using System.Text.Json;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Serialization;

/// <summary>
/// Tests for model serialization round-trips.
/// T058: CreateResponse deserialization
/// T059: Models.Response serialization
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

        Assert.IsNotNull(request);
        Assert.AreEqual("gpt-4o", request!.Model);
        Assert.AreEqual("You are a helpful assistant.", request.Instructions);
        Assert.IsTrue(request.Stream);
        Assert.AreEqual(0.7, request.Temperature);
        Assert.AreEqual(0.9, request.TopP);
        Assert.AreEqual(1024, request.MaxOutputTokens);
        Assert.IsTrue(request.Store);
        Assert.IsNotNull(request.Metadata);
        Assert.AreEqual("u123", request.Metadata.AdditionalProperties["user_id"]);
        Assert.AreEqual("s456", request.Metadata.AdditionalProperties["session_id"]);
    }

    [Test]
    public void CreateResponse_Deserialize_MinimalPayload()
    {
        var options = CreateOptions();
        var json = """{ "model": "gpt-4o" }""";

        var request = JsonSerializer.Deserialize<CreateResponse>(json, options);

        Assert.IsNotNull(request);
        Assert.AreEqual("gpt-4o", request!.Model);
        Assert.IsNull(request.Instructions);
        Assert.IsNull(request.Stream);
        Assert.IsNull(request.Temperature);
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

        Assert.IsNotNull(request);
        Assert.AreEqual("resp_prev123", request!.PreviousResponseId);
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

        Assert.IsNotNull(request);
        Assert.IsTrue(request!.Background);
        Assert.IsFalse(request.Stream);
    }

    // ========================================
    // T059: Models.Response Serialization
    // ========================================

    [Test]
    public void Response_Serialize_ContainsRequiredFields()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();

        var json = JsonSerializer.Serialize(response, options);
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        Assert.AreEqual("resp_test123", root.GetProperty("id").GetString());
        Assert.AreEqual("response", root.GetProperty("object").GetString());
        Assert.AreEqual("completed", root.GetProperty("status").GetString());
        Assert.AreEqual("gpt-4o", root.GetProperty("model").GetString());
        Assert.IsTrue(root.TryGetProperty("created_at", out _));
        Assert.IsTrue(root.TryGetProperty("output", out var output));
        Assert.AreEqual(JsonValueKind.Array, output.ValueKind);
    }

    [Test]
    public void Response_Serialize_WithError_ContainsErrorObject()
    {
        var options = CreateOptions();
        var response = new Models.Response("resp_err", "gpt-4o")
        {
            Status = ResponseStatus.Failed,
            Error = new Models.ResponseError(ResponseErrorCode.ServerError, "Internal failure"),
            CreatedAt = new DateTimeOffset(2026, 3, 4, 12, 0, 0, TimeSpan.Zero),
        };

        var json = JsonSerializer.Serialize(response, options);
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        Assert.AreEqual("failed", root.GetProperty("status").GetString());
        Assert.IsTrue(root.TryGetProperty("error", out var errorProp));
        Assert.AreEqual("server_error", errorProp.GetProperty("code").GetString());
        Assert.AreEqual("Internal failure", errorProp.GetProperty("message").GetString());
    }

    [Test]
    public void Response_Serialize_WithMetadata_ContainsMetadataObject()
    {
        var options = CreateOptions();
        var metadata = new Metadata();
        metadata.AdditionalProperties["env"] = "test";

        var response = new Models.Response("resp_meta", "gpt-4o")
        {
            Status = ResponseStatus.Completed,
            Metadata = metadata,
            CreatedAt = new DateTimeOffset(2026, 3, 4, 12, 0, 0, TimeSpan.Zero),
        };

        var json = JsonSerializer.Serialize(response, options);
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        Assert.IsTrue(root.TryGetProperty("metadata", out var metaProp));
        Assert.AreEqual("test", metaProp.GetProperty("env").GetString());
    }

    [Test]
    public void Response_Serialize_InProgressStatus()
    {
        var options = CreateOptions();
        var response = CreateTestResponse(status: ResponseStatus.InProgress);

        var json = JsonSerializer.Serialize(response, options);
        using var doc = JsonDocument.Parse(json);

        Assert.AreEqual("in_progress", doc.RootElement.GetProperty("status").GetString());
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

        Assert.AreEqual("response.created", doc.RootElement.GetProperty("type").GetString());
    }

    [Test]
    public void ResponseCompletedEvent_Serialize_HasCorrectTypeDiscriminator()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();
        var evt = new ResponseCompletedEvent(2, response);

        var json = JsonSerializer.Serialize(evt, options);
        using var doc = JsonDocument.Parse(json);

        Assert.AreEqual("response.completed", doc.RootElement.GetProperty("type").GetString());
    }

    [Test]
    public void ResponseIncompleteEvent_Serialize_HasCorrectTypeDiscriminator()
    {
        var options = CreateOptions();
        var response = CreateTestResponse(status: ResponseStatus.Incomplete);
        var evt = new ResponseIncompleteEvent(3, response);

        var json = JsonSerializer.Serialize(evt, options);
        using var doc = JsonDocument.Parse(json);

        Assert.AreEqual("response.incomplete", doc.RootElement.GetProperty("type").GetString());
    }

    [Test]
    public void ResponseCreatedEvent_Serialize_ContainsSequenceNumber()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();
        var evt = new ResponseCreatedEvent(42, response);

        var json = JsonSerializer.Serialize(evt, options);
        using var doc = JsonDocument.Parse(json);

        Assert.AreEqual(42, doc.RootElement.GetProperty("sequence_number").GetInt64());
    }

    [Test]
    public void ResponseCreatedEvent_Serialize_ContainsNestedResponse()
    {
        var options = CreateOptions();
        var response = CreateTestResponse(id: "resp_nested");
        var evt = new ResponseCreatedEvent(0, response);

        var json = JsonSerializer.Serialize(evt, options);
        using var doc = JsonDocument.Parse(json);

        Assert.IsTrue(doc.RootElement.TryGetProperty("response", out var responseProp));
        Assert.AreEqual("resp_nested", responseProp.GetProperty("id").GetString());
        Assert.AreEqual("response", responseProp.GetProperty("object").GetString());
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

        Assert.AreEqual("error", doc.RootElement.GetProperty("type").GetString());
        Assert.AreEqual(5, doc.RootElement.GetProperty("sequence_number").GetInt64());
        Assert.AreEqual("server_error", doc.RootElement.GetProperty("code").GetString());
        Assert.AreEqual("Something broke", doc.RootElement.GetProperty("message").GetString());
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
        var restored = JsonSerializer.Deserialize<Models.Response>(json, options);

        Assert.IsNotNull(restored);
        Assert.AreEqual("resp_rt1", restored!.Id);
        Assert.AreEqual("gpt-4o-mini", restored.Model);
        Assert.AreEqual(ResponseStatus.Failed, restored.Status);
    }

    [Test]
    public void Response_RoundTrip_WithError_PreservesError()
    {
        var options = CreateOptions();
        var original = new Models.Response("resp_err_rt", "gpt-4o")
        {
            Status = ResponseStatus.Failed,
            Error = new Models.ResponseError(ResponseErrorCode.RateLimitExceeded, "Too many requests"),
            CreatedAt = new DateTimeOffset(2026, 3, 4, 12, 0, 0, TimeSpan.Zero),
        };

        var json = JsonSerializer.Serialize(original, options);
        var restored = JsonSerializer.Deserialize<Models.Response>(json, options);

        Assert.IsNotNull(restored);
        Assert.IsNotNull(restored!.Error);
        Assert.AreEqual(ResponseErrorCode.RateLimitExceeded, restored.Error.Code);
        Assert.AreEqual("Too many requests", restored.Error.Message);
    }

    [Test]
    public void ResponseCreatedEvent_RoundTrip_PreservesAll()
    {
        var options = CreateOptions();
        var response = CreateTestResponse(id: "resp_evtrt");
        var original = new ResponseCreatedEvent(10, response);

        var json = JsonSerializer.Serialize(original, options);
        var restored = JsonSerializer.Deserialize<ResponseCreatedEvent>(json, options);

        Assert.IsNotNull(restored);
        Assert.AreEqual(10, restored!.SequenceNumber);
        Assert.AreEqual("resp_evtrt", restored.Response.Id);
    }

    [Test]
    public void ResponseCompletedEvent_RoundTrip_PreservesAll()
    {
        var options = CreateOptions();
        var response = CreateTestResponse(id: "resp_comprt", status: ResponseStatus.Completed);
        var original = new ResponseCompletedEvent(20, response);

        var json = JsonSerializer.Serialize(original, options);
        var restored = JsonSerializer.Deserialize<ResponseCompletedEvent>(json, options);

        Assert.IsNotNull(restored);
        Assert.AreEqual(20, restored!.SequenceNumber);
        Assert.AreEqual("resp_comprt", restored.Response.Id);
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
            var original = new Models.ResponseError(code, $"Error: {code}");
            var json = JsonSerializer.Serialize(original, options);
            var restored = JsonSerializer.Deserialize<Models.ResponseError>(json, options);

            Assert.IsNotNull(restored);
            Assert.AreEqual(code, restored!.Code);
            Assert.AreEqual($"Error: {code}", restored.Message);
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

        Assert.IsNotNull(restored);
        Assert.AreEqual(3, restored!.AdditionalProperties.Count);
        Assert.AreEqual("value1", restored.AdditionalProperties["key1"]);
        Assert.AreEqual("value2", restored.AdditionalProperties["key2"]);
        Assert.AreEqual("value3", restored.AdditionalProperties["key3"]);
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
        Assert.IsNotNull(deserialized);

        var reserialized = JsonSerializer.Serialize(deserialized, options);
        var roundTripped = JsonSerializer.Deserialize<CreateResponse>(reserialized, options);

        Assert.IsNotNull(roundTripped);
        Assert.AreEqual("gpt-4o", roundTripped!.Model);
        Assert.AreEqual("Be concise.", roundTripped.Instructions);
        Assert.IsTrue(roundTripped.Stream);
        Assert.AreEqual(0.5, roundTripped.Temperature);
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

        Assert.IsNotNull(restored);
        XAssert.IsType<ResponseCreatedEvent>(restored);
        Assert.AreEqual(5, ((ResponseCreatedEvent)restored!).SequenceNumber);
    }

    [Test]
    public void ResponseStreamEvent_Polymorphic_RoundTrip_CompletedEvent()
    {
        var options = CreateOptions();
        var response = CreateTestResponse();
        ResponseStreamEvent original = new ResponseCompletedEvent(15, response);

        var json = JsonSerializer.Serialize(original, original.GetType(), options);
        var restored = JsonSerializer.Deserialize<ResponseStreamEvent>(json, options);

        Assert.IsNotNull(restored);
        XAssert.IsType<ResponseCompletedEvent>(restored);
        Assert.AreEqual(15, ((ResponseCompletedEvent)restored!).SequenceNumber);
    }

    [Test]
    public void DeleteResponseResult_Serialize_ProducesCorrectFields()
    {
        var options = CreateOptions();
        var result = new DeleteResponseResult("resp_del123");

        var json = JsonSerializer.Serialize(result, options);
        using var doc = JsonDocument.Parse(json);

        Assert.AreEqual("resp_del123", doc.RootElement.GetProperty("id").GetString());
        Assert.IsTrue(doc.RootElement.GetProperty("deleted").GetBoolean());
    }

    [Test]
    public void DeleteResponseResult_RoundTrip()
    {
        var options = CreateOptions();
        var original = new DeleteResponseResult("resp_del456");

        var json = JsonSerializer.Serialize(original, options);
        var restored = JsonSerializer.Deserialize<DeleteResponseResult>(json, options);

        Assert.IsNotNull(restored);
        Assert.AreEqual("resp_del456", restored!.Id);
        Assert.IsTrue(restored.Deleted);
    }
}
