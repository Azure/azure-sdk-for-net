// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace System.ClientModel.Primitives;

/// <summary>
/// A classifier that can evaluate a <see cref="PipelineMessage"/> in two ways.
/// First, given an HTTP message, the <see cref="PipelineMessageClassifier"/>
/// can determine whether the service response it holds should be considered an
/// error response.  Second, given an HTTP message and an optional pipeline
/// exception, the classifier can determine whether or not the
/// <see cref="ClientPipeline"/> should retry the request.
/// </summary>
public abstract class PipelineMessageClassifier
{
    /// <summary>
    /// A default classifier instance. This classifier will classify a
    /// <see cref="PipelineResponse"/> with a status code of <c>4xx</c> or
    /// <c>5xx</c> as an error, and with a status code of <c>408</c>,
    /// <c>429</c>, <c>500</c>, <c>502</c>, <c>503</c> and <c>504</c> as
    /// retriable.
    /// </summary>
    public static PipelineMessageClassifier Default { get; } = new EndOfChainClassifier();

    /// <summary>
    /// Create an instance of a <see cref="PipelineMessageClassifier"/> from a
    /// collection of success status codes.
    /// </summary>
    /// <param name="successStatusCodes">The status codes that the returned
    /// classifier instance will classifiy as success codes.</param>
    /// <returns>A <see cref="PipelineMessageClassifier"/> instance that
    /// classifies the status codes provided by
    /// <paramref name="successStatusCodes"/> as success codes.</returns>
    public static PipelineMessageClassifier Create(ReadOnlySpan<ushort> successStatusCodes)
        => new ResponseStatusClassifier(successStatusCodes);

    /// <summary>
    /// Attempt to evaluate whether the provided <see cref="PipelineMessage"/>
    /// contains a <see cref="PipelineMessage.Response"/> that the client should
    /// consider an error response.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> to classify.</param>
    /// <param name="isError"><c>true</c> if the
    /// <see cref="PipelineMessage.Response"/> should be considered an error
    /// response.</param>
    /// <returns><c>true</c> if the classifier had an opinion regarding whether
    /// the service response was an error response; <c>false</c> otherwise.
    /// </returns>
    /// <remarks>
    /// Not all classifiers derived from <see cref="PipelineMessageClassifier"/>
    /// will classify a given <see cref="PipelineMessage"/>. Returning
    /// <c>false</c> from <see cref="TryClassify(PipelineMessage, out bool)"/>
    /// allows a classifier instance to compose with other classifiers by
    /// passing the classification decision to a later instance.
    /// <see cref="Default"/> will always return <c>true</c> from
    /// <see cref="TryClassify(PipelineMessage, out bool)"/> and may be used as
    /// the last classifier in any composed classifier collection.
    /// </remarks>
    public abstract bool TryClassify(PipelineMessage message, out bool isError);

    /// <summary>
    /// Attempt to evaluate whether the provided <see cref="PipelineMessage"/>
    /// contains a <see cref="PipelineMessage.Response"/> that indicates the
    /// client should retry the <see cref="PipelineMessage.Request"/>.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> to classify.</param>
    /// <param name="exception">An <see cref="Exception"/>, if any, that will
    /// also be used in the retry classification. Callers are intended to
    /// provide any exception thrown during the attempt to send the prior
    /// request.</param>
    /// <param name="isRetriable"><c>true</c> if the
    /// <see cref="PipelineMessage.Request"/> should be retried.</param>
    /// <returns><c>true</c> if the classifier had an opinion regarding whether
    /// the service request should be retried; <c>false</c> otherwise.
    /// </returns>
    /// <remarks>
    /// Not all classifiers derived from <see cref="PipelineMessageClassifier"/>
    /// will classify a given <see cref="PipelineMessage"/>. Returning
    /// <c>false</c> from <see cref="TryClassify(PipelineMessage, out bool)"/>
    /// allows a classifier instance to compose with other classifiers by
    /// passing the classification decision to a later instance.
    /// <see cref="Default"/> will always return <c>true</c> from
    /// <see cref="TryClassify(PipelineMessage, out bool)"/> and may be used as
    /// the last classifier in any composed classifier collection.
    /// </remarks>
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
