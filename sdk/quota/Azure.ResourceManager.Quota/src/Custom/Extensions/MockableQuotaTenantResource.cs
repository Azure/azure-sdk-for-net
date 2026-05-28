// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Quota.Models;

namespace Azure.ResourceManager.Quota.Mocking
{
    public partial class MockableQuotaTenantResource
    {
        // Operation path: /providers/Microsoft.Quota/operations
        // This operation is obsolete; use GetAllAsync instead.
        /// <summary> Obsolete. Use GetAllAsync instead. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<QuotaOperationResult> GetQuotaOperationsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is obsolete. Use GetAllAsync instead.");
        }

        // Operation path: /providers/Microsoft.Quota/operations
        // This operation is obsolete; use GetAll instead.
        /// <summary> Obsolete. Use GetAll instead. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<QuotaOperationResult> GetQuotaOperations(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is obsolete. Use GetAll instead.");
        }
    }
}
