// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Personalizer.Models
{
    internal partial class PersonalizerClientProperties
    {
        internal static PersonalizerClientProperties DeserializePersonalizerServiceProperties(JsonElement element)
        {
            string applicationID = default;
            string modelBlobUri = default;
            float initialExplorationEpsilon = default;
            PersonalizerLearningMode learningMode = default;
            string initialCommandLine = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("applicationID"))
                {
                    applicationID = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("modelBlobUri"))
                {
                    modelBlobUri = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("initialExplorationEpsilon"))
                {
                    initialExplorationEpsilon = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("learningMode"))
                {
                    learningMode = new PersonalizerLearningMode(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("initialCommandLine"))
                {
                    learningMode = new PersonalizerLearningMode(property.Value.GetString());
                    continue;
                }
            }
                return new PersonalizerClientProperties(applicationID, modelBlobUri, initialExplorationEpsilon, learningMode, initialCommandLine);
        }
    }
}
