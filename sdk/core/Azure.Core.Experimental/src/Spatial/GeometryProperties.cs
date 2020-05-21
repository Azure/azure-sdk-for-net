// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents additional information that can be associated with <see cref="Geometry"/>.
    /// </summary>
    public class GeometryProperties
    {
        private static readonly IReadOnlyDictionary<string, object?> EmptyReadonlyDictionary = new ReadOnlyDictionary<string, object?>(new Dictionary<string, object?>());

        /// <summary>
        /// Initializes a new instance of <see cref="GeometryProperties"/> class.
        /// </summary>
        /// <param name="boundingBox">The <see cref="BoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="Geometry"/>.</param>
        public GeometryProperties(GeometryBoundingBox? boundingBox = null, IReadOnlyDictionary<string, object?>? additionalProperties = null)
        {
            BoundingBox = boundingBox;
            AdditionalProperties = additionalProperties ?? EmptyReadonlyDictionary;
        }

        /// <summary>
        /// Represents information about the coordinate range of the <see cref="Geometry"/>.
        /// </summary>
        public GeometryBoundingBox? BoundingBox { get; }

        /// <summary>
        /// Gets a dictionary of additional properties associated with the <see cref="Geometry"/>.
        /// </summary>
        public IReadOnlyDictionary<string, object?> AdditionalProperties { get; }
    }
}