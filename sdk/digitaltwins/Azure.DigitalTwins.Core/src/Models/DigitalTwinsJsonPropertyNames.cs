// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// String constants for use in JSON de/serialization for custom types.
    /// </summary>
    public static class DigitalTwinsJsonPropertyNames
    {
        /// <summary>
        /// The JSON property name for the Id field on a digital twin.
        /// </summary>
        public const string DigitalTwinId = "$dtId";

        /// <summary>
        /// The JSON property name for the ETag field on a digital twin.
        /// </summary>
        public const string DigitalTwinETag = "$etag";

        /// <summary>
        /// The JSON property name for the metadata field on a digital twin or a component.
        /// </summary>
        public const string DigitalTwinMetadata = "$metadata";

        /// <summary>
        /// The JSON property name for the model field on a digital twin metadata.
        /// </summary>
        public const string MetadataModel = "$model";

        /// <summary>
        /// The last update time of a digital twin property, used in the $metadata object
        /// on a digital twin or component about their properties.
        /// </summary>
        public const string MetadataLastUpdateTime = "$lastUpdateTime";

        /// <summary>
        /// The last update time of a digital twin property, used in the $metadata object
        /// on a digital twin or component about their properties.
        /// </summary>
        public const string MetadataPropertyLastUpdateTime = "lastUpdateTime";

        /// <summary>
        /// The time the value of a digital twin property was sourced, used in the $metadata
        /// object on a digital twin or component about their properties.
        /// </summary>
        public const string MetadataPropertySourceTime = "sourceTime";

        /// <summary>
        /// The JSON property name for the Id field on a relationship.
        /// </summary>
        public const string RelationshipId = "$relationshipId";

        /// <summary>
        /// The JSON property name for the source Id field on a relationship.
        /// </summary>
        public const string RelationshipSourceId = "$sourceId";

        /// <summary>
        /// The JSON property name for the target Id field on a relationship.
        /// </summary>
        public const string RelationshipTargetId = "$targetId";

        /// <summary>
        /// The JSON property name for the name field on a relationship.
        /// </summary>
        public const string RelationshipName = "$relationshipName";
    }
}
