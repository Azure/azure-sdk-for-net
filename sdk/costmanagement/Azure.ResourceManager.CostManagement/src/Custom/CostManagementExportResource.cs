// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.CostManagement.Models;

namespace Azure.ResourceManager.CostManagement
{
    // Backward-compat: Execute without ExportRunRequest param.
    public partial class CostManagementExportResource
    {
        /// <summary> The operation to execute an export. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response Execute(CancellationToken cancellationToken)
        {
            return Execute(default(ExportRunContent), cancellationToken);
        }

        /// <summary> The operation to execute an export. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> ExecuteAsync(CancellationToken cancellationToken)
        {
            return await ExecuteAsync(default(ExportRunContent), cancellationToken).ConfigureAwait(false);
        }
    }
}
