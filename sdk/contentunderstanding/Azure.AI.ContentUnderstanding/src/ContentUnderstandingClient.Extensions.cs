// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Extension methods for <see cref="ContentUnderstandingClient"/> to provide convenience APIs.
    /// </summary>
    public static partial class ContentUnderstandingClientExtensions
    {
        /// <summary> Update analyzer properties. </summary>
        /// <param name="client"> The client instance. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="resource"> The resource instance with properties to update. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/>, <paramref name="analyzerId"/>, or <paramref name="resource"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public static Response UpdateAnalyzer(this ContentUnderstandingClient client, string analyzerId, ContentAnalyzer resource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNull(resource, nameof(resource));

            return client.UpdateAnalyzer(analyzerId, RequestContent.Create(resource), cancellationToken.ToRequestContext());
        }

        /// <summary> Update analyzer properties asynchronously. </summary>
        /// <param name="client"> The client instance. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="resource"> The resource instance with properties to update. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/>, <paramref name="analyzerId"/>, or <paramref name="resource"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public static async Task<Response> UpdateAnalyzerAsync(this ContentUnderstandingClient client, string analyzerId, ContentAnalyzer resource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNull(resource, nameof(resource));

            return await client.UpdateAnalyzerAsync(analyzerId, RequestContent.Create(resource), cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }
    }
}