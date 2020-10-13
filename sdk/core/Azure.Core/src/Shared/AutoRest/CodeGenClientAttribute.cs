// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class CodeGenClientAttribute : CodeGenTypeAttribute
    {
        public CodeGenClientAttribute(string originalName) : base(originalName)
        {
        }
    }
}