// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace System.ClientModel.Primitives;

public class PipelineMessageClassifier
{
    internal static PipelineMessageClassifier Default { get; } = new PipelineMessageClassifier();

    public static PipelineMessageClassifier Create(ReadOnlySpan<ushort> successStatusCodes)
        => new ResponseStatusClassifier(successStatusCodes);

    protected internal PipelineMessageClassifier() { }

    /// <summary>
    /// Specifies if the response contained in the <paramref name="message"/> is not successful.
    /// </summary>
    public virtual bool IsErrorResponse(PipelineMessage message)
    {
        message.AssertResponse();

        int statusKind = message.Response!.Status / 100;
        return statusKind == 4 || statusKind == 5;
    }

    public virtual bool IsRetriableResponse(PipelineMessage message)
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

    public virtual bool IsRetriableException(Exception exception)
    {
        return (exception is IOException) ||
               (exception is ClientResultException requestFailed && requestFailed.Status == 0);
    }

    public virtual bool IsRetriable(PipelineMessage message, Exception exception)
    {
        return IsRetriableException(exception) ||
               // Retry non-user initiated cancellations
               (exception is OperationCanceledException && !message.CancellationToken.IsCancellationRequested);
    }
}
