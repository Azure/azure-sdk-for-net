// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Provides options to be used with <see cref="DynamicData"/>.
    /// </summary>
    public class DynamicDataOptions
    {
        private static readonly DynamicDataOptions _default = new()
        {
            DateTimeHandling = DynamicDateTimeHandling.Rfc3339
        };
        internal static DynamicDataOptions Default { get => _default; }

        /// <summary>
        /// Gets or sets an object that specifies how dynamic property names will be mapped to member names in the data buffer.
        /// </summary>
        public DynamicCaseMapping CaseMapping { get; set; }

        /// <summary>
        /// Gets or sets an object that specifies how DateTime and DateTimeOffset should be handled when serializing and deserializing.
        /// </summary>
        public DynamicDateTimeHandling DateTimeHandling { get; set; }
    }
}
