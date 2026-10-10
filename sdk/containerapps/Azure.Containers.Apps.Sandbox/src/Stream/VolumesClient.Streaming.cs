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
    [CodeGenSuppress("DownloadVolumeFile", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("DownloadVolumeFileAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("UploadVolumeFile", typeof(string), typeof(string), typeof(BinaryData), typeof(bool?), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppress("UploadVolumeFileAsync", typeof(string), typeof(string), typeof(BinaryData), typeof(bool?), typeof(MatchConditions), typeof(CancellationToken))]
    internal partial class VolumesClient
    {
        /// <summary> Downloads a volume file without buffering the response. The caller must dispose the returned stream. </summary>
        public virtual Response<Stream> DownloadVolumeFile(string volumeName, string path, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("VolumesClient.DownloadVolumeFile");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
                Argument.AssertNotNullOrEmpty(path, nameof(path));
                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateDownloadVolumeFileRequest(volumeName, path, context);
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

        /// <summary> Downloads a volume file without buffering the response. The caller must dispose the returned stream. </summary>
        public virtual async Task<Response<Stream>> DownloadVolumeFileAsync(string volumeName, string path, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("VolumesClient.DownloadVolumeFile");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
                Argument.AssertNotNullOrEmpty(path, nameof(path));
                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateDownloadVolumeFileRequest(volumeName, path, context);
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

        /// <summary> Uploads a volume file from a readable, seekable stream. The caller retains ownership of the stream. </summary>
        public virtual Response<VolumePathItem> UploadVolumeFile(string volumeName, string path, Stream content, bool? overwrite = default, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            using RequestContent requestContent = StreamRequestContent.Create(content);
            Response response = UploadVolumeFile(volumeName, path, requestContent, overwrite, matchConditions, cancellationToken.ToRequestContext());
            return Response.FromValue((VolumePathItem)response, response);
        }

        /// <summary> Uploads a volume file from a readable, seekable stream. The caller retains ownership of the stream. </summary>
        public virtual async Task<Response<VolumePathItem>> UploadVolumeFileAsync(string volumeName, string path, Stream content, bool? overwrite = default, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            using RequestContent requestContent = StreamRequestContent.Create(content);
            Response response = await UploadVolumeFileAsync(volumeName, path, requestContent, overwrite, matchConditions, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((VolumePathItem)response, response);
        }
    }
}
