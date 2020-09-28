// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// TODODOCS.
    /// </summary>
    [CodeGenModel("ViewMode")]
    public readonly partial struct AccessMode
    {
        /// <summary>
        /// TODODOCS.
        /// </summary>
        public static AccessMode Private { get; } = new AccessMode(PrivateValue);

        /// <summary>
        /// TODODOCS.
        /// </summary>
        public static AccessMode Public { get; } = new AccessMode(PublicValue);
    }
}
