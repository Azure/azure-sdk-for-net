// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// Options for <see cref="LogsQueryClient.QueryAsync"/> and <see cref="LogsBatchQuery.AddQuery"/> methods.
    /// </summary>
    public class LogsQueryOptions
    {
        /// <summary>
        /// Gets or sets the value indicating the service timeout for the query. Defaults to <c>null</c>.
        /// </summary>
        public TimeSpan? ServerTimeout { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to include query execution statistics as part of the response.
        /// Statistics can be retrieved via the <see cref="LogsQueryResult.Statistics"/> property.
        /// Defaults to <c>false</c>.
        /// </summary>
        public bool IncludeStatistics { get; set; }

        /// <summary>
        /// Gets a list of additional workspaces ids to include in the query.
        /// </summary>
        public IList<string> AdditionalWorkspaceIds { get; } = new ChangeTrackingList<string>();

        /// <summary>
        /// Gets a list of additional workspaces names to include in the query.
        /// </summary>
        public IList<string> AdditionalWorkspaceNames { get; } = new ChangeTrackingList<string>();

        /// <summary>
        /// Gets a list of additional workspaces names to include in the query.
        /// </summary>
        public IList<string> AdditionalWorkspaceQualifiedNames { get; } = new ChangeTrackingList<string>();

        /// <summary>
        /// Gets a list of additional resource to include in the query.
        /// </summary>
        public IList<string> AdditionalResourceIds { get; } = new ChangeTrackingList<string>();
    }
}