// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ConnectionMonitorCreateOrUpdateContent
    {
        // The required wrapper remains initialized while its flattened input members stay writable.
        [CodeGenMember("Properties")]
        internal ConnectionMonitorParameters Properties { get; set; } = new ConnectionMonitorParameters();

        internal ConnectionMonitorContent ToConnectionMonitorContent() =>
            new ConnectionMonitorContent(Location, Tags, Properties, _additionalBinaryDataProperties);
    }
}
