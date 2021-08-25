// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    using System;

    internal static class AssetScaleGenerator
    {
        /// <summary>
        /// Gets the asset scale from the unit supplied.
        /// </summary>
        /// <param name="unit">The unit of the asset gravity.</param>
        /// <returns>Returns float.</returns>
        /// <exception cref="NotSupportedException"></exception>
        public static float GetAssetScale(AssetLengthUnit unit)
        {
            return unit switch
            {
                AssetLengthUnit.Centimeters => 0.01f,
                AssetLengthUnit.Decimeters => 0.1f,
                AssetLengthUnit.Feet => 0.3048f,
                AssetLengthUnit.Inches => 0.0254f,
                AssetLengthUnit.Kilometers => 1000,
                AssetLengthUnit.Meters => 1,
                AssetLengthUnit.Millimeters => 0.001f,
                AssetLengthUnit.Yards => 0.9144f,
                _ => throw new NotSupportedException($"Unsupported value for '{nameof(unit)}': '{unit}'."),
            };
        }
    }
}
