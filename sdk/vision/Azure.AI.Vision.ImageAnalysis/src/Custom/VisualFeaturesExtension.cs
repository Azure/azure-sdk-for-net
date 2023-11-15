// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Vision.ImageAnalysis
{
    internal static class VisualFeaturesExtension
    {
        public static string[] ToStringArray(this VisualFeatures features)
        {
            List<string> result = new List<string>();

            if (features.HasFlag(VisualFeatures.Tags))
            {
                result.Add(VisualFeaturesImpl.Tags.ToString());
            }
            if (features.HasFlag(VisualFeatures.Caption))
            {
                result.Add(VisualFeaturesImpl.Caption.ToString());
            }
            if (features.HasFlag(VisualFeatures.DenseCaptions))
            {
                result.Add(VisualFeaturesImpl.DenseCaptions.ToString());
            }
            if (features.HasFlag(VisualFeatures.Objects))
            {
                result.Add(VisualFeaturesImpl.Objects.ToString());
            }
            if (features.HasFlag(VisualFeatures.Read))
            {
                result.Add(VisualFeaturesImpl.Read.ToString());
            }
            if (features.HasFlag(VisualFeatures.SmartCrops))
            {
                result.Add(VisualFeaturesImpl.SmartCrops.ToString());
            }
            if (features.HasFlag(VisualFeatures.People))
            {
                result.Add(VisualFeaturesImpl.People.ToString());
            }
            return result.ToArray();
        }
    }
}
