// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public interface IPagedCollection<T> : IEnumerable<T>
    {
        Task<IPagedCollection<T>> GetNextPageAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
