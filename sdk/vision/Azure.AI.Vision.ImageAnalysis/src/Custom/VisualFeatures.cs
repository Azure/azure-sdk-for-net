// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Vision.ImageAnalysis
{
    /// <summary>
    /// The visual features requested: tags, objects, caption, denseCaptions, read, smartCrops, people.
    /// </summary>
    [Flags]
    public enum VisualFeatures
    {
        /// <summary>
        /// No visual features are selected.
        /// </summary>
        None = 0,
        /// <summary> Tags. </summary>
        Tags = 1,
        /// <summary> Caption. </summary>
        Caption = 2,
        /// <summary> DenseCaptions. </summary>
        DenseCaptions = 4,
        /// <summary> Objects. </summary>
        Objects = 8,
        /// <summary> Read. </summary>
        Read = 16,
        /// <summary> SmartCrops. </summary>
        SmartCrops = 32,
        /// <summary> People. </summary>
        People = 64
    }
}
