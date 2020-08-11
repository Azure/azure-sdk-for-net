// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Compute.Tests
{
    public static class ApiConstants
    {
        public const string
            Subscriptions = "subscriptions",
            ResourceGroups = "resourceGroups",
            Providers = "providers",
            VirtualMachines = "virtualMachines",
            AvailabilitySets = "availabilitySets",
            ProximityPlacementGroups = "proximityPlacementGroups",
            VMScaleSets = "virtualMachineScaleSets",
            ResourceProviderNamespace = "Microsoft.Compute";
    }
#pragma warning disable SA1402 // File may only contain a single type
    public static class Constants
#pragma warning restore SA1402 // File may only contain a single type
    {
        public const string StorageAccountBlobUriTemplate = "https://{0}.blob.core.windows.net/";
    }
}
