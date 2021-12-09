// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a function parameter log for a table parameter.</summary>
    [JsonTypeName("Table")]
#if PUBLICPROTOCOL
    public class TableParameterLog : ParameterLog
#else
    internal class TableParameterLog : ParameterLog
#endif
    {
        /// <summary>Gets or sets the number of entities inserted or replaced.</summary>
        public int EntitiesWritten { get; set; }

        /// <summary>Gets or sets the number of entities updated.</summary>
        [Obsolete("Use the EntitiesWritten property instead.")]
        public int EntitiesUpdated
        {
            get => EntitiesWritten;
            set => EntitiesWritten = value;
        }

        /// <summary>Gets or sets the approximate amount of time spent performing write I/O.</summary>
        public TimeSpan ElapsedWriteTime { get; set; }
    }
}