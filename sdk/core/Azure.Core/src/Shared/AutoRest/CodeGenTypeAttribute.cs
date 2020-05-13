// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class CodeGenTypeAttribute : Attribute
    {
        public string? OriginalName { get; }

        public CodeGenTypeAttribute(string? originalName)
        {
            OriginalName = originalName;
        }
    }
}