﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace DnsResolver.Tests
{
    internal static class Constants
    {
        public const string DnsResolverLocation = "westus2";
        public const string DnsResolverResourceType = "Microsoft.Network/dnsResolvers";
        public const string ProvisioningStateSucceeded = "Succeeded";
        public const string StaticPrivateIpAllocationMethod = "Static";
        public const string DynamicPrivateIpAllocationMethod = "Dynamic";

        // Add an environment variable as NRP_SIMULATOR_URI with value https://westus2.test.azuremresolver.net:9002
        public const string NrpSimulatorUriEnvironmentVariableName = "NRP_SIMULATOR_URI";
    }
}
