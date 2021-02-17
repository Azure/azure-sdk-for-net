// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.ModelsRepository
{
    internal static class ModelRepositoryConstants
    {
        // Set EventSource name to package name replacing '.' with '-'
        public const string ModelRepositoryEventSourceName = "Azure-Iot-ModelsRepository";

        public const string DefaultModelsRepository = "https://devicemodels.azure.com";

        // File Extensions
        public const string JsonFileExtension = ".json";
        public const string ExpandedJsonFileExtension = ".expanded.json";
    }
}
