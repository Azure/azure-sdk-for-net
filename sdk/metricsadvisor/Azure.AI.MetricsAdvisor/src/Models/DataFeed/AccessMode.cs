// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    // TODODOCS.
    /// <summary>
    /// </summary>
    [CodeGenModel("ViewMode")]
    public readonly partial struct AccessMode
    {
        /// <summary>
        /// </summary>
        public static AccessMode Private { get; } = new AccessMode(PrivateValue);

        /// <summary>
        /// </summary>
        public static AccessMode Public { get; } = new AccessMode(PublicValue);
    }
}
