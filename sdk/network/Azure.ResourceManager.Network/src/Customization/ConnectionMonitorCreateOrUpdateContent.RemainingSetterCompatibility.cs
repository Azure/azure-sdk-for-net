// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ConnectionMonitorCreateOrUpdateContent type. </summary>
    public partial class ConnectionMonitorCreateOrUpdateContent
    {
        /// <summary> Gets or sets the Location compatibility property. </summary>
        public AzureLocation? Location { get; set; }

        /// <summary> Gets or sets the string compatibility property. </summary>
        public IDictionary<string, string> Tags { get; } = new ChangeTrackingDictionary<string, string>();
    }
}
