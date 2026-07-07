// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Customizations for <see cref="TranscriptPhrase"/> to expose time properties as <see cref="TimeSpan"/>.
    /// </summary>
    public partial class TranscriptPhrase
    {
        // CUSTOMIZATION: Hide the generated long millisecond properties and expose TimeSpan instead.
        [CodeGenMember("StartTimeMs")]
        internal long StartTimeMsValue { get; }

        [CodeGenMember("EndTimeMs")]
        internal long EndTimeMsValue { get; }

        /// <summary> Gets the start time of the phrase. </summary>
        public TimeSpan StartTime => TimeSpan.FromMilliseconds(StartTimeMsValue);

        /// <summary> Gets the end time of the phrase. </summary>
        public TimeSpan EndTime => TimeSpan.FromMilliseconds(EndTimeMsValue);
    }
}
