// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.VoiceLive
{
    /// <summary> Configuration for animation outputs including blendshapes, visemes, and emotion metadata. </summary>
    public partial class AnimationOptions
    {
        /// <summary> Interval for emotion detection in milliseconds. If not set, emotion detection is disabled. </summary>
        public int? EmotionDetectionIntervalMs { get; set; }

        /// <summary> Interval for emotion detection. If not set, emotion detection is disabled. </summary>
        public TimeSpan? EmotionDetectionInterval
        {
            get => EmotionDetectionIntervalMs.HasValue ? TimeSpan.FromMilliseconds(EmotionDetectionIntervalMs.Value) : (TimeSpan?)null;
            set => EmotionDetectionIntervalMs = value.HasValue ? (int?)value.Value.TotalMilliseconds : null;
        }
    }
}
