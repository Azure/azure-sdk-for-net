// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Maps.Routing.Models
{
    /// <summary> Type of the incident. Can currently be <see cref="TrafficIncidentCategory.Jam"/>, <see cref="TrafficIncidentCategory.RoadWork"/>, <see cref="TrafficIncidentCategory.RoadClosure"/>, or <see cref="TrafficIncidentCategory.Other"/>. Please refer to <see href="https://cdn.standards.iteh.ai/samples/79852/da4e7b5a4f8849aa95b4dd0386fc63b2/ISO-DIS-21219-15.pdf">TPEG2-TEC standard</see> for more information </summary>
    [CodeGenModel("SimpleCategory")]
    public readonly partial struct TrafficIncidentCategory : IEquatable<TrafficIncidentCategory>
    {
    }
}
