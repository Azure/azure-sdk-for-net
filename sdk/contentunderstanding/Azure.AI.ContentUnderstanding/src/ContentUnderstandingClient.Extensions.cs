// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
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

        /// <summary> Update default model deployment settings. </summary>
        /// <remarks>
        /// This is the recommended public API for updating default model deployment settings.
        /// The generated protocol methods (UpdateDefaults/UpdateDefaultsAsync with RequestContent) are internal
        /// and should not be used directly. This convenience method provides a simpler API that accepts
        /// a dictionary mapping model names to deployment names.
        /// </remarks>
        /// <param name="client"> The client instance. </param>
        /// <param name="modelDeployments"> Mapping of model names to deployment names. For example: { "gpt-4.1": "myGpt41Deployment", "text-embedding-3-large": "myTextEmbedding3LargeDeployment" }. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> or <paramref name="modelDeployments"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public static Response<ContentUnderstandingDefaults> UpdateDefaults(this ContentUnderstandingClient client, IDictionary<string, string> modelDeployments, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(modelDeployments, nameof(modelDeployments));

            var defaults = ContentUnderstandingModelFactory.ContentUnderstandingDefaults(modelDeployments);
            var writerOptions = new ModelReaderWriterOptions("W");
            var requestContent = RequestContent.Create(
                ModelReaderWriter.Write(defaults, writerOptions, AzureAIContentUnderstandingContext.Default));

            Response response = client.UpdateDefaults(requestContent, cancellationToken.ToRequestContext());
            return Response.FromValue((ContentUnderstandingDefaults)response, response);
        }

        /// <summary> Update default model deployment settings asynchronously. </summary>
        /// <remarks>
        /// This is the recommended public API for updating default model deployment settings.
        /// The generated protocol methods (UpdateDefaults/UpdateDefaultsAsync with RequestContent) are internal
        /// and should not be used directly. This convenience method provides a simpler API that accepts
        /// a dictionary mapping model names to deployment names.
        /// </remarks>
        /// <param name="client"> The client instance. </param>
        /// <param name="modelDeployments"> Mapping of model names to deployment names. For example: { "gpt-4.1": "myGpt41Deployment", "text-embedding-3-large": "myTextEmbedding3LargeDeployment" }. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> or <paramref name="modelDeployments"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public static async Task<Response<ContentUnderstandingDefaults>> UpdateDefaultsAsync(this ContentUnderstandingClient client, IDictionary<string, string> modelDeployments, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(modelDeployments, nameof(modelDeployments));

            var defaults = ContentUnderstandingModelFactory.ContentUnderstandingDefaults(modelDeployments);
            var writerOptions = new ModelReaderWriterOptions("W");
            var requestContent = RequestContent.Create(
                ModelReaderWriter.Write(defaults, writerOptions, AzureAIContentUnderstandingContext.Default));

            Response response = await client.UpdateDefaultsAsync(requestContent, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((ContentUnderstandingDefaults)response, response);
        }
    }
}
