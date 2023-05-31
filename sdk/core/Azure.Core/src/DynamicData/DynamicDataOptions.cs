// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Serialization;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Provides options to be used with <see cref="DynamicData"/>.
    /// </summary>
    internal class DynamicDataOptions
    {
        private static readonly DynamicDataOptions _default = new()
        {
            DateTimeHandling = DateTimeHandling.Rfc3339
        };
        internal static DynamicDataOptions Default { get => _default; }

        /// <summary>
        /// Gets or sets an object that specifies how dynamic property names will be mapped to member names in the data content.
        /// </summary>
        public PropertyNameHandling PropertyNameHandling { get; set; }

        /// <summary>
        /// Gets or sets an object that specifies how DateTime and DateTimeOffset should be handled when serializing and deserializing.
        /// </summary>
        public DateTimeHandling DateTimeHandling { get; set; }
    }
}
