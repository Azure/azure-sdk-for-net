// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// This is used internally for testing purposes. It is shared within the test packages.
    /// </summary>
    internal abstract class StorageResourceItemInternal : StorageResourceItem
    {
        internal Task CompleteTransferInternalAsync(
            bool overwrite,
            StorageResourceCompleteTransferOptions completeTransferOptions,
            CancellationToken cancellationToken = default)
            => CompleteTransferAsync(
                overwrite,
                completeTransferOptions,
                cancellationToken);

        internal Task CopyBlockFromUriInternalAsync(
            StorageResourceItem sourceResource,
            HttpRange range,
            bool overwrite,
            long completeLength,
            StorageResourceCopyFromUriOptions options = null,
            CancellationToken cancellationToken = default)
            => CopyBlockFromUriAsync(
                sourceResource,
                range,
                overwrite,
                completeLength,
                options,
                cancellationToken);

        internal Task CopyFromStreamInternalAsync(
            Stream stream,
            long streamLength,
            bool overwrite,
            long completeLength,
            StorageResourceWriteToOffsetOptions options = null,
            CancellationToken cancellationToken = default)
           => CopyFromStreamAsync(
               stream,
               streamLength,
               overwrite,
               completeLength,
               options,
               cancellationToken);

        internal Task CopyFromUriInternalAsync(
            StorageResourceItem sourceResource,
            bool overwrite,
            long completeLength,
            StorageResourceCopyFromUriOptions options = null,
            CancellationToken cancellationToken = default)
            => CopyFromUriAsync(
                sourceResource,
                overwrite,
                completeLength,
                options,
                cancellationToken);

        internal Task<bool> DeleteIfExistsInternalAsync(CancellationToken cancellationToken = default)
            => DeleteIfExistsAsync(cancellationToken);

        internal Task<HttpAuthorization> GetCopyAuthorizationHeaderInternalAsync(CancellationToken cancellationToken = default)
            => GetCopyAuthorizationHeaderAsync(cancellationToken);

        internal Task<StorageResourceItemProperties> GetPropertiesInternalAsync(CancellationToken token = default)
            => GetPropertiesAsync(token);

        internal Task<StorageResourceReadStreamResult> ReadStreamInternalAsync(
            long position = 0,
            long? length = null,
            CancellationToken cancellationToken = default)
            => ReadStreamAsync(position, length, cancellationToken);

        internal StorageResourceItemProperties GetResourceProperties()
            => ResourceProperties;

        internal Task<string> GetPermissionsInternalAsync(StorageResourceItemProperties sourceProperties = default)
            => GetPermissionsAsync(sourceProperties);

        internal Task SetPermissionsInternalAsync(StorageResourceItem sourceResource, StorageResourceItemProperties sourceProperties)
            => SetPermissionsAsync(sourceResource, sourceProperties);
    }
}
