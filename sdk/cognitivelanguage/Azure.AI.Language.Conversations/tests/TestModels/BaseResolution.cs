// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary>
    /// The abstract base class for entity resolutions.
    /// Please note <see cref="BaseResolution"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="AgeResolution"/>, <see cref="AreaResolution"/>, <see cref="BooleanResolution"/>, <see cref="CurrencyResolution"/>, <see cref="DateTimeResolution"/>, <see cref="InformationResolution"/>, <see cref="LengthResolution"/>, <see cref="NumberResolution"/>, <see cref="NumericRangeResolution"/>, <see cref="OrdinalResolution"/>, <see cref="SpeedResolution"/>, <see cref="TemperatureResolution"/>, <see cref="TemporalSpanResolution"/>, <see cref="VolumeResolution"/> and <see cref="WeightResolution"/>.
    /// </summary>
    public partial class BaseResolution
    {
        /// <summary> Initializes a new instance of BaseResolution. </summary>
        internal BaseResolution()
        {
        }

        /// <summary> Initializes a new instance of BaseResolution. </summary>
        /// <param name="resolutionKind"> The entity resolution object kind. </param>
        internal BaseResolution(ResolutionKind resolutionKind)
        {
            ResolutionKind = resolutionKind;
        }

        /// <summary> The entity resolution object kind. </summary>
        internal ResolutionKind ResolutionKind { get; set; }
    }
}
