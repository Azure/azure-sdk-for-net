// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Restores GetAll/GetAllAsync overloads and IEnumerable/IAsyncEnumerable
// implementations matching the prior GA surface. The new generator moves list operations to
// the parent FileServiceResource, so these overloads delegate there via PageableWrapper.

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
            => GetAll((string)null, null, null, default).GetEnumerator();

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerator IEnumerable.GetEnumerator()
            => GetAll((string)null, null, null, default).GetEnumerator();

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        IAsyncEnumerator<FileShareResource> IAsyncEnumerable<FileShareResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync((string)null, null, null, cancellationToken).GetAsyncEnumerator(cancellationToken);

        // Backward-compatible overload: Lists all file shares.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<FileShareResource> GetAll(string maxpagesize, string filter, string expand, CancellationToken cancellationToken)
            => new PageableWrapper<FileShareItem, FileShareResource>(
                Client.GetFileServiceResource(Id).GetAll(maxpagesize, filter, expand, cancellationToken),
                item => Client.GetFileShareResource(item.Id));

        // Backward-compatible overload: Lists all file shares.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<FileShareResource> GetAllAsync(string maxpagesize, string filter, string expand, CancellationToken cancellationToken)
            => new AsyncPageableWrapper<FileShareItem, FileShareResource>(
                Client.GetFileServiceResource(Id).GetAllAsync(maxpagesize, filter, expand, cancellationToken),
                item => Client.GetFileShareResource(item.Id));

        // Backward-compatible overload with int maxpagesize: Lists all file shares.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<FileShareResource> GetAll(int? maxpagesize, string filter, string expand, CancellationToken cancellationToken)
            => GetAll(maxpagesize?.ToString(), filter, expand, cancellationToken);

        // Backward-compatible overload with int maxpagesize: Lists all file shares.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<FileShareResource> GetAllAsync(int? maxpagesize, string filter, string expand, CancellationToken cancellationToken)
            => GetAllAsync(maxpagesize?.ToString(), filter, expand, cancellationToken);
    }
}
