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

        /// <inheritdoc />
        protected override TypeProvider VisitType(TypeProvider type)
        {
            string fullName = $"{type.Type.Namespace}.{type.Name}";
            if ((type.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public)
                    || type.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Protected))
                && !type.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Internal)
                && !SupportedPackages.IsStable(fullName)
                && !type.Attributes.Any(attr => attr.Type.Equals(typeof(ExperimentalAttribute)))
                && _attributedTypes.Add(fullName))
            {
                type.Update(
                    attributes: [.. type.Attributes,
                        new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]);
                return type;
            }

            return base.VisitType(type);
        }
    }
}
