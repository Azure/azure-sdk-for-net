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
                "Azure.ResourceManager.Resources.Models.SubResource",
                "Azure.ResourceManager.Resources.Models.WritableSubResource",
                "Azure.ResourceManager.Models.ResourceData",
                "Azure.ResourceManager.Models.TrackedResourceData",
                "Azure.ResourceManager.ManagementGroups.Models.ManagementGroupCollectionGetEntitiesOptions"
            };
        }
    }
}
