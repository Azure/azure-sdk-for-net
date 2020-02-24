// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct)]
    internal class CodeGenSchemaAttribute : Attribute
    {
        public string SchemaName { get; }

        public CodeGenSchemaAttribute(string schemaName)
        {
            SchemaName = schemaName;
        }
    }
}
