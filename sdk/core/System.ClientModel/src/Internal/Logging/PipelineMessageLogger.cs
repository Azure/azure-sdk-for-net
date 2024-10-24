// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Internal;

internal partial class PipelineMessageLogger
{
    private readonly ILogger<MessageLoggingPolicy>? _logger;
    private readonly PipelineMessageSanitizer _sanitizer;

    public PipelineMessageLogger(PipelineMessageSanitizer sanitizer, ILoggerFactory? loggerFactory)
    {
        _sanitizer = sanitizer;
        _logger = loggerFactory?.CreateLogger<MessageLoggingPolicy>() ?? null;
    }

    public void LogRequest(PipelineRequest request, string? clientAssembly)
    {
        if (_logger is not null)
        {
            Request(_logger, request.ClientRequestId, request, clientAssembly);
        }
        else
        {
            ClientEventSource.Log.Request(request.ClientRequestId, request, clientAssembly, _sanitizer);
        }
    }

    private void Request(ILogger logger, string? requestId, PipelineRequest request, string? clientAssembly)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            string uri = _sanitizer.SanitizeUrl(request.Uri!.AbsoluteUri);
            string headers = FormatHeaders(request.Headers);

            Request(logger, requestId, request.Method, uri, headers, clientAssembly);
        }
    }

    [LoggerMessage(LoggingEventIds.RequestEvent, LogLevel.Information, "Request [{requestId}] {method} {uri}\r\n{headers}client assembly: {clientAssembly}", SkipEnabledCheck = true, EventName = "Request")]
    private static partial void Request(ILogger logger, string? requestId, string method, string uri, string headers, string? clientAssembly);

    private string FormatHeaders(IEnumerable<KeyValuePair<string, string>> headers)
    {
        var stringBuilder = new StringBuilder();
        foreach (var header in headers)
        {
            stringBuilder.Append(header.Key);
            stringBuilder.Append(':');
            stringBuilder.Append(_sanitizer.SanitizeHeader(header.Key, header.Value));
            stringBuilder.Append(Environment.NewLine);
        }
        return stringBuilder.ToString();
    }
}
