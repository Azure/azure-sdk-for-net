// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class NetworkAdapterReportedProperties
    {
        /// <summary> Indicates whether this is a management interface. </summary>
        [CodeGenMember("ManagementInterface")]
        public bool? IsManagementInterface { get; }
    }
}
