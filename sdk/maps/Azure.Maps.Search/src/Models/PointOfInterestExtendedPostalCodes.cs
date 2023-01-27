// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Maps.Search
{
    /// <summary> The PointOfInterestExtendedPostalCodes. </summary>
    [CodeGenModel("PointOfInterestExtendedPostalCodes")]
    public readonly partial struct PointOfInterestExtendedPostalCodes : IEquatable<PointOfInterestExtendedPostalCodes>
    {
        private const string POIValue = "PointOfInterest";

        /// <summary> POI. </summary>
        [CodeGenMember("POI")]
        public static PointOfInterestExtendedPostalCodes PointOfInterest  { get; } = new PointOfInterestExtendedPostalCodes(POIValue);
    }
}
