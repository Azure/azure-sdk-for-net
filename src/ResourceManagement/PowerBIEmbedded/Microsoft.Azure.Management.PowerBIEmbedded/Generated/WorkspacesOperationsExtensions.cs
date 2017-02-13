// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PowerBIEmbedded
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for WorkspacesOperations.
    /// </summary>
    public static partial class WorkspacesOperationsExtensions
    {
            /// <summary>
            /// Retrieves all existing Power BI workspaces in the specified workspace
            /// collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='workspaceCollectionName'>
            /// Power BI Embedded Workspace Collection name
            /// </param>
            public static IEnumerable<Workspace> List(this IWorkspacesOperations operations, string resourceGroupName, string workspaceCollectionName)
            {
                return Task.Factory.StartNew(s => ((IWorkspacesOperations)s).ListAsync(resourceGroupName, workspaceCollectionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Retrieves all existing Power BI workspaces in the specified workspace
            /// collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='workspaceCollectionName'>
            /// Power BI Embedded Workspace Collection name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IEnumerable<Workspace>> ListAsync(this IWorkspacesOperations operations, string resourceGroupName, string workspaceCollectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, workspaceCollectionName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
