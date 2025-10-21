// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Primitives;

namespace Azure.Generator.Management.Primitives
{
    internal class NewManagementProjectScaffolding : NewAzureProjectScaffolding
    {
        protected override IReadOnlyList<CSharpProjectCompileInclude> BuildCompileIncludes()
            => new List<CSharpProjectCompileInclude>();
    }
}
