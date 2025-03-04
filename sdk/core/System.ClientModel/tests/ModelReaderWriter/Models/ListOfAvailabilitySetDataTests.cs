// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using Azure.Core;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    public class ListOfAvailabilitySetDataTests : CollectionTests<List<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override ModelReaderWriterContext Context => new TestClientModelReaderWriterContext();

        internal static readonly AvailabilitySetData s_testAs_3375 = new(AzureLocation.EastUS)
        {
            Name = "testAS-3375",
            Id = new ResourceIdentifier("/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375"),
            ResourceType = new ResourceType("Microsoft.Compute/availabilitySets"),
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

        internal static readonly AvailabilitySetData s_testAs_3376 = new(AzureLocation.EastUS)
        {
            Name = "testAS-3376",
            Id = new ResourceIdentifier("/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3376"),
            ResourceType = new ResourceType("Microsoft.Compute/availabilitySets"),
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

        protected override List<AvailabilitySetData> GetModelInstance()
        {
            return [s_testAs_3375, s_testAs_3376];
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);
    }
}
