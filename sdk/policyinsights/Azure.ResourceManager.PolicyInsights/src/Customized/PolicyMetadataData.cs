// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.PolicyInsights
{
    /// <summary>
    /// A class representing the PolicyMetadata data model.
    /// Policy metadata resource definition.
    /// </summary>
    public partial class PolicyMetadataData : ResourceData
    {
        /// <summary> Url for getting additional content about the resource metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property has been replaced by AdditionalContentUriString", false)]
        public Uri AdditionalContentUri { get; set; }
    }
}
