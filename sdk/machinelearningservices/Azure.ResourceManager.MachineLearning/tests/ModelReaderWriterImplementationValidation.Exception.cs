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
                "Azure.ResourceManager.MachineLearning.Models.MachineLearningDatastoreCollectionGetAllOptions",
                "Azure.ResourceManager.MachineLearning.Models.MachineLearningDataVersionCollectionGetAllOptions",
                "Azure.ResourceManager.MachineLearning.Models.MachineLearningFeatureSetContainerCollectionGetAllOptions",
                "Azure.ResourceManager.MachineLearning.Models.MachineLearningFeatureSetVersionCollectionGetAllOptions",
                "Azure.ResourceManager.MachineLearning.Models.MachineLearningFeatureStoreEntityContainerCollectionGetAllOptions",
                "Azure.ResourceManager.MachineLearning.Models.MachineLearningFeaturestoreEntityVersionCollectionGetAllOptions",
                "Azure.ResourceManager.MachineLearning.Models.MachineLearningJobCollectionGetAllOptions",
                "Azure.ResourceManager.MachineLearning.Models.MachineLearningModelVersionCollectionGetAllOptions",
                "Azure.ResourceManager.MachineLearning.Models.MachineLearningOnlineEndpointCollectionGetAllOptions",
                "Azure.ResourceManager.MachineLearning.Models.MachineLearningRegistryModelVersionCollectionGetAllOptions",
                "Azure.ResourceManager.MachineLearning.Models.MachineLearningFeatureCollectionGetAllOptions"
            };
        }
    }
}
