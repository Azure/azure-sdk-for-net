// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.TrafficManager
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct, AllowMultiple = true)]
    internal class CodeGenSuppressAttribute : Attribute
    {
        public CodeGenSuppressAttribute(string member, params Type[] parameters)
        {
            Member = member;
            Parameters = parameters;
        }

        public string Member { get; }
        public Type[] Parameters { get; }
    }
}
