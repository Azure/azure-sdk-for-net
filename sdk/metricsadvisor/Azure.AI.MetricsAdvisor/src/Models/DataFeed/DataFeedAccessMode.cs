// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    // TODODOCS.
    /// <summary>
    /// </summary>
    [CodeGenModel("ViewMode")]
    public readonly partial struct DataFeedAccessMode
    {
        /// <summary>
        /// </summary>
        public static DataFeedAccessMode Private { get; } = new DataFeedAccessMode(PrivateValue);

        /// <summary>
        /// </summary>
        public static DataFeedAccessMode Public { get; } = new DataFeedAccessMode(PublicValue);
    }
}
