// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Primitives;

namespace Azure.Generator.Management.Primitives
{
    internal class NewManagementProjectScaffolding : NewAzureProjectScaffolding
    {
        private const string MgmtCoreSharedProperty = "$(MgmtCoreShared)";
        private const string MgmtSharedSourceLinkBase = "Shared/Management";

        protected override IReadOnlyList<CSharpProjectCompileInclude> BuildCompileIncludes()
        {
            var baseIncludes = base.BuildCompileIncludes();
            var compileIncludes = new List<CSharpProjectCompileInclude>(baseIncludes);

            // Add mgmt-specific shared source files from Azure.ResourceManager
            compileIncludes.Add(new CSharpProjectCompileInclude($"{MgmtCoreSharedProperty}/**/*.cs", MgmtSharedSourceLinkBase));

            return compileIncludes;
        }
    }
}
