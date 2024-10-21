// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;

namespace Azure.CloudMachine;

public class StorageFile
{
    private readonly Response? _response;

    private StorageServices _storage;
    public string Path { get; internal set; }

    /// <summary>
    /// The requestId for the storage operation that triggered this event
    /// </summary>
    public string RequestId { get; internal set; }

    /// <summary>
    ///
    /// </summary>
    /// <param name="result"></param>
    /// <remarks>returns null if the file is not created as a return value of a service method call.</remarks>
    public static implicit operator Response?(StorageFile result) => result._response;

    public CancellationToken CancellationToken { get; internal set; }

    public BinaryData Download()
        => _storage.DownloadBlob(Path);

    // public async Task<BinaryData> DownloadAsync()
    //     => await _storage.DownloadBlobAsync(Path).ConfigureAwait(false);

    public void Delete()
        => _storage.DeleteBlob(Path);

    // public async Task DeleteAsync()
    //     => await _storage.DeleteBlobAsync(Path).ConfigureAwait(false);

    // public Uri ShareFolder(AccessPermissions permissions, TimeSpan expiresAfter)
    //     => _storage.ShareFolder(Path, permissions, expiresAfter);

    // public Uri ShareFile(AccessPermissions permissions, TimeSpan expiresAfter)
    //     => _storage.ShareFile(Path, permissions, expiresAfter);

    internal StorageFile(StorageServices storage, string path, string requestId, Response? response = default)
    {
        _storage = storage;
        Path = path;
        RequestId = requestId;
        _response = response;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) => base.Equals(obj);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => base.GetHashCode();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => $"{Path}";
}
