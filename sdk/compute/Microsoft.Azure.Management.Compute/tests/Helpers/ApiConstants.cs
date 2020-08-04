// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Compute.Tests
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
            HostGroups = "hostGroups",
            Hosts = "hosts",
            VMScaleSets = "virtualMachineScaleSets",
            ResourceProviderNamespace = "Microsoft.Compute";
    }

    public static class Constants
    {
        public const string StorageAccountBlobUriTemplate = "https://{0}.blob.core.windows.net/";
    }
}
