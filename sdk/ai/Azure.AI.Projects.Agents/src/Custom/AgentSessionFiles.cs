// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Agents;

[Experimental("AAIP001")]
public partial class AgentSessionFiles
{
    /// <summary>
    /// Upload a file to the session sandbox via binary stream.
    /// Maximum file size is 50 MB. Uploads exceeding this limit return 413 Payload Too Large.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="sessionId"> The session ID. </param>
    /// <param name="sessionStoragePath"> The destination file path within the sandbox, relative to the session home directory. </param>
    /// <param name="localPath"> The path to the local file to be uploaded. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="sessionId"/>, <paramref name="localPath"/> or <paramref name="sessionStoragePath"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="sessionId"/>, <paramref name="localPath"/> or <paramref name="sessionStoragePath"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult<SessionFileWriteResponse>> UploadSessionFileAsync(string agentName, string sessionId, string sessionStoragePath, string localPath, CancellationToken cancellationToken=default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(sessionId, nameof(sessionId));
        Argument.AssertNotNullOrEmpty(localPath, nameof(localPath));
        Argument.AssertNotNullOrEmpty(sessionStoragePath, nameof(sessionStoragePath));

        using BinaryContent content = BinaryContent.Create(new BinaryData(File.ReadAllBytes(localPath)));
        ClientResult result = await UploadSessionFileAsync(agentName, sessionId, sessionStoragePath, content, default, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((SessionFileWriteResponse)result, result.GetRawResponse());
    }

    /// <summary>
    /// Upload a file to the session sandbox via binary stream.
    /// Maximum file size is 50 MB. Uploads exceeding this limit return 413 Payload Too Large.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="sessionId"> The session ID. </param>
    /// <param name="sessionStoragePath"> The destination file path within the sandbox, relative to the session home directory. </param>
    /// <param name="localPath"> The path to the local file to be uploaded. </param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="sessionId"/>, <paramref name="localPath"/> or <paramref name="sessionStoragePath"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="sessionId"/>, <paramref name="localPath"/> or <paramref name="sessionStoragePath"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public ClientResult<SessionFileWriteResponse> UploadSessionFile(string agentName, string sessionId, string sessionStoragePath, string localPath, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(sessionId, nameof(sessionId));
        Argument.AssertNotNullOrEmpty(localPath, nameof(localPath));
        Argument.AssertNotNullOrEmpty(sessionStoragePath, nameof(sessionStoragePath));

        using BinaryContent content = BinaryContent.Create(new BinaryData(File.ReadAllBytes(localPath)));
        ClientResult result = UploadSessionFile(agentName, sessionId, sessionStoragePath, content, default, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((SessionFileWriteResponse)result, result.GetRawResponse());
    }

    /// <summary>
    /// [Protocol Method] List files and directories at a given path in the session sandbox.
    /// Returns only the immediate children of the specified directory (non-recursive).
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="sessionId"> The session ID. </param>
    /// <param name="sessionStoragePath"> The directory path to list, relative to the session home directory. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="sessionId"/> or <paramref name="sessionStoragePath"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="sessionId"/> or <paramref name="sessionStoragePath"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult<SessionDirectoryListResponse>> GetSessionFilesAsync(string agentName, string sessionId, string sessionStoragePath, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(sessionId, nameof(sessionId));
        Argument.AssertNotNullOrEmpty(sessionStoragePath, nameof(sessionStoragePath));

        ClientResult result = await GetSessionFilesAsync(agentName, sessionId, sessionStoragePath, default, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((SessionDirectoryListResponse)result, result.GetRawResponse());
    }

    /// <summary>
    /// [Protocol Method] List files and directories at a given path in the session sandbox.
    /// Returns only the immediate children of the specified directory (non-recursive).
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="sessionId"> The session ID. </param>
    /// <param name="sessionStoragePath"> The directory path to list, relative to the session home directory. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="sessionId"/> or <paramref name="sessionStoragePath"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="sessionId"/> or <paramref name="sessionStoragePath"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult<SessionDirectoryListResponse> GetSessionFiles(string agentName, string sessionId, string sessionStoragePath, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(sessionId, nameof(sessionId));
        Argument.AssertNotNullOrEmpty(sessionStoragePath, nameof(sessionStoragePath));

