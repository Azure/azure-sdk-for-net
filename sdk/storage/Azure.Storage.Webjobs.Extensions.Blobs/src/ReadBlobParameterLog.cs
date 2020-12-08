// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Host.Protocols
{
    /// <summary>Represents a function parameter log for a read-only blob parameter.</summary>
    [JsonTypeName("ReadBlob")]
    internal class ReadBlobParameterLog : ParameterLog
    {
        /// <summary>Gets or sets the number of bytes read.</summary>
        public long BytesRead { get; set; }

        /// <summary>Gets or sets the total number of bytes available to read.</summary>
        public long Length { get; set; }

        /// <summary>Gets or sets the approximate amount of time spent performing I/O.</summary>
        public TimeSpan ElapsedTime { get; set; }
    }
}
