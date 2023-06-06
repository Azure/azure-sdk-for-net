// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Provides the client options for serializing models.
    /// </summary>
    internal class SerializableOptions
    {
        /// <summary>
        /// Bool that determines if ReadOnlyProperties will be serialized. Default is false.
        /// </summary>
        public bool IgnoreReadOnlyProperties { get; set; }

        /// <summary>
        /// Bool that determines if AdditionalProperties will be serialized. Default is false.
        /// </summary>
        public bool IgnoreAdditionalProperties { get; set; }

        /// <summary>
        /// Bool that determines if Json will be PrettyPrinted. Default is false.
        /// </summary>
        public bool PrettyPrint { get; set; }

        /// <summary>
        /// todo
        /// </summary>
        public ObjectSerializer? Serializer { get; set; }
    }
}
