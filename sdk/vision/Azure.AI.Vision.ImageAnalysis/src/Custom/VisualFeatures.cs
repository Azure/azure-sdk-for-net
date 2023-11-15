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
        None,
        /// <summary> Tags. </summary>
        Tags,
        /// <summary> Caption. </summary>
        Caption,
        /// <summary> DenseCaptions. </summary>
        DenseCaptions,
        /// <summary> Objects. </summary>
        Objects,
        /// <summary> Read. </summary>
        Read,
        /// <summary> SmartCrops. </summary>
        SmartCrops,
        /// <summary> People. </summary>
        People
    }
}
