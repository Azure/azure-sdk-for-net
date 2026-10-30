// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Serialization;

/// <summary>
/// ApiError and ApiErrorResponse are generated from the spec. These tests pin the spec's <c>misalignment</c>
/// property, which the earlier hand-written ApiError did not model, and that the property stays off the wire
/// when it is not set.
/// </summary>
public class ApiErrorSerializationTests
{
    private const string ApiErrorResponseJson = """
        {
          "error": {
            "code": "misaligned",
            "message": "The request was blocked.",
            "param": "input",
            "type": "invalid_request_error",
            "misalignment": {
              "error_type": "potentially_unintended_data_transfer",
              "detailed_explanation": "The agent tried to send data outside the approved boundary.",
              "steer": { "message": "Use an approved destination." }
            }
          }
        }
        """;

    [Test]
    public void ApiErrorResponse_Read_PopulatesMisalignment()
    {
        var response = ReadResponse();

        var error = response.Error;
        Assert.That(error.Misalignment, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(error.Code, Is.EqualTo("misaligned"));
            Assert.That(error.Message, Is.EqualTo("The request was blocked."));
            Assert.That(error.Param, Is.EqualTo("input"));
            Assert.That(error.Type, Is.EqualTo("invalid_request_error"));
            Assert.That(error.Misalignment.ErrorType, Is.EqualTo(MisalignmentErrorType.PotentiallyUnintendedDataTransfer));
            Assert.That(error.Misalignment.DetailedExplanation, Is.EqualTo("The agent tried to send data outside the approved boundary."));
            Assert.That(error.Misalignment.Steer.Message, Is.EqualTo("Use an approved destination."));
        });
    }

    [Test]
    public void ApiErrorResponse_RoundTrip_PreservesMisalignment()
    {
        var response = ReadResponse();

        var written = ModelReaderWriter.Write(response, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default);

        Assert.That(
            JsonNode.DeepEquals(JsonNode.Parse(ApiErrorResponseJson), JsonNode.Parse(written.ToString())),
            Is.True,
            $"Expected: {ApiErrorResponseJson}{Environment.NewLine}Actual: {written}");
    }

    [Test]
    public void ApiError_Write_WithoutMisalignment_OmitsIt()
    {
        var error = new ApiError("invalid_value", "Bad input");

        using var document = JsonDocument.Parse(ModelReaderWriter.Write(error, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default));

        Assert.Multiple(() =>
        {
            Assert.That(document.RootElement.GetProperty("code").GetString(), Is.EqualTo("invalid_value"));
            Assert.That(document.RootElement.GetProperty("message").GetString(), Is.EqualTo("Bad input"));
            Assert.That(document.RootElement.TryGetProperty("misalignment", out _), Is.False);
        });
    }

    [Test]
    public void ModelFactory_ApiError_LeavesMisalignmentUnset()
    {
        var error = AgentServerResponsesModelFactory.ApiError(code: "invalid_value", message: "Bad input");

        using var document = JsonDocument.Parse(ModelReaderWriter.Write(error, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default));

        Assert.Multiple(() =>
        {
            Assert.That(error.Misalignment, Is.Null);
            Assert.That(document.RootElement.TryGetProperty("misalignment", out _), Is.False);
        });
    }

    private static ApiErrorResponse ReadResponse()
        => ModelReaderWriter.Read<ApiErrorResponse>(
            BinaryData.FromString(ApiErrorResponseJson),
            ModelReaderWriterOptions.Json,
            AzureAIAgentServerResponsesContext.Default)!;
}
