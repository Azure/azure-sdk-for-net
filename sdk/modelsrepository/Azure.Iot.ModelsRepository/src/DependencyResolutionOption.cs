// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.ModelsRepository
{
    /// <summary>
    /// The model dependency resolution options.
    /// </summary>
    public enum DependencyResolutionOption
    {
        /// <summary>
        /// Try to get pre-computed model dependencies using .expanded.json.
        /// If the model expanded form does not exist fall back to normal dependency processing.
        /// </summary>
        TryFromExpanded,

        /// <summary>
        /// Disable model dependency resolution.
        /// </summary>
        Disabled,

        /// <summary>
        /// Enable model dependency resolution.
        /// </summary>
        Enabled,
    }
}
