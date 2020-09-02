// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct, AllowMultiple = true)]
    internal class CodeGenSuppressAttribute : Attribute
    {
        public string Member { get; }
        public Type[] Parameters { get; }

        public CodeGenSuppressAttribute(string member, params Type[] parameters)
        {
            Member = member;
            Parameters = parameters;
        }
    }
}