// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure
{
    /// <summary>
    /// Provides the client options for serializing models.
    /// </summary>
    public class SerializableOptions
    {
        /// <summary>
        /// TODO
        /// </summary>
        public bool IgnoreReadOnlyProperties { get; set; } = false;

        /// <summary>
        /// TODO
        /// </summary>
        public bool IgnoreAdditionalProperties { get; set; } = false;

        /// <summary>
        /// TODO
        /// </summary>
        public bool PrettyPrint { get; set; } = false;
    }
}
