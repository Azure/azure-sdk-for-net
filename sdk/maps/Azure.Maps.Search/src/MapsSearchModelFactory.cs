// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core.GeoJson;

namespace Azure.Maps.Search.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class MapsSearchModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="SearchBoundary"/> for mocking. </summary>
        /// <param name="geometry"> A valid <c>GeoJSON</c> geometry collection object. </param>
        /// <param name="properties"> Properties can contain any additional metadata about the <c>Feature</c>. </param>
        /// <returns> A new <see cref="SearchBoundary"/> instance for mocking. </returns>
        public static SearchBoundary SearchBoundary(GeoCollection geometry = null, BoundaryProperties properties = null)
        {
            return new SearchBoundary(geometry, properties);
        }
    }
}
