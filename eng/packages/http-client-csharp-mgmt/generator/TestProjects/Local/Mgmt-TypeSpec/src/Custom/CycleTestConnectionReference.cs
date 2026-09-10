// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.Generator.MgmtTypeSpec.Tests.Models
{
    // Repro for the AppConfiguration cycle: a Custom/ partial class forces a plain
    // model (with @flattenProperty) to inherit from ResourceData.  This causes the
    // FlattenPropertyVisitor's BaseType-chain walk to hit a ResourceData → ResourceData
    // self-reference in CSharpTypeMap.
    public partial class CycleTestConnectionReference : ResourceData
    { }
}
