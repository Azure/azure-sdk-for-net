// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Core
{
    /// <summary>
    /// Shared source helpers for <see cref="RequestContext"/>.
    /// </summary>
	internal static class RequestContextExtensions
	{
        /// <summary>
        /// Singleton <see cref="RequestContext"/> to use when we don't have an
        /// instance.
        /// </summary>
        public static RequestContext Empty { get; } = new RequestContext();

        /// <summary>
        /// Create a RequestContext instance from a CancellationToken.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// A <see cref="RequestContext"/> wrapping the cancellation token.
        /// </returns>
        public static RequestContext ToRequestContext(this CancellationToken cancellationToken) =>
            cancellationToken == CancellationToken.None ?
                Empty :
                new() { CancellationToken = cancellationToken };

        /// <summary>
        /// Link a CancellationToken with an existing RequestContext.
        /// </summary>
        /// <param name="context">
        /// The <see cref="RequestContext"/> for the current operation.
        /// </param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>
        /// The <see cref="RequestContext"/> for the current operation.
        /// </returns>
        public static RequestContext Link(this RequestContext context, CancellationToken cancellationToken)
        {
            if (cancellationToken == CancellationToken.None)
            {
                // Don't link if there's nothing there
            }
            else if (context.CancellationToken == CancellationToken.None)
            {
                // Don't link if we can just replace
                context.CancellationToken = cancellationToken;
            }
            else
            {
                // Otherwise link them together
                CancellationTokenSource source = CancellationTokenSource.CreateLinkedTokenSource(
                    context.CancellationToken,
                    cancellationToken);
                context.CancellationToken = source.Token;
            }
            return context;
        }

        /// <summary>
        /// Customizes the <see cref="ResponseClassifier"/> for this operation
        /// to change the default <see cref="Response"/> classification behavior
        /// so that it evalutes the anonymous classifier to determine whether
        /// an error occured or not.
        ///
        /// Custom classifiers are applied after all
        /// <see cref="ResponseClassificationHandler"/> classifiers.  This is
        /// useful for cases where you'd like to prevent specific situations
        /// from being treated as errors by logging and distributed tracing
        /// policies -- that is, if a response is not classified as an error,
        /// it will not appear as an error in logs or distributed traces.
        /// </summary>
        /// <param name="context">
        /// The <see cref="RequestContext"/> for the current operation.
        /// </param>
        /// <param name="classifier">
        /// A function to classify the response.  It should return true if the
        /// message contains an error, false if not an error, and null if it
        /// was unable to classify.
        /// </param>
        /// <returns>
        /// The <see cref="RequestContext"/> for the current operation.
        /// </returns>
        public static RequestContext AddClassifier(this RequestContext context, Func<HttpMessage, bool?> classifier)
        {
            Argument.AssertNotNull(context, nameof(context));
            Argument.AssertNotNull(classifier, nameof(classifier));
            context.AddClassifier(new LambdaClassifier(classifier));
            return context;
        }

        // Anonymous reponse classifier
        private class LambdaClassifier : ResponseClassificationHandler
        {
            private Func<HttpMessage, bool?> _classifier;

            public LambdaClassifier(Func<HttpMessage, bool?> classifier) =>
                _classifier = classifier;

            public override bool TryClassify(HttpMessage message, out bool isError)
            {
                if (message.HasResponse)
                {
                    bool? result = _classifier(message);
                    if (result is not null)
                    {
                        isError = result.Value;
                        return true;
                    }
                }

                isError = false;
                return false;
            }
        }

        /// <summary>
        /// Customizes the <see cref="ResponseClassifier"/> for this operation
        /// to change the default <see cref="Response"/> classification behavior
        /// so that it considers the passed-in status code and error code to be
        /// an error or not, as specified.
        ///
        /// Custom classifiers are applied after all
        /// <see cref="ResponseClassificationHandler"/> classifiers.  This is
        /// useful for cases where you'd like to prevent specific response
        /// status and error codes from being treated as errors by logging and
        /// distributed tracing policies -- that is, if a response is not
        /// classified as an error, it will not appear as an error in logs or
        /// distributed traces.
        /// </summary>
        /// <param name="context">
        /// The <see cref="RequestContext"/> for the current operation.
        /// </param>
        /// <param name="statusCode">
        /// The status code to customize classification for.
        /// </param>
        /// <param name="errorCode">
        /// The error code to customize classification for.
        /// </param>
        /// <param name="isError">
        /// Whether the passed-in status code should be classified as an error.
        /// </param>
        /// <returns>
        /// The <see cref="RequestContext"/> for the current operation.
        /// </returns>
        public static RequestContext AddClassifier(this RequestContext context, int statusCode, string errorCode, bool isError) =>
            context.AddClassifier(
                message =>
                    message.Response.Status == statusCode &&
                    message.Response.Headers.TryGetValue("x-ms-error-code", out string code) &&
                    code == errorCode ?
                        isError :
                        null);
    }
}
