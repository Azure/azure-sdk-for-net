// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    internal static class ModelInstances
    {
        internal static readonly AvailabilitySetData s_testAs_3375 = new("eastus")
        {
            Name = "testAS-3375",
            Id = "/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375",
            ResourceType = "Microsoft.Compute/availabilitySets",
            Sku = new ComputeSku()
            {
                Name = "Classic"
            },
            Tags =
                    {
                        { "key", "value" },
                    },
            PlatformUpdateDomainCount = 5,
            PlatformFaultDomainCount = 3,
        };

        internal static readonly AvailabilitySetData s_testAs_3376 = new("eastus")
        {
            Name = "testAS-3376",
            Id = "/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3376",
            ResourceType = "Microsoft.Compute/availabilitySets",
            Sku = new ComputeSku()
            {
                Name = "Classic"
            },
            Tags =
                    {
                        { "key", "value" },
                    },
            PlatformUpdateDomainCount = 6,
            PlatformFaultDomainCount = 4,
        };

        internal static readonly AvailabilitySetData s_testAs_3377 = new("eastus")
        {
            Name = "testAS-3377",
            Id = "/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3377",
            ResourceType = "Microsoft.Compute/availabilitySets",
            Sku = new ComputeSku()
            {
                Name = "Classic"
            },
            Tags =
                    {
                        { "key", "value" },
                    },
            PlatformUpdateDomainCount = 7,
            PlatformFaultDomainCount = 5,
        };

        internal static readonly AvailabilitySetData s_testAs_3378 = new("eastus")
        {
            Name = "testAS-3378",
            Id = "/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3378",
            ResourceType = "Microsoft.Compute/availabilitySets",
            Sku = new ComputeSku()
            {
                Name = "Classic"
            },
            Tags =
                    {
                        { "key", "value" },
                    },
            PlatformUpdateDomainCount = 8,
            PlatformFaultDomainCount = 6,
        };

        internal static readonly AvailabilitySetData s_testAs_3379 = new("eastus")
        {
            Name = "testAS-3379",
            Id = "/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3379",
            ResourceType = "Microsoft.Compute/availabilitySets",
            Sku = new ComputeSku()
            {
                Name = "Classic"
            },
            Tags =
                    {
                        { "key", "value" },
                    },
            PlatformUpdateDomainCount = 9,
            PlatformFaultDomainCount = 7,
        };
    }
}
