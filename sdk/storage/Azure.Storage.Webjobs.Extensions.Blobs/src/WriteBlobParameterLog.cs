// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Host.Protocols
{
    /// <summary>Represents a function parameter log for a write-only blob parameter.</summary>
    [JsonTypeName("WriteBlob")]
    internal class WriteBlobParameterLog : ParameterLog
    {
        /// <summary>Gets or sets a value indicating whether the blob was written at all.</summary>
        public bool WasWritten { get; set; }

        /// <summary>When the blob was written, gets or sets the number of bytes written.</summary>
        public long? BytesWritten { get; set; }
    }
}
