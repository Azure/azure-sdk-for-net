// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Generator.CSharp.Primitives;
using System;
using System.Collections.Generic;
using System.Net;

namespace Azure.Generator.Primitives
{
    internal static class KnownAzureTypes
    {
        private const string UuidId = "Azure.Core.uuid";
        private const string IPv4AddressId = "Azure.Core.ipV4Address";
        private const string IPv6AddressId = "Azure.Core.ipV6Address";
        private const string ETagId = "Azure.Core.eTag";
        private const string AzureLocationId = "Azure.Core.azureLocation";
        private const string ArmIdId = "Azure.Core.armResourceIdentifier";

        internal static readonly IReadOnlyDictionary<string, CSharpType> PrimitiveTypes = new Dictionary<string, CSharpType>
        {
            [UuidId] = typeof(Guid),
            [IPv4AddressId] = typeof(IPAddress),
            [IPv6AddressId] = typeof(IPAddress),
            [ETagId] = typeof(ETag),
            [AzureLocationId] = typeof(AzureLocation),
            [ArmIdId] = typeof(ResourceIdentifier),
        };
    }
}
