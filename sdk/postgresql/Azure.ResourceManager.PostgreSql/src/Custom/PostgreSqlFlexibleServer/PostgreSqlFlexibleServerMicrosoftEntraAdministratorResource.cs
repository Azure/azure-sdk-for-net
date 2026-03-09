// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    public partial class PostgreSqlFlexibleServerMicrosoftEntraAdministratorResource
    {
        /// <summary> Updates an existing Microsoft Entra administrator. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="content"> The required parameters for creating or updating a Microsoft Entra administrator. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<PostgreSqlFlexibleServerMicrosoftEntraAdministratorResource> Update(WaitUntil waitUntil, PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent content, CancellationToken cancellationToken = default)
            => Update(waitUntil, content.ToAdministratorMicrosoftEntraAdd(), cancellationToken);

        /// <summary> Updates an existing Microsoft Entra administrator. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="content"> The required parameters for creating or updating a Microsoft Entra administrator. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<PostgreSqlFlexibleServerMicrosoftEntraAdministratorResource>> UpdateAsync(WaitUntil waitUntil, PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent content, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, content.ToAdministratorMicrosoftEntraAdd(), cancellationToken).ConfigureAwait(false);
    }
}
