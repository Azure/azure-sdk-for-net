// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the InboundSecurityRuleData type. </summary>
    public partial class InboundSecurityRuleData
    {
        /// <summary> Gets or sets the ETag compatibility property. </summary>
        public ETag? ETag { get; }
    }
}
