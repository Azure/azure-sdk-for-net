// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// The service-defined fields of a digital twin relationship.
    /// </summary>
    public interface IDigitalTwinRelationship
    {
        /// <summary>
        /// The unique Id of the relationship, serialized as '$relationshipId'.
        /// </summary>
        /// <remarks>
        /// This field is present on every relationship.
        /// </remarks>
        public string Id { get; set; }

        /// <summary>
        /// The unique Id of the target digital twin, serialized as '$targetId'.
        /// </summary>
        /// <remarks>
        /// This field is present on every relationship.
        /// </remarks>
        public string TargetId { get; set; }

        /// <summary>
        /// The unique Id of the source digital twin, serialized as '$sourceId'.
        /// </summary>
        /// <remarks>
        /// This field is present on every relationship.
        /// </remarks>
        public string SourceId { get; set; }

        /// <summary>
        /// The name of the relationship, which defines the type of link (e.g. Contains), serialized as '$relationshipName'.
        /// </summary>
        /// <remarks>
        /// This field is present on every relationship.
        /// </remarks>
        public string Name { get; set; }
    }
}
