// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.ContentUnderstanding
{
    public partial class AnalysisInput
    {
        // CUSTOMIZATION: Replaces the generated InputRange (string) with ContentRange type
        // for a self-documenting API. Wire format (string) preserved via internal backing property.

        [CodeGenMember("InputRange")]
        internal string InputRangeValue { get; set; }

        /// <summary>
        /// Range of the input to analyze. Document content uses 1-based page numbers;
        /// audio/video content uses integer milliseconds.
        /// <code>
        /// input.InputRange = ContentRange.Pages(1, 3);           // "1-3"
        /// input.InputRange = ContentRange.Combine(
        ///     ContentRange.Pages(1, 3),
        ///     ContentRange.Page(5));                              // "1-3,5"
        /// input.InputRange = ContentRange.TimeRange(0, 5000);    // "0-5000"
        /// </code>
        /// </summary>
        /// <seealso cref="ContentRange"/>
        public ContentRange? InputRange
        {
            get => string.IsNullOrEmpty(InputRangeValue) ? null : new ContentRange(InputRangeValue);
            set => InputRangeValue = value?.ToString()!;
        }
    }
}
