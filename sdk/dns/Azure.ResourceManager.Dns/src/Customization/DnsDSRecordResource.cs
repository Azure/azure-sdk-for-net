// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager;
using CodeGenResourceDataAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenResourceDataAttribute;

namespace Azure.ResourceManager.Dns
{
    [CodeGenResourceDataAttribute(typeof(DnsDSRecordData))]
    public partial class DnsDSRecordResource : ArmResource
    {
    }
}