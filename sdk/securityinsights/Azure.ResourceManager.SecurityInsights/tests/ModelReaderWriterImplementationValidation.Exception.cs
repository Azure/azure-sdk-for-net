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
                "Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPackageCollectionGetAllOptions",
                "Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsProductTemplateCollectionGetAllOptions",
                "Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsTemplateCollectionGetAllOptions"
            };
        }
    }
}
