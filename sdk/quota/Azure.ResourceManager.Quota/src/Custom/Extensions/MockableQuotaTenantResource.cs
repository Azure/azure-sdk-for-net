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
        /// <summary>
        /// List the operations for the provider
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Quota/operations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>QuotaOperation_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-09-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="QuotaOperationResult"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<QuotaOperationResult> GetQuotaOperationsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// List the operations for the provider
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Quota/operations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>QuotaOperation_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-09-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="QuotaOperationResult"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<QuotaOperationResult> GetQuotaOperations(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }
    }
}
