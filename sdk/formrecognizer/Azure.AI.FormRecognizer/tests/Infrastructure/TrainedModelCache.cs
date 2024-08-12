// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

using ServiceVersion = Azure.AI.FormRecognizer.FormRecognizerClientOptions.ServiceVersion;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// Stores instances of <see cref="DisposableTrainedModel"/> for later use, reducing the amount
    /// of calls to the model training API.
    /// </summary>
    internal static class TrainedModelCache
    {
        /// <summary>
        /// The actual collection storing <see cref="DisposableTrainedModel"/> instances.
        /// </summary>
        public static Dictionary<ModelKey, DisposableTrainedModel> Models { get; } = new();

        /// <summary>
        /// Deletes all cached models.
        /// </summary>
        public static async Task DeleteModelsAsync()
        {
            foreach (var model in Models.Values)
            {
                try
                {
                    await model.DeleteModelAsync();
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
            public ModelKey(ServiceVersion serviceVersion, string containerType, bool useTrainingLabels, string modelName)
            {
                ServiceVersion = serviceVersion;
                ContainerType = containerType;
                UseTrainingLabels = useTrainingLabels;
                ModelName = modelName;
            }

            public ServiceVersion ServiceVersion { get; }

            public string ContainerType { get; }

            public bool UseTrainingLabels { get; }

            public string ModelName { get; }
        }
    }
}
