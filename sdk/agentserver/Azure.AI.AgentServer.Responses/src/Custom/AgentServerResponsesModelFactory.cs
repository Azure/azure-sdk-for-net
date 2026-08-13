// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// A factory class for creating instances of models used internally.
/// <para>
/// This is hand-maintained because the generated factory from tsp-output has
/// constructor parameter ordering mismatches with our customized generated models.
/// Only methods actively used by this library are included.
/// </para>
/// </summary>
internal static partial class AgentServerResponsesModelFactory
{
    /// <summary>Creates an <see cref="Models.Error"/> instance for mocking.</summary>
    /// <param name="code">The error code.</param>
    /// <param name="message">The error message.</param>
    /// <param name="param">The parameter that caused the error.</param>
    /// <param name="type">The error type.</param>
    /// <param name="details">Nested error details.</param>
    /// <param name="additionalInfo">Additional structured info.</param>
    /// <param name="debugInfo">Debug info (not exposed to callers).</param>
    /// <returns>A new <see cref="Models.Error"/> instance.</returns>
    public static Error Error(
        string? code = default,
        string? message = default,
        string? @param = default,
        string? @type = default,
        IEnumerable<Error>? details = default,
        IDictionary<string, BinaryData>? additionalInfo = default,
        IDictionary<string, BinaryData>? debugInfo = default)
    {
        details ??= new List<Error>();
        additionalInfo ??= new Dictionary<string, BinaryData>();
        debugInfo ??= new Dictionary<string, BinaryData>();

        return new Error(
            code!,
            message!,
            @param!,
            @type!,
            details.ToList(),
            additionalInfo,
            debugInfo,
            additionalBinaryDataProperties: null);
    }

    /// <summary>Creates an <see cref="Models.ApiErrorResponse"/> instance for mocking.</summary>
    /// <param name="error">The error object.</param>
    /// <returns>A new <see cref="Models.ApiErrorResponse"/> instance.</returns>
    public static ApiErrorResponse ApiErrorResponse(Error error = default!)
    {
        return new ApiErrorResponse(error, additionalBinaryDataProperties: null);
    }

    /// <summary>Creates a <see cref="Models.ResponseErrorInfo"/> instance for mocking.</summary>
    /// <param name="code">The error code.</param>
    /// <param name="message">The error message.</param>
    /// <returns>A new <see cref="Models.ResponseErrorInfo"/> instance.</returns>
    public static ResponseErrorInfo ResponseErrorInfo(
        ResponseErrorCode code = default,
        string message = default!)
    {
        return new ResponseErrorInfo(code, message, additionalBinaryDataProperties: null);
    }

    /// <summary>Creates a <see cref="Models.ResponseObject"/> instance for mocking.</summary>
    /// <param name="id">The response identifier.</param>
    /// <param name="model">The model name.</param>
    /// <param name="status">The response status.</param>
    /// <param name="createdAt">The creation timestamp.</param>
    /// <param name="error">The error, if any.</param>
    /// <param name="output">The output items.</param>
    /// <returns>A new <see cref="Models.ResponseObject"/> instance.</returns>
    public static ResponseObject ResponseObject(
        string id = default!,
        string model = default!,
        ResponseStatus? status = default,
        DateTimeOffset createdAt = default,
        ResponseErrorInfo error = default!,
        IEnumerable<OutputItem> output = default!)
    {
        output ??= new List<OutputItem>();

        return new ResponseObject(
            metadata: null,
            topLogprobs: null,
            temperature: null,
            topP: null,
            user: null,
            safetyIdentifier: null,
            promptCacheKey: null,
            serviceTier: null,
            promptCacheRetention: null,
            previousResponseId: null,
            model: model,
            reasoning: null,
            background: null,
            maxOutputTokens: null,
            maxToolCalls: null,
            text: null,
            tools: new List<Tool>(),
            toolChoice: null,
            prompt: null,
            truncation: null,
            id: id,
            @object: null,
            status: status,
            createdAt: createdAt,
            completedAt: null,
            error: error,
            incompleteDetails: null,
            output: output.ToList(),
            instructions: null,
            outputText: null,
            usage: null,
            parallelToolCalls: default,
            conversation: null,
            agent: null,
            agentSessionId: null,
            agentReference: null,
            additionalBinaryDataProperties: null);
    }

    /// <summary>Creates a <see cref="Models.ResponseCreatedEvent"/> instance for mocking.</summary>
    /// <param name="sequenceNumber">The SSE sequence number.</param>
    /// <param name="response">The response object.</param>
    /// <returns>A new <see cref="Models.ResponseCreatedEvent"/> instance.</returns>
    public static ResponseCreatedEvent ResponseCreatedEvent(
        ResponseObject response = default!,
        long sequenceNumber = default)
    {
        return new ResponseCreatedEvent(
            ResponseStreamEventType.ResponseCreated,
            sequenceNumber,
            additionalBinaryDataProperties: null,
            response: response);
    }

    /// <summary>Creates a <see cref="Models.DeleteResponseResult"/> instance for mocking.</summary>
    /// <param name="id">The ID of the deleted response.</param>
    /// <returns>A new <see cref="Models.DeleteResponseResult"/> with <c>Deleted = true</c>.</returns>
    public static DeleteResponseResult DeleteResponseResult(string id = default!)
    {
        return new DeleteResponseResult(id, true, "response", additionalBinaryDataProperties: null);
    }

    /// <summary>Creates an <see cref="Models.AgentsPagedResultOutputItem"/> instance for mocking.</summary>
    /// <param name="data">The output items in the page.</param>
    /// <param name="firstId">The ID of the first item.</param>
    /// <param name="lastId">The ID of the last item.</param>
    /// <param name="hasMore">Whether there are more items.</param>
    /// <returns>A new <see cref="Models.AgentsPagedResultOutputItem"/> instance.</returns>
    public static AgentsPagedResultOutputItem AgentsPagedResultOutputItem(
        IEnumerable<OutputItem> data = default!,
        string firstId = default!,
        string lastId = default!,
        bool hasMore = default)
    {
        data ??= new List<OutputItem>();

        return new AgentsPagedResultOutputItem(
            data.ToList(),
            firstId,
            lastId,
            hasMore,
            additionalBinaryDataProperties: null);
    }

    /// <summary>Creates a <see cref="Models.ResponseUsage"/> instance for mocking.</summary>
    /// <param name="inputTokens">The number of input tokens.</param>
    /// <param name="inputTokensDetails">A detailed breakdown of the input tokens.</param>
    /// <param name="outputTokens">The number of output tokens.</param>
    /// <param name="outputTokensDetails">A detailed breakdown of the output tokens.</param>
    /// <param name="totalTokens">The total number of tokens used.</param>
    /// <returns>A new <see cref="Models.ResponseUsage"/> instance.</returns>
    public static ResponseUsage ResponseUsage(
        long inputTokens = default,
        ResponseUsageInputTokensDetails inputTokensDetails = default!,
        long outputTokens = default,
        ResponseUsageOutputTokensDetails outputTokensDetails = default!,
        long totalTokens = default)
    {
        inputTokensDetails ??= new ResponseUsageInputTokensDetails(cachedTokens: 0);
        outputTokensDetails ??= new ResponseUsageOutputTokensDetails(reasoningTokens: 0);

        return new ResponseUsage(inputTokens, inputTokensDetails, outputTokens, outputTokensDetails, totalTokens);
    }
}
