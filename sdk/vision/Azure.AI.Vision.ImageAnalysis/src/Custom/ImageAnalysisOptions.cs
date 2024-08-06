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
        /// The desired language for result generation (a two-letter language code).
        /// </summary>
        /// <remarks>
        /// If this option is not specified, the default value 'en' is used (English).
        /// See https://aka.ms/cv-languages for a list of supported languages.
        /// At the moment, only tags can be generated in non-English languages.
        /// </remarks>
        public string Language { get; set; }

        /// <summary>
        /// Boolean flag for enabling gender-neutral captioning for Caption and Dense Captions features.
        /// </summary>
        /// <remarks>
        /// By default captions may contain gender terms (for example: 'man', 'woman', or 'boy', 'girl').
        /// If you set this to "true", those will be replaced with gender-neutral terms (for example: 'person' or 'child').
        /// </remarks>
        public bool? GenderNeutralCaption { get; set; }

        /// <summary>
        /// A list of aspect ratios to use for smart cropping.
        /// </summary>
        /// <remarks>
        /// Aspect ratios are calculated by dividing the target crop width in pixels by the height in pixels.
        /// Supported values are between 0.75 and 1.8 (inclusive).
        /// If this parameter is not specified, the service will return one crop region with an aspect
        /// ratio it sees fit between 0.5 and 2.0 (inclusive).
        /// </remarks>
        public IEnumerable<float> SmartCropsAspectRatios { get; set; }

        /// <summary>
        /// The version of cloud AI-model used for analysis.
        /// </summary>
        /// <remarks>
        /// The format is the following: 'latest' (default value) or 'YYYY-MM-DD' or 'YYYY-MM-DD-preview', where 'YYYY', 'MM', 'DD' are the year, month and day associated with the model.
        /// This is not commonly set, as the default always gives the latest AI model with recent improvements.
        /// If however you would like to make sure analysis results do not change over time, set this value to a specific model version.
        /// </remarks>
        public string ModelVersion { get; set; }
    }
}
