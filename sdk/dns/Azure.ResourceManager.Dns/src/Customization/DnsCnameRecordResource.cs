// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager;
using CodeGenResourceDataAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenResourceDataAttribute;

namespace Azure.ResourceManager.Dns
{
    [CodeGenResourceDataAttribute(typeof(DnsCnameRecordData))]
    public partial class DnsCnameRecordResource : ArmResource
    {
    }
}