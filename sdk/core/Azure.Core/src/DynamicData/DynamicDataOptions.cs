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
        /// Gets or sets a value that specifies how to convert property names on the dynamic object to another format, such as camel case.  This conversion is applied when new values are set on the dynamic object, and when changes to the dynamic object are serialized.
        /// </summary>
        public PropertyNameConversion PropertyNameConversion { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies how to bind property names on the dynamic object to property names in the dynamic content.
        /// </summary>
        public DynamicNameBinding DynamicNameBinding { get; set; }

        /// <summary>
        /// Gets or sets an object that specifies how DateTime and DateTimeOffset should be handled when serializing and deserializing.
        /// </summary>
        public DateTimeHandling DateTimeHandling { get; set; }
    }
}
