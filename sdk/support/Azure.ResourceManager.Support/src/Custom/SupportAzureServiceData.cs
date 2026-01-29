// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Support
{
    // Add missing IReadOnlyList<string> attributes
    public partial class SupportAzureServiceData
    {
        /// <summary> ARM Resource types. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<string> ResourceTypes => (IReadOnlyList<string>)ArmResourceTypes;
    }
}
