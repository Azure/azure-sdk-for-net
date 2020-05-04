// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents
{
    /// <summary>
    /// Options to customize Search service operations conditioned on <see cref="IfMatch"/> or <see cref="IfNoneMatch"/> ETags.
    /// </summary>
    public class SearchConditionalOptions : SearchRequestOptions
    {
        /// <summary>
        /// Optionally limit requests to resources that have a matching ETag.
        /// </summary>
        public ETag? IfMatch { get; set; }

        /// <summary>
        /// Optionally limit requests to resources that do not match the ETag.
        /// </summary>
        public ETag? IfNoneMatch { get; set; }
    }
}
