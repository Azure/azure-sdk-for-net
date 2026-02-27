// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class HciSkuMappings
    {
        /// <summary> Initializes a new instance of <see cref="HciSkuMappings"/> for backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected HciSkuMappings(string catalogPlanId) : this()
        {
        }
    }
}
