// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.DataMovement.Tests.Shared;

public class InjectedFailureException : Exception { }

/// <summary>
/// Wraps all calls to a <see cref="StorageResourceItem"/> with toggleable throwing.
/// </summary>
public class StorageResourceItemFailureWrapper : StorageResourceItem
{
    private readonly ScopeManager _throwScopeManager;
    private readonly StorageResourceItem _inner;

    public StorageResourceItemFailureWrapper(StorageResourceItem inner, ScopeManager throwScopeManager = default)
    {
        _inner = inner;
        _throwScopeManager = throwScopeManager ?? new();
    }

    public IDisposable ThrowScope() => _throwScopeManager.GetScope();

    private T ThrowOr<T>(T result) => _throwScopeManager.InScope
        ? throw new InjectedFailureException()
        : result;
    private T ThrowOrDo<T>(Func<T> func) => _throwScopeManager.InScope
        ? throw new InjectedFailureException()
        : func();

    #region Passthru
    public override Uri Uri => _inner.Uri;

    public override string ProviderId => ThrowOr(_inner.ProviderId);

    protected internal override string ResourceId => ThrowOr(_inner.ResourceId);

    protected internal override TransferOrder TransferType => ThrowOr(_inner.TransferType);

    protected internal override long MaxSupportedSingleTransferSize => ThrowOr(_inner.MaxSupportedSingleTransferSize);

    protected internal override long MaxSupportedChunkSize => ThrowOr(_inner.MaxSupportedChunkSize);

    protected internal override int MaxSupportedChunkCount => ThrowOr(_inner.MaxSupportedChunkCount);

    protected internal override long? Length => ThrowOr(_inner.Length);

    protected internal override Task CompleteTransferAsync(bool overwrite, StorageResourceCompleteTransferOptions completeTransferOptions = null, CancellationToken cancellationToken = default)
        => ThrowOrDo(() => _inner.CompleteTransferAsync(overwrite, completeTransferOptions, cancellationToken));

    protected internal override Task CopyBlockFromUriAsync(StorageResourceItem sourceResource, HttpRange range, bool overwrite, long completeLength, StorageResourceCopyFromUriOptions options = null, CancellationToken cancellationToken = default)
        => ThrowOrDo(() => _inner.CopyBlockFromUriAsync(sourceResource, range, overwrite, completeLength, options, cancellationToken));

    protected internal override Task CopyFromStreamAsync(Stream stream, long streamLength, bool overwrite, long completeLength, StorageResourceWriteToOffsetOptions options = null, CancellationToken cancellationToken = default)
        => ThrowOrDo(() => _inner.CopyFromStreamAsync(stream, streamLength, overwrite, completeLength, options, cancellationToken));

    protected internal override Task CopyFromUriAsync(StorageResourceItem sourceResource, bool overwrite, long completeLength, StorageResourceCopyFromUriOptions options = null, CancellationToken cancellationToken = default)
        => ThrowOrDo(() => _inner.CopyFromUriAsync(sourceResource, overwrite, completeLength, options, cancellationToken));

    protected internal override Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken = default)
        => ThrowOrDo(() => _inner.DeleteIfExistsAsync(cancellationToken));

    protected internal override Task<HttpAuthorization> GetCopyAuthorizationHeaderAsync(CancellationToken cancellationToken = default)
        => ThrowOrDo(() => _inner.GetCopyAuthorizationHeaderAsync(cancellationToken));

    protected internal override StorageResourceCheckpointDetails GetDestinationCheckpointDetails()
        => ThrowOrDo(_inner.GetDestinationCheckpointDetails);

    protected internal override Task<string> GetPermissionsAsync(StorageResourceItemProperties properties = null, CancellationToken cancellationToken = default)
        => ThrowOrDo(() => _inner.GetPermissionsAsync(properties, cancellationToken));

    protected internal override Task<StorageResourceItemProperties> GetPropertiesAsync(CancellationToken token = default)
        => ThrowOrDo(() => _inner.GetPropertiesAsync(token));

    protected internal override StorageResourceCheckpointDetails GetSourceCheckpointDetails()
        => ThrowOrDo(_inner.GetSourceCheckpointDetails);

    protected internal override Task<StorageResourceReadStreamResult> ReadStreamAsync(long position = 0, long? length = null, CancellationToken cancellationToken = default)
        => ThrowOrDo(() => _inner.ReadStreamAsync(position, length, cancellationToken));

    protected internal override Task SetPermissionsAsync(StorageResourceItem sourceResource, StorageResourceItemProperties sourceProperties, CancellationToken cancellationToken = default)
        => ThrowOrDo(() => _inner.SetPermissionsAsync(sourceResource, sourceProperties, cancellationToken));
    #endregion
}

/// <summary>
/// Wraps all calls to a <see cref="StorageResourceContainer"/> with toggleable throwing.
/// </summary>
public class StorageResourceContainerFailureWrapper : StorageResourceContainer
{
    private readonly ScopeManager _throwScopeManager;
    private readonly StorageResourceContainer _inner;

    public StorageResourceContainerFailureWrapper(StorageResourceContainer inner, ScopeManager throwScopeManager = default)
    {
        _inner = inner;
        _throwScopeManager = throwScopeManager ?? new();
    }

    public IDisposable ThrowScope() => _throwScopeManager.GetScope();

    private T ThrowOr<T>(T result) => _throwScopeManager.InScope
        ? throw new InjectedFailureException()
        : result;
    private T ThrowOrDo<T>(Func<T> func) => _throwScopeManager.InScope
        ? throw new InjectedFailureException()
        : func();

    protected internal override StorageResourceItem GetStorageResourceReference(string path, string resourceId)
        => ThrowOrDo(() => new StorageResourceItemFailureWrapper(_inner.GetStorageResourceReference(path, resourceId), _throwScopeManager));

    protected internal override StorageResourceContainer GetChildStorageResourceContainer(string path)
        => ThrowOrDo(() => new StorageResourceContainerFailureWrapper(_inner.GetChildStorageResourceContainer(path), _throwScopeManager));

    protected internal override async IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(StorageResourceContainer destinationContainer = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        if (_throwScopeManager.InScope)
        {
            throw new InjectedFailureException();
        }

        await foreach (StorageResource resource in _inner.GetStorageResourcesAsync(destinationContainer, cancellationToken))
        {
            if (resource is StorageResourceItem item)
            {
                yield return new StorageResourceItemFailureWrapper(item, _throwScopeManager);
            }
            else if (resource is StorageResourceContainer container)
            {
                yield return new StorageResourceContainerFailureWrapper(container, _throwScopeManager);
            }
            else
            {
                yield return resource;
            }
        }
    }

    protected internal override Task<StorageResourceContainerProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        => ThrowOrDo(() => _inner.GetPropertiesAsync(cancellationToken));

    public override string ToString()
    {
        return base.ToString();
    }

    #region Passthru
    public override Uri Uri => ThrowOr(_inner.Uri);

    public override string ProviderId => ThrowOr(_inner.ProviderId);

    protected internal override Task CreateIfNotExistsAsync(CancellationToken cancellationToken = default)
        => ThrowOrDo(() => _inner.CreateIfNotExistsAsync(cancellationToken));

    protected internal override StorageResourceCheckpointDetails GetDestinationCheckpointDetails()
        => ThrowOrDo(_inner.GetDestinationCheckpointDetails);

    protected internal override StorageResourceCheckpointDetails GetSourceCheckpointDetails()
        => ThrowOrDo(_inner.GetSourceCheckpointDetails);
    #endregion
}
