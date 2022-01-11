// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using BenchmarkDotNet.Attributes;

namespace Azure.Template.Perf
{
    [InProcess]
    [MemoryDiagnoser]
    public class ResourceIdentifierBenchmark
    {
        [Benchmark]
        public ResourceIdentifier Create()
        {
            return new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Network/vortualNetworks/myNet/subnets/mySubnet");
        }

        [Benchmark]
        public string CreateGetName()
        {
            return new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Network/vortualNetworks/myNet/subnets/mySubnet").Name;
        }

        [Benchmark]
        public ResourceType CreateGetType()
        {
            return new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Network/vortualNetworks/myNet/subnets/mySubnet").ResourceType;
        }
    }
}