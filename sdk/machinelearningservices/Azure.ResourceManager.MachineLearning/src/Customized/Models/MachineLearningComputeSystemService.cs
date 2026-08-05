// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy IP address aliases whose casing/type differs from TypeSpec naming.
    public partial class MachineLearningComputeSystemService
    {
        /// <summary> Public IP address. </summary>
        [WirePath("publicIpAddress")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PublicIPAddress => PublicIpAddress;
    }
}
