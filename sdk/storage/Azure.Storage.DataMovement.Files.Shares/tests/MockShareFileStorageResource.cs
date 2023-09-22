// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMShare;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;
using DMShare::Azure.Storage.DataMovement.Files.Shares;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    internal class MockShareFileStorageResource : ShareFileStorageResource
    {
        public MockShareFileStorageResource(
            ShareFileClient fileClient,
            ShareFileStorageResourceOptions options = null) : base(fileClient, options)
        {
        }

        internal MockShareFileStorageResource(
            ShareFileClient fileClient,
            long? length,
            ETag? etagLock,
            ShareFileStorageResourceOptions options = null) : base(fileClient, length, etagLock, options)
        {
        }

        internal Task MockCompleteTransferAsync(bool overwrite, CancellationToken cancellationToken = default)
            => CompleteTransferAsync(overwrite, cancellationToken);

        internal Task MockCopyBlockFromUriAsync(
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

        internal Task MockCopyFromStreamAsync(
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

        internal Task MockCopyFromUriAsync(
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

        internal Task<bool> MockDeleteIfExistsAsync(CancellationToken cancellationToken = default)
            => DeleteIfExistsAsync(cancellationToken);

        internal Task<HttpAuthorization> MockGetCopyAuthorizationHeaderAsync(CancellationToken cancellationToken = default)
            => MockGetCopyAuthorizationHeaderAsync(cancellationToken);

        internal Task<StorageResourceProperties> MockGetPropertiesAsync(CancellationToken token = default)
            => GetPropertiesAsync(token);

        internal Task<StorageResourceReadStreamResult> MockReadStreamAsync(
            long position = 0,
            long? length = null,
            CancellationToken cancellationToken = default)
            => ReadStreamAsync(position, length, cancellationToken);
    }
}
