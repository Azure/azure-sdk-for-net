// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.Query.Logs.Models
{
    /// <summary>
    /// Represents a status of a batch query response.
    /// </summary>
    public enum LogsQueryResultStatus
    {
        /// <summary>
        /// The query succeeded.
        /// </summary>
        Success,
        /// <summary>
        /// The query partially succeeded, both data and an error was returned.
        /// </summary>
        PartialFailure,
        /// <summary>
        /// The query failed.
        /// </summary>
        Failure
    }
}
