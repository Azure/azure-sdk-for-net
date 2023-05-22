﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure
{
    /// <summary>
    /// Provides the client options for serializing models.
    /// </summary>
    public class SerializableOptions
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
    }
}
