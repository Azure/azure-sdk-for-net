// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> Wrapper resource for tags patch API request only. </summary>
    public partial class TagPatchResource
    {
        /// <summary> Initializes a new instance of TagsPatchResource. </summary>
        public TagPatchResource()
        {
        }

        /// <summary> The operation type for the patch API. </summary>
        public TagPatchResourceOperation? Operation { get; set; }
        /// <summary> The set of tags. </summary>
        public Tag Properties { get; set; }
    }
}
