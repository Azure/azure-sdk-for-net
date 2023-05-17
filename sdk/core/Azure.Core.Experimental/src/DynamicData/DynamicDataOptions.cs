// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// </summary>
    public class DynamicDataOptions
    {
        internal static readonly DynamicDataOptions Default = new()
        {
            DateTimeHandling = DynamicDateTimeHandling.Rfc3339Utc
        };

        /// <summary>
        /// </summary>
        public DynamicDateTimeHandling DateTimeHandling { get; set; }
    }
}
