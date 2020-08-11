// ------------------------------------------------------------------------------------------------
// <copyright file="TestDataGenerator.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace PrivateDns.Tests
{
    internal static class Constants
    {
        public const string PrivateDnsZonesResourceType = "Microsoft.Network/privateDnsZones";
        public const string PrivateDnsZonesLocation = "global";

        public const string PrivateDnsZonesVirtualNetworkLinksResourceType = "Microsoft.Network/privateDnsZones/virtualNetworkLinks";
        public const string PrivateDnsZonesVirtualNetworkLinksLocation = "global";

        public const string ProvisioningStateSucceeded = "Succeeded";

        public const string VirtualNetworkLinkStateCompleted = "Completed";
        public const string VirtualNetworkLinkStateInProgress = "InProgress";
    }
}
