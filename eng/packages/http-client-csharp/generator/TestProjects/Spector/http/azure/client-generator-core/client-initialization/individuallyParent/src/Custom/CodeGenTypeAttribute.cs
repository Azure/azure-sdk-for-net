// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.TypeSpec.Generator.Customizations
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct)]
    internal sealed class CodeGenTypeAttribute : Attribute
    {
        public CodeGenTypeAttribute(string originalName)
        {
            OriginalName = originalName;
        }

        public string OriginalName { get; }
    }
}
