//-----------------------------------------------------------------------
// <copyright file="ConditionHeaderKind.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
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
