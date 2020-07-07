// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a function parameter log for a read-only blob parameter.</summary>
    [JsonTypeName("ReadBlob")]
#if PUBLICPROTOCOL
    public class ReadBlobParameterLog : ParameterLog
#else
    internal class ReadBlobParameterLog : ParameterLog
#endif
    {
        /// <summary>Gets or sets the number of bytes read.</summary>
        public long BytesRead { get; set; }

        /// <summary>Gets or sets the total number of bytes available to read.</summary>
        public long Length { get; set; }

        /// <summary>Gets or sets the approximate amount of time spent performing I/O.</summary>
        public TimeSpan ElapsedTime { get; set; }
    }
}
