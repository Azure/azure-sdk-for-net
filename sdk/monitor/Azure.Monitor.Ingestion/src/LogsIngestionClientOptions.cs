// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Monitor.Ingestion
{
    /// <summary> Client options for <see cref="LogsIngestionClient"/>. </summary>
    public partial class LogsIngestionClientOptions : ClientOptions
    {
        /// <summary>
        /// Gets or sets the audience to use for authentication with Azure Active Directory (AAD). The audience is not considered when using a shared key.
        /// </summary>
        /// <value>If <c>null</c>, <see cref="LogsIngestionAudience.AzurePublicCloud" /> will be assumed.</value>
        public LogsIngestionAudience? Audience { get; set; }
    }
}
