// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;

namespace Extensions.Plugin.Visitors
{
    /// <summary>
    /// A visitor that propagates the consumed OpenAI library's experimental markers
    /// (e.g. <c>OPENAI001</c>, <c>OPENAICUA001</c>) onto the generated public surface that exposes
    /// OpenAI-experimental types. This replaces the blanket assembly-wide <c>nowarn</c> suppression for
    /// generated code with correct, per-symbol attribution driven by reflection over the OpenAI assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The experimental status is sourced from <see cref="OpenAIExperimentalCatalog"/>, which reads the
    /// OpenAI assembly the SDK compiles against, so no hand-maintained list is required.
    /// </para>
    /// <para>
    /// Granularity: a generated type is marked <see cref="ExperimentalAttribute"/> at the <em>type</em> level
    /// only when it is itself experimental — it derives from an OpenAI-experimental base or implements an
    /// OpenAI-experimental interface. Otherwise-stable types that merely reference an experimental type in a
    /// subset of members are marked at the <em>member</em> level, so their stable members remain
    /// warning-free for downstream consumers.
    /// </para>
    /// <para>
    /// This visitor runs before <see cref="ExperimentalAttributeVisitor"/> so declarations exposing OpenAI
    /// types carry the correct OpenAI diagnostic id; both visitors skip declarations that already have an
    /// <see cref="ExperimentalAttribute"/>, avoiding double-marking.
    /// </para>
    /// </remarks>
    public class OpenAIExperimentalVisitor : ScmLibraryVisitor
    {
        private readonly HashSet<string> _attributedTypes = new(StringComparer.Ordinal);

        private static bool HasExperimentalAttribute(IEnumerable<AttributeStatement> attributes)
            => attributes.Any(attr => attr.Type.Equals(typeof(ExperimentalAttribute)));

        /// <summary>Returns the experimental diagnostic id of the nearest experimental base type, or null.</summary>
        private static string GetAncestorExperimentalId(CSharpType theType)
        {
            if (theType.BaseType is null)
            {
                return null;
            }
            if (OpenAIExperimentalCatalog.Instance.TryGetId(theType.BaseType.FullyQualifiedName, out string id))
            {
                return id;
            }
            return GetAncestorExperimentalId(theType.BaseType);
        }

