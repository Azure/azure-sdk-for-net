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
    public partial class ImageReference
    {
        public DateTimeOffset Created { get; }
        public Uri DownloadUrl { get; }

        private HttpPipeline _pipeline { get; }

        protected ImageReference(HttpPipeline downloadPipeline, long unixCreatedSeconds, Uri downloadUri)
        {
            _pipeline = downloadPipeline;

            Created = DateTimeOffset.FromUnixTimeSeconds(unixCreatedSeconds);
            DownloadUrl = downloadUri;
        }

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
