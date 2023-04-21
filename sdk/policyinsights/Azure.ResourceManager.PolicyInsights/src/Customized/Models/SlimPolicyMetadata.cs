// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.PolicyInsights.Models
{
    /// <summary> Slim version of policy metadata resource definition, excluding properties with large strings. </summary>
    public partial class SlimPolicyMetadata : ResourceData
    {
        /// <summary> Url for getting additional content about the resource metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property has been replaced by AdditionalContentUriString", false)]
        public Uri AdditionalContentUri { get; set; }
    }
}
