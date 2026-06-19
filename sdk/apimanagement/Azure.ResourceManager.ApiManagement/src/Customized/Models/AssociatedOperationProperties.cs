// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ApiManagement.Models
{
    public partial class AssociatedOperationProperties
    {
        // Old SDK name was UriTemplate; generated name is UrlTemplate.
        // Not spec-fixable: @@clientName on non-flattened direct properties breaks
        // the generated constructor and serialization code.

        /// <summary> Relative URL template identifying the target resource for this operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("urlTemplate")]
        public string UriTemplate => UrlTemplate;
    }
}
