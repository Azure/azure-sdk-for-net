// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ArcData.Models
{
    public partial class DbmEndpoint
    {
        /// <summary> Listener IP address. </summary>
        [CodeGenMember("IPAddress")]
        public string IpAddress { get; }
    }
}
