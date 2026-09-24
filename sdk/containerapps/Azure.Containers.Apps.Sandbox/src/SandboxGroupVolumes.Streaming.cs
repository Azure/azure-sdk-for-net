// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.Apps.Sandbox
{
    public partial class SandboxGroupVolumes
    {
        /// <summary>
        /// Downloads a file from a volume without buffering the response body.
        /// </summary>
        /// <param name="volumeName">The volume name.</param>
        /// <param name="path">The file path to download.</param>
        /// <param name="cancellationToken">The cancellation token that can be used to cancel the operation.</param>
        /// <returns>
        /// A response whose value is the response body stream. The caller must dispose the returned stream.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="volumeName"/> or <paramref name="path"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="volumeName"/> or <paramref name="path"/> is empty.</exception>
        /// <exception cref="RequestFailedException">The service returned a non-success status code.</exception>
        public virtual Response<Stream> DownloadVolumeFileStreaming(
            string volumeName,
            string path,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("SandboxGroupVolumes.DownloadVolumeFileStreaming");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
                Argument.AssertNotNullOrEmpty(path, nameof(path));

                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateDownloadVolumeFileRequest(volumeName, path, context);
                message.BufferResponse = false;
                Response response = Pipeline.ProcessMessage(message, context);
                Stream content = message.ExtractResponseContent();
                return Response.FromValue(content, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Downloads a file from a volume without buffering the response body.
        /// </summary>
        /// <param name="volumeName">The volume name.</param>
        /// <param name="path">The file path to download.</param>
        /// <param name="cancellationToken">The cancellation token that can be used to cancel the operation.</param>
        /// <returns>
        /// A response whose value is the response body stream. The caller must dispose the returned stream.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="volumeName"/> or <paramref name="path"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="volumeName"/> or <paramref name="path"/> is empty.</exception>
        /// <exception cref="RequestFailedException">The service returned a non-success status code.</exception>
        public virtual async Task<Response<Stream>> DownloadVolumeFileStreamingAsync(
            string volumeName,
            string path,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("SandboxGroupVolumes.DownloadVolumeFileStreaming");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
                Argument.AssertNotNullOrEmpty(path, nameof(path));

                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateDownloadVolumeFileRequest(volumeName, path, context);
                message.BufferResponse = false;
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Stream content = message.ExtractResponseContent();
                return Response.FromValue(content, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Uploads a file to a volume from a stream.
        /// </summary>
        /// <param name="volumeName">The volume name.</param>
        /// <param name="path">The destination file path.</param>
        /// <param name="content">
        /// The readable, seekable stream to upload. Upload starts at the stream's current position.
        /// The stream remains open after the operation completes.
        /// </param>
        /// <param name="overwrite">Whether to replace an existing file.</param>
        /// <param name="matchConditions">The request conditions.</param>
        /// <param name="cancellationToken">The cancellation token that can be used to cancel the operation.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="volumeName"/>, <paramref name="path"/>, or <paramref name="content"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="volumeName"/> or <paramref name="path"/> is empty, or <paramref name="content"/> is not readable and seekable.
        /// </exception>
        /// <exception cref="RequestFailedException">The service returned a non-success status code.</exception>
        public virtual Response<VolumePathItem> UploadVolumeFile(
            string volumeName,
            string path,
            Stream content,
            bool? overwrite = default,
            MatchConditions matchConditions = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
            Argument.AssertNotNullOrEmpty(path, nameof(path));
            RequestContent requestContent = StreamRequestContent.Create(content);

            Response result = UploadVolumeFile(
                volumeName,
                path,
                requestContent,
                overwrite,
                matchConditions,
                cancellationToken.ToRequestContext());
            return Response.FromValue((VolumePathItem)result, result);
        }

        /// <summary>
        /// Uploads a file to a volume from a stream.
        /// </summary>
        /// <param name="volumeName">The volume name.</param>
        /// <param name="path">The destination file path.</param>
        /// <param name="content">
        /// The readable, seekable stream to upload. Upload starts at the stream's current position.
        /// The stream remains open after the operation completes.
        /// </param>
        /// <param name="overwrite">Whether to replace an existing file.</param>
        /// <param name="matchConditions">The request conditions.</param>
        /// <param name="cancellationToken">The cancellation token that can be used to cancel the operation.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="volumeName"/>, <paramref name="path"/>, or <paramref name="content"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="volumeName"/> or <paramref name="path"/> is empty, or <paramref name="content"/> is not readable and seekable.
        /// </exception>
        /// <exception cref="RequestFailedException">The service returned a non-success status code.</exception>
        public virtual async Task<Response<VolumePathItem>> UploadVolumeFileAsync(
            string volumeName,
            string path,
            Stream content,
            bool? overwrite = default,
            MatchConditions matchConditions = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
            Argument.AssertNotNullOrEmpty(path, nameof(path));
            RequestContent requestContent = StreamRequestContent.Create(content);

            Response result = await UploadVolumeFileAsync(
                volumeName,
                path,
                requestContent,
                overwrite,
                matchConditions,
                cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((VolumePathItem)result, result);
        }
    }
}
