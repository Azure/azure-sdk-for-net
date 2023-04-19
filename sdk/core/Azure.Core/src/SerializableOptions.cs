// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure
{
    /// <summary>
    /// TODO
    /// </summary>
    public class SerializableOptions
    {
        /// <summary>
        /// TODO
        /// </summary>
        public bool SerializeReadonlyProperties { get; set; } = true;

        /// <summary>
        /// TODO
        /// </summary>
        public bool HandleUnknownElements { get; set; } = true;

        /// <summary>
        /// TODO
        /// </summary>
        public bool PrettyPrint { get; set; } = false;
    }
}
