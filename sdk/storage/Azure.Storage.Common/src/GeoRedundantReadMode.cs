// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage
{
    /// <summary>
    /// Pattern for retrying a read request between geo-redundant primary and secondary endpoints.
    /// </summary>
    public enum GeoRedundantReadMode
    {
        /// <summary>
        /// Altnernate between primary and secondary endpoints, attempting primary first.
        /// </summary>
        PrimaryThenSecondary = 0,

        /// <summary>
        /// Altnernate between primary and secondary endpoints, attempting secondary first.
        /// </summary>
        SecondaryThenPrimary = 1
    }
}