// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    public partial class PostgreSqlFlexibleServerMicrosoftEntraAdministratorCollection
    {
        /// <summary> Creates or updates an existing Microsoft Entra administrator. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="objectId"> Guid of the objectId for the administrator. </param>
        /// <param name="content"> The required parameters for creating or updating a Microsoft Entra administrator. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<PostgreSqlFlexibleServerMicrosoftEntraAdministratorResource> CreateOrUpdate(WaitUntil waitUntil, string objectId, PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent content, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, objectId, content.ToAdministratorMicrosoftEntraAdd(), cancellationToken);

        /// <summary> Creates or updates an existing Microsoft Entra administrator. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="objectId"> Guid of the objectId for the administrator. </param>
        /// <param name="content"> The required parameters for creating or updating a Microsoft Entra administrator. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<PostgreSqlFlexibleServerMicrosoftEntraAdministratorResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string objectId, PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent content, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, objectId, content.ToAdministratorMicrosoftEntraAdd(), cancellationToken).ConfigureAwait(false);
    }
}
