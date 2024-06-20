// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Search
{
    /// <summary> The GeographicEntityType. </summary>
    [CodeGenModel("GeographicEntityType")]
    public readonly partial struct GeographicEntity
    {
        /// <summary> Neighborhood. </summary>
        // cSpell:ignore Neighbourhood
        [CodeGenMember("Neighbourhood")]
        internal static GeographicEntity Neighbourhood { get; } = new GeographicEntity(NeighborhoodValue);

        /// <summary> Neighborhood. </summary>
        public static GeographicEntity Neighborhood { get; } = new GeographicEntity(NeighborhoodValue);

        /// <summary> NeighborhoodValue. </summary>
        private const string NeighborhoodValue = "Neighbourhood";
    }
}
