// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The direction of the boundaries specified by a <see cref="MetricBoundaryCondition"/>.
    /// </summary>
    [CodeGenModel("Direction")]
    public readonly partial struct BoundaryDirection
    {
        /// <summary>
        /// Used when both lower and upper bounds are applied.
        /// </summary>
        public static BoundaryDirection Both { get; } = new BoundaryDirection(BothValue);

        /// <summary>
        /// Used when only a lower bound is applied.
        /// </summary>
        public static BoundaryDirection Down { get; } = new BoundaryDirection(DownValue);

        /// <summary>
        /// Used when only an upper bound is applied.
        /// </summary>
        public static BoundaryDirection Up { get; } = new BoundaryDirection(UpValue);
    }
}
