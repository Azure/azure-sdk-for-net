// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct)]
    internal class CodeGenModelAttribute : Attribute
    {
        public string OriginalName { get; }

        public CodeGenModelAttribute(string originalName)
        {
            OriginalName = originalName;
        }
    }
}
