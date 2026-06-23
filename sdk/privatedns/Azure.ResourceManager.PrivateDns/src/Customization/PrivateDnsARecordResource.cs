// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// TypeSpec generates a shared record-set data model and record-type parameters; these partials preserve the shipped per-record data and fixed-record-type APIs.

using CodeGenResourceDataAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenResourceDataAttribute;

namespace Azure.ResourceManager.PrivateDns
{
    [CodeGenResourceDataAttribute(typeof(PrivateDnsARecordData))]
    public partial class PrivateDnsARecordResource : ArmResource
    {
    }
}
