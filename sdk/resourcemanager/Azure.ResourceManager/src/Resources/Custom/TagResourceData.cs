// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class representing the TagResource data model. </summary>
    public partial class TagResourceData
    {
        /// <summary> Dictionary of &lt;string&gt;. </summary>
        public IDictionary<string, string> TagValues
        {
            get => Properties.TagsValue;
        }
    }
}
