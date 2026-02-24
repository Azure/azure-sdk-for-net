// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Represents a face tracklet — a continuous track of a detected face across consecutive video frames.
    /// Encoded as <c>AV(startTime,x,y,w,h)-AV(endTime,x,y,w,h)</c> in the wire format.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A tracklet captures where a face appeared at the start and end of one continuous appearance.
    /// The <c>-</c> separator joins the start/end frames within a single tracklet.
    /// Multiple tracklets for the same person (reappearing after being absent) are separated by <c>;</c>
    /// and returned as separate <see cref="TrackletSource"/> elements in the <see cref="ContentField.GroundingSources"/> array.
    /// </para>
    /// </remarks>
    public class TrackletSource : ContentSource
    {
        /// <summary> Gets the audio/visual source at the start of the tracklet. </summary>
        public AudioVisualSource Start { get; }

        /// <summary> Gets the audio/visual source at the end of the tracklet. </summary>
        public AudioVisualSource End { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="TrackletSource"/> by parsing a tracklet pair string.
        /// </summary>
        /// <param name="source"> The raw source string in the format <c>AV(...)-AV(...)</c>. </param>
        /// <exception cref="System.FormatException"> The source string is not a valid tracklet pair. </exception>
        internal TrackletSource(string source) : base(source)
        {
            // Split on ")-AV(" to find the boundary between the two AV segments
            const string separator = ")-AV(";
            int separatorIndex = source.IndexOf(separator, System.StringComparison.Ordinal);

            if (separatorIndex < 0)
            {
                throw new System.FormatException($"Expected a tracklet pair in the format 'AV(...)-AV(...)': '{source}'.");
            }

            string first = source.Substring(0, separatorIndex + 1); // include the closing ')'
            string second = source.Substring(separatorIndex + 2);   // skip the '-', start at 'AV('

            Start = new AudioVisualSource(first);
            End = new AudioVisualSource(second);
        }

        /// <summary>
        /// Parses a tracklet pair string.
        /// </summary>
        /// <param name="source"> The source string in the format <c>AV(...)-AV(...)</c>. </param>
        /// <returns> A new <see cref="TrackletSource"/>. </returns>
        /// <exception cref="System.ArgumentNullException"> <paramref name="source"/> is null. </exception>
        /// <exception cref="System.FormatException"> The source string is not a valid tracklet pair. </exception>
        public static new TrackletSource Parse(string source)
        {
            Argument.AssertNotNullOrEmpty(source, nameof(source));
            return new TrackletSource(source);
        }
    }
}
