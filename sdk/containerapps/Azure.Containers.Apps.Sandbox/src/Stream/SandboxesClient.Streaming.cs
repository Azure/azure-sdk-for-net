// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.Apps.Sandbox.Models;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Containers.Apps.Sandbox
{
    [CodeGenSuppress("DownloadSandboxFile", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("DownloadSandboxFileAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("UploadSandboxFile", typeof(string), typeof(string), typeof(BinaryData), typeof(bool?), typeof(int?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("UploadSandboxFileAsync", typeof(string), typeof(string), typeof(BinaryData), typeof(bool?), typeof(int?), typeof(string), typeof(CancellationToken))]
    internal partial class SandboxesClient
    {
        /// <summary> Downloads a sandbox file without buffering the response. The caller must dispose the returned stream. </summary>
        public virtual Response<Stream> DownloadSandboxFile(string id, string path, string containerName = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("SandboxesClient.DownloadSandboxFile");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(id, nameof(id));
                Argument.AssertNotNullOrEmpty(path, nameof(path));
                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateDownloadSandboxFileRequest(id, path, containerName, context);
                message.BufferResponse = false;
                Response response = Pipeline.ProcessMessage(message, context);
                Stream stream = message.ExtractResponseContent() ?? throw new InvalidOperationException("The file response has no content stream.");
                return Response.FromValue(stream, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Downloads a sandbox file without buffering the response. The caller must dispose the returned stream. </summary>
        public virtual async Task<Response<Stream>> DownloadSandboxFileAsync(string id, string path, string containerName = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("SandboxesClient.DownloadSandboxFile");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(id, nameof(id));
                Argument.AssertNotNullOrEmpty(path, nameof(path));
                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateDownloadSandboxFileRequest(id, path, containerName, context);
                message.BufferResponse = false;
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Stream stream = message.ExtractResponseContent() ?? throw new InvalidOperationException("The file response has no content stream.");
                return Response.FromValue(stream, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Uploads a sandbox file from a readable, seekable stream. The caller retains ownership of the stream. </summary>
        public virtual Response<WriteFileResult> UploadSandboxFile(string id, string path, Stream content, bool? createDirs = default, int? mode = default, string containerName = default, CancellationToken cancellationToken = default)
        {
            using RequestContent requestContent = StreamRequestContent.Create(content);
            Response response = UploadSandboxFile(id, path, requestContent, createDirs, mode, containerName, cancellationToken.ToRequestContext());
            return Response.FromValue((WriteFileResult)response, response);
        }

        /// <summary> Uploads a sandbox file from a readable, seekable stream. The caller retains ownership of the stream. </summary>
        public virtual async Task<Response<WriteFileResult>> UploadSandboxFileAsync(string id, string path, Stream content, bool? createDirs = default, int? mode = default, string containerName = default, CancellationToken cancellationToken = default)
        {
            using RequestContent requestContent = StreamRequestContent.Create(content);
            Response response = await UploadSandboxFileAsync(id, path, requestContent, createDirs, mode, containerName, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((WriteFileResult)response, response);
        }
    }
}
