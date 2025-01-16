// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;

namespace Azure.Generator.Models
{
    internal readonly struct Reference
    {
        public Reference(string name, CSharpType type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public CSharpType Type { get; }
        public TypeProvider? Implementation { get; }

        public static implicit operator Reference(ParameterProvider parameter) => new Reference(parameter.Name, parameter.Type);
        public static implicit operator Reference(FieldProvider field) => new Reference(field.Name, field.Type);
    }
}