        /// <summary>Returns the experimental diagnostic id of an experimental implemented interface, or null.</summary>
        private static string GetInterfaceExperimentalId(TypeProvider theType)
        {
            foreach (CSharpType theInterface in theType.Implements)
            {
                if (OpenAIExperimentalCatalog.Instance.TryGetId(theInterface.FullyQualifiedName, out string id))
                {
                    return id;
                }
                if (theInterface.IsGenericType)
                {
                    foreach (CSharpType generic in theInterface.Arguments)
                    {
                        string genericId = GetExperimentalId(generic);
                        if (genericId is not null)
                        {
                            return genericId;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the experimental diagnostic id when the supplied type (unwrapping nested/generic element
        /// types and inspecting generic arguments and base types) references an OpenAI-experimental type.
        /// </summary>
        public static string GetExperimentalId(CSharpType theType)
        {
            if (theType is null)
            {
                return null;
            }
            theType = theType.GetNestedElementType();
            if (OpenAIExperimentalCatalog.Instance.TryGetId(theType.FullyQualifiedName, out string id))
            {
                return id;
            }
            if (theType.IsGenericType)
            {
                foreach (CSharpType generic in theType.Arguments)
                {
                    string genericId = GetExperimentalId(generic);
                    if (genericId is not null)
                    {
                        return genericId;
                    }
                }
            }
            return GetAncestorExperimentalId(theType);
        }

        private static string GetSignatureExperimentalId(IReadOnlyList<ParameterProvider> parameters, CSharpType returnType = null)
        {
            foreach (ParameterProvider parameter in parameters)
            {
                string id = GetExperimentalId(parameter.Type);
                if (id is not null)
                {
                    return id;
                }
            }
            return returnType is null ? null : GetExperimentalId(returnType);
        }

        /// <inheritdoc />
        protected override TypeProvider VisitType(TypeProvider type)
        {
            // Never touch the generated ModelReaderWriterContext. Reading its Attributes here forces the base
            // generator to build the context's buildable set eagerly, which caches every buildable type's
            // CanonicalView. Because this visitor runs before ExperimentalAttributeVisitor, doing so before
            // AAIP001 markings are applied drops the #pragma wrappers the base generator otherwise emits around
            // those buildables. The context exposes no OpenAI-experimental surface of its own, so skipping it
            // loses no propagation; its external experimental registrations remain covered by the assembly-wide
            // suppression.
            if (string.Equals(type.Type.BaseType?.Name, "ModelReaderWriterContext", StringComparison.Ordinal))
            {
                return type;
            }

            // Skip declarations already carrying an [Experimental] attribute (e.g. marked by a prior visitor)
            // so the two experimental visitors never double-mark the same declaration.
            if (HasExperimentalAttribute(type.Attributes))
            {
                return base.VisitType(type);
            }

            // Whole-type marking: only when the type is itself experimental — it derives from an
            // OpenAI-experimental base or implements an OpenAI-experimental interface. This clears the
            // experimental base clause and every member body/serialization partial in one attribute
            // without needing local suppression. A type that merely references an experimental type in a
            // subset of members is left to member-level marking below so its stable members stay
            // warning-free for downstream consumers.
            string typeId = GetAncestorExperimentalId(type.Type)
                ?? GetInterfaceExperimentalId(type);
            if (typeId is not null && _attributedTypes.Add(type.Type.FullyQualifiedName))
            {
                type.Update(
                    attributes: [.. type.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(typeId))]);
                return type;
            }

            bool isDirty = false;

            // Constructors: mark per-constructor (not the whole type) so stable members stay warning-free.
            List<ConstructorProvider> constructors = [];
            foreach (ConstructorProvider constructor in type.Constructors)
            {
                string id = GetSignatureExperimentalId(constructor.Signature.Parameters);
                if (id is not null && !HasExperimentalAttribute(constructor.Signature.Attributes))
                {
                    constructor.Signature.Update(
                        attributes: [.. constructor.Signature.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(id))]);
                    isDirty = true;
                }
                constructors.Add(constructor);
            }

            // Methods: mark when a parameter or the return type exposes an experimental type.
            List<MethodProvider> methods = [];
            foreach (MethodProvider method in type.Methods)
            {
                string id = GetSignatureExperimentalId(method.Signature.Parameters, method.Signature.ReturnType);
                if (id is not null && !HasExperimentalAttribute(method.Signature.Attributes))
                {
                    method.Signature.Update(
                        attributes: [.. method.Signature.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(id))]);
                    isDirty = true;
                }
                methods.Add(method);
            }

            // Fields: mark when the field type exposes an experimental type.
            List<FieldProvider> fields = [];
            foreach (FieldProvider field in type.Fields)
            {
                string id = GetExperimentalId(field.Type);
                if (id is not null && !HasExperimentalAttribute(field.Attributes))
                {
                    field.Update(
                        attributes: [.. field.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(id))]);
                    isDirty = true;
                }
                fields.Add(field);
            }

            // Properties: mark when the property type exposes an experimental type.
            List<PropertyProvider> properties = [];
            foreach (PropertyProvider property in type.Properties)
            {
                string id = GetExperimentalId(property.Type);
                if (id is not null && !HasExperimentalAttribute(property.Attributes))
                {
                    property.Update(
                        attributes: [.. property.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(id))]);
                    isDirty = true;
                }
                properties.Add(property);
            }

            if (isDirty)
            {
                type.Update(
                    constructors: constructors,
                    methods: methods,
                    fields: fields,
                    properties: properties);
                return type;
            }

            return base.VisitType(type);
        }

        /// <inheritdoc />
        protected override MethodProvider VisitMethod(MethodProvider method)
        {
            // If the enclosing type is already wholly experimental, its members are covered.
            if (_attributedTypes.Contains(method.EnclosingType.Type.FullyQualifiedName))
            {
                return base.VisitMethod(method);
            }
            if (!HasExperimentalAttribute(method.Signature.Attributes))
            {
                string id = GetSignatureExperimentalId(method.Signature.Parameters, method.Signature.ReturnType);
                if (id is not null)
                {
                    method.Signature.Update(
                        attributes: [.. method.Signature.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(id))]);
                    return method;
                }
            }
            return base.VisitMethod(method);
        }
    }
}
