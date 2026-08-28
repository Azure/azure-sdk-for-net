// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declarations for generated members that intentionally hide inherited ARM members. </summary>
    [CodeGenSuppress("Name")]
    [CodeGenSuppress("Id")]
    public partial class AvailableDelegation
    {
        // The generated member intentionally preserves the service wire shape while hiding an inherited ARM member.
        // TODO: Remove this SDK-side workaround after https://github.com/Azure/azure-sdk-for-net/issues/60023 is fixed.
        /// <summary> The name of the AvailableDelegation resource. </summary>
        [WirePath("name")]
        public new string Name { get; }
        /// <summary> A unique identifier of the AvailableDelegation resource. </summary>
        [WirePath("id")]
        public new string Id { get; }
    }
}
