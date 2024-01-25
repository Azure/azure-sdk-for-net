// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel.Internal;

internal class ChainingClassifier : PipelineMessageClassifier
{
    private MessageClassificationHandler[]? _handlers;
    private readonly PipelineMessageClassifier _endOfChain;

    public ChainingClassifier((int Status, bool IsError)[]? statusCodes,
        MessageClassificationHandler[]? handlers,
        PipelineMessageClassifier endOfChain)
    {
        if (handlers != null)
        {
            AddClassifiers(handlers);
        }

        if (statusCodes != null)
        {
            StatusCodeHandler[] handler = { new StatusCodeHandler(statusCodes) };
            AddClassifiers(new ReadOnlySpan<MessageClassificationHandler>(handler));
        }

        _endOfChain = endOfChain;
    }

    public override bool IsErrorResponse(PipelineMessage message)
    {
        if (_handlers != null)
        {
            foreach (var handler in _handlers)
            {
                if (handler.TryClassify(message, out bool isError))
                {
                    return isError;
                }
            }
        }

        return _endOfChain.IsErrorResponse(message);
    }

    public override bool IsRetriable(PipelineMessage message, Exception exception)
    {
        if (_handlers != null)
        {
            foreach (var handler in _handlers)
            {
                if (handler.TryClassify(message, exception, out bool isRetriable))
                {
                    return isRetriable;
                }
            }
        }

        return _endOfChain.IsRetriable(message, exception);
    }

    public override bool IsRetriableResponse(PipelineMessage message)
    {
        if (_handlers != null)
        {
            foreach (var handler in _handlers)
            {
                if (handler.TryClassify(message, default, out bool isRetriable))
                {
                    return isRetriable;
                }
            }
        }

        return _endOfChain.IsRetriableResponse(message);
    }

    private void AddClassifiers(ReadOnlySpan<MessageClassificationHandler> handlers)
    {
        int length = _handlers == null ? 0 : _handlers.Length;
        Array.Resize(ref _handlers, length + handlers.Length);
        Span<MessageClassificationHandler> target = new Span<MessageClassificationHandler>(_handlers, length, handlers.Length);
        handlers.CopyTo(target);
    }

    private class StatusCodeHandler : MessageClassificationHandler
    {
        private readonly (int Status, bool IsError)[] _statusCodes;

        public StatusCodeHandler((int Status, bool IsError)[] statusCodes)
        {
            _statusCodes = statusCodes;
        }

        public override bool TryClassify(PipelineMessage message, out bool isError)
        {
            message.AssertResponse();

            foreach (var classification in _statusCodes)
            {
                if (classification.Status == message.Response!.Status)
                {
                    isError = classification.IsError;
                    return true;
                }
            }

            isError = false;
            return false;
        }
    }
}
