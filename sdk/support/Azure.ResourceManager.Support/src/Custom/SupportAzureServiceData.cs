// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Support
{
    public partial class SupportAzureServiceData : ResourceData
    {
        /// <summary> Localized name of the Azure service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DisplayName => LocalDisplayName;

        /// <summary> ARM Resource types. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<string> ResourceTypes => (IReadOnlyList<string>)LocalResourceTypes;
    }
}
