// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.Query.Logs
{
    public partial class LogsQueryClientOptions
    {
        /// <summary>
        /// Gets or sets the audience to use for authentication with Microsoft Entra ID. The audience is not considered when using a shared key.
        /// </summary>
        /// <value>If <c>null</c>, <see cref="LogsQueryAudience.AzurePublicCloud" /> will be assumed.</value>
        public LogsQueryAudience? Audience { get; set; }
    }
}
