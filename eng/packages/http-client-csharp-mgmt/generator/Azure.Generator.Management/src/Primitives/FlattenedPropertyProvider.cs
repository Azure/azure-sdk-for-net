// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;

namespace Azure.Generator.Management.Primitives
{
    internal class FlattenedPropertyProvider : PropertyProvider
    {
        public PropertyProvider PropertyFlattenedFrom { get; }

        public FlattenedPropertyProvider(FormattableString? description, MethodSignatureModifiers modifiers, CSharpType type, string name, PropertyBody body, TypeProvider enclosingType, PropertyProvider flattenedFrom, CSharpType? explicitInterface = null, PropertyWireInformation? wireInfo = null, bool isRef = false, IEnumerable<AttributeStatement>? attributes = null)
            : base(description, modifiers, type, name, body, enclosingType, explicitInterface, wireInfo, isRef, attributes)
        {
            PropertyFlattenedFrom = flattenedFrom;
        }
    }
}
