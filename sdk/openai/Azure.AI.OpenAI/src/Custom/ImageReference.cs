// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.OpenAI
{
    /// <summary>
    /// Representation of a single generated image from an image generation request.
    /// </summary>
    public partial class ImageReference
    {
        /// <summary>
        /// Gets the creation timestamp for the generated image.
        /// </summary>
        public DateTimeOffset Created { get; }

        /// <summary>
        /// Gets a temporary URL from which the generated image may be downloaded.
        /// </summary>
        public Uri DownloadUrl { get; }

        private HttpPipeline _pipeline { get; }

        protected ImageReference(HttpPipeline downloadPipeline, long unixCreatedSeconds, Uri downloadUri)
        {
            _pipeline = downloadPipeline;

            Created = DateTimeOffset.FromUnixTimeSeconds(unixCreatedSeconds);
            DownloadUrl = downloadUri;
        }

        /// <summary>
        ///     Connects to the image source specified at <see cref="DownloadUrl"/> and opens a stream to retrieve the
        ///     binary data of the image.
        /// </summary>
        /// <remarks>
        ///     This method uses the <see cref="HttpPipeline"/> from the originating <see cref="OpenAIClient"/> to
        ///     initiate the download and will inherit any configuration details, such as proxy settings.
        /// </remarks>
        /// <param name="cancellationToken">
        ///     An optional cancellation token that may be used to abort the operation.
        /// </param>
        /// <returns>
        ///     A stream of binary data for the generated image.
        /// </returns>
        public async Task<Stream> GetStreamAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage message = _pipeline.CreateMessage();
            message.BufferResponse = false;

            var requestUri = new RequestUriBuilder();
            requestUri.Reset(DownloadUrl);

            message.Request.Method = RequestMethod.Get;
            message.Request.Uri = requestUri;
            message.SetProperty(SkippableBearerTokenAuthenticationPolicy.SkipPropertyKey, true);

            Response response = await _pipeline.ProcessMessageAsync(
                message,
                requestContext: null,
                cancellationToken)
                .ConfigureAwait(false);

            return response.ContentStream;
        }

        internal static IReadOnlyList<ImageReference> RangeFromResponse(
            ImageResponse imageResponse,
            HttpPipeline pipeline)
        {
            var results = new List<ImageReference>();

            foreach (ImageLocation imageLocation in imageResponse.Data)
            {
                results.Add(new ImageReference(
                    pipeline,
                    imageResponse.Created,
                    imageLocation.Url));
            }

            return results;
        }
    }
}
