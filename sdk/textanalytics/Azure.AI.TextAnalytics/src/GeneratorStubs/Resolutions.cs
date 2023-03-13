// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
#pragma warning disable SA1402 // File may only contain a single type

    #region Primitives

    [CodeGenModel("AgeUnit")]
    public readonly partial struct AgeUnit { }

    [CodeGenModel("AreaUnit")]
    public readonly partial struct AreaUnit { }

    [CodeGenModel("DateTimeSubKind")]
    public readonly partial struct DateTimeSubKind { }

    [CodeGenModel("InformationUnit")]
    public readonly partial struct InformationUnit { }

    [CodeGenModel("LengthUnit")]
    public readonly partial struct LengthUnit { }

    [CodeGenModel("NumberKind")]
    public readonly partial struct NumberKind { }

    [CodeGenModel("RangeKind")]
    public readonly partial struct RangeKind { }

    [CodeGenModel("RelativeTo")]
    public readonly partial struct RelativeTo { }

    [CodeGenModel("SpeedUnit")]
    public readonly partial struct SpeedUnit { }

    [CodeGenModel("TemperatureUnit")]
    public readonly partial struct TemperatureUnit { }

    [CodeGenModel("TemporalModifier")]
    public readonly partial struct TemporalModifier { }

    [CodeGenModel("VolumeUnit")]
    public readonly partial struct VolumeUnit { }

    [CodeGenModel("WeightUnit")]
    public readonly partial struct WeightUnit { }

    #endregion

    #region Resolutions

    [CodeGenModel("AgeResolution")]
    public partial class AgeResolution
    {
        internal AgeResolution(AgeUnit unit, double value)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.AgeResolution;
        }

        internal AgeResolution(ResolutionKind resolutionKind, AgeUnit unit, double value) : base(resolutionKind)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary>
        /// The Age Unit of measurement.
        /// </summary>
        [CodeGenMember("Unit")]
        public AgeUnit Unit { get; }

        /// <summary>
        /// The numeric value that the extracted text denotes.
        /// </summary>
        [CodeGenMember("Value")]
        public double Value { get; }
    }

    [CodeGenModel("AreaResolution")]
    public partial class AreaResolution
    {
        internal AreaResolution(AreaUnit unit, double value)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.AreaResolution;
        }

        internal AreaResolution(ResolutionKind resolutionKind, AreaUnit unit, double value) : base(resolutionKind)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary>
        /// The area Unit of measurement.
        /// </summary>
        [CodeGenMember("Unit")]
        public AreaUnit Unit { get; }

        /// <summary>
        /// The numeric value that the extracted text denotes.
        /// </summary>
        [CodeGenMember("Value")]
        public double Value { get; }
    }

    [CodeGenModel("BaseResolution")]
    public abstract partial class BaseResolution
    {
        internal BaseResolution()
        {
        }

        internal BaseResolution(ResolutionKind resolutionKind)
        {
            ResolutionKind = resolutionKind;
        }

        [CodeGenMember("ResolutionKind")]
        internal ResolutionKind ResolutionKind { get; set; }
    }

    [CodeGenModel("CurrencyResolution")]
    public partial class CurrencyResolution
    {
        internal CurrencyResolution(string unit, double value)
        {
            Argument.AssertNotNull(unit, nameof(unit));

            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.CurrencyResolution;
        }

        internal CurrencyResolution(ResolutionKind resolutionKind, string iso4217, string unit, double value) : base(resolutionKind)
        {
            Iso4217 = iso4217;
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary>
        /// The alphabetic code based on another ISO standard, ISO 3166, which lists the codes for country names.
        /// The first two letters of the ISO 4217 three-letter code are the same as the code for the country name,
        /// and, where possible, the third letter corresponds to the first letter of the currency name.
        /// </summary>
        [CodeGenMember("Iso4217")]
        public string Iso4217 { get; }

        /// <summary>
        /// The unit of the amount captured in the extracted entity.
        /// </summary>
        [CodeGenMember("Unit")]
        public string Unit { get; }

        /// <summary>
        /// The numeric value that the extracted text denotes.
        /// </summary>
        [CodeGenMember("Value")]
        public double Value { get; }
    }

    [CodeGenModel("DateTimeResolution")]
    public partial class DateTimeResolution
    {
        internal DateTimeResolution(string timex, DateTimeSubKind dateTimeSubKind, string value)
        {
            Argument.AssertNotNull(timex, nameof(timex));
            Argument.AssertNotNull(value, nameof(value));

            Timex = timex;
            DateTimeSubKind = dateTimeSubKind;
            Value = value;
            ResolutionKind = ResolutionKind.DateTimeResolution;
        }

        internal DateTimeResolution(ResolutionKind resolutionKind, string timex, DateTimeSubKind dateTimeSubKind, string value, TemporalModifier? modifier) : base(resolutionKind)
        {
            Timex = timex;
            DateTimeSubKind = dateTimeSubKind;
            Value = value;
            Modifier = modifier;
            ResolutionKind = resolutionKind;
        }

        /// <summary>
        /// An extended ISO 8601 date/time representation as described in (https://github.com/Microsoft/Recognizers-Text/blob/master/Patterns/English/English-DateTime.yaml).
        /// </summary>
        [CodeGenMember("Timex")]
        public string Timex { get; }

        /// <summary>
        /// The DateTime SubKind.
        /// </summary>
        [CodeGenMember("DateTimeSubKind")]
        public DateTimeSubKind DateTimeSubKind { get; }

        /// <summary>
        /// The actual time that the extracted text denote.
        /// </summary>
        [CodeGenMember("Value")]
        public string Value { get; }

        /// <summary>
        /// An optional modifier of a date/time instance.
        /// </summary>
        [CodeGenMember("Modifier")]
        public TemporalModifier? Modifier { get; }
    }

    [CodeGenModel("InformationResolution")]
    public partial class InformationResolution
    {
        internal InformationResolution(InformationUnit unit, double value)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.InformationResolution;
        }

        internal InformationResolution(ResolutionKind resolutionKind, InformationUnit unit, double value) : base(resolutionKind)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary>
        /// The information (data) Unit of measurement.
        /// </summary>
        [CodeGenMember("Unit")]
        public InformationUnit Unit { get; }

        /// <summary>
        /// The numeric value that the extracted text denotes.
        /// </summary>
        [CodeGenMember("Value")]
        public double Value { get; }
    }

    [CodeGenModel("LengthResolution")]
    public partial class LengthResolution
    {
        internal LengthResolution(LengthUnit unit, double value)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.LengthResolution;
        }

        internal LengthResolution(ResolutionKind resolutionKind, LengthUnit unit, double value) : base(resolutionKind)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary>
        /// The length Unit of measurement.
        /// </summary>
        [CodeGenMember("Unit")]
        public LengthUnit Unit { get; }

        /// <summary>
        /// The numeric value that the extracted text denotes.
        /// </summary>
        [CodeGenMember("Value")]
        public double Value { get; }
    }

    [CodeGenModel("NumberResolution")]
    public partial class NumberResolution
    {
        internal NumberResolution(NumberKind numberKind, double value)
        {
            Argument.AssertNotNull(value, nameof(value));

            NumberKind = numberKind;
            Value = value;
            ResolutionKind = ResolutionKind.NumberResolution;
        }

        internal NumberResolution(ResolutionKind resolutionKind, NumberKind numberKind, double value) : base(resolutionKind)
        {
            NumberKind = numberKind;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary>
        /// The type of the extracted number entity.
        /// </summary>
        [CodeGenMember("NumberKind")]
        public NumberKind NumberKind { get; }

        /// <summary>
        /// A numeric representation of what the extracted text denotes.
        /// </summary>
        [CodeGenMember("Value")]
        public double Value { get; }
    }

    [CodeGenModel("NumericRangeResolution")]
    public partial class NumericRangeResolution
    {
        internal NumericRangeResolution(RangeKind rangeKind, double minimum, double maximum)
        {
            RangeKind = rangeKind;
            Minimum = minimum;
            Maximum = maximum;
            ResolutionKind = ResolutionKind.NumericRangeResolution;
        }

        internal NumericRangeResolution(ResolutionKind resolutionKind, RangeKind rangeKind, double minimum, double maximum) : base(resolutionKind)
        {
            RangeKind = rangeKind;
            Minimum = minimum;
            Maximum = maximum;
            ResolutionKind = resolutionKind;
        }

        /// <summary>
        /// The kind of range that the resolution object represents.
        /// </summary>
        [CodeGenMember("RangeKind")]
        public RangeKind RangeKind { get; }

        /// <summary>
        /// The beginning value of  the interval.
        /// </summary>
        [CodeGenMember("Minimum")]
        public double Minimum { get; }

        /// <summary>
        /// The ending value of the interval.
        /// </summary>
        [CodeGenMember("Maximum")]
        public double Maximum { get; }
    }

    [CodeGenModel("OrdinalResolution")]
    public partial class OrdinalResolution
    {
        internal OrdinalResolution(string offset, RelativeTo relativeTo, string value)
        {
            Argument.AssertNotNull(offset, nameof(offset));
            Argument.AssertNotNull(value, nameof(value));

            Offset = offset;
            RelativeTo = relativeTo;
            Value = value;
            ResolutionKind = ResolutionKind.OrdinalResolution;
        }

        internal OrdinalResolution(ResolutionKind resolutionKind, string offset, RelativeTo relativeTo, string value) : base(resolutionKind)
        {
            Offset = offset;
            RelativeTo = relativeTo;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary>
        /// The offset with respect to the reference (e.g., offset = -1 in "show me the second to last").
        /// </summary>
        [CodeGenMember("Offset")]
        public string Offset { get; }

        /// <summary>
        /// The reference point that the ordinal number denotes.
        /// </summary>
        [CodeGenMember("RelativeTo")]
        public RelativeTo RelativeTo { get; }

        /// <summary>
        /// A simple arithmetic expression that the ordinal denotes.
        /// </summary>
        [CodeGenMember("Value")]
        public string Value { get; }
    }

    [CodeGenModel("SpeedResolution")]
    public partial class SpeedResolution
    {
        internal SpeedResolution(SpeedUnit unit, double value)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.SpeedResolution;
        }

        internal SpeedResolution(ResolutionKind resolutionKind, SpeedUnit unit, double value) : base(resolutionKind)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary>
        /// The speed Unit of measurement.
        /// </summary>
        [CodeGenMember("Unit")]
        public SpeedUnit Unit { get; }

        /// <summary>
        /// The numeric value that the extracted text denotes.
        /// </summary>
        [CodeGenMember("Value")]
        public double Value { get; }
    }

    [CodeGenModel("TemperatureResolution")]
    public partial class TemperatureResolution
    {
        internal TemperatureResolution(TemperatureUnit unit, double value)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.TemperatureResolution;
        }

        internal TemperatureResolution(ResolutionKind resolutionKind, TemperatureUnit unit, double value) : base(resolutionKind)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary>
        /// The temperature Unit of measurement.
        /// </summary>
        [CodeGenMember("Unit")]
        public TemperatureUnit Unit { get; }

        /// <summary>
        /// The numeric value that the extracted text denotes.
        /// </summary>
        [CodeGenMember("Value")]
        public double Value { get; }
    }

    [CodeGenModel("TemporalSpanResolution")]
    public partial class TemporalSpanResolution
    {
        internal TemporalSpanResolution()
        {
            ResolutionKind = ResolutionKind.TemporalSpanResolution;
        }

        internal TemporalSpanResolution(ResolutionKind resolutionKind, string begin, string end, string duration, TemporalModifier? modifier, string timex) : base(resolutionKind)
        {
            Begin = begin;
            End = end;
            Duration = duration;
            Modifier = modifier;
            Timex = timex;
            ResolutionKind = resolutionKind;
        }

        /// <summary>
        /// An extended ISO 8601 date/time representation as described in
        /// (https://github.com/Microsoft/Recognizers-Text/blob/master/Patterns/English/English-DateTime.yaml).
        /// </summary>
        [CodeGenMember("Begin")]
        public string Begin { get; }

        /// <summary>
        /// An extended ISO 8601 date/time representation as described in
        /// (https://github.com/Microsoft/Recognizers-Text/blob/master/Patterns/English/English-DateTime.yaml).
        /// </summary>
        [CodeGenMember("End")]
        public string End { get; }

        /// <summary>
        /// An optional duration value formatted based on the ISO 8601
        /// (https://en.wikipedia.org/wiki/ISO_8601#Durations).
        /// </summary>
        [CodeGenMember("Duration")]
        public string Duration { get; }

        /// <summary>
        /// An optional modifier of a date/time instance.
        /// </summary>
        [CodeGenMember("Modifier")]
        public TemporalModifier? Modifier { get; }

        /// <summary>
        /// An optional triplet containing the beginning, the end, and the duration all stated as ISO 8601 formatted strings.
        /// </summary>
        [CodeGenMember("Timex")]
        public string Timex { get; }
    }

    [CodeGenModel("VolumeResolution")]
    public partial class VolumeResolution
    {
        internal VolumeResolution(VolumeUnit unit, double value)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.VolumeResolution;
        }

        internal VolumeResolution(ResolutionKind resolutionKind, VolumeUnit unit, double value) : base(resolutionKind)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary>
        /// The Volume Unit of measurement.
        /// </summary>
        [CodeGenMember("Unit")]
        public VolumeUnit Unit { get; }

        /// <summary>
        /// The numeric value that the extracted text denotes.
        /// </summary>
        [CodeGenMember("Value")]
        public double Value { get; }
    }

    [CodeGenModel("WeightResolution")]
    public partial class WeightResolution
    {
        internal WeightResolution(WeightUnit unit, double value)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.WeightResolution;
        }

        internal WeightResolution(ResolutionKind resolutionKind, WeightUnit unit, double value) : base(resolutionKind)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary>
        /// The weight Unit of measurement.
        /// </summary>
        [CodeGenMember("Unit")]
        public WeightUnit Unit { get; }

        /// <summary>
        /// The numeric value that the extracted text denotes.
        /// </summary>
        [CodeGenMember("Value")]
        public double Value { get; }
    }

    #endregion

#pragma warning restore SA1402 // File may only contain a single type
}
