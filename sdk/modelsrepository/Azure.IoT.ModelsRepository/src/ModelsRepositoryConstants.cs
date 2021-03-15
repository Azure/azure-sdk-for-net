// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.ModelsRepository
{
    internal static class ModelsRepositoryConstants
    {
        // Set EventSource name to package name replacing '.' with '-'
        public const string ModelRepositoryEventSourceName = "Azure-Iot-ModelsRepository";

        public const string DefaultModelsRepository = "https://devicemodels.azure.com";

        // File Extensions
        public const string JsonFileExtension = ".json";
        public const string ExpandedJsonFileExtension = ".expanded.json";
        public const string UriFileSchema = "file";

        /// <summary>
        /// The ModelRepositoryConstants.ModelProperties class contains DTDL v2 property names and property values
        /// used by the ModelQuery class to parse DTDL model key indicators.
        /// </summary>
        internal static class ModelProperties
        {
            public const string Dtmi = "@id";
            public const string Type = "@type";
            public const string Extends = "extends";
            public const string Contents = "contents";
            public const string Schema = "schema";
            public const string TypeValueInterface = "Interface";
            public const string TypeValueComponent = "Component";
        }
    }
}
