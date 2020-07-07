// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host
{
    internal static class HostQueueNames
    {
        private const string Prefix = "azure-webjobs-";

        private const string HostBlobTriggerQueuePrefix = Prefix + "blobtrigger-";
        private const string HostQueuePrefix = Prefix + "host-";
        private const string HostSharedQueuePrefix = Prefix + "shared-";
        private const string HostSharedPoisonPrefix = Prefix + "poison-";

        // The standard prefix is too long here; this queue is bound by customers.
        public const string BlobTriggerPoisonQueue = "webjobs-blobtrigger-poison";

        /// <summary>Gets the shared host blob trigger queue name.</summary>
        /// <param name="hostId">The host ID.</param>
        /// <returns>The shared host blob trigger queue name.</returns>
        public static string GetHostBlobTriggerQueueName(string hostId)
        {
            return HostBlobTriggerQueuePrefix + hostId;
        }

        /// <summary>
        /// Gets the shared host queue name.
        /// </summary>
        /// <param name="hostId">The host ID.</param>
        /// <returns>The shared host queue name.</returns>
        internal static string GetHostSharedQueueName(string hostId)
        {
            return HostSharedQueuePrefix + hostId;
        }

        /// <summary>
        /// Gets the shared host poison queue name.
        /// </summary>
        /// <param name="hostId">The host ID.</param>
        /// <returns>The shared host poison queue name.</returns>
        internal static string GetHostSharedPoisonQueueName(string hostId)
        {
            return HostSharedPoisonPrefix + hostId;
        }

        /// <summary>Gets the host instance queue name.</summary>
        /// <param name="hostId">The host ID.</param>
        /// <returns>The host instance queue name.</returns>
        public static string GetHostQueueName(string hostId)
        {
            return HostQueuePrefix + hostId;
        }

        public static bool IsHostQueue(string queueName)
        {
            if (string.IsNullOrEmpty(queueName))
            {
                throw new ArgumentNullException("queueName");
            }

            return queueName.StartsWith(Prefix, StringComparison.OrdinalIgnoreCase) ||
                   queueName.StartsWith(BlobTriggerPoisonQueue, StringComparison.OrdinalIgnoreCase);
        }
    }
}
