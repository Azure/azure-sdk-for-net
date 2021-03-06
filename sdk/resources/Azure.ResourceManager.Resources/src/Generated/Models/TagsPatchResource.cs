// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> Wrapper resource for tags patch API request only. </summary>
    public partial class TagsPatchResource
    {
        /// <summary> Initializes a new instance of TagsPatchResource. </summary>
        public TagsPatchResource()
        {
        }

        /// <summary> The operation type for the patch API. </summary>
        public TagsPatchResourceOperation? Operation { get; set; }
        /// <summary> The set of tags. </summary>
        public Tags Properties { get; set; }
    }
}
