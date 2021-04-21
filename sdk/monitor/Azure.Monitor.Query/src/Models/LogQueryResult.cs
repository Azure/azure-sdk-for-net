// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("QueryResults")]
    public partial class LogsQueryResult
    {
        // TODO: Handle not found
        public LogsQueryResultTable PrimaryTable => Tables.Single(t => t.Name == "PrimaryResult");
    }
}