// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure
{
    /// <summary>
    /// ResponseStatusOption controls the behavior of an operation based on the status code of a response.
    /// </summary>
    public enum ResponseStatusOption
    {
        /// <summary>
        /// Indicates that an operation should throw an exception when the response indicates a failure.
        /// </summary>
        ThrowOnError = 0,
        /// <summary>
        /// Indicates that an operation should not throw an exception when the response indicates a failure.
        /// </summary>
        SuppressExceptions = 1,
    }
}
