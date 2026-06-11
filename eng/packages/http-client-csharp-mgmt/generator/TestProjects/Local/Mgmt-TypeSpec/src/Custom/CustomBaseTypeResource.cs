// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager;

namespace Azure.Generator.MgmtTypeSpec.Tests
{
    // Real resource custom code may extend ArmResource on the pre-Data resource name.
    // Resource data generation must ignore this custom base type after appending "Data".
    [CodeGenResourceData(typeof(CustomBaseTypeResourceCustomData))]
    public partial class CustomBaseTypeResource : ArmResource
    { }
}
