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
        /// <summary>
        /// The property that this property is flattened from.
        /// </summary>
        public PropertyProvider FlattenedProperty { get; }

        /// <summary>
        /// The property that this property is directed to.
        /// </summary>
        public PropertyProvider OriginalProperty { get; }

        /// <summary>
        /// True when this flattened property's type was lifted to nullable because the
        /// wrapping parent (the internalized property, e.g. <c>properties?:</c>) may be
        /// absent at runtime. Applies to both value types (<c>Nullable&lt;T&gt;</c>) and
        /// reference types (nullable annotation). The public property surface is
        /// nullable, but the public constructor parameter is kept as the original
        /// inner type to enforce that required leaves are provided. The model factory
        /// parameter, however, is nullable (callers may omit it when mocking).
        /// </summary>
        public bool IsLiftedToNullable { get; }

        public FlattenedPropertyProvider(FormattableString? description, MethodSignatureModifiers modifiers, CSharpType type, string name, PropertyBody body, TypeProvider enclosingType, PropertyProvider flattenedFrom, PropertyProvider originalProperty, CSharpType? explicitInterface = null, PropertyWireInformation? wireInfo = null, bool isRef = false, IEnumerable<AttributeStatement>? attributes = null, bool isLiftedToNullable = false)
            : base(description, modifiers, type, name, body, enclosingType, explicitInterface, wireInfo, isRef, attributes)
        {
            FlattenedProperty = flattenedFrom;
            OriginalProperty = originalProperty;
            IsLiftedToNullable = isLiftedToNullable;
        }
    }
}
