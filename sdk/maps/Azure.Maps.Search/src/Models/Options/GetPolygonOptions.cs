// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Maps.Search.Models.Options
{
    /// <summary> Options. </summary>
    public class GetPolygonOptions : BaseOptions
    {
        /// <summary> The geopolitical concept to return a boundary for. </summary>
        public BoundaryResultTypeEnum? ResultType { get; set; }

        /// <summary> Resolution determines the amount of points to send back. </summary>
        public ResolutionEnum? Resolution { get; set; }
    }
}
