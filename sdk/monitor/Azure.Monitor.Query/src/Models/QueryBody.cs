// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.Query.Models
{
    internal partial class QueryBody
    {
        /// <summary> A list of workspaces that are included in the query. </summary>
        public IList<string> Workspaces { get; set; }
        /// <summary> A list of qualified workspace names that are included in the query. </summary>
        public IList<string> QualifiedNames { get; set; }
        /// <summary> A list of workspace IDs that are included in the query. </summary>
        public IList<string> WorkspaceIds { get; set; }
        /// <summary> A list of Azure resource IDs that are included in the query. </summary>
        public IList<string> AzureResourceIds { get; set; }
    }
}