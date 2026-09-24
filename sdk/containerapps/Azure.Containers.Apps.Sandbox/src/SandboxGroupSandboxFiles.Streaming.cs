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
    public partial class SandboxGroupSandboxFiles
    {
        /// <summary>
        /// Reads a file from a running sandbox without buffering the response body.
        /// </summary>
        /// <param name="path">The file path to download.</param>
        /// <param name="containerName">The target container name.</param>
        /// <param name="cancellationToken">The cancellation token that can be used to cancel the operation.</param>
        /// <returns>
        /// A response whose value is the response body stream. The caller must dispose the returned stream.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="path"/> is empty.</exception>
        /// <exception cref="RequestFailedException">The service returned a non-success status code.</exception>
        public virtual Response<Stream> DownloadSandboxFileStreaming(
            string path,
            string containerName = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("SandboxGroupSandboxFiles.DownloadSandboxFileStreaming");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(path, nameof(path));

                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateDownloadSandboxFileRequest(path, containerName, context);
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
        /// Reads a file from a running sandbox without buffering the response body.
        /// </summary>
        /// <param name="path">The file path to download.</param>
        /// <param name="containerName">The target container name.</param>
        /// <param name="cancellationToken">The cancellation token that can be used to cancel the operation.</param>
        /// <returns>
        /// A response whose value is the response body stream. The caller must dispose the returned stream.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="path"/> is empty.</exception>
        /// <exception cref="RequestFailedException">The service returned a non-success status code.</exception>
        public virtual async Task<Response<Stream>> DownloadSandboxFileStreamingAsync(
            string path,
            string containerName = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("SandboxGroupSandboxFiles.DownloadSandboxFileStreaming");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(path, nameof(path));

                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateDownloadSandboxFileRequest(path, containerName, context);
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
        /// Writes a file to a running sandbox from a stream.
        /// </summary>
        /// <param name="path">The destination file path.</param>
        /// <param name="content">
        /// The readable, seekable stream to upload. Upload starts at the stream's current position.
        /// The stream remains open after the operation completes.
        /// </param>
        /// <param name="createDirs">Whether to create missing parent directories.</param>
        /// <param name="mode">The Unix mode for the uploaded file.</param>
        /// <param name="containerName">The target container name.</param>
        /// <param name="cancellationToken">The cancellation token that can be used to cancel the operation.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> or <paramref name="content"/> is null.</exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="path"/> is empty, or <paramref name="content"/> is not readable and seekable.
        /// </exception>
        /// <exception cref="RequestFailedException">The service returned a non-success status code.</exception>
        public virtual Response<WriteFileResult> UploadSandboxFile(
            string path,
            Stream content,
            bool? createDirs = default,
            int? mode = default,
            string containerName = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(path, nameof(path));
            RequestContent requestContent = StreamRequestContent.Create(content);

            Response result = UploadSandboxFile(
                path,
                requestContent,
                createDirs,
                mode,
                containerName,
                cancellationToken.ToRequestContext());
            return Response.FromValue((WriteFileResult)result, result);
        }

        /// <summary>
        /// Writes a file to a running sandbox from a stream.
        /// </summary>
        /// <param name="path">The destination file path.</param>
        /// <param name="content">
        /// The readable, seekable stream to upload. Upload starts at the stream's current position.
        /// The stream remains open after the operation completes.
        /// </param>
        /// <param name="createDirs">Whether to create missing parent directories.</param>
        /// <param name="mode">The Unix mode for the uploaded file.</param>
        /// <param name="containerName">The target container name.</param>
        /// <param name="cancellationToken">The cancellation token that can be used to cancel the operation.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> or <paramref name="content"/> is null.</exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="path"/> is empty, or <paramref name="content"/> is not readable and seekable.
        /// </exception>
        /// <exception cref="RequestFailedException">The service returned a non-success status code.</exception>
        public virtual async Task<Response<WriteFileResult>> UploadSandboxFileAsync(
            string path,
            Stream content,
            bool? createDirs = default,
            int? mode = default,
            string containerName = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(path, nameof(path));
            RequestContent requestContent = StreamRequestContent.Create(content);

            Response result = await UploadSandboxFileAsync(
                path,
                requestContent,
                createDirs,
                mode,
                containerName,
                cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((WriteFileResult)result, result);
        }
    }
}
