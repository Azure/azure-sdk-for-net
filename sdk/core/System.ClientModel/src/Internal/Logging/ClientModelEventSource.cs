// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Text;

namespace System.ClientModel.Internal;

// The methods in this class should only ever be called from LoggingHandler
[EventSource(Name = "System-ClientModel")]
internal sealed class ClientModelEventSource : EventSource
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

    private ClientModelEventSource(string eventSourceName, string[]? traits = default) : base(eventSourceName, EventSourceSettings.Default, traits) { }

    public static ClientModelEventSource Log = new("System-ClientModel");

    [Event(RequestEvent, Level = EventLevel.Informational, Message = "Request [{0}] {1} {2}\r\n{3}client assembly: {4}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with primitive types.")]
    public void Request(string? requestId, string method, string uri, string headers, string? clientAssembly)
    {
        WriteEvent(RequestEvent, requestId, method, uri, headers, clientAssembly);
    }

    [Event(RequestContentEvent, Level = EventLevel.Verbose, Message = "Request [{0}] content: {1}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with an array with primitive type elements.")]
    public void RequestContent(string? requestId, byte[] content)
    {
        WriteEvent(RequestContentEvent, requestId, content);
    }

    [Event(RequestContentTextEvent, Level = EventLevel.Verbose, Message = "Request [{0}] content: {1}")]
    public void RequestContentText(string? requestId, string content)
    {
        WriteEvent(RequestContentTextEvent, requestId, content);
    }

    [Event(ResponseEvent, Level = EventLevel.Informational, Message = "Response [{0}] {1} {2} ({4:00.0}s)\r\n{3}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with primitive types.")]
    public void Response(string? requestId, int status, string reasonPhrase, string headers, double seconds)
    {
        WriteEvent(ResponseEvent, requestId, status, reasonPhrase, headers, seconds);
    }

    [Event(ResponseContentEvent, Level = EventLevel.Verbose, Message = "Response [{0}] content: {1}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with an array with primitive type elements.")]
    public void ResponseContent(string? requestId, byte[] content)
    {
        WriteEvent(ResponseContentEvent, requestId, content);
    }

    [Event(ResponseContentTextEvent, Level = EventLevel.Verbose, Message = "Response [{0}] content: {1}")]
    public void ResponseContentText(string? requestId, string content)
    {
        WriteEvent(ResponseContentTextEvent, requestId, content);
    }

    [Event(ResponseContentBlockEvent, Level = EventLevel.Verbose, Message = "Response [{0}] content block {1}: {2}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with an array with primitive type elements.")]
    public void ResponseContentBlock(string? requestId, int blockNumber, byte[] content)
    {
        WriteEvent(ResponseContentBlockEvent, requestId, blockNumber, content);
    }

    [Event(ResponseContentTextBlockEvent, Level = EventLevel.Verbose, Message = "Response [{0}] content block {1}: {2}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with primitive types.")]
    public void ResponseContentTextBlock(string? requestId, int blockNumber, string content)
    {
        WriteEvent(ResponseContentTextBlockEvent, requestId, blockNumber, content);
    }

    [Event(ErrorResponseEvent, Level = EventLevel.Warning, Message = "Error response [{0}] {1} {2} ({4:00.0}s)\r\n{3}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with primitive types.")]
    public void ErrorResponse(string? requestId, int status, string reasonPhrase, string headers, double seconds)
    {
        WriteEvent(ErrorResponseEvent, requestId, status, reasonPhrase, headers, seconds);
    }

    [Event(ErrorResponseContentEvent, Level = EventLevel.Informational, Message = "Error response [{0}] content: {1}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with an array with primitive type elements.")]
    public void ErrorResponseContent(string? requestId, byte[] content)
    {
        WriteEvent(ErrorResponseContentEvent, requestId, content);
    }

    [Event(ErrorResponseContentTextEvent, Level = EventLevel.Informational, Message = "Error response [{0}] content: {1}")]
    public void ErrorResponseContentText(string? requestId, string content)
    {
        WriteEvent(ErrorResponseContentTextEvent, requestId, content);
    }

    [Event(ErrorResponseContentBlockEvent, Level = EventLevel.Informational, Message = "Error response [{0}] content block {1}: {2}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with an array with primitive type elements.")]
    public void ErrorResponseContentBlock(string? requestId, int blockNumber, byte[] content)
    {
        WriteEvent(ErrorResponseContentBlockEvent, requestId, blockNumber, content);
    }

    [Event(ErrorResponseContentTextBlockEvent, Level = EventLevel.Informational, Message = "Error response [{0}] content block {1}: {2}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with primitive types.")]
    public void ErrorResponseContentTextBlock(string? requestId, int blockNumber, string content)
    {
        WriteEvent(ErrorResponseContentTextBlockEvent, requestId, blockNumber, content);
    }

    [Event(RequestRetryingEvent, Level = EventLevel.Informational, Message = "Request [{0}] attempt number {1} took {2:00.0}s")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with primitive types.")]
    public void RequestRetrying(string? requestId, int retryNumber, double seconds)
    {
        WriteEvent(RequestRetryingEvent, requestId, retryNumber, seconds);
    }

    [Event(ResponseDelayEvent, Level = EventLevel.Warning, Message = "Response [{0}] took {1:00.0}s")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with primitive types.")]
    public void ResponseDelay(string? requestId, double seconds)
    {
        WriteEvent(ResponseDelayEvent, requestId, seconds);
    }

    [Event(ExceptionResponseEvent, Level = EventLevel.Informational, Message = "Request [{0}] exception {1}")]
    public void ExceptionResponse(string? requestId, string exception)
    {
        WriteEvent(ExceptionResponseEvent, requestId, exception);
    }
}
