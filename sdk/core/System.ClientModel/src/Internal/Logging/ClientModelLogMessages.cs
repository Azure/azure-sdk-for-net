// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Internal;

// The methods in this class should only ever be called from LoggingHandler
internal partial class ClientModelLogMessages
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

    private ILogger _logger;
    public ClientModelLogMessages(ILogger logger)
    {
        _logger = logger;
    }

    [LoggerMessage(RequestEvent, LogLevel.Information, "Request [{requestId}] {method} {uri}\r\n{headers}client assembly: {clientAssembly}", EventName = "Request")]
    public partial void Request(string requestId, string method, string uri, string headers, string? clientAssembly);

    [LoggerMessage(RequestContentEvent, LogLevel.Debug, "Request [{requestId}] content: {content}", EventName = "RequestContent")]
    public partial void RequestContent(string requestId, byte[] content);

    [LoggerMessage(RequestContentTextEvent, LogLevel.Debug, "Request [{requestId}] content: {content}", EventName = "RequestContentText")]
    public partial void RequestContentText(string requestId, string content);

    [LoggerMessage(ResponseEvent, LogLevel.Information, "Response [{requestId}] {status} {reasonPhrase} ({seconds:00.0}s)\r\n{headers}", EventName = "Response")]
    public partial void Response(string requestId, int status, string reasonPhrase, string headers, double seconds);

    [LoggerMessage(ResponseContentEvent, LogLevel.Debug, "Response [{requestId}] content: {content}", EventName = "ResponseContent")]
    public partial void ResponseContent(string requestId, byte[] content);

    [LoggerMessage(ResponseContentTextEvent, LogLevel.Debug, "Response [{requestId}] content: {content}", EventName = "ResponseContentText")]
    public partial void ResponseContentText(string requestId, string content);

    [LoggerMessage(ResponseContentBlockEvent, LogLevel.Debug, "Response [{requestId}] content block {blockNumber}: {content}", EventName = "ResponseContentBlock")]
    public partial void ResponseContentBlock(string requestId, int blockNumber, byte[] content);

    [LoggerMessage(ResponseContentTextBlockEvent, LogLevel.Debug, "Response [{requestId}] content block {blockNumber}: {content}", EventName = "ResponseContentTextBlock")]
    public partial void ResponseContentTextBlock(string requestId, int blockNumber, string content);

    [LoggerMessage(ErrorResponseEvent, LogLevel.Warning, "Error response [{requestId}] {status} {reasonPhrase} ({seconds:00.0}s)\r\n{headers}", EventName = "ErrorResponse")]
    public partial void ErrorResponse(string requestId, int status, string reasonPhrase, string headers, double seconds);

    [LoggerMessage(ErrorResponseContentEvent, LogLevel.Information, "Error response [{requestId}] content: {content}", EventName = "ErrorResponseContent")]
    public partial void ErrorResponseContent(string requestId, byte[] content);

    [LoggerMessage(ErrorResponseContentTextEvent, LogLevel.Information, "Error response [{requestId}] content: {content}", EventName = "ErrorResponseContentText")]
    public partial void ErrorResponseContentText(string requestId, string content);

    [LoggerMessage(ErrorResponseContentBlockEvent, LogLevel.Information, "Error response [{requestId}] content block {blockNumber}: {content}", EventName = "ErrorResponseContentBlock")]
    public partial void ErrorResponseContentBlock(string requestId, int blockNumber, byte[] content);

    [LoggerMessage(ErrorResponseContentTextBlockEvent, LogLevel.Information, "Error response [{requestId}] content block {blockNumber}: {content}", EventName = "ErrorResponseContentTextBlock")]
    public partial void ErrorResponseContentTextBlock(string requestId, int blockNumber, string content);

    [LoggerMessage(RequestRetryingEvent, LogLevel.Information, "Request [{requestId}] attempt number {retryCount} took {seconds:00.0}s", EventName = "RequestRetrying")]
    public partial void RequestRetrying(string requestId, int retryCount, double seconds);

    [LoggerMessage(ResponseDelayEvent, LogLevel.Warning, "Response [{requestId}] took {seconds:00.0}s", EventName = "ResponseDelay")]
    public partial void ResponseDelay(string requestId, double seconds);

    [LoggerMessage(ExceptionResponseEvent, LogLevel.Information, "Request [{requestId}] exception occurred.", EventName = "ExceptionResponse")]
    public partial void ExceptionResponse(string requestId, Exception exception);
}
