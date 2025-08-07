// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;

namespace Azure.Core.Perf
{
    [InProcess]
    public class ResourceIdentifierBenchmark
    {
        [Benchmark]
        public void TryParseInvalidWithCatch()
        {
            try
            {
                ResourceIdentifier.Parse("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/virtualMachines/myVm");
            }
            catch
            {
            }
        }

        [Benchmark]
        public void TryParseInvalid()
        {
            ResourceIdentifier.TryParse("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/virtualMachines/myVm", out var resourceIdentifier);
        }

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
        public string CreateNavigateParentWithResourceType()
        {
            var id = new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm");
            AccessMembers(id);
            return id;
        }

        private static void AccessMembers(ResourceIdentifier id)
        {
            string x = id.Name;
            x = id.ResourceGroupName;
            x = id.SubscriptionId;
            x = id.Parent.Name;
            x = id.Parent.Parent.Name;
            x = id.ResourceType.Namespace;
            x = id.Parent.ResourceType.Namespace;
            x = id.Parent.Parent.ResourceType.Namespace;
        }

        [Benchmark]
        public string CreateAccessResourceTypeMultipleTimes()
        {
            var id = new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm");
            for (int i = 0; i < 100; i++)
            {
                string x = id.ResourceType.Namespace;
            }
            return id;
        }

        [Benchmark]
        public void CreateAppendProviderAndChild()
        {
            var id = new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg");
            id = id.AppendProviderResource("Microsoft.Compute", "virtualMachines", "myVm");
            id = id.AppendChildResource("children", "myChild");
        }

        [Benchmark]
        public void CreateAppendProviderAndChildAndAccess()
        {
            var id = new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg");
            AccessMembers(id);
            id = id.AppendProviderResource("Microsoft.Compute", "virtualMachines", "myVm");
            AccessMembers(id);
            id = id.AppendChildResource("children", "myChild");
            AccessMembers(id);
        }
    }
}
