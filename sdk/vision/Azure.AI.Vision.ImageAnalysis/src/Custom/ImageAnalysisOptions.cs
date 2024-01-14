// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Azure.AI.Vision.ImageAnalysis
{
    /// <summary>
    /// Options for a single image analysis operation.
    /// </summary>
    public struct ImageAnalysisOptions
    {
        /// <summary>
        /// The desired Language for output generation. If this parameter is not specified, the default value is "en". See https://aka.ms/cv-languages for a list of supported languages.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Boolean flag for enabling gender-neutral captioning for caption and denseCaptions features. If this parameter is not specified, the default value is "false".
        /// </summary>
        public bool? GenderNeutralCaption { get; set; }

        /// <summary>
        /// A list of aspect ratios to use for smartCrops feature. Aspect ratios are calculated by dividing the target crop width by the height. Supported values are between 0.75 and 1.8 (inclusive). Multiple values should be comma-separated. If this parameter is not specified, the service will return one crop suggestion with an aspect ratio it sees fit between 0.5 and 2.0 (inclusive).
        /// </summary>
        public IEnumerable<float> SmartCropsAspectRatios { get; set; }

        /// <summary>
        /// The version of cloud AI-model used for analysis.
        /// </summary>
        /// <remarks>
        /// The format is the following: 'latest' (default value) or 'YYYY-MM-DD' or 'YYYY-MM-DD-preview', where `YYYY`, `MM`, `DD` are the year, month and day.
        /// </remarks>
        public string ModelVersion { get; set; }
    }
}
