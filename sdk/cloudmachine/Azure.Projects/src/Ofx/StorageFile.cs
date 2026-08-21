// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Projects;

/// <summary>
/// The storage file for the project client.
/// </summary>
public class StorageFile
{
    private readonly Response _response;

    private readonly StorageServices _storage;

    /// <summary>
    /// The path of the file in the storage account.
    /// </summary>
    public string Path { get; internal set; }

    /// <summary>
    /// The requestId for the storage operation that triggered this event.
    /// </summary>
    public string RequestId { get; internal set; }

    /// <summary>
    ///
    /// </summary>
    /// <param name="result"></param>
    /// <remarks>returns null if the file is not created as a return value of a service method call.</remarks>
    public static implicit operator Response(StorageFile result) => result._response;

    /// <summary>
    /// The cancellation token for the storage operation.
    /// </summary>
    public CancellationToken CancellationToken { get; internal set; }

    /// <summary>
    /// Downloads the file from the storage account.
    /// </summary>
    /// <returns></returns>
    public BinaryData Download()
        => _storage.Download(Path);

    /// <summary>
    /// Downloads the file from the storage account.
    /// </summary>
    /// <returns></returns>
    public async Task<BinaryData> DownloadAsync()
        => await _storage.DownloadAsync(Path).ConfigureAwait(false);

    // public async Task<BinaryData> DownloadAsync()
    //     => await _storage.DownloadBlobAsync(Path).ConfigureAwait(false);

    /// <summary>
    /// Deletes the file from the storage account.
    /// </summary>
    public void Delete()
        => _storage.Delete(Path);

    /// <summary>
    /// Deletes the file from the storage account.
    /// </summary>
    /// <returns></returns>
    public async Task DeleteAsync()
        => await _storage.DeleteAsync(Path).ConfigureAwait(false);

    // public Uri ShareFolder(AccessPermissions permissions, TimeSpan expiresAfter)
    //     => _storage.ShareFolder(Path, permissions, expiresAfter);

    // public Uri ShareFile(AccessPermissions permissions, TimeSpan expiresAfter)
    //     => _storage.ShareFile(Path, permissions, expiresAfter);

    internal StorageFile(StorageServices storage, string path, string requestId, Response response = default)
    {
        _storage = storage;
        Path = path;
        RequestId = requestId;
        _response = response;
    }

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => base.Equals(obj);

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => base.GetHashCode();

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => $"{Path}";
}
