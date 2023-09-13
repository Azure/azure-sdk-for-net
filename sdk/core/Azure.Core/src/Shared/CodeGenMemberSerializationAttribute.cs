// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class CodeGenMemberSerializationAttribute : Attribute
    {
        public string[] SerializationPath { get; }

        public CodeGenMemberSerializationAttribute(params string[] serializationPath)
        {
            SerializationPath = serializationPath;
        }
    }
}
