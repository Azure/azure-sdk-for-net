// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents the definition of a host instance heartbeat blob.</summary>
    /// <remarks>While it is running, the host instance periodically updates the blob's LastModified time.</remarks>
#if PUBLICPROTOCOL
    public class HeartbeatDescriptor
#else
    internal class HeartbeatDescriptor
#endif
    {
        /// <summary>Gets or sets the name of the heartbeat container shared by all instances of the host.</summary>
        public string SharedContainerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the directory in <see cref="SharedContainerName"/> shared by all instances of the
        /// host.
        /// </summary>
        public string SharedDirectoryName { get; set; }

        /// <summary>
        /// Gets or sets the name of the blob in <see cref="SharedDirectoryName"/>.
        /// </summary>
        public string InstanceBlobName { get; set; }

        /// <summary>
        /// Gets or sets the number of seconds after the blob's LastModified time during which the heartbeat is still
        /// valid.
        /// </summary>
        public int ExpirationInSeconds { get; set; }
    }
}
