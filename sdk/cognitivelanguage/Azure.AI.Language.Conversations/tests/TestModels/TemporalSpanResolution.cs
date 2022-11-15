// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> represents the resolution of a date and/or time span. </summary>
    public partial class TemporalSpanResolution : BaseResolution
    {
        /// <summary> Initializes a new instance of TemporalSpanResolution. </summary>
        internal TemporalSpanResolution()
        {
            ResolutionKind = ResolutionKind.TemporalSpanResolution;
        }

        /// <summary> Initializes a new instance of TemporalSpanResolution. </summary>
        /// <param name="resolutionKind"> The entity resolution object kind. </param>
        /// <param name="begin"> An extended ISO 8601 date/time representation as described in (https://github.com/Microsoft/Recognizers-Text/blob/master/Patterns/English/English-DateTime.yaml). </param>
        /// <param name="end"> An extended ISO 8601 date/time representation as described in (https://github.com/Microsoft/Recognizers-Text/blob/master/Patterns/English/English-DateTime.yaml). </param>
        /// <param name="duration"> An optional duration value formatted based on the ISO 8601 (https://en.wikipedia.org/wiki/ISO_8601#Durations). </param>
        /// <param name="modifier"> An optional modifier of a date/time instance. </param>
        internal TemporalSpanResolution(ResolutionKind resolutionKind, string begin, string end, string duration, TemporalModifier? modifier) : base(resolutionKind)
        {
            Begin = begin;
            End = end;
            Duration = duration;
            Modifier = modifier;
            ResolutionKind = resolutionKind;
        }

        /// <summary> An extended ISO 8601 date/time representation as described in (https://github.com/Microsoft/Recognizers-Text/blob/master/Patterns/English/English-DateTime.yaml). </summary>
        public string Begin { get; }
        /// <summary> An extended ISO 8601 date/time representation as described in (https://github.com/Microsoft/Recognizers-Text/blob/master/Patterns/English/English-DateTime.yaml). </summary>
        public string End { get; }
        /// <summary> An optional duration value formatted based on the ISO 8601 (https://en.wikipedia.org/wiki/ISO_8601#Durations). </summary>
        public string Duration { get; }
        /// <summary> An optional modifier of a date/time instance. </summary>
        public TemporalModifier? Modifier { get; }
    }
}
