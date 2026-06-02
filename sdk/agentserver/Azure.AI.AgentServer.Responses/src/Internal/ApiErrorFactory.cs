// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Http;

using ModelFactory = Azure.AI.AgentServer.Responses.AgentServerResponsesModelFactory;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Centralized factory for converting exceptions and error data into the two
/// API-compatible error shapes:
/// <list type="bullet">
///   <item><see cref="ApiErrorResponse"/> — top-level JSON body for HTTP error responses.</item>
///   <item><see cref="ResponseErrorEvent"/> — standalone SSE <c>error</c> event (pre-creation errors).</item>
/// </list>
/// All user-facing error messages are sanitized here. Internal details are never exposed.
/// </summary>
internal static class ApiErrorFactory
{
    // --- Constants ---

    /// <summary>
    /// Safe generic message for server errors. Never expose internal details.
    /// </summary>
    internal const string GenericServerErrorMessage = "An internal server error occurred.";

    // --- Top-level JSON error responses (ApiErrorResponse) ---

    /// <summary>
    /// Creates an <see cref="IResult"/> that serializes an <see cref="ApiErrorResponse"/>
    /// with the given parameters.
    /// </summary>
    internal static ApiErrorResult CreateErrorResult(
        int statusCode,
        string type,
        string message,
        string? code = null,
        string? param = null)
    {
        var error = ModelFactory.Error(code: code, message: message, param: param, type: type);
        return new ApiErrorResult(ModelFactory.ApiErrorResponse(error), statusCode);
    }

    /// <summary>
    /// Creates an <see cref="IResult"/> for a 400 <c>invalid_request_error</c>.
    /// </summary>
    internal static ApiErrorResult InvalidRequest(string message, string? code = null, string? param = null)
        => CreateErrorResult(400, "invalid_request_error", message, code ?? "invalid_request_error", param);

    /// <summary>
    /// Creates an <see cref="IResult"/> for a 404 <c>invalid_request_error</c>.
    /// </summary>
    internal static ApiErrorResult NotFound(string message, string? code = null, string? param = null)
        => CreateErrorResult(404, "invalid_request_error", message, code ?? "invalid_request_error", param);

    /// <summary>
    /// Creates an <see cref="IResult"/> for a 500 <c>server_error</c>
    /// with the generic safe message.
    /// </summary>
    internal static ApiErrorResult ServerError()
        => CreateErrorResult(500, "server_error", GenericServerErrorMessage, code: "server_error");

    /// <summary>
    /// Creates an <see cref="IResult"/> wrapping a pre-built <see cref="ResponsesApiException"/>.
    /// </summary>
    internal static ApiErrorResult FromApiException(ResponsesApiException ex)
        => new(ModelFactory.ApiErrorResponse(ex.Error), ex.StatusCode);

    /// <summary>
    /// Creates an <see cref="IResult"/> for a <see cref="PayloadValidationException"/>
    /// with per-field detail errors.
    /// </summary>
    internal static ApiErrorResult PayloadValidation(PayloadValidationException ex)
    {
        var detailsList = new List<Models.Error>();
        foreach (var validationError in ex.Errors)
        {
            detailsList.Add(ModelFactory.Error(
                code: "invalid_value",
                message: validationError.Message,
                param: validationError.Path,
                type: "invalid_request_error"));
        }

        var topLevelError = ModelFactory.Error(
            message: ex.Message,
            type: "invalid_request_error",
            details: detailsList);

        return new ApiErrorResult(ModelFactory.ApiErrorResponse(topLevelError), 400);
    }

    // --- Standalone Error model (for ResponsesApiException construction) ---

    /// <summary>
    /// Creates a <see cref="Error"/> with <c>type: "server_error"</c>.
    /// Used when constructing <see cref="ResponsesApiException"/> to throw.
    /// </summary>
    internal static Models.Error NewServerError(string message)
        => ModelFactory.Error(code: "server_error", message: message, type: "server_error");

