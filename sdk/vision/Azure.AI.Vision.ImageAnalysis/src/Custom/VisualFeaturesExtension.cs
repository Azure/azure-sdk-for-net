// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Vision.ImageAnalysis
{
    internal static class VisualFeaturesExtension
    {
        public static IEnumerable<VisualFeaturesImpl> ToImplArray(this VisualFeatures features)
        {
            List<VisualFeaturesImpl> result = new();

            if (features.HasFlag(VisualFeatures.Tags))
            {
                result.Add(VisualFeaturesImpl.Tags);
            }
            if (features.HasFlag(VisualFeatures.Caption))
            {
                result.Add(VisualFeaturesImpl.Caption);
            }
            if (features.HasFlag(VisualFeatures.DenseCaptions))
            {
                result.Add(VisualFeaturesImpl.DenseCaptions);
            }
            if (features.HasFlag(VisualFeatures.Objects))
            {
                result.Add(VisualFeaturesImpl.Objects);
            }
            if (features.HasFlag(VisualFeatures.Read))
            {
                result.Add(VisualFeaturesImpl.Read);
            }
            if (features.HasFlag(VisualFeatures.SmartCrops))
            {
                result.Add(VisualFeaturesImpl.SmartCrops);
            }
            if (features.HasFlag(VisualFeatures.People))
            {
                result.Add(VisualFeaturesImpl.People);
            }
            return result.ToArray();
        }
    }
}
