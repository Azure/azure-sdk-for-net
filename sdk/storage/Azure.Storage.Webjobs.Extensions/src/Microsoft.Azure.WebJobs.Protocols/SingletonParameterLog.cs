// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Newtonsoft.Json;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>
    /// Represents a function parameter log for a virtual singleton parameter.
    /// </summary>
    [JsonTypeName("Singleton")]
#if PUBLICPROTOCOL
    public class SingletonParameterLog : ParameterLog
#else
    internal class SingletonParameterLog : ParameterLog
#endif
    {
        /// <summary>
        /// Gets or sets the time that has been spent waiting for the lock.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public TimeSpan? TimeToAcquireLock { get; set; }

        /// <summary>
        /// Gets or sets the total time the lock was held.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public TimeSpan? LockDuration { get; set; }

        /// <summary>
        /// Gets or sets the current lock owner.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LockOwner { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the lock has been acquired.
        /// </summary>
        public bool LockAcquired { get; set; }
    }
}