    /// <summary>
    /// Creates a <see cref="ResponsesApiException"/> with HTTP 500 and the
    /// generic safe server error message.
    /// </summary>
    internal static ResponsesApiException ServerException()
        => new(NewServerError(GenericServerErrorMessage), 500);

    // --- Exception → error info mapping (single source of truth) ---

    /// <summary>
    /// Core exception-to-error mapping. Returns the raw (code, message) tuple that
    /// both <see cref="ToResponseError"/> and <see cref="ToSseErrorEvent"/> use,
    /// eliminating the duplicated if-chain.
    /// <list type="bullet">
    ///   <item><see cref="ResponsesApiException"/> — preserves the structured error code and message.</item>
    ///   <item><see cref="PayloadValidationException"/> — <c>server_error</c> code with per-field detail in message.</item>
    ///   <item><see cref="BadRequestException"/> — <c>server_error</c> code with the exception message.</item>
    ///   <item><see cref="ResourceNotFoundException"/> — <c>server_error</c> code with the exception message.</item>
    ///   <item><see cref="ResponseValidationException"/> — <c>server_error</c> with generic message (details logged, never exposed).</item>
    ///   <item><see cref="OperationCanceledException"/> — <c>server_error</c> with generic message.</item>
    ///   <item>Any other <see cref="Exception"/> — <c>server_error</c> with generic message.</item>
    /// </list>
    /// </summary>
    private static (string Code, string Message) ExceptionErrorInfo(Exception exception)
    {
        if (exception is ResponsesApiException apiEx)
        {
            return (apiEx.Error.Code ?? "server_error", apiEx.Error.Message);
        }

        if (exception is PayloadValidationException payloadEx)
        {
            return ("server_error", payloadEx.Message);
        }

        if (exception is BadRequestException badReq)
        {
            return ("server_error", badReq.Message);
        }

        if (exception is ResourceNotFoundException notFound)
        {
            return ("server_error", notFound.Message);
        }

        // ResponseValidationException, OperationCanceledException, or any other exception
        // — generic server error; internal details are logged, never sent to the client.
        return ("server_error", GenericServerErrorMessage);
    }

    /// <summary>
    /// Maps any handler exception to a <see cref="ResponseErrorInfo"/> with the correct
    /// <see cref="ResponseErrorCode"/> and message.
    /// </summary>
    internal static Models.ResponseErrorInfo ToResponseError(Exception exception)
    {
        var (code, message) = ExceptionErrorInfo(exception);
        return new Models.ResponseErrorInfo(ParseResponseErrorCode(code), message);
    }

    // --- SSE standalone error event ---

    /// <summary>
    /// Creates a <see cref="ResponseErrorEvent"/> for pre-<c>response.created</c> errors
    /// that must be written as standalone SSE events.
    /// The message is sanitized — internal details are never exposed.
    /// </summary>
    internal static ResponseErrorEvent SseErrorEvent(string? safeMessage = null)
        => new(0, "server_error", safeMessage ?? GenericServerErrorMessage, null!);

    /// <summary>
    /// Maps any handler exception to a <see cref="ResponseErrorEvent"/> with the correct
    /// code and message, using the same fidelity rules as <see cref="ToResponseError"/>.
    /// </summary>
    internal static ResponseErrorEvent ToSseErrorEvent(Exception exception)
    {
        var (code, message) = ExceptionErrorInfo(exception);
        return new ResponseErrorEvent(0, code, message, null!);
    }

    // --- Helpers ---

    /// <summary>
    /// Parses a snake_case error code string to <see cref="ResponseErrorCode"/>.
    /// Since ResponseErrorCode is an extensible struct, any string value is valid.
    /// Falls back to <see cref="ResponseErrorCode.ServerError"/> for null/empty.
    /// </summary>
    private static ResponseErrorCode ParseResponseErrorCode(string? code)
    {
        if (string.IsNullOrEmpty(code))
        {
            return ResponseErrorCode.ServerError;
        }

        return new ResponseErrorCode(code);
    }
}
