// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Primitives;

namespace Azure.Generator.Management.Primitives
{
    internal class NewManagementProjectScaffolding : NewAzureProjectScaffolding
    {
        private const string SharedCoreLinkBase = "Shared/Core";
        private const string SharedArmLinkBase = "Shared/Arm";

        private const string RelativeArmSegment = "sdk/resourcemanager/Azure.ResourceManager/src/Shared/";

        protected override IReadOnlyList<CSharpProjectCompileInclude> BuildCompileIncludes()
        {
            var compileIncludes = new List<CSharpProjectCompileInclude>();
            compileIncludes.AddRange(base.BuildCompileIncludes());

            foreach (var coreShareFile in coreSharedFiles)
            {
                compileIncludes.Add(new CSharpProjectCompileInclude(GetCompileInclude(coreShareFile), SharedCoreLinkBase));
            }

            foreach (var armShareFile in armSharedFiles)
            {
                compileIncludes.Add(new CSharpProjectCompileInclude(GetCompileInclude(armShareFile, RelativeArmSegment), SharedArmLinkBase));
            }

            return compileIncludes;
        }

        private static IReadOnlyList<string> coreSharedFiles = new List<string>
        {
            "ForwardsClientCallsAttribute.cs",
            "NoValueResponseOfT.cs"
        };

        private static IReadOnlyList<string> armSharedFiles = new List<string>
        {
            "SharedExtensions.cs"
        };
    }
}
