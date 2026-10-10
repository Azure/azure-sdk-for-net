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
                // HybridComputeLocation is a backward-compatible alias for LocationData (inherits from LocationData which implements IJsonModel<LocationData>)
                "Azure.ResourceManager.HybridCompute.Models.HybridComputeLocation",
                // HybridComputeLicense is a backward-compatible alias for HybridComputeLicenseData (inherits from HybridComputeLicenseData which implements IJsonModel<HybridComputeLicenseData>)
                "Azure.ResourceManager.HybridCompute.Models.HybridComputeLicense",
            };
        }
    }
}
