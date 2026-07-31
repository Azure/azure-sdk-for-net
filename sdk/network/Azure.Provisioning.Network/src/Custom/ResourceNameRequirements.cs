// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;

#pragma warning disable CS1591 // Missing XML comment for compatibility overrides
#pragma warning disable SA1402 // Keep Network resource name requirements together.

namespace Azure.Provisioning.Network
{
    public partial class ApplicationSecurityGroup
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Standard;
    }

    public partial class FirewallPolicy
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Standard;
    }

    public partial class LoadBalancer
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Standard;
    }

    public partial class InboundNatRule
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Standard;
    }

    public partial class NetworkInterface
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Standard;
    }

    public partial class NetworkSecurityGroup
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Standard;
    }

    public partial class SecurityRule
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Standard;
    }

    public partial class NetworkWatcher
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Standard;
    }

    public partial class PrivateEndpoint
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Restricted;
    }

    public partial class PrivateLinkService
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Restricted;
    }

    public partial class NetworkPrivateEndpointConnection
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Restricted;
    }

    public partial class PublicIPAddress
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Standard;
    }

    public partial class PublicIPPrefix
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Standard;
    }

    public partial class RouteTable
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Standard;
    }

    public partial class RouteResource
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Standard;
    }

    public partial class ServiceEndpointPolicy
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Standard;
    }

    public partial class VirtualNetwork
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Restricted;
    }

    public partial class SubnetResource
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Standard;
    }

    public partial class VirtualNetworkPeering
    {
        public override ResourceNameRequirements GetResourceNameRequirements() => NetworkResourceNameRequirements.Standard;
    }

    internal static class NetworkResourceNameRequirements
    {
        private const ResourceNameCharacters ValidCharacters =
            ResourceNameCharacters.LowercaseLetters |
            ResourceNameCharacters.UppercaseLetters |
            ResourceNameCharacters.Numbers |
            ResourceNameCharacters.Hyphen |
            ResourceNameCharacters.Underscore |
            ResourceNameCharacters.Period;

        internal static ResourceNameRequirements Standard => new(1, 80, ValidCharacters);

        internal static ResourceNameRequirements Restricted => new(2, 64, ValidCharacters);
    }
}
