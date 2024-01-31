// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// Options for <see cref="LogsQueryClient.QueryWorkspaceAsync"/> and <see cref="LogsBatchQuery.AddWorkspaceQuery"/> methods.
    /// </summary>
    public class LogsQueryOptions
    {
        /// <summary>
        /// Gets or sets the value indicating the service timeout for the query. Defaults to <c>null</c>.
        /// </summary>
        public TimeSpan? ServerTimeout { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to include query execution statistics as part of the response.
        /// Statistics can be retrieved via the <see cref="LogsQueryResult.GetStatistics()"/> method.
        /// Defaults to <c>false</c>.
        /// </summary>
        public bool IncludeStatistics { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to include query visualization as part of the response.
        /// Visualization can be retrieved via the <see cref="LogsQueryResult.GetVisualization()"/> method.
        /// Defaults to <c>false</c>.
        /// </summary>
        public bool IncludeVisualization { get; set; }

        /// <summary>
        /// <para>
        /// Gets a list of additional workspaces names to include in the query.
        /// </para>
        /// <para>
        /// Although this collection cannot be set, it can be modified.
        /// See <see href="https://learn.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#object-initializers-with-collection-read-only-property-initialization">Object initializers with collection read-only property initialization</see>.
        /// </para>
        /// </summary>
        public IList<string> AdditionalWorkspaces { get; } = new ChangeTrackingList<string>();

        /// <summary>
        /// Gets or sets the value indicating whether to throw when a partial error is returned with the logs response.
        /// </summary>
        public bool AllowPartialErrors { get; set; }
    }
}
