// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Sql
{
    using Microsoft.Rest.Azure;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class DatabasesOperations
    {
        /// <summary>
        /// Renames a database.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can
        /// obtain this value from the Azure Resource Manager API or the
        /// portal.
        /// </param>
        /// <param name='serverName'>
        /// The name of the server.
        /// </param>
        /// <param name='databaseName'>
        /// The name of the database to rename.
        /// </param>
        /// <param name='newName'>
        /// The new name that the database should be renamed to.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        public async Task<AzureOperationResponse> RenameWithHttpMessagesAsync(
            string resourceGroupName,
            string serverName,
            string databaseName,
            string newName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.RenameWithHttpMessagesAsync(
                resourceGroupName,
                serverName,
                databaseName,
                new Models.ResourceMoveDefinition(
                    string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/databases/{3}",
                        this.Client.SubscriptionId,
                        resourceGroupName,
                        serverName,
                        newName)),
                customHeaders,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
