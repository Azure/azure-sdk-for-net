// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

using ServiceVersion = Azure.AI.FormRecognizer.FormRecognizerClientOptions.ServiceVersion;

namespace Azure.AI.FormRecognizer.Tests
{
    internal static class TrainedModelCache
    {
        public static Dictionary<ModelKey, DisposableTrainedModel> Models { get; } = new();

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
