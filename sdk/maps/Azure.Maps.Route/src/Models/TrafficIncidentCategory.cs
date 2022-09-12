// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Maps.Route.Models
{
    /// <summary> Type of the incident. Can currently be JAM, ROAD_WORK, ROAD_CLOSURE, or OTHER. See &quot;tec&quot; for detailed information. </summary>
    [CodeGenModel("SimpleCategory")]
    public readonly partial struct TrafficIncidentCategory : IEquatable<TrafficIncidentCategory>
    {
    }
}
