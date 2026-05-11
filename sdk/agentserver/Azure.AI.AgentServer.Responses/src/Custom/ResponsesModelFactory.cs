// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Factory for creating model instances with specific values for testing and mocking.
/// Provides a curated subset of factory methods with cleaner parameter names,
/// delegating to the internal <c>AgentServerResponsesModelFactory</c>.
/// </summary>
/// <remarks>
/// Most model types now have public constructors (via @@usage) and can be
/// constructed directly. This factory is primarily useful for types where
/// all-defaults construction is convenient for tests.
/// </remarks>
public static class ResponsesModelFactory
{
    /// <summary>Creates a <see cref="Models.ResponseObject"/> instance for mocking.</summary>
    /// <param name="id">The unique response identifier.</param>
    /// <param name="model">The model name (e.g. "gpt-4o").</param>
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
        return AgentServerResponsesModelFactory.ResponseObject(
            id: id,
            model: model,
            status: status,
            createdAt: createdAt,
            error: error,
            output: output);
    }

    /// <summary>Creates a <see cref="Models.ResponseErrorInfo"/> instance for mocking.</summary>
    /// <param name="code">The error code.</param>
    /// <param name="message">The error message.</param>
    /// <returns>A new <see cref="Models.ResponseErrorInfo"/> instance.</returns>
    public static ResponseErrorInfo ResponseErrorInfo(
        ResponseErrorCode code = default,
        string message = default!)
    {
        return AgentServerResponsesModelFactory.ResponseErrorInfo(
            code: code,
            message: message);
    }

    /// <summary>Creates a <see cref="Models.ResponseCreatedEvent"/> instance for mocking.</summary>
    /// <param name="response">The response object.</param>
    /// <param name="sequenceNumber">The SSE sequence number.</param>
    /// <returns>A new <see cref="Models.ResponseCreatedEvent"/> instance.</returns>
    public static ResponseCreatedEvent ResponseCreatedEvent(
        ResponseObject response = default!,
        long sequenceNumber = default)
    {
        return AgentServerResponsesModelFactory.ResponseCreatedEvent(
            response: response,
            sequenceNumber: sequenceNumber);
    }

    /// <summary>Creates a <see cref="Models.DeleteResponseResult"/> instance for mocking.</summary>
    /// <param name="id">The ID of the deleted response.</param>
    /// <returns>A new <see cref="Models.DeleteResponseResult"/> instance with <c>Deleted</c> set to <c>true</c>.</returns>
    public static DeleteResponseResult DeleteResponseResult(
        string id = default!)
    {
        return AgentServerResponsesModelFactory.DeleteResponseResult(id: id);
    }

    /// <summary>Creates an <see cref="Models.AgentsPagedResultOutputItem"/> instance for mocking.</summary>
    /// <param name="data">The output items in the page.</param>
    /// <param name="firstId">The ID of the first item in the page.</param>
    /// <param name="lastId">The ID of the last item in the page.</param>
    /// <param name="hasMore">Whether there are more items available.</param>
    /// <returns>A new <see cref="Models.AgentsPagedResultOutputItem"/> instance.</returns>
    public static AgentsPagedResultOutputItem AgentsPagedResultOutputItem(
        IEnumerable<OutputItem> data = default!,
        string firstId = default!,
        string lastId = default!,
        bool hasMore = default)
    {
        return AgentServerResponsesModelFactory.AgentsPagedResultOutputItem(
            data: data,
            firstId: firstId,
            lastId: lastId,
            hasMore: hasMore);
    }
}
