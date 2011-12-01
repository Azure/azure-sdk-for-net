//-----------------------------------------------------------------------
// <copyright file="ConditionHeaderKind.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the ConditionHeaderKind enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Specifies the kinds of conditional headers that may be set for a request.
    /// </summary>
    public enum ConditionHeaderKind
    {
        /// <summary>
        /// Indicates that no conditional headers are set.
        /// </summary>
        None,

        /// <summary>
        /// The If-Unmodified-Since header.
        /// </summary>
        IfUnmodifiedSince,

        /// <summary>
        /// The If-Match header.
        /// </summary>
        IfMatch,

        /// <summary>
        /// The If-Modified-Since header.
        /// </summary>
        IfModifiedSince,

        /// <summary>
        /// The If-None-Match header.
        /// </summary>
        IfNoneMatch
    }
}
