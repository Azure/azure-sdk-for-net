// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.Query.Logs.Models
{
    internal partial class QueryBody
    {
        /// <summary> A list of workspaces that are included in the query. </summary>
        public IList<string> Workspaces { get; set; }
    }
}
