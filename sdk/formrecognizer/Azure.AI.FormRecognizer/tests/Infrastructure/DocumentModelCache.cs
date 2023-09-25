// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ServiceVersion = Azure.AI.FormRecognizer.DocumentAnalysis.DocumentAnalysisClientOptions.ServiceVersion;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// Stores instances of <see cref="DisposableDocumentModel"/> for later use, reducing the amount
    /// of calls to the model building API.
    /// </summary>
    internal static class DocumentModelCache
    {
        /// <summary>
        /// The actual collection storing <see cref="DisposableDocumentModel"/> instances.
        /// </summary>
        public static Dictionary<ModelKey, DisposableDocumentModel> Models { get; } = new();

        /// <summary>
        /// Deletes all cached models.
        /// </summary>
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

        /// <summary>
        /// A key used the <see cref="Models"/> dictionary to indicate whether two models are the same.
        /// </summary>
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
