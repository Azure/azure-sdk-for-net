// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Provides well-known container names in the protocol.</summary>
#if PUBLICPROTOCOL
    public static class ContainerNames
#else
    internal static class ContainerNames
#endif
    {
        private const string Prefix = "azure-jobs-";

        /// <summary>The name of the container where protocol messages from the host are stored.</summary>
        public const string HostOutput = Prefix + "host-output";

        /// <summary>
        /// The name of the container where protocol messages from the host are archived after processing.
        /// </summary>
        public const string HostArchive = Prefix + "host-archive";
    }
}
