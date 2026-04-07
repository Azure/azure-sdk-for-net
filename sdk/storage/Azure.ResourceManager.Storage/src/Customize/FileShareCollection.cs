// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Restores GetAll/GetAllAsync overloads and IEnumerable/IAsyncEnumerable
// implementations matching the prior GA surface. The new generator moves list operations to
// the parent FileServiceResource, so these overloads delegate there via PageableWrapper.

using System.ComponentModel;
using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.Storage
{
    public partial class FileShareCollection
    {
        // Backward-compatible overload with int maxpagesize: Lists all file shares.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Pageable<FileShareResource> GetAll(int? maxpagesize, string filter, string expand, CancellationToken cancellationToken)
            => GetAll(maxpagesize?.ToString(), filter, expand, cancellationToken);

        // Backward-compatible overload with int maxpagesize: Lists all file shares.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual AsyncPageable<FileShareResource> GetAllAsync(int? maxpagesize, string filter, string expand, CancellationToken cancellationToken)
            => GetAllAsync(maxpagesize?.ToString(), filter, expand, cancellationToken);
    }
}
