// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning
{
    /// <summary>
    /// The type of the Bicep parameter or output.
    /// </summary>
    public enum BicepType
    {
        /// <summary>
        /// A string.
        /// </summary>
        String,

        /// <summary>
        /// An integer.
        /// </summary>
        Int,

        /// <summary>
        /// A boolean.
        /// </summary>
        Bool,

        /// <summary>
        /// An object.
        /// </summary>
        Object,

        /// <summary>
        /// An array.
        /// </summary>
        Array
    }
}
