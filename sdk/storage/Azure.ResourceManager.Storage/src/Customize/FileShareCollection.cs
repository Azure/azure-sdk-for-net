// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class FileShareCollection : IEnumerable<FileShareResource>, IAsyncEnumerable<FileShareResource>
    {
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerator<FileShareResource> IEnumerable<FileShareResource>.GetEnumerator()
        {
            throw new NotSupportedException("This collection does not support enumerating directly. Use GetAllAsync or GetAll on the parent resource instead.");
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotSupportedException("This collection does not support enumerating directly. Use GetAllAsync or GetAll on the parent resource instead.");
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        IAsyncEnumerator<FileShareResource> IAsyncEnumerable<FileShareResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This collection does not support enumerating directly. Use GetAllAsync or GetAll on the parent resource instead.");
        }

        /// <summary> Lists all file shares. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<FileShareResource> GetAll(string maxpagesize, string filter, string expand, CancellationToken cancellationToken)
            => new PageableWrapper<FileShareItem, FileShareResource>(
                Client.GetFileServiceResource(Id).GetAll(maxpagesize, filter, expand, cancellationToken),
                item => Client.GetFileShareResource(item.Id));

        /// <summary> Lists all file shares. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<FileShareResource> GetAllAsync(string maxpagesize, string filter, string expand, CancellationToken cancellationToken)
            => new AsyncPageableWrapper<FileShareItem, FileShareResource>(
                Client.GetFileServiceResource(Id).GetAllAsync(maxpagesize, filter, expand, cancellationToken),
                item => Client.GetFileShareResource(item.Id));

        /// <summary> Lists all file shares. Backward-compatible overload with int maxpagesize. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<FileShareResource> GetAll(int? maxpagesize, string filter, string expand, CancellationToken cancellationToken)
            => GetAll(maxpagesize?.ToString(), filter, expand, cancellationToken);

        /// <summary> Lists all file shares. Backward-compatible overload with int maxpagesize. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<FileShareResource> GetAllAsync(int? maxpagesize, string filter, string expand, CancellationToken cancellationToken)
            => GetAllAsync(maxpagesize?.ToString(), filter, expand, cancellationToken);
    }
}
