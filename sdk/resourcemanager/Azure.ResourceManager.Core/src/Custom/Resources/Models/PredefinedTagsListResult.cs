// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> List of subscription tags. </summary>
    internal partial class PredefinedTagsListResult
    {
        /// <summary> Initializes a new instance of TagsListResult. </summary>
        internal PredefinedTagsListResult()
        {
            Value = new ChangeTrackingList<PredefinedTagData>();
        }

        /// <summary> Initializes a new instance of TagsListResult. </summary>
        /// <param name="value"> An array of tags. </param>
        /// <param name="nextLink"> The URL to use for getting the next set of results. </param>
        internal PredefinedTagsListResult(IReadOnlyList<PredefinedTagData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> An array of tags. </summary>
        public IReadOnlyList<PredefinedTagData> Value { get; }
        /// <summary> The URL to use for getting the next set of results. </summary>
        public string NextLink { get; }
    }
}
