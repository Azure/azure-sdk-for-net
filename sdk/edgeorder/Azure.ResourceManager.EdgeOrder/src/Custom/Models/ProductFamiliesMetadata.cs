// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    public partial class ProductFamiliesMetadata
    {
        /// <summary> Contains details related to resource provider. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<ResourceProviderDetails> ResourceProviderDetails => (IReadOnlyList<ResourceProviderDetails>)ResourceProviderDetailsList;
    }
}
