// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.IoT.ModelsRepository
{
    /// <summary>
    /// ModelsRepositoryMetadata is used to deserialize the contents
    /// of the Models Repository metadata file as defined by
    /// https://github.com/Azure/iot-plugandplay-models-tools/wiki/Publishing-Metadata.
    /// </summary>
    internal class ModelsRepositoryMetadata
    {
        [JsonPropertyName("commitId")]
        public string CommitId { get; set; }

        [JsonPropertyName("publishDateUtc")]
        public string PublishDateUtc { get; set; }

        [JsonPropertyName("sourceRepo")]
        public string SourceRepo { get; set; }

        [JsonPropertyName("totalModelCount")]
        public int TotalModelCount { get; set; }

        [JsonPropertyName("features")]
        public RepositoryFeatures Features { get; set; }

        internal class RepositoryFeatures
        {
            [JsonPropertyName("expanded")]
            public bool Expanded { get; set; }

            [JsonPropertyName("index")]
            public bool Index { get; set; }
        }

        public ModelsRepositoryMetadata(RepositoryFeatures features)
        {
            Features = features;
        }

        public ModelsRepositoryMetadata(): this(new RepositoryFeatures())
        {
        }
    }
}
