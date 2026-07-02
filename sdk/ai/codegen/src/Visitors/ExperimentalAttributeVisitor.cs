// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Extensions.Plugin.Visitors
{
    /// <summary>
    /// A visitor that adds <see cref="ExperimentalAttribute"/> to generated public types that are not
    /// present in the stable-types baseline. This ensures that newly introduced generated types are
    /// automatically tagged as experimental until explicitly promoted.
    /// </summary>
    /// <remarks>
    /// This visitor mirrors the pattern established by the upstream OpenAI library's codegen plugin
    /// (ExperimentalAttributeVisitor), adapted for Azure.AI.Extensions.OpenAI conventions.
    /// </remarks>
    public class ExperimentalAttributeVisitor : ScmLibraryVisitor
    {
        private const string DiagnosticId = "AAIP001";

        private readonly HashSet<string> _attributedTypes = new(StringComparer.Ordinal);

        private static bool ImplementsExperimrental(TypeProvider theType)
        {
            foreach(CSharpType theInterface in theType.Implements)
            {
                if (SupportedPackages.IsExperimental(theInterface.FullyQualifiedName))
                {
                    return true;
                }
                if (theInterface.IsGenericType)
                {
                    foreach (CSharpType generic in theInterface.Arguments)
                    {
                        if(SupportedPackages.IsExperimental(generic.FullyQualifiedName))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private static bool HasExperimentalAncestor(CSharpType theType)
        {
            if (theType.BaseType is null)
            {
                return false;
            }
            return SupportedPackages.IsExperimental(theType.BaseType.FullyQualifiedName) || HasExperimentalAncestor(theType.BaseType);
        }

        public static bool IsExperimental(CSharpType theType)
        {
            if (theType is null)
            {
                return false;
            }
            theType = theType.GetNestedElementType();
            if (SupportedPackages.IsExperimental(theType.FullyQualifiedName))
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

        private static string GetRealName(TypeProvider type)
        {
            string className = type.Type.FullyQualifiedName.Substring(type.Type.FullyQualifiedName.LastIndexOf('.') + 1);
            string classPath = type.Type.FullyQualifiedName.Substring(0, type.Type.FullyQualifiedName.Length - className.Length - 1);
            // Get the class name according to typespec
            IEnumerable<AttributeStatement> allAttributes =
            [
                .. type.Attributes,
                .. type.CustomCodeView?.Attributes ?? [],
                .. type.SerializationProviders.SelectMany(serializer => serializer.Attributes),
                .. type.SerializationProviders.SelectMany(serializer => serializer.CustomCodeView?.Attributes ?? []),
            ];
            // If typespec does not changes the class name, leave the original class name.
            string realName = allAttributes
                .Where(x => string.Equals(x.Type.Name, "CodeGenTypeAttribute") && x.Arguments.Count == 1 && x.Arguments[0] is LiteralExpression)
                .Select(x => (x.Arguments[0] as LiteralExpression).Literal.ToString())
                .FirstOrDefault(x => !string.IsNullOrEmpty(x)) ?? className;
            return $"{classPath}.{realName}";
        }

        /// <inheritdoc />
        protected override TypeProvider VisitType(TypeProvider type)
        {
            // Diagnostic code for troubleshooting.
            //if (string.Equals(type.Type.Name, "MemorySearchPreviewTool"))
            //{
            //    throw new InvalidOperationException(
            //        $"================================================\n" +
            //        $"{GetRealName(type)}\n" +
            //        $"Is already experimental: {_attributedTypes.Contains(type.Type.FullyQualifiedName)}\n" +
            //        $"Has experimental parent: {HasExperimentalAncestor(type.Type)}\n" +
            //        $"Implements experimental interface: {ImplementsExperimrental(type)}\n" +
            //        $"Has the experimental attribute: {type.Attributes.Any(attr => attr.Type.Equals(typeof(ExperimentalAttribute)))}\n" +
            //        $"Is explicitly marked as experimental: {SupportedPackages.IsExperimental(GetRealName(type))}\n" +
            //        $"================================================\n");
            //}
            // Fisrt check if the whole class needs to be marked as experimental.
            if ((SupportedPackages.IsExperimental(GetRealName(type)) || HasExperimentalAncestor(type.Type) || ImplementsExperimrental(type))
                && !type.Attributes.Any(attr => attr.Type.Equals(typeof(ExperimentalAttribute)))
                && _attributedTypes.Add(type.Type.FullyQualifiedName))
            {
                type.Update(
                    attributes: [.. type.Attributes,
                        new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]);
                return type;
            }
            // If the whole class was already marked as experimental, no need to mark methods/constructors/properties.
            if (_attributedTypes.Contains(type.Type.FullyQualifiedName))
            {
                return base.VisitType(type);
            }
            bool isDirty = false;
            // Constructors
            List<ConstructorProvider> constructors = [];
            // In a first run we will check if all the constructors are experimental and if it is the case, mark class experimental.
            if (type.Constructors.Count > 0 && type.Constructors.All(x => x.Signature.Parameters.Any(x => IsExperimental(x.Type))))
            {
                type.Update(
                    attributes: [.. type.Attributes,
                        new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]);
                return type;
            }
            // If there is at least one constriuctor without experimental argument, just update experimental constructors.
            foreach (ConstructorProvider constructor in type.Constructors)
            {
                if (constructor.Signature.Parameters.Any(x => IsExperimental(x.Type)))
                {
                    constructor.Signature.Update(
                        attributes: [.. constructor.Signature.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]
                    );
                    isDirty = true;
                }
                constructors.Add(constructor);
            }
            // Methods
            List<MethodProvider> methods = [];
            foreach (MethodProvider method in type.Methods)
            {
                if (method.Signature.Parameters.Any(x => IsExperimental(x.Type)) || IsExperimental(method.Signature.ReturnType))
                {
                    method.Signature.Update(
                        attributes: [.. method.Signature.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]
                    );
                    isDirty = true;
                }
                methods.Add(method);
            }
            // Fields
            List<FieldProvider> fields = [];
            foreach (FieldProvider field in type.Fields)
            {
                if (IsExperimental(field.Type))
                {
                    field.Update(
                        attributes: [.. field.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]
                    );
                    isDirty = true;
                }
                fields.Add(field);
            }
            if (isDirty)
            {
                type.Update(
                    constructors: constructors,
                    methods: methods,
                    fields: fields
                );
                return type;
            }
            return base.VisitType(type);
        }

        protected override MethodProvider VisitMethod(MethodProvider method)
        {
            // Diagnostics code for troubleshooting.
            //if (string.Equals(method.Signature.Name, "CodeBasedEvaluatorDefinition"))
            //{
            //    throw new InvalidOperationException(
            //        $"================================================\n" +
            //        $"Is already experimental: {method.Signature.Attributes.Any(attr => attr.Type.Equals(typeof(ExperimentalAttribute)))}\n" +
            //        $"Return type is experimental: {SupportedPackages.IsExperimental(method.Signature.ReturnType?.FullyQualifiedName)}\n" +
            //        $"Parameters were previously marked as experimental (include renames): {method.Signature.Parameters.Any(x => _attributedTypes.Contains(x.Type.FullyQualifiedName))}\n" +
            //        $"Parameters are explicitly marked as experimental: {method.Signature.Parameters.Any(x => SupportedPackages.IsExperimental(x.Type.FullyQualifiedName))}\n" +
            //        $"{(method.Signature.Attributes[0].Arguments[0] as ScopedApi).Original}.\n" +
            //        $"================================================\n");
            //}
            // If the whole class was already marked as experimental, no need to mark methods.
            if (_attributedTypes.Contains(method.EnclosingType.Type.FullyQualifiedName))
            {
                return base.VisitMethod(method);
            }
            if (!method.Signature.Attributes.Any(attr => attr.Type.Equals(typeof(ExperimentalAttribute))) && (
                method.Signature.Parameters.Any(x => _attributedTypes.Contains(x.Type.FullyQualifiedName) || SupportedPackages.IsExperimental(x.Type.FullyQualifiedName))
                || _attributedTypes.Contains(method.Signature.ReturnType?.FullyQualifiedName)
                || SupportedPackages.IsExperimental(method.Signature.ReturnType?.FullyQualifiedName)))
            {
                method.Signature.Update(
                    attributes: [.. method.Signature.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]
                );
                return method;
            }
            return base.VisitMethod(method);
        }
    }
}