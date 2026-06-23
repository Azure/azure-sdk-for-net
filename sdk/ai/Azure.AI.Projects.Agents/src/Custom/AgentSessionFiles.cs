// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Agents;

[CodeGenSuppress("GetSessionFiles", typeof(string), typeof(string), typeof(string), typeof(string), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetSessionFilesAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetSessionFiles", typeof(string), typeof(string), typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetSessionFilesAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
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
    /// <param name="userIsolationKey"> Opaque per-user isolation key used to scope endpoint-scoped data (responses, conversations, sessions) to a specific end user. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="sessionId"/>, <paramref name="localPath"/> or <paramref name="sessionStoragePath"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="sessionId"/>, <paramref name="localPath"/> or <paramref name="sessionStoragePath"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult<SessionFileWriteResponse>> UploadSessionFileAsync(string agentName, string sessionId, string sessionStoragePath, string localPath, string userIsolationKey=default, CancellationToken cancellationToken=default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(sessionId, nameof(sessionId));
        Argument.AssertNotNullOrEmpty(localPath, nameof(localPath));
        Argument.AssertNotNullOrEmpty(sessionStoragePath, nameof(sessionStoragePath));

        using BinaryContent content = BinaryContent.Create(new BinaryData(File.ReadAllBytes(localPath)));
        ClientResult result = await UploadSessionFileAsync(agentName, sessionId, sessionStoragePath, content, userIsolationKey, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
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
    /// <param name="userIsolationKey"> Opaque per-user isolation key used to scope endpoint-scoped data (responses, conversations, sessions) to a specific end user. </param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="sessionId"/>, <paramref name="localPath"/> or <paramref name="sessionStoragePath"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="sessionId"/>, <paramref name="localPath"/> or <paramref name="sessionStoragePath"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public ClientResult<SessionFileWriteResponse> UploadSessionFile(string agentName, string sessionId, string sessionStoragePath, string localPath, string userIsolationKey=default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(sessionId, nameof(sessionId));
        Argument.AssertNotNullOrEmpty(localPath, nameof(localPath));
        Argument.AssertNotNullOrEmpty(sessionStoragePath, nameof(sessionStoragePath));

        using BinaryContent content = BinaryContent.Create(new BinaryData(File.ReadAllBytes(localPath)));
        ClientResult result = UploadSessionFile(agentName, sessionId, sessionStoragePath, content, userIsolationKey, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((SessionFileWriteResponse)result, result.GetRawResponse());
    }

    /// <summary>
    /// List files and directories at a given path in the session sandbox.
    /// Returns only the immediate children of the specified directory (non-recursive).
    /// If path is not provided, lists the session home directory.
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="agentSessionId"> The session ID. </param>
    /// <param name="sessionStoragePath"> The directory path to list, relative to the session home directory. Defaults to the home directory if not provided. </param>
    /// <param name="userIsolationKey"> Opaque per-user isolation key used to scope endpoint-scoped data (responses, conversations, sessions) to a specific end user. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<SessionDirectoryEntry> GetSessionFiles(string agentName, string agentSessionId, string sessionStoragePath = default, string userIsolationKey = default, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        sessionStoragePath ??= "<unset>";
        return new InternalOpenAICollectionResultOfT<SessionDirectoryEntry>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetSessionFilesRequest(
                    agentName: localCollectionOptions.Filters[0],
                    agentSessionId: localCollectionOptions.Filters[1],
                    path: string.Equals(localCollectionOptions.Filters[2], "<unset>") ? null : localCollectionOptions.Filters[2],
                    userIsolationKey: localCollectionOptions.Filters.Count > 3 ? localCollectionOptions.Filters[3] : null,
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after:localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: (e, o) => SessionDirectoryEntry.DeserializeSessionDirectoryEntry(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [agentName, agentSessionId, sessionStoragePath, userIsolationKey]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// List files and directories at a given path in the session sandbox.
    /// Returns only the immediate children of the specified directory (non-recursive).
    /// If path is not provided, lists the session home directory.
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="agentSessionId"> The session ID. </param>
    /// <param name="sessionStoragePath"> The directory path to list, relative to the session home directory. Defaults to the home directory if not provided. </param>
    /// <param name="userIsolationKey"> Opaque per-user isolation key used to scope endpoint-scoped data (responses, conversations, sessions) to a specific end user. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<SessionDirectoryEntry> GetSessionFilesAsync(string agentName, string agentSessionId, string sessionStoragePath = default, string userIsolationKey = default, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        sessionStoragePath ??= "<unset>";
        return new InternalOpenAIAsyncCollectionResultOfT<SessionDirectoryEntry>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetSessionFilesRequest(
                    agentName: localCollectionOptions.Filters[0],
                    agentSessionId: localCollectionOptions.Filters[1],
                    path: string.Equals(localCollectionOptions.Filters[2], "<unset>") ? null : localCollectionOptions.Filters[2],
                    userIsolationKey: localCollectionOptions.Filters.Count > 3 ? localCollectionOptions.Filters[3] : null,
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: (e, o) => SessionDirectoryEntry.DeserializeSessionDirectoryEntry(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [agentName, agentSessionId, sessionStoragePath, userIsolationKey]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Download a file from the session sandbox as a binary stream. Also return file as binary data. </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="sessionId"> The session ID. </param>
    /// <param name="sessionStoragePath"> The destination file path within the sandbox, relative to the session home directory. </param>
    /// <param name="localPath"> The path to the local file to save the data to. </param>
    /// <param name="userIsolationKey"> Opaque per-user isolation key used to scope endpoint-scoped data (responses, conversations, sessions) to a specific end user. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="sessionId"/>, <paramref name="localPath"/> or <paramref name="sessionStoragePath"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="sessionId"/>, <paramref name="localPath"/> or <paramref name="sessionStoragePath"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<BinaryData> DownloadSessionFileAsync(string agentName, string sessionId, string sessionStoragePath, string localPath, string userIsolationKey=default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(sessionId, nameof(sessionId));
        Argument.AssertNotNullOrEmpty(sessionStoragePath, nameof(sessionStoragePath));
        Argument.AssertNotNullOrEmpty(localPath, nameof(localPath));

        ClientResult result = await DownloadSessionFileAsync(agentName, sessionId, sessionStoragePath, userIsolationKey, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        File.WriteAllBytes(localPath, result.GetRawResponse().Content.ToArray());
        return result.GetRawResponse().Content;
    }

    /// <summary> Download a file from the session sandbox as a binary stream. Also return file as binary data. </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="sessionId"> The session ID. </param>
    /// <param name="sessionStoragePath"> The destination file path within the sandbox, relative to the session home directory. </param>
    /// <param name="localPath"> The path to the local file to save the data to. </param>
    /// <param name="userIsolationKey"> Opaque per-user isolation key used to scope endpoint-scoped data (responses, conversations, sessions) to a specific end user. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="sessionId"/>, <paramref name="localPath"/> or <paramref name="sessionStoragePath"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="sessionId"/>, <paramref name="localPath"/> or <paramref name="sessionStoragePath"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual BinaryData DownloadSessionFile(string agentName, string sessionId, string sessionStoragePath, string localPath, string userIsolationKey=default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(sessionId, nameof(sessionId));
        Argument.AssertNotNullOrEmpty(sessionStoragePath, nameof(sessionStoragePath));
        Argument.AssertNotNullOrEmpty(localPath, nameof(localPath));

        ClientResult result = DownloadSessionFile(agentName, sessionId, sessionStoragePath, userIsolationKey, cancellationToken.ToRequestOptions());
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
    /// <param name="userIsolationKey"> Opaque per-user isolation key used to scope endpoint-scoped data (responses, conversations, sessions) to a specific end user. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="sessionId"/> or <paramref name="path"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="sessionId"/> or <paramref name="path"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult DeleteSessionFile(string agentName, string sessionId, string path, bool? recursive = default, string userIsolationKey=default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(sessionId, nameof(sessionId));
        Argument.AssertNotNullOrEmpty(path, nameof(path));

        return DeleteSessionFile(agentName, sessionId, path, recursive, userIsolationKey, cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Delete a file or directory from the session sandbox.
    /// If `recursive` is false (default) and the target is a non-empty directory, the API returns 409 Conflict.
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="sessionId"> The session ID. </param>
    /// <param name="path"> The file or directory path to delete, relative to the session home directory. </param>
    /// <param name="recursive"> Whether to recursively delete directory contents. Defaults to false. </param>
    /// <param name="userIsolationKey"> Opaque per-user isolation key used to scope endpoint-scoped data (responses, conversations, sessions) to a specific end user. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="sessionId"/> or <paramref name="path"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="sessionId"/> or <paramref name="path"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult> DeleteSessionFileAsync(string agentName, string sessionId, string path, bool? recursive = default, string userIsolationKey=default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(sessionId, nameof(sessionId));
        Argument.AssertNotNullOrEmpty(path, nameof(path));

        return await DeleteSessionFileAsync(agentName, sessionId, path, recursive, userIsolationKey, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
    }
}
