// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Generator.MgmtTypeSpec.Tests.Models
{
    internal partial class AutoUpgradeProperties
    {
        /// <summary> Configures how auto-upgrade will be run. </summary>
        [CodeGenMember("Channel")]
        public UpgradeChannel? Channel { get; set; }
    }
}
