// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;

namespace Azure.Core.Perf
{
    [InProcess]
    [MemoryDiagnoser]
    public class ResourceIdentifierBenchmark
    {
        [Benchmark]
        public ResourceIdentifier Create()
        {
            return new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm");
        }

        [Benchmark]
        public string CreateGetName()
        {
            return new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm").Name;
        }

        [Benchmark]
        public string CreateNavigateParent()
        {
            var id = new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm");
            string x = id.Name;
            x = id.ResourceGroupName;
            x = id.SubscriptionId;
            x = id.Parent.Name;
            x = id.Parent.Parent.Name;
            return id;
        }

        [Benchmark]
        public string CreateAppendProviderAndChild()
        {
            var id = new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg");
            id = id.AppendProviderResource("Microsoft.Compute", "virtualMachines", "myVm");
            id = id.AppendChildResource("children", "myChild");
            return id;
        }
    }
}