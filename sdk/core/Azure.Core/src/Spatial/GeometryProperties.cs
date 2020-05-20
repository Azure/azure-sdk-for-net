// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public class GeometryProperties
    {
        private static readonly IReadOnlyDictionary<string, object?> EmptyReadonlyDictionary = new ReadOnlyDictionary<string, object?>(new Dictionary<string, object?>());

        /// <summary>
        ///
        /// </summary>
        /// <param name="boundingBox"></param>
        /// <param name="additionalProperties"></param>
        public GeometryProperties(GeometryBoundingBox? boundingBox = null, IReadOnlyDictionary<string, object?>? additionalProperties = null)
        {
            BoundingBox = boundingBox;
            AdditionalProperties = additionalProperties ?? EmptyReadonlyDictionary;
        }

        /// <summary>
        ///
        /// </summary>
        public GeometryBoundingBox? BoundingBox { get; }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyDictionary<string, object?> AdditionalProperties { get; }
    }
}