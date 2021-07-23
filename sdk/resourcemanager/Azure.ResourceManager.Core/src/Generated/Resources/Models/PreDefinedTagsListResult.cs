// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary> List of subscription tags. </summary>
    internal partial class PreDefinedTagsListResult
    {
        /// <summary> Initializes a new instance of TagsListResult. </summary>
        internal PreDefinedTagsListResult()
        {
            Value = new ChangeTrackingList<PreDefinedTagData>();
        }

        /// <summary> Initializes a new instance of TagsListResult. </summary>
        /// <param name="value"> An array of tags. </param>
        /// <param name="nextLink"> The URL to use for getting the next set of results. </param>
        internal PreDefinedTagsListResult(IReadOnlyList<PreDefinedTagData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> An array of tags. </summary>
        public IReadOnlyList<PreDefinedTagData> Value { get; }
        /// <summary> The URL to use for getting the next set of results. </summary>
        public string NextLink { get; }
    }
}
