// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> A dictionary of name and value pairs. </summary>
    public partial class Tag : Resource
    {
        /// <summary> Initializes a new instance of TagsData. </summary>
        public Tag()
        {
            TagsValue = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of Tags. </summary>
        /// <param name="tagsValue"> Dictionary of &lt;string&gt;. </param>
        internal Tag(IDictionary<string, string> tagsValue)
        {
            TagsValue = tagsValue;
        }

        /// <summary> Dictionary of &lt;string&gt;. </summary>
        public IDictionary<string, string> TagsValue { get; }
    }
}
