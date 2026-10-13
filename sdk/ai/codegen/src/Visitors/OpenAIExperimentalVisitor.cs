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
    /// A visitor that marks the generated public surface that exposes OpenAI-experimental types with a
    /// dedicated <c>AAIP002</c> experimental id, meaning "experimental because it depends on OpenAI-experimental
    /// surface, not because Azure is actively changing it". This replaces the blanket assembly-wide
    /// <c>nowarn</c> suppression for generated code with correct, per-symbol attribution driven by reflection
    /// over the OpenAI assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The set of experimental OpenAI types is sourced from <see cref="OpenAIExperimentalCatalog"/>, which reads
    /// the OpenAI assembly the SDK compiles against, so no hand-maintained list is required. Only membership is
    /// used: OpenAI's own diagnostic id is intentionally not propagated — the single <c>AAIP002</c> id is stamped
    /// instead so downstream consumers acknowledge one stable Azure-owned id decoupled from OpenAI's id churn.
    /// </para>
    /// <para>
    /// Granularity: a generated type is marked <see cref="ExperimentalAttribute"/> at the <em>type</em> level
    /// only when it is itself experimental — it derives from an OpenAI-experimental base or implements an
    /// OpenAI-experimental interface. Otherwise-stable types that merely reference an experimental type in a
    /// subset of members are marked at the <em>member</em> level, so their stable members remain
    /// warning-free for downstream consumers.
    /// </para>
    /// <para>
    /// This visitor runs <em>after</em> <see cref="ExperimentalAttributeVisitor"/> so that a declaration which is
    /// experimental for both reasons keeps our intentional <c>AAIP001</c> id (the stronger signal); both visitors
    /// skip declarations that already have an <see cref="ExperimentalAttribute"/>, avoiding double-marking.
    /// Because C# suppresses every experimental reference inside any <c>[Experimental]</c> scope regardless of id,
    /// stamping <c>AAIP002</c> (or <c>AAIP001</c>) still silences the internal references to OpenAI-experimental
    /// types without any assembly-wide <c>NoWarn</c>.
    /// </para>
    /// </remarks>
    public class OpenAIExperimentalVisitor : ScmLibraryVisitor
    {
        /// <summary>
        /// Diagnostic id stamped by this visitor. Distinct from OpenAI's own ids (<c>OPENAI001</c>, …): it
        /// signals that the declaration is experimental <em>because it exposes OpenAI-experimental surface</em>,
        /// not because Azure is actively changing it. Because C# suppresses every experimental reference inside
        /// any <c>[Experimental]</c> scope regardless of id, stamping our own id still silences the internal
        /// references to OpenAI-experimental types without an assembly-wide <c>NoWarn</c>.
        /// </summary>
        private const string DiagnosticId = "AAIP002";

        private readonly HashSet<string> _attributedTypes = new(StringComparer.Ordinal);

        private static bool HasExperimentalAttribute(IEnumerable<AttributeStatement> attributes)
            => attributes.Any(attr => attr.Type.Equals(typeof(ExperimentalAttribute)));

        /// <summary>Returns whether the nearest base type is an OpenAI-experimental type.</summary>
        private static bool HasExperimentalAncestor(CSharpType theType)
        {
            if (theType.BaseType is null)
            {
                return false;
            }
            if (OpenAIExperimentalCatalog.Instance.IsExperimental(theType.BaseType.FullyQualifiedName))
            {
                return true;
            }
            return HasExperimentalAncestor(theType.BaseType);
        }

        /// <summary>Returns whether the type implements an OpenAI-experimental interface.</summary>
        private static bool ImplementsExperimental(TypeProvider theType)
        {
            foreach (CSharpType theInterface in theType.Implements)
            {
                if (OpenAIExperimentalCatalog.Instance.IsExperimental(theInterface.FullyQualifiedName))
                {
                    return true;
                }
                if (theInterface.IsGenericType)
                {
                    foreach (CSharpType generic in theInterface.Arguments)
                    {
                        if (IsExperimental(generic))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Returns whether the supplied type (unwrapping nested/generic element types and inspecting generic
        /// arguments and base types) references an OpenAI-experimental type.
        /// </summary>
        public static bool IsExperimental(CSharpType theType)
        {
            if (theType is null)
            {
                return false;
            }
            theType = theType.GetNestedElementType();
            if (OpenAIExperimentalCatalog.Instance.IsExperimental(theType.FullyQualifiedName))
            {
                return true;
            }
            if (theType.IsGenericType)
            {
                foreach (CSharpType generic in theType.Arguments)
                {
                    if (IsExperimental(generic))
                    {
                        return true;
                    }
                }
            }
            return HasExperimentalAncestor(theType);
        }

        private static bool SignatureIsExperimental(IReadOnlyList<ParameterProvider> parameters, CSharpType returnType = null)
        {
            foreach (ParameterProvider parameter in parameters)
            {
                if (IsExperimental(parameter.Type))
                {
                    return true;
                }
            }
            return returnType is not null && IsExperimental(returnType);
        }

        /// <inheritdoc />
        protected override TypeProvider VisitType(TypeProvider type)
        {
            // Never touch the generated ModelReaderWriterContext. Reading its Attributes here forces the base
            // generator to build the context's buildable set eagerly, which caches every buildable type's
            // CanonicalView. Doing so can drop the #pragma wrappers the base generator otherwise emits around
            // those buildables. The context exposes no OpenAI-experimental surface of its own, so skipping it
            // loses no propagation; its external experimental registrations remain covered by the assembly-wide
            // suppression.
            if (string.Equals(type.Type.BaseType?.Name, "ModelReaderWriterContext", StringComparison.Ordinal))
            {
                return type;
            }

            // Skip declarations already carrying an [Experimental] attribute (e.g. our own AAIP001 applied by
            // the prior ExperimentalAttributeVisitor). Record the FQN so the type's serialization partial —
            // visited via base.VisitType below and which shares the same FQN and OpenAI-experimental ancestor —
            // is not independently marked, which would place a second [Experimental] on the same partial type.
            if (HasExperimentalAttribute(type.Attributes))
            {
                _attributedTypes.Add(type.Type.FullyQualifiedName);
                return base.VisitType(type);
            }

            // Whole-type marking: only when the type is itself experimental — it derives from an
            // OpenAI-experimental base or implements an OpenAI-experimental interface. This clears the
            // experimental base clause and every member body/serialization partial in one attribute
            // without needing local suppression. A type that merely references an experimental type in a
            // subset of members is left to member-level marking below so its stable members stay
            // warning-free for downstream consumers.
            if ((HasExperimentalAncestor(type.Type) || ImplementsExperimental(type))
                && _attributedTypes.Add(type.Type.FullyQualifiedName))
            {
                type.Update(
                    attributes: [.. type.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]);
                return type;
            }

            // If the type was already marked at the type level (for example via its model partial), its
            // members — including this serialization partial's — are already covered; do not mark them again.
            if (_attributedTypes.Contains(type.Type.FullyQualifiedName))
            {
                return base.VisitType(type);
            }

            bool isDirty = false;

            // Constructors: mark per-constructor (not the whole type) so stable members stay warning-free.
            List<ConstructorProvider> constructors = [];
            foreach (ConstructorProvider constructor in type.Constructors)
            {
                if (SignatureIsExperimental(constructor.Signature.Parameters) && !HasExperimentalAttribute(constructor.Signature.Attributes))
                {
                    constructor.Signature.Update(
                        attributes: [.. constructor.Signature.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]);
                    isDirty = true;
                }
                constructors.Add(constructor);
            }

            // Methods: mark when a parameter or the return type exposes an experimental type.
            List<MethodProvider> methods = [];
            foreach (MethodProvider method in type.Methods)
            {
                if (SignatureIsExperimental(method.Signature.Parameters, method.Signature.ReturnType) && !HasExperimentalAttribute(method.Signature.Attributes))
                {
                    method.Signature.Update(
                        attributes: [.. method.Signature.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]);
                    isDirty = true;
                }
                methods.Add(method);
            }

            // Fields: mark when the field type exposes an experimental type.
            List<FieldProvider> fields = [];
            foreach (FieldProvider field in type.Fields)
            {
                if (IsExperimental(field.Type) && !HasExperimentalAttribute(field.Attributes))
                {
                    field.Update(
                        attributes: [.. field.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]);
                    isDirty = true;
                }
                fields.Add(field);
            }

            // Properties: mark when the property type exposes an experimental type.
            List<PropertyProvider> properties = [];
            foreach (PropertyProvider property in type.Properties)
            {
                if (IsExperimental(property.Type) && !HasExperimentalAttribute(property.Attributes))
                {
                    property.Update(
                        attributes: [.. property.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]);
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
            if (!HasExperimentalAttribute(method.Signature.Attributes)
                && SignatureIsExperimental(method.Signature.Parameters, method.Signature.ReturnType))
            {
                method.Signature.Update(
                    attributes: [.. method.Signature.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]);
                return method;
            }
            return base.VisitMethod(method);
        }
    }
}
