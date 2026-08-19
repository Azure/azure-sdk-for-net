// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class HciClusterReportedProperties
    {
        /// <summary> The MSI expiration time. </summary>
        [CodeGenMember("MsiExpirationTimeStamp")]
        public DateTimeOffset? MsiExpirationOn { get; }
    }
}
