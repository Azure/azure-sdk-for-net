// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Containers.Apps.Sandbox
{
    public partial class SandboxGroupContentPackages
    {
        /// <summary>
        /// Creates a content package from a stream.
        /// </summary>
        /// <param name="content">
        /// The readable, seekable stream to upload. Upload starts at the stream's current position.
        /// The stream remains open after the operation completes.
        /// </param>
        /// <param name="contentType">The media type of the uploaded content.</param>
        /// <param name="labels">Comma-separated key=value labels that all resources must match.</param>
        /// <param name="cancellationToken">The cancellation token that can be used to cancel the operation.</param>
        /// <exception cref="ArgumentNullException"><paramref name="content"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="content"/> is not readable and seekable.</exception>
        /// <exception cref="RequestFailedException">The service returned a non-success status code.</exception>
        public virtual Response<ContentPackage> UploadContentPackage(
            Stream content,
            string contentType = default,
            string labels = default,
            CancellationToken cancellationToken = default)
        {
            RequestContent requestContent = StreamRequestContent.Create(content);

            Response result = UploadContentPackage(
                requestContent,
                contentType,
                labels,
                cancellationToken.ToRequestContext());
            return Response.FromValue((ContentPackage)result, result);
        }

        /// <summary>
        /// Creates a content package from a stream.
        /// </summary>
        /// <param name="content">
        /// The readable, seekable stream to upload. Upload starts at the stream's current position.
        /// The stream remains open after the operation completes.
        /// </param>
        /// <param name="contentType">The media type of the uploaded content.</param>
        /// <param name="labels">Comma-separated key=value labels that all resources must match.</param>
        /// <param name="cancellationToken">The cancellation token that can be used to cancel the operation.</param>
        /// <exception cref="ArgumentNullException"><paramref name="content"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="content"/> is not readable and seekable.</exception>
        /// <exception cref="RequestFailedException">The service returned a non-success status code.</exception>
        public virtual async Task<Response<ContentPackage>> UploadContentPackageAsync(
            Stream content,
            string contentType = default,
            string labels = default,
            CancellationToken cancellationToken = default)
        {
            RequestContent requestContent = StreamRequestContent.Create(content);

            Response result = await UploadContentPackageAsync(
                requestContent,
                contentType,
                labels,
                cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((ContentPackage)result, result);
        }
    }
}
