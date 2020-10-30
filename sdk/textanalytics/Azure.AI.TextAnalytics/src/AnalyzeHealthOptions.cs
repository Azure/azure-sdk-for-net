// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run and what information is returned from it by the service.
    /// </summary>
    public class AnalyzeHealthOptions : TextAnalyticsRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeHealthOptions"/>
        /// class.
        /// </summary>
        public AnalyzeHealthOptions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeHealthOptions"/>
        /// class.
        /// </summary>
        public AnalyzeHealthOptions(int? top = null, int? skip = null, bool? showStats = null)
        {
            Top = top;
            Skip = skip;
            ShowStats = showStats;
        }

        public int? Top { get; internal set; }
        public int? Skip { get; internal set; }
        public bool? ShowStats { get; internal set; }
    }
}
