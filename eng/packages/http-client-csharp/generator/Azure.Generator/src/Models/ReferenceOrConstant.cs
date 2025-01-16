// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using System;

namespace Azure.Generator.Models
{
    internal readonly struct ReferenceOrConstant
    {
        private readonly Constant? _constant;
        private readonly Reference? _reference;

        private ReferenceOrConstant(Constant constant)
        {
            Type = constant.Type;
            _constant = constant;
            _reference = null;
        }

        private ReferenceOrConstant(Reference reference)
        {
            Type = reference.Type;
            _reference = reference;
            _constant = null;
        }

        public CSharpType Type { get; }
        public bool IsConstant => _constant.HasValue;

        public Constant Constant => _constant ?? throw new InvalidOperationException("Not a constant");
        public Reference Reference => _reference ?? throw new InvalidOperationException("Not a reference");

        public static implicit operator ReferenceOrConstant(Constant constant) => new ReferenceOrConstant(constant);
        public static implicit operator ReferenceOrConstant(Reference reference) => new ReferenceOrConstant(reference);
        public static implicit operator ReferenceOrConstant(ParameterProvider parameter) => new ReferenceOrConstant(new Reference(parameter.Name, parameter.Type));
        public static implicit operator ReferenceOrConstant(FieldProvider field) => new ReferenceOrConstant(new Reference(field.Name, field.Type));
    }
}
