// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Serialization;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Provides options to be used with <see cref="DynamicData"/>.
    /// </summary>
    public class DynamicDataOptions
    {
        private static readonly DynamicDataOptions _default = new()
        {
            DateTimeHandling = DateTimeHandling.Rfc3339
        };
        internal static DynamicDataOptions Default { get => _default; }

        /// <summary>
        /// </summary>
        public PropertyNameConversion PropertyNameConversion { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies how to bind property names on the dynamic object to property names in the dynamic content.
        /// </summary>
        internal PropertyNameLookup ExistingPropertyLookup { get; set; }

        /// <summary>
        /// Gets or sets an object that specifies how DateTime and DateTimeOffset should be handled when serializing and deserializing.
        /// </summary>
        internal DateTimeHandling DateTimeHandling { get; set; }
    }
}
