// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace System.ClientModel.Primitives;

public abstract class PipelineMessageClassifier
{
    public static PipelineMessageClassifier Default { get; } = new EndOfChainClassifier();

    public static PipelineMessageClassifier Create(ReadOnlySpan<ushort> successStatusCodes)
        => new ResponseStatusClassifier(successStatusCodes);

    protected PipelineMessageClassifier() { }

    public abstract bool TryClassify(PipelineMessage message, out bool isError);

    public abstract bool TryClassify(PipelineMessage message, Exception? exception, out bool isRetriable);

    internal class EndOfChainClassifier : PipelineMessageClassifier
    {
        public override bool TryClassify(PipelineMessage message, out bool isError)
        {
            message.AssertResponse();

            int statusKind = message.Response!.Status / 100;
            isError = statusKind == 4 || statusKind == 5;

            // Always classify the message
            return true;
        }

        public override bool TryClassify(PipelineMessage message, Exception? exception, out bool isRetriable)
        {
            isRetriable = exception is null ?
                IsRetriable(message) :
                IsRetriable(message, exception);

            // Always classify the message
            return true;
        }

        private static bool IsRetriable(PipelineMessage message)
        {
            message.AssertResponse();

            return message.Response!.Status switch
            {
                // Request Timeout
                408 => true,

                // Too Many Requests
                429 => true,

                // Internal Server Error
                500 => true,

                // Bad Gateway
                502 => true,

                // Service Unavailable
                503 => true,

                // Gateway Timeout
                504 => true,

                // Default case
                _ => false
            };
        }

        private static bool IsRetriable(PipelineMessage message, Exception exception)
            => IsRetriable(exception) ||
                // Retry non-user initiated cancellations
                (exception is OperationCanceledException &&
                !message.CancellationToken.IsCancellationRequested);

        private static bool IsRetriable(Exception exception)
            => (exception is IOException) ||
                (exception is ClientResultException ex && ex.Status == 0);
    }
}
