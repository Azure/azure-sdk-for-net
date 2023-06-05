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
            DateTimeHandling = DynamicDateTimeHandling.Rfc3339
        };
        internal static DynamicDataOptions Default { get => _default; }

        /// <summary>
        /// A value that specifies how to convert the names of properties that are newly added to the dynamic object.
        /// New properties can be added in two ways.  The first is by setting a property on the dynamic object that wasn't present in the data content prior to
        /// the set operation.  In this case, the conversion specified by this parameter will be applied to the property name used in the set operation when setting
        /// the property in the data content.  The second way is by setting a new or existing property in the data content to an instance of a .NET type that has
        /// properties.  In this case, the conversion specified by this parameter will be applied to all property names in the object graph when serializing the
        /// value to JSON.
        /// </summary>
        public PropertyNameConversion NewPropertyConversion { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies how to bind property names on the dynamic object to property names in the dynamic content.
        /// </summary>
        public PropertyNameLookup ExistingPropertyLookup { get; set; }

        /// <summary>
        /// Gets or sets an object that specifies how DateTime and DateTimeOffset should be handled when serializing and deserializing.
        /// </summary>
        public DynamicDateTimeHandling DateTimeHandling { get; set; }
    }
}
