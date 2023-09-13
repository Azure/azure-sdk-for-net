// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    internal class CodeGenOverrideServiceVersionsAttribute : Attribute
    {
        public string[] Versions { get; }

        public CodeGenOverrideServiceVersionsAttribute(params string[] versions)
        {
            Versions = versions;
        }
    }
}
