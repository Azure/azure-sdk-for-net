// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// </summary>
    public class DynamicDataOptions
    {
        /// <summary>
        /// </summary>
        public static DynamicDataOptions Default = new()
        {
            DateTimeHandling = DynamicDateTimeHandling.Rfc3339
        };

        /// <summary>
        /// </summary>
        public DynamicDateTimeHandling DateTimeHandling { get; set; }
    }
}
