// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core
{
    /// <summary>
    /// Metrics options.
    /// </summary>
    public class MetricsOptions
    {
        /// <summary>
        /// Get or set enable metrics flag.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Creates new MeticsOptions instance.
        /// </summary>
        protected MetricsOptions()
        {
        }

        internal MetricsOptions(bool isEnabled)
        {
            IsEnabled = isEnabled;
        }
    }
}
