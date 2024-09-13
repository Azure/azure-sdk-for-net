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
    private ClientModelEventSource(string eventSourceName, string[]? traits = default) : base(eventSourceName, EventSourceSettings.Default, traits) { }

    public static ClientModelEventSource Log = new("System-ClientModel");

    #region Request

    [NonEvent]
    public void Request(string requestId, PipelineRequest request, string? clientAssembly, PipelineMessageSanitizer sanitizer)
    {
        if (IsEnabled(EventLevel.Informational, EventKeywords.None))
        {
            Request(requestId, request.Method, sanitizer.SanitizeUrl(request.Uri!.AbsoluteUri), );
        }
    }

    [Event(LoggingEventIds.RequestEvent, Level = EventLevel.Informational, Message = "Request [{0}] {1} {2}\r\n{3}client assembly: {4}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with primitive types.")]
    private void Request(string? requestId, string method, string uri, string headers, string? clientAssembly)
    {
        WriteEvent(LoggingEventIds.RequestEvent, requestId, method, uri, headers, clientAssembly);
    }

    [NonEvent]
    public void RequestContent(string requestId, byte[] content, Encoding? textEncoding)
    {
        if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
        {
            if (textEncoding != null)
            {
                RequestContentText(requestId, textEncoding.GetString(content));
            }
            else
            {
                RequestContent(requestId, content);
            }
        }
    }

    [Event(LoggingEventIds.RequestContentEvent, Level = EventLevel.Verbose, Message = "Request [{0}] content: {1}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with an array with primitive type elements.")]
    private void RequestContent(string? requestId, byte[] content)
    {
        WriteEvent(LoggingEventIds.RequestContentEvent, requestId, content);
    }

    [Event(LoggingEventIds.RequestContentTextEvent, Level = EventLevel.Verbose, Message = "Request [{0}] content: {1}")]
    private void RequestContentText(string? requestId, string content)
    {
        WriteEvent(LoggingEventIds.RequestContentTextEvent, requestId, content);
    }

    #endregion

    #region Response

    [Event(LoggingEventIds.ResponseEvent, Level = EventLevel.Informational, Message = "Response [{0}] {1} {2} ({4:00.0}s)\r\n{3}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with primitive types.")]
    private void Response(string? requestId, int status, string reasonPhrase, string headers, double seconds)
    {
        WriteEvent(LoggingEventIds.ResponseEvent, requestId, status, reasonPhrase, headers, seconds);
    }

    [Event(LoggingEventIds.ResponseContentEvent, Level = EventLevel.Verbose, Message = "Response [{0}] content: {1}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with an array with primitive type elements.")]
    private void ResponseContent(string? requestId, byte[] content)
    {
        WriteEvent(LoggingEventIds.ResponseContentEvent, requestId, content);
    }s

    [Event(LoggingEventIds.ResponseContentTextEvent, Level = EventLevel.Verbose, Message = "Response [{0}] content: {1}")]
    private void ResponseContentText(string? requestId, string content)
    {
        WriteEvent(LoggingEventIds.ResponseContentTextEvent, requestId, content);
    }

    [Event(LoggingEventIds.ResponseContentBlockEvent, Level = EventLevel.Verbose, Message = "Response [{0}] content block {1}: {2}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with an array with primitive type elements.")]
    private void ResponseContentBlock(string? requestId, int blockNumber, byte[] content)
    {
        WriteEvent(LoggingEventIds.ResponseContentBlockEvent, requestId, blockNumber, content);
    }

    [Event(LoggingEventIds.ResponseContentTextBlockEvent, Level = EventLevel.Verbose, Message = "Response [{0}] content block {1}: {2}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with primitive types.")]
    private void ResponseContentTextBlock(string? requestId, int blockNumber, string content)
    {
        WriteEvent(LoggingEventIds.ResponseContentTextBlockEvent, requestId, blockNumber, content);
    }

    #endregion

    #region Error Response

    [Event(LoggingEventIds.ErrorResponseEvent, Level = EventLevel.Warning, Message = "Error response [{0}] {1} {2} ({4:00.0}s)\r\n{3}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with primitive types.")]
    private void ErrorResponse(string? requestId, int status, string reasonPhrase, string headers, double seconds)
    {
        WriteEvent(LoggingEventIds.ErrorResponseEvent, requestId, status, reasonPhrase, headers, seconds);
    }

    [Event(LoggingEventIds.ErrorResponseContentEvent, Level = EventLevel.Informational, Message = "Error response [{0}] content: {1}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with an array with primitive type elements.")]
    private void ErrorResponseContent(string? requestId, byte[] content)
    {
        WriteEvent(LoggingEventIds.ErrorResponseContentEvent, requestId, content);
    }

    [Event(LoggingEventIds.ErrorResponseContentTextEvent, Level = EventLevel.Informational, Message = "Error response [{0}] content: {1}")]
    private void ErrorResponseContentText(string? requestId, string content)
    {
        WriteEvent(LoggingEventIds.ErrorResponseContentTextEvent, requestId, content);
    }

    [Event(LoggingEventIds.ErrorResponseContentBlockEvent, Level = EventLevel.Informational, Message = "Error response [{0}] content block {1}: {2}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with an array with primitive type elements.")]
    private void ErrorResponseContentBlock(string? requestId, int blockNumber, byte[] content)
    {
        WriteEvent(LoggingEventIds.ErrorResponseContentBlockEvent, requestId, blockNumber, content);
    }

    [Event(LoggingEventIds.ErrorResponseContentTextBlockEvent, Level = EventLevel.Informational, Message = "Error response [{0}] content block {1}: {2}")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with primitive types.")]
    private void ErrorResponseContentTextBlock(string? requestId, int blockNumber, string content)
    {
        WriteEvent(LoggingEventIds.ErrorResponseContentTextBlockEvent, requestId, blockNumber, content);
    }

    #endregion

    #region Retry

    [Event(LoggingEventIds.RequestRetryingEvent, Level = EventLevel.Informational, Message = "Request [{0}] attempt number {1} took {2:00.0}s")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with primitive types.")]
    private void RequestRetrying(string? requestId, int retryNumber, double seconds)
    {
        WriteEvent(LoggingEventIds.RequestRetryingEvent, requestId, retryNumber, seconds);
    }

    #endregion

    #region Response Delay

    [Event(LoggingEventIds.ResponseDelayEvent, Level = EventLevel.Warning, Message = "Response [{0}] took {1:00.0}s")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with primitive types.")]
    private void ResponseDelay(string? requestId, double seconds)
    {
        WriteEvent(LoggingEventIds.ResponseDelayEvent, requestId, seconds);
    }

    #endregion

    #region Exception Response

    [Event(LoggingEventIds.ExceptionResponseEvent, Level = EventLevel.Informational, Message = "Request [{0}] exception {1}")]
    private void ExceptionResponse(string? requestId, string exception)
    {
        WriteEvent(LoggingEventIds.ExceptionResponseEvent, requestId, exception);
    }

    #endregion

    #region Helpers

    [NonEvent]
    private string FormatHeaders(IEnumerable<KeyValuePair<string, string>> headers, PipelineMessageSanitizer sanitizer)
    {
        var stringBuilder = new StringBuilder();
        foreach (var header in headers)
        {
            stringBuilder.Append(header.Key);
            stringBuilder.Append(':');
            stringBuilder.Append(sanitizer.SanitizeHeader(header.Key, header.Value));
            stringBuilder.Append(Environment.NewLine);
        }
        return stringBuilder.ToString();
    }

    #endregion
}
