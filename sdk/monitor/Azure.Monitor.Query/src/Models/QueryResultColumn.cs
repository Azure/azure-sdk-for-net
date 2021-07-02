// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("Column")]
    public partial class LogsQueryResultColumn
    {
        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Name} ({Type})";
        }
    }
}