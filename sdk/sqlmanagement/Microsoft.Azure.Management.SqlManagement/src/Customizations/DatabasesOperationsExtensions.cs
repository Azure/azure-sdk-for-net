// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Sql
{
    using System.Threading;
    using System.Threading.Tasks;

    public partial class DatabasesOperationsExtensions
    {
        /// <summary>
        /// Renames a database.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
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
        public static void Rename(
            this IDatabasesOperations operations,
            string resourceGroupName,
            string serverName,
            string databaseName,
            string newName)
        {
            RenameAsync(operations, resourceGroupName, serverName, databaseName, newName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Renames a database.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task RenameAsync(
            this IDatabasesOperations operations,
            string resourceGroupName,
            string serverName,
            string databaseName,
            string newName,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.RenameWithHttpMessagesAsync(
                resourceGroupName,
                serverName,
                databaseName,
                newName,
                null,
                cancellationToken).ConfigureAwait(false)).Dispose();
        }
    }
}
