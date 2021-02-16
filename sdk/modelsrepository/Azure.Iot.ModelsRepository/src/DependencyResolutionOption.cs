// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.ModelsRepository
{
    /// <summary>
    /// The dependency processing options.
    /// </summary>
    public enum DependencyResolutionOption
    {
        /// <summary>
        /// Do not process external dependencies.
        /// </summary>
        Disabled,

        /// <summary>
        /// Enable external dependencies.
        /// </summary>
        Enabled,

        /// <summary>
        /// Try to get external dependencies using .expanded.json.
        /// </summary>
        TryFromExpanded
    }
}
