// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> A resolution for datetime entity instances. </summary>
    public partial class DateTimeResolution : BaseResolution
    {
        /// <summary> Initializes a new instance of DateTimeResolution. </summary>
        /// <param name="timex"> An extended ISO 8601 date/time representation as described in (https://github.com/Microsoft/Recognizers-Text/blob/master/Patterns/English/English-DateTime.yaml). </param>
        /// <param name="dateTimeSubKind"> The DateTime SubKind. </param>
        /// <param name="value"> The actual time that the extracted text denote. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="timex"/> or <paramref name="value"/> is null. </exception>
        internal DateTimeResolution(string timex, DateTimeSubKind dateTimeSubKind, string value)
        {
            Argument.AssertNotNull(timex, nameof(timex));
            Argument.AssertNotNull(value, nameof(value));

            Timex = timex;
            DateTimeSubKind = dateTimeSubKind;
            Value = value;
            ResolutionKind = ResolutionKind.DateTimeResolution;
        }

        /// <summary> Initializes a new instance of DateTimeResolution. </summary>
        /// <param name="resolutionKind"> The entity resolution object kind. </param>
        /// <param name="timex"> An extended ISO 8601 date/time representation as described in (https://github.com/Microsoft/Recognizers-Text/blob/master/Patterns/English/English-DateTime.yaml). </param>
        /// <param name="dateTimeSubKind"> The DateTime SubKind. </param>
        /// <param name="value"> The actual time that the extracted text denote. </param>
        /// <param name="modifier"> An optional modifier of a date/time instance. </param>
        internal DateTimeResolution(ResolutionKind resolutionKind, string timex, DateTimeSubKind dateTimeSubKind, string value, TemporalModifier? modifier) : base(resolutionKind)
        {
            Timex = timex;
            DateTimeSubKind = dateTimeSubKind;
            Value = value;
            Modifier = modifier;
            ResolutionKind = resolutionKind;
        }

        /// <summary> An extended ISO 8601 date/time representation as described in (https://github.com/Microsoft/Recognizers-Text/blob/master/Patterns/English/English-DateTime.yaml). </summary>
        public string Timex { get; }
        /// <summary> The DateTime SubKind. </summary>
        public DateTimeSubKind DateTimeSubKind { get; }
        /// <summary> The actual time that the extracted text denote. </summary>
        public string Value { get; }
        /// <summary> An optional modifier of a date/time instance. </summary>
        public TemporalModifier? Modifier { get; }
    }
}