        ClientResult result = GetSessionFiles(agentName, sessionId, sessionStoragePath, default, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((SessionDirectoryListResponse)result, result.GetRawResponse());
    }

    /// <summary> Download a file from the session sandbox as a binary stream. Also return file as binary data. </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="sessionId"> The session ID. </param>
    /// <param name="sessionStoragePath"> The destination file path within the sandbox, relative to the session home directory. </param>
    /// <param name="localPath"> The path to the local file to save the data to. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="sessionId"/>, <paramref name="localPath"/> or <paramref name="sessionStoragePath"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="sessionId"/>, <paramref name="localPath"/> or <paramref name="sessionStoragePath"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<BinaryData> DownloadSessionFileAsync(string agentName, string sessionId, string sessionStoragePath, string localPath, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(sessionId, nameof(sessionId));
        Argument.AssertNotNullOrEmpty(sessionStoragePath, nameof(sessionStoragePath));
        Argument.AssertNotNullOrEmpty(localPath, nameof(localPath));

        ClientResult result = await DownloadSessionFileAsync(agentName, sessionId, sessionStoragePath, default, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        File.WriteAllBytes(localPath, result.GetRawResponse().Content.ToArray());
        return result.GetRawResponse().Content;
    }

    /// <summary> Download a file from the session sandbox as a binary stream. Also return file as binary data. </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="sessionId"> The session ID. </param>
    /// <param name="sessionStoragePath"> The destination file path within the sandbox, relative to the session home directory. </param>
    /// <param name="localPath"> The path to the local file to save the data to. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="sessionId"/>, <paramref name="localPath"/> or <paramref name="sessionStoragePath"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="sessionId"/>, <paramref name="localPath"/> or <paramref name="sessionStoragePath"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual BinaryData DownloadSessionFile(string agentName, string sessionId, string sessionStoragePath, string localPath, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(sessionId, nameof(sessionId));
        Argument.AssertNotNullOrEmpty(sessionStoragePath, nameof(sessionStoragePath));
        Argument.AssertNotNullOrEmpty(localPath, nameof(localPath));

        ClientResult result = DownloadSessionFile(agentName, sessionId, sessionStoragePath, default, cancellationToken.ToRequestOptions());
        File.WriteAllBytes(localPath, result.GetRawResponse().Content.ToArray());
        return result.GetRawResponse().Content;
    }

    /// <summary>
    /// Delete a file or directory from the session sandbox.
    /// If `recursive` is false (default) and the target is a non-empty directory, the API returns 409 Conflict.
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="sessionId"> The session ID. </param>
    /// <param name="path"> The file or directory path to delete, relative to the session home directory. </param>
    /// <param name="recursive"> Whether to recursively delete directory contents. Defaults to false. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="sessionId"/> or <paramref name="path"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="sessionId"/> or <paramref name="path"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult DeleteSessionFile(string agentName, string sessionId, string path, bool? recursive = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(sessionId, nameof(sessionId));
        Argument.AssertNotNullOrEmpty(path, nameof(path));

        return DeleteSessionFile(agentName, sessionId, path, default, recursive, cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Delete a file or directory from the session sandbox.
    /// If `recursive` is false (default) and the target is a non-empty directory, the API returns 409 Conflict.
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="sessionId"> The session ID. </param>
    /// <param name="path"> The file or directory path to delete, relative to the session home directory. </param>
    /// <param name="recursive"> Whether to recursively delete directory contents. Defaults to false. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="sessionId"/> or <paramref name="path"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="sessionId"/> or <paramref name="path"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult> DeleteSessionFileAsync(string agentName, string sessionId, string path, bool? recursive = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(sessionId, nameof(sessionId));
        Argument.AssertNotNullOrEmpty(path, nameof(path));

        return await DeleteSessionFileAsync(agentName, sessionId, path, default, recursive, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
    }
}
