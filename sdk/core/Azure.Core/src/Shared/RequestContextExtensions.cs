// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Core
{
    /// <summary>
    /// Shared source helpers for <see cref="RequestContext"/>.
    /// </summary>
	internal static class RequestContextExtensions
	{
        /// <summary>
        /// Singleton RequestContext to use when we don't have an instance.
        /// </summary>
        public static RequestContext Empty { get; } = new RequestContext();

        /// <summary>
        /// Create a RequestContext instance from a CancellationToken.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// A RequestContext wrapping the cancellation token.
        /// </returns>
        public static RequestContext ToRequestContext(this CancellationToken cancellationToken) =>
            cancellationToken == CancellationToken.None ?
                Empty :
                new() { CancellationToken = cancellationToken };

        /// <summary>
        /// Link a CancellationToken with an existing RequestContext.
        /// </summary>
        /// <param name="context">The RequestContext.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        public static void Link(this RequestContext context, CancellationToken cancellationToken)
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
        }
	}
}
