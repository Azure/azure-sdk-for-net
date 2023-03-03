// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public partial class DocumentStyle
    {
        /// <summary>
        /// Visually most similar font from among the set of supported font families, with fallback fonts
        /// following CSS convention (ex. &apos;Arial, sans-serif&apos;).
        /// </summary>
        internal string SimilarFontFamily { get; }

        /// <summary>
        /// Font style.
        /// </summary>
        internal FontStyle? FontStyle { get; }

        /// <summary>
        /// Font weight.
        /// </summary>
        internal FontWeight? FontWeight { get; }

        /// <summary>
        /// Foreground color in #rrggbb hexadecimal format.
        /// </summary>
        internal string Color { get; }

        /// <summary>
        /// Background color in #rrggbb hexadecimal format.
        /// </summary>
        internal string BackgroundColor { get; }
    }
}
