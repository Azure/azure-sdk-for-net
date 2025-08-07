// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Azure.AI.ContentSafety
{
    public partial class ContentSafetyClient
    {
        /// <summary> Analyze Text. </summary>
        public virtual Response<AnalyzeTextResult> AnalyzeText(string text, CancellationToken cancellationToken = default)
        {
            return AnalyzeText(new AnalyzeTextOptions(text), cancellationToken);
        }

        /// <summary> Analyze Text Async. </summary>
        public virtual async Task<Response<AnalyzeTextResult>> AnalyzeTextAsync(string text, CancellationToken cancellationToken = default)
        {
            return await AnalyzeTextAsync(new AnalyzeTextOptions(text), cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Analyze Image with Blob URI. </summary>
        public virtual Response<AnalyzeImageResult> AnalyzeImage(Uri blobUri, CancellationToken cancellationToken = default)
        {
            return AnalyzeImage(new AnalyzeImageOptions(new ContentSafetyImageData(blobUri)), cancellationToken);
        }

        /// <summary> Analyze Image with Blob URI Async. </summary>
        public virtual async Task<Response<AnalyzeImageResult>> AnalyzeImageAsync(Uri blobUri, CancellationToken cancellationToken = default)
        {
            return await AnalyzeImageAsync(new AnalyzeImageOptions(new ContentSafetyImageData(blobUri)), cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Analyze Image with Binary Data. </summary>
        public virtual Response<AnalyzeImageResult> AnalyzeImage(BinaryData content, CancellationToken cancellationToken = default)
        {
            return AnalyzeImage(new AnalyzeImageOptions(new ContentSafetyImageData(content)), cancellationToken);
        }

        /// <summary> Analyze Image with Binary Data Async. </summary>
        public virtual async Task<Response<AnalyzeImageResult>> AnalyzeImageAsync(BinaryData content, CancellationToken cancellationToken = default)
        {
            return await AnalyzeImageAsync(new AnalyzeImageOptions(new ContentSafetyImageData(content)), cancellationToken).ConfigureAwait(false);
        }
    }
}
