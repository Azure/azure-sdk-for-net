// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("logQueryResult")]
    internal partial class LogsBatchQueryResultInternal: LogsQueryResult
    {
        internal ErrorInfo Error { get; }
    }
}