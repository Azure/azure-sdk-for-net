// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Internal.Logging;
internal class HttpMessageLogging
{
    private const double RequestTooLongSeconds = 3.0;

    private readonly LoggingOptions _loggingOptions;
    private readonly LoggingHandler _loggingHandler;

    public HttpMessageLogging(LoggingOptions? options = default)
    {
        _loggingOptions = options ?? new LoggingOptions();

        PipelineMessageSanitizer sanitizer = new(_loggingOptions.AllowedQueryParameters.ToArray(), _loggingOptions.AllowedHeaderNames.ToArray());
        ILogger logger = _loggingOptions.LoggerFactory.CreateLogger<HttpMessageLogging>();
        _loggingHandler = new LoggingHandler(logger, sanitizer);
    }

    public void LogRequest(PipelineMessage message)
    {
        if (_loggingOptions.IsHttpMessageLoggingEnabled)
        {
            _loggingHandler.LogRequest(message.LoggingCorrelationId, message.Request);
        }
    }

    public async ValueTask LogRequestContentSyncOrAsync(PipelineMessage message, bool async)
    {
        if (_loggingOptions.IsHttpMessageBodyLoggingEnabled && _loggingHandler.IsEnabled(LogLevel.Debug, EventLevel.Verbose))
        {
            PipelineRequest request = message.Request;

            if (request.Content == null)
            {
                _loggingHandler.LogRequestContent(message.LoggingCorrelationId, Array.Empty<byte>(), null);
                return;
            }

            using var memoryStream = new MaxLengthStream(_loggingOptions.HttpMessageBodyLogLimit);
            if (async)
            {
                await request.Content.WriteToAsync(memoryStream).ConfigureAwait(false);
            }
            else
            {
                request.Content.WriteTo(memoryStream, message.CancellationToken);
            }
            byte[] bytes = memoryStream.ToArray();

            Encoding? requestTextEncoding = null;
            if (request.Headers.TryGetValue("Content-Type", out var contentType) && contentType != null)
            {
                ContentTypeUtilities.TryGetTextEncoding(contentType, out requestTextEncoding);
            }

            _loggingHandler.LogRequestContent(message.LoggingCorrelationId, bytes, requestTextEncoding);
        }
    }

    public void LogResponse(PipelineMessage message, double secondsElapsed)
    {
        PipelineResponse? response = message.Response;
        if (_loggingOptions.IsHttpMessageLoggingEnabled && response != null)
        {
            if (response.IsError)
            {
                _loggingHandler.LogErrorResponse(message.LoggingCorrelationId, response, secondsElapsed);
            }
            else
            {
                _loggingHandler.LogResponse(message.LoggingCorrelationId, response, secondsElapsed);
            }
        }
    }

    public void LogBufferedOrSeekableResponseContent(PipelineMessage message)
    {
        PipelineResponse? response = message.Response;
        if (_loggingOptions.IsHttpMessageBodyLoggingEnabled && _loggingHandler.IsEnabled(LogLevel.Debug, EventLevel.Verbose) && response != null)
        {
            if (response.ContentStream == null)
            {
                _loggingHandler.LogResponseContent(message.LoggingCorrelationId, Array.Empty<byte>(), null);
                return;
            }

            Encoding? responseTextEncoding = null;
            if (response.Headers.TryGetValue("Content-Type", out var contentType) && contentType != null)
            {
                ContentTypeUtilities.TryGetTextEncoding(contentType, out responseTextEncoding);
            }

            if (message.BufferResponse || response.ContentStream.CanSeek)
            {
                byte[]? responseBytes;
                if (message.BufferResponse)
                {
                    // Content is buffered, so log the first _loggingOptions.HttpMessageBodyLogLimit bytes
                    ReadOnlyMemory<byte> contentAsMemory = response.Content.ToMemory();
                    var length = Math.Min(contentAsMemory.Length, _loggingOptions.HttpMessageBodyLogLimit);
                    responseBytes = contentAsMemory.Span.Slice(0, length).ToArray();
                }
                else
                {
                    responseBytes = new byte[_loggingOptions.HttpMessageBodyLogLimit];
                    response.ContentStream.Read(responseBytes, 0, _loggingOptions.HttpMessageBodyLogLimit);
                    response.ContentStream.Seek(0, SeekOrigin.Begin);
                }

                if (response.IsError)
                {
                    _loggingHandler.LogErrorResponseContent(message.LoggingCorrelationId, responseBytes, responseTextEncoding);
                }
                else
                {
                    _loggingHandler.LogResponseContent(message.LoggingCorrelationId, responseBytes, responseTextEncoding);
                }
            }
        }
    }

    public void LogNonBufferedResponseContent(PipelineMessage message)
    {
        PipelineResponse? response = message.Response;
        if (_loggingOptions.IsHttpMessageBodyLoggingEnabled && _loggingHandler.IsEnabled(LogLevel.Debug, EventLevel.Verbose) && response != null)
        {
            if (response.ContentStream == null)
            {
                _loggingHandler.LogResponseContent(message.LoggingCorrelationId, Array.Empty<byte>(), null);
                return;
            }

            Encoding? responseTextEncoding = null;
            if (response.Headers.TryGetValue("Content-Type", out var contentType) && contentType != null)
            {
                ContentTypeUtilities.TryGetTextEncoding(contentType, out responseTextEncoding);
            }

            response.ContentStream = new LoggingStream(_loggingHandler, message.LoggingCorrelationId, _loggingOptions.HttpMessageBodyLogLimit, response.ContentStream, response.IsError, responseTextEncoding);
        }
    }
}
