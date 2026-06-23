// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Generator.MgmtTypeSpec.Tests.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Generator.MgmtTypeSpec.Tests
{
    [CodeGenTagPatchHook(nameof(PrepareTagPatch))]
    public partial class IssueTestResource
    {
        private void PrepareTagPatch(IssueTestResourcePatch patch, IssueTestResourceData current)
        {
            patch.DisplayName = current.Properties?.DisplayName;
        }
    }
}
