// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    internal class CodeGenSuppressTypeAttribute : Attribute
    {
        public string Typename { get; }

        public CodeGenSuppressTypeAttribute(string typename)
        {
            Typename = typename;
        }
    }
}
