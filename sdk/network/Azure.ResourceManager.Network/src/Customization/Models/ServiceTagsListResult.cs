// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    // These aliases restore the released string Id and Type APIs over the canonical inherited ResourceData metadata.
    // The Type attributes direct callers to the canonical ResourceType property; inherited metadata owns serialization.
    public partial class ServiceTagsListResult
    {
        /// <summary> The ID of the cloud. </summary>
        public new string Id => base.Id?.ToString();

        /// <summary> The resource type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete. Please use ResourceType instead.")]
        public string Type => base.ResourceType.ToString();
    }
}
