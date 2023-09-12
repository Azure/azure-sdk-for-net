// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ServiceVersion = Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions.ServiceVersion;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    internal static class DocumentModelCache
    {
        public static Dictionary<ModelKey, DisposableDocumentModel> Models { get; } = new();

        public static async Task DeleteModelsAsync()
        {
            foreach (var model in Models.Values)
            {
                try
                {
                    await model.DeleteAsync();
                }
                catch
                {
                    // ignore
                }
            }

            Models.Clear();
        }

        public readonly struct ModelKey
        {
            public ModelKey(ServiceVersion serviceVersion, string containerType, DocumentBuildMode buildMode, BuildDocumentModelOptions options)
            {
                ServiceVersion = serviceVersion;
                ContainerType = containerType;
                BuildMode = buildMode;

                if (options != null)
                {
                    Description = options.Description;
                    Tags = string.Join(",", options.Tags.Select(kvp => kvp.ToString()));
                }
            }

            public ServiceVersion ServiceVersion { get; }

            public string ContainerType { get; }

            public DocumentBuildMode BuildMode { get; }

            public string Description { get; }

            public string Tags { get; }
        }
    }
}
