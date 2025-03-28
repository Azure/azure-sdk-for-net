// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.TestFramework
{
    public sealed partial class ModelReaderWriterImplementationValidation
    {
        public ModelReaderWriterImplementationValidation()
        {
            ExceptionList = new[]
            {
                "Azure.ResourceManager.Compute.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions",
                "Azure.ResourceManager.Compute.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions",
                "Azure.ResourceManager.Compute.Models.SubscriptionResourceGetVirtualMachineImagesOptions",
                "Azure.ResourceManager.Compute.Models.SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions"
            };
        }
    }
}
