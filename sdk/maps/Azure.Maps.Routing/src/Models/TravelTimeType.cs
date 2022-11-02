// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Maps.Routing
{
    /// <summary> What travel time we should consider when calculating route directions.
    /// Possible value is <see cref="TravelTimeType.All"/> to include all travel time including walking time when transfer between different transportation
    /// or <see cref="TravelTimeType.None"/> for not to consider additional travel time.
    /// </summary>
    [CodeGenModel("ComputeTravelTime")]
    public readonly partial struct TravelTimeType : IEquatable<TravelTimeType>
    {
    }
}
