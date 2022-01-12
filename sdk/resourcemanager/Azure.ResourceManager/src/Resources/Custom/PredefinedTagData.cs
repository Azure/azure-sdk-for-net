// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary> Tag details. </summary>
    public partial class PredefinedTagData : SubResource
    {
        /// <summary> Initializes a new instance of TagDetails. </summary>
        internal PredefinedTagData()
        {
            Values = new ChangeTrackingList<PredefinedTagValue>();
        }

        /// <summary> Initializes a new instance of TagDetails. </summary>
        /// <param name="id"> The tag name ID. </param>
        /// <param name="tagName"> The tag name. </param>
        /// <param name="count"> The total number of resources that use the resource tag. When a tag is initially created and has no associated resources, the value is 0. </param>
        /// <param name="values"> The list of tag values. </param>
        internal PredefinedTagData(ResourceIdentifier id, string tagName, PredefinedTagCount count, IReadOnlyList<PredefinedTagValue> values) : base(id)
        {
            TagName = tagName;
            Count = count;
            Values = values;
        }

        /// <summary> The tag name. </summary>
        public string TagName { get; }
        /// <summary> The total number of resources that use the resource tag. When a tag is initially created and has no associated resources, the value is 0. </summary>
        public PredefinedTagCount Count { get; }
        /// <summary> The list of tag values. </summary>
        public IReadOnlyList<PredefinedTagValue> Values { get; }
    }
}
