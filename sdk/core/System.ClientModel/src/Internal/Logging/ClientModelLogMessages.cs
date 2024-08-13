// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Internal;

internal static partial class ClientModelLogMessages
{
    private const int RequestEvent = 1;
    private const int RequestContentEvent = 2;
    private const int ResponseEvent = 5;
    private const int ResponseContentEvent = 6;
    private const int ResponseDelayEvent = 7;
    private const int ErrorResponseEvent = 8;
    private const int ErrorResponseContentEvent = 9;
    private const int RequestRetryingEvent = 10;
    private const int ResponseContentBlockEvent = 11;
    private const int ErrorResponseContentBlockEvent = 12;
    private const int ResponseContentTextEvent = 13;
    private const int ErrorResponseContentTextEvent = 14;
    private const int ResponseContentTextBlockEvent = 15;
    private const int ErrorResponseContentTextBlockEvent = 16;
    private const int RequestContentTextEvent = 17;
    private const int ExceptionResponseEvent = 18;

    [LoggerMessage(RequestEvent, LogLevel.Information, "Request [{requestId}] {method} {uri}\r\n{headers}client assembly: {clientAssembly}", EventName = "Request")]
    public static partial void Request(ILogger logger, string requestId, string method, string uri, string headers, string? clientAssembly);

    [LoggerMessage(RequestContentEvent, LogLevel.Debug, "Request [{requestId}] content: {content}", EventName = "RequestContent")]
    public static partial void RequestContent(ILogger logger, string requestId, byte[] content);

    [LoggerMessage(RequestContentTextEvent, LogLevel.Debug, "Request [{requestId}] content: {content}", EventName = "RequestContentText")]
    public static partial void RequestContentText(ILogger logger, string requestId, string content);

    [LoggerMessage(ResponseEvent, LogLevel.Information, "Response [{requestId}] {status} {reasonPhrase} ({seconds:00.0}s)\r\n{headers}", EventName = "Response")]
    public static partial void Response(ILogger logger, string requestId, int status, string reasonPhrase, string headers, double seconds);

    [LoggerMessage(ResponseContentEvent, LogLevel.Debug, "Response [{requestId}] content: {content}", EventName = "ResponseContent")]
    public static partial void ResponseContent(ILogger logger, string requestId, byte[] content);

    [LoggerMessage(ResponseContentTextEvent, LogLevel.Debug, "Response [{requestId}] content: {content}", EventName = "ResponseContentText")]
    public static partial void ResponseContentText(ILogger logger, string requestId, string content);

    [LoggerMessage(ResponseContentBlockEvent, LogLevel.Debug, "Response [{requestId}] content block {blockNumber}: {content}", EventName = "ResponseContentBlock")]
    public static partial void ResponseContentBlock(ILogger logger, string requestId, int blockNumber, byte[] content);

    [LoggerMessage(ResponseContentTextBlockEvent, LogLevel.Debug, "Response [{requestId}] content block {blockNumber}: {content}", EventName = "ResponseContentTextBlock")]
    public static partial void ResponseContentTextBlock(ILogger logger, string requestId, int blockNumber, string content);

    [LoggerMessage(ErrorResponseEvent, LogLevel.Warning, "Error response [{requestId}] {status} {reasonPhrase} ({seconds:00.0}s)\r\n{headers}", EventName = "ErrorResponse")]
    public static partial void ErrorResponse(ILogger logger, string requestId, int status, string reasonPhrase, string headers, double seconds);

    [LoggerMessage(ErrorResponseContentEvent, LogLevel.Information, "Error response [{requestId}] content: {content}", EventName = "ErrorResponseContent")]
    public static partial void ErrorResponseContent(ILogger logger, string requestId, byte[] content);

    [LoggerMessage(ErrorResponseContentTextEvent, LogLevel.Information, "Error response [{requestId}] content: {content}", EventName = "ErrorResponseContentText")]
    public static partial void ErrorResponseContentText(ILogger logger, string requestId, string content);

    [LoggerMessage(ErrorResponseContentBlockEvent, LogLevel.Information, "Error response [{requestId}] content block {blockNumber}: {content}", EventName = "ErrorResponseContentBlock")]
    public static partial void ErrorResponseContentBlock(ILogger logger, string requestId, int blockNumber, byte[] content);

    [LoggerMessage(ErrorResponseContentTextBlockEvent, LogLevel.Information, "Error response [{requestId}] content block {blockNumber}: {content}", EventName = "ErrorResponseContentTextBlock")]
    public static partial void ErrorResponseContentTextBlock(ILogger logger, string requestId, int blockNumber, string content);

    [LoggerMessage(RequestRetryingEvent, LogLevel.Information, "Request [{requestId}] attempt number {retryCount} took {seconds:00.0}s", EventName = "RequestRetrying")]
    public static partial void RequestRetrying(ILogger logger, string requestId, int retryCount, double seconds);

    [LoggerMessage(ResponseDelayEvent, LogLevel.Warning, "Response [{requestId}] took {seconds:00.0}s", EventName = "ResponseDelay")]
    public static partial void ResponseDelay(ILogger logger, string requestId, double seconds);

    [LoggerMessage(ExceptionResponseEvent, LogLevel.Information, "Request [{requestId}] exception occurred.", EventName = "ExceptionResponse")]
    public static partial void ExceptionResponse(ILogger logger, string requestId, Exception exception);
}
