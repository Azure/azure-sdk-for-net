// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.CostManagement
{
    public partial class CostManagementExportResource
    {
        /// <summary>
        /// The operation to run an export.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.CostManagement/exports/{exportName}/run</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Exports_Execute</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CostManagementExportResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> ExecuteAsync(CancellationToken cancellationToken = default)
            => await ExecuteAsync(null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The operation to run an export.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.CostManagement/exports/{exportName}/run</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Exports_Execute</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CostManagementExportResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response Execute(CancellationToken cancellationToken = default)
            => Execute(null, cancellationToken);
    }
}
