// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Vision.ImageAnalysis
{
    /// <inheritdoc cref="VisualFeaturesImpl"/>
    [Flags]
    public enum VisualFeatures
    {
        /// <summary>
        /// No visual features are selected.
        /// </summary>
        None = 0,
        /// <inheritdoc cref="VisualFeaturesImpl.Tags"/>
        Tags = 1,
        /// <inheritdoc cref="VisualFeaturesImpl.Caption"/>
        Caption = 2,
        /// <inheritdoc cref="VisualFeaturesImpl.DenseCaptions"/>
        DenseCaptions = 4,
        /// <inheritdoc cref="VisualFeaturesImpl.Objects"/>
        Objects = 8,
        /// <inheritdoc cref="VisualFeaturesImpl.Read"/>
        Read = 16,
        /// <inheritdoc cref="VisualFeaturesImpl.SmartCrops"/>
        SmartCrops = 32,
        /// <inheritdoc cref="VisualFeaturesImpl.People"/>
        People = 64
    }
}
