// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage
{
    /// <summary>
    /// Specifies the format the service should use to return list results.
    /// </summary>
    public enum StorageResponseFormat
    {
        /// <summary>
        /// Default. Currently maps to <see cref="Xml"/>, but may be updated in future releases.
        /// </summary>
        Auto = 0,

        /// <summary>
        /// Use XML to return list results.
        /// </summary>
        Xml = 1,

        /// <summary>
        /// Use Apache Arrow to return list results.
        /// </summary>
        Arrow = 2,
    }
}
