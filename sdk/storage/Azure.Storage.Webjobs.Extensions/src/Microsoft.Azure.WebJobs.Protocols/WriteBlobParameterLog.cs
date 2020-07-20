// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a function parameter log for a write-only blob parameter.</summary>
    [JsonTypeName("WriteBlob")]
#if PUBLICPROTOCOL
    public class WriteBlobParameterLog : ParameterLog
#else
    internal class WriteBlobParameterLog : ParameterLog
#endif
    {
        /// <summary>Gets or sets a value indicating whether the blob was written at all.</summary>
        public bool WasWritten { get; set; }

        /// <summary>When the blob was written, gets or sets the number of bytes written.</summary>
        public long? BytesWritten { get; set; }
    }
}
