// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class CodeGenClientAttribute : Attribute
    {
        public string OperationGroupName { get; }

        public CodeGenClientAttribute(string operationGroupName)
        {
            OperationGroupName = operationGroupName;
        }
    }
}