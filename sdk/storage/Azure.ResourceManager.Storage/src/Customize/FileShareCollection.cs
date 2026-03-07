// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

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
    }
}
