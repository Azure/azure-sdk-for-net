// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.Apps.Sandbox.Models;
using Azure.Core;

#nullable enable annotations

namespace Azure.Containers.Apps.Sandbox
{
    /// <summary> A volume scoped to a sandbox group. </summary>
    public partial class VolumeClient
    {
        private readonly VolumesClient _client;

        /// <summary> The name of the volume. </summary>
        public virtual string VolumeName { get; }

        /// <summary> The model returned by the service, or null when this client was created from an identifier alone. </summary>
        public virtual SandboxGroupVolume? Data { get; }

        /// <summary> Initializes a new instance of VolumeClient for mocking. </summary>
        protected VolumeClient()
        {
        }

        internal VolumeClient(VolumesClient client, string volumeName, SandboxGroupVolume? data = null)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));

            _client = client;
            VolumeName = volumeName;
            Data = data;
        }

        /// <summary> Gets the current volume in a new client. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<VolumeClient> Get(CancellationToken cancellationToken = default)
        {
            Response<SandboxGroupVolume> response = _client.GetVolume(VolumeName, cancellationToken);
            return Response.FromValue(new VolumeClient(_client, VolumeName, response.Value), response.GetRawResponse());
        }

        /// <summary> Gets the current volume in a new client asynchronously. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual async Task<Response<VolumeClient>> GetAsync(CancellationToken cancellationToken = default)
        {
            Response<SandboxGroupVolume> response = await _client.GetVolumeAsync(VolumeName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new VolumeClient(_client, VolumeName, response.Value), response.GetRawResponse());
        }

        /// <summary> Deletes a volume by name. Uses this client's name. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response DeleteVolume(RequestContext context)
        {
            return _client.DeleteVolume(VolumeName, context);
        }

        /// <summary> Deletes a volume by name. Uses this client's name. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> DeleteVolumeAsync(RequestContext context)
        {
            return _client.DeleteVolumeAsync(VolumeName, context);
        }

        /// <summary> Deletes a volume by name. Uses this client's name. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response DeleteVolume(CancellationToken cancellationToken = default)
        {
            return _client.DeleteVolume(VolumeName, cancellationToken);
        }

        /// <summary> Deletes a volume by name. Uses this client's name. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response> DeleteVolumeAsync(CancellationToken cancellationToken = default)
        {
            return _client.DeleteVolumeAsync(VolumeName, cancellationToken);
        }

        /// <summary> Delete a file or directory from a volume. Uses this client's name. </summary>
        /// <param name="path"> The file or directory path to delete. </param>
        /// <param name="recursive"> Whether to delete a directory and all of its contents. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response DeleteVolumeFile(string path, bool? recursive, RequestContext context)
        {
            return _client.DeleteVolumeFile(VolumeName, path, recursive, context);
        }

        /// <summary> Delete a file or directory from a volume. Uses this client's name. </summary>
        /// <param name="path"> The file or directory path to delete. </param>
        /// <param name="recursive"> Whether to delete a directory and all of its contents. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> DeleteVolumeFileAsync(string path, bool? recursive, RequestContext context)
        {
            return _client.DeleteVolumeFileAsync(VolumeName, path, recursive, context);
        }

        /// <summary> Delete a file or directory from a volume. Uses this client's name. </summary>
        /// <param name="path"> The file or directory path to delete. </param>
        /// <param name="recursive"> Whether to delete a directory and all of its contents. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response DeleteVolumeFile(string path, bool? recursive = default, CancellationToken cancellationToken = default)
        {
            return _client.DeleteVolumeFile(VolumeName, path, recursive, cancellationToken);
        }

        /// <summary> Delete a file or directory from a volume. Uses this client's name. </summary>
        /// <param name="path"> The file or directory path to delete. </param>
        /// <param name="recursive"> Whether to delete a directory and all of its contents. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response> DeleteVolumeFileAsync(string path, bool? recursive = default, CancellationToken cancellationToken = default)
        {
            return _client.DeleteVolumeFileAsync(VolumeName, path, recursive, cancellationToken);
        }

        /// <summary> Gets a specific volume by name. Uses this client's name. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GetVolume(RequestContext context)
        {
            return _client.GetVolume(VolumeName, context);
        }

        /// <summary> Gets a specific volume by name. Uses this client's name. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GetVolumeAsync(RequestContext context)
        {
            return _client.GetVolumeAsync(VolumeName, context);
        }

        /// <summary> Gets a specific volume by name. Uses this client's name. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxGroupVolume> GetVolume(CancellationToken cancellationToken = default)
        {
            return _client.GetVolume(VolumeName, cancellationToken);
        }

        /// <summary> Gets a specific volume by name. Uses this client's name. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxGroupVolume>> GetVolumeAsync(CancellationToken cancellationToken = default)
        {
            return _client.GetVolumeAsync(VolumeName, cancellationToken);
        }

        /// <summary> List directory contents within a volume. Uses this client's name. </summary>
        /// <param name="path"> The directory path to list. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GetVolumeFilesMetadata(string path, RequestContext context)
        {
            return _client.GetVolumeFilesMetadata(VolumeName, path, context);
        }

        /// <summary> List directory contents within a volume. Uses this client's name. </summary>
        /// <param name="path"> The directory path to list. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GetVolumeFilesMetadataAsync(string path, RequestContext context)
        {
            return _client.GetVolumeFilesMetadataAsync(VolumeName, path, context);
        }

        /// <summary> List directory contents within a volume. Uses this client's name. </summary>
        /// <param name="path"> The directory path to list. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<VolumeListDirectoryResult> GetVolumeFilesMetadata(string path = default, CancellationToken cancellationToken = default)
        {
            return _client.GetVolumeFilesMetadata(VolumeName, path, cancellationToken);
        }

        /// <summary> List directory contents within a volume. Uses this client's name. </summary>
        /// <param name="path"> The directory path to list. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<VolumeListDirectoryResult>> GetVolumeFilesMetadataAsync(string path = default, CancellationToken cancellationToken = default)
        {
            return _client.GetVolumeFilesMetadataAsync(VolumeName, path, cancellationToken);
        }

        /// <summary> Downloads a volume file without buffering the response. The caller must dispose the returned stream. </summary>
        /// <param name="path"> The path of the file to download. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<Stream> DownloadVolumeFile(string path, CancellationToken cancellationToken = default) =>
            _client.DownloadVolumeFile(VolumeName, path, cancellationToken);

        /// <summary> Downloads a volume file without buffering the response. The caller must dispose the returned stream. </summary>
        /// <param name="path"> The path of the file to download. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<Stream>> DownloadVolumeFileAsync(string path, CancellationToken cancellationToken = default) =>
            _client.DownloadVolumeFileAsync(VolumeName, path, cancellationToken);

        /// <summary> Create a directory within a volume. Uses this client's name. </summary>
        /// <param name="path"> The directory path to create. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response CreateVolumeDirectory(string path, RequestContext context)
        {
            return _client.CreateVolumeDirectory(VolumeName, path, context);
        }

        /// <summary> Create a directory within a volume. Uses this client's name. </summary>
        /// <param name="path"> The directory path to create. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> CreateVolumeDirectoryAsync(string path, RequestContext context)
        {
            return _client.CreateVolumeDirectoryAsync(VolumeName, path, context);
        }

        /// <summary> Create a directory within a volume. Uses this client's name. </summary>
        /// <param name="path"> The directory path to create. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<VolumePathItem> CreateVolumeDirectory(string path, CancellationToken cancellationToken = default)
        {
            return _client.CreateVolumeDirectory(VolumeName, path, cancellationToken);
        }

        /// <summary> Create a directory within a volume. Uses this client's name. </summary>
        /// <param name="path"> The directory path to create. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<VolumePathItem>> CreateVolumeDirectoryAsync(string path, CancellationToken cancellationToken = default)
        {
            return _client.CreateVolumeDirectoryAsync(VolumeName, path, cancellationToken);
        }

        /// <summary> Forks a data disk volume. Uses this client's name. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response ForkVolume(RequestContent content, RequestContext context = null)
        {
            return _client.ForkVolume(VolumeName, content, context);
        }

        /// <summary> Forks a data disk volume. Uses this client's name. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> ForkVolumeAsync(RequestContent content, RequestContext context = null)
        {
            return _client.ForkVolumeAsync(VolumeName, content, context);
        }

        /// <summary> Forks a data disk volume. Uses this client's name. </summary>
        /// <param name="body"> The destination name and labels for the forked volume. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxGroupVolume> ForkVolume(ForkDataDiskVolumeContent body, CancellationToken cancellationToken = default)
        {
            return _client.ForkVolume(VolumeName, body, cancellationToken);
        }

        /// <summary> Forks a data disk volume. Uses this client's name. </summary>
        /// <param name="body"> The destination name and labels for the forked volume. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxGroupVolume>> ForkVolumeAsync(ForkDataDiskVolumeContent body, CancellationToken cancellationToken = default)
        {
            return _client.ForkVolumeAsync(VolumeName, body, cancellationToken);
        }

        /// <summary> Creates a new volume. Uses this client's name. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response CreateVolume(RequestContent content, RequestContext context = null)
        {
            return _client.CreateVolume(VolumeName, content, context);
        }

        /// <summary> Creates a new volume. Uses this client's name. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> CreateVolumeAsync(RequestContent content, RequestContext context = null)
        {
            return _client.CreateVolumeAsync(VolumeName, content, context);
        }

        /// <summary> Creates a new volume. Uses this client's name. </summary>
        /// <param name="body"> The volume configuration to create. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxGroupVolume> CreateVolume(SandboxGroupVolume body, CancellationToken cancellationToken = default)
        {
            return _client.CreateVolume(VolumeName, body, cancellationToken);
        }

        /// <summary> Creates a new volume. Uses this client's name. </summary>
        /// <param name="body"> The volume configuration to create. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxGroupVolume>> CreateVolumeAsync(SandboxGroupVolume body, CancellationToken cancellationToken = default)
        {
            return _client.CreateVolumeAsync(VolumeName, body, cancellationToken);
        }

        /// <summary> Uploads a volume file from a readable, seekable stream. The caller retains ownership of the stream. </summary>
        /// <param name="path"> The destination path of the file. </param>
        /// <param name="content"> The content to upload. </param>
        /// <param name="overwrite"> Whether to overwrite an existing file. </param>
        /// <param name="matchConditions"> The request conditions. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<VolumePathItem> UploadVolumeFile(string path, Stream content, bool? overwrite = default, MatchConditions matchConditions = default, CancellationToken cancellationToken = default) =>
            _client.UploadVolumeFile(VolumeName, path, content, overwrite, matchConditions, cancellationToken);

        /// <summary> Uploads a volume file from a readable, seekable stream. The caller retains ownership of the stream. </summary>
        /// <param name="path"> The destination path of the file. </param>
        /// <param name="content"> The content to upload. </param>
        /// <param name="overwrite"> Whether to overwrite an existing file. </param>
        /// <param name="matchConditions"> The request conditions. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<VolumePathItem>> UploadVolumeFileAsync(string path, Stream content, bool? overwrite = default, MatchConditions matchConditions = default, CancellationToken cancellationToken = default) =>
            _client.UploadVolumeFileAsync(VolumeName, path, content, overwrite, matchConditions, cancellationToken);
    }
}
