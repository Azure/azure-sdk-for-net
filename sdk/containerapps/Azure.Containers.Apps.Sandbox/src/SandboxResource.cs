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
    /// <summary> A sandbox scoped to a sandbox group. </summary>
    public partial class SandboxResource
    {
        private readonly SandboxesClient _client;

        /// <summary> The identifier of the sandbox. </summary>
        public virtual string Id { get; }

        /// <summary> The model returned by the service, or null when this client was created from an identifier alone. </summary>
        public virtual SandboxProperties? Data { get; }

        /// <summary> Initializes a new instance of SandboxResource for mocking. </summary>
        protected SandboxResource()
        {
        }

        internal SandboxResource(SandboxesClient client, string id, SandboxProperties? data = null)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            _client = client;
            Id = id;
            Data = data;
        }

        /// <summary> Gets the current sandbox properties in a new resource client. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxResource> Get(CancellationToken cancellationToken = default)
        {
            Response<SandboxProperties> response = _client.GetProperties(Id, cancellationToken);
            return Response.FromValue(new SandboxResource(_client, Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Gets the current sandbox properties in a new resource client asynchronously. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual async Task<Response<SandboxResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            Response<SandboxProperties> response = await _client.GetPropertiesAsync(Id, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new SandboxResource(_client, Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Gets a sandbox by identifier. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GetProperties(RequestContext context)
        {
            return _client.GetProperties(Id, context);
        }

        /// <summary> Gets a sandbox by identifier. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GetPropertiesAsync(RequestContext context)
        {
            return _client.GetPropertiesAsync(Id, context);
        }

        /// <summary> Gets a sandbox by identifier. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxProperties> GetProperties(CancellationToken cancellationToken = default)
        {
            return _client.GetProperties(Id, cancellationToken);
        }

        /// <summary> Gets a sandbox by identifier. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxProperties>> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            return _client.GetPropertiesAsync(Id, cancellationToken);
        }

        /// <summary> Deletes a sandbox by identifier. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response Delete(RequestContext context)
        {
            return _client.Delete(Id, context);
        }

        /// <summary> Deletes a sandbox by identifier. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> DeleteAsync(RequestContext context)
        {
            return _client.DeleteAsync(Id, context);
        }

        /// <summary> Deletes a sandbox by identifier. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response Delete(CancellationToken cancellationToken = default)
        {
            return _client.Delete(Id, cancellationToken);
        }

        /// <summary> Deletes a sandbox by identifier. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return _client.DeleteAsync(Id, cancellationToken);
        }

        /// <summary> Deletes a file or directory in a running sandbox. If the target is a directory, the `recursive` query parameter must be set to true to delete it and its contents. Uses this sandbox's identifier. </summary>
        /// <param name="path"> The file or directory path to delete. </param>
        /// <param name="recursive"> Whether to delete a directory and all of its contents. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response DeleteSandboxFile(string path, bool? recursive, string containerName, RequestContext context)
        {
            return _client.DeleteSandboxFile(Id, path, recursive, containerName, context);
        }

        /// <summary> Deletes a file or directory in a running sandbox. If the target is a directory, the `recursive` query parameter must be set to true to delete it and its contents. Uses this sandbox's identifier. </summary>
        /// <param name="path"> The file or directory path to delete. </param>
        /// <param name="recursive"> Whether to delete a directory and all of its contents. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> DeleteSandboxFileAsync(string path, bool? recursive, string containerName, RequestContext context)
        {
            return _client.DeleteSandboxFileAsync(Id, path, recursive, containerName, context);
        }

        /// <summary> Deletes a file or directory in a running sandbox. If the target is a directory, the `recursive` query parameter must be set to true to delete it and its contents. Uses this sandbox's identifier. </summary>
        /// <param name="path"> The file or directory path to delete. </param>
        /// <param name="recursive"> Whether to delete a directory and all of its contents. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxFileOperationResult> DeleteSandboxFile(string path, bool? recursive = default, string containerName = default, CancellationToken cancellationToken = default)
        {
            return _client.DeleteSandboxFile(Id, path, recursive, containerName, cancellationToken);
        }

        /// <summary> Deletes a file or directory in a running sandbox. If the target is a directory, the `recursive` query parameter must be set to true to delete it and its contents. Uses this sandbox's identifier. </summary>
        /// <param name="path"> The file or directory path to delete. </param>
        /// <param name="recursive"> Whether to delete a directory and all of its contents. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxFileOperationResult>> DeleteSandboxFileAsync(string path, bool? recursive = default, string containerName = default, CancellationToken cancellationToken = default)
        {
            return _client.DeleteSandboxFileAsync(Id, path, recursive, containerName, cancellationToken);
        }

        /// <summary> Downloads a sandbox file without buffering the response. The caller must dispose the returned stream. </summary>
        /// <param name="path"> The path of the file to download. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<Stream> DownloadSandboxFile(string path, string containerName = default, CancellationToken cancellationToken = default) =>
            _client.DownloadSandboxFile(Id, path, containerName, cancellationToken);

        /// <summary> Downloads a sandbox file without buffering the response. The caller must dispose the returned stream. </summary>
        /// <param name="path"> The path of the file to download. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<Stream>> DownloadSandboxFileAsync(string path, string containerName = default, CancellationToken cancellationToken = default) =>
            _client.DownloadSandboxFileAsync(Id, path, containerName, cancellationToken);

        /// <summary> Lists the contents of a directory in a running sandbox. The response includes file and directory names, sizes, and metadata. Uses this sandbox's identifier. </summary>
        /// <param name="path"> The directory path to list. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GetSandboxFilesMetadata(string path, string containerName, RequestContext context)
        {
            return _client.GetSandboxFilesMetadata(Id, path, containerName, context);
        }

        /// <summary> Lists the contents of a directory in a running sandbox. The response includes file and directory names, sizes, and metadata. Uses this sandbox's identifier. </summary>
        /// <param name="path"> The directory path to list. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GetSandboxFilesMetadataAsync(string path, string containerName, RequestContext context)
        {
            return _client.GetSandboxFilesMetadataAsync(Id, path, containerName, context);
        }

        /// <summary> Lists the contents of a directory in a running sandbox. The response includes file and directory names, sizes, and metadata. Uses this sandbox's identifier. </summary>
        /// <param name="path"> The directory path to list. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxDirectoryListingResult> GetSandboxFilesMetadata(string path, string containerName = default, CancellationToken cancellationToken = default)
        {
            return _client.GetSandboxFilesMetadata(Id, path, containerName, cancellationToken);
        }

        /// <summary> Lists the contents of a directory in a running sandbox. The response includes file and directory names, sizes, and metadata. Uses this sandbox's identifier. </summary>
        /// <param name="path"> The directory path to list. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxDirectoryListingResult>> GetSandboxFilesMetadataAsync(string path, string containerName = default, CancellationToken cancellationToken = default)
        {
            return _client.GetSandboxFilesMetadataAsync(Id, path, containerName, cancellationToken);
        }

        /// <summary> Gets metadata for a file or directory in a running sandbox, including size, permissions, and timestamps. Uses this sandbox's identifier. </summary>
        /// <param name="path"> The file or directory path to inspect. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GetSandboxFileMetadata(string path, string containerName, RequestContext context)
        {
            return _client.GetSandboxFileMetadata(Id, path, containerName, context);
        }

        /// <summary> Gets metadata for a file or directory in a running sandbox, including size, permissions, and timestamps. Uses this sandbox's identifier. </summary>
        /// <param name="path"> The file or directory path to inspect. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GetSandboxFileMetadataAsync(string path, string containerName, RequestContext context)
        {
            return _client.GetSandboxFileMetadataAsync(Id, path, containerName, context);
        }

        /// <summary> Gets metadata for a file or directory in a running sandbox, including size, permissions, and timestamps. Uses this sandbox's identifier. </summary>
        /// <param name="path"> The file or directory path to inspect. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxFileInfo> GetSandboxFileMetadata(string path, string containerName = default, CancellationToken cancellationToken = default)
        {
            return _client.GetSandboxFileMetadata(Id, path, containerName, cancellationToken);
        }

        /// <summary> Gets metadata for a file or directory in a running sandbox, including size, permissions, and timestamps. Uses this sandbox's identifier. </summary>
        /// <param name="path"> The file or directory path to inspect. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxFileInfo>> GetSandboxFileMetadataAsync(string path, string containerName = default, CancellationToken cancellationToken = default)
        {
            return _client.GetSandboxFileMetadataAsync(Id, path, containerName, cancellationToken);
        }

        /// <summary> Creates a directory in a running sandbox. If the `createParents` property is set to true, any missing parent directories will also be created. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response CreateSandboxDirectory(RequestContent content, string containerName = default, RequestContext context = null)
        {
            return _client.CreateSandboxDirectory(Id, content, containerName, context);
        }

        /// <summary> Creates a directory in a running sandbox. If the `createParents` property is set to true, any missing parent directories will also be created. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> CreateSandboxDirectoryAsync(RequestContent content, string containerName = default, RequestContext context = null)
        {
            return _client.CreateSandboxDirectoryAsync(Id, content, containerName, context);
        }

        /// <summary> Creates a directory in a running sandbox. If the `createParents` property is set to true, any missing parent directories will also be created. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The directory path and creation options. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxFileOperationResult> CreateSandboxDirectory(SandboxDirectoryContent body, string containerName = default, CancellationToken cancellationToken = default)
        {
            return _client.CreateSandboxDirectory(Id, body, containerName, cancellationToken);
        }

        /// <summary> Creates a directory in a running sandbox. If the `createParents` property is set to true, any missing parent directories will also be created. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The directory path and creation options. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxFileOperationResult>> CreateSandboxDirectoryAsync(SandboxDirectoryContent body, string containerName = default, CancellationToken cancellationToken = default)
        {
            return _client.CreateSandboxDirectoryAsync(Id, body, containerName, cancellationToken);
        }

        /// <summary> Uploads a sandbox file from a readable, seekable stream. The caller retains ownership of the stream. </summary>
        /// <param name="path"> The destination path of the file. </param>
        /// <param name="content"> The content to upload. </param>
        /// <param name="createDirs"> Whether to create missing parent directories. </param>
        /// <param name="mode"> The file permissions. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<WriteFileResult> UploadSandboxFile(string path, Stream content, bool? createDirs = default, int? mode = default, string containerName = default, CancellationToken cancellationToken = default) =>
            _client.UploadSandboxFile(Id, path, content, createDirs, mode, containerName, cancellationToken);

        /// <summary> Uploads a sandbox file from a readable, seekable stream. The caller retains ownership of the stream. </summary>
        /// <param name="path"> The destination path of the file. </param>
        /// <param name="content"> The content to upload. </param>
        /// <param name="createDirs"> Whether to create missing parent directories. </param>
        /// <param name="mode"> The file permissions. </param>
        /// <param name="containerName"> The target container name. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<WriteFileResult>> UploadSandboxFileAsync(string path, Stream content, bool? createDirs = default, int? mode = default, string containerName = default, CancellationToken cancellationToken = default) =>
            _client.UploadSandboxFileAsync(Id, path, content, createDirs, mode, containerName, cancellationToken);

        /// <summary> Opens an interactive exec WebSocket connection for this sandbox. Dispose the returned stream. </summary>
        /// <param name="containerName"> The container where the session runs. </param>
        /// <param name="user"> The optional user for the session. </param>
        /// <param name="cancellationToken"> The cancellation token for connecting. </param>
        public virtual Task<SandboxStream> ConnectToSandboxExecStreamAsync(string containerName = default, string user = default, CancellationToken cancellationToken = default) =>
            _client.ConnectToSandboxExecStreamAsync(Id, containerName, user, cancellationToken);

        /// <summary> Opens and starts an interactive exec session for this sandbox. Dispose the returned session. </summary>
        /// <param name="request"> The initial WebSocket exec configuration. </param>
        /// <param name="containerName"> The container where the session runs. </param>
        /// <param name="cancellationToken"> The cancellation token for connecting and sending the start message. </param>
        public virtual Task<SandboxExecSession> StartSandboxExecSessionAsync(SandboxExecStartRequest request, string containerName = default, CancellationToken cancellationToken = default) =>
            _client.StartSandboxExecSessionAsync(Id, request, containerName, cancellationToken);

        /// <summary> Opens an unbuffered HTTP log stream for this sandbox. Dispose the returned stream. </summary>
        /// <param name="tailLines"> The number of previous log lines. </param>
        /// <param name="logFormat"> The format of the log records. </param>
        /// <param name="follow"> Whether to follow new log records. </param>
        /// <param name="containerName"> The container whose logs are streamed. </param>
        /// <param name="cancellationToken"> The cancellation token for connecting. </param>
        public virtual Task<Response<Stream>> OpenSandboxLogStreamAsync(int tailLines = 100, SandboxLogFormat logFormat = SandboxLogFormat.Text, bool follow = true, string containerName = default, CancellationToken cancellationToken = default) =>
            _client.OpenSandboxLogStreamAsync(Id, tailLines, logFormat, follow, containerName, cancellationToken);

        /// <summary> Opens a read-only stream of process snapshots for this sandbox. Dispose the returned stream. </summary>
        /// <param name="containerName"> The container whose processes are streamed. </param>
        /// <param name="cancellationToken"> The cancellation token for connecting. </param>
        public virtual Task<SandboxProcessStream> OpenSandboxProcessStreamAsync(string containerName = default, CancellationToken cancellationToken = default) =>
            _client.OpenSandboxProcessStreamAsync(Id, containerName, cancellationToken);

        /// <summary> Opens a process WebSocket connection for this sandbox. Dispose the returned stream. </summary>
        /// <param name="containerName"> The container whose processes are streamed. </param>
        /// <param name="cancellationToken"> The cancellation token for connecting. </param>
        public virtual Task<SandboxStream> ConnectToSandboxProcessesStreamAsync(string containerName = default, CancellationToken cancellationToken = default) =>
            _client.ConnectToSandboxProcessesStreamAsync(Id, containerName, cancellationToken);

        /// <summary> Gets egress decisions for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GetEgressDecisions(RequestContext context)
        {
            return _client.GetEgressDecisions(Id, context);
        }

        /// <summary> Gets egress decisions for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GetEgressDecisionsAsync(RequestContext context)
        {
            return _client.GetEgressDecisionsAsync(Id, context);
        }

        /// <summary> Gets egress decisions for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<EgressDecisionsResult> GetEgressDecisions(CancellationToken cancellationToken = default)
        {
            return _client.GetEgressDecisions(Id, cancellationToken);
        }

        /// <summary> Gets egress decisions for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<EgressDecisionsResult>> GetEgressDecisionsAsync(CancellationToken cancellationToken = default)
        {
            return _client.GetEgressDecisionsAsync(Id, cancellationToken);
        }

        /// <summary> Gets the list of ports for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GetPorts(RequestContext context)
        {
            return _client.GetPorts(Id, context);
        }

        /// <summary> Gets the list of ports for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GetPortsAsync(RequestContext context)
        {
            return _client.GetPortsAsync(Id, context);
        }

        /// <summary> Gets the list of ports for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<PortsListResult> GetPorts(CancellationToken cancellationToken = default)
        {
            return _client.GetPorts(Id, cancellationToken);
        }

        /// <summary> Gets the list of ports for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<PortsListResult>> GetPortsAsync(CancellationToken cancellationToken = default)
        {
            return _client.GetPortsAsync(Id, cancellationToken);
        }

        /// <summary> Updates a single port on a sandbox (partial update). Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response UpdatePort(RequestContent content, RequestContext context = null)
        {
            return _client.UpdatePort(Id, content, context);
        }

        /// <summary> Updates a single port on a sandbox (partial update). Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> UpdatePortAsync(RequestContent content, RequestContext context = null)
        {
            return _client.UpdatePortAsync(Id, content, context);
        }

        /// <summary> Adds a connection to a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response AddConnection(RequestContent content, RequestContext context = null)
        {
            return _client.AddConnection(Id, content, context);
        }

        /// <summary> Adds a connection to a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> AddConnectionAsync(RequestContent content, RequestContext context = null)
        {
            return _client.AddConnectionAsync(Id, content, context);
        }

        /// <summary> Adds a connection to a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The connection to attach to the sandbox. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<ConnectionsListResult> AddConnection(AddConnectionContent body, CancellationToken cancellationToken = default)
        {
            return _client.AddConnection(Id, body, cancellationToken);
        }

        /// <summary> Adds a connection to a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The connection to attach to the sandbox. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<ConnectionsListResult>> AddConnectionAsync(AddConnectionContent body, CancellationToken cancellationToken = default)
        {
            return _client.AddConnectionAsync(Id, body, cancellationToken);
        }

        /// <summary> Sets the egress policy for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response SetEgressPolicy(RequestContent content, RequestContext context = null)
        {
            return _client.SetEgressPolicy(Id, content, context);
        }

        /// <summary> Sets the egress policy for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> SetEgressPolicyAsync(RequestContent content, RequestContext context = null)
        {
            return _client.SetEgressPolicyAsync(Id, content, context);
        }

        /// <summary> Sets the egress policy for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The egress policy to apply to the sandbox. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxEgressPolicy> SetEgressPolicy(SandboxEgressPolicy body, CancellationToken cancellationToken = default)
        {
            return _client.SetEgressPolicy(Id, body, cancellationToken);
        }

        /// <summary> Sets the egress policy for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The egress policy to apply to the sandbox. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxEgressPolicy>> SetEgressPolicyAsync(SandboxEgressPolicy body, CancellationToken cancellationToken = default)
        {
            return _client.SetEgressPolicyAsync(Id, body, cancellationToken);
        }

        /// <summary> Adds a port to a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response AddPort(RequestContent content, RequestContext context = null)
        {
            return _client.AddPort(Id, content, context);
        }

        /// <summary> Adds a port to a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> AddPortAsync(RequestContent content, RequestContext context = null)
        {
            return _client.AddPortAsync(Id, content, context);
        }

        /// <summary> Adds a port to a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The port configuration to add. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<PortsListResult> AddPort(CreateSandboxPortContent body, CancellationToken cancellationToken = default)
        {
            return _client.AddPort(Id, body, cancellationToken);
        }

        /// <summary> Adds a port to a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The port configuration to add. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<PortsListResult>> AddPortAsync(CreateSandboxPortContent body, CancellationToken cancellationToken = default)
        {
            return _client.AddPortAsync(Id, body, cancellationToken);
        }

        /// <summary> Removes a port from a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response RemovePort(RequestContent content, RequestContext context = null)
        {
            return _client.RemovePort(Id, content, context);
        }

        /// <summary> Removes a port from a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> RemovePortAsync(RequestContent content, RequestContext context = null)
        {
            return _client.RemovePortAsync(Id, content, context);
        }

        /// <summary> Removes a port from a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The name or number of the port to remove. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<PortsListResult> RemovePort(RemovePortContent body, CancellationToken cancellationToken = default)
        {
            return _client.RemovePort(Id, body, cancellationToken);
        }

        /// <summary> Removes a port from a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The name or number of the port to remove. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<PortsListResult>> RemovePortAsync(RemovePortContent body, CancellationToken cancellationToken = default)
        {
            return _client.RemovePortAsync(Id, body, cancellationToken);
        }

        /// <summary> Updates all ports for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response SetPorts(RequestContent content, RequestContext context = null)
        {
            return _client.SetPorts(Id, content, context);
        }

        /// <summary> Updates all ports for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> SetPortsAsync(RequestContent content, RequestContext context = null)
        {
            return _client.SetPortsAsync(Id, content, context);
        }

        /// <summary> Updates all ports for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The complete port configuration for the sandbox. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<PortsListResult> SetPorts(UpdatePortsContent body, CancellationToken cancellationToken = default)
        {
            return _client.SetPorts(Id, body, cancellationToken);
        }

        /// <summary> Updates all ports for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The complete port configuration for the sandbox. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<PortsListResult>> SetPortsAsync(UpdatePortsContent body, CancellationToken cancellationToken = default)
        {
            return _client.SetPortsAsync(Id, body, cancellationToken);
        }

        /// <summary> Commits a running sandbox as a new disk image. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response Commit(RequestContent content, RequestContext context = null)
        {
            return _client.Commit(Id, content, context);
        }

        /// <summary> Commits a running sandbox as a new disk image. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> CommitAsync(RequestContent content, RequestContext context = null)
        {
            return _client.CommitAsync(Id, content, context);
        }

        /// <summary> Commits a running sandbox as a new disk image. Uses this sandbox's identifier. </summary>
        /// <param name="body"> Optional labels for the new disk image. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<CommitSandboxResult> Commit(CommitSandboxContent body = default, CancellationToken cancellationToken = default)
        {
            return _client.Commit(Id, body, cancellationToken);
        }

        /// <summary> Commits a running sandbox as a new disk image. Uses this sandbox's identifier. </summary>
        /// <param name="body"> Optional labels for the new disk image. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<CommitSandboxResult>> CommitAsync(CommitSandboxContent body = default, CancellationToken cancellationToken = default)
        {
            return _client.CommitAsync(Id, body, cancellationToken);
        }

        /// <summary> Downloads a content package to a running sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response DownloadContentPackage(RequestContent content, RequestContext context = null)
        {
            return _client.DownloadContentPackage(Id, content, context);
        }

        /// <summary> Downloads a content package to a running sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> DownloadContentPackageAsync(RequestContent content, RequestContext context = null)
        {
            return _client.DownloadContentPackageAsync(Id, content, context);
        }

        /// <summary> Downloads a content package to a running sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The content package and destination path. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response DownloadContentPackage(DownloadContentPackageToSandboxContent body, CancellationToken cancellationToken = default)
        {
            return _client.DownloadContentPackage(Id, body, cancellationToken);
        }

        /// <summary> Downloads a content package to a running sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The content package and destination path. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response> DownloadContentPackageAsync(DownloadContentPackageToSandboxContent body, CancellationToken cancellationToken = default)
        {
            return _client.DownloadContentPackageAsync(Id, body, cancellationToken);
        }

        /// <summary> Adds pod volume mounts to a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response AddPodVolumeMounts(RequestContent content, RequestContext context = null)
        {
            return _client.AddPodVolumeMounts(Id, content, context);
        }

        /// <summary> Adds pod volume mounts to a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> AddPodVolumeMountsAsync(RequestContent content, RequestContext context = null)
        {
            return _client.AddPodVolumeMountsAsync(Id, content, context);
        }

        /// <summary> Adds pod volume mounts to a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The pod volumes and container mounts to add. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response AddPodVolumeMounts(PodVolumeMountsContent body, CancellationToken cancellationToken = default)
        {
            return _client.AddPodVolumeMounts(Id, body, cancellationToken);
        }

        /// <summary> Adds pod volume mounts to a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The pod volumes and container mounts to add. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response> AddPodVolumeMountsAsync(PodVolumeMountsContent body, CancellationToken cancellationToken = default)
        {
            return _client.AddPodVolumeMountsAsync(Id, body, cancellationToken);
        }

        /// <summary> Takes a snapshot of a running sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response CreateSnapshot(RequestContent content, RequestContext context = null)
        {
            return _client.CreateSnapshot(Id, content, context);
        }

        /// <summary> Takes a snapshot of a running sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> CreateSnapshotAsync(RequestContent content, RequestContext context = null)
        {
            return _client.CreateSnapshotAsync(Id, content, context);
        }

        /// <summary> Takes a snapshot of a running sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> Labels for the new snapshot. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxSnapshot> CreateSnapshot(CreateSnapshotContent body, CancellationToken cancellationToken = default)
        {
            return _client.CreateSnapshot(Id, body, cancellationToken);
        }

        /// <summary> Takes a snapshot of a running sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> Labels for the new snapshot. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxSnapshot>> CreateSnapshotAsync(CreateSnapshotContent body, CancellationToken cancellationToken = default)
        {
            return _client.CreateSnapshotAsync(Id, body, cancellationToken);
        }

        /// <summary> Adds a volume mount to a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="containerName"> The container that receives the mount. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response AddVolumeMount(RequestContent content, string containerName = default, RequestContext context = null)
        {
            return _client.AddVolumeMount(Id, content, containerName, context);
        }

        /// <summary> Adds a volume mount to a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="containerName"> The container that receives the mount. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> AddVolumeMountAsync(RequestContent content, string containerName = default, RequestContext context = null)
        {
            return _client.AddVolumeMountAsync(Id, content, containerName, context);
        }

        /// <summary> Adds a volume mount to a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The volume mount to add. </param>
        /// <param name="containerName"> The container that receives the mount. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response AddVolumeMount(SandboxVolumeMountContent body, string containerName = default, CancellationToken cancellationToken = default)
        {
            return _client.AddVolumeMount(Id, body, containerName, cancellationToken);
        }

        /// <summary> Adds a volume mount to a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The volume mount to add. </param>
        /// <param name="containerName"> The container that receives the mount. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response> AddVolumeMountAsync(SandboxVolumeMountContent body, string containerName = default, CancellationToken cancellationToken = default)
        {
            return _client.AddVolumeMountAsync(Id, body, containerName, cancellationToken);
        }

        /// <summary> Gets resource usage statistics for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GetStats(RequestContext context)
        {
            return _client.GetStats(Id, context);
        }

        /// <summary> Gets resource usage statistics for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GetStatsAsync(RequestContext context)
        {
            return _client.GetStatsAsync(Id, context);
        }

        /// <summary> Gets resource usage statistics for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxStatsResult> GetStats(CancellationToken cancellationToken = default)
        {
            return _client.GetStats(Id, cancellationToken);
        }

        /// <summary> Gets resource usage statistics for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxStatsResult>> GetStatsAsync(CancellationToken cancellationToken = default)
        {
            return _client.GetStatsAsync(Id, cancellationToken);
        }

        /// <summary> Disables a sandbox, stopping it first if it is running. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response Disable(RequestContext context)
        {
            return _client.Disable(Id, context);
        }

        /// <summary> Disables a sandbox, stopping it first if it is running. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> DisableAsync(RequestContext context)
        {
            return _client.DisableAsync(Id, context);
        }

        /// <summary> Disables a sandbox, stopping it first if it is running. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxProperties> Disable(CancellationToken cancellationToken = default)
        {
            return _client.Disable(Id, cancellationToken);
        }

        /// <summary> Disables a sandbox, stopping it first if it is running. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxProperties>> DisableAsync(CancellationToken cancellationToken = default)
        {
            return _client.DisableAsync(Id, cancellationToken);
        }

        /// <summary> Enables a disabled sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response Enable(RequestContext context)
        {
            return _client.Enable(Id, context);
        }

        /// <summary> Enables a disabled sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> EnableAsync(RequestContext context)
        {
            return _client.EnableAsync(Id, context);
        }

        /// <summary> Enables a disabled sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxProperties> Enable(CancellationToken cancellationToken = default)
        {
            return _client.Enable(Id, cancellationToken);
        }

        /// <summary> Enables a disabled sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxProperties>> EnableAsync(CancellationToken cancellationToken = default)
        {
            return _client.EnableAsync(Id, cancellationToken);
        }

        /// <summary> Executes a command in a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="containerName"> The container where the command runs. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response ExecuteCommand(RequestContent content, string containerName = default, RequestContext context = null)
        {
            return _client.ExecuteCommand(Id, content, containerName, context);
        }

        /// <summary> Executes a command in a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="containerName"> The container where the command runs. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> ExecuteCommandAsync(RequestContent content, string containerName = default, RequestContext context = null)
        {
            return _client.ExecuteCommandAsync(Id, content, containerName, context);
        }

        /// <summary> Executes a command in a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The executable, arguments, and execution options. </param>
        /// <param name="containerName"> The container where the command runs. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxExecuteCommandResult> ExecuteCommand(ExecuteSandboxCommandContent body, string containerName = default, CancellationToken cancellationToken = default)
        {
            return _client.ExecuteCommand(Id, body, containerName, cancellationToken);
        }

        /// <summary> Executes a command in a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The executable, arguments, and execution options. </param>
        /// <param name="containerName"> The container where the command runs. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxExecuteCommandResult>> ExecuteCommandAsync(ExecuteSandboxCommandContent body, string containerName = default, CancellationToken cancellationToken = default)
        {
            return _client.ExecuteCommandAsync(Id, body, containerName, cancellationToken);
        }

        /// <summary> Executes a shell command in a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="containerName"> The container where the shell command runs. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response ExecuteShellCommand(RequestContent content, string containerName = default, RequestContext context = null)
        {
            return _client.ExecuteShellCommand(Id, content, containerName, context);
        }

        /// <summary> Executes a shell command in a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="containerName"> The container where the shell command runs. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> ExecuteShellCommandAsync(RequestContent content, string containerName = default, RequestContext context = null)
        {
            return _client.ExecuteShellCommandAsync(Id, content, containerName, context);
        }

        /// <summary> Executes a shell command in a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The shell command and execution options. </param>
        /// <param name="containerName"> The container where the shell command runs. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxExecuteShellCommandResult> ExecuteShellCommand(ExecuteSandboxShellCommandContent body, string containerName = default, CancellationToken cancellationToken = default)
        {
            return _client.ExecuteShellCommand(Id, body, containerName, cancellationToken);
        }

        /// <summary> Executes a shell command in a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The shell command and execution options. </param>
        /// <param name="containerName"> The container where the shell command runs. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxExecuteShellCommandResult>> ExecuteShellCommandAsync(ExecuteSandboxShellCommandContent body, string containerName = default, CancellationToken cancellationToken = default)
        {
            return _client.ExecuteShellCommandAsync(Id, body, containerName, cancellationToken);
        }

        /// <summary> Sets the lifecycle policy for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response SetLifecyclePolicy(RequestContent content, RequestContext context = null)
        {
            return _client.SetLifecyclePolicy(Id, content, context);
        }

        /// <summary> Sets the lifecycle policy for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> SetLifecyclePolicyAsync(RequestContent content, RequestContext context = null)
        {
            return _client.SetLifecyclePolicyAsync(Id, content, context);
        }

        /// <summary> Sets the lifecycle policy for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The automatic suspension and deletion settings. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxProperties> SetLifecyclePolicy(SandboxLifecyclePolicy body, CancellationToken cancellationToken = default)
        {
            return _client.SetLifecyclePolicy(Id, body, cancellationToken);
        }

        /// <summary> Sets the lifecycle policy for a sandbox. Uses this sandbox's identifier. </summary>
        /// <param name="body"> The automatic suspension and deletion settings. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxProperties>> SetLifecyclePolicyAsync(SandboxLifecyclePolicy body, CancellationToken cancellationToken = default)
        {
            return _client.SetLifecyclePolicyAsync(Id, body, cancellationToken);
        }

        /// <summary> Resumes a stopped sandbox from a snapshot. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response Resume(RequestContext context)
        {
            return _client.Resume(Id, context);
        }

        /// <summary> Resumes a stopped sandbox from a snapshot. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> ResumeAsync(RequestContext context)
        {
            return _client.ResumeAsync(Id, context);
        }

        /// <summary> Resumes a stopped sandbox from a snapshot. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxProperties> Resume(CancellationToken cancellationToken = default)
        {
            return _client.Resume(Id, cancellationToken);
        }

        /// <summary> Resumes a stopped sandbox from a snapshot. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxProperties>> ResumeAsync(CancellationToken cancellationToken = default)
        {
            return _client.ResumeAsync(Id, cancellationToken);
        }

        /// <summary> Stops a running sandbox and saves its state as a snapshot. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response Stop(RequestContext context)
        {
            return _client.Stop(Id, context);
        }

        /// <summary> Stops a running sandbox and saves its state as a snapshot. Uses this sandbox's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> StopAsync(RequestContext context)
        {
            return _client.StopAsync(Id, context);
        }

        /// <summary> Stops a running sandbox and saves its state as a snapshot. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxSnapshot> Stop(CancellationToken cancellationToken = default)
        {
            return _client.Stop(Id, cancellationToken);
        }

        /// <summary> Stops a running sandbox and saves its state as a snapshot. Uses this sandbox's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxSnapshot>> StopAsync(CancellationToken cancellationToken = default)
        {
            return _client.StopAsync(Id, cancellationToken);
        }
    }
}
